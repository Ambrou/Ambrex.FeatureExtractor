using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class FeatureTransformer
    {
        public void transform(ref Requirement requirement)
        {
            transform(ref requirement.m_strContext);
            foreach(var scenario in requirement.m_Scenarios)
            {
                string strTemp = scenario.Item2;
                transform(ref strTemp);
                //scenario.GetType = strTemp;
            }
        }

        private void transform(ref string strText)
        {
            strText.Replace("Étant donné", "Soit");
            strText.Replace("é", "e");
            strText.Replace("è", "e");
            strText.Replace("ê", "e");
            strText.Replace("ù", "u");
            strText.Replace("à", "a");
            strText.Replace("à", "a");
            strText.Replace("’", "'");
        }
    }
}
