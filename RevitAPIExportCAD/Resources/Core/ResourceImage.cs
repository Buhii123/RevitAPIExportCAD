using System.IO;
using System.Windows.Media.Imaging;


namespace RevitAPIExportCAD.Resources.Core
{
    public static class ResourceImage
    {
        public static BitmapImage GetIcon(string name)
        {
            Stream stream = ResourceAssembly.GetAssembly().GetManifestResourceStream(ResourceAssembly.GetNamespace() + "Images." + name);

            BitmapImage imge = new BitmapImage();

            imge.BeginInit();

            imge.StreamSource = stream;

            imge.EndInit();

            return imge;
        }
    }
}
