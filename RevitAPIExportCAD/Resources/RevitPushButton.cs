using Autodesk.Revit.UI;
using RevitAPIExportCAD.Model;
using RevitAPIExportCAD.Resources.Core;
using System;


namespace RevitAPIExportCAD.Resources
{
    public static class RevitPushButton
    {
        public static PushButton Create(RevitPushButtonDataModel data)
        {

            string btnDataName = Guid.NewGuid().ToString();

            var btnData = new PushButtonData(btnDataName, data.Label, CoreAssembly.GetAssemblyLocation(), data.CommandNamespacePath)
            {
                ToolTip = data.Tooltip,
                LargeImage = ResourceImage.GetIcon(data.IconImageName),
                ToolTipImage = ResourceImage.GetIcon(data.TooltipImageName),
            };

            return data.Panel.AddItem(btnData) as PushButton;
        }
    }
}
