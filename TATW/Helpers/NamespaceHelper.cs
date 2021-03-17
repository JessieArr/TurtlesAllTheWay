using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TATW.Helpers
{
    public static class NamespaceHelper
    {
        public static string GetNamespaceFromPath(string path)
        {
            return path.Replace(Path.DirectorySeparatorChar, '.');
        }
    }
}
