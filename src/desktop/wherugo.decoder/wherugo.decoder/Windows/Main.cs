//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011-2013 Peter Siegmund <developer@mars3142.org>
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
using System.Windows.Forms;

using org.mars3142.wherugo.cartridges;
using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.decoder.Windows
{
   public partial class Main : Form
   {
      File gwc = new File();

      public Main()
      {
         InitializeComponent();
         pbOpen.Text = Locale.GetString("open_gwc");
         pbObjects.Text = Locale.GetString("objects");
         fdGWC.Title = Locale.GetString("open_gwc_title");
         fdGWC.Filter = Locale.GetString("open_gwc_filter");
      }

      ~Main()
      {
         gwc = null;
      }

      private void pbOpen_Click(object sender, EventArgs e)
      {
         txContent.Text = String.Empty;
         imSplashScreen.Image = null;
         imSmallIcon.Image = null;

         if (fdGWC.ShowDialog() == DialogResult.OK)
         {
            gwc.Read(fdGWC.FileName);

            if (gwc.cartridge.SplashScreenId != -1)
            {
               byte[] data = gwc.cartridge.GetObject(gwc.cartridge.SplashScreenId).Data;
               if (data != null)
               {
                  ImageConverter ic = new ImageConverter();
                  Image splashImage = (Image)ic.ConvertFrom(data);
                  Bitmap splashScreen = new Bitmap(splashImage);
                  imSplashScreen.Image = splashScreen;
                  splashImage.Dispose();
               }
            }
            if (gwc.cartridge.SmallIconId != -1)
            {
               byte[] data = gwc.cartridge.GetObject(gwc.cartridge.SmallIconId).Data;
               if (data != null)
               {
                  ImageConverter ic = new ImageConverter();
                  Image smallImage = (Image)ic.ConvertFrom(data);
                  Bitmap smallIcon = new Bitmap(smallImage);
                  imSmallIcon.Image = smallIcon;
                  smallImage.Dispose();
               }
            }

            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("cartridge_name"), gwc.cartridge.CartridgeName);
            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("author"), gwc.cartridge.Author);
            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("version"), gwc.cartridge.Version);
            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("recommend_device"), gwc.cartridge.RecommendedDevice);
            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("start_location"), gwc.cartridge.StartLocationDesc);
            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("player_name"), gwc.cartridge.PlayerName);
            txContent.Text += String.Format("{0} ({1}): {2}\r\n", Locale.GetString("completion_code"), Locale.GetString("encrypted"), gwc.cartridge.CompletionCode);
            txContent.Text += String.Format("{0}: {1}\r\n", Locale.GetString("object_count"), gwc.cartridge.Obj().Count);
         }
      }

      private void pbObjects_Click(object sender, EventArgs e)
      {
         if (gwc.cartridge != null)
         {
            ObjectWindow _frm = new ObjectWindow(gwc);

            _frm.ShowDialog();
         }
      }
   }
}