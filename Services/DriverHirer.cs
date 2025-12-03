using AMS2ChEd.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public enum DriverRole
    {
        FIRST_DRIVER,
        SECOND_DRIVER
    }

    public class DriverResume
    {
        public string Id { get; set; }
        public DriverReputation Reputation { get; set; }
    }

    public class DriverHirer
    {

        public Dictionary<TeamReputation, Dictionary<DriverRole, DriverReputation[]>> teamPolicies = new()
        {
            { 
                TeamReputation.TOP_TEAM, new()
                {
                    { DriverRole.FIRST_DRIVER, new[] { 
                                                        DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL,
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL,
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN,
                                                     } 
                    },
                    { DriverRole.SECOND_DRIVER, new[] {
                                                        DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL,
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL,
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN,
                                                        DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN,
                                                        DriverReputation.AGEING_CHAMPIONSHIP_LEVEL,
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED,
                                                        DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED,
                                                        DriverReputation.PRIME_STRONG_MIDFIELD
                                                     }
                    }
                }
            },
            {
                TeamReputation.MIDFIELD_HIGH, new()
                {
                    { DriverRole.FIRST_DRIVER, new[] {
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED,
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN,
                                                        DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN,
                                                        DriverReputation.PRIME_STRONG_MIDFIELD,
                                                        DriverReputation.AGEING_STRONG_MIDFIELD
                                                     }
                    },
                    { DriverRole.SECOND_DRIVER, new[] {
                                                        DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED,
                                                        DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED,
                                                        DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN,
                                                        DriverReputation.PRIME_STRONG_MIDFIELD,
                                                        DriverReputation.AGEING_STRONG_MIDFIELD,
                                                        DriverReputation.PRIME_MIDFIELD
                                                     }
                    }
                }
            },
            {
                TeamReputation.MIDFIELD, new()
                {
                    { DriverRole.FIRST_DRIVER, new[] {
                                                        DriverReputation.PRIME_STRONG_MIDFIELD,
                                                        DriverReputation.AGEING_STRONG_MIDFIELD,
                                                        DriverReputation.PRIME_MIDFIELD,
                                                        DriverReputation.AGEING_MIDFIELD,
                                                     }
                    },
                    { DriverRole.SECOND_DRIVER, new[] {
                                                        DriverReputation.AGEING_STRONG_MIDFIELD,
                                                        DriverReputation.PRIME_MIDFIELD,
                                                        DriverReputation.YOUNG_TALENT,
                                                        DriverReputation.AGEING_MIDFIELD,
                                                     }
                    }
                }
            },
            {
                TeamReputation.MINNOW, new()
                {
                    { DriverRole.FIRST_DRIVER, new[] {
                                                        DriverReputation.PRIME_MIDFIELD,
                                                        DriverReputation.AGEING_MIDFIELD,
                                                        DriverReputation.YOUNG_TALENT,
                                                        DriverReputation.PAY_DRIVER_SEASON,
                                                     }
                    },
                    { DriverRole.SECOND_DRIVER, new[] {
                                                        DriverReputation.YOUNG_TALENT,
                                                        DriverReputation.PAY_DRIVER_SEASON,
                                                     }
                    }
                }
            },
            {
                TeamReputation.SUPER_MINNOW, new()
                {
                    { DriverRole.FIRST_DRIVER, new[] {
                                                        DriverReputation.YOUNG_TALENT,
                                                        DriverReputation.PAY_DRIVER_SEASON,
                                                     }
                    },
                    { DriverRole.SECOND_DRIVER, new[] {
                                                        DriverReputation.YOUNG_TALENT,
                                                        DriverReputation.PAY_DRIVER_SEASON,
                                                     }
                    }
                }
            },
        };
        public DriverResume? PickBestCandidate(IEnumerable<DriverResume> drivers, DriverRole role, TeamReputation teamReputation)
        {
            var result = drivers?.
                    Where(d => teamPolicies[teamReputation][role].Contains(d.Reputation))
                    .OrderByDescending(d => d.Reputation)
                    .FirstOrDefault();
            return result;
        }

        public DriverResume PickWinner(DriverResume diverPickedByTeam, DriverResume driverWhoIsProposingToTeam)
        {
            if (diverPickedByTeam == null)
                return driverWhoIsProposingToTeam;

            return diverPickedByTeam.Reputation >= driverWhoIsProposingToTeam.Reputation ? diverPickedByTeam : driverWhoIsProposingToTeam;
        }
    }
}
