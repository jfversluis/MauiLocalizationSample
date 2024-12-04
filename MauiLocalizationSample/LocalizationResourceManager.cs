using MauiLocalizationSample.Resources.Languages;
using System.ComponentModel;
using System.Globalization;

namespace MauiLocalizationSample {
    public class LocalizationResourceManager : INotifyPropertyChanged {
        private LocalizationResourceManager() {
            Culture = CultureInfo.CurrentCulture;
        }

        public event EventHandler CultureChanged;

        public CultureInfo Culture
        {
            get => CultureInfo.CurrentUICulture;
            set
            {
                CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Culture)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
                CultureChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public static LocalizationResourceManager Instance { get; } = new();

        public object this[string resourceKey]
            => AppResources.ResourceManager.GetObject(resourceKey, Culture) ?? Array.Empty<byte>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
