using AMS2ChEd.Models.Enums;
using AMS2ChEd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS2ChEd.Services
{
    public class ReputationUpdater
    {
        public static IEnumerable<DriverReputation> AvailableReputationForAge(int age)
        {
            yield return DriverReputation.PAY_DRIVER_WILD_CARD;
            yield return DriverReputation.PAY_DRIVER_SEASON;

            if (age < YOUNG_DRIVER_AGE)
            {
                yield return DriverReputation.YOUNG_TALENT;
                yield return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN;
                yield return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL;
            }
            else if (age < OLD_DRIVER_AGE)
            {
                yield return DriverReputation.PRIME_MIDFIELD;
                yield return DriverReputation.PRIME_STRONG_MIDFIELD;
                yield return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                yield return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL;
                yield return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED;
            }
            else
            {
                yield return DriverReputation.AGEING_MIDFIELD;
                yield return DriverReputation.AGEING_STRONG_MIDFIELD;
                yield return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;
                yield return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED;
            }

        }


        public const int YOUNG_DRIVER_AGE = 25;
        public const int OLD_DRIVER_AGE = 31;

        public DriverReputation EvaluateWildCard(int age, int position, bool dnf, int expectedPosition)
        {
            if (dnf) return DriverReputation.PAY_DRIVER_WILD_CARD;

            if (age < YOUNG_DRIVER_AGE)
            {
                if (position <= 3)
                {
                    return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN;
                }
                else if (position <= expectedPosition)
                {
                    return DriverReputation.YOUNG_TALENT;
                }
            }
            else if (age < OLD_DRIVER_AGE)
            {
                if (position <= 3)
                {
                    return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                }
                else if (position <= expectedPosition)
                {
                    return DriverReputation.PRIME_MIDFIELD;
                }
            }
            else
            {
                if (position <= 3)
                {
                    return DriverReputation.AGEING_STRONG_MIDFIELD;
                }
                else if (position <= expectedPosition)
                {
                    return DriverReputation.AGEING_MIDFIELD;
                }
            }

            return DriverReputation.PAY_DRIVER_SEASON;
        }

        public DriverReputation GetNewReputation(DriverReputation currentReputation, int age, int standings, int podiums, int dnfs)
        {
            if (currentReputation == DriverReputation.PAY_DRIVER_WILD_CARD)
            {
                throw new Exception("driver is a wild card, please use EvaluateWildcard function");
            }

            if (age < YOUNG_DRIVER_AGE)
            {
                return GetNewYoungReputation(currentReputation, age, standings, podiums, dnfs);
            }
            else if (age < OLD_DRIVER_AGE)
            {
                return GetNewPrimeReputation(currentReputation, age, standings, podiums, dnfs);
            }
            else
            {
                return GetNewAgeingReputation(currentReputation, age, standings, podiums, dnfs);
            }
        }

        private DriverReputation GetNewAgeingReputation(DriverReputation currentReputation, int age, int standings, int podiums, int dnfs)
        {
            if (standings == 1)
                return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;

            switch (currentReputation)
            {
                case DriverReputation.PAY_DRIVER_SEASON:
                    if (standings <= 15)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else if (dnfs <= 2)
                        return DriverReputation.AGEING_MIDFIELD;
                    else
                        return currentReputation;

                case DriverReputation.PRIME_MIDFIELD:
                    if (standings <= 12)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.PRIME_STRONG_MIDFIELD:
                    if (standings <= 10)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN:
                    if (standings <= 6)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.PRIME_MIDFIELD;

                case DriverReputation.PRIME_CHAMPIONSHIP_LEVEL:
                    if (standings <= 3)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED:
                    if (standings <= 3)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.AGEING_MIDFIELD:
                    if (standings <= 12)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.AGEING_STRONG_MIDFIELD:
                    if (standings <= 3)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 10)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.AGEING_CHAMPIONSHIP_LEVEL:
                    if (standings <= 3)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                case DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED:
                    if (standings <= 3)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.AGEING_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.AGEING_STRONG_MIDFIELD;
                    else
                        return DriverReputation.AGEING_MIDFIELD;

                default:
                    throw new Exception($"reputation not valid for a {age} year old: {currentReputation}");
            }
        }

        private DriverReputation GetNewPrimeReputation(DriverReputation currentReputation, int age, int standings, int podiums, int dnfs)
        {
            if (standings == 1)
                return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL;

            switch (currentReputation)
            {
                case DriverReputation.PAY_DRIVER_SEASON:
                    if (standings <= 10)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 15)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else if (dnfs <= 2)
                        return DriverReputation.PRIME_MIDFIELD;
                    else
                        return currentReputation;

                case DriverReputation.YOUNG_TALENT:
                    if (standings <= 8)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 12)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else if (dnfs <= 2)
                        return DriverReputation.PRIME_MIDFIELD;
                    else
                        return DriverReputation.PAY_DRIVER_SEASON;

                case DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN:
                    if (standings <= 6)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 12)
                        return DriverReputation.PRIME_MIDFIELD;
                    else
                        return DriverReputation.PAY_DRIVER_SEASON;

                case DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL:
                    if (standings <= 3)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else
                        return DriverReputation.PRIME_MIDFIELD;

                case DriverReputation.PRIME_MIDFIELD:
                    if (standings <= 8)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 12)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else if (standings <= 15)
                        return DriverReputation.PRIME_MIDFIELD;
                    else
                        return DriverReputation.PAY_DRIVER_SEASON;

                case DriverReputation.PRIME_STRONG_MIDFIELD:
                    if (standings <= 5)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 10)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else
                        return DriverReputation.PRIME_MIDFIELD;

                case DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN:
                    if (standings <= 6)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 8)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else
                        return DriverReputation.PRIME_MIDFIELD;

                case DriverReputation.PRIME_CHAMPIONSHIP_LEVEL:
                    if (standings <= 3)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else
                        return DriverReputation.PRIME_MIDFIELD;

                case DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED:
                    if (standings <= 3)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 6)
                        return DriverReputation.PRIME_CHAMPIONSHIP_LEVEL_WASHED;
                    else if (standings <= 10)
                        return DriverReputation.PRIME_STRONG_MIDFIELD;
                    else
                        return DriverReputation.PRIME_MIDFIELD;

                default:
                    throw new Exception($"reputation not valid for a {age} year old: {currentReputation}");
            }
        }

        private DriverReputation GetNewYoungReputation(DriverReputation currentReputation, int age, int standings, int podiums, int dnfs)
        {
            if (standings == 1)
                return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL;

            switch (currentReputation)
            {
                case DriverReputation.PAY_DRIVER_SEASON:
                    if (standings <= 10)
                        return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 15)
                        return DriverReputation.YOUNG_TALENT;
                    else return currentReputation;

                case DriverReputation.YOUNG_TALENT:
                    if (standings <= 10)
                        return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN;
                    else if (standings <= 15)
                        return currentReputation;
                    else
                        return DriverReputation.PAY_DRIVER_SEASON;

                case DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL_UNPROVEN:
                    if (standings <= 3)
                        return DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL;
                    else if (standings <= 8)
                        return currentReputation;
                    else if (standings <= 15)
                        return DriverReputation.YOUNG_TALENT;
                    else
                        return DriverReputation.PAY_DRIVER_SEASON;

                case DriverReputation.YOUNG_CHAMPIONSHIP_LEVEL:
                    if (standings <= 5)
                        return currentReputation;
                    else if (standings <= 10)
                        return DriverReputation.YOUNG_TALENT;
                    else
                        return DriverReputation.PAY_DRIVER_SEASON;

                default:
                    throw new Exception($"reputation not valid for a {age} year old: {currentReputation}");
            }
        }
    }
}

