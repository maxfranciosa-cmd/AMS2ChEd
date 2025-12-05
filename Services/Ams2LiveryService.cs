using AMS2ChEd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace AMS2LiveryService
{
    /// <summary>
    /// Service for generating AMS2 livery XML files, custom AI files, and helmet/visor DDS textures
    /// </summary>
    public class LiveryService
    {
        private readonly DriverRatingsDatabase driversData;
        private readonly Season seasonData;
        private readonly Dictionary<string, DriverData> driversDict;
        private readonly Func<string, string, string, string> ddsComposer;

        /// <summary>
        /// Initialize the LiveryService
        /// </summary>
        /// <param name="driversJsonPath">Path to drivers.json</param>
        /// <param name="seasonJsonPath">Path to season.json</param>
        /// <param name="ddsComposerFunction">Function to compose DDS files: (baseHelmetPath, sponsorPath, outputPath) => outputPath</param>
        public LiveryService(
            string driversJsonPath,
            string seasonJsonPath,
            Func<string, string, string, string> ddsComposerFunction)
        {
            // Load JSON data
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            driversData = JsonSerializer.Deserialize<DriverRatingsDatabase>(File.ReadAllText(driversJsonPath), jsonOptions);
            seasonData = JsonSerializer.Deserialize<Season>(File.ReadAllText(seasonJsonPath), jsonOptions);

            // Create driver lookup dictionary
            driversDict = driversData.Drivers.ToDictionary(d => d.DriverId, d => d);

            // Store DDS composer function
            ddsComposer = ddsComposerFunction;
        }

        /// <summary>
        /// Generate all outputs for a specific race using AMS2 folder structure
        /// </summary>
        /// <param name="raceId">The race ID</param>
        /// <param name="raceEntryList">List of entries with team and driver assignments</param>
        /// <param name="driversDirectory">Drivers directory containing base_helmet_liveries/ and drivers.json</param>
        /// <param name="seasonDirectory">Season directory (e.g., Seasons/1996) containing static_assets/, car_liveries/, helmet_sponsors/</param>
        /// <param name="ams2RootDirectory">Root AMS2 directory (contains UserData and Vehicles folders) - all outputs go here</param>
        /// <param name="playerData">Optional player data (if a driver is the player)</param>
        public void GenerateRaceFiles(
            int raceId,
            List<EntryListEntry> raceEntryList,
            string driversDirectory,
            string seasonDirectory,
            string ams2RootDirectory,
            PlayerData playerData = null)
        {
            // Resolve base helmet liveries directory
            string baseHelmetLiveriesDirectory = Path.Combine(driversDirectory, "base_helmet_liveries");

            // Step 1: Copy static assets AS-IS from season/static_assets to AMS2
            CopyStaticAssets(seasonDirectory, ams2RootDirectory);

            // Build paths based on AMS2 structure
            string customAiPath = Path.Combine(ams2RootDirectory, "UserData", "CustomAIDrivers", $"{seasonData.Ams2Class}.xml");
            string vehiclesOverridesPath = Path.Combine(ams2RootDirectory, "Vehicles", "Textures", "CustomLiveries", "Overrides");

            // Ensure directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(customAiPath));

            // Step 2 & 3: Generate livery XMLs, copy car liveries, and generate helmets
            GenerateLiveryXmlsAMS2(raceId, raceEntryList, vehiclesOverridesPath, baseHelmetLiveriesDirectory, seasonDirectory, playerData);

            // Step 4: Generate custom AI XML
            GenerateCustomAiXml(raceId, raceEntryList, customAiPath, playerData);
        }

        /// <summary>
        /// Copy static assets from season/static_assets to AMS2 root directory
        /// </summary>
        private void CopyStaticAssets(string seasonDirectory, string ams2RootDirectory)
        {
            string staticAssetsPath = Path.Combine(seasonDirectory, "static_assets");

            if (!Directory.Exists(staticAssetsPath))
            {
                Console.WriteLine($"Warning: static_assets directory not found: {staticAssetsPath}");
                return;
            }

            Console.WriteLine($"Copying static assets from: {staticAssetsPath}");
            Console.WriteLine($"                       to: {ams2RootDirectory}");

            CopyDirectory(staticAssetsPath, ams2RootDirectory);

            Console.WriteLine("Static assets copied successfully");
        }

        /// <summary>
        /// Recursively copy directory contents
        /// </summary>
        private void CopyDirectory(string sourceDir, string destDir)
        {
            // Create destination directory if it doesn't exist
            Directory.CreateDirectory(destDir);

            // Copy all files
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destDir, fileName);
                File.Copy(file, destFile, overwrite: true);
                Console.WriteLine($"  Copied: {fileName}");
            }

            // Recursively copy subdirectories
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destDir, dirName);
                CopyDirectory(subDir, destSubDir);
            }
        }

        private void ProcessDriverHelmetVisor(
            string driverId,
            TeamEntry team,
            string helmetSponsors,
            string visorSponsors,
            string outputDirectory,
            string baseHelmetLiveriesDirectory,
            string seasonDirectory,
            PlayerData playerData)
        {
            // Check if this driver is the player (compare driverId with playerData.DriverId)
            bool isPlayer = playerData != null && driverId == playerData.DriverId;

            string baseHelmetFile;
            string baseVisorFile;

            if (isPlayer)
            {
                // Use player's helmet and visor (resolve relative to baseHelmetLiveriesDirectory)
                baseHelmetFile = Path.IsPathRooted(playerData.BaseHelmetFile)
                    ? playerData.BaseHelmetFile
                    : Path.Combine(baseHelmetLiveriesDirectory, playerData.BaseHelmetFile);
                baseVisorFile = Path.IsPathRooted(playerData.BaseVisorFile)
                    ? playerData.BaseVisorFile
                    : Path.Combine(baseHelmetLiveriesDirectory, playerData.BaseVisorFile);
            }
            else
            {
                // Use AI driver's helmet and visor (resolve relative to baseHelmetLiveriesDirectory)
                if (!driversDict.TryGetValue(driverId, out var driver)) return;
                baseHelmetFile = Path.IsPathRooted(driver.BaseHelmetFile)
                    ? driver.BaseHelmetFile
                    : Path.Combine(baseHelmetLiveriesDirectory, driver.BaseHelmetFile);
                baseVisorFile = Path.IsPathRooted(driver.BaseVisorFile)
                    ? driver.BaseVisorFile
                    : Path.Combine(baseHelmetLiveriesDirectory, driver.BaseVisorFile);
            }

            // Resolve sponsor paths relative to seasonDirectory
            string resolvedHelmetSponsors = string.IsNullOrEmpty(helmetSponsors)
                ? null
                : (Path.IsPathRooted(helmetSponsors)
                    ? helmetSponsors
                    : Path.Combine(seasonDirectory, helmetSponsors));

            string resolvedVisorSponsors = string.IsNullOrEmpty(visorSponsors)
                ? null
                : (Path.IsPathRooted(visorSponsors)
                    ? visorSponsors
                    : Path.Combine(seasonDirectory, visorSponsors));

            // Generate helmet with sponsors if sponsor overlay exists
            if (!string.IsNullOrEmpty(resolvedHelmetSponsors))
            {
                string outputHelmetPath = Path.Combine(outputDirectory, Path.GetFileName(baseHelmetFile));
                ddsComposer(baseHelmetFile, resolvedHelmetSponsors, outputHelmetPath);
            }
            else if (!string.IsNullOrEmpty(baseHelmetFile))
            {
                // Just copy the base helmet if no sponsors
                string outputHelmetPath = Path.Combine(outputDirectory, Path.GetFileName(baseHelmetFile));
                if (File.Exists(baseHelmetFile))
                {
                    File.Copy(baseHelmetFile, outputHelmetPath, overwrite: true);
                }
                else
                {
                    Console.WriteLine($"Warning: Base helmet file not found: {baseHelmetFile}");
                }
            }

            // Generate visor with sponsors if sponsor overlay exists
            if (!string.IsNullOrEmpty(resolvedVisorSponsors))
            {
                string outputVisorPath = Path.Combine(outputDirectory, Path.GetFileName(baseVisorFile));
                ddsComposer(baseVisorFile, resolvedVisorSponsors, outputVisorPath);
            }
            else if (!string.IsNullOrEmpty(baseVisorFile))
            {
                // Just copy the base visor if no sponsors
                string outputVisorPath = Path.Combine(outputDirectory, Path.GetFileName(baseVisorFile));
                if (File.Exists(baseVisorFile))
                {
                    File.Copy(baseVisorFile, outputVisorPath, overwrite: true);
                }
                else
                {
                    Console.WriteLine($"Warning: Base visor file not found: {baseVisorFile}");
                }
            }
        }

        /// <summary>
        /// Copy a car livery file from season/car_liveries to the car model directory
        /// </summary>
        private void CopyCarLivery(string liveryPath, string seasonDirectory, string carModelDirectory)
        {
            // Resolve the source path (relative to seasonDirectory)
            string sourcePath = Path.IsPathRooted(liveryPath)
                ? liveryPath
                : Path.Combine(seasonDirectory, liveryPath);

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Warning: Car livery file not found: {sourcePath}");
                return;
            }

            // Destination is just the filename in the car model directory
            string fileName = Path.GetFileName(sourcePath);
            string destPath = Path.Combine(carModelDirectory, fileName);

            File.Copy(sourcePath, destPath, overwrite: true);
            Console.WriteLine($"  Copied car livery: {fileName}");
        }

        /// <summary>
        /// Generate livery XML files using AMS2 folder structure
        /// </summary>
        private void GenerateLiveryXmlsAMS2(
            int raceId,
            List<EntryListEntry> raceEntryList,
            string vehiclesOverridesPath,
            string baseHelmetLiveriesDirectory,
            string seasonDirectory,
            PlayerData playerData)
        {
            // Group entries by car model
            var entriesByCarModel = new Dictionary<string, List<(EntryListEntry entry, TeamEntry team)>>();

            foreach (var entry in raceEntryList)
            {
                var team = seasonData.Teams.FirstOrDefault(t => t.TeamId == entry.TeamId);
                if (team == null) continue;

                if (!entriesByCarModel.ContainsKey(team.Ams2Car))
                {
                    entriesByCarModel[team.Ams2Car] = new List<(EntryListEntry, TeamEntry)>();
                }
                entriesByCarModel[team.Ams2Car].Add((entry, team));
            }

            // Process each car model
            foreach (var carModelGroup in entriesByCarModel)
            {
                string carModel = carModelGroup.Key;
                var entries = carModelGroup.Value;

                // Build paths for this car model
                string carModelDirectory = Path.Combine(vehiclesOverridesPath, carModel);
                string baseXmlPath = Path.Combine(carModelDirectory, $"{carModel}.xml");
                string outputXmlPath = Path.Combine(carModelDirectory, $"{carModel}.xml");  // Same file - modified in place
                string temporaryTexturesPath = Path.Combine(carModelDirectory, "temporary_textures");

                // Delete temporary_textures folder if it exists
                if (Directory.Exists(temporaryTexturesPath))
                {
                    Directory.Delete(temporaryTexturesPath, recursive: true);
                    Console.WriteLine($"Deleted existing temporary_textures: {temporaryTexturesPath}");
                }

                // Create temporary_textures folder
                Directory.CreateDirectory(temporaryTexturesPath);

                // Check if XML exists (copied from static_assets)
                if (!File.Exists(baseXmlPath))
                {
                    Console.WriteLine($"Warning: XML not found (should have been copied from static_assets): {baseXmlPath}");
                    continue;
                }

                // Load XML (this was copied from static_assets in Step 1)
                XDocument doc = XDocument.Load(baseXmlPath);
                XElement root = doc.Root;

                if (root == null)
                {
                    Console.WriteLine($"Warning: Invalid XML structure in {baseXmlPath}");
                    continue;
                }

                // Generate helmet/visor DDS files for this car model
                GenerateHelmetVisorDDSForCarModel(raceId, entries, temporaryTexturesPath, baseHelmetLiveriesDirectory, seasonDirectory, playerData);

                // Copy car liveries and update XML for each team using this car model
                foreach (var (entry, team) in entries)
                {
                    // Get race-specific overrides
                    var raceOverride = team.LiveryOverrides?.FirstOrDefault(o => o.RaceId == raceId);

                    // Get car livery files
                    string driver1Livery = raceOverride?.Driver1Livery ?? team.BaseLiveryDriver1;
                    string driver2Livery = raceOverride?.Driver2Livery ?? team.BaseLiveryDriver2;

                    // Copy driver 1 livery from season/car_liveries to AMS2 car model folder
                    if (!string.IsNullOrEmpty(driver1Livery))
                    {
                        CopyCarLivery(driver1Livery, seasonDirectory, carModelDirectory);
                    }

                    // Copy driver 2 livery from season/car_liveries to AMS2 car model folder
                    if (!string.IsNullOrEmpty(driver2Livery))
                    {
                        CopyCarLivery(driver2Livery, seasonDirectory, carModelDirectory);
                    }

                    // Update driver 1
                    UpdateDriverLiveryAMS2(
                        root,
                        team.Driver1LiveryNumber,
                        entry.Driver1Id,
                        team.TeamName,
                        driver1Livery,
                        playerData);

                    // Update driver 2
                    UpdateDriverLiveryAMS2(
                        root,
                        team.Driver2LiveryNumber,
                        entry.Driver2Id,
                        team.TeamName,
                        driver2Livery,
                        playerData);
                }

                // Save modified XML
                doc.Save(outputXmlPath);
                Console.WriteLine($"Updated livery XML: {outputXmlPath}");
            }
        }

        /// <summary>
        /// Generate helmet and visor DDS files for entries using a specific car model
        /// </summary>
        private void GenerateHelmetVisorDDSForCarModel(
            int raceId,
            List<(EntryListEntry entry, TeamEntry team)> entries,
            string outputDirectory,
            string baseHelmetLiveriesDirectory,
            string seasonDirectory,
            PlayerData playerData)
        {
            foreach (var (entry, team) in entries)
            {
                // Get race-specific overrides
                var raceOverride = team.LiveryOverrides?.FirstOrDefault(o => o.RaceId == raceId);

                // Process driver 1
                ProcessDriverHelmetVisor(
                    entry.Driver1Id,
                    team,
                    raceOverride?.HelmetSponsors ?? team.HelmetSponsors,
                    raceOverride?.VisorSponsors ?? team.VisorSponsors,
                    outputDirectory,
                    baseHelmetLiveriesDirectory,
                    seasonDirectory,
                    playerData);

                // Process driver 2
                ProcessDriverHelmetVisor(
                    entry.Driver2Id,
                    team,
                    raceOverride?.HelmetSponsors ?? team.HelmetSponsors,
                    raceOverride?.VisorSponsors ?? team.VisorSponsors,
                    outputDirectory,
                    baseHelmetLiveriesDirectory,
                    seasonDirectory,
                    playerData);
            }
        }

        /// <summary>
        /// Update driver livery in XML with relative paths for AMS2 structure
        /// </summary>
        private void UpdateDriverLiveryAMS2(
            XElement root,
            string liveryNumber,
            string driverId,
            string teamName,
            string liveryFilePath,
            PlayerData playerData)
        {
            // Check if this driver is the player (compare driverId with playerData.DriverId)
            bool isPlayer = playerData != null && driverId == playerData.DriverId;

            string driverName;
            string baseHelmetFile;
            string baseVisorFile;

            if (isPlayer)
            {
                // Use player data
                driverName = playerData.Name;
                baseHelmetFile = playerData.BaseHelmetFile;
                baseVisorFile = playerData.BaseVisorFile;
            }
            else
            {
                // Use AI driver data
                if (!driversDict.TryGetValue(driverId, out var driver)) return;
                driverName = driver.Name;
                baseHelmetFile = driver.BaseHelmetFile;
                baseVisorFile = driver.BaseVisorFile;
            }

            // Find LIVERY_OVERRIDE element with matching LIVERY attribute
            var liveryOverride = root.Elements("LIVERY_OVERRIDE")
                .FirstOrDefault(e => e.Attribute("LIVERY")?.Value == liveryNumber.ToString());

            if (liveryOverride != null)
            {
                // Update NAME attribute to show driver and team
                liveryOverride.SetAttributeValue("NAME", $"{driverName} - {teamName}");

                // Update BODY texture PATH
                var bodyTexture = liveryOverride.Elements("TEXTURE")
                    .FirstOrDefault(t => t.Attribute("NAME")?.Value == "BODY");

                if (bodyTexture != null && !string.IsNullOrEmpty(liveryFilePath))
                {
                    // Use just the filename since the file is already copied to this directory
                    string liveryFilename = Path.GetFileName(liveryFilePath);
                    bodyTexture.SetAttributeValue("PATH", liveryFilename);
                }
            }

            // Find HELMET_OVERRIDE element with matching LIVERY attribute
            var helmetOverride = root.Elements("HELMET_OVERRIDE")
                .FirstOrDefault(e => e.Attribute("LIVERY")?.Value == liveryNumber.ToString());

            if (helmetOverride != null)
            {
                // Update helmet BODY_DIFF texture with RELATIVE path
                var helmetTexture = helmetOverride.Elements("TEXTURE")
                    .FirstOrDefault(t => t.Attribute("NAME")?.Value == "BODY_DIFF");

                if (helmetTexture != null)
                {
                    string helmetFilename = Path.GetFileName(baseHelmetFile);
                    string relativePath = Path.Combine("temporary_textures", helmetFilename);
                    helmetTexture.SetAttributeValue("PATH", relativePath);
                }

                // Update visor VISOR_DIFF texture with RELATIVE path
                var visorTexture = helmetOverride.Elements("TEXTURE")
                    .FirstOrDefault(t => t.Attribute("NAME")?.Value == "VISOR_DIFF");

                if (visorTexture != null)
                {
                    string visorFilename = Path.GetFileName(baseVisorFile);
                    string relativePath = Path.Combine("temporary_textures", visorFilename);
                    visorTexture.SetAttributeValue("PATH", relativePath);
                }
            }
        }

        /// <summary>
        /// Generate the custom AI XML file
        /// </summary>
        private void GenerateCustomAiXml(
            int raceId,
            List<EntryListEntry> raceEntryList,
            string outputCustomAiXmlPath,
            PlayerData playerData)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));
            XElement root = new XElement("custom_ai_drivers");

            foreach (var entry in raceEntryList)
            {
                var team = seasonData.Teams.FirstOrDefault(t => t.TeamId == entry.TeamId);
                if (team == null) continue;

                // Add driver 1
                AddDriverAiEntry(root, entry.Driver1Id, team, playerData);

                // Add driver 2
                AddDriverAiEntry(root, entry.Driver2Id, team, playerData);
            }

            doc.Add(root);
            doc.Save(outputCustomAiXmlPath);
        }

        private void AddDriverAiEntry(XElement root, string driverId, TeamEntry team, PlayerData playerData)
        {
            // Check if this driver is the player (compare driverId with playerData.DriverId)
            bool isPlayer = playerData != null && driverId == playerData.DriverId;

            string driverName;
            string nationality;
            Dictionary<string, double> ratings;

            if (isPlayer)
            {
                // Use player data with fixed ratings (player controls the car, AI ratings don't matter)
                driverName = playerData.Name;
                nationality = playerData.Nationality;

                // Fixed ratings for player (these won't be used in gameplay)
                ratings = new Dictionary<string, double>
                {
                    { "aggression", 0.5 },
                    { "avoidance_of_forced_mistakes", 0.5 },
                    { "avoidance_of_mistakes", 0.5 },
                    { "blue_flag_conceding", 0.5 },
                    { "consistency", 0.5 },
                    { "defending", 0.5 },
                    { "fuel_management", 0.5 },
                    { "qualifying_skill", 0.5 },
                    { "race_skill", 0.5 },
                    { "stamina", 0.5 },
                    { "start_reactions", 0.5 },
                    { "tyre_management", 0.5 },
                    { "weather_tyre_changes", 0.5 },
                    { "wet_skill", 0.5 }
                };
            }
            else
            {
                // Use AI driver data with team performance malus
                if (!driversDict.TryGetValue(driverId, out var driver)) return;

                driverName = driver.Name;
                nationality = driver.Nationality;

                // Get driver ratings for the season
                var seasonStr = seasonData.Year.ToString();
                var driverRating = driver.Ratings.FirstOrDefault(r => r.Season == seasonStr);

                if (driverRating == null)
                {
                    // Try to find the closest season
                    driverRating = driver.Ratings.OrderByDescending(r => r.Season).FirstOrDefault();
                }

                if (driverRating == null) return;

                // Apply team performance malus to ratings
                ratings = new Dictionary<string, double>();
                foreach (var ratingKvp in driverRating.Values)
                {
                    string ratingName = ratingKvp.Key;
                    double baseValue = ratingKvp.Value;

                    // Apply team performance malus if exists
                    double malus = 0;
                    if (team.Ams2CarPerformanceMalus != null &&
                        team.Ams2CarPerformanceMalus.ContainsKey(ratingName))
                    {
                        malus = team.Ams2CarPerformanceMalus[ratingName];
                    }

                    double adjustedValue = Math.Max(0.0, Math.Min(1.0, baseValue - malus));
                    ratings[ratingName] = adjustedValue;
                }
            }

            // Create driver element
            string liveryName = $"{driverName} - {team.TeamName}";
            XElement driverElement = new XElement("driver",
                new XAttribute("livery_name", liveryName)
            );

            // Add ratings
            foreach (var ratingKvp in ratings.OrderBy(kvp => kvp.Key))
            {
                driverElement.Add(new XElement(ratingKvp.Key, ratingKvp.Value.ToString("0.##")));
            }

            // Add driver name
            driverElement.Add(new XElement("name", driverName));

            // Add country
            driverElement.Add(new XElement("country", nationality));

            root.Add(driverElement);
        }
    }
}