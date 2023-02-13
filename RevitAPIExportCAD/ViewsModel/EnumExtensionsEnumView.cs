using RevitAPIExportCAD.Model;
using System;

namespace RevitAPIExportCAD.ViewsModel
{
    static class EnumExtensionsEnumView
    {
        public static string ToDisplayString(EnumViewType value) 
        {
            switch (value) 
            {
                case EnumViewType.FloorPlaneView:
                    return "Floor Plan";
                case EnumViewType.StructuralView:
                    return "Structural Plan";
                case EnumViewType.CellingPlaneView:
                    return "Ceiling Plan";
                case EnumViewType.ElevationView:
                    return "Building Elevation";
                case EnumViewType.SectionView:
                    return "Building Sectionn";
                case EnumViewType.Schedule:
                    return "Schedule";
                case EnumViewType.DetailView:
                    return "Detail";
                case EnumViewType.WallSection:
                    return "Wall Section";
                case EnumViewType.SheetView:
                    return "Sheet";
                case EnumViewType.View3D:
                    return "3D View";
                default:
                    return value.ToString();
            }
        }
    }
}
