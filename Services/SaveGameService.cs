using System;
using System.IO;
using System.Text.Json;
using AMS2ChEd.Models;

namespace AMS2ChEd.Services
{
    public class SaveGameService
    {
        private const string SAVES_FOLDER = "Saves";

        public static string SaveGame(SaveGame saveGame, string saveName)
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string savesPath = Path.Combine(appPath, SAVES_FOLDER);

                // Create saves directory if it doesn't exist
                if (!Directory.Exists(savesPath))
                {
                    Directory.CreateDirectory(savesPath);
                }

                // Generate filename
                string fileName = $"{saveName}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string fullPath = Path.Combine(savesPath, fileName);

                // Serialize with indentation for readability
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };

                string json = JsonSerializer.Serialize(saveGame, options);
                File.WriteAllText(fullPath, json);

                return fullPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving game: {ex.Message}", ex);
            }
        }

        public static SaveGame LoadGame(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Save file not found: {filePath}");
                }

                string json = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var saveGame = JsonSerializer.Deserialize<SaveGame>(json, options);
                return saveGame;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading game: {ex.Message}", ex);
            }
        }

        public static string[] GetSaveFiles()
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string savesPath = Path.Combine(appPath, SAVES_FOLDER);

                if (!Directory.Exists(savesPath))
                {
                    return Array.Empty<string>();
                }

                return Directory.GetFiles(savesPath, "*.json");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting save files: {ex.Message}", ex);
            }
        }

        public static void DeleteSave(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting save file: {ex.Message}", ex);
            }
        }
    }
}