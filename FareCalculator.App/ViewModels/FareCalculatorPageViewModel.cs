﻿using FareCalculator.Core.Models;
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

            LoadUberOptions();
            LoadCityOptions();

            CalculateFareCommand = new DelegateCommand(ExecuteCalculateFare);
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
                OnPropertyChanged(nameof(IsDeliveryTypeVisible));
                OnPropertyChanged(nameof(IsPassengerTypeVisible));
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

        private Vehicle CreateVehicle(UberType type)
        {
            switch (type)
            {
                case UberType.UberX:
                    return new UberX { Passengers = IsPassengerTypeVisible ? 1 : 0 };
                case UberType.UberVIP:
                    return new UberVip { Passengers = IsPassengerTypeVisible ? 1 : 0 };
                case UberType.UberBlack:
                    return new UberBlack { Passengers = IsPassengerTypeVisible ? 1 : 0 };
                case UberType.UberMoto:
                    return new UberMoto();
                case UberType.Flash:
                    return new FlashMoto { Weight = Weight };
                case UberType.FlashMoto:
                    return new UberFlash { Dimension = Height * Width * Length };
                default:
                    throw new ArgumentException("Invalid UberType", nameof(type));
            }
        }
    }
}
