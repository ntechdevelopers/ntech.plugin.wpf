using MEF.Launcher.Contract;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MEF.Launcher.Manager
{
    [Export(typeof(IPluginManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class PluginManager : IPluginManager
    {
        /// <summary>
        /// Gets or sets plugin.
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<IPlugin> Plugins { get; set; }

        /// <summary>
        /// Loads the plugin.
        /// </summary>
        public void LoadPlugin()
        {
            foreach (var plugin in this.Plugins)
            {
                plugin.InitPlugin();
            }
        }

        /// <summary>
        /// Unloads the plugin.
        /// </summary>
        public void UnloadPlugin()
        {
            foreach (var plugin in this.Plugins)
            {
                plugin.UninitPlugin();
            }
        }
    }
}
