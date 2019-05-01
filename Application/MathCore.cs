using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace Application
{
    public class MathCore
    {
        public MathCore(String pPathToPlugins)
        {
            Plugins = new Dictionary<string, object>();
            LoadPlugins(pPathToPlugins);
        }
        /// <summary>
        /// Ladet die Module aus der übergebenen Assembly
        /// </summary>
        /// <param name="pFileName">Assembly die verwendet werden soll.</param>
        /// <param name="pTypeInterface">Welches Interface das Modul implementierrt hat.</param>
        /// <returns>Gibt ein Dictionary zurück. Als Key wird der Klassenname der aktivierten Instanz verwendet.</returns>
        private static Dictionary<string, object> GetModul(string pFileName, Type pTypeInterface)
        {
            //Hier speichern wir unsere Plugins
            Dictionary<string, object> interfaceinstances = new Dictionary<string, object>();

            //Loads an assembly given its file name or path.
            Assembly assembly = Assembly.LoadFrom(pFileName);

            // http://msdn.microsoft.com/de-de/library/t0cs7xez.aspx
            // Assembly Eigenschaften checken
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsPublic) // Ruft einen Wert ab, der angibt, ob der Type als öffentlich deklariert ist. 
                {
                    if (!type.IsAbstract)  //nur Assemblys verwenden die nicht Abstrakt sind
                    {
                        // Sucht die Schnittstelle mit dem angegebenen Namen. 
                        Type typeInterface = type.GetInterface(pTypeInterface.ToString(), true);

                        //Make sure the interface we want to use actually exists
                        if (typeInterface != null)
                        {
                            try
                            {

                                object activedInstance = Activator.CreateInstance(type);
                                if (activedInstance != null)
                                {
                                    interfaceinstances.Add(type.Name, activedInstance);
                                }
                            }
                            catch (Exception exception)
                            {
                                System.Diagnostics.Debug.WriteLine(exception);
                            }
                        }

                        typeInterface = null;
                    }
                }
            }

            assembly = null;

            return interfaceinstances;
        }
        
        public void LoadPlugins(String pPluginPath)
        {
            String[] files = Directory.GetFiles(pPluginPath);

            foreach (String file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.Extension.Equals(".dll"))
                {
                    Dictionary<string, object> dictionary = GetModul(file, typeof(IPlugin.IPlugin));
                    foreach (var a in dictionary)
                    {
                        Plugins.Add(a.Key,a.Value);
                    }

                }

            }
        }

        public Dictionary<string, object> Plugins { get; protected set; }

        private IPlugin.IPlugin GetPlugin(string pluginName)
        {
            foreach (var dir in Plugins)
            {
                IPlugin.IPlugin plugin = dir.Value as IPlugin.IPlugin;
                if (plugin.Name.ToLower().Equals(pluginName.ToLower()))
                    return plugin;

            }
            return null;
        }

        public string Calc(string pInput)
        {
            //Funktionsname ermitteln
            Regex regex = new Regex("([a-z]+)");
            MatchCollection matchCollection = regex.Matches(pInput);

            String pluginName = matchCollection[0].Value;

            IPlugin.IPlugin plugin = GetPlugin(pluginName);

            //Es wurde kein Plugin gefunden, das als Namen den gesuchten Funktionsnamen hat
            if (plugin == null)
            {
                //throw new NotImplementedException();
            }
            else
            {
                try
                {
                    //Methode vom Plugin aufrufen
                    return plugin.Calc(pInput);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine(e);
                }
            }

            return "Funktion nicht gefunden.";
        }
         
    }
}
