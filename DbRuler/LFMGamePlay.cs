using SQLLiteInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    public enum TypeOfObject
    {
        Balance = 0,
        Movie = 1,
        Serial = 2,
        Script = 49,
        Writer = 50,
        Director = 51,
        Showrunner = 52,
        Actor = 60,
        Sport = 61,
        Singer = 62,
        TdP = 70,
        FX = 71
    }

    public class LastCashMovement
    {
        /// <summary>
        /// Target su cui effettuare la somma (-1 per Balance)
        /// </summary>
        public int ID_Target { get; set; }
        /// <summary>
        /// Tipo di Target (0 per Balance)
        /// </summary>
        public TypeOfObject Target { get; set; }
        /// <summary>
        /// ID del movimento
        /// </summary>
        public int ID_Movement { get; set; }
        /// <summary>
        /// Tipo di Movimento
        /// </summary>
        public TypeOfObject TypeOfMovement { get; set; }
        /// <summary>
        /// Valore
        /// </summary>
        public long MovementValue { get; set; }
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public int Week { get; set; } = 0;
    }

    // Nome PG, Nome Studios, Soldi
    // Tabella Bilanci - Riga: Valore (+o-), Tipo, ID

    public static class LFMGamePlay
    {
        /// <summary>
        /// This method return all the movie produced by the player and return a list of ID.
        /// If IsProducing is true it return only the movie actually in production.
        /// </summary>
        /// <param name="IsProducing"></param>
        /// <returns></returns>
        public static List<Movie> GetMoviesOfPlayer(bool IsProducing = false)
        {
            string strCommand = "SELECT DISTINCT ID_Target AS ID FROM LG_CashMovement WHERE Target = " + (int)TypeOfObject.Movie +";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            List<Movie> ListOfMyMovie = new List<Movie>();
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                int intActualMovieID = Convert.ToInt32(tblRet.Rows[i]["ID"]);
                Movie MyMovie = new Movie(intActualMovieID);
                if (IsProducing)
                    if (MyMovie.Status > 0)
                        ListOfMyMovie.Add(MyMovie);
                else
                    ListOfMyMovie.Add(MyMovie);
            }
            return ListOfMyMovie;
        }

        /// <summary>
        /// This method subtract 7 from the status of the movie.
        /// If the status went to 0 or less it set it to 0 and return true.
        /// </summary>
        /// <param name="MyMovie"></param>
        /// <returns></returns>
        public static bool AnotherWeekPassed(Movie MyMovie)
        {
            MyMovie.Status -= 7;
            if (MyMovie.Status <= 0)
            {
                MyMovie.Status = 0;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// This method subtract 7 from the status of the movie.
        /// If the status went to 0 or less it set it to 0 and return true.
        /// </summary>
        /// <param name="MySerial"></param>
        /// <returns></returns>
        public static bool AnotherWeekPassed(Serial MySerial)
        {
            MySerial.Status -= 1;
            if (MySerial.Status <= 0)
            {
                MySerial.Status = 0;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// This method age all character (if blnAging is true) and check if some character die
        /// then generate casually N new character.
        /// Return the list of all the retired.
        /// </summary>
        /// <returns></returns>
        public static List<GenericCharacters> AnotherYearPassed(int Year, bool blnAging, int NewCharNumber = 8)
        {
            List<GenericCharacters> DeadMenWalking = new List<GenericCharacters>();
            GenericCharacters[] GenList = Retriever.GetCharacters();
            if (blnAging)
            {
                for (int i = 0; i < GenList.Length; i++)
                {
                    int Age = Year - GenList[i].Age;
                    // If age > 100 dead 
                    if (Age >= 100)
                    {
                        DeadMenWalking.Add(GenList[i]);
                        GenList[i].SetActive(0);
                    }
                    else
                    {
                        // if age < 10 not yet working
                        if (Age < 10)
                            GenList[i].SetActive(0);
                        // else active
                        else
                            GenList[i].SetActive(1);
                    }
                }
            }
            // Generate new Characters
            int Count = NewCharNumber - 7;
            if (Count < 0)
                Count = NewCharNumber;
            // Generate Actor and Actress
            for (int j = 0; j < Count; j++)
            {
                Random rndCasuale = new Random();
                string strSex = (rndCasuale.Next(-5, 6) > 0 ? "F" : "M");
                TypeOfCharacters typo;
                switch (strSex)
                {
                    case "F": typo = new TypeOfCharacters(4); break;
                    default: typo = new TypeOfCharacters(3); break;
                }
                GenericCharacters G = Creator.CreateNewCharacter(Year, strSex, typo);
            }
            // Generate other kind
            for (int k = 0; k < NewCharNumber - Count; k++)
            {
                Random rndCasuale = new Random();
                string strSex = (rndCasuale.Next(-5, 6) > 0 ? "F" : "M");
                TypeOfCharacters typo2;
                int GotoCount = 0;
                Repeat:
                int intIndex = rndCasuale.Next(1, 9);
                // If is again Actor or Actress repeat random
                if (intIndex == 3 || intIndex == 4)
                {
                    GotoCount++;
                    if (GotoCount < 10)
                        goto Repeat;
                }
                typo2 = new TypeOfCharacters(intIndex);               
                GenericCharacters G = Creator.CreateNewCharacter(Year, strSex, typo2);
            }

            return DeadMenWalking;
        }
    }
}
