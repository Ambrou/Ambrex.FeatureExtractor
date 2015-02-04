using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class Requirement
    {
        public string m_strContext = "";
        public List<Tuple<string, string>> m_Scenario = new List<Tuple<string,string>>();
    }
}
