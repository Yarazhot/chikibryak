using System;
using System.Collections.Generic;
using System.Text;

namespace PluginBase
{
    public interface IPlagin
    {
        string Name { get; }
        void EncodeFile(string path);

        void DecodeFile(string path);
    }

}
