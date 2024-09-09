using FareCalculator.App.ViewModels;
using System.Linq;
using Windows.UI.Xaml.Controls;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace FareCalculator.App.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class FareCalculatorPage : Page
    {
        public FareCalculatorPageViewModel ViewModel => (FareCalculatorPageViewModel)DataContext;

        public FareCalculatorPage()
        {
            InitializeComponent();
        }

        private void TextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c) && c != '.' && c != ',');
        }
    }
}
