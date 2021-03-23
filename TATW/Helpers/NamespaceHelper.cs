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

        public static string GetNamespaceFromFullTypeName(string typeName)
        {
            if(!typeName.Contains("."))
            {
                return "";
            }
            else
            {
                return typeName.Substring(0, typeName.LastIndexOf("."));
            }
        }

        public static string GetTypeFromFullTypeName(string typeName)
        {
            if (!typeName.Contains("."))
            {
                return typeName;
            }
            else
            {
                return typeName.Substring(typeName.LastIndexOf(".") + 1);
            }
        }
    }
}
