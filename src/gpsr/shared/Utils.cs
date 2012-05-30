//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011-2012 Peter Siegmund <developer@mars3142.org>
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace org.mars3142.wherugo.shared
{
   public class Utils
   {
      public static Bitmap CaptureScreen()
      {
         Bitmap bitmap = null;
         Graphics graphics;

         try
         {
            bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            graphics.Dispose();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Shared, Trace.TraceEventType.Error, ex);
         }
         return bitmap;
      }

      public static void SaveScreenshot()
      {
         try
         {
            CaptureScreen().Save(@"\Test.png", ImageFormat.Png);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Shared, Trace.TraceEventType.Error, ex);
         }
      }
   }
}