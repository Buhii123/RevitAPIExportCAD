using System;
using System.Reflection;

namespace RevitAPIExportCAD.Resources.Core
{
    public static class CoreAssembly
    {
        public static string GetAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
}
