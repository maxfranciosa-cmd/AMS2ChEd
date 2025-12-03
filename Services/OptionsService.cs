using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public class AppSettings
    {
        public string Ams2Folder { get; set; }
        public string SaveFolder { get; set; }
    }

    public class OptionsService
    {
        private static string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        private static AppSettings _appSettings = null;
        public static AppSettings Settings
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = LoadSettings();
                }
                return _appSettings;
            }
        }

        private static AppSettings LoadSettings()
        {
            if (!File.Exists(_path))
            {
                return new AppSettings() { 
                    Ams2Folder = "C:\\SteamLibrary\\steamapps\\common\\Automobilista 2", 
                    SaveFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves") 
                };
            }

            using (StreamReader sr = new StreamReader(_path))
            {
                AppSettings currentSettings = JsonSerializer.Deserialize<AppSettings>(_path);
                return currentSettings;
            }
        }

        public static void SaveSettings(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

    }
}
