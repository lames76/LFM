using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    public static class LFMGRule
    {
        /// <summary>
        /// This method change the Actor/Actress passed moving all his/her inner values N point
        /// toward the value of the move he/she play in. It also save the Actor/Actress.
        /// </summary>
        /// <param name="Gen">The Actor/Actress to be chagned</param>
        /// <param name="SerialValues">The Inner Values of the Serial</param>
        /// <param name="Episodes">Number of Episode. The going up or down is the number of episode / 3</param>
        /// <returns></returns>
        public static bool ActorAdvancementForSerial(GenericCharacters Gen, Inner_Values SerialValues, int Episodes)
        {
            int Variance = Episodes / 3;
            if (Gen.Inner_Val.Action > SerialValues.Action)
                Gen.Inner_Val.Action -= Variance;
            else
                if (Gen.Inner_Val.Action < SerialValues.Action)
                Gen.Inner_Val.Action += Variance;
            if (Gen.Inner_Val.Humor > SerialValues.Humor)
                Gen.Inner_Val.Humor -= Variance;
            else
                if (Gen.Inner_Val.Humor < SerialValues.Humor)
                Gen.Inner_Val.Humor += Variance;

            if (Gen.Inner_Val.Sexappeal > SerialValues.Sexappeal)
                Gen.Inner_Val.Sexappeal -= Variance;
            else
                if (Gen.Inner_Val.Sexappeal < SerialValues.Sexappeal)
                Gen.Inner_Val.Sexappeal += Variance;
            return Gen.GenericCharacters_WriteOnDb();
        }

        /// <summary>
        /// This method change the Actor/Actress passed moving all his/her inner values one point
        /// toward the value of the move he/she play in. It also save the Actor/Actress.
        /// </summary>
        /// <param name="Gen">The Actor/Actress to be chagned</param>
        /// <param name="MovieValues">The Inner Values of the Movie</param>
        /// <returns></returns>
        public static bool ActorAdvancement(GenericCharacters Gen, Inner_Values MovieValues)
        {
            if (Gen.Inner_Val.Action > MovieValues.Action)
                Gen.Inner_Val.Action--;
            else
                if (Gen.Inner_Val.Action < MovieValues.Action)
                Gen.Inner_Val.Action++;
            if (Gen.Inner_Val.Humor > MovieValues.Humor)
                Gen.Inner_Val.Humor--;
            else
                if (Gen.Inner_Val.Humor < MovieValues.Humor)
                Gen.Inner_Val.Humor++;

            if (Gen.Inner_Val.Sexappeal > MovieValues.Sexappeal)
                Gen.Inner_Val.Sexappeal--;
            else
                if (Gen.Inner_Val.Sexappeal < MovieValues.Sexappeal)
                Gen.Inner_Val.Sexappeal++;
            return Gen.GenericCharacters_WriteOnDb();
        }

        /// <summary>
        /// This method change the Director passed moving all his/her inner values one point
        /// toward the value of the move he/she direct, but only if the difference is major
        /// of 10. It also save the Director.
        /// </summary>
        /// <param name="Gen">The Director to be chagned</param>
        /// <param name="MovieValues">The Inner Values of the Movie</param>
        /// <returns></returns>
        public static bool DirectorAdvancement(GenericCharacters Gen, Inner_Values MovieValues)
        {
            if ((Gen.Inner_Val.Action - MovieValues.Action) > 10)
                Gen.Inner_Val.Action--;
            else
                if ((Gen.Inner_Val.Action - MovieValues.Action) < -10)
                Gen.Inner_Val.Action++;
            if ((Gen.Inner_Val.Humor - MovieValues.Humor) > 10)
                Gen.Inner_Val.Humor--;
            else
                if ((Gen.Inner_Val.Humor - MovieValues.Humor) < -10)
                Gen.Inner_Val.Humor++;

            if ((Gen.Inner_Val.Sexappeal - MovieValues.Sexappeal) > 10)
                Gen.Inner_Val.Sexappeal--;
            else
                if ((Gen.Inner_Val.Sexappeal - MovieValues.Sexappeal) < -10)
                Gen.Inner_Val.Sexappeal++;
            return Gen.GenericCharacters_WriteOnDb();
        }

        /// <summary>
        /// This method calculate the real audience of the movie. The value is:
        /// Success + Base_Audience + random (-10,10) all multiplier by 2.
        /// </summary>
        /// <param name="MyMovie"></param>
        /// <returns>RealAudience</returns>
        public static int CalculateRealAudience(Movie MyMovie)
        {
            Random rndCasuale = new Random();

            int RealAudience = MyMovie.Success + MyMovie.Base_Audience;
            RealAudience += rndCasuale.Next(-10, 11);
            return RealAudience * 2;
        }

        /// <summary>
        /// This method calculate the cash get from the movie. The value is:
        /// RealAudience * 150000.
        /// </summary>
        /// <param name="RealAudience"></param>
        /// <returns></returns>
        public static long CalculateMoney(int RealAudience)
        {
            return RealAudience * 150000;
        }

        /// <summary>
        /// This method get the RealAudience (calulated only one time since it have random inside)
        /// and return the money gon in the selected week
        /// </summary>
        /// <param name="RealAudience"></param>
        /// <param name="Week"></param>
        /// <returns></returns>
        public static long CalculateMoneyByWeeks(int RealAudience, int Week)
        {
            long lngMoneyThisWeek = 0;
            long TotalMoney = CalculateMoney(RealAudience);
            long Appo34Perc = (TotalMoney * 34) / 100;
            long Appo33Perc = (TotalMoney * 33) / 100;
            switch (Week)
            {
                // Nella prima settimana si incassa il 34% dell'incasso.
                case 1:
                    lngMoneyThisWeek = Appo34Perc;
                    break;
                // Un 33% si incassa nelle successive 2 settimane (75% del 25% nella 1 ed il resto nella seconda).
                case 2:
                    lngMoneyThisWeek = (Appo33Perc * 75) / 100;
                    break;
                case 3:
                    lngMoneyThisWeek = (Appo33Perc * 25) / 100;
                    break;
                // Infine l'ultimo 33% è incassato nelle successive 3 settimane (55% 30% 15%).
                case 4:
                    lngMoneyThisWeek = (Appo33Perc * 55) / 100;
                    break;
                case 5:
                    lngMoneyThisWeek = (Appo33Perc * 30) / 100;
                    break;
                case 6:
                    lngMoneyThisWeek = (Appo33Perc * 15) / 100;
                    break;
            }
            return lngMoneyThisWeek;
        }

        /// <summary>
        /// This method calculate how the popularity change after the movie.
        /// If the movie get more than 10.000.000 is a huge popularity increase (+10),
        /// if it gain from 0 to 9.999.999 is a general popularity increase (+5).
        /// If it loose more than 10.000.000 is a huge disappointing (-10).
        /// If it loose between 0 and 9.999.999 is a general disappointment (-5).
        /// </summary>
        /// <param name="CalculateMoney">How much the movie get</param>
        /// <param name="Price">Price of the Movie</param>
        /// <returns></returns>
        public static int GetPopularityChange(long CalculateMoney, long Price)
        {
            int Change = 0;
            long Difference = CalculateMoney - Price;
            // More than 10.000.000 is a big success
            if (Difference >= 10000000)
                Change = 10;
            else
            {
                // More than 0 is a success
                if (Difference > 0)
                    Change = 5;
                else
                {
                    // More than 10.000.000 of loose is a big unsuccess
                    if (Difference <= -10000000)
                        Change = -10;
                    // Else is a small unsuccess.
                    else
                        Change = -5;
                }
            }
            return Change;
        }

        /// <summary>
        /// Get the change from the audience
        /// </summary>
        /// <param name="MySerial"></param>
        /// <returns></returns>
        public static int GetPopularityChange(Serial MySerial)
        {
            int Change = 0;
            long Difference = MySerial.Base_Audience - 100;
            // More than 10.000.000 is a big success
            if (Difference >= 50)
                Change = 10;
            else
            {
                // More than 0 is a success
                if (Difference > 0)
                    Change = 5;
                else
                {
                    // More than 10.000.000 of loose is a big unsuccess
                    if (Difference <= -50)
                        Change = -10;
                    // Else is a small unsuccess.
                    else
                        Change = -5;
                }
            }
            return Change;
        }
        /// <summary>
        /// This method apply the popularity chagne to the character and save it.
        /// </summary>
        /// <param name="Gen"></param>
        /// <param name="Change">coming from GetPopularityChange</param>
        /// <returns></returns>
        public static bool PopularityChange(GenericCharacters Gen, int Change)
        {
            Gen.Popularity += Change;
            if (Gen.Popularity > 100)
                Gen.Popularity = 100;
            else
            {
                if (Gen.Popularity < 0)
                    Gen.Popularity = 0;
            }
            return Gen.GenericCharacters_WriteOnDb();
        }

        /// <summary>
        /// This method change the Affinity adding/subtracting 1% or 2% based on Change value.
        /// It save the value and add 1 to the NumberOfMovie for the selected Character.
        /// </summary>
        /// <param name="Gen"></param>
        /// <param name="Change">Can value +/-5 or +/-10 (coming from GetPopularityChange)</param>
        /// <returns></returns>
        public static bool AffinityChange(GenericCharacters Gen, int Change)
        {
            int PercChange = 0;
            LG_CharPlayerAffinity Link = new LG_CharPlayerAffinity(Gen.ID);
            if (Change == 5)
                PercChange++;
            if (Change == 10)
                PercChange++;
            if (Change == -5)
                PercChange--;
            if (Change == -10)
                PercChange--;
            Link.Affinity += PercChange;
            if (Link.NumberOfMovies == 0)
            {
                Link.NumberOfMovies = 1;
                return Link.Insert();
            }
            else
            {
                Link.NumberOfMovies++;
                return Link.Update();
            }
        }
    }
}