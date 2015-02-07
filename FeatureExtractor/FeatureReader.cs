using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class FeatureReader
    {
        public Dictionary<string, string> readRequirements(string strFile)
        {
            Dictionary<string, string> requirements = new Dictionary<string, string>();
            System.IO.StreamReader file = new System.IO.StreamReader(strFile, Encoding.GetEncoding("iso-8859-15"));
            string strReqId = "";
            string strText = "";
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                if(line.StartsWith("ReqID= ") == true)
                {
                    strReqId = line.Substring(7).TrimStart(' ').TrimEnd(' ');
                }
                else if (line.StartsWith("TEXTE= ") == true)
                {
                    strText = line.Substring(7).TrimStart(' ').TrimEnd(' ');
                }
                if(strText != "" && strReqId != "")
                {
                    requirements[strReqId] = strText;
                    strReqId = "";
                    strText = "";
                }
            }
            file.Close();
            return requirements;
        }
    }
}
