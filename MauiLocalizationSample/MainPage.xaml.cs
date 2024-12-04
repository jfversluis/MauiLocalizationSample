using MauiLocalizationSample.Resources.Languages;
using System.Globalization;

namespace MauiLocalizationSample;

public partial class MainPage : ContentPage
{
	public int count { get; set; } = 0;

    public LocalizationResourceManager LocalizationResourceManager
        => LocalizationResourceManager.Instance;

    public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        var switchToCulture = LocalizationResourceManager.Instance.Culture.TwoLetterISOLanguageName
            .Equals("nl", StringComparison.InvariantCultureIgnoreCase) ?
            new CultureInfo("en-US") : new CultureInfo("nl-NL");

        LocalizationResourceManager.Instance.SetCulture(switchToCulture);

        count++;
        OnPropertyChanged(nameof(count));

		CounterBtn.Text = String.Format(LocalizationResourceManager["Counter"].ToString(), count);

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

