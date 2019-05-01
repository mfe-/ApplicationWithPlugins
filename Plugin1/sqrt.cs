using System;

namespace Plugin1
{
    public class sqrt : IPlugin.IPlugin
    {
        #region IPlugin Members

        public string Name
        {
            get
            {
                return "sqrt";
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
                return "Berechnet die Wurzel";
            }
            set
            {
                ;
            }
        }

        public string Calc(string pInput)
        {
            //Zuerst den Input zurecht parsen
            pInput = pInput.Replace("sqrt(",String.Empty).Replace(")",String.Empty);
            return Math.Sqrt(Double.Parse(pInput)).ToString();
        }

        #endregion
    }
}
