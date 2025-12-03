using AMS2ChEd.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public class GameSave
    {
        public int CurrentSeason { get; set; }
        public PlayerDriverInfo PlayerDriverInfo { get; set; } = new PlayerDriverInfo();

    }

    public class PlayerDriverInfo 
    {
        public string Name { get; set; }
        public string Nationality { get; set; }

        public int Age { get; set; }
        public DriverReputation Reputation { get; set; }
    }

    public class GameSaveService
    {
        private static GameSave _instance;
        public static GameSave MemorySave { 
            get { 
                if( _instance == null )
                {
                    _instance = new GameSave();
                }
                return _instance;
            } 
        }

        public static void SaveToDisk()
        {
            var path = Path.Combine(OptionsService.Settings.SaveFolder, "currentsave.json");
            string json = JsonSerializer.Serialize(MemorySave, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

    }
}
