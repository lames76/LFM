using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyImDbParser
{
    public class ImDbDataRetriever
    {
        public string strPageCode = string.Empty;

        public string Title;
        public string Link;
        public string ImageLink;

        public string Json;


        public void ParseCode()
        {
            if (strPageCode.Length > 0)
            {
                int IndexStart = strPageCode.IndexOf("<Title>");
                int IndexStop = strPageCode.IndexOf("</Title>");

                string strSearchStart = "<script type=\"application/ld+json\">";

                IndexStart = strPageCode.IndexOf(strSearchStart);
                Json = strPageCode.Substring(IndexStart + strSearchStart.Length);
                IndexStop = Json.IndexOf("</script>");
                Json = strPageCode.Substring(IndexStart+strSearchStart.Length, IndexStop);
                NormalizeJson();
            }
        }

        private void NormalizeJson()
        {
            int Index = Json.IndexOf("\"director\": [");
            if (Index <0)
            {
                string Json1 = Json.Replace("\"director\": {", "\"director\": [\n {");
                Json = Json1;
                Json1 = Json.Replace("},\n  \"creator\":", "}\n ],\n \"creator\":");
                Json = Json1;
            }
        }
    }
}
