using System;

namespace Plugin2
{
    public class cos : IPlugin.IPlugin
    {
        #region IPlugin Members

        public string Name
        {
            get
            {
                return "cos";
            }
            set
            {
                ;
            }
        }

        public string Description
        {
            get
            {
                return "Berechnet den cos";
            }
            set
            {
                ;
            }
        }

        public string Calc(string pInput)
        {
            //Zuerst den Input zurecht parsen
            pInput = pInput.Replace("cos(", String.Empty).Replace(")", String.Empty);
            return Math.Cos(Double.Parse(pInput)).ToString();
        }

        #endregion
    }
}
