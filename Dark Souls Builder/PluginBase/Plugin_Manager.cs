using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginBase
{
    public class Plugin_Manager
    {
        public List<IPlagin> Plugins = new List<IPlagin>();

        public void ScanPlugins(string directory)
        {
            //перебирвем все файлы dll
            foreach (var file in Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories))
                try
                {
                    //загружаем ассемблю
                    var ass = Assembly.LoadFile(file);
                    //перебираем все типы из ассембли
                    foreach (var type in ass.GetTypes())
                    {
                        //проверяем наличие интерфейса IPlugin
                        var i = type.GetInterface("IPlagin");
                        if (i != null)
                        {
                            //создаем экземпляр плагина
                            bool a = true;
                            foreach (var plugin in this.Plugins)
                                if (plugin.GetType().Name == type.Name)
                                    a = false;
                            if (a)
                                Plugins.Add(ass.CreateInstance(type.FullName) as IPlagin);
                        }
                    }
                }
                catch {/*is not .NET assembly*/}
        }
    }
}
