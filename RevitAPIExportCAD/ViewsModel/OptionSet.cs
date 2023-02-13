using Autodesk.Revit.DB;
using System;


namespace RevitAPIExportCAD.ViewsModel
{
    public static class OptionSet
    {
        public static ExportColorMode SetColorMode(params bool[] b)
        {

            ExportColorMode[] arr = { ExportColorMode.IndexColors,ExportColorMode.TrueColor,ExportColorMode.TrueColorPerView};
            for(int i = 0; i < b.Length;i++) 
            {
                if (b[i])
                {
                    return arr[i];
                }
            }

            return ExportColorMode.IndexColors;
        }
        public static SolidGeometry SetSolidMode(params bool[] b)
        {

            SolidGeometry[] arr = { SolidGeometry.Polymesh, SolidGeometry.ACIS };
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i])
                {
                    return arr[i];
                }
            }

            return SolidGeometry.Polymesh;
        }
    }
}
