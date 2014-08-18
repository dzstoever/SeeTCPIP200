// Copyright (c) 2003, Michael Mayer
// See License.txt that should have been included with this source file.
// or see http://www.mag37.com/projects/Printing/

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ReportPrinting
{
    /// <summary>
    /// Gets the page margin info - based on the following url:
    /// http://www.fawcette.com/vsm/2002_11/magazine/features/eaton/page5.aspx
    /// </summary>
    /// This is a sample of using this class to get a page bounds to be used for printing.
    /// <example>
    /// IntPtr hDc = e.Graphics.GetHdc();
    /// e.Graphics.ReleaseHdc(hDc);
    /// PrinterMarginInfo mi = new PrinterMarginInfo(hDc.ToInt32());
    /// Bounds pageBounds = mi.GetBounds (e.PageBounds, e.MarginBounds, scale);
    /// </example>
    class PrinterMarginInfo
    {

        [DllImport("gdi32.dll")]
        static extern Int16 GetDeviceCaps([In] 
            [MarshalAs (UnmanagedType.U4)] int hDc, [In] [MarshalAs (UnmanagedType.U2)] Int16 funct);
        float hardLeftMargin = 0;
        float hardTopMargin = 0;
        float hardRightMargin = 0;
        float hardBottomMargin = 0;
        const short HORZSIZE      = 4;
        const short VERTSIZE      = 6;
        const short HORZRES       = 8;
        const short VERTRES       = 10;
        const short PHYSICALOFFSETX = 112;
        const short PHYSICALOFFSETY = 113;

        /// <summary>
        /// The only constructer for this class
        /// </summary>
        /// <param name="deviceHandle">
        /// And int pointer, using a value returned from Graphics.GetHdc()
        /// </param>
        public PrinterMarginInfo(int deviceHandle) 
        {
            float offx = Convert.ToSingle(
                GetDeviceCaps(deviceHandle, 
                PHYSICALOFFSETX));
            float offy = Convert.ToSingle(
                GetDeviceCaps(deviceHandle, 
                PHYSICALOFFSETY));
            float resx = Convert.ToSingle(
                GetDeviceCaps(deviceHandle, HORZRES));
            float resy = Convert.ToSingle(
                GetDeviceCaps(deviceHandle, VERTRES));
            float hsz = Convert.ToSingle(
                GetDeviceCaps(deviceHandle, HORZSIZE))/25.4f;
            float vsz = Convert.ToSingle(
                GetDeviceCaps(deviceHandle,VERTSIZE))/25.4f;
            float ppix = resx/hsz;
            float ppiy = resy/vsz;
            hardLeftMargin  = (offx/ppix) * 100.0f;
            hardTopMargin   = (offy/ppix) * 100.0f;
            hardBottomMargin  = hardTopMargin + (vsz * 100.0f);
            hardRightMargin  = hardLeftMargin + (hsz * 100.0f);
        }


        /// <summary>
        /// The 
        /// </summary>
        /// <param name="pageRectangle"></param>
        /// <param name="desiredMargins"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public Bounds GetBounds (Rectangle pageRectangle, Rectangle desiredMargins,
            float scale)
        {
            // take the hard margins into account by using them simply
            // as an offset that the print would apply...
            float leftMargin = desiredMargins.Left - hardLeftMargin;
            float topMargin = desiredMargins.Top - hardTopMargin;
            float rightMargin = desiredMargins.Right - hardLeftMargin;
            float bottomMargin = desiredMargins.Bottom - hardTopMargin;

            leftMargin *= scale;
            topMargin *= scale;
            rightMargin *= scale;
            bottomMargin *= scale;

            Bounds pageBounds = new Bounds(leftMargin, topMargin, rightMargin, bottomMargin);
            return pageBounds;
        }


    }

}
