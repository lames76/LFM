using SQLLiteInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    /// <summary>
    /// This is the AgeClass of a character. It have two "special" values: Timelord and Elf.
    /// Timelord means it is not yet born, Elf meand it is older than 100 years.
    /// </summary>
    public enum AgeClass
    {
        NoValue = 0,
        Timelord = 10,
        Child = 1,
        Teen = 2,
        Average = 3,
        Mature = 4,
        Old = 5,
        Elf = 11
    }

    public static class LFMUtils
    {       
        /// <summary>
        /// This method check the current Age (year) with another age (year) and return
        /// the AgeClass (enum).
        /// </summary>
        /// <param name="intCurrentAge"></param>
        /// <param name="intReferralAge"></param>
        /// <returns></returns>
        public static AgeClass GetAgeClassFromDate(int intCurrentAge, int intReferralAge)
        {
            int intAppo = intCurrentAge - intReferralAge;
            if (intAppo < 0)
                return AgeClass.Timelord;
            if (intAppo > 100)
                return AgeClass.Elf;
            if (intAppo < 15)
                return AgeClass.Child;
            if (intAppo < 30)
                return AgeClass.Teen;
            if (intAppo < 45)
                return AgeClass.Average;
            if (intAppo < 70)
                return AgeClass.Mature;
            return AgeClass.Old;
        }

        /// <summary>
        /// Check if the Character is free checking all active Movies and Serials
        /// </summary>
        /// <param name="IDChar"></param>
        /// <returns></returns>
        public static bool CheckIfCharacterIsFree(int IDChar)
        {
            
            int[] MovieList = Retriever.GetMovieInWorking();
            int[] SerialList = Retriever.GetSerialSeasoning();
            List<Movie> MovieCastList = Retriever.GetListOfMovieInWorkingFromCharID(IDChar);
            List<Serial> SerialCastList = Retriever.GetListOfSerialInWorkingFromCharID(IDChar);            
            if (MovieCastList.Count > 0)
                return false;
            if (SerialCastList.Count > 0)
                return false;
            return true;
        }

        #region Game File Utilities
        /// <summary>
        /// This method create a new game, creating the directory and coping the DB if not yet done
        /// and updating the connection string in the file.
        /// </summary>
        /// <param name="strGameName"></param>
        /// <returns></returns>
        public static bool PrepareNewGame(string strGameName)
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string strNewGamepath = strAppPath + "\\" + LFMConst.GameDirPath + strGameName;
            if (!Directory.Exists(strNewGamepath))
            {
                Directory.CreateDirectory(strNewGamepath);
                File.Copy(strAppPath + "\\Db\\LFM.db", strNewGamepath + "\\LFM.db");
            }
            PrepareConnectionString(strGameName);            
            return true;
        }

        /// <summary>
        /// This method prepare the connection string based on the name of the game.
        /// </summary>
        /// <param name="strGameName"></param>
        /// <returns></returns>
        public static bool PrepareConnectionString(string strGameName)
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string strConnectionFileLine = string.Format(LFMConst.ConnStringVal, LFMConst.GameDirPath + strGameName + "\\LFM.db");
            File.WriteAllText(strAppPath + "\\" + LFMConst.ConfigurationFile, strConnectionFileLine);
            return true;
        }

        /// <summary>
        /// Return the text of the connection string inside the configuration file.
        /// </summary>
        /// <returns></returns>
        public static string GetActualConnectionString()
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string ConnString = File.ReadAllText(strAppPath + "\\" + LFMConst.ConfigurationFile);
            return ConnString;
        }

        /// <summary>
        /// Delete the passed game, deleting the folder (and files) and restoring the connection
        /// to the original Db.
        /// </summary>
        /// <param name="strGameName"></param>
        /// <returns></returns>
        public static bool DeleteGame(string strGameName)
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string strNewGamepath = strAppPath + "\\" + LFMConst.GameDirPath + strGameName;
            if (Directory.Exists(strNewGamepath))
            {
                Directory.Delete(strNewGamepath, true);
            }
            return RestoreOriginalDb();
        }

        /// <summary>
        /// Restore the original connection to the original Db.
        /// </summary>
        /// <returns></returns>
        public static bool RestoreOriginalDb()
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string strConnectionFileLine = string.Format(LFMConst.ConnStringVal, "\\Db\\LFM.db");
            File.WriteAllText(strAppPath + "\\" + LFMConst.ConfigurationFile, strConnectionFileLine);
            return true;
        }

        /// <summary>
        /// This method check if there is at least one saved game.
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfGameExist()
        {
            string[] strGames = GetGamesName();
            if (strGames.Length > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method return the list of all the games saved
        /// </summary>
        /// <returns></returns>
        public static string[] GetGamesName()
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string[] strGames = Directory.GetDirectories(strAppPath + "\\" + LFMConst.GameDirPath);
            for (int i=0;i<strGames.Length;i++)
                strGames[i] = strGames[i].Replace(strAppPath + "\\" + LFMConst.GameDirPath,"");
            return strGames;
        }

        /// <summary>
        /// This method "normalize" the input game name removing all the special characters that can
        /// cause problems.
        /// </summary>
        /// <returns></returns>
        public static string NormalizeGameName(string strName)
        {
            string strRetString = strName.Replace(" ","_").Replace("\"","_");
            return strRetString;
        }
        #endregion
    }
}
