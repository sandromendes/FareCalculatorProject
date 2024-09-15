using FareCalculator.App.Views;
using FareCalculator.Core.Services;
using FareCalculator.Core.Services.Interfaces;
using FareCalculator.ViewModels.ViewModels;
using Prism.Mvvm;
using Prism.Unity.Windows;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace FareCalculator.App
{
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();

        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register(typeof(FareCalculatorPage).ToString(), 
                typeof(FareCalculatorPageViewModel));
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("FareCalculator", null);

            return Task.CompletedTask;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(IFareCalculatorService), typeof(FareCalculatorService), false);
            RegisterTypeIfMissing(typeof(IDistanceCalculatorService), typeof(DistanceCalculatorService), true);
        }
    }
}
