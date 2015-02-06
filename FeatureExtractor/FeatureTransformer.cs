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
                transform(ref scenario.m_strSteps);
            }
        }

        private void transform(ref string strText)
        {
            strText = strText.Replace("Étant donné", "Soit");
            strText = strText.Replace("é", "e");
            strText = strText.Replace("è", "e");
            strText = strText.Replace("ê", "e");
            strText = strText.Replace("ù", "u");
            strText = strText.Replace("à", "a");
            strText = strText.Replace("à", "a");
            strText = strText.Replace("’", "'");
            strText = strText.Replace("ô", "o");
            strText = strText.Replace("ë", "e");
            strText = strText.Replace("ö", "o");
            strText = strText.Replace("ï", "i");
            strText = strText.Replace("ä", "a");
        }
    }
}
