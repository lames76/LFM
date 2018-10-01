using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    #region Description
    /* 
 * Famous Movie Examples
    Humor		
    1<x<20	niente  shlinderlist
    21<x<50	act	true lies
    51<x<80	marv    film marvel
    81<x<100	ups pallottola spuntata
    Sex		
    1<x<20	niente  shlinderlist
    21<x<50	lov elizabethtown
    51<x<80	ses basic instinct
    81<x<100	porn rocco
    Violence		
    1<x<20	nient   harry ti presento sally
    21<x<50	act film di schwarzeneger
    51<x<80	viol    rambo
    81<x<100	splat   arancia meccanica
    TechnologyLevel		
    1<x<20	primitiva	
    21<x<50	moderna	
    51<x<80	futurist	
    81<x<100 sci-fi
*/
    #endregion
    public static class Calculation
    {
        #region Generic Calculations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B_Values_Min"></param>
        /// <param name="A_Values_Min"></param>
        /// <param name="B_Values_Max"></param>
        /// <param name="A_Values_Max"></param>
        /// <param name="strType">A, H or S</param>
        /// <returns>0 Down Same Side, 1 Up Same Side, 2 Not Same Side</returns>
        public static int IsSameSide(
            Inner_Values B_Values_Min,
            Inner_Values A_Values_Min,
            Inner_Values B_Values_Max,
            Inner_Values A_Values_Max,
            string strType)
        {
            int intSameSide = 2;

            switch (strType)
            {
                case "A":
                    if (B_Values_Min.Action == 0)
                    {
                        if (A_Values_Min.Action == 0)
                            intSameSide = 0;
                        else
                            intSameSide = 2;
                    }
                    else
                    {
                        if (B_Values_Max.Action == 100)
                        {
                            if (A_Values_Max.Action == 100)
                                intSameSide = 1;
                            else
                                intSameSide = 2;
                        }
                    }
                    break;
                case "H":
                    if (B_Values_Min.Humor == 0)
                    {
                        if (A_Values_Min.Humor == 0)
                            intSameSide = 0;
                        else
                            intSameSide = 2;
                    }
                    else
                    {
                        if (B_Values_Max.Humor == 100)
                        {
                            if (A_Values_Max.Humor == 100)
                                intSameSide = 1;
                            else
                                intSameSide = 2;
                        }
                    }
                    break;
                case "S":
                    if (B_Values_Min.Sexappeal == 0)
                    {
                        if (A_Values_Min.Sexappeal == 0)
                            intSameSide = 0;
                        else
                            intSameSide = 2;
                    }
                    else
                    {
                        if (B_Values_Max.Sexappeal == 100)
                        {
                            if (A_Values_Max.Sexappeal == 100)
                                intSameSide = 1;
                            else
                                intSameSide = 2;
                        }
                    }
                    break;
            }
            return intSameSide;
        }        

        public static string CheckJsonAndNormalizeGenre(string json)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This method merge two set of Inner_Values (max and min) and create the merged final value
        /// </summary>
        /// <param name="Max_Values_A"></param>
        /// <param name="Min_Values_A"></param>
        /// <param name="Max_Values_B"></param>
        /// <param name="Min_Values_B"></param>
        public static bool CalculateValueForTwoGenre(
            Inner_Values Max_Values_A,
            Inner_Values Min_Values_A,
            Inner_Values Max_Values_B,
            Inner_Values Min_Values_B,
            out Inner_Values Max_Values_Calculated,
            out Inner_Values Min_Values_Calculated)
        {
            bool blnIsOk = true;
            Max_Values_Calculated = new Inner_Values();
            Min_Values_Calculated = new Inner_Values();

            #region Action
            // Action
            int intActionSide = IsSameSide(Min_Values_B, Min_Values_A, Max_Values_B, Max_Values_A, "A");
            // Downside bond
            if (intActionSide == 0)
            {
                Min_Values_Calculated.Action = 0;

                if (Max_Values_A.Action > Max_Values_B.Action)
                    Max_Values_Calculated.Action = Max_Values_A.Action;
                else
                    Max_Values_Calculated.Action = Max_Values_B.Action;

                blnIsOk = true;
            }
            else
            {
                // Upside bond
                if (intActionSide == 1)
                {
                    Max_Values_Calculated.Action = 100;

                    if (Min_Values_A.Action < Min_Values_B.Action)
                        Min_Values_Calculated.Action = Min_Values_A.Action;
                    else
                        Min_Values_Calculated.Action = Min_Values_B.Action;

                    blnIsOk = true;
                }
                // Not same side
                else
                {
                    if (Min_Values_A.Action < Min_Values_B.Action)
                    {
                        if (Max_Values_A.Action >= Min_Values_B.Action)
                        {
                            Min_Values_Calculated.Action = Min_Values_B.Action;
                            Max_Values_Calculated.Action = Max_Values_A.Action;
                            blnIsOk = true;
                        }
                        else
                        {
                            Min_Values_Calculated.Action = 0;
                            Max_Values_Calculated.Action = 100;
                            blnIsOk = false;
                        }
                    }
                    else
                    {
                        if (Max_Values_B.Action >= Min_Values_A.Action)
                        {
                            Min_Values_Calculated.Action = Min_Values_A.Action;
                            Max_Values_Calculated.Action = Max_Values_B.Action;
                            blnIsOk = true;
                        }
                        else
                        {
                            Min_Values_Calculated.Action = 0;
                            Max_Values_Calculated.Action = 100;
                            blnIsOk = false;
                        }
                    }
                }
            }
            #endregion
            #region Humor
            // Action
            int intHumorSide = IsSameSide(Min_Values_B, Min_Values_A, Max_Values_B, Max_Values_A, "H");
            // Downside bond
            if (intHumorSide == 0)
            {
                Min_Values_Calculated.Humor = 0;

                if (Max_Values_A.Humor > Max_Values_B.Humor)
                    Max_Values_Calculated.Humor = Max_Values_A.Humor;
                else
                    Max_Values_Calculated.Humor = Max_Values_B.Humor;

                blnIsOk = true;
            }
            else
            {
                // Upside bond
                if (intHumorSide == 1)
                {
                    Max_Values_Calculated.Humor = 100;

                    if (Min_Values_A.Humor < Min_Values_B.Humor)
                        Min_Values_Calculated.Humor = Min_Values_A.Humor;
                    else
                        Min_Values_Calculated.Humor = Min_Values_B.Humor;

                    blnIsOk = true;
                }
                // Not same side
                else
                {
                    if (Min_Values_A.Humor < Min_Values_B.Humor)
                    {
                        if (Max_Values_A.Humor >= Min_Values_B.Humor)
                        {
                            Min_Values_Calculated.Humor = Min_Values_B.Humor;
                            Max_Values_Calculated.Humor = Max_Values_A.Humor;
                            blnIsOk = true;
                        }
                        else
                        {
                            Min_Values_Calculated.Humor = 0;
                            Max_Values_Calculated.Humor = 100;
                            blnIsOk = false;
                        }
                    }
                    else
                    {
                        if (Max_Values_B.Humor >= Min_Values_A.Humor)
                        {
                            Min_Values_Calculated.Humor = Min_Values_A.Humor;
                            Max_Values_Calculated.Humor = Max_Values_B.Humor;
                            blnIsOk = true;
                        }
                        else
                        {
                            Min_Values_Calculated.Humor = 0;
                            Max_Values_Calculated.Humor = 100;
                            blnIsOk = false;
                        }
                    }
                }
            }
            #endregion
            #region Sexappeal
            // Action
            int intSexappealSide = IsSameSide(Min_Values_B, Min_Values_A, Max_Values_B, Max_Values_A, "S");
            // Downside bond
            if (intSexappealSide == 0)
            {
                Min_Values_Calculated.Sexappeal = 0;

                if (Max_Values_A.Sexappeal > Max_Values_B.Sexappeal)
                    Max_Values_Calculated.Sexappeal = Max_Values_A.Sexappeal;
                else
                    Max_Values_Calculated.Sexappeal = Max_Values_B.Sexappeal;

                blnIsOk = true;
            }
            else
            {
                // Upside bond
                if (intSexappealSide == 1)
                {
                    Max_Values_Calculated.Sexappeal = 100;

                    if (Min_Values_A.Sexappeal < Min_Values_B.Sexappeal)
                        Min_Values_Calculated.Sexappeal = Min_Values_A.Sexappeal;
                    else
                        Min_Values_Calculated.Sexappeal = Min_Values_B.Sexappeal;

                    blnIsOk = true;
                }
                // Not same side
                else
                {
                    if (Min_Values_A.Sexappeal < Min_Values_B.Sexappeal)
                    {
                        if (Max_Values_A.Sexappeal >= Min_Values_B.Sexappeal)
                        {
                            Min_Values_Calculated.Sexappeal = Min_Values_B.Sexappeal;
                            Max_Values_Calculated.Sexappeal = Max_Values_A.Sexappeal;
                            blnIsOk = true;
                        }
                        else
                        {
                            Min_Values_Calculated.Sexappeal = 0;
                            Max_Values_Calculated.Sexappeal = 100;
                            blnIsOk = false;
                        }
                    }
                    else
                    {
                        if (Max_Values_B.Sexappeal >= Min_Values_A.Sexappeal)
                        {
                            Min_Values_Calculated.Sexappeal = Min_Values_A.Sexappeal;
                            Max_Values_Calculated.Sexappeal = Max_Values_B.Sexappeal;
                            blnIsOk = true;
                        }
                        else
                        {
                            Min_Values_Calculated.Sexappeal = 0;
                            Max_Values_Calculated.Sexappeal = 100;
                            blnIsOk = false;
                        }
                    }
                }
            }
            #endregion

            return blnIsOk;
        }

        /// <summary>
        /// This method compare two set of Inner_Values based on the value of the bool parameters.
        /// </summary>
        /// <param name="Inner_Val_To_Compare">Target Values</param>
        /// <param name="Inner_Value_To_Be_Compared">Compared values</param>
        /// <param name="IsActionUp">If the compared value should be greater than the target</param>
        /// <param name="IsHumorUp">If the compared value should be greater than the target</param>
        /// <param name="IsSexUp">If the compared value should be greater than the target</param>
        /// <returns></returns>
        public static int CompareTwoSetsOfTargetValues(
            Inner_Values Inner_Val_To_Compare, 
            Inner_Values Inner_Value_To_Be_Compared,
            bool IsActionUp,
            bool IsHumorUp,
            bool IsSexUp
            )
        {
            int intCalculatedValue = 0;
            intCalculatedValue += (IsActionUp ? Inner_Value_To_Be_Compared.Action - Inner_Val_To_Compare.Action : Inner_Val_To_Compare.Action - Inner_Value_To_Be_Compared.Action);
            intCalculatedValue += (IsHumorUp ? Inner_Value_To_Be_Compared.Humor - Inner_Val_To_Compare.Humor : Inner_Val_To_Compare.Humor - Inner_Value_To_Be_Compared.Humor);
            intCalculatedValue += (IsSexUp ? Inner_Value_To_Be_Compared.Sexappeal - Inner_Val_To_Compare.Sexappeal : Inner_Val_To_Compare.Sexappeal - Inner_Value_To_Be_Compared.Sexappeal);
            return intCalculatedValue;
        }

        /// <summary>
        /// This method get how good is the Inner_Val passed (based on TypeOfValue) compared to the values of the 
        /// MovieType value.
        /// If the value is inside the range you get a positive value difference from the average of the range value.
        /// If the value is outside the range you get a negative value difference from min or max outbound.
        /// </summary>
        /// <param name="inner_Val"></param>
        /// <param name="MovieType"></param>
        /// <param name="TypeOfValue">V, H or S</param>
        /// <returns></returns>
        private static int GetDifferenceFromValues(Inner_Values inner_Val, TypeOfMovie MovieType, string TypeOfValue)
        {
            int intDiff = 0;
            switch (TypeOfValue)
            {
                case "V":
                    if (inner_Val.Action >= MovieType.Inner_Val_Min.Action && inner_Val.Action <= MovieType.Inner_Val_Max.Action)
                    {
                        int Average = (MovieType.Inner_Val_Max.Action + MovieType.Inner_Val_Min.Action) / 2;
                        intDiff = Math.Abs(inner_Val.Action - Average);                        
                    }
                    else
                    {
                        if (inner_Val.Action < MovieType.Inner_Val_Min.Action)
                            intDiff = inner_Val.Action - MovieType.Inner_Val_Min.Action;
                        else
                            intDiff = MovieType.Inner_Val_Max.Action - inner_Val.Action;
                    }
                    break;
                case "H":
                    if (inner_Val.Humor >= MovieType.Inner_Val_Min.Humor && inner_Val.Humor <= MovieType.Inner_Val_Max.Humor)
                    {
                        int Average = (MovieType.Inner_Val_Max.Humor + MovieType.Inner_Val_Min.Humor) / 2;
                        intDiff = Math.Abs(inner_Val.Humor - Average);
                    }
                    else
                    {
                        if (inner_Val.Humor < MovieType.Inner_Val_Min.Humor)
                            intDiff = inner_Val.Humor - MovieType.Inner_Val_Min.Humor;
                        else
                            intDiff = MovieType.Inner_Val_Max.Humor - inner_Val.Humor;
                    }
                    break;
                case "S":
                    if (inner_Val.Sexappeal >= MovieType.Inner_Val_Min.Sexappeal && inner_Val.Sexappeal <= MovieType.Inner_Val_Max.Sexappeal)
                    {
                        int Average = (MovieType.Inner_Val_Max.Sexappeal + MovieType.Inner_Val_Min.Sexappeal) / 2;
                        intDiff = Math.Abs(inner_Val.Sexappeal - Average);
                    }
                    else
                    {
                        if (inner_Val.Sexappeal < MovieType.Inner_Val_Min.Sexappeal)
                            intDiff = inner_Val.Sexappeal - MovieType.Inner_Val_Min.Sexappeal;
                        else
                            intDiff = MovieType.Inner_Val_Max.Sexappeal - inner_Val.Sexappeal;
                    }
                    break;
            }
            return intDiff;
        }

        /// <summary>
        /// This method get how good is the Inner_Val passed (based on TypeOfValue) compared to the values of the 
        /// Movie Values.
        /// The value is the difference between the value and the movie value, always a negative number.
        /// </summary>
        /// <param name="inner_Val"></param>
        /// <param name="MyMov"></param>
        /// <param name="TypeOfValue">V, H or S</param>
        /// <returns></returns>
        private static int GetDifferenceFromValues(Inner_Values inner_Val, Movie MyMov, string TypeOfValue)
        {
            //TypeOfMovie MovieType = MyMov.fkType;
            int intDiff = 0;
            switch (TypeOfValue)
            {
                case "V":
                    //if (inner_Val.Action >= MovieType.Inner_Val_Min.Action && inner_Val.Action <= MovieType.Inner_Val_Max.Action)
                    //{
                    //    int Average = MyMov.Inner_Val.Action;
                    //    intDiff = Math.Abs(inner_Val.Action - Average);
                    //}
                    //else
                    //{
                    //    if (inner_Val.Action < MovieType.Inner_Val_Min.Action)
                    //        intDiff = inner_Val.Action - MovieType.Inner_Val_Min.Action;
                    //    else
                    //        intDiff = MovieType.Inner_Val_Max.Action - inner_Val.Action;
                    //}
                    if (inner_Val.Action < MyMov.Inner_Val.Action)
                        intDiff = inner_Val.Action - MyMov.Inner_Val.Action;
                    else
                        intDiff = MyMov.Inner_Val.Action - inner_Val.Action;
                    break;
                case "H":
                    //if (inner_Val.Humor >= MovieType.Inner_Val_Min.Humor && inner_Val.Humor <= MovieType.Inner_Val_Max.Humor)
                    //{
                    //    int Average = MyMov.Inner_Val.Humor;
                    //    intDiff = Math.Abs(inner_Val.Humor - Average);
                    //}
                    //else
                    //{
                    //    if (inner_Val.Humor < MovieType.Inner_Val_Min.Humor)
                    //        intDiff = inner_Val.Humor - MovieType.Inner_Val_Min.Humor;
                    //    else
                    //        intDiff = MovieType.Inner_Val_Max.Humor - inner_Val.Humor;
                    //}
                    if (inner_Val.Humor < MyMov.Inner_Val.Humor)
                        intDiff = inner_Val.Humor - MyMov.Inner_Val.Humor;
                    else
                        intDiff = MyMov.Inner_Val.Humor - inner_Val.Humor;
                    break;
                case "S":
                    //if (inner_Val.Sexappeal >= MovieType.Inner_Val_Min.Sexappeal && inner_Val.Sexappeal <= MovieType.Inner_Val_Max.Sexappeal)
                    //{
                    //    int Average = MyMov.Inner_Val.Sexappeal;
                    //    intDiff = Math.Abs(inner_Val.Sexappeal - Average);
                    //}
                    //else
                    //{
                    //    if (inner_Val.Sexappeal < MovieType.Inner_Val_Min.Sexappeal)
                    //        intDiff = inner_Val.Sexappeal - MovieType.Inner_Val_Min.Sexappeal;
                    //    else
                    //        intDiff = MovieType.Inner_Val_Max.Sexappeal - inner_Val.Sexappeal;
                    //}
                    if (inner_Val.Sexappeal < MyMov.Inner_Val.Sexappeal)
                        intDiff = inner_Val.Sexappeal - MyMov.Inner_Val.Sexappeal;
                    else
                        intDiff = MyMov.Inner_Val.Sexappeal - inner_Val.Sexappeal;
                    break;
            }
            return intDiff;
        }
        #endregion

        #region Script
        /// <summary>
        /// This method calculate the values of the movie from the level of the script
        /// </summary>
        /// <param name="level"></param>
        /// <param name="movieType"></param>
        /// <returns></returns>
        private static Inner_Values GenerateMovieValueFromScriptLevel(TypeOfLevel level, TypeOfMovie[] movieType, out int Success)
        {
            Random rndCasuale = new Random();
            Inner_Values RetVal = new Inner_Values();
            int intLevelVariance = 0;
            switch (level.Level)
            {
                case "A": intLevelVariance = 10; break;
                case "A1": intLevelVariance = 0;  break;
                case "B": intLevelVariance = 20;  break;
                case "Z": intLevelVariance = 30;  break;
            }
            #region Calculate Bound Values From Types
            TypeOfMovie JoinedValue = new TypeOfMovie(-1);
            // Assegno il primo genere al Joined Value
            JoinedValue = GetUnifiedTypeOfMovie(movieType, out Success);
            #endregion
            // Aggiungo i random vari
            RetVal.Action = rndCasuale.Next(JoinedValue.Inner_Val_Min.Action - intLevelVariance, JoinedValue.Inner_Val_Max.Action + intLevelVariance);
            RetVal.Humor = rndCasuale.Next(JoinedValue.Inner_Val_Min.Humor - intLevelVariance, JoinedValue.Inner_Val_Max.Humor + intLevelVariance);
            RetVal.Sexappeal = rndCasuale.Next(JoinedValue.Inner_Val_Min.Sexappeal - intLevelVariance, JoinedValue.Inner_Val_Max.Sexappeal + intLevelVariance);
            // Normalizzo a minimo 0 e massimo 100
            if (RetVal.Action < 0)
                RetVal.Action = 0;
            if (RetVal.Action > 100)
                RetVal.Action = 100;
            if (RetVal.Humor < 0)
                RetVal.Humor = 0;
            if (RetVal.Humor > 100)
                RetVal.Humor = 100;
            if (RetVal.Sexappeal < 0)
                RetVal.Sexappeal = 0;
            if (RetVal.Sexappeal > 100)
                RetVal.Sexappeal = 100;
            
            return RetVal;
        }
        #endregion

        #region Writer
        /// <summary>
        /// This method calculate the value of the movie based from value of the writer and talent.
        /// </summary>
        /// <param name="Inner_Val"></param>
        /// <param name="intGen"></param>
        /// <param name="intT"></param>
        /// <returns></returns>
        public static Inner_Values CompareWriterSkillToTargetValue(Inner_Values Inner_Val, TypeOfMovie MovieGen, int intTalent, int Random)
        {
            Random rndCasuale = new Random();
            Inner_Values RetVal = new Inner_Values();
            if (Inner_Val.Action >= MovieGen.Inner_Val_Min.Action && Inner_Val.Action <= MovieGen.Inner_Val_Max.Action)
                RetVal.Action = Inner_Val.Action + rndCasuale.Next(-Random, Random);
            else
            {
                if (Inner_Val.Action < MovieGen.Inner_Val_Min.Action)
                    RetVal.Action = Inner_Val.Action + intTalent;
                else
                    RetVal.Action = Inner_Val.Action - intTalent;
            }
            if (Inner_Val.Humor >= MovieGen.Inner_Val_Min.Humor && Inner_Val.Humor <= MovieGen.Inner_Val_Max.Humor)
                RetVal.Humor = Inner_Val.Humor + rndCasuale.Next(-Random, Random);
            else
            {
                if (Inner_Val.Humor < MovieGen.Inner_Val_Min.Humor)
                    RetVal.Humor = Inner_Val.Humor + intTalent;
                else
                    RetVal.Humor = Inner_Val.Humor - intTalent;
            }
            if (Inner_Val.Sexappeal >= MovieGen.Inner_Val_Min.Sexappeal && Inner_Val.Sexappeal <= MovieGen.Inner_Val_Max.Sexappeal)
                RetVal.Sexappeal = Inner_Val.Sexappeal + rndCasuale.Next(-Random, Random);
            else
            {
                if (Inner_Val.Sexappeal < MovieGen.Inner_Val_Min.Sexappeal)
                    RetVal.Sexappeal = Inner_Val.Sexappeal + intTalent;
                else
                    RetVal.Sexappeal = Inner_Val.Sexappeal - intTalent;
            }
            if (RetVal.Action > 100)
                RetVal.Action = 100;
            if (RetVal.Humor> 100)
                RetVal.Humor = 100;
            if (RetVal.Sexappeal > 100)
                RetVal.Sexappeal = 100;
            if (RetVal.Action <0 )
                RetVal.Action = 0;
            if (RetVal.Humor < 0)
                RetVal.Humor = 0;
            if (RetVal.Sexappeal < 0)
                RetVal.Sexappeal = 0;
            return RetVal;
        }
        #endregion

        # region Cost Actors + Writer + Director + Structure + Showrunner
        /// <summary>
        /// This method return the Affinity between the passed character and the player.
        /// </summary>
        /// <param name="Actor"></param>
        /// <returns></returns>
        public static int GetAffinityFromChar(GenericCharacters Gen)
        {
            LG_CharPlayerAffinity Aff = new LG_CharPlayerAffinity(Gen.ID);
            if (Aff.NumberOfMovies > 0)
            {
                return Aff.Affinity;
            }
            else
                return 0;
        }

        public static long GetCashOfActor(GenericCharacters Actor, Movie MyMovie)
        {
            // La variazione su violenza è quella base
            int VarianceV = Math.Abs(GetDifferenceFromValues(Actor.Inner_Val, MyMovie, "V"));
            // La variazione su sesso è doppia
            int VarianceS = Math.Abs(GetDifferenceFromValues(Actor.Inner_Val, MyMovie, "S") * 2);
            // La variazione su humor è dimezzata
            int VarianceH = Math.Abs(GetDifferenceFromValues(Actor.Inner_Val, MyMovie, "H") / 2);
            int Variance =  VarianceH + VarianceS + VarianceV;
            long BasePrize = Actor.Popularity * 20000;
            if (Variance > 0)
                BasePrize += Variance * 10000;
            else
                BasePrize -= Variance * 50000;
            int Perc = GetAffinityFromChar(Actor);
            BasePrize -= (BasePrize + Perc) / 100;
            return BasePrize;
        }

        public static long GetCashOfActor(GenericCharacters Actor, Serial MyMovie)
        {
            Random rndCasual = new Random();
            long BasePrize = Actor.Popularity * 20000;
            if (rndCasual.Next(-10,11) > 0)
                BasePrize += 20000;
            else
                BasePrize -= 5000;
            int Perc = GetAffinityFromChar(Actor);
            BasePrize -= (BasePrize + Perc) / 100;
            return BasePrize;
        }

        public static long GetCashOfDirector(GenericCharacters Actor, Movie MyMovie)
        {
            // La variazione su violenza è quella base
            int VarianceV = Math.Abs(GetDifferenceFromValues(Actor.Inner_Val, MyMovie, "V"));
            // La variazione su sesso è doppia
            int VarianceS = Math.Abs(GetDifferenceFromValues(Actor.Inner_Val, MyMovie, "S") * 2);
            // La variazione su humor è dimezzata
            int VarianceH = Math.Abs(GetDifferenceFromValues(Actor.Inner_Val, MyMovie, "H") / 2);
            int Variance = VarianceH + VarianceS + VarianceV;
            long BasePrize = Actor.Popularity * 100000;
            if (Variance > 0)
                BasePrize += Variance * 100000;
            else
                BasePrize -= Variance * 500000;
            return BasePrize;
        }

        public static long GetCashOfWriter(GenericCharacters Writer, Movie MyMovie)
        {
            int VarianceV = Math.Abs(GetDifferenceFromValues(Writer.Inner_Val, MyMovie, "V"));
            int VarianceS = Math.Abs(GetDifferenceFromValues(Writer.Inner_Val, MyMovie, "S"));
            int VarianceH = Math.Abs(GetDifferenceFromValues(Writer.Inner_Val, MyMovie, "H"));
            int Variance = VarianceH + VarianceS + VarianceV;

            long Base_Prize = MyMovie.Success * 10000 + MyMovie.Base_Audience * 20000;
            if (Variance > 0)
                Base_Prize += Variance * 25000;
            else
                Base_Prize -= Variance * 5000;
            return Base_Prize;
        }

        public static long GetCashOfShowrunner(GenericCharacters Showrunner)
        {
            Random rndCasuale = new Random();
            long Base_Prize = (Showrunner.Talent + Showrunner.Skills) * 20000;
            if (rndCasuale.Next(-10,11) > 0)
                Base_Prize += 25000;
            else
                Base_Prize -= 5000;
            int Perc = GetAffinityFromChar(Showrunner);
            Base_Prize -= (Base_Prize + Perc) / 100;
            return Base_Prize;
        }

        public static long GetPriceOfTheatre(Movie MyMovie)
        {
            Random rndCasuale = new Random();
            long Price = MyMovie.fkTdP.SuccessBonus + MyMovie.fkTdP.AudienceBonus;
            long BasePrize = Price * 10000;
            BasePrize += rndCasuale.Next(1,5) * 100000;            
            return BasePrize;
        }

        public static long GetPriceOfFX(Movie MyMovie)
        {
            Random rndCasuale = new Random();
            long Price = MyMovie.fkFX.SuccessBonus + MyMovie.fkFX.AudienceBonus;
            long BasePrize = Price * 10000;
            BasePrize += rndCasuale.Next(1, 5) * 100000;
            return BasePrize;
        }

        public static long GetPriceOfTheatre(Serial MySerial)
        {
            Random rndCasuale = new Random();
            long Price = MySerial.fkTdP.SuccessBonus + MySerial.fkTdP.AudienceBonus;
            long BasePrize = Price * 10000;
            BasePrize += rndCasuale.Next(1, 5) * 100000;
            return BasePrize;
        }

        public static long GetPriceOfFX(Serial MySerial)
        {
            Random rndCasuale = new Random();
            long Price = MySerial.fkFX.SuccessBonus + MySerial.fkFX.AudienceBonus;
            long BasePrize = Price * 10000;
            BasePrize += rndCasuale.Next(1, 5) * 100000;
            return BasePrize;
        }

        internal static long GetCostOfLocation(int l_ID)
        {
            Random rndCasuale = new Random();
            Location Loc = new Location(l_ID);
            long Price = Loc.SuccessBonus + Loc.AudienceBonus;
            long BasePrize = Price * 1000;
            BasePrize += rndCasuale.Next(1, 5) * 100;
            return BasePrize;
        }
        #endregion

        #region Movie
        #region Movie Type
        public static TypeOfMovie GetUnifiedTypeOfMovie(TypeOfMovie[] movieType, out int Success)
        {            
            #region Calculate Bound Values From Types
            TypeOfMovie JoinedValue = new TypeOfMovie(-1);
            // Assegno il primo genere al Joined Value
            JoinedValue = new TypeOfMovie(movieType[0].ID);
            Success = 0;
            // Se uno come prima
            if (movieType.Length > 1)
            {
                // Ciclo gli altri generi
                for (int i = 1; i < movieType.Length; i++)
                {
                    if (movieType[i] != null)
                    {
                        Inner_Values Max = new Inner_Values();
                        Inner_Values Min = new Inner_Values();
                        // Calcolo l'intersezione dei valori e ritorno i nuovi min e max risultati dall'intersezione stessa
                        bool blnResult = CalculateValueForTwoGenre(JoinedValue.Inner_Val_Max, JoinedValue.Inner_Val_Min, movieType[i].Inner_Val_Max, movieType[i].Inner_Val_Min, out Max, out Min);
                        // Li assegno al mio Joined Value
                        JoinedValue.Inner_Val_Max = Max;
                        JoinedValue.Inner_Val_Min = Min;
                        // Se i due valori non si intersecavano sto usando due insiemi che non si toccano
                        if (!blnResult)
                            // Quindi successo -100 (ALPHA)
                            Success -= 100;
                    }
                }
            }
            #endregion
            return JoinedValue;
        }
        #endregion

        #region Create
        /// <summary>
        /// This method create the base movie from a script.
        /// This is the first method to create a movie.
        /// </summary>
        /// <param name="Scripts"></param>
        /// <param name="MovieType"></param>
        /// <returns></returns>
        private static Movie CreateMovieFromScript(Script Scripts, TypeOfMovie[] MovieType, int CurrentAge)
        {            
            Movie NewMovie = new Movie();
            int SuccessByTypeMix = 0;
            NewMovie.Inner_Val = new Inner_Values();
            NewMovie.Inner_Val = GenerateMovieValueFromScriptLevel(Scripts.Level, MovieType, out SuccessByTypeMix);
            NewMovie.Title = Scripts.Title;
            NewMovie.Age = CurrentAge;
            NewMovie.Citation = "Set Movie Citation.";
            NewMovie.Description = Scripts.Description;
            for (int i = 0; i < MovieType.Length; i++)
            {
                NewMovie.fkType[i] = new TypeOfMovie(MovieType[i].ID);
            }
            NewMovie.Success = SuccessByTypeMix;
            NewMovie.Base_Audience = 0;
            foreach (TypeOfMovie MT in MovieType)
            {
                NewMovie.Status += MT.GetTotalProductionTime();
            }
            Scripts.MoviesAndScripts_DeleteScript();
            return NewMovie;
        }        

        /// <summary>
        /// This method create the base movie from a writer.
        /// This is the second method to create a movie.
        /// </summary>
        /// <param name="Writer"></param>
        /// <param name="MovieType"></param>
        /// <returns></returns>
        public static Movie CreateMovieFromWriter(GenericCharacters Writer, TypeOfMovie[] MovieType, int CurrentAge, out long Price)
        {
            #region SpecialAbilities (Alpha)
            int intBonusAudience = 0;
            int intBonusSuccess = 0;
            int intBonusAction = 0;
            int intBonusHumor = 0;
            int intBonusSexappeal = 0;
            Retriever.GetBonusFromSkills(Writer, out intBonusAudience, out intBonusSuccess, out intBonusAction, out intBonusHumor, out intBonusSexappeal);
            #endregion
            Price = 0;
            int Success = 0;
            Movie NewMovie = new Movie();
            NewMovie.Inner_Val = new Inner_Values();
            TypeOfMovie FinalMovieType = GetUnifiedTypeOfMovie(MovieType, out Success);
            // ALPHA - Set random to 5%
            NewMovie.Inner_Val = CompareWriterSkillToTargetValue(Writer.Inner_Val, FinalMovieType, Writer.Talent, 5);
            NewMovie.Title = Writer.Name + " " + Writer.Surname + "'s ";
            NewMovie.Age = CurrentAge;            
            NewMovie.Citation = "Set Movie Citation.";
            NewMovie.Description = "Generic Movie Description for ";
            NewMovie.fkType = MovieType;            
            // Originality: add to the Level
            NewMovie.Success = Writer.Skills + Success;
            // Base Audience is the popularity of the Writer
            NewMovie.Base_Audience = Writer.Popularity + intBonusAudience;
            foreach (TypeOfMovie ToM in MovieType)
            {
                NewMovie.Title += ToM.TypeOf + " ";
                NewMovie.Description += ToM.TypeOf + " ";
                NewMovie.Status += ToM.GetTotalProductionTime();
            }
            NewMovie.Status /= MovieType.Length;
            NewMovie.Title += "movie";
            NewMovie.Description += "movie";
            #region Special Abilities (Alpha)
            NewMovie.Inner_Val.Action += intBonusAction;
            NewMovie.Inner_Val.Sexappeal += intBonusSexappeal;
            NewMovie.Inner_Val.Humor += intBonusHumor;
            NewMovie.Base_Audience += intBonusAudience;
            NewMovie.Success += intBonusSuccess;
            #endregion
            Price = GetCashOfWriter(Writer, NewMovie);
            return NewMovie;
        }

        /// <summary>
        /// This method adjust the Inner Values of the Movie to the one of the director.
        /// If a value is lesser than the value of the Director is get up from 5 to Difference points 
        /// (or 0 to difference if difference is less than 5).
        /// If a value is bigger than the value of the Director is get down from 5 to Difference points 
        /// (or 0 to difference if difference is less than 5).
        /// Difference maximum 15.
        /// The check are subsequential so it's possible that a value is first lowered than push up.
        /// </summary>
        /// <param name="Director"></param>
        /// <param name="MyMovie"></param>
        /// <returns></returns>
        public static void DirectorStyleChangeMovie(GenericCharacters Director, Movie MyMovie)
        {
            Random rndCasuale = new Random();
            int intMaxValue = Math.Abs((MyMovie.Inner_Val.Action - Director.Inner_Val.Action));
            int intMinValue = 5;
            if (intMaxValue < intMinValue)
                intMinValue = 0;
            else
            {
                if (intMaxValue > 15)
                    intMaxValue = 15;
            }
            if (MyMovie.Inner_Val.Action > Director.Inner_Val.Action)
                MyMovie.Inner_Val.Action -= rndCasuale.Next(intMinValue, intMaxValue);
            if (MyMovie.Inner_Val.Action < Director.Inner_Val.Action)
                MyMovie.Inner_Val.Action += rndCasuale.Next(intMinValue, intMaxValue);

            intMaxValue = Math.Abs((MyMovie.Inner_Val.Humor - Director.Inner_Val.Humor));
            intMinValue = 5;
            if (intMaxValue < intMinValue)
                intMinValue = 0;
            else
            {
                if (intMaxValue > 15)
                    intMaxValue = 15;
            }
            if (MyMovie.Inner_Val.Humor > Director.Inner_Val.Humor)
                MyMovie.Inner_Val.Humor -= rndCasuale.Next(intMinValue, intMaxValue);
            if (MyMovie.Inner_Val.Humor < Director.Inner_Val.Humor)
                MyMovie.Inner_Val.Humor += rndCasuale.Next(intMinValue, intMaxValue);

            intMaxValue = Math.Abs((MyMovie.Inner_Val.Sexappeal - Director.Inner_Val.Sexappeal));
            intMinValue = 5;
            if (intMaxValue < intMinValue)
                intMinValue = 0;
            else
            {
                if (intMaxValue > 15)
                    intMaxValue = 15;
            }
            if (MyMovie.Inner_Val.Sexappeal > Director.Inner_Val.Sexappeal)
                MyMovie.Inner_Val.Sexappeal -= rndCasuale.Next(intMinValue, intMaxValue);
            if (MyMovie.Inner_Val.Sexappeal < Director.Inner_Val.Sexappeal)
                MyMovie.Inner_Val.Sexappeal += rndCasuale.Next(intMinValue, intMaxValue);
        }
        #endregion

        #region Production
        /// TODO: Theatre where the movie is filmed, locations and special effects.

        /// <summary>
        /// This method return the Success value get from Director performance and update the performance
        /// in the link table. It also update the Base_Audience of the movie based on Director Popularity x 2.
        /// </summary>
        /// <param name="Director"></param>
        /// <param name="CurrentMovie"></param>
        /// <returns></returns>
        private static int CalculateSuccessFromDirector(GenericCharacters Director, Movie CurrentMovie, int Random, string strRole)
        {
            Random rndCasuale = new Random();
            #region SpecialAbilities (Alpha)
            int intBonusAudience = 0;
            int intBonusSuccess = 0;
            int intBonusAction = 0;
            int intBonusHumor = 0;
            int intBonusSexappeal = 0;
            Retriever.GetBonusFromSkills(Director, out intBonusAudience, out intBonusSuccess, out intBonusAction, out intBonusHumor, out intBonusSexappeal);
            #endregion
            CurrentMovie.Base_Audience += Director.Popularity * 2;
            L_CharsMovies Updater = new L_CharsMovies(Director.ID, CurrentMovie.ID, strRole);
            int ActionVariance = GetDifferenceFromValues(Director.Inner_Val, CurrentMovie, "V");
            ActionVariance += intBonusAction;
            int HumorVariance = GetDifferenceFromValues(Director.Inner_Val, CurrentMovie, "H");
            int SexVariance = GetDifferenceFromValues(Director.Inner_Val, CurrentMovie, "S");
            int Success = ActionVariance + HumorVariance + SexVariance + rndCasuale.Next(-Random,Random);
            #region Special Abilities (Alpha)
            ActionVariance += intBonusAction;
            HumorVariance += intBonusHumor;
            SexVariance += intBonusSexappeal;
            CurrentMovie.Base_Audience += intBonusAudience;
            Success += intBonusSuccess;
            #endregion
            Updater.Performance = Success;
            Updater.Performance_Description = "A: " + ActionVariance.ToString() +
                " - H: " + HumorVariance.ToString() +
                " - S: " + SexVariance.ToString();
            Updater.L_CharsMovies_UpdatePerformance();
            return Success;
        }

        /// <summary>
        /// This method return the Success value get from Director performance and update the performance
        /// in the link table. It also update the Base_Audience of the movie based on Director Popularity x 1. 
        /// </summary>
        /// <param name="Musician"></param>
        /// <param name="CurrentMovie"></param>
        /// <param name="Random"></param>
        /// <returns></returns>
        private static int CalculateSuccessFromComposer(GenericCharacters Musician, Movie CurrentMovie, int Random, string strRole)
        {
            Random rndCasuale = new Random();
            #region SpecialAbilities (Alpha)
            int intBonusAudience = 0;
            int intBonusSuccess = 0;
            int intBonusAction = 0;
            int intBonusHumor = 0;
            int intBonusSexappeal = 0;
            Retriever.GetBonusFromSkills(Musician, out intBonusAudience, out intBonusSuccess, out intBonusAction, out intBonusHumor, out intBonusSexappeal);
            #endregion
            int OldBase_Audience = CurrentMovie.Base_Audience;
            for (int i = 0; i < CurrentMovie.fkType.Length; i++)
            {
                if (CurrentMovie.fkType[i].TypeOf.ToUpper() == "MUSICAL")
                    CurrentMovie.Base_Audience += Musician.Popularity * 5;
            }
            if (OldBase_Audience == CurrentMovie.Base_Audience)
                CurrentMovie.Base_Audience += Musician.Popularity;
            L_CharsMovies Updater = new L_CharsMovies(Musician.ID, CurrentMovie.ID, strRole);
            int ActionVariance = GetDifferenceFromValues(Musician.Inner_Val, CurrentMovie, "V");
            int HumorVariance = GetDifferenceFromValues(Musician.Inner_Val, CurrentMovie, "H");
            int SexVariance = GetDifferenceFromValues(Musician.Inner_Val, CurrentMovie, "S");
            int Success = ActionVariance + HumorVariance + SexVariance + rndCasuale.Next(-Random, Random);
            #region Special Abilities (Alpha)
            ActionVariance += intBonusAction;
            HumorVariance += intBonusHumor;
            SexVariance += intBonusSexappeal;
            CurrentMovie.Base_Audience += intBonusAudience;
            Success += intBonusSuccess;
            #endregion
            Updater.Performance = Success;
            Updater.Performance_Description = "A: " + ActionVariance.ToString() +
                " - H: " + HumorVariance.ToString() +
                " - S: " + SexVariance.ToString();
            Updater.L_CharsMovies_UpdatePerformance();
            return Success;
        }

        /// <summary>
        /// This method return the Success value get from Actor performance and update the performance
        /// in the link table. It also update the Base_Audience of the movie based on Director Popularity x 3,
        /// (Popularity x 5 if is a Musical and the Actor is a Singer).
        /// </summary>
        /// <param name="Actor"></param>
        /// <param name="CurrentMovie"></param>
        /// <param name="Random"></param>
        /// <returns></returns>
        private static int CalculateSuccessFromActor(GenericCharacters Actor, Movie CurrentMovie, int Random, string strRole)
        {
            Random rndCasuale = new Random();
            #region SpecialAbilities (Alpha)
            int intBonusAudience = 0;
            int intBonusSuccess = 0;
            int intBonusAction = 0;
            int intBonusHumor = 0;
            int intBonusSexappeal = 0;
            Retriever.GetBonusFromSkills(Actor, out intBonusAudience, out intBonusSuccess, out intBonusAction, out intBonusHumor, out intBonusSexappeal);
            #endregion
            if (Actor.TypeOf.TypeOf.ToUpper() == "SINGER")
            {
                foreach (TypeOfMovie T in CurrentMovie.fkType)
                {
                    if (T.TypeOf.ToUpper() == "MUSICAL")
                        CurrentMovie.Base_Audience += Actor.Popularity * 5;
                }
            }
            else
                CurrentMovie.Base_Audience += (Actor.Popularity * 3);

            L_CharsMovies Updater = new L_CharsMovies(Actor.ID, CurrentMovie.ID, strRole);
            int ActionVariance = GetDifferenceFromValues(Actor.Inner_Val, CurrentMovie, "V");            
            int HumorVariance = GetDifferenceFromValues(Actor.Inner_Val, CurrentMovie, "H");            
            int SexVariance = GetDifferenceFromValues(Actor.Inner_Val, CurrentMovie, "S");            
            int Success = ActionVariance + HumorVariance + SexVariance + rndCasuale.Next(-Random, Random);
            #region Special Abilities (Alpha)
            ActionVariance += intBonusAction;
            HumorVariance += intBonusHumor;
            SexVariance += intBonusSexappeal;
            CurrentMovie.Base_Audience += intBonusAudience;
            Success += intBonusSuccess;
            #endregion
            Updater.Performance = Success;
            Updater.Performance_Description = "A: " + ActionVariance.ToString() +
                " - H: " + HumorVariance.ToString() +
                " - S: " + SexVariance.ToString();
            Updater.L_CharsMovies_UpdatePerformance();
            return Success;
        }

        /// <summary>
        /// This method calculate all the value for the film based to the Director, Actors and Composer
        /// performance. Set the Success, Base_Audience of the movie and the Performance of the Characters.
        /// </summary>
        /// <param name="CurrentMovie"></param>
        /// <param name="GenChars"></param>
        /// <param name="Random"></param>
        public static void CalculateFilming(Movie CurrentMovie, GenericCharacters[] GenChars, int Random)
        {
            int Success = CurrentMovie.Success;
            int Coesione = 0;
            int ContaAttori = 0;
            int SuccessAttori = 0;
            foreach (GenericCharacters Charact in GenChars)
            {
                switch (Charact.TypeOf.TypeOf.ToUpper())
                {
                    case "DIRECTOR":
                        Success += CalculateSuccessFromDirector(Charact, CurrentMovie, Random, Charact.TypeOf.TypeOf);
                        break;
                    case "ACTOR":
                        SuccessAttori += CalculateSuccessFromActor(Charact, CurrentMovie, Random, Charact.TypeOf.TypeOf);
                        Coesione += Charact.Skills;
                        ContaAttori++;
                        break;
                    case "ACTRESS":
                        SuccessAttori += CalculateSuccessFromActor(Charact, CurrentMovie, Random, "Actor");
                        Coesione += Charact.Skills;
                        ContaAttori++;
                        break;
                    case "COMPOSER":
                        Success += CalculateSuccessFromComposer(Charact, CurrentMovie, Random, Charact.TypeOf.TypeOf);
                        break;
                }
            }
            if (ContaAttori > 0)
                Success += SuccessAttori / ContaAttori;

            int TSuccess = 0;
            int TAudience = 0;
            int FXSuccess = 0;
            int FXAudience = 0;
            int LSuccess = 0;
            int LAudience = 0;

            int intPercT = 0;
            int intPercFX = 0;
            int intPercL = 0;
            GetPercFromGenre(CurrentMovie, out intPercT, out intPercFX, out intPercL);

            CalculateSuccessFromTheatre(CurrentMovie, intPercT, out TSuccess, out TAudience);
            CalculateSuccessFromSpecialEffect(CurrentMovie, intPercFX, out FXSuccess, out FXAudience);
            CalculateSuccessFromLocations(CurrentMovie, intPercL, out LSuccess, out LAudience);
            Success += TSuccess;
            Success += FXSuccess;
            Success += LSuccess;
            CurrentMovie.Base_Audience += TAudience + FXAudience + LAudience;

            CurrentMovie.Success = Success;
        }

        private static void CalculateSuccessFromLocations(Movie currentMovie, int intPercL, out int lSuccess, out int lAudience)
        {
            lSuccess = 0;
            lAudience = 0;
            
            int[] intLocIDs = Retriever.GetMovieLocations(currentMovie.ID);
            int intS = 0, intA = 0;
            for (int i = 0; i < intLocIDs.Length; i++)
            {
                Location L = new Location(intLocIDs[i]);
                intS += L.SuccessBonus;
                intA += L.AudienceBonus;
            }
            if (intLocIDs.Length > 0)
            {
                lSuccess = intS / intLocIDs.Length * intPercL / 100;
                lAudience = intA / intLocIDs.Length * intPercL / 100;
            }
        }

        private static void CalculateSuccessFromSpecialEffect(Movie currentMovie, int intPercFX, out int fXSuccess, out int fXAudience)
        {
            fXSuccess = 0;
            fXAudience = 0;
            
            fXSuccess = currentMovie.fkFX.SuccessBonus * intPercFX / 100;
            fXAudience = currentMovie.fkFX.AudienceBonus * intPercFX / 100;
        }

        private static void CalculateSuccessFromTheatre(Movie currentMovie, int intPercT, out int Tsuccess, out int Taudience)
        {
            Tsuccess = 0;
            Taudience = 0;            
            Tsuccess = currentMovie.fkTdP.SuccessBonus * intPercT / 100;
            Taudience = currentMovie.fkTdP.AudienceBonus * intPercT / 100;
        }

        private static void GetPercFromGenre(Movie currentMovie, out int intPercT, out int intPercFX, out int intPercL)
        {
            intPercT = 0;
            intPercFX = 0;
            intPercL = 0;
            int Conta = 0;
            foreach (TypeOfMovie ToM in currentMovie.fkType)
            {
                intPercT = ToM.TdP;
                intPercFX = ToM.FX;
                intPercL = ToM.Loc;
                Conta++;
            }
            intPercT /= Conta;
            intPercFX /= Conta;
            intPercL /= Conta;
        }
        #endregion

        #region Launch
        /// <summary>
        /// This method finalize the movie. Save the movie player, characters player, advance characters,
        /// calculate affinity and return the difference between Price and cash.
        /// </summary>
        /// <param name="MyMov"></param>
        /// <returns></returns>
        public static long FinalizeMovie(Movie MyMov)
        {
            #region Movie Player
            LG_MoviePlayer MovPla = new LG_MoviePlayer(MyMov.ID);
            MovPla.Price = GetTotalMovieCost(MyMov);
            int RealAudience = LFMGRule.CalculateRealAudience(MyMov);
            long Cash = LFMGRule.CalculateMoney(RealAudience);
            int Change = LFMGRule.GetPopularityChange(Cash, MovPla.Price);
            MovPla.Cash = Cash;
            MovPla.Change = Change;
            MovPla.RealAudience = RealAudience;
            MovPla.Insert();
            #endregion
            #region Movie Character Player
            GenericCharacters[] Links = Retriever.GetGenericCastFromMovie(MyMov.ID);
            foreach (GenericCharacters Gen in Links)
            {
                // Change the popularity
                LFMGRule.PopularityChange(Gen, Change);
                // Change the Affinity
                LFMGRule.AffinityChange(Gen, Change);
                // Change the Values
                LFMGRule.ActorAdvancement(Gen, MyMov.Inner_Val);
            }
            #endregion
            return Cash - MovPla.Price;
        }
        #endregion

        #region Movie Cost
        public static long GetTotalMovieCost(Movie GenMovie)
        {
            long Price = 0;
            #region Cast Costs
            GenericCharacters[] GenChars = Retriever.GetGenericCastFromMovie(GenMovie.ID);
            foreach (GenericCharacters Charact in GenChars)
            {
                switch (Charact.TypeOf.TypeOf.ToUpper())
                {
                    case "WRITER":
                        long Priw = Calculation.GetCashOfWriter(Charact, GenMovie);
                        LG_CharPlayerAffinity Linkw = new LG_CharPlayerAffinity(Charact.ID);
                        long AffinityChangew = Priw * -Linkw.Affinity / 100;
                        Price += Priw + AffinityChangew;
                        break;
                    case "DIRECTOR":
                        long Prid = Calculation.GetCashOfDirector(Charact, GenMovie);
                        LG_CharPlayerAffinity Linkd = new LG_CharPlayerAffinity(Charact.ID);
                        long AffinityChanged = Prid * -Linkd.Affinity / 100;
                        Price += Prid + AffinityChanged;
                        break;
                    case "ACTOR":
                    case "ACTRESS":
                        long Pri = Calculation.GetCashOfActor(Charact, GenMovie);
                        LG_CharPlayerAffinity Link = new LG_CharPlayerAffinity(Charact.ID);
                        long AffinityChange = Pri * -Link.Affinity / 100;
                        Price += Pri + AffinityChange;
                        break;
                }
            }
            #endregion
            #region Structure Cost
            Price += GetPriceOfTheatre(GenMovie);
            Price += GetPriceOfFX(GenMovie);
            #endregion

            return Price;
        }
        #endregion
        #endregion

        #region Serial
        #region Inizio
        // Crea Serie
        // Seleziona Showrunner che determina i valori della serie
        /// <summary>
        /// This method create the base serial from a showrunner.
        /// This is the only method to create a serial.
        /// </summary>
        /// <param name="Showrunner"></param>
        /// <param name="MovieType"></param>
        /// <returns></returns>
        public static Serial CreateSerialFromShowrunner(GenericCharacters Showrunner, TypeOfMovie[] MovieType, int CurrentAge, out long Price)
        {
            #region SpecialAbilities (Alpha)
            int intBonusAudience = 0;
            int intBonusSuccess = 0;
            int intBonusAction = 0;
            int intBonusHumor = 0;
            int intBonusSexappeal = 0;
            Retriever.GetBonusFromSkills(Showrunner, out intBonusAudience, out intBonusSuccess, out intBonusAction, out intBonusHumor, out intBonusSexappeal);
            #endregion
            Price = 0;
            int Success = 0;
            Serial NewSerial = new Serial();
            NewSerial.Inner_Val = new Inner_Values();
            // TODO - Vedere come usare MainGenre e SubGenre
            TypeOfMovie FinalSerialType = GetUnifiedTypeOfMovie(MovieType, out Success);
            // ALPHA - Set random to 5%
            NewSerial.Inner_Val = CompareWriterSkillToTargetValue(Showrunner.Inner_Val, FinalSerialType, Showrunner.Talent, 5);
            NewSerial.Title = Showrunner.Name + " " + Showrunner.Surname + "'s ";
            NewSerial.Age = CurrentAge;
            NewSerial.Description = "Generic Serial Description for ";
            NewSerial.fkMainType = new TypeOfMovie(MovieType[0].ID);
            NewSerial.fkSubType = new TypeOfMovie(MovieType[1].ID);
            // Originality: add to the Level
            NewSerial.Episodes = 12; // Writer.Skills + Success;
            // Base Audience is the popularity of the Writer
            NewSerial.Base_Audience = Showrunner.Talent + Showrunner.Skills + intBonusAudience;
            foreach (TypeOfMovie ToM in MovieType)
            {
                if (ToM != null)
                {
                    NewSerial.Title += ToM.TypeOf + " ";
                    NewSerial.Description += ToM.TypeOf + " ";
                }
            }
            NewSerial.Status = 12;
            NewSerial.Title += "serial";
            NewSerial.Description += "serial";
            #region Special Abilities (Alpha)
            NewSerial.Inner_Val.Action += intBonusAction;
            NewSerial.Inner_Val.Sexappeal += intBonusSexappeal;
            NewSerial.Inner_Val.Humor += intBonusHumor;
            NewSerial.Base_Audience += intBonusAudience;
            #endregion
            Price = GetCashOfShowrunner(Showrunner);
            NewSerial.WriteOnDb();
            AddCastToSerial(Showrunner, NewSerial, "Showrunner");
            return NewSerial;
        }
        // Seleziona Tdp e FX
        /// <summary>
        /// This method sinply add the Theatre and FX Company to the Serial and save it.
        /// </summary>
        /// <param name="MySerial"></param>
        /// <param name="T"></param>
        /// <param name="F"></param>
        /// <returns></returns>
        public static bool AddTdPandFXToSerial(Serial MySerial, Theatre T, SpecialEffectCompany F)
        {
            MySerial.fkTdP = new Theatre(T.ID);
            MySerial.fkFX = new SpecialEffectCompany(F.ID);
            return MySerial.WriteOnDb();
        }
        // seleziona Cast
        /// <summary>
        /// This method add the selected cast to the serial and set it active.
        /// </summary>
        /// <param name="Cast"></param>
        /// <param name="MySerial"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool AddCastToSerial(GenericCharacters Cast, Serial MySerial, string strName)
        {
            L_CharsSerials Link = new L_CharsSerials(Cast.ID, MySerial.ID, strName);
            Link.Active = 1;
            return Link.InsertDb();
        }

        /// <summary>
        /// This method add the cost of the Showrunner, the cost of the cast and the price of
        /// TdT and FX (TODO add the cost of bonus).
        /// </summary>
        /// <param name="MySerial"></param>
        /// <returns></returns>
        public static long GetSerialTotalCost(Serial MySerial)
        {
            long Cost = 0;
            L_CharsSerials LinkShow = new L_CharsSerials(MySerial.ID, "Showrunner");
            GenericCharacters ShowR = new GenericCharacters(LinkShow.ID_Char);
            Cost += GetCashOfShowrunner(ShowR);
            GenericCharacters[] GenList = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
            foreach (GenericCharacters Gen in GenList)
            {
                if (Gen.TypeOf.TypeOf != "Showrunner")
                    Cost += GetCashOfActor(Gen, MySerial);
            }
            Cost += GetPriceOfTheatre(MySerial) / 2;
            Cost += GetPriceOfFX(MySerial) / 2;
            // TODO - Add the cost of the Bonus used to raise Audience
            return Cost;
        }
        #endregion
        #region Andamento
        // Calcolo audience
        /// <summary>
        ///  This method calcualte the audience of the serie based on the Cast
        /// </summary>
        /// <param name="MySerial"></param>
        /// <returns></returns>
        public static int GetAudienceFromCast(Serial MySerial)
        {
            GenericCharacters[] GenList = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
            int Cast_Audience = 0;
            foreach (GenericCharacters Gen in GenList)
            {
                if (Gen.TypeOf.TypeOf != "Showrunner")
                {
                    Cast_Audience += Gen.Talent + Gen.Skills;
                }
            }
            return Cast_Audience;
        }
        #endregion
        #region Fine Stagione
        // Aumento salario showrunner
        // Aumento inner values cast
        /// <summary>
        /// This method advance each member of the cast.
        /// </summary>
        /// <param name="MySerial"></param>
        public static void CastAdvancmentForSerialSeasonEnd(Serial MySerial)
        {
            GenericCharacters[] GenList = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
            foreach (GenericCharacters Gen in GenList)
            {
                if (Gen.TypeOf.TypeOf != "Showrunner")
                    LFMGRule.ActorAdvancementForSerial(Gen, MySerial.Inner_Val, MySerial.Episodes);
            }
        }
        // Aumento popularity
        /// <summary>
        /// This method add or subtract Popularty and Affinity based on the audience of the Serial
        /// for each member of the cast.
        /// </summary>
        /// <param name="MySerial"></param>
        public static void CastAdvancementPopularityAndAffinityForSerialSeasonEnd(Serial MySerial)
        {
            long FakeGain = MySerial.Base_Audience * 100;
            int Change = LFMGRule.GetPopularityChange(FakeGain, 0);
            GenericCharacters[] GenList = Retriever.GetGenericCastFromSerial(MySerial.ID, 1);
            foreach (GenericCharacters Gen in GenList)
            {
                LFMGRule.PopularityChange(Gen, Change);
                LFMGRule.AffinityChange(Gen, Change);
            }
        }
        // Rimozione Eventuale Cast
        /// <summary>
        /// This method remove a cast member from the serial (ad history it's remove only logically,
        /// i.e. Active = 0) and it lower the affinity with the character by 10%.
        /// </summary>
        /// <param name="Cast"></param>
        /// <param name="MySerial"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool RemoveCastFromSerial(GenericCharacters Cast, Serial MySerial, string strName)
        {
            L_CharsSerials Link = new L_CharsSerials(Cast.ID, MySerial.ID, strName);
            Link.Active = 0;
            LG_CharPlayerAffinity LinkAff = new LG_CharPlayerAffinity(Cast.ID);
            LinkAff.Affinity -= 10;
            LinkAff.Update();
            return Link.InsertDb();
        }
        #endregion
        #endregion
    }
}
