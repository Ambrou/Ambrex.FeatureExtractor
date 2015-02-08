using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class FeatureReader
    {
        public Dictionary<string, Tuple<string, string>> readRequirements(string strFile)
        {
            Dictionary<string, Tuple<string, string>> requirements = new Dictionary<string, Tuple<string, string>>();
            System.IO.StreamReader file = new System.IO.StreamReader(strFile, Encoding.GetEncoding("windows-1252"));
            //System.IO.StreamReader file = new System.IO.StreamReader(strFile);
            string strReqId = "";
            string strText = "";
            string strTitle = "";
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                if(line.StartsWith("ReqID= ") == true)
                {
                    strReqId = line.Substring(7).TrimStart(' ').TrimEnd(' ');
                }
                else if (line.StartsWith("TITRE= ") == true)
                {
                    strTitle = line.Substring(7).TrimStart(' ').TrimEnd(' ');
                }
                else if (line.StartsWith("TEXTE= ") == true)
                {
                    strText = line.Substring(7).TrimStart(' ').TrimEnd(' ');
                }
                if(strText != "" && strReqId != "" && strTitle != "")
                {
                    requirements.Add(strReqId, new Tuple<string, string>(strTitle, strText));
                    strReqId = "";
                    strText = "";
                    strTitle = "";
                }
            }
            file.Close();
            return requirements;
        }
    }
}
