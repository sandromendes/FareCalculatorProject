using FareCalculator.Core.Models;
using System;
using System.Windows.Input;
using Prism.Commands;
using FareCalculator.Core.Enums;
using FareCalculator.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Prism.Windows.Mvvm;

namespace FareCalculator.App.ViewModels
{
    public class FareCalculatorPageViewModel : ViewModelBase
    {
        private readonly IFareCalculatorService _fareCalculatorService;
        private readonly IDistanceCalculatorService _distanceCalculatorService;
        public ICommand CalculateFareCommand { get; }

        public FareCalculatorPageViewModel(IFareCalculatorService fareCalculatorService, IDistanceCalculatorService distanceCalculatorService)
        {
            _fareCalculatorService = fareCalculatorService;
            _distanceCalculatorService = distanceCalculatorService;

            LoadUberTypes();

            CalculateFareCommand = new DelegateCommand(ExecuteCalculateFare);
        }

        public void LoadUberTypes()
        {
            UberTypes = Enum.GetNames(typeof(UberType)).ToList();
        }

        public List<string> UberTypes { get; set; }

        private string _selectedUberType;
        public string SelectedUberOption
        {
            get => _selectedUberType;
            set
            {
                SetProperty(ref _selectedUberType, value);
                OnPropertyChanged(nameof(IsDeliveryTypeVisible));
                OnPropertyChanged(nameof(IsPassengerTypeVisible));
            }
        }

        private string _origin;
        public string Origin
        {
            get => _origin;
            set => SetProperty(ref _origin, value);
        }

        private string _destination;
        public string Destination
        {
            get => _destination;
            set => SetProperty(ref _destination, value);
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
                    return selectedType == UberType.Flash || selectedType == UberType.FlashMoto;
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
                    return selectedType == UberType.UberX || selectedType == UberType.UberVIP ||
                           selectedType == UberType.UberBlack || selectedType == UberType.UberMoto;
                }
                return false;
            }
        }

        private async void ExecuteCalculateFare()
        {
            try
            {
                Distance = await _distanceCalculatorService.CalculateDistanceAsync(Origin, Destination);

                Enum.TryParse(SelectedUberOption, out UberType selectedType);

                var fare = _fareCalculatorService.CalculateFare(new Vehicle
                {
                    Type = selectedType,
                    Passengers = IsPassengerTypeVisible ? 1 : 0 
                }, Distance, Weight, Height * Width * Length); 

                FareResult = $"Calculated Fare: {fare:C}";
                DistanceResult = $"Calculated Distance: {Distance} km";
            }
            catch (Exception ex)
            {
                FareResult = $"Error calculating fare: {ex.Message}";
            }
        }
    }
}
