using System.IO;
using System.Text.Json;
using AMS2ChEd.Models;

namespace AMS2ChEd.Services
{
    public class DriversLoader
    {
        private static Dictionary<string, DriverData> driversCache;

        public static Dictionary<string, DriverData> LoadDrivers()
        {
            if (driversCache != null)
                return driversCache;

            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string driversPath = Path.Combine(appPath, "Drivers", "drivers.json");

                if (!File.Exists(driversPath))
                {
                    throw new FileNotFoundException($"Drivers database not found at: {driversPath}");
                }

                string json = File.ReadAllText(driversPath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var driversDb = JsonSerializer.Deserialize<DriverRatingsDatabase>(json, options);

                driversCache = driversDb.Drivers.ToDictionary(d => d.DriverId, d => d);
                return driversCache;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading drivers database: {ex.Message}", ex);
            }
        }

        public static DriverData GetDriver(string driverId)
        {
            var drivers = LoadDrivers();
            return drivers.ContainsKey(driverId) ? drivers[driverId] : null;
        }

        public static void ClearCache()
        {
            driversCache = null;
        }
    }

    public class TeamsLoader
    {
        private static Dictionary<string, Team> teamsCache;

        public static Dictionary<string, Team> LoadTeams()
        {
            if (teamsCache != null)
                return teamsCache;

            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string teamsPath = Path.Combine(appPath, "Teams", "teams.json");

                if (!File.Exists(teamsPath))
                {
                    throw new FileNotFoundException($"Teams database not found at: {teamsPath}");
                }

                string json = File.ReadAllText(teamsPath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var teamsDb = JsonSerializer.Deserialize<TeamsDatabase>(json, options);

                teamsCache = teamsDb.Teams.ToDictionary(t => t.TeamId, t => t);
                return teamsCache;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading teams database: {ex.Message}", ex);
            }
        }

        public static Team GetTeam(string teamId)
        {
            var teams = LoadTeams();
            return teams.ContainsKey(teamId) ? teams[teamId] : null;
        }

        public static void ClearCache()
        {
            teamsCache = null;
        }
    }

    public class SeasonLoader
    {
        public static Season LoadSeason(string seasonYear)
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string seasonPath = Path.Combine(appPath, "Seasons", seasonYear, "season.json");

                if (!File.Exists(seasonPath))
                {
                    throw new FileNotFoundException($"Season file not found at: {seasonPath}");
                }

                string json = File.ReadAllText(seasonPath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var seasonData = JsonSerializer.Deserialize<Season>(json, options);

                return seasonData;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading season data: {ex.Message}", ex);
            }
        }

        public static List<string> GetAvailableSeasons()
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string seasonsPath = Path.Combine(appPath, "Seasons");

                if (!Directory.Exists(seasonsPath))
                {
                    return new List<string>();
                }

                return Directory.GetDirectories(seasonsPath)
                    .Select(d => new DirectoryInfo(d).Name)
                    .OrderBy(s => s)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting available seasons: {ex.Message}", ex);
            }
        }
    }
}