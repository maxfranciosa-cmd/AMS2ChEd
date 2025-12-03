using AMS2ChEd.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public class DriverSituation
    {
        public string DriverId { get; set; }
        public DriverReputation Reputation { get; set; }

        public int RacesLeftInContract { get; set; }
        public bool Dropped { get; set; }
    }

    public class TeamSituation
    {
        public string TeamId { get; set; }

        public TeamReputation Reputation { get; set; }
        public DriverSituation Driver1 { get; set; }
        public DriverSituation Driver2 { get; set; }
    }

    public class DropTeamResult
    {
        public string TeamId { get; set; }
        public bool DropDriver1 { get; set; }

        public bool DropDriver2 { get; set; }
    }


    public class OffSeasonMovements
    {
        DriverFirer _driverFirer;
        DriverHirer _driverHirer;

        public OffSeasonMovements(DriverFirer driverFirer,DriverHirer driverHirer)
        {
            _driverFirer = driverFirer;
            _driverHirer = driverHirer;
        }

        public IEnumerable<DropTeamResult> DropDrivers(IEnumerable<TeamSituation> teams, out IEnumerable<string> driversDropped)
        {
            var dropped = new List<string>();
            var result = new List<DropTeamResult>();

            foreach (var team in teams)
            {
                var dropDriver1 = team.Driver1 != null && _driverFirer.WillDropDriver(team.Reputation, team.Driver1.Reputation, team.Driver1.RacesLeftInContract);
                var dropDriver2 = team.Driver2 != null && _driverFirer.WillDropDriver(team.Reputation, team.Driver2.Reputation, team.Driver2.RacesLeftInContract);
                
                if (dropDriver1) dropped.Add(team.Driver1.DriverId);
                if (dropDriver2) dropped.Add(team.Driver2.DriverId);

                result.Add(new()
                {
                    TeamId = team.TeamId,
                    DropDriver1 = dropDriver1,
                    DropDriver2 = dropDriver2,
                });

            }
            
            driversDropped = dropped.ToArray();

            return result;
        }

        public class TeamJobAd
        {
            public string TeamId { get; set; }

            public TeamReputation TeamReputation { get; set; }

            public DriverRole Role { get; set; }
        }

        public class TeamHiring
        {
            public string TeamId { get; set; }
            public string DriverId { get; set; }

            public DriverRole Role { get; set; }

            public DriverReputation DriverReputation { get; set; }

            public TeamReputation TeamReputation { get; set; }
        }

        public class UnenployedDriver
        {
            public string DriverId { get; set; }

            public DriverReputation Reputation { get; set; }
        }

        public IEnumerable<TeamHiring> PickPotentialNewDrivers(IEnumerable<TeamJobAd> jobAds,  IEnumerable<UnenployedDriver> poolOfDrivers)
        {
            var result = new List<TeamHiring>();
            var rnd = new Random();
            var orderJobAdOrderedByReputationAndRandomly = jobAds
                                                    .GroupBy(x => x.TeamReputation)
                                                    .OrderByDescending(g => g.Key)
                                                    .SelectMany(g => g.OrderBy(x => rnd.Next()))
                                                    .ToList();

            var availableDrivers = poolOfDrivers
                                        .GroupBy(x => x.Reputation)
                                        .OrderByDescending(g => g.Key)
                                        .SelectMany(g => g.OrderBy(x => rnd.Next()))
                                        .Select(g => new DriverResume()
                                        {
                                            Id = g.DriverId,
                                            Reputation = g.Reputation
                                        })
                                        .ToList();

            foreach (var teamJobAd in orderJobAdOrderedByReputationAndRandomly)
            {
                var winner = _driverHirer.PickBestCandidate(availableDrivers, teamJobAd.Role, teamJobAd.TeamReputation);

                result.Add(new TeamHiring()
                {
                    DriverId = winner.Id,
                    Role = teamJobAd.Role,
                    TeamId = teamJobAd.TeamId,
                    DriverReputation = winner.Reputation,
                    TeamReputation = teamJobAd.TeamReputation
                });

                availableDrivers.Remove(winner);
            }

            return result;

        }

        public class Ambition
        {
            public TeamReputation MinReputation { get; set; }
            public TeamReputation MaxReputation { get; set; }
        }

        readonly Dictionary<DriverReputation, Ambition> driverAmbitions = new()
        {
            {  DriverReputation.PAY_DRIVER_SEASON , new() { MaxReputation = TeamReputation.MIDFIELD , MinReputation = TeamReputation.SUPER_MINNOW } },
            {  DriverReputation.AGEING_MIDFIELD , new() { MaxReputation = TeamReputation.MIDFIELD , MinReputation = TeamReputation.SUPER_MINNOW } },
            {  DriverReputation.YOUNG_TALENT , new() { MaxReputation = TeamReputation.MIDFIELD , MinReputation = TeamReputation.SUPER_MINNOW } },
            {  DriverReputation.PRIME_MIDFIELD , new() { MaxReputation = TeamReputation.MIDFIELD_HIGH , MinReputation = TeamReputation.MINNOW } },
            {  DriverReputation.AGEING_STRONG_MIDFIELD , new() { MaxReputation = TeamReputation.MIDFIELD_HIGH , MinReputation = TeamReputation.MINNOW } },
            {  DriverReputation.PRIME_STRONG_MIDFIELD , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.MIDFIELD } },
            {  DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.MIDFIELD } },
            {  DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.MIDFIELD } },
            {  DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.MIDFIELD_HIGH } },
            {  DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.MIDFIELD_HIGH } },
            {  DriverReputation.AGEING_CHAMPIONSHIP_LEVEL , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.MIDFIELD_HIGH } },
            {  DriverReputation.PRIME_CHAMPIONSHIP_LEVEL , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.TOP_TEAM } },
            {  DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL , new() { MaxReputation = TeamReputation.TOP_TEAM , MinReputation = TeamReputation.TOP_TEAM } },
        };

        public class TeamHiringBallot
        {
            public TeamHiring OriginalTeamHiring { get; set; }

            public IEnumerable<TeamHiringBallotCandidate> Candidates { get; set; }
        }

        public class TeamHiringBallotCandidate
        {
            public string DriverId { get; set; }

            public DriverReputation DriverReputation { get; set; }
        }

        public IEnumerable<TeamHiringBallot> DriversProposeToTeams(IEnumerable<UnenployedDriver> poolOfDrivers,IEnumerable<TeamHiring> currentTeamPickings)
        {
            var result = currentTeamPickings.Select(h => new Tuple<TeamHiring,List<TeamHiringBallotCandidate>>(h,new List<TeamHiringBallotCandidate>()));

            foreach(var unenployedDriver in poolOfDrivers)
            {
                var maxAmbition = driverAmbitions[unenployedDriver.Reputation].MaxReputation;
                var minAmbition = driverAmbitions[unenployedDriver.Reputation].MinReputation;

                var potentialTeams = result.Where(r => r.Item1.TeamReputation >= maxAmbition && r.Item1.TeamReputation <= minAmbition);

                foreach (var potentialTeam in potentialTeams)
                {
                    potentialTeam.Item2.Add(new TeamHiringBallotCandidate { DriverId = unenployedDriver.DriverId, DriverReputation = unenployedDriver.Reputation });
                }
            }

            return result.Select(t => new TeamHiringBallot { OriginalTeamHiring = t.Item1, Candidates = t.Item2 });

        }

        public IEnumerable<TeamHiring> FinalBallotResults(IEnumerable<TeamHiringBallot> ballots)
        {
            var result = new List<TeamHiring>();
            var rnd = new Random();

            foreach(var ballot in ballots)
            {
                if (!ballot.Candidates.Any())
                {
                    result.Add(ballot.OriginalTeamHiring);
                }

                var bestCandidateResume = ballot.Candidates
                                        .GroupBy(x => x.DriverReputation)
                                        .OrderByDescending(g => g.Key)
                                        .SelectMany(g => g.OrderBy(x => rnd.Next()))
                                        .Select(g => new DriverResume {  Id = g.DriverId, Reputation = g.DriverReputation })
                                        .First();

                var originalHireResume = ballot.OriginalTeamHiring == null ? null : new DriverResume { Id = ballot.OriginalTeamHiring.DriverId, Reputation = ballot.OriginalTeamHiring.DriverReputation };

                var winner = _driverHirer.PickWinner(originalHireResume, bestCandidateResume);

                if (winner == originalHireResume)
                {
                    result.Add(ballot.OriginalTeamHiring);
                }

                result.Add(new TeamHiring
                {
                    Role = ballot.OriginalTeamHiring.Role,
                    TeamId = ballot.OriginalTeamHiring.TeamId,
                    TeamReputation = ballot.OriginalTeamHiring.TeamReputation,
                    DriverId =bestCandidateResume.Id,
                    DriverReputation = bestCandidateResume.Reputation
                });

            }

            return result;
        }
    }
}
