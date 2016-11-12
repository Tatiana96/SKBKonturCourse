using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Task7StorageControl
{
    class BitmapEditor
    {
        private readonly Bitmap bitmapObject;
        private readonly BitmapData bitmapData;

        private bool isDisposed = false;

        public BitmapEditor(Bitmap bitmap)
        {
            bitmapObject = bitmap;
            Rectangle rectangleObject = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            bitmapData = bitmap.LockBits(rectangleObject, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        }

        ~BitmapEditor()
        {
            Dispose(false);
        }

        public void SetPixel(int x, int y, byte redColor, byte greenColor, byte blueColor)
        {
            int offset = 3 * x + y * bitmapData.Stride;
            Marshal.Copy(
                            new[] { blueColor, greenColor, redColor}, 
                            0, 
                            IntPtr.Add(bitmapData.Scan0, offset), 
                            3
                         );

        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool fromFinalize)
        {
            if (!isDisposed)
            {

                if (!fromFinalize)
                {
                    bitmapObject.UnlockBits(bitmapData);
                }
                isDisposed = true;

            }

        }

    }
}
