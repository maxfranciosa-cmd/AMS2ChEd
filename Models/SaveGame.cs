using System.Collections.Generic;
using System.Text.Json.Serialization;
using AMS2ChEd.Models.Enums;

namespace AMS2ChEd.Models
{
    public class SaveGame
    {
        [JsonPropertyName("currentSeason")]
        public Season CurrentSeason { get; set; }

        [JsonPropertyName("drivers")]
        public List<DriverData> Drivers { get; set; }

        [JsonPropertyName("nextGpIndex")]
        public int NextGpIndex { get; set; }

        [JsonPropertyName("nextGpEntryList")]
        public List<EntryListEntry> NextGpEntryList { get; set; }

        [JsonPropertyName("playerData")]
        public PlayerData PlayerData { get; set; }

        [JsonPropertyName("grandPrixResults")]
        public List<GrandPrixResult> GrandPrixResults { get; set; }

        [JsonPropertyName("currentDriverStandings")]
        public List<DriverStandingEntry> CurrentDriverStandings { get; set; }

        [JsonPropertyName("currentConstructorStandings")]
        public List<ConstructorStandingEntry> CurrentConstructorStandings { get; set; }

        [JsonPropertyName("historicalDriverStandings")]
        public List<HistoricalDriverStanding> HistoricalDriverStandings { get; set; }

        [JsonPropertyName("historicalConstructorStandings")]
        public List<HistoricalConstructorStanding> HistoricalConstructorStandings { get; set; }
    }

    // SeasonDriverData class removed - now using DriverData directly

    public class EntryListEntry
    {
        [JsonPropertyName("teamid")]
        public string TeamId { get; set; }

        [JsonPropertyName("driver1id")]
        public string Driver1Id { get; set; }

        [JsonPropertyName("driver1Reputation")]
        public DriverReputation Driver1Reputation { get; set; }

        [JsonPropertyName("driver1number")]
        public int Driver1Number { get; set; }

        [JsonPropertyName("driver2id")]
        public string Driver2Id { get; set; }

        [JsonPropertyName("driver2Reputation")]
        public DriverReputation Driver2Reputation { get; set; }

        [JsonPropertyName("driver2number")]
        public int Driver2Number { get; set; }
    }

    public class PlayerData
    {
        [JsonPropertyName("driverid")]
        public string DriverId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("teamid")]
        public string TeamId { get; set; }
    }

    public class GrandPrixResult
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("grandPrixName")]
        public string GrandPrixName { get; set; }

        [JsonPropertyName("qualifyingResults")]
        public List<SessionResult> QualifyingResults { get; set; }

        [JsonPropertyName("raceResults")]
        public List<SessionResult> RaceResults { get; set; }
    }

    public class SessionResult
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("driver_id")]
        public string DriverId { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }
    }

    public class DriverStandingEntry
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("driver_id")]
        public string DriverId { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("points")]
        public double Points { get; set; }
    }

    public class ConstructorStandingEntry
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("points")]
        public double Points { get; set; }
    }

    public class HistoricalDriverStanding
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("standing")]
        public List<DriverStandingEntry> Standing { get; set; }
    }

    public class HistoricalConstructorStanding
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("standing")]
        public List<ConstructorStandingEntry> Standing { get; set; }
    }
}