namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	string translatedNumber;

	private void OnTranslate(object sender, EventArgs args)
	{ 
		string enterNUmber=PhoneNumberText.Text;

		translatedNumber = MauiApp1.PhoneNumberDialer.ToNumber(enterNUmber);

		if (!string.IsNullOrEmpty(translatedNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = $"Call {translatedNumber} ";
		}
		else
		{
			CallButton.IsEnabled=false;
			CallButton.Text = "Call";
		}
	}

	async void OnCall(object sender, EventArgs args)
	{
		if (await this.DisplayAlert("Dial a number", "Would you like to call" + translatedNumber + "?","Yes", "No" ))
		{
			try
			{
				if (PhoneDialer.Default.IsSupported)
				{
					PhoneDialer.Default.Open(translatedNumber);
				}
			}
			catch (ArgumentNullException)
			{
				await DisplayAlert("Unable to dial", "Phone number was not valid", "Ok");
			}
			catch(Exception) { await DisplayAlert("Unable to dial", "Phone dialing failed", "Ok"); }
		}
	}

	//private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	count++;

	//	if (count == 1)
	//		CounterBtn.Text = $"Clicked {count} time";
	//	else
	//		CounterBtn.Text = $"Clicked {count} times";

	//	SemanticScreenReader.Announce(CounterBtn.Text);
	//}
}

