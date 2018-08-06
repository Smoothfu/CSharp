using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp251
{
    public interface IDrawable
    {
        void Draw();
    }

    public interface IAdvancedDraw:IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    public class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Drawing....");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Simple Interface Hierarchy*****");

            //call from object level
            BitmapImage bm = new BitmapImage();
            bm.Draw();
            bm.DrawInBoundingBox(10, 10, 100, 150);
            bm.DrawUpsideDown();


            //Get IAdvancedDraw explicitly
            IAdvancedDraw iAdvDraw = bm as IAdvancedDraw;
            if(iAdvDraw!=null)
            {
                iAdvDraw.DrawUpsideDown();
            }
            Console.ReadLine();
        }
    }
}
