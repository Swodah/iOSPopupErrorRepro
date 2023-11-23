namespace iOSPopupErrorRepro;

public partial class Childpage : ContentPage
{
	public Childpage()
	{
		InitializeComponent();
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
        while (true)
        {
            var result = true;

            if (result == true)
            {
                await PopUpUtil.ShowCheckOutSuccess(this);
                await Navigation.PopToRootAsync(true);
            }
            break;
        }
    }
}