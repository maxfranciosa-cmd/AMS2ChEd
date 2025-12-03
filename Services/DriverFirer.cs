using AMS2ChEd.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public class DriverFirer
    {
        private DriverReputation[] topTeamDrops = new[]
        {
            DriverReputation.PAY_DRIVER_WILD_CARD,
            DriverReputation.PAY_DRIVER_SEASON,
            DriverReputation.YOUNG_TALENT,
            DriverReputation.PRIME_MIDFIELD,
            DriverReputation.AGEING_MIDFIELD,
            DriverReputation.AGEING_STRONG_MIDFIELD
        };

        private DriverReputation[] midfieldHighDrops = new[]
        {
            DriverReputation.PAY_DRIVER_WILD_CARD,
            DriverReputation.PAY_DRIVER_SEASON,
            DriverReputation.YOUNG_TALENT,
            DriverReputation.PRIME_MIDFIELD
        };


        public bool WillDropDriver(TeamReputation teamReputation, DriverReputation driverNewReputation, int racesLeft)
        {
            if (racesLeft == 0)
                return true;

            switch(teamReputation)
            {
                case TeamReputation.TOP_TEAM:
                    return topTeamDrops.Contains(driverNewReputation);
                case TeamReputation.MIDFIELD_HIGH:
                    return midfieldHighDrops.Contains(driverNewReputation);
                default:
                    return false;
            }
        }
    }
}
