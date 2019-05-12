using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ConsoleApp346
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ScreenCapture();

        }

        static void ScreenCapture()
        {
            Rectangle bounds = Screen.GetBounds(System.Drawing.Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(0, 0, bounds.X, bounds.Y, bitmap.Size);
                    //g.CopyFromScreen(System.Drawing.Point.Empty, System.Drawing.Point.Empty, bounds.Size);
                }
                string fullName = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".jpg";
                bitmap.Save(fullName, ImageFormat.Jpeg);
            }
        }
    }   
}
