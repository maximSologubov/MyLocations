using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MyLocationsNote.Services.Settings
{
    class SettingsManager
    {
        public bool DarkTheme
        {
            get => Preferences.Get(nameof(DarkTheme), false);
            set => Preferences.Set(nameof(DarkTheme), value);
        }
    }
}
