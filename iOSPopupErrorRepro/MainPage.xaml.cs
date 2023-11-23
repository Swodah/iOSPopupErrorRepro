namespace iOSPopupErrorRepro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GestureCheckout_OnTapped(object sender, TappedEventArgs e)
        {
            Routing.RegisterRoute(nameof(Childpage), typeof(Childpage));

            await Shell.Current.GoToAsync(nameof(Childpage));
        }
    }

}
