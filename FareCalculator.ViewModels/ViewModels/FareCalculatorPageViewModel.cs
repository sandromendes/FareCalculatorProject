using FareCalculator.Core.Common;
using FareCalculator.Core.Enums;
using FareCalculator.Core.Models;
using FareCalculator.Core.Services.Interfaces;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace FareCalculator.ViewModels.ViewModels
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

            SelectedUberOption = UberType.UBER_X.GetDescription();
            SelectedOrigin = CityTypes.RECIFE.GetDescription();
            SelectedDestination = CityTypes.OLINDA.GetDescription();

            CalculateFareCommand = new DelegateCommand(ExecuteCalculateFare);
            ClearCommand = new DelegateCommand(ExecuteClear);
        }

        public void LoadUberOptions()
        {
            UberOptions = Enum.GetValues(typeof(UberType))
                              .Cast<UberType>()
                              .Select(uberType => uberType.GetDescription())
                              .ToList();
        }

        public void LoadCityOptions()
        {
            CityOptions = Enum.GetValues(typeof(CityTypes))
                              .Cast<CityTypes>()
                              .Select(uberType => uberType.GetDescription())
                              .ToList();
        }

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
            set => SetProperty(ref _fareResult, value);
        }

        private string _distanceResult;
        public string DistanceResult
        {
            get => _distanceResult;
            set => SetProperty(ref _distanceResult, value);
        }

        public bool IsDeliveryTypeVisible
        {
            get
            {
                var selectedType = EnumExtensions.GetValueFromDescription<UberType>(SelectedUberOption);

                return selectedType == UberType.UBER_FLASH || selectedType == UberType.UBER_FLASH_MOTO;
            }
        }

        public bool IsPassengerTypeVisible
        {
            get
            {
                var selectedType = EnumExtensions.GetValueFromDescription<UberType>(SelectedUberOption);

                return selectedType == UberType.UBER_X || selectedType == UberType.UBER_VIP ||
                       selectedType == UberType.UBER_BLACK || selectedType == UberType.UBER_MOTO;
            }
        }

        public async void ExecuteCalculateFare()
        {
            try
            {
                if (IsDeliveryTypeVisible && (Weight <= 0 || Height <= 0 || Width <= 0 || Length <= 0))
                {
                    await ShowAlertDialog("There's at least one measure field with zero or empty.");
                    return;
                }

                var selectedOrigin = EnumExtensions.GetValueFromDescription<CityTypes>(SelectedOrigin);
                var selectedDestination = EnumExtensions.GetValueFromDescription<CityTypes>(SelectedDestination);

                Distance = await _distanceCalculatorService.CalculateDistanceAsync(selectedOrigin, selectedDestination);

                var selectedType = EnumExtensions.GetValueFromDescription<UberType>(SelectedUberOption);

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
            SelectedUberOption = UberType.UBER_X.GetDescription();
            SelectedOrigin = CityTypes.RECIFE.GetDescription();
            SelectedDestination = CityTypes.OLINDA.GetDescription();
            Weight = 0;
            Height = 0;
            Width = 0;
            Length = 0;
            FareResult = string.Empty;
            DistanceResult = string.Empty;
        }

        private UberRideBase CreateVehicle(UberType type)
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
                    return new UberFlash { Dimension = Height * Width * Length };
                case UberType.UBER_FLASH_MOTO:
                    return new UberFlashMoto { Weight = Weight };
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
