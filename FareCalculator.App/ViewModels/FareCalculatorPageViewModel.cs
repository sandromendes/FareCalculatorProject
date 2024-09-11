using FareCalculator.Core.Models;
using System;
using System.Windows.Input;
using Prism.Commands;
using FareCalculator.Core.Enums;
using FareCalculator.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Prism.Windows.Mvvm;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FareCalculator.App.ViewModels
{
    public class FareCalculatorPageViewModel : ViewModelBase
    {
        private readonly IFareCalculatorService _fareCalculatorService;
        private readonly IDistanceCalculatorService _distanceCalculatorService;

        public ICommand CalculateFareCommand { get; }
        public ICommand ClearCommand { get; }


        public FareCalculatorPageViewModel(IFareCalculatorService fareCalculatorService, IDistanceCalculatorService distanceCalculatorService)
        {
            _fareCalculatorService = fareCalculatorService;
            _distanceCalculatorService = distanceCalculatorService;

            LoadUberOptions();
            LoadCityOptions();

            SelectedUberOption = UberType.UBER_X.ToString();
            SelectedOrigin = CityTypes.RECIFE.ToString();
            SelectedDestination = CityTypes.OLINDA.ToString();

            CalculateFareCommand = new DelegateCommand(ExecuteCalculateFare);
            ClearCommand = new DelegateCommand(ExecuteClear);
        }

        public void LoadUberOptions() => UberOptions = Enum.GetNames(typeof(UberType)).ToList();
        public void LoadCityOptions() => CityOptions = Enum.GetNames(typeof(CityTypes)).ToList();

        public List<string> UberOptions { get; set; }

        private string _selectedUberType;
        public string SelectedUberOption
        {
            get => _selectedUberType;
            set
            {
                SetProperty(ref _selectedUberType, value);
                RaisePropertyChanged(nameof(IsDeliveryTypeVisible));
                RaisePropertyChanged(nameof(IsPassengerTypeVisible));
            }
        }
        
        public List<string> CityOptions { get; set; }
        
        private string _selectedOrigin;
        public string SelectedOrigin
        {
            get => _selectedOrigin;
            set => SetProperty(ref _selectedOrigin, value);
        }

        private string _selectedDestination;
        public string SelectedDestination
        {
            get => _selectedDestination;
            set => SetProperty(ref _selectedDestination, value);
        }

        private int _distance;
        public int Distance
        {
            get => _distance;
            set => SetProperty(ref _distance, value);
        }

        private decimal _weight;
        public decimal Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        private decimal _height;
        public decimal Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private decimal _width;
        public decimal Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private decimal _length;
        public decimal Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }


        private string _fareResult;
        public string FareResult
        {
            get => _fareResult;
            private set => SetProperty(ref _fareResult, value);
        }

        private string _distanceResult;
        public string DistanceResult
        {
            get => _distanceResult;
            private set => SetProperty(ref _distanceResult, value);
        }

        public bool IsDeliveryTypeVisible
        {
            get
            {
                if (Enum.TryParse(SelectedUberOption, out UberType selectedType))
                {
                    return selectedType == UberType.UBER_FLASH || selectedType == UberType.UBER_FLASH_MOTO;
                }
                return false;
            }
        }

        public bool IsPassengerTypeVisible
        {
            get
            {
                if (Enum.TryParse(SelectedUberOption, out UberType selectedType))
                {
                    return selectedType == UberType.UBER_X || selectedType == UberType.UBER_VIP ||
                           selectedType == UberType.UBER_BLACK || selectedType == UberType.UBER_MOTO;
                }
                return false;
            }
        }

        private async void ExecuteCalculateFare()
        {
            try
            {
                if (IsDeliveryTypeVisible && (Weight <= 0 || Height <= 0 || Width <= 0 || Length <= 0))
                {
                    await ShowAlertDialog("There's at least one measure field with zero or empty.");
                    return;
                }

                Enum.TryParse(SelectedOrigin, out CityTypes selectedOrigin);
                Enum.TryParse(SelectedDestination, out CityTypes selectedDestination);

                Distance = await _distanceCalculatorService.CalculateDistanceAsync(selectedOrigin, selectedDestination);

                Enum.TryParse(SelectedUberOption, out UberType selectedType);

                var fare = _fareCalculatorService
                    .CalculateFare(CreateVehicle(selectedType), Distance, Weight, Height * Width * Length); 

                FareResult = $"Calculated Fare: {fare:C}";
                DistanceResult = $"Calculated Distance: {Distance} km";
            }
            catch (Exception ex)
            {
                FareResult = $"Error calculating fare: {ex.Message}";
            }
        }

        private void ExecuteClear()
        {
            SelectedUberOption = UberType.UBER_X.ToString();
            SelectedOrigin = CityTypes.RECIFE.ToString();
            SelectedDestination = CityTypes.OLINDA.ToString();
            Weight = 0;
            Height = 0;
            Width = 0;
            Length = 0;
            FareResult = string.Empty;
            DistanceResult = string.Empty;
        }

        private Vehicle CreateVehicle(UberType type)
        {
            switch (type)
            {
                case UberType.UBER_X:
                    return new UberX { Passengers = IsPassengerTypeVisible ? 1 : 0 };
                case UberType.UBER_VIP:
                    return new UberVip { Passengers = IsPassengerTypeVisible ? 1 : 0 };
                case UberType.UBER_BLACK:
                    return new UberBlack { Passengers = IsPassengerTypeVisible ? 1 : 0 };
                case UberType.UBER_MOTO:
                    return new UberMoto();
                case UberType.UBER_FLASH:
                    return new UberFlashMoto { Weight = Weight };
                case UberType.UBER_FLASH_MOTO:
                    return new UberFlash { Dimension = Height * Width * Length };
                default:
                    throw new ArgumentException("Invalid UberType", nameof(type));
            }
        }

        private async Task ShowAlertDialog(string message)
        {
            var dialog = new ContentDialog
            {
                Title = "Warning!",
                Content = message,
                CloseButtonText = "OK"
            };

            await dialog.ShowAsync();
        }

    }
}
