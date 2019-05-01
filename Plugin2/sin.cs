using System;

namespace Plugin2
{
    public class sin : IPlugin.IPlugin
    {
        #region IPlugin Members

        public string Name
        {
            get
            {
                return "sin";
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
                return "Berechnet den sin";
            }
            set
            {
                ;
            }
        }

        public string Calc(string pInput)
        {
            //Zuerst den Input zurecht parsen
            pInput = pInput.Replace("sin(", String.Empty).Replace(")", String.Empty);
            return Math.Sin(Double.Parse(pInput)).ToString();
        }

        #endregion
    }
}
