using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Globalization;
using System.Collections;
using System.IO;

namespace SQLLiteInterface
{
    public static class LFMConst
    {
        public const string GameDirPath = @"Games\";
        public const string ConfigurationFile = "ConnConf.zop";
        public const string ConnStringVal = @"Data Source={0};Version=3;New=False;Compress=True;";
    }

    public static class SQLLiteInt
    {        
        private static string strConnectionstring()
        {
            string strAppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string ConnString = File.ReadAllText(strAppPath + "\\" + LFMConst.ConfigurationFile);
            return "Data Source=DB\\LFM.db;Version=3;New=False;Compress=True;";
        }

        public static DataTable Select(string strSelect)
        {
            SQLiteConnection connection;
            DataTable tblMinion = new DataTable();

            connection = new SQLiteConnection(strConnectionstring());

            // Open the connection
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                // Create the SQLiteCommand and assign the query string
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = strSelect;
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                
                da.Fill(tblMinion);                
            }
            catch (Exception exc)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return tblMinion;
        }

        public static void SelectBynary(string strSelect, out byte[] MyImage)
        {
            MyImage = null;
            SQLiteConnection connection;
            DataTable tblMinion = new DataTable();

            connection = new SQLiteConnection(strConnectionstring());

            SQLiteCommand command = new SQLiteCommand(strSelect, connection);

            // Open the connection
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                IDataReader rdr = command.ExecuteReader();

                try
                {
                    while (rdr.Read())
                    {
                        MyImage = (System.Byte[])rdr[0];
                    }
                }
                catch (Exception exc1) { throw exc1; }
            }
            catch (Exception exc)
            { throw exc; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public static bool GenericCommandBynary(string strUpdate, byte [] Image)
        {
            bool blnResult = true;
            SQLiteConnection connection;

            connection = new SQLiteConnection(strConnectionstring());

            // Open the connection
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = strUpdate;
                SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
                param.Value = Image;
                command.Parameters.Add(param);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exc1)
                {
                    blnResult = false;
                    throw exc1;
                }
                connection.Close();
                blnResult = true;
            }
            catch (Exception exc)
            {
                blnResult = false;
                throw exc;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return blnResult;
        }

        public static bool GenericCommand(string strUpdate)
        {
            bool blnResult = true;
            SQLiteConnection connection;

            connection = new SQLiteConnection(strConnectionstring());

            // Open the connection
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = strUpdate;
                command.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception exc)
            {                
                blnResult = false;
                throw exc;
            }
            finally
            {
                if (connection.State != ConnectionState.Open)
                    connection.Close();
            }
            return blnResult;
        }
    }
}
