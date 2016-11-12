using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;


namespace Task7StorageControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var timerObject = new Timer();
            var bitmap = (Bitmap)Bitmap.FromFile("TestImage.jpg");

            using ( timerObject.Start() )
            {
                using (var bitmapEditor = new BitmapEditor(bitmap))
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            bitmapEditor.SetPixel(x, y, 255, 255, 0); // yellow
                        }
                    }
                }
            }

            Console.WriteLine("First part: " + timerObject.ElapsedMilliseconds);


            using ( timerObject.Start() )
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        bitmap.SetPixel(x, y, 128, 128, 128); // gray
                    }
                }
            }

            Console.WriteLine("Second part: " + timerObject.ElapsedMilliseconds);

        }
    }
}
