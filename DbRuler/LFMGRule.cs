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
        /// RealAudience * 100000.
        /// </summary>
        /// <param name="RealAudience"></param>
        /// <returns></returns>
        public static long CalculateMoney(int RealAudience)
        {
            return RealAudience * 150000;
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