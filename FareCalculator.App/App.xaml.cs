using FareCalculator.Core.Services;
using FareCalculator.Core.Services.Interfaces;
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
