using System.Text.Json.Serialization;
using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;

namespace AMS2ChEd.Models
{
    public class DriverRatingsDatabase
    {
        [JsonPropertyName("drivers")]
        public List<DriverData> Drivers { get; set; }
    }

    public class DriverData
    {
        [JsonPropertyName("driver_id")]
        public string DriverId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }

        [JsonPropertyName("base_helmet_file")]
        public string BaseHelmetFile { get; set; }

        [JsonPropertyName("base_visor_file")]
        public string BaseVisorFile { get; set; }

        [JsonPropertyName("ratings")]
        public List<SeasonRating> Ratings { get; set; }
    }

    public class SeasonRating
    {
        [JsonPropertyName("season")]
        public string Season { get; set; }

        [JsonPropertyName("reputation")]
        [JsonConverter(typeof(DriverReputationConverter))]
        public DriverReputation Reputation { get; set; }

        [JsonPropertyName("values")]
        public RatingValues Values { get; set; }
    }

    public class RatingValues
    {
        [JsonPropertyName("aggression")]
        public double Aggression { get; set; }

        [JsonPropertyName("avoidance_of_forced_mistakes")]
        public double AvoidanceOfForcedMistakes { get; set; }

        [JsonPropertyName("avoidance_of_mistakes")]
        public double AvoidanceOfMistakes { get; set; }

        [JsonPropertyName("blue_flag_conceding")]
        public double BlueFlagConceding { get; set; }

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

        [JsonPropertyName("stamina")]
        public double Stamina { get; set; }

        [JsonPropertyName("start_reactions")]
        public double StartReactions { get; set; }

        [JsonPropertyName("tyre_management")]
        public double TyreManagement { get; set; }

        [JsonPropertyName("weather_tyre_changes")]
        public double? WeatherTyreChanges { get; set; }

        [JsonPropertyName("wet_skill")]
        public double? WetSkill { get; set; }
    }
}