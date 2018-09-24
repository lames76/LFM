using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    public static class LFMReportManager
    {
        #region Detailed Cost Report
        /// <summary>
        /// Look at Reports.xlsx Tab DetailerCostReport
        /// </summary>
        /// <param name="GenMovie"></param>
        /// <returns></returns>
        public static DataTable GetDetailedCostReport(Movie GenMovie)
        {
            DataTable tblData = GenerateDetailedCostTable();
            AddHeaderToTable(tblData, GenMovie);
            AddEmptyLineToTable(tblData);

            long Price = 0;
            #region Cast Costs
            GenericCharacters[] GenChars = Retriever.GetGenericCastFromMovie(GenMovie.ID);
            bool blnFirstActorAdded = false;
            foreach (GenericCharacters Charact in GenChars)
            {
                // They are ordered so the case is right order
                switch (Charact.TypeOf.TypeOf.ToUpper())
                {
                    case "WRITER":              
                        long Priw = Calculation.GetCashOfWriter(Charact, GenMovie);
                        LG_CharPlayerAffinity Linkw = new LG_CharPlayerAffinity(Charact.ID);
                        long AffinityChangew = Priw * -Linkw.Affinity / 100;                        
                        Price += Priw + AffinityChangew;
                        AddCharSectionToTable(tblData, Charact, Priw + AffinityChangew, Charact.TypeOf.TypeOf);
                        AddEmptyLineToTable(tblData);
                        break;
                    case "DIRECTOR":
                        long Prid = Calculation.GetCashOfDirector(Charact, GenMovie);
                        LG_CharPlayerAffinity Linkd = new LG_CharPlayerAffinity(Charact.ID);
                        long AffinityChanged = Prid * -Linkd.Affinity / 100;
                        Price += Prid + AffinityChanged;
                        AddCharSectionToTable(tblData, Charact, Prid + AffinityChanged, Charact.TypeOf.TypeOf);
                        AddEmptyLineToTable(tblData);
                        break;
                    case "ACTOR":
                    case "ACTRESS":
                        long Pri = Calculation.GetCashOfActor(Charact, GenMovie);
                        LG_CharPlayerAffinity Link = new LG_CharPlayerAffinity(Charact.ID);
                        long AffinityChange = Pri * -Link.Affinity / 100;
                        Price += Pri + AffinityChange;
                        AddCharSectionToTable(tblData, Charact, Pri + AffinityChange, Charact.TypeOf.TypeOf, !blnFirstActorAdded);
                        blnFirstActorAdded = true;
                        break;
                }
            }
            AddEmptyLineToTable(tblData);
            #endregion
            #region Structure Cost
            long lngPriceStructure = Calculation.GetPriceOfTheatre(GenMovie);
            AddStructSectionToTable(tblData, GenMovie, lngPriceStructure, "Theatre");
            Price += lngPriceStructure;
            lngPriceStructure = Calculation.GetPriceOfFX(GenMovie);
            AddStructSectionToTable(tblData, GenMovie, lngPriceStructure, "FX", false);
            Price += lngPriceStructure;
            AddEmptyLineToTable(tblData);
            #endregion
            #region Locations
            int[] Locations = Retriever.GetMovieLocations(GenMovie.ID);
            blnFirstActorAdded = false;
            foreach (int L_ID in Locations)
            {
                Location Loc = new Location(L_ID);
                long lngPrice = Calculation.GetCostOfLocation(L_ID);
                AddLocationSectionToTable(tblData, Loc, lngPrice, !blnFirstActorAdded);
                blnFirstActorAdded = true;
                Price += lngPrice;                
            }
            AddEmptyLineToTable(tblData);
            #endregion
            AddTotalCostToTable(tblData, Price);
            AddEmptyLineToTable(tblData);
            AddEmptyLineToTable(tblData);
            int RealAudience = LFMGRule.CalculateRealAudience(GenMovie);
            long Cash = LFMGRule.CalculateMoney(RealAudience);
            AddTotalCostToTable(tblData, Cash, "Revenue");
            AddEmptyLineToTable(tblData);            
            AddTotalCostToTable(tblData, Cash - Price, "Gain");
            return tblData;
        }

        private static void AddTotalCostToTable(DataTable tblData, long TotalPrice, string strGain = "")
        {
            DataRow dr = tblData.NewRow();
            dr["A"] = strGain;
            dr["B"] = "";
            dr["C"] = "";
            dr["D"] = "";
            dr["E"] = "Totals:";
            dr["F"] = TotalPrice;
            tblData.Rows.Add(dr);
        }

        private static void AddLocationSectionToTable(DataTable tblData, Location loc, long lngPriceStructure, bool blnAddHeader = true)
        {
            DataRow dr;
            if (blnAddHeader)
            {
                #region Row 1 - Header
                dr = tblData.NewRow();
                dr["A"] = "Locations:";
                dr["B"] = "";
                dr["C"] = "";
                dr["D"] = "";
                dr["E"] = "";
                dr["F"] = 0;
                tblData.Rows.Add(dr);
                #endregion
            }
            #region Row 2
            dr = tblData.NewRow();
            dr["A"] = "";
            dr["B"] = "Location:";
            dr["C"] = loc.Name;
            dr["D"] = "";
            dr["E"] = "Cost:";
            dr["F"] = lngPriceStructure;
            tblData.Rows.Add(dr);
            #endregion
        }

        private static void AddStructSectionToTable(DataTable tblData, Movie genMovie, long lngPriceStructure, string StructType, bool blnAddHeader = true)
        {
            DataRow dr;
            if (blnAddHeader)
            {
                #region Row 1 - Header
                dr = tblData.NewRow();
                dr["A"] = StructType + ":";
                dr["B"] = "";
                dr["C"] = "";
                dr["D"] = "";
                dr["E"] = "";
                dr["F"] = 0;
                tblData.Rows.Add(dr);
                #endregion
            }
            #region Row 2
            dr = tblData.NewRow();
            dr["A"] = "";
            dr["B"] = StructType + ":";
            dr["C"] = (StructType == "Theatre" ? genMovie.fkTdP.Name : genMovie.fkFX.Name);
            dr["D"] = "";
            dr["E"] = "Cost:";
            dr["F"] = lngPriceStructure;
            tblData.Rows.Add(dr);
            #endregion
        }

        private static void AddEmptyLineToTable(DataTable tblData)
        {
            #region Row 4 - Empty
            DataRow dr = tblData.NewRow();
            dr["A"] = "";
            dr["B"] = "";
            dr["C"] = "";
            dr["D"] = "";
            dr["E"] = "";
            dr["F"] = 0;
            tblData.Rows.Add(dr);
            #endregion
        }

        private static void AddCharSectionToTable(DataTable tblData, GenericCharacters charact, long lngPriceWriter, string CharType, bool blnAddHeader = true)
        {
            DataRow dr;
            if (blnAddHeader)
            {
                #region Row 1 - Header
                dr = tblData.NewRow();
                dr["A"] = CharType + ":";
                dr["B"] = "";
                dr["C"] = "";
                dr["D"] = "";
                dr["E"] = "";
                dr["F"] = 0;
                tblData.Rows.Add(dr);
                #endregion
            }
            #region Row 2
            dr = tblData.NewRow();
            dr["A"] = "";
            dr["B"] = CharType + ":";
            dr["C"] = charact.Name + " " + charact.Surname;
            dr["D"] = "";
            dr["E"] = "Cost:";            
            dr["F"] = lngPriceWriter;
            tblData.Rows.Add(dr);
            #endregion
        }

        /// <summary>
        /// This method add the Header section of the report directly to the tblData
        /// </summary>
        /// <param name="tblData"></param>
        /// <param name="genMovie"></param>
        private static void AddHeaderToTable(DataTable tblData, Movie genMovie)
        {
            #region Row 1
            DataRow dr = tblData.NewRow();
            dr["A"] = "Titolo:";
            dr["B"] = genMovie.Title;
            dr["C"] = "";
            dr["E"] = "Anno:";
            dr["F"] = genMovie.Age;
            dr["D"] = "";
            tblData.Rows.Add(dr);
            #endregion
            #region Row 2
            dr = tblData.NewRow();
            dr["A"] = "Generi:";
            dr["B"] = "";
            dr["C"] = "";
            dr["D"] = "";
            dr["E"] = "";
            dr["F"] = 0;
            tblData.Rows.Add(dr);
            #endregion
            #region Row 3
            dr = tblData.NewRow();
            dr["A"] = "";
            for (int i = 0; i < genMovie.fkType.Length; i++)
            {
                dr[i+1] = genMovie.fkType[i].TypeOf;                
            }
            tblData.Rows.Add(dr);
            #endregion
        }

        private static DataTable GenerateDetailedCostTable()
        {
            DataTable tblRet = new DataTable();
            tblRet.Columns.Add("A");
            tblRet.Columns.Add("B");
            tblRet.Columns.Add("C");
            tblRet.Columns.Add("D");
            tblRet.Columns.Add("E");
            tblRet.Columns.Add("F");
            return tblRet;
        }
        #endregion
    }
}
