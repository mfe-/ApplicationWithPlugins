using System;

namespace IPlugin
{
    /// <summary>
    /// Definiert das "Aussehen" unserer Plugins
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Name des Plugins
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// Beschreibung des Plugins
        /// </summary>
        String Description { get; set; }

        /// <summary>
        /// Berechnet die Eingabe
        /// </summary>
        /// <param name="pInput">Eingabe die ausgewertet werden soll.</param>
        /// <returns>Gibt das berechnete Ergebnis zurück</returns>
        String Calc(String pInput);
    }
}
