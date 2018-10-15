using SQLLiteInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomNameGenerator;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Svg;
using Newtonsoft.Json.Linq;

namespace DbRuler
{
    #region DataLayer


    public class L_CharsSerials
    {
        public int ID { get; set; }
        public int ID_Char { get; set; }
        public int ID_Serial { get; set; }
        public string Char_Name { get; set; }
        public int Active { get; set; }

        public L_CharsSerials()
        {
        }

        public L_CharsSerials(int intID_Char, int intID_Serial)
        {
            ID_Char = intID_Char;
            ID_Serial = intID_Serial;
            Char_Name = "NONE";
            LoadFromDb();
        }

        public L_CharsSerials(int intID_Char, int intID_Serial, string strName)
        {
            ID_Char = intID_Char;
            ID_Serial = intID_Serial;
            Char_Name = strName;
            LoadFromDb(strName);
        }

        public L_CharsSerials(int intIDSerial, string strName)
        {
            ID_Serial = intIDSerial;
            Char_Name = strName;
            if (!LoadFromDB(intIDSerial, strName))
            {
                ID_Char = -1;
            }
        }

        #region Load and Write Data
        public bool LoadFromDB(int intIDSerial, string strNome)
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsSerials WHERE ID_Serial = " + intIDSerial + " AND Char_Name = '" + strNome + "' AND Active = 1;");
            if (tblRet.Rows.Count > 0)
            {
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                ID_Char = Convert.ToInt32(tblRet.Rows[0]["ID_Char"]);
                Active = Convert.ToInt32( tblRet.Rows[0]["Active"]);
                return true;
            }
            return false;
        }

        public void LoadFromDb()
        {
            string strCommand = "SELECT * FROM L_CharsSerials";
            strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Serial = " + ID_Serial.ToString() + "; ";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                Char_Name = tblRet.Rows[0]["Char_Name"].ToString();
                Active = Convert.ToInt32(tblRet.Rows[0]["Active"]);
            }
        }

        private void LoadFromDb(string strName)
        {
            string strCommand = "SELECT * FROM L_CharsMovies";
            strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Movie = " + ID_Serial.ToString() + " AND Char_Name = '" + strName + "'; ";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                Active = Convert.ToInt32(tblRet.Rows[0]["Active"]);
            }
            else
                Active = 1;
        }

        public bool UpdateActive(int ActiveValue)
        {
            string strCommand = string.Format("UPDATE L_CharsSerials SET Active = {3}" +
                " WHERE ID_Char = {0} AND ID_Serial = {1} AND Char_Name = '{2}'; ", ID_Char, ID_Serial, Char_Name, ActiveValue);
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool InsertDb()
        {
            if ((ID_Char > 0) && (ID_Serial > 0))
            {
                string strCommand = "SELECT * FROM L_CharsSerials";
                strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Serial = " + ID_Serial.ToString() + " AND Char_Name = '" + Char_Name + "'; ";
                DataTable tblRet = SQLLiteInt.Select(strCommand);
                if (tblRet.Rows.Count == 0)
                {
                    strCommand = string.Empty;
                    strCommand = "INSERT INTO L_CharsSerials ";
                    strCommand += "(Char_Name,Active,ID_Char,ID_Serial) ";
                    strCommand += " VALUES ( ";
                    strCommand += "'" + Char_Name + "',";
                    strCommand += Active.ToString() + ",";
                    strCommand += ID_Char.ToString() + ",";
                    strCommand += ID_Serial.ToString() + ");";
                    return SQLLiteInt.GenericCommand(strCommand);
                }
            }
            return false;
        }
        
        public bool L_CharsMovies_Delete()
        {
            string strCommand = string.Empty;
            strCommand = "DELETE FROM L_CharsSerials ";
            strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Serial = " + ID_Serial.ToString() + " AND Char_Name = '" + Char_Name + "';";
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion
    }

    public class Serial
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public TypeOfMovie fkMainType { get; set; }
        public TypeOfMovie fkSubType { get; set; }
        public int fkUniverse { get; set; }
        public Universes Universe { get; set; }
        public Inner_Values Inner_Val { get; set; }
        public int Episodes { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Age { get; set; }
        public int Base_Audience { get; set; }
        public string ImDB_Link { get; set; }
        public Theatre fkTdP { get; set; }
        public SpecialEffectCompany fkFX { get; set; }

        public Serial()
        {
            ID = 0;
        }

        public Serial(int intID)
        {
            ID = intID;
            LoadFromDb();
        }

        #region Load and Write Data
        public void LoadFromDb()
        {
            string strCommand = "SELECT * FROM Serials";
            strCommand += " WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                Inner_Val = new Inner_Values();
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                Inner_Val.Action = Convert.ToInt32(tblRet.Rows[0]["Action"]);
                Description = tblRet.Rows[0]["Description"].ToString();
                fkMainType = new TypeOfMovie(Convert.ToInt32(tblRet.Rows[0]["fkMainType"]));
                fkSubType = new TypeOfMovie(Convert.ToInt32(tblRet.Rows[0]["fkSubType"]));
                Inner_Val.Humor = Convert.ToInt32(tblRet.Rows[0]["Humor"]);
                Episodes = Convert.ToInt32(tblRet.Rows[0]["Episodes"]);
                Inner_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["Sex"]);
                Status = Convert.ToInt32(tblRet.Rows[0]["Status"]);
                Title = tblRet.Rows[0]["Title"].ToString();
                Age = Convert.ToInt32(tblRet.Rows[0]["Age"]);
                fkUniverse = Convert.ToInt32(tblRet.Rows[0]["fkUniverse"]);
                if (fkUniverse > 0)
                    Universe = new Universes(fkUniverse);
                Base_Audience = Convert.ToInt32(tblRet.Rows[0]["Base_Audience"]);
                ImDB_Link = tblRet.Rows[0]["ImDB_Link"].ToString();
                Theatre T = new Theatre(Convert.ToInt32(tblRet.Rows[0]["fkTdP"]));
                fkTdP = T;
                SpecialEffectCompany FX = new SpecialEffectCompany(Convert.ToInt32(tblRet.Rows[0]["fkFX"]));
                fkFX = FX;
            }
        }

        public bool WriteOnDb()
        {
            string strCommand = string.Empty;
            if (ID > 0)
            {
                strCommand = "UPDATE Serials SET ";
                strCommand += " Description = '" + Description.Replace("'", "''") + "',";
                strCommand += " Title = '" + Title.Replace("'", "''") + "',";
                strCommand += " ImDB_Link = '" + ImDB_Link + "',";
                strCommand += " fkMainType = " + fkMainType.ID.ToString() + ",";
                strCommand += " fkSubType = " + fkSubType.ID.ToString() + ",";
                strCommand += " Sex = " + Inner_Val.Sexappeal.ToString() + ",";
                strCommand += " Action = " + Inner_Val.Action.ToString() + ",";
                strCommand += " Episodes = " + Episodes.ToString() + ",";
                strCommand += " Humor = " + Inner_Val.Humor.ToString() + ",";
                strCommand += " Status = " + Status.ToString() + ",";
                strCommand += " Age = " + Age.ToString() + ",";
                strCommand += " Base_Audience = '" + Base_Audience + "',";
                strCommand += " fkUniverse = " + fkUniverse.ToString();
                if (fkTdP != null)
                    strCommand += ", fkTdP = " + fkTdP.ID.ToString();
                if (fkFX != null)
                    strCommand += ", fkFX = " + fkFX.ID.ToString();
                strCommand += " WHERE ID = " + ID.ToString() + ";";
            }
            else
            {
                strCommand = "INSERT INTO Serials ";
                strCommand += "(Title,Description,ImDB_Link,Sex,Action,Humor,Episodes,Status,Age,fkTdP,fkFX,fkUniverse,fkMainType,fkSubType) ";
                strCommand += " VALUES ( ";
                strCommand += "'" + Title.Replace("'", "''") + "',";
                strCommand += "'" + Description.Replace("'", "''") + "',";
                strCommand += "'" + ImDB_Link + "',";
                strCommand += Inner_Val.Sexappeal + ",";
                strCommand += Inner_Val.Action.ToString() + ",";
                strCommand += Inner_Val.Humor.ToString() + ",";
                strCommand += Episodes.ToString() + ",";
                strCommand += Status.ToString() + ",";
                strCommand += Age.ToString() + ",";
                if (fkTdP != null)
                    strCommand += fkTdP.ID.ToString() + ",";
                else
                    strCommand += "-1,";
                if (fkFX != null)
                    strCommand += fkFX.ID.ToString() + ",";
                else
                    strCommand += "-1,";
                strCommand += fkUniverse.ToString() + ",";
                strCommand += fkMainType.ID.ToString() + ",";
                strCommand += fkSubType.ID.ToString() + ");";
            }
            bool blnResult = SQLLiteInt.GenericCommand(strCommand);
            if (ID == 0)
            {
                ID = Retriever.GetMaxSerialID();
            }
            return blnResult;
        }
        #endregion
        #region Delete
        public bool Delete()
        {
            string strCommand = "DELETE FROM Serials WHERE ID = " + ID.ToString() + ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion
        public long Price(LG_CashMovement bank)
        {
            List<LastCashMovement> Bal = (from m in bank.Movement
                                          where m.ID_Target == ID
                                          select m).ToList();
            long Price = 0;
            foreach (LastCashMovement L in Bal)
                Price += L.MovementValue;
            return Price;
        }
    }

    public class Universes
    {
        public int ID { get; set; }
        public string Name { get; set; }

        #region Constructor
        public Universes()
        {
            Name = "";
            ID = -1;
            LoadValues();
        }

        public Universes(int intID)
        {
            ID = intID;
            Name = "";
            LoadValues();
        }

        public Universes(string strName)
        {
            Name = strName;
            ID = -1;
            LoadValues();
        }
        #endregion

        private void LoadValues()
        {
            bool blnIsWhere = false;
            string strCommand = "SELECT * FROM Universes ";
            if (ID > 0)
            {
                strCommand += " WHERE ID = " + ID.ToString();
            }
            if (Name.Length > 0)
            {
                if (!blnIsWhere)
                {
                    strCommand += " WHERE ";
                }
                else
                    strCommand += " AND ";
                strCommand += " Name = '" + Name + "'";
            }
            strCommand += ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Name = tblRet.Rows[0]["Name"].ToString();
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
            }
        }

        public bool Save()
        {
            string strCommand = "";
            // Update
            if (ID > 0)
            {                
                strCommand += "UPDATE Universes SET Name = '" + Name + " WHERE ID = " + ID.ToString() + ";";
            }
            // Insert
            else
            {
                strCommand += "INSERT INTO Universes (Name) VALUES ('" + Name + "');";
            }
            bool blnRet = SQLLiteInt.GenericCommand(strCommand);
            ID = GetMaxID();
            return blnRet;
        }

        private int GetMaxID()
        {
            string strCommand = "SELECT MAX(ID) AS Mx FROM Universes;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                return Convert.ToInt32(tblRet.Rows[0]["Mx"]);
            }
            else
                return -1;
        }
    }

    public class Theatre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SuccessBonus { get; set; }
        public int  AudienceBonus { get; set; }

        public Theatre(int intID)
        {
            ID = intID;
            Theatre_LoadFromDb();
        }

        private void Theatre_LoadFromDb()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE ID = " + ID.ToString() + " AND Type = 'T';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Name = tblRet.Rows[0]["Name"].ToString();
                Description = tblRet.Rows[0]["Description"].ToString();
                SuccessBonus = Convert.ToInt32(tblRet.Rows[0]["SuccessBonus"]);
                AudienceBonus = Convert.ToInt32(tblRet.Rows[0]["AudienceBonus"]);
            }
        }
    }

    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SuccessBonus { get; set; }
        public int AudienceBonus { get; set; }

        public Location(int intIDLocation)
        {
            ID = intIDLocation;
            Location_LoadFromDb();
        }

        private void Location_LoadFromDb()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE ID = " + ID.ToString() + " AND Type = 'L';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Name = tblRet.Rows[0]["Name"].ToString();
                Description = tblRet.Rows[0]["Description"].ToString();
                SuccessBonus = Convert.ToInt32(tblRet.Rows[0]["SuccessBonus"]);
                AudienceBonus = Convert.ToInt32(tblRet.Rows[0]["AudienceBonus"]);
            }
        }
    }

    public class SpecialEffectCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int SuccessBonus { get; set; }
        public int AudienceBonus { get; set; }

        public SpecialEffectCompany(int intID)
        {
            ID = intID;
            SpecialEffectCompany_LoadFromDb();
        }

        private void SpecialEffectCompany_LoadFromDb()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE ID = " + ID.ToString() + " AND Type = 'S';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Name = tblRet.Rows[0]["Name"].ToString();
                Description = tblRet.Rows[0]["Description"].ToString();
                SuccessBonus = Convert.ToInt32(tblRet.Rows[0]["SuccessBonus"]);
                AudienceBonus = Convert.ToInt32(tblRet.Rows[0]["AudienceBonus"]);
            }
        }
    }

    public class Inner_Values
    {
        public int Action { get; set; }
        public int Sexappeal { get; set; }
        public int Humor { get; set; }
        public Inner_Values()
        {
            Action = 0;
            Humor = 0;
            Sexappeal = 0;
        }
    }
    public class CharImages
    {
        public int IDChar { get; set; }
        public byte[] Image { get; set; }       
        public AgeClass AgeValue { get; set; }

        /// <summary>
        /// ID is Char_ID
        /// </summary>
        /// <param name="ID"></param>
        public CharImages(int ID)
        {
            IDChar = ID;
            CharImages_LoadFromDb();
        }

        /// <summary>
        /// ID is Char_ID
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="acAgeValue"></param>
        public CharImages(int ID, AgeClass acAgeValue)
        {
            IDChar = ID;
            AgeValue = acAgeValue;
            CharImages_LoadFromDb();
        }


        public CharImages()
        {
            IDChar = 0;
        }

        #region Load and Write Data
        public void CharImages_LoadFromDb()
        {
            string strCommand = "SELECT Image FROM CharImages WHERE IDChar = " + IDChar.ToString();
            strCommand += " AND AgeValue = " + (int)AgeValue;
            strCommand += ";";
            byte[] MyImage;
            SQLLiteInt.SelectBynary(strCommand, out MyImage);
            Image = MyImage;
        }

        public bool CharImages_UpdateImage()
        {
            string strCommand = "";
            strCommand += "UPDATE CharImages SET Image = @0 WHERE IDChar = " + IDChar.ToString();
            strCommand += " AND AgeValue = " + (int)AgeValue;
            strCommand += ";";
            return SQLLiteInt.GenericCommandBynary(strCommand, Image);
        }

        public bool CharImages_DeleteImage()
        {
            string strCommand = "";
            strCommand += "DELETE FROM CharImages WHERE IDChar = " + IDChar.ToString();
            strCommand += " AND AgeValue = " + (int)AgeValue;
            strCommand += ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool CharImages_Create()
        {
            string strCommand = "";
            strCommand += "INSERT INTO CharImages (IDChar,Image,AgeValue) VALUES (" + IDChar.ToString() +"," +
                 "@0," + (int)AgeValue + ");";
            return SQLLiteInt.GenericCommandBynary(strCommand, Image);
        }
        #endregion
    }
    public class L_CharsMovies
    {
        public int ID { get; set; }
        public int ID_Char { get; set; }
        public int ID_Movie { get; set; }
        public string Char_Name { get; set; }
        public int Performance { get; set; }
        public string Performance_Description { get; set; }

        public L_CharsMovies()
        {
            Performance = -1;
            Performance_Description = "NONE";
            Char_Name = "NONE";         
        }

        public L_CharsMovies(int intID_Char, int intID_Movie)
        {
            ID_Char = intID_Char;
            ID_Movie = intID_Movie;
            Performance = -1;
            Performance_Description = "NONE";
            Char_Name = "NONE";
            L_CharsMovies_LoadFromDb();
        }

        public L_CharsMovies(int intID_Char, int intID_Movie, string strRole)
        {
            ID_Char = intID_Char;
            ID_Movie = intID_Movie;
            Performance = -1;
            Performance_Description = "NONE";
            Char_Name = strRole;
            L_CharsMovies_LoadFromDb(strRole);
        }

        public L_CharsMovies(int intIDMovie, string strRole)
        {
            ID_Movie = intIDMovie;
            Char_Name = strRole;
            if (!L_CharsMovies_LoadFromDB(intIDMovie, strRole))
            {
                ID_Char = -1;
                Performance = -1;
                Performance_Description = "NONE";
            }
        }        

        #region Load and Write Data
        public bool L_CharsMovies_LoadFromDB(int intIDMovie, string strRole)
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + intIDMovie + " AND Char_Name = '" + strRole + "';");
            if (tblRet.Rows.Count > 0)
            {
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                ID_Char = Convert.ToInt32(tblRet.Rows[0]["ID_Char"]);
                Performance = Convert.ToInt32(tblRet.Rows[0]["Performance"]);
                Performance_Description = tblRet.Rows[0]["Performance_Description"].ToString();
                return true;
            }
            return false;
        }

        public void L_CharsMovies_LoadFromDb()
        {
            string strCommand = "SELECT * FROM L_CharsMovies";
            strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Movie = " + ID_Movie.ToString() + "; ";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                ID = Convert.ToInt32(tblRet.Rows[i]["ID"]);
                Char_Name = tblRet.Rows[i]["Char_Name"].ToString();
                Performance = Convert.ToInt32(tblRet.Rows[i]["Performance"]);
                Performance_Description = tblRet.Rows[i]["Performance_Description"].ToString();
            }
        }

        private void L_CharsMovies_LoadFromDb(string strRole)
        {
            string strCommand = "SELECT * FROM L_CharsMovies";
            strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Movie = " + ID_Movie.ToString() + " AND Char_Name = '" + Char_Name + "'; ";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                ID = Convert.ToInt32(tblRet.Rows[i]["ID"]);
                Performance = Convert.ToInt32(tblRet.Rows[i]["Performance"]);
                Performance_Description = tblRet.Rows[i]["Performance_Description"].ToString();
            }
        }

        public bool L_CharsMovies_InsertDb()
        {
            if ((ID_Char > 0) && (ID_Movie > 0))
            {
                string strCommand = "SELECT * FROM L_CharsMovies";
                strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Movie = " + ID_Movie.ToString() + " AND Char_Name = '" + Char_Name + "'; ";
                DataTable tblRet = SQLLiteInt.Select(strCommand);
                if (tblRet.Rows.Count == 0)
                {
                    strCommand = string.Empty;
                    strCommand = "INSERT INTO L_CharsMovies ";
                    strCommand += "(Char_Name,Performance,ID_Char,ID_Movie,Performance_Description) ";
                    strCommand += " VALUES ( ";
                    strCommand += "'" + Char_Name + "',";
                    strCommand += Performance.ToString() + ",";
                    strCommand += ID_Char.ToString() + ",";
                    strCommand += ID_Movie.ToString() + ",";
                    strCommand += "'" + Performance_Description.ToString() + "');";
                    return SQLLiteInt.GenericCommand(strCommand);
                }
            }
            return false;
        }

        public bool L_CharsMovies_UpdatePerformance()
        {            
            if ((ID_Char > 0) && (ID_Movie > 0) && (Char_Name.Length > 0))
            {
                string strCommand = string.Empty;
                strCommand = "UPDATE L_CharsMovies SET ";
                strCommand += " Performance = " + Performance.ToString() + ", Performance_Description = '" + Performance_Description + "' ";
                strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Movie = " + ID_Movie.ToString() + " AND Char_Name = '" + Char_Name  + "';";
                return SQLLiteInt.GenericCommand(strCommand);
            }         
            return false;
        }

        public bool L_CharsMovies_Delete()
        {
            string strCommand = string.Empty;
            strCommand = "DELETE FROM L_CharsMovies ";
            strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Movie = " + ID_Movie.ToString() + " AND Char_Name = '" + Char_Name + "';";
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion
    }

    public class L_CharsAbilities
    {
        public int ID_Char { get; set; }
        public int ID_Ability { get; set; }        

        public L_CharsAbilities(int intID_Char, int intID_Ability)
        {
            ID_Char = intID_Char;
            ID_Ability = intID_Ability;
        }

        #region Load and Write Data        
        public bool L_CharsAbilities_InsertDb()
        {
            string strCommand = string.Empty;
            strCommand = "INSERT INTO L_CharsAbilities ";
            strCommand += "(ID_Char,ID_Ability) ";
            strCommand += " VALUES ( ";
            strCommand += ID_Char.ToString() + ",";
            strCommand += ID_Ability.ToString() + ");";
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool L_CharsAbilities_Delete()
        {
            string strCommand = string.Empty;
            if (ID_Ability > -1)
            {
                strCommand = "DELETE FROM L_CharsAbilities ";
                strCommand += " WHERE ID_Char = " + ID_Char.ToString() + " AND ID_Ability = " + ID_Ability.ToString() + ";";
            }
            else
            {
                strCommand = "DELETE FROM L_CharsAbilities ";
                strCommand += " WHERE ID_Char = " + ID_Char.ToString() + ";";
            }
            return SQLLiteInt.GenericCommand(strCommand);

        }
        #endregion
    }

    public class L_MovieType
    {
        public int ID_Movie { get; set; }
        public int ID_Type { get; set; }

        public L_MovieType(int intID_Movie, int intID_Type)
        {
            ID_Movie = intID_Movie;
            ID_Type = intID_Type;
        }

        #region Load and Write Data        
        public bool L_MovieType_InsertDb()
        {
            string strCommand = string.Empty;
            strCommand = "INSERT INTO L_MovieType ";
            strCommand += "(ID_Movie,ID_Type) ";
            strCommand += " VALUES ( ";
            strCommand += ID_Movie.ToString() + ",";
            strCommand += ID_Type.ToString() + ");";
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool L_MovieType_Delete()
        {
            string strCommand = string.Empty;
            if (ID_Type > -1)
            {
                strCommand = "DELETE FROM L_MovieType ";
                strCommand += " WHERE ID_Movie = " + ID_Movie.ToString() + " AND ID_Type = " + ID_Type.ToString() + ";";
            }
            else
            {
                strCommand = "DELETE FROM L_MovieType ";
                strCommand += " WHERE ID_Movie = " + ID_Movie.ToString() + ";";
            }
            return SQLLiteInt.GenericCommand(strCommand);

        }
        #endregion
    }

    public class L_MovieLocation
    {
        public int ID_Movie { get; set; }
        public int ID_Location{ get; set; }

        public L_MovieLocation(int intID_Movie, int intID_Location)
        {
            ID_Movie = intID_Movie;
            ID_Location = intID_Location;
        }

        #region Load and Write Data        
        public bool L_MovieLocation_InsertDb()
        {
            string strCommand = string.Empty;
            strCommand = "INSERT INTO L_MovieLocation ";
            strCommand += "(ID_Movie,ID_Location) ";
            strCommand += " VALUES ( ";
            strCommand += ID_Movie.ToString() + ",";
            strCommand += ID_Location.ToString() + ");";
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool L_MovieLocation_Delete()
        {
            string strCommand = string.Empty;
            if (ID_Location > -1)
            {
                strCommand = "DELETE FROM L_MovieLocation ";
                strCommand += " WHERE ID_Movie = " + ID_Movie.ToString() + " AND ID_Location = " + ID_Location.ToString() + ";";
            }
            else
            {
                strCommand = "DELETE FROM L_MovieLocation ";
                strCommand += " WHERE ID_Movie = " + ID_Movie.ToString() + ";";
            }
            return SQLLiteInt.GenericCommand(strCommand);

        }
        #endregion
    }

    public class SpecialAbilities
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Icon { get; set; }
        public Inner_Values In_Val { get; set; }
        public int Audience { get; set; }
        public int Success { get; set; }
        public TypeOfCharacters TypeOf { get; set; }

        public SpecialAbilities(int intID)
        {
            ID = intID;
            SpecialAbilities_LoadFromDB();
        }

        private bool SpecialAbilities_LoadFromDB()
        {
            string strCommand = "SELECT * FROM SpecialAbilities WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Audience = Convert.ToInt32(tblRet.Rows[0]["Audience"]);
                Success = Convert.ToInt32(tblRet.Rows[0]["Success"]);
                Name = tblRet.Rows[0]["Name"].ToString();
                Description = tblRet.Rows[0]["Description"].ToString();
                In_Val = new Inner_Values();
                In_Val.Action = Convert.ToInt32(tblRet.Rows[0]["Action"]);
                In_Val.Humor = Convert.ToInt32(tblRet.Rows[0]["Humor"]);
                In_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["Sexappeal"]);
                TypeOf = new TypeOfCharacters(Convert.ToInt32(tblRet.Rows[0]["TypeOf"]));
                //byte[] MyImage;
                //strCommand = "SELECT Icon FROM SpecialAbilities WHERE ID = " + ID.ToString() + ";";
                //SQLLiteInt.SelectBynary(strCommand, out MyImage);
                //Icon = MyImage;
                return true;
            }
            return false;
        }
    }

    public class TypeOfLevel
    {
        public int ID { get; set; }
        public string Level { get; set; }
        public decimal Multiplier { get; set; }

        public TypeOfLevel(int intID)
        {
            ID = intID;
            TypeOfLevel_LoadFromDb();
        }

        #region Load and Write Data
        private void TypeOfLevel_LoadFromDb()
        {
            string strCommand = "SELECT * FROM Level WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                Level = tblRet.Rows[0]["Level"].ToString();
                Multiplier = Convert.ToDecimal(tblRet.Rows[0]["Multiplier"]);
            }
        }
        #endregion
    }
    public class TypeOfCharacters
    {
        public int ID { get; set; }
        public string TypeOf { get; set; }
        /// <summary>
        /// "1"	"Writer"
        /// "2"	"Director"
        /// "3"	"Actor"
        /// "4"	"Actress"
        /// "5"	"Composer"
        /// "6"	"Sport Star"
        /// "7"	"Singer"
        /// "8"	"Showrunner"
        /// </summary>
        /// <param name="intID"></param>
        public TypeOfCharacters(int intID)
        {
            ID = intID;
            TypeOfCharacters_LoadFromDb();
        }

        #region Load and Write Data
        private void TypeOfCharacters_LoadFromDb()
        {
            string strCommand = "SELECT * FROM TypeOfCharacter";
            strCommand += " WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
                TypeOf = tblRet.Rows[0]["TypeOf"].ToString();
        }
        #endregion
    }
    public class TypeOfMovie
    {
        public int ID { get; set; }
        public string TypeOf { get; set; }
        public Inner_Values Inner_Val_Max { get; set; }
        public Inner_Values Inner_Val_Min { get; set; }
        public int T { get; set; }
        public int Pre_Production { get; set; }
        public int Filming { get; set; }
        public int Post_Production { get; set; }
        public int TdP { get; set; }
        public int Loc { get; set; }
        public int FX { get; set; }

        public int GetTotalProductionTime()
        {
            return Pre_Production + Filming + Post_Production;
        }

        public string GetActualStatusFromTime(int Time)
        {
            string strStatus = string.Empty;
            if (Time <= Pre_Production)
                strStatus = "Pre-Production";
            if (Time <= Pre_Production + Filming)
                strStatus = "Filming";
            if (Time <= Pre_Production + Filming + Post_Production)
                strStatus = "Post-Production";
            if (Time > Pre_Production + Filming + Post_Production)
                strStatus = "Produced";
            return strStatus;
        }

        public TypeOfMovie(int intID)
        {
            ID = intID;
            TypeOfMovie_LoadFromDb();
        }
        #region Load and Write Data
        private void TypeOfMovie_LoadFromDb()
        {
            string strCommand = "SELECT * FROM TypeOfMovie WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                Inner_Val_Max = new Inner_Values();
                Inner_Val_Min = new Inner_Values();
                TypeOf = tblRet.Rows[0]["TypeOf"].ToString();
                Inner_Val_Min.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["S"]);
                Inner_Val_Min.Humor = Convert.ToInt32(tblRet.Rows[0]["H"]);
                Inner_Val_Min.Action = Convert.ToInt32(tblRet.Rows[0]["V"]);
                Inner_Val_Max.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["SM"]);
                Inner_Val_Max.Humor = Convert.ToInt32(tblRet.Rows[0]["HM"]);
                Inner_Val_Max.Action = Convert.ToInt32(tblRet.Rows[0]["VM"]);
                T = Convert.ToInt32(tblRet.Rows[0]["T"]);
                Pre_Production = Convert.ToInt32(tblRet.Rows[0]["Pre_Production"]);
                Filming = Convert.ToInt32(tblRet.Rows[0]["Filming"]);
                Post_Production = Convert.ToInt32(tblRet.Rows[0]["Post_Production"]);
                TdP = Convert.ToInt32(tblRet.Rows[0]["TdP"]);
                Loc = Convert.ToInt32(tblRet.Rows[0]["Loc"]);
                FX = Convert.ToInt32(tblRet.Rows[0]["FX"]);
            }
        }
        #endregion
    }
    public class GenericCharacters
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public TypeOfCharacters TypeOf { get; set; }
        public int ImageLink { get; set; }
        public string Sex { get; set; }
        public int Skills { get; set; }
        public Inner_Values Inner_Val { get; set; }
        public int Popularity { get; set; }
        public int Talent { get; set; }
        public int Age { get; set; }
        public int Films { get; set; }
        public string ImDB_Link { get; set; }
        public int Active { get; set; }

        public GenericCharacters(int intID)
        {
            ID = intID;
            GenericCharacters_LoadFromDb();
        }

        public GenericCharacters()
        {
            ID = 0;
        }

        #region Load and Write Data
        private void GenericCharacters_LoadFromDb()
        {
            string strCommand = "SELECT * FROM GenericCharacter";
            strCommand += " WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Inner_Val = new Inner_Values();
                Inner_Val.Action = Convert.ToInt32(tblRet.Rows[0]["Action"]);
                Age = Convert.ToInt32(tblRet.Rows[0]["Age"]);
                Inner_Val.Humor = Convert.ToInt32(tblRet.Rows[0]["Humor"]);
                Name = tblRet.Rows[0]["Name"].ToString();
                Popularity = Convert.ToInt32(tblRet.Rows[0]["Popularity"]);
                Sex = tblRet.Rows[0]["Sex"].ToString();
                Inner_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["Sexappeal"]);
                Skills = Convert.ToInt32(tblRet.Rows[0]["Skill"]);
                Surname = tblRet.Rows[0]["Surname"].ToString();
                Talent = Convert.ToInt32(tblRet.Rows[0]["Talent"]);
                TypeOfCharacters typo = new TypeOfCharacters(Convert.ToInt32(tblRet.Rows[0]["fkTypeOf"]));
                TypeOf = typo;
                ImDB_Link = tblRet.Rows[0]["ImDB_Link"].ToString();
                Active = Convert.ToInt32(tblRet.Rows[0]["Active"]);
            }
            else
                Active = 1;
        }

        public bool GenericCharacters_WriteOnDb()
        {
            string strCommand = string.Empty;
            if (ID > 0)
            {
                strCommand = "UPDATE GenericCharacter SET ";
                strCommand += " Name = '" + Name + "',";
                strCommand += " Surname = '" + Surname + "',";
                strCommand += " Sex = '" + Sex + "',";
                strCommand += " ImDB_Link = '" + ImDB_Link + "',";
                strCommand += " fkTypeOf = " + TypeOf.ID.ToString() + ",";
                strCommand += " Skill = " + Skills.ToString() + ",";
                strCommand += " Action = " + Inner_Val.Action.ToString() + ",";
                strCommand += " Sexappeal = " + Inner_Val.Sexappeal.ToString() + ",";
                strCommand += " Humor = " + Inner_Val.Humor.ToString() + ",";
                strCommand += " Popularity = " + Popularity.ToString() + ",";
                strCommand += " Talent = " + Talent.ToString() + ",";
                strCommand += " Active = " + Active.ToString() + ",";
                strCommand += " Age = " + Age.ToString();
                strCommand += " WHERE ID = " + ID.ToString() + ";";
            }
            else
            {
                strCommand = "INSERT INTO GenericCharacter ";
                strCommand += "(Name,Surname,ImDB_Link,Sex,fkTypeOf,Skill,Action,Sexappeal,Humor,Popularity,Talent,Active,Age) ";
                strCommand += " VALUES ( ";
                strCommand += "'" + Name + "',";
                strCommand += "'" + Surname + "',";
                strCommand += "'" + ImDB_Link + "',";
                strCommand += "'" + Sex + "',";
                strCommand += TypeOf.ID.ToString() + ",";
                strCommand += Skills.ToString() + ",";
                strCommand += Inner_Val.Action.ToString() + ",";
                strCommand += Inner_Val.Sexappeal.ToString() + ",";
                strCommand += Inner_Val.Humor.ToString() + ",";
                strCommand += Popularity.ToString() + ",";
                strCommand += Talent.ToString() + ",";
                strCommand += Active.ToString() + ",";
                strCommand += Age.ToString() + ");";
            }
            bool blnResult = SQLLiteInt.GenericCommand(strCommand);
            if (ID == 0)
                ID = Retriever.GetMaxCharacterID();
            return blnResult;
        }

        public bool GenericCharacters_DeleteFromDb()
        {
            bool blnResult = false;
            string strCommand = string.Empty;
            if (ID > 0)
            {
                strCommand = "DELETE FROM GenericCharacter ";
                strCommand += " WHERE ID = " + ID.ToString() + ";";

                blnResult = SQLLiteInt.GenericCommand(strCommand);
            }
            return blnResult;
        }
        #endregion

        public void SetActive(int intValue)
        {
            Active = intValue;
            GenericCharacters_WriteOnDb();
        }
    }
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public TypeOfMovie[] fkType { get; set; }
        public Location[] fkLocations { get; set; }
        public TypeOfMovie fkType1 { get; set; }
        public int fkUniverse { get; set; }
        public Universes Universe { get; set; }
        public Inner_Values Inner_Val { get; set; }
        public int Success { get; set; }
        public string Description { get; set; }
        public string Citation { get; set; }
        public int Status { get; set; }
        public int Age { get; set; }
        public int Base_Audience { get; set; }
        public string ImDB_Link { get; set; }
        public Theatre fkTdP { get; set; }
        public SpecialEffectCompany fkFX { get; set; }
        private int Pre_Production { get; set; } = 0;
        private int Filming { get; set; } = 0;
        private int Post_Production { get; set; } = 0;

        public Movie()
        {
            ID = 0;
        }

        public Movie(int intID)
        {
            ID = intID;
            Movie_LoadFromDb();
        }

        #region Load and Write Data
        public void Movie_LoadFromDb()
        {
            string strCommand = "SELECT * FROM Movie";            
            strCommand += " WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                Inner_Val = new Inner_Values();
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                Inner_Val.Action = Convert.ToInt32(tblRet.Rows[0]["Action"]);
                Description = tblRet.Rows[0]["Description"].ToString();
                int[] typos = Retriever.GetMovieTypes(ID, false);
                fkType = new TypeOfMovie[typos.Length];
                for (int i = 0; i < typos.Length; i++)
                {
                    fkType[i] = new TypeOfMovie(typos[i]);
                }
                int[] Loc = Retriever.GetMovieLocations(ID);
                fkLocations = new Location[Loc.Length];
                for (int i = 0; i < Loc.Length; i++)
                {
                    fkLocations[i] = new Location(Loc[i]);
                }
                TypeOfMovie typo = new TypeOfMovie(Convert.ToInt32(tblRet.Rows[0]["fkType"]));
                fkType1 = typo;
                Inner_Val.Humor = Convert.ToInt32(tblRet.Rows[0]["Humor"]);           
                Success = Convert.ToInt32(tblRet.Rows[0]["Success"]);
                Inner_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["Sex"]);
                Status = Convert.ToInt32(tblRet.Rows[0]["Status"]);
                Title = tblRet.Rows[0]["Title"].ToString();
                Age = Convert.ToInt32(tblRet.Rows[0]["Age"]);
                Citation = tblRet.Rows[0]["Citation"].ToString();
                fkUniverse = Convert.ToInt32(tblRet.Rows[0]["fkUniverse"]);
                if (fkUniverse > 0)
                    Universe = new Universes(fkUniverse);
                Base_Audience = Convert.ToInt32(tblRet.Rows[0]["Base_Audience"]);
                ImDB_Link = tblRet.Rows[0]["ImDB_Link"].ToString();
                Theatre T = new Theatre(Convert.ToInt32(tblRet.Rows[0]["fkTdP"]));
                fkTdP = T;
                SpecialEffectCompany FX = new SpecialEffectCompany(Convert.ToInt32(tblRet.Rows[0]["fkFX"]));
                fkFX = FX;
            }
        }

        public bool Movie_WriteOnDb()
        {
            string strCommand = string.Empty;
            if (ID > 0)
            {
                strCommand = "UPDATE Movie SET ";
                strCommand += " Description = '" + Description.Replace("'", "''") + "',";
                strCommand += " Title = '" + Title.Replace("'", "''") + "',";
                strCommand += " ImDB_Link = '" + ImDB_Link + "',";
                strCommand += " Sex = " + Inner_Val.Sexappeal.ToString() + ",";
                strCommand += " Action = " + Inner_Val.Action.ToString() + ",";
                strCommand += " Success = " + Success.ToString() + ",";
                strCommand += " Humor = " + Inner_Val.Humor.ToString() + ",";
                strCommand += " Status = " + Status.ToString() + ",";
                strCommand += " Age = " + Age.ToString() + ",";
                strCommand += " Citation = '" + Citation.Replace("'", "''") + "',";
                strCommand += " Base_Audience = '" + Base_Audience + "',";
                strCommand += " fkUniverse = " + fkUniverse.ToString();
                if (fkTdP != null)
                    strCommand += ", fkTdP = " + fkTdP.ID.ToString();
                if (fkFX != null)
                    strCommand += ", fkFX = " + fkFX.ID.ToString();
                strCommand += " WHERE ID = " + ID.ToString() + ";";
            }
            else
            {
                strCommand = "INSERT INTO Movie ";
                strCommand += "(Title,Description,ImDB_Link,Sex,Action,Humor,Success,Status,Age,Citation,fkTdP,fkFX,fkUniverse) ";
                strCommand += " VALUES ( ";
                strCommand += "'" + Title.Replace("'", "''") + "',";
                strCommand += "'" + Description.Replace("'","''") + "',";
                strCommand += "'" + ImDB_Link + "',";
                strCommand += Inner_Val.Sexappeal + ",";
                strCommand += Inner_Val.Action.ToString() + ",";
                strCommand += Inner_Val.Humor.ToString() + ",";
                strCommand += Success.ToString() + ",";
                strCommand += Status.ToString() + ",";
                strCommand += Age.ToString() + ",'" + Citation.Replace("'", "''") + "',";
                if (fkTdP != null)
                    strCommand += fkTdP.ID.ToString() + ",";
                else
                    strCommand += "-1,";
                if (fkFX != null)
                    strCommand += fkFX.ID.ToString() + ",";
                else
                    strCommand += "-1,";
                strCommand += fkUniverse.ToString() + ");";
            }
            bool blnResult = SQLLiteInt.GenericCommand(strCommand);
            if (ID == 0)
            {
                ID = Retriever.GetMaxMovieID();
                AddGenreToMovie();
                AddLocationToMovie();
            }
            else
            {
                UpdateGenreOfMovie();
                UpdateLocationOfMovie();
            }
            GetTotalProductionTime();
            return blnResult;
        }

        #region Genre and Location
        private void UpdateGenreOfMovie()
        {
            int[] ActualGenre = Retriever.GetMovieTypes(ID, true);
            for (int i = 0; i < fkType.Length; i++)
            {
                if (fkType[i] != null)
                    if (!ActualGenre.Contains(fkType[i].ID))
                    {
                        L_MovieType L = new L_MovieType(ID, fkType[i].ID);
                        L.L_MovieType_InsertDb();
                    }
            }
        }

        private void UpdateLocationOfMovie()
        {
            int[] ActualLocation = Retriever.GetMovieLocations(ID);
            for (int i = 0; i < ActualLocation.Length; i++)
            {
                if (!ActualLocation.Contains(fkLocations[i].ID))
                {
                    L_MovieLocation L = new L_MovieLocation(ID, fkLocations[i].ID);
                    L.L_MovieLocation_InsertDb();
                }
            }
        }

        private void AddGenreToMovie()
        {
            for (int i = 0; i < fkType.Length; i++)
            {
                if (fkType[i] != null)
                {
                    L_MovieType L = new L_MovieType(ID, fkType[i].ID);
                    L.L_MovieType_InsertDb();
                }
            }
        }

        private void AddLocationToMovie()
        {
            if (fkLocations != null)
            for (int i = 0; i < fkLocations.Length; i++)
            {
                L_MovieLocation L = new L_MovieLocation(ID, fkLocations[i].ID);
                L.L_MovieLocation_InsertDb();
            }
        }
        #endregion
        #endregion
        #region Delete
        public bool Delete()
        {
            string strCommand = "DELETE FROM Movie WHERE ID = " + ID.ToString() + ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion

        public int GetTotalProductionTime()
        {            
            foreach (TypeOfMovie Typ in fkType)
            {
                if (Typ != null)
                {
                    if (Typ.Pre_Production > Pre_Production)
                        Pre_Production = Typ.Pre_Production;
                    if (Typ.Filming > Filming)
                        Filming = Typ.Filming;
                    if (Typ.Post_Production > Post_Production)
                        Post_Production = Typ.Post_Production;
                }
            }
            return Pre_Production + Filming + Post_Production;
        }

        public string GetActualStatusFromTime(int Time)
        {
            if (Pre_Production == 0)
                GetTotalProductionTime();
            string strStatus = string.Empty;
            if (Time <= Pre_Production)
                strStatus = "Pre-Production";
            if (Time <= Pre_Production + Filming)
                strStatus = "Filming";
            if (Time <= Pre_Production + Filming + Post_Production)
                strStatus = "Post-Production";
            if (Time > Pre_Production + Filming + Post_Production)
                strStatus = "Produced";
            return strStatus;
        }

        public string GetActualStatusFromStatus()
        {
            int Time = GetTotalProductionTime() - Status;
            string strStatus = string.Empty;
            if (Time <= Pre_Production)
                strStatus = "Pre-Production";
            if (Time <= Pre_Production + Filming)
                strStatus = "Filming";
            if (Time <= Pre_Production + Filming + Post_Production)
                strStatus = "Post-Production";
            if (Time > Pre_Production + Filming + Post_Production)
                strStatus = "Produced";
            return strStatus;
        }

        public long Price(LG_CashMovement bank)
        {
            List<LastCashMovement> Bal = (from m in bank.Movement
                                          where m.ID_Target == ID
                                          select m).ToList();
            long Price = 0;
            foreach (LastCashMovement L in Bal)
                Price += L.MovementValue;
            return Price;
        }
    }

    public class Script
    {        
        public int ID { get; set; }
        public string Title { get; set; }
        public int fkType { get; set; }
        public Inner_Values Inner_Val { get; set; }        
        public TypeOfLevel Level { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Cost { get; set; }

        public Script()
        {
            ID = 0;
        }

        public Script(int intID)
        {
            ID = intID;
            Script_LoadFromDb();
        }

        #region Load and Write Data
        public void Script_LoadFromDb()
        {
            string strCommand = "SELECT * FROM Script";
            strCommand += " WHERE ID = " + ID.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count == 1)
            {
                Inner_Val = new Inner_Values();
                ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                Inner_Val.Action = Convert.ToInt32(tblRet.Rows[0]["Action"]);
                Description = tblRet.Rows[0]["Description"].ToString();
                fkType = Convert.ToInt32(tblRet.Rows[0]["fkTypeOf"]);
                Inner_Val.Humor = Convert.ToInt32(tblRet.Rows[0]["Humor"]);
                TypeOfLevel NewLev = new TypeOfLevel(Convert.ToInt32(tblRet.Rows[0]["Level"]));
                Level = NewLev;
                Inner_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[0]["Sex"]);
                Status = Convert.ToInt32(tblRet.Rows[0]["Status"]);
                Title = tblRet.Rows[0]["Title"].ToString();
                Cost = Convert.ToInt32(tblRet.Rows[0]["Costo"]);                
            }
        }

        public bool Script_WriteOnDb(Script MaS)
        {
            string strCommand = string.Empty;
            if (MaS.ID > 0)
            {
                strCommand = "UPDATE Script SET ";
                strCommand += " Description = '" + MaS.Description + "',";
                strCommand += " Title = '" + MaS.Title + "',";
                strCommand += " Sex = " + MaS.Inner_Val.Sexappeal.ToString() + ",";
                strCommand += " fkTypeOf = " + MaS.fkType.ToString() + ",";
                strCommand += " Action = " + MaS.Inner_Val.Action.ToString() + ",";
                strCommand += " Level = " + MaS.Level.ID.ToString() + ",";
                strCommand += " Humor = " + MaS.Inner_Val.Humor.ToString() + ",";
                strCommand += " Status = " + MaS.Status.ToString() + ",";
                strCommand += " Cost = " + MaS.Cost.ToString();
                strCommand += " WHERE ID = " + MaS.ID.ToString() + ";";
            }
            else
            {
                strCommand = "INSERT INTO Script ";
                strCommand += "(Title,Description,Sex,fkTypeOf,Action,Humor,Level,Status,Cost) ";
                strCommand += " VALUES ( ";
                strCommand += "'" + MaS.Title + "',";
                strCommand += "'" + MaS.Description + "',";
                strCommand += MaS.Inner_Val.Sexappeal + ",";
                strCommand += MaS.fkType.ToString() + ",";
                strCommand += MaS.Inner_Val.Action.ToString() + ",";
                strCommand += MaS.Inner_Val.Humor.ToString() + ",";
                strCommand += MaS.Level.ID.ToString() + ",";
                strCommand += MaS.Status.ToString() + ",";
                strCommand += MaS.Cost.ToString()  + ");";
            }
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion

        #region Delete Script
        public bool MoviesAndScripts_DeleteScript()
        {
            string strCommand = "DELETE FROM Script WHERE ID = " + ID.ToString() + ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion
    }
    public class Current_Game_Values
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        #region Load and Write Game Data
        public Current_Game_Values MoviesAndScripts_LoadFromDb(int intID = 0, string strName = "")
        {
            Current_Game_Values CurrentGame = new Current_Game_Values();

            string strCommand = "SELECT * FROM Current_Game_Values";
            if (intID > 0)
                strCommand += " WHERE ID = " + ID.ToString() + ";";
            if (strName.Length > 0)
                strCommand += " WHERE Name = '" + strName + "';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {                
                CurrentGame.ID = Convert.ToInt32(tblRet.Rows[0]["ID"]);
                CurrentGame.Age = Convert.ToInt32(tblRet.Rows[0]["Age"]);
                CurrentGame.Name = tblRet.Rows[0]["Name"].ToString();
            }       
            return CurrentGame;
        }

        public bool Current_Game_Values_Save(Current_Game_Values CurrentGame)
        {
            string strCommand = string.Empty;
            if (CurrentGame.ID > 0)
            {
                strCommand = "UPDATE Current_Game_Values SET ";
                strCommand += " Name = '" + CurrentGame.Name + "',";
                strCommand += " Age = " + CurrentGame.Age.ToString();
                strCommand += " WHERE ID = " + CurrentGame.ID.ToString() + ";";
            }
            else
            {
                strCommand = "INSERT INTO Current_Game_Values ";
                strCommand += "(Age,Name) ";
                strCommand += " VALUES ( ";
                strCommand += CurrentGame.Age.ToString() + ",";
                strCommand += "'" + CurrentGame.Name + "');";
            }
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion

        #region Delete Game
        public bool Current_Game_Values_DeleteGame(int ID)
        {
            string strCommand = "DELETE FROM Current_Game_Values WHERE ID = " + ID.ToString() + ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }
        #endregion
    }
    #endregion

    #region Game Tables

    public class LG_RandomEventClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isBonus { get; set; }
        public long Value { get; set; }

        public LG_RandomEventClass(int intID)
        {
            ID = intID;
            LoadValue();
        }

        private void LoadValue()
        {
            string strCommand = string.Format("SELECT * FROM LG_RandomEvent WHERE ID = {0};", ID);
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Name = tblRet.Rows[0]["Name"].ToString();
                Description = tblRet.Rows[0]["Description"].ToString();
                isBonus = Convert.ToInt32(tblRet.Rows[0]["isBonus"]) == 1 ? true : false;
                Value = Convert.ToInt32(tblRet.Rows[0]["Value"]);
            }
        }

        public bool AddEvent()
        {
            string strCommand = string.Format("INSERT INTO LG_RandomEvent (Name, Description, Value, isBonus) " +
                " VALUES ('{0}','{1}',{2},{3});",
                Name, Description, Value, (isBonus ? 1 : 0));
            return SQLLiteInt.GenericCommand(strCommand);
        }
    }

    public class LG_CharPlayerAffinity
    {
        public int IDChar { get; set; }
        public int Affinity { get; set; }
        public int NumberOfMovies { get; set; }

        /// <summary>
        /// Set the IDChar index
        /// </summary>
        /// <param name="ID"></param>
        public LG_CharPlayerAffinity(int ID)
        {
            IDChar = ID;
            Load();
        }

        private void Load()
        {
            string strCommand = "SELECT * FROM LG_CharPlayerAffinity WHERE IDChar = " + IDChar.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Affinity = Convert.ToInt32(tblRet.Rows[0]["Affinity"]);
                NumberOfMovies = Convert.ToInt32(tblRet.Rows[0]["NumberOfMovies"]);
            }
            else
            {
                Affinity = 0;
                NumberOfMovies = 0;
            }
        }

        public bool Update()
        {
            if (Affinity > 90)
                Affinity = 90;
            string  strCommand = "UPDATE LG_CharPlayerAffinity SET Affinity = " + Affinity.ToString() +
                ", NumberOfMovies = " + NumberOfMovies.ToString() + " WHERE IDChar = " +
                IDChar.ToString() + ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool Insert()
        {
            if (Affinity > 90)
                Affinity = 90;
            string strCommand = "INSERT INTO LG_CharPlayerAffinity (IDChar,Affinity,NumberOfMovies) VALUES (" +
                    IDChar.ToString() + "," + Affinity.ToString() + "," + NumberOfMovies.ToString() + ");";
            return SQLLiteInt.GenericCommand(strCommand);
        }
    }

    public class LG_MoviePlayer
    {
        public int IDMovie { get; set; }
        public long Price { get; set; }
        public int RealAudience { get; set; }
        public long Cash { get; set; }
        public int Change { get; set; }

        public LG_MoviePlayer(int ID)
        {
            IDMovie = ID;
            Load();
        }

        private void Load()
        {
            string strCommand = "SELECT * FROM LG_MoviePlayer WHERE IDMovie = " + IDMovie.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Price = Convert.ToInt32(tblRet.Rows[0]["Price"]);
                RealAudience = Convert.ToInt32(tblRet.Rows[0]["RealAudience"]);
                Cash = Convert.ToInt32(tblRet.Rows[0]["Cash"]);
                Change = Convert.ToInt32(tblRet.Rows[0]["Change"]);
            }
            else
            {
                Price = 0;
                RealAudience = 0;
                Cash = 0;
                Change = 0;
            }
        }

        public bool Update()
        {
            string strCommand = "UPDATE LG_MoviePlayer SET Price = " + Price.ToString() +
                " RealAudience = " + RealAudience.ToString() +
                " Cash = " + Cash.ToString() +
                " Change = " + Change.ToString() +
                " WHERE IDMovie = " +
                IDMovie.ToString() + ";";
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool Insert()
        {
            string strCommand = "INSERT INTO LG_MoviePlayer (IDMovie,Price,RealAudience,Cash,Change) VALUES (" +
                    IDMovie.ToString() + "," + Price.ToString() + "," + RealAudience.ToString() +
                    Cash.ToString() + "," + Change.ToString() + ");";
            return SQLLiteInt.GenericCommand(strCommand);
        }
    }

    public class LG_CashMovement
    {
        public List<LastCashMovement> Movement { get; }

        public LG_CashMovement()
        {
            string strCommand = "SELECT * FROM LG_CashMovement ORDER BY Year, Month, Week ASC;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Movement = new List<LastCashMovement>();
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                LastCashMovement LCM = new LastCashMovement();
                LCM.ID_Movement = Convert.ToInt32(tblRet.Rows[i]["ID_Movement"]);
                LCM.ID_Target = Convert.ToInt32(tblRet.Rows[i]["ID_Target"]);                
                LCM.MovementValue = Convert.ToInt64(tblRet.Rows[i]["MovementValue"]);
                LCM.Target = (TypeOfObject)Convert.ToInt32(tblRet.Rows[i]["Target"]);
                LCM.TypeOfMovement = (TypeOfObject)Convert.ToInt32(tblRet.Rows[i]["TypeOfMovement"]);
                LCM.Week = Convert.ToInt32(tblRet.Rows[i]["Week"]);
                LCM.Month = Convert.ToInt32(tblRet.Rows[i]["Month"]);
                LCM.Year = Convert.ToInt32(tblRet.Rows[i]["Year"]);
                Movement.Add(LCM);
            }
        }

        public bool AddLine(LastCashMovement Line)
        {
            Movement.Add(Line);
            return InsertInDb(Line);
        }

        public bool AddLineBulk(List<LastCashMovement> Lines)
        {
            bool blnRes = false;
            foreach (LastCashMovement Line in Lines)
            {
                blnRes = AddLine(Line);
            }
            return blnRes;
        }

        private bool InsertInDb(LastCashMovement line)
        {
            string strCommand = string.Format("INSERT INTO LG_CashMovement " +
                "(ID_Movement,ID_Target,MovementValue,Target,TypeOfMovement,Week,Month,Year)" +
                " VALUES ({0},{1},{2},{3},{4},{5},{6},{7});", line.ID_Movement,line.ID_Target,line.MovementValue,
                (int)line.Target,(int)line.TypeOfMovement,line.Week,line.Month,line.Year);
            return SQLLiteInt.GenericCommand(strCommand);

        }

        public long Balance()
        {
            List<LastCashMovement> Bal = (from m in Movement
                                          where m.ID_Target == -1
                                          select m).ToList();
            long RetVal = 0;
            foreach (LastCashMovement lcm in Bal)
            {
                RetVal += lcm.MovementValue;
            }
            return RetVal;
        }
    }

    public class LG_MainGameData
    {
        public string SaveGameDir { get; set; }
        public string Name { get; set; }
        public string StudiosName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public bool AgingOn { get; set; }

        public LG_MainGameData(string strGameName)
        {
            SaveGameDir = strGameName;
            LoadData();
        }

        private void LoadData()
        {
            string strCommand = string.Format("SELECT * FROM LG_MainGameData WHERE SaveGameDir = '{0}';", SaveGameDir);
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                Name = tblRet.Rows[0]["Name"].ToString();
                StudiosName = tblRet.Rows[0]["StudiosName"].ToString();
                Year = Convert.ToInt32(tblRet.Rows[0]["Year"]);
                Month = Convert.ToInt32(tblRet.Rows[0]["Month"]);
                Week = Convert.ToInt32(tblRet.Rows[0]["Week"]);
                AgingOn = (Convert.ToInt32(tblRet.Rows[0]["AgingOn"]) == 1 ? true : false);
            }
        }

        public bool InsertInDb()
        {
            string strCommand = string.Format("INSERT INTO LG_MainGameData " +
                " (SaveGameDir,Name,StudiosName,Year,Month,Week,AgingOn) " +
                " VALUES ('{0}','{1}','{2}',{3},{4},{5},{6});", SaveGameDir, Name, StudiosName, Year, Month, Week, (AgingOn ? 1 : 0));
            return SQLLiteInt.GenericCommand(strCommand);
        }

        public bool UpdateDb()
        {
            string strCommand = string.Format("UPDATE LG_MainGameData " +
                " SET Name = '{0}', StudiosName = '{1}', Year = {2}, Month = {3}, Week = {4} " +
                " WHERE SaveGameDir ='{5}';", Name, StudiosName, Year, Month, Week, SaveGameDir);
            return SQLLiteInt.GenericCommand(strCommand);
        }
    }
    #endregion

    /* ************************************************************************************************** */
    /* ************************************************************************************************** */
    /* ************************************************************************************************** */
    /* ************************************************************************************************** */
    /* ************************************************************************************************** */
    /* ************************************************************************************************** */
    /* ************************************************************************************************** */

    public static class Retriever
    {
        #region Games
        public static LG_CharPlayerAffinity[] GetWhoPlaysForMe()
        {
            string strCommand = "SELECT * FROM LG_CharPlayerAffinity;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            LG_CharPlayerAffinity[] MyChars = new LG_CharPlayerAffinity[tblRet.Rows.Count];
            for (int i=0;i<tblRet.Rows.Count;i++)
            {
                LG_CharPlayerAffinity MyChar = new LG_CharPlayerAffinity(Convert.ToInt32(tblRet.Rows[i]["IDChar"]));
                MyChars[i] = MyChar;
            }
            return MyChars;
        }

        public static List<GenericCharacters> GetWhoPlayForMeInThePast(TypeOfCharacters type1 = null, TypeOfCharacters type2 = null)
        {
            List<GenericCharacters> ListGen = new List<GenericCharacters>();
            LG_CharPlayerAffinity[] ListArray = GetWhoPlaysForMe();
            for (int i = 0; i < ListArray.Length; i++)
            {
                GenericCharacters Gen = new GenericCharacters(ListArray[i].IDChar);
                if (type1 != null)
                {
                    if (type2 != null)
                    {
                        if ((Gen != null) && ((type1.ID == Gen.TypeOf.ID) || (type2.ID == Gen.TypeOf.ID)))
                            ListGen.Add(Gen);
                    }
                    else
                        if ((Gen != null) && (type1.ID == Gen.TypeOf.ID))
                        ListGen.Add(Gen);
                }
                else
                    ListGen.Add(Gen);
            }
            return ListGen;
        }
        #endregion

        #region Universes
        public static Universes[] GetUniverses()
        {
            string strCommand = "SELECT * FROM Universes;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Universes[] UniverseList = new Universes[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                UniverseList[i] = new Universes(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return UniverseList;
        }

        public static Universes[] GetUniverseFromName(string strName)
        {
            string strCommand = "SELECT * FROM Universes WHERE Name LIKE '%" + strName + "%';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Universes[] UniverseList = new Universes[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                UniverseList[i] = new Universes(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return UniverseList;
        }
        #endregion

        #region Structures
        public static Theatre[] GetTheatreList()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE Type = 'T';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Theatre[] Theatres = new Theatre[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Theatres[i] = new Theatre(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Theatres;
        }

        public static DataTable GetTheatreListTable()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE Type = 'T';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);            
            return tblRet;
        }

        public static SpecialEffectCompany[] GetFXCompanyList()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE Type = 'S';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            SpecialEffectCompany[] SpecialEffectCompanies = new SpecialEffectCompany[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                SpecialEffectCompanies[i] = new SpecialEffectCompany(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return SpecialEffectCompanies;
        }

        public static DataTable GetFXCompanyListTable()
        {
            string strCommand = "SELECT * FROM GenericStructure WHERE Type = 'S';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            return tblRet;
        }

        public static int[] GetMovieLocations(int intIDMovie)
        {
            string strCommand = "SELECT S.ID FROM Location as L INNER JOIN L_MovieLocation AS A ON A.ID_Location = L.ID  WHERE L.ID_Movie = " + intIDMovie.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            int[] TypeOfs = new int[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                TypeOfs[i] = Convert.ToInt32(tblRet.Rows[i]["ID"]);
            }
            return TypeOfs;
        }
        #endregion

        #region Movies

        public static int[] GetMovieInWorking()
        {
            string strCommand = "SELECT ID Movie WHERE Status > 0;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            int[] intListOfMovie = new int[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                intListOfMovie[i] = Convert.ToInt32(tblRet.Rows[i]["ID"]);
            }
            return intListOfMovie;
        }

        public static int[] GetMovieTypes(int intIDMovie, bool IsFalse)
        {
            string strCommand = "SELECT S.ID FROM TypeOfMovie as S INNER JOIN L_MovieType AS A ON A.ID_Type = S.ID  WHERE A.ID_Movie = " + intIDMovie.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            int[] TypeOfs = new int[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                TypeOfs[i] = Convert.ToInt32(tblRet.Rows[i]["ID"]);
            }
            return TypeOfs;
        }

        public static TypeOfMovie[] GetMovieTypes(int intIDMovie)
        {
            string strCommand = "SELECT S.ID FROM TypeOfMovie as S INNER JOIN L_MovieType AS A ON A.ID_Type = S.ID  WHERE A.ID_Movie = " + intIDMovie.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            TypeOfMovie[] TypeOfs = new TypeOfMovie[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                TypeOfs[i] = new TypeOfMovie(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return TypeOfs;
        }

        public static Movie[] GetMovies()
        {
            string strCommand = "SELECT * FROM Movie;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Movie[] MoviesOrScripts = new Movie[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                MoviesOrScripts[i] = new Movie(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return MoviesOrScripts;
        }

        public static Movie[] GetMoviesFromTitleLike(string strTitle)
        {
            string strCommand = "SELECT * FROM Movie WHERE Title LIKE '%" + strTitle.Replace("'", "''") + "%';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Movie[] MoviesOrScripts = new Movie[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
               MoviesOrScripts[i] = new Movie(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return MoviesOrScripts;
        }

        public static Movie[] GetMoviesFromPeopleID(int IDChar, bool isDisplay)
        {
            string strCommand = "SELECT M.*, L.Char_Name FROM Movie AS M";
            strCommand += " INNER JOIN L_CharsMovies AS L ON L.ID_Movie = M.ID ";
            strCommand += " WHERE L.ID_Char = " + IDChar.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Movie[] MoviesOrScripts = new Movie[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                MoviesOrScripts[i] = new Movie(Convert.ToInt32(tblRet.Rows[i]["ID"]));
                if (isDisplay)
                    MoviesOrScripts[i].Citation = tblRet.Rows[i]["Char_Name"].ToString();
            }
            return MoviesOrScripts;
        }

        public static Movie[] GetMoviesFromUniverse(int IDUniverse, bool isDisplay)
        {
            string strCommand = "SELECT * FROM Movie";
            strCommand += " WHERE fkUniverse = " + IDUniverse.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Movie[] MoviesOrScripts = new Movie[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                MoviesOrScripts[i] = new Movie(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return MoviesOrScripts;
        }

        public static TypeOfMovie[] GetTypeOfMovies(bool blnAddBlanckValue = false)
        {
            string strCommand = "SELECT * FROM TypeOfMovie;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            int intAddValue = 0;
            if (blnAddBlanckValue) intAddValue = 1;
            TypeOfMovie[] TypeOf = new TypeOfMovie[tblRet.Rows.Count + intAddValue];
            if (blnAddBlanckValue)
            {
                TypeOf[0] = new TypeOfMovie(-1);
                TypeOf[0].ID = -1;
                TypeOf[0].TypeOf = "";
            }
            for (int i = intAddValue; i < tblRet.Rows.Count; i++)
            {
                TypeOf[i] = new TypeOfMovie(Convert.ToInt32(tblRet.Rows[i]["ID"]));
                TypeOf[i].Inner_Val_Max = new Inner_Values();
                TypeOf[i].Inner_Val_Min = new Inner_Values();
                TypeOf[i].ID = Convert.ToInt32(tblRet.Rows[i]["ID"]);
                TypeOf[i].TypeOf = tblRet.Rows[i]["TypeOf"].ToString();
                TypeOf[i].Inner_Val_Min.Sexappeal = Convert.ToInt32(tblRet.Rows[i]["S"]);
                TypeOf[i].Inner_Val_Min.Humor = Convert.ToInt32(tblRet.Rows[i]["H"]);
                TypeOf[i].Inner_Val_Min.Action = Convert.ToInt32(tblRet.Rows[i]["V"]);
                TypeOf[i].Inner_Val_Max.Sexappeal = Convert.ToInt32(tblRet.Rows[i]["SM"]);
                TypeOf[i].Inner_Val_Max.Humor = Convert.ToInt32(tblRet.Rows[i]["HM"]);
                TypeOf[i].Inner_Val_Max.Action = Convert.ToInt32(tblRet.Rows[i]["VM"]);
                TypeOf[i].T = Convert.ToInt32(tblRet.Rows[i]["T"]);
                TypeOf[i].Pre_Production = Convert.ToInt32(tblRet.Rows[i]["Pre_Production"]);
                TypeOf[i].Filming = Convert.ToInt32(tblRet.Rows[i]["Filming"]);
                TypeOf[i].Post_Production = Convert.ToInt32(tblRet.Rows[i]["Post_Production"]);
            }
            return TypeOf;
        }

        public static DataTable GetTypeOfMoviesTable(bool blnAddBlanckValue = false)
        {
            string strCommand = "SELECT * FROM TypeOfMovie;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (blnAddBlanckValue)
            {
                DataRow dr = tblRet.NewRow();
                dr["ID"] = -1;
                dr["TypeOf"] = "";
                tblRet.Rows.InsertAt(dr, 0);
            }
            return tblRet;
        }

        public static int GetMaxMovieID()
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT MAX(ID) FROM Movie;");
            return Convert.ToInt32(tblRet.Rows[0][0]);
        }

        #endregion

        #region Serials
        public static Serial[] GetSerials()
        {
            string strCommand = "SELECT * FROM Serial;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Serial[] Serials = new Serial[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Serials[i] = new Serial(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Serials;
        }

        public static Serial[] GetSerialsFromTitleLike(string strTitle)
        {
            string strCommand = "SELECT * FROM Serials WHERE Title LIKE '%" + strTitle.Replace("'", "''") + "%';";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Serial[] Serials = new Serial[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Serials[i] = new Serial(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Serials;
        }


        public static int[] GetSerialSeasoning()
        {
            string strCommand = "SELECT ID FROM Serials WHERE Status > 0;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            int[] intListOfMovie = new int[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                intListOfMovie[i] = Convert.ToInt32(tblRet.Rows[i]["ID"]);
            }
            return intListOfMovie;
        }

        public static int GetMaxSerialID()
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT MAX(ID) FROM Serials;");
            return Convert.ToInt32(tblRet.Rows[0][0]);
        }

        /// <summary>
        /// This method return all the cast (link) for the serial that are currentice Active (1 or 0)
        /// and that are not Showrunner
        /// </summary>
        /// <param name="SerialID"></param>
        /// <param name="Active"></param>
        /// <returns></returns>
        public static L_CharsSerials[] GetCastFromSerial(int SerialID, int Active)
        {
            L_CharsSerials Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsSerials WHERE ID_Serial = " + SerialID + " AND Char_Name <> 'Showrunner' AND Active = " + Active.ToString() + ";");
            L_CharsSerials[] Links = new L_CharsSerials[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new L_CharsSerials();
                Link.ID_Char = Convert.ToInt32(tblRet.Rows[i]["ID_Char"]);
                Link.ID_Serial = Convert.ToInt32(tblRet.Rows[i]["ID_Serial"]);
                Link.Char_Name = tblRet.Rows[i]["Char_Name"].ToString();
                Link.Active = Active;
                Links[i] = Link;
            }
            return Links;
        }

        public static GenericCharacters[] GetGenericCastFromSerial(int SerialID, int Active)
        {

            GenericCharacters Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsSerials WHERE ID_Serial = " + SerialID + " AND Active = " + Active.ToString() + " ORDER BY Char_Name DESC;");
            GenericCharacters[] Links = new GenericCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]));                
                Links[i] = Link;
            }
            return Links;
        }
        public static List<GenericCharacters> GetGenericCastFromSerial_List(int SerialID, int Active)
        {

            GenericCharacters Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsSerials WHERE ID_Serial = " + SerialID + " AND Active = " + Active.ToString() + " ORDER BY Char_Name DESC;");
            List<GenericCharacters> Links = new List<GenericCharacters>();
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]));
                Links.Add(Link);
            }
            return Links;
        }


        #endregion

        #region Special Abilities
        public static SpecialAbilities[] GetSpecialAbilitiesList()
        {            
            string strCommand = "SELECT ID FROM SpecialAbilities;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            SpecialAbilities[] Specials = new SpecialAbilities[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {                
                Specials[i] = new SpecialAbilities(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Specials;
        }

        public static SpecialAbilities[] GetSpecialAbilitiesListVByType(int intType)
        {
            string strCommand = "SELECT ID FROM SpecialAbilities WHERE TypeOf = " + intType.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            SpecialAbilities[] Specials = new SpecialAbilities[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Specials[i] = new SpecialAbilities(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Specials;
        }

        public static SpecialAbilities[] GetSpecialAbilitiesListByIDChar(int intIDChar)
        {
            string strCommand = "SELECT S.ID FROM SpecialAbilities as S INNER JOIN L_CharsAbilities AS A ON A.ID_Ability = S.ID  WHERE A.ID_Char = " + intIDChar.ToString() + ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            SpecialAbilities[] Specials = new SpecialAbilities[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Specials[i] = new SpecialAbilities(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Specials;
        }
        #endregion

        #region Characters
        public static List<Movie> GetListOfMovieInWorkingFromCharID(int IDChar, int StatusValue = 0)
        {
            string strCommand = string.Format("SELECT * " +
                "FROM Movie AS M " +
                "INNER JOIN L_CharsMovies AS L ON L.ID_Movie = M.ID " +
                "WHERE M.Status > {1} AND L.ID_Char = {0};", IDChar, StatusValue);
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            List<Movie> MovieList = new List<Movie>();
            for (int i = 0; i < tblRet.Rows.Count; i++)
                MovieList.Add(new Movie(Convert.ToInt32(tblRet.Rows[i]["ID"])));
            return MovieList;
        }
        public static List<Serial> GetListOfSerialInWorkingFromCharID(int IDChar, int StatusValue = 0)
        {
            string strCommand = string.Format("SELECT * " +
                "FROM Serials AS M " +
                "INNER JOIN L_CharsSerials AS L ON L.ID_Movie = M.ID " +
                "WHERE M.Status > {1} AND L.ID_Char = {0};", IDChar, StatusValue);
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            List<Serial> SerialList = new List<Serial>();
            for (int i = 0; i < tblRet.Rows.Count; i++)
                SerialList.Add(new Serial(Convert.ToInt32(tblRet.Rows[i]["ID"])));
            return SerialList;
        }
        #endregion

        public static Script[] GetScripts()
        {
            string strCommand = "SELECT * FROM Script";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            Script[] MoviesOrScripts = new Script[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                MoviesOrScripts[i].Inner_Val = new Inner_Values();
                MoviesOrScripts[i].ID = Convert.ToInt32(tblRet.Rows[i]["ID"]);
                MoviesOrScripts[i].Inner_Val.Action = Convert.ToInt32(tblRet.Rows[i]["Action"]);
                MoviesOrScripts[i].Description = tblRet.Rows[i]["Description"].ToString();
                MoviesOrScripts[i].fkType = Convert.ToInt32(tblRet.Rows[i]["fkTypeOf"]);
                MoviesOrScripts[i].Inner_Val.Humor = Convert.ToInt32(tblRet.Rows[i]["Humor"]);
                TypeOfLevel NewLev = new TypeOfLevel(Convert.ToInt32(tblRet.Rows[i]["Level"]));
                MoviesOrScripts[i].Level = NewLev;
                MoviesOrScripts[i].Inner_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[i]["Sex"]);
                MoviesOrScripts[i].Status = Convert.ToInt32(tblRet.Rows[i]["Status"]);
                MoviesOrScripts[i].Title = tblRet.Rows[i]["Title"].ToString();
                MoviesOrScripts[i].Cost = Convert.ToInt32(tblRet.Rows[i]["Costo"]);
            }
            return MoviesOrScripts;
        }

        public static CharImages[] GetImages()
        {
            string strCommand = "SELECT * FROM CharImages";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            CharImages[] TypeOf = new CharImages[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                TypeOf[i].IDChar = Convert.ToInt32(tblRet.Rows[i]["IDChar"]);
                TypeOf[i].Image = (System.Byte[]) tblRet.Rows[i]["Image"];
                TypeOf[i].AgeValue = (AgeClass)Convert.ToInt32(tblRet.Rows[i]["AgeValue"]);
            }
            return TypeOf;
        }

        public static TypeOfLevel[] GetTypeOfLevels()
        {
            string strCommand = "SELECT * FROM Level";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            TypeOfLevel[] TypeOf = new TypeOfLevel[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                TypeOf[i] = new TypeOfLevel(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return TypeOf;
        }

        public static TypeOfCharacters[] GetTypeOfCharacters()
        {
            string strCommand = "SELECT * FROM TypeOfCharacter;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            TypeOfCharacters[] Types = new TypeOfCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Types[i] = new TypeOfCharacters(Convert.ToInt32(tblRet.Rows[i]["ID"]));
            }
            return Types;
        }

        public static DataTable GetTypeOfCharactersTable()
        {
            string strCommand = "SELECT * FROM TypeOfCharacter;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            return tblRet;
        }

        #region Characters
        /// <summary>
        /// This method return all the characters of this type and active status and if blnCheckBusy = true
        /// also that are not currently on movies or serials.
        /// </summary>
        /// <param name="Typo"></param>
        /// <param name="Active"></param>
        /// <param name="blnCheckBusy"></param>
        /// <returns></returns>
        public static GenericCharacters[] GetCharacters(TypeOfCharacters Typo = null, int Active = 1, bool blnCheckBusy = false)
        {
            string strCommand = "SELECT * FROM GenericCharacter WHERE Active = " + Active;
            if (Typo != null)
            {
                strCommand += " AND fkTypeOf = " + Typo.ID.ToString();
            }
            strCommand += ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            GenericCharacters[] RetVal = new GenericCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                GenericCharacters Appo = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID"]));
                if (blnCheckBusy)
                { 
                    List<Movie> Mov = GetListOfMovieInWorkingFromCharID(Appo.ID, 0);
                    if (Mov.Count == 0)
                    {
                        List<Serial> Ser = GetListOfSerialInWorkingFromCharID(Appo.ID, 0);
                        if (Ser.Count == 0)
                            RetVal[i] = Appo;
                    }
                }
                else
                    RetVal[i] = Appo;
        }
            return RetVal;
        }

        public static DataTable GetCharactersTable(int Active = 1)
        {
            string strCommand = "SELECT * FROM GenericCharacter WHERE Active = " + Active +"; ";
            DataTable tblRet = SQLLiteInt.Select(strCommand);            
            return tblRet;
        }

        public static GenericCharacters[] GetCharactersByType(string strTypeOfCharacter, int Active = 1)
        {
            string strCommand = string.Format("SELECT GenericCharacter.* FROM GenericCharacter " +
                "INNER JOIN TypeOfCharacter AS T ON T.ID = GenericCharacter.fkTypeOf " +
                "WHERE T.TypeOf = '{0}' AND GenericCharacter.Ative={1};", strTypeOfCharacter, Active);
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            GenericCharacters[] RetVal = new GenericCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                RetVal[i] = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID"]));
                //RetVal[i].Inner_Val = new Inner_Values();
                //RetVal[i].Inner_Val.Action = Convert.ToInt32(tblRet.Rows[i]["Action"]);
                //RetVal[i].Age = Convert.ToInt32(tblRet.Rows[i]["Age"]);
                //RetVal[i].Inner_Val.Humor = Convert.ToInt32(tblRet.Rows[i]["Humor"]);
                //RetVal[i].Name = tblRet.Rows[i]["Name"].ToString();
                //RetVal[i].Popularity = Convert.ToInt32(tblRet.Rows[i]["Popularity"]);
                //RetVal[i].Sex = tblRet.Rows[i]["Sex"].ToString();
                //RetVal[i].Inner_Val.Sexappeal = Convert.ToInt32(tblRet.Rows[i]["Sexappeal"]);
                //RetVal[i].Skills = Convert.ToInt32(tblRet.Rows[i]["Skill"]);
                //RetVal[i].Surname = tblRet.Rows[i]["Surname"].ToString();
                //RetVal[i].Talent = Convert.ToInt32(tblRet.Rows[i]["Talent"]);
                //TypeOfCharacters typo = new TypeOfCharacters(Convert.ToInt32(tblRet.Rows[i]["fkTypeOf"]));
                //RetVal[i].TypeOf = typo;
            }
            return RetVal;
        }

        /// <summary>
        /// This method return the list of all characters with the "LIKE" surname, type, active status
        /// and if blnCheckBusy = true also not on a movies or serials.
        /// </summary>
        /// <param name="strSurname"></param>
        /// <param name="Typo"></param>
        /// <param name="Active"></param>
        /// <param name="blnCheckBusy"></param>
        /// <returns></returns>
        public static GenericCharacters[] GetCharactersBySurnameLike(string strSurname, TypeOfCharacters Typo = null, int Active = 1, bool blnCheckBusy = false)
        {
            string strCommand = string.Format("SELECT * FROM GenericCharacter " +
                "WHERE Surname LIKE '%{0}%' AND Active = {1};", strSurname, Active);
            if (Typo != null)
            {
                strCommand += " AND fkTypeOf = " + Typo.ID.ToString();
            }
            strCommand += ";";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            GenericCharacters[] RetVal = new GenericCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                GenericCharacters Appo = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID"]));
                if (blnCheckBusy)
                {
                    List<Movie> Mov = GetListOfMovieInWorkingFromCharID(Appo.ID, 0);
                    if (Mov.Count == 0)
                    {
                        List<Serial> Ser = GetListOfSerialInWorkingFromCharID(Appo.ID, 0);
                        if (Ser.Count == 0)
                            RetVal[i] = Appo;
                    }
                }
                else
                    RetVal[i] = Appo;
            }
            return RetVal;
        }

        public static GenericCharacters[] GetCharactersByNameAndSurnameLike(string Name, string strSurname, int Active = 1)
        {
            string strCommand = string.Format("SELECT * FROM GenericCharacter " +
                "WHERE Surname = '{0}' AND Name = '{1}' AND Active = {2};", strSurname, Name, Active);
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            GenericCharacters[] RetVal = new GenericCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                RetVal[i] = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID"]) );
            }
            return RetVal;
        }

        public static L_CharsMovies[] GetDirectorFromMovie(int MovieID)
        {

            L_CharsMovies Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + MovieID + " AND Char_Name = 'Director';");
            L_CharsMovies[] Links = new L_CharsMovies[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new L_CharsMovies(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]), MovieID);
                Links[i] = Link;
            }
            return Links;
        }

        public static L_CharsMovies[] GetWriterFromMovie(int MovieID)
        {

            L_CharsMovies Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + MovieID + " AND Char_Name = 'Writer';");
            L_CharsMovies[] Links = new L_CharsMovies[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new L_CharsMovies(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]), MovieID);
                Links[i] = Link;
            }
            return Links;
        }

        public static L_CharsMovies[] GetActorsFromMovie(int MovieID)
        {

            L_CharsMovies Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + MovieID + " AND Char_Name = 'Actor';");
            L_CharsMovies[] Links = new L_CharsMovies[tblRet.Rows.Count];
            for (int i=0;i<tblRet.Rows.Count;i++)
            {
                Link = new L_CharsMovies(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]), MovieID);
                Links[i] = Link;
            }
            return Links;
        }

        public static L_CharsMovies[] GetCastFromMovie(int MovieID)
        {

            L_CharsMovies Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + MovieID + ";");
            L_CharsMovies[] Links = new L_CharsMovies[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new L_CharsMovies(); 
                Link.ID_Char = Convert.ToInt32(tblRet.Rows[i]["ID_Char"]);
                Link.ID_Movie = Convert.ToInt32(tblRet.Rows[i]["ID_Movie"]);
                Link.Char_Name = tblRet.Rows[i]["Char_Name"].ToString();
                Links[i] = Link;
            }
            return Links;
        }

        public static GenericCharacters[] GetGenericCastFromMovie(int MovieID)
        {

            GenericCharacters Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + MovieID + " ORDER BY Char_Name DESC;");
            GenericCharacters[] Links = new GenericCharacters[tblRet.Rows.Count];
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]));
                int intIDType = -1;
                switch (tblRet.Rows[i]["Char_Name"])
                {
                    case "Actor":
                        intIDType = (Link.Sex == "F" ? 4 : 3);
                        break;
                    case "Director":
                        intIDType = 2;
                        break;
                    case "Writer":
                        intIDType = 1;
                        break;
                }
                TypeOfCharacters typo = new TypeOfCharacters(intIDType);
                Link.TypeOf = typo;
                Links[i] = Link;
            }
            return Links;
        }

        public static List<GenericCharacters> GetGenericCastFromMovie_List(int MovieID)
        {

            GenericCharacters Link;
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + MovieID + " ORDER BY Char_Name DESC;");
            List<GenericCharacters> Links = new List<GenericCharacters>();
            for (int i = 0; i < tblRet.Rows.Count; i++)
            {
                Link = new GenericCharacters(Convert.ToInt32(tblRet.Rows[i]["ID_Char"]));                
                Links.Add(Link);
            }
            return Links;
        }

        /// <summary>
        /// This method checks if, for the selected movie, there is already someone in the role.
        /// </summary>
        /// <param name="intIDMovie"></param>
        /// <param name="strRole"></param>
        /// <returns></returns>
        public static bool AlreadyExistRole(int intIDMovie, string strRole)
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + intIDMovie + " AND Char_Name = '" + strRole + "';");
            if (tblRet.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// This method checks if, for the selected movie and actor, the role is already assigned
        /// </summary>
        /// <param name="intIDMovie"></param>
        /// <param name="intIDChar"></param>
        /// <param name="strRole"></param>
        /// <returns></returns>
        public static bool AlreadyInTheMovieForThisRole(int intIDMovie, int intIDChar, string strRole)
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT * FROM L_CharsMovies WHERE ID_Movie = " + intIDMovie + " AND Char_Name = '" + strRole + "' AND ID_Char = " + intIDChar + ";");
            if (tblRet.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static int GetMaxCharacterID()
        {
            DataTable tblRet = SQLLiteInt.Select("SELECT MAX(ID) FROM GenericCharacter;");
            return Convert.ToInt32(tblRet.Rows[0][0]);
        }
        #endregion

        
        public static string GetNameOfValueFromInnerValue(int Val, string ValueName, bool IsFemale = true)
        {
            string strCommand = "SELECT ";
            switch (ValueName.ToUpper())
            {
                case "ACTION":
                    strCommand += " ActionName as Name ";
                    break;
                case "HUMOR":
                    strCommand += " HumorName as Name ";
                    break;
                case "SEXAPPEAL":
                    strCommand += " SexappealName as Name ";
                    break;
            }
            strCommand += "FROM Name_Of_Values WHERE "; 
            strCommand += " MaxValue <= " + Val + " ORDER BY MaxValue DESC;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                if (IsFemale)
                    return tblRet.Rows[0]["Name"].ToString();
                else
                {
                    string strVa = tblRet.Rows[0]["Name"].ToString();
                    if (strVa.Substring(strVa.Length - 1, 1) == "a")
                        strVa = strVa.Remove(strVa.Length - 1, 1) + "o";
                    return strVa;
                }
            }
            else
                return "";
        }

        public static DataTable GetNameOfValue(string ValueName, bool IsFemale = true)
        {
            string strCommand = "SELECT MaxValue, ";
            switch (ValueName.ToUpper())
            {
                case "ACTION":
                    strCommand += " ActionName as Name ";
                    break;
                case "HUMOR":
                    strCommand += " HumorName as Name ";
                    break;
                case "SEXAPPEAL":
                    strCommand += " SexappealName as Name ";
                    break;
            }
            strCommand += "FROM Name_Of_Values ";
            strCommand += " ORDER BY MaxValue DESC;";
            DataTable tblRet = SQLLiteInt.Select(strCommand);
            if (tblRet.Rows.Count > 0)
            {
                if (!IsFemale)
                {
                    for (int i = 0; i < tblRet.Rows.Count; i++)
                    {
                        string strVa = tblRet.Rows[i]["Name"].ToString();
                        if (strVa.Substring(strVa.Length - 1, 1) == "a")
                            strVa = strVa.Remove(strVa.Length - 1, 1) + "o";
                        tblRet.Rows[i]["Name"] = strVa;
                    }
                }
            }
            return tblRet;
        }

        public static void GetBonusFromSkills(GenericCharacters Actor, out int intBonusAudience, out int intBonusSuccess, out int intBonusAction, out int intBonusHumor, out int intBonusSexappeal)
        {
            intBonusAudience = 0;
            intBonusSuccess = 0;
            intBonusAction = 0;
            intBonusHumor = 0;
            intBonusSexappeal = 0;

            SpecialAbilities[] Specials = GetSpecialAbilitiesListByIDChar(Actor.ID);

            foreach (SpecialAbilities S in Specials)
            {
                intBonusAction += S.In_Val.Action;
                intBonusHumor += S.In_Val.Humor;
                intBonusSexappeal += S.In_Val.Sexappeal;
                intBonusAudience += S.Audience;
                intBonusSuccess += S.Success;
            }
        }
    }

    public static class Creator
    {
        public static string CheckJsonAndNormalizeGenre(string EntryJson)
        {
            string ExitJson = "";
            JObject jo = JObject.Parse(EntryJson);
            try
            {
                jo.Property("contentRating").Remove();
            }
            catch (Exception exc) { throw exc; }
            try
            {
                jo.Property("review").Remove();
            }
            catch (Exception exc) { throw exc; }
            try
            {
                jo.Property("aggregateRating").Remove();
            }
            catch (Exception exc) { throw exc; }
            EntryJson = jo.ToString();

            // Se ha solo un genere
            if (EntryJson.Contains("\"genre\": \""))
            {
                string Appo = EntryJson.Replace("\"genre\": \"", "\"genre\": [\"");
                
                ExitJson = Appo.Replace("\"actor\":", "],\"actor\":");
            }
            else
                ExitJson = EntryJson;

            return ExitJson;
        }

        /// <summary>
        /// This method add the character to the movie for the selected role.
        /// First check if the role is already filled (in this case it remove the previous and add the new),
        /// or it checks if it's filled by the same character (live the same).
        /// </summary>
        /// <param name="MovieID"></param>
        /// <param name="CharID"></param>
        /// <param name="Role"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        public static bool AddCharToMovie(int MovieID, int CharID, string Role)
        {
            bool blnResult = false;

            // Ruolo già occupato
            if (!Retriever.AlreadyExistRole(MovieID, Role) || Role == "Actor")                
            {
                if (!Retriever.AlreadyInTheMovieForThisRole(MovieID, CharID, Role))
                {
                    // Aggiungo il personaggio
                    L_CharsMovies Link = new L_CharsMovies();
                    Link.Char_Name = Role;
                    Link.ID_Char = CharID;
                    Link.ID_Movie = MovieID;
                    Link.Performance_Description = "";
                    blnResult = Link.L_CharsMovies_InsertDb();
                }
            }
            else
            {
                // Se non è lo stesso personaggio, tolgo il precedente e metto il nuovo
                if (!Retriever.AlreadyInTheMovieForThisRole(MovieID, CharID, Role))
                { 
                    L_CharsMovies Link = new L_CharsMovies(MovieID, Role);
                    Link.L_CharsMovies_Delete();
                    // Aggiungo il nuovo
                    Link = new L_CharsMovies();
                    Link.Char_Name = Role;
                    Link.ID_Char = CharID;
                    Link.ID_Movie = MovieID;
                    Link.Performance_Description = "";
                    blnResult = Link.L_CharsMovies_InsertDb();
                }                
            }
                
            return blnResult;
        }

        #region Creation of New Characters By Type
        private static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// This method add a new actor to the game, based from the actual age (year) and sex.
        /// Generate a random value for Inner_Values (between 0 and 69).
        /// Set popularity at 1.
        /// Generate at random up to 3 special abilities.
        /// </summary>
        /// <param name="intActualAge"></param>
        /// <param name="strSex"></param>
        /// <returns></returns>
        public static GenericCharacters CreateNewCharacter(int intActualAge, string strSex, TypeOfCharacters typo)
        {
            GenericCharacters Gen = new GenericCharacters();
            Random rndCasuale = new Random();
            Gender GenGender;
            if (strSex == "F")
                GenGender = Gender.Female;
            else
                GenGender = Gender.Male;

            // Età pari a 15 -2/+7
            Gen.Age = intActualAge - (15 + rndCasuale.Next(-2, 7));
            Gen.Inner_Val = new Inner_Values();
            Gen.Inner_Val.Action = rndCasuale.Next(0,70);
            Gen.Inner_Val.Sexappeal= rndCasuale.Next(0, 70);
            Gen.Inner_Val.Humor = rndCasuale.Next(0, 70);
            Gen.Talent = rndCasuale.Next(0, 70);
            Gen.Skills = rndCasuale.Next(0, 70);
            // All'inizio vale 1, esordiente.
            Gen.Popularity = 1;
            Gen.Name = FirstCharToUpper(NameGenerator.GenerateFirstName(GenGender).ToLower());            
            Gen.Sex = strSex;
            Gen.Surname = FirstCharToUpper(NameGenerator.GenerateLastName().ToLower());            
            Gen.TypeOf = typo;
            Gen.Active = 1;
            Gen.GenericCharacters_WriteOnDb();
            // Add Abilities
            AddAbilities(Gen, 70);

            // Add Image
            DbRuler.CharImages Img = new CharImages(Gen.ID);
            Img.IDChar = Gen.ID;

            string strImagePath = GenerateCharImage(Gen.Sex);

            string myDirectory = Path.Combine(Environment.CurrentDirectory, "hello.svg");

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(strImagePath, myDirectory);
            }            

            SVGParser.MaximumSize = new System.Drawing.Size(4000, 4000);

            Svg.SvgDocument svgDocument = SVGParser.GetSvgDocument(myDirectory);
            var bitmap = svgDocument.Draw();
            Image NewImg = bitmap;            

            using (var ms1 = new MemoryStream())
            {
                ResizeImage(NewImg, 100, 130).Save(ms1, ImageFormat.Png);
                Img.Image = ms1.ToArray();
            }

            Img.CharImages_Create();
            return Gen;
        }

        private static void AddAbilities(GenericCharacters gen, int intTargetPerc)
        {
            Random rndCasuale = new Random();
            int intNumberOf = rndCasuale.Next(0, 3);
            int intPerc = rndCasuale.Next(0, 100);
            if (intPerc >= intTargetPerc)
            {
                int intType = gen.TypeOf.ID;

                SpecialAbilities[] Spec = Retriever.GetSpecialAbilitiesListVByType(intType);
                if (Spec.Length > 0)
                {
                    bool blnAddSpec = true;
                    for (int i = 0; i < intNumberOf; i++)
                    {
                        blnAddSpec = true;
                        int intIndex = rndCasuale.Next(0, Spec.Length);
                        SpecialAbilities[] CharSpec = Retriever.GetSpecialAbilitiesListByIDChar(gen.ID);
                        foreach (SpecialAbilities S in CharSpec)
                        {
                            if (S.ID == Spec[intIndex].ID)
                            {
                                blnAddSpec = false;
                                break;
                            }
                        }
                        if (blnAddSpec)
                        {
                            L_CharsAbilities Link = new L_CharsAbilities(gen.ID, intIndex);
                            Link.L_CharsAbilities_InsertDb();
                        }
                    }
                }
            }
        }

        private static string GenerateCharImage(string strSex)
        {
            string strPath = "";
            string strFinalPath = "";
            string strBasePath = "https://avatars.dicebear.com/v2/:sprites/:seed.svg";
            string strSub = "";
            if (strSex == "M")
                strSub = "male";
            else
            {
                if (strSex == "F")
                    strSub = "female";
                else
                    strSub = "identicon";
            }
            strPath = strBasePath.Replace(":sprites", strSub);
            Random rndCasuale = new Random();
            strFinalPath = strPath.Replace(":seed", rndCasuale.Next(0, 50000).ToString());
            return strFinalPath;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (Image)destImage;
        }

        public static GenericCharacters CreateDirector(int intActualAge, string strSex)
        {
            GenericCharacters Gen = new GenericCharacters();
            Random rndCasuale = new Random();
            Gender GenGender;
            if (strSex == "F")
                GenGender = Gender.Female;
            else
                GenGender = Gender.Male;

            // Età pari a 25 -5/+10
            Gen.Age = intActualAge - (25 + rndCasuale.Next(-5, 10));
            Gen.Inner_Val = new Inner_Values();
            Gen.Inner_Val.Action = rndCasuale.Next(0, 70);
            Gen.Inner_Val.Sexappeal = rndCasuale.Next(0, 70);
            Gen.Inner_Val.Humor = rndCasuale.Next(0, 70);
            Gen.Talent = rndCasuale.Next(0, 70);
            Gen.Skills = rndCasuale.Next(0, 70);
            // All'inizio vale 1, esordiente.
            Gen.Popularity = 1;
            Gen.Name = FirstCharToUpper(NameGenerator.GenerateFirstName(GenGender).ToLower());
            Gen.Sex = strSex;
            Gen.Surname = FirstCharToUpper(NameGenerator.GenerateLastName().ToLower());
            TypeOfCharacters typo = new TypeOfCharacters(2);
            Gen.TypeOf = typo;
            Gen.Active = 1;
            Gen.GenericCharacters_WriteOnDb();
            AddAbilities(Gen, 75);
            return Gen;
        }

        public static GenericCharacters CreateWriter(int intActualAge, string strSex)
        {
            GenericCharacters Gen = new GenericCharacters();
            Random rndCasuale = new Random();
            Gender GenGender;
            if (strSex == "F")
                GenGender = Gender.Female;
            else
                GenGender = Gender.Male;

            // Età pari a 40 -10/+15
            Gen.Age = intActualAge - (40 + rndCasuale.Next(-10, 15));
            Gen.Inner_Val = new Inner_Values();
            Gen.Inner_Val.Action = rndCasuale.Next(0, 70);
            Gen.Inner_Val.Sexappeal = rndCasuale.Next(0, 70);
            Gen.Inner_Val.Humor = rndCasuale.Next(0, 70);
            Gen.Talent = rndCasuale.Next(0, 70);
            Gen.Skills = rndCasuale.Next(0, 70);
            // All'inizio vale 1, esordiente.
            Gen.Popularity = 1;
            Gen.Name = FirstCharToUpper(NameGenerator.GenerateFirstName(GenGender).ToLower());
            Gen.Sex = strSex;
            Gen.Surname = FirstCharToUpper(NameGenerator.GenerateLastName().ToLower());
            TypeOfCharacters typo = new TypeOfCharacters(1);
            Gen.TypeOf = typo;
            Gen.Active = 1;
            Gen.GenericCharacters_WriteOnDb();
            AddAbilities(Gen, 80);
            return Gen;
        }
        #endregion
    }
}