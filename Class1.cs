using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;
namespace lib

{

     interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2, char x);
    }
  
    static class Counter
    {

        public static List<Plugin> plugins;

        public static string[] names()
        {
            List<string> nms = new List<string>();
            foreach (var i in plugins)
                nms.Add(i.PluginName);

            return nms.ToArray();
        }

    }
    /// <summary>
    /// Creates the new custom plugin
    /// </summary>
    public class Plugin : IPlugin
    {
        string n = "unknown", v = "unknown", d = "unknown";
        Image img = null;

        /// <summary>
        /// Creates the new custom plugin
        /// </summary>
        /// <param name="nam">The Name.</param>
        /// <param name="vers">The Version.</param>
        /// <param name="disc">The Description.</param>
        /// <param name="Img">The Image.</param>
        public Plugin(string nam, string vers, string disc, Image Img)
        {
            n = nam;
            v = vers;
            d = disc;
            img = Img;
            if (Counter.plugins == null)
                Counter.plugins = new List<Plugin>();

            Counter.plugins.Add(this);
        }


        /// <summary>
        /// Plugin Name
        /// </summary>
        public string PluginName => n;
        /// <summary>
        /// Plugin Version
        /// </summary>
        public string Version => v;
        /// <summary>
        /// Plugin Image
        /// </summary>
        public Image Image => img;
        /// <summary>
        /// Plugin Description
        /// </summary>
        public string Description => d;
        /// <summary>
        /// Performing a mathematical operation 
        /// </summary>
        /// <param name="input1">The First Int Value.</param>
        /// <param name="input2">The Second Int Value.</param>
        /// <param name="MathSigh">The operation.</param>
        /// <returns>Result of math operation</returns>
        public int Run(int input1, int input2, char MathSigh)
        {
            switch (MathSigh)
            {
                case '+': return input1 + input2;
                case '-': return input1 - input2;
                case '*': return input1 * input2;
                case '/': return input1 / input2;
                default:Console.WriteLine("Wrong sigh [" + MathSigh+"]");  return 0;
            }
        }
    }






     interface PluginFactory
    {
        int PluginsCount { get; }
        string[] GetPluginNames { get; }
        IPlugin GetPlugin(string pluginName);
    }

    class PlugFac : PluginFactory
    {
        public int PluginsCount => Counter.plugins.Count;

        public string[] GetPluginNames => Counter.names();

        public IPlugin GetPlugin(string pluginName)
        {
            return Counter.plugins.Find(x => x.PluginName == pluginName);
        }
    }
    /// <summary>
    /// Gets common information about created plugins.
    /// </summary>
    public class Plugins
    {
        PlugFac plugFac = new PlugFac();
        /// <summary>
        /// Get all plugins names
        /// </summary>
        public string[] GetNames() => plugFac.GetPluginNames;
        /// <summary>
        /// Get the number of all plugins.
        /// </summary>
        public int Count => plugFac.PluginsCount;
        /// <summary>
        /// Get the plugin by its name
        /// </summary>
        public Plugin GetPluginByName(string pluginName)
        {
            return Counter.plugins.Find(x => x.PluginName == pluginName);
        }

        
    }
}
