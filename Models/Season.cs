using System.Collections.Generic;
using System.Text.Json.Serialization;
using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;

namespace AMS2ChEd.Models
{
    public class Season
    {
        [JsonPropertyName("season")]
        public int Year { get; set; }

        [JsonPropertyName("pointsSystem")]
        public Dictionary<string, int> PointsSystem { get; set; }

        [JsonPropertyName("races")]
        public List<Race> Races { get; set; }

        [JsonPropertyName("teams")]
        public List<TeamEntry> Teams { get; set; }

        [JsonPropertyName("absences")]
        public List<Absence> Absences { get; set; }
    }

    public class Race
    {
        [JsonPropertyName("race_id")]
        public int RaceId { get; set; }

        [JsonPropertyName("race_name")]
        public string RaceName { get; set; }

        [JsonPropertyName("race_date")]
        public string RaceDate { get; set; }

        [JsonPropertyName("circuit")]
        public string Circuit { get; set; }
    }

    public class TeamEntry
    {
        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }

        [JsonPropertyName("team_principal")]
        public string TeamPrincipal { get; set; }

        [JsonPropertyName("reputation")]
        [JsonConverter(typeof(TeamReputationConverter))]
        public TeamReputation Reputation { get; set; }

        [JsonPropertyName("ams2car")]
        public string Ams2Car { get; set; }

        [JsonPropertyName("ams2carPerformanceMalus")]
        public PerformanceMalus Ams2CarPerformanceMalus { get; set; }

        [JsonPropertyName("driver1_contract")]
        public DriverContract Driver1Contract { get; set; }

        [JsonPropertyName("driver2_contract")]
        public DriverContract Driver2Contract { get; set; }

        [JsonPropertyName("base_livery_driver1")]
        public string BaseLiveryDriver1 { get; set; }

        [JsonPropertyName("base_livery_driver2")]
        public string BaseLiveryDriver2 { get; set; }

        [JsonPropertyName("helmet_sponsors")]
        public string HelmetSponsors { get; set; }

        [JsonPropertyName("visor_sponsors")]
        public string VisorSponsors { get; set; }

        [JsonPropertyName("livery_overrides")]
        public List<LiveryOverride> LiveryOverrides { get; set; }
    }

    public class PerformanceMalus
    {
        [JsonPropertyName("consistency")]
        public double Consistency { get; set; }

        [JsonPropertyName("defending")]
        public double Defending { get; set; }

        [JsonPropertyName("fuel_management")]
        public double FuelManagement { get; set; }

        [JsonPropertyName("qualifying_skill")]
        public double QualifyingSkill { get; set; }

        [JsonPropertyName("race_skill")]
        public double RaceSkill { get; set; }

        [JsonPropertyName("tyre_management")]
        public double TyreManagement { get; set; }
    }

    public class DriverContract
    {
        [JsonPropertyName("driver_id")]
        public string DriverId { get; set; }

        [JsonPropertyName("races")]
        public int Races { get; set; }

        [JsonPropertyName("replaceable")]
        public bool Replaceable { get; set; }

        [JsonPropertyName("drivernumber")]
        public int DriverNumber { get; set; }
    }

    public class LiveryOverride
    {
        [JsonPropertyName("race_id")]
        public int RaceId { get; set; }

        [JsonPropertyName("driver1_livery")]
        public string Driver1Livery { get; set; }

        [JsonPropertyName("driver2_livery")]
        public string Driver2Livery { get; set; }

        [JsonPropertyName("helmet_sponsors")]
        public string HelmetSponsors { get; set; }

        [JsonPropertyName("visor_sponsors")]
        public string VisorSponsors { get; set; }
    }

    public class Absence
    {
        [JsonPropertyName("race_id")]
        public int RaceId { get; set; }

        [JsonPropertyName("teamid")]
        public string TeamId { get; set; }

        [JsonPropertyName("driver_out")]
        public string DriverOut { get; set; }

        [JsonPropertyName("driver_in")]
        public string DriverIn { get; set; }

        [JsonPropertyName("newDriverNumber")]
        public int NewDriverNumber { get; set; }

        [JsonPropertyName("chainedAbsence")]
        public Absence ChainedAbsence { get; set; }
    }
}