using Autodesk.Revit.UI;
using System;

namespace RevitAPIExportCAD.ApplicationRevitUI
{
    internal class MainAppInterface : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var ui = new DataAppSetupInterface(application);
            ui.InitializeSetupButton();
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}
