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
using System.Windows.Forms;
using org.mars3142.wherugo.Cartridges;

namespace org.mars3142.wherugo.decoder.Windows
{
   public partial class Main : Form
   {
      File _gwc = new File();

      public Main()
      {
         InitializeComponent();
      }

      ~Main()
      {
         _gwc = null;
      }

      private void pbOpen_Click(object sender, EventArgs e)
      {
         txContent.Text = String.Empty;
         imSplashScreen.Image = null;
         imSmallIcon.Image = null;

         if (fdGWC.ShowDialog() == DialogResult.OK)
         {
            _gwc.Read(fdGWC.FileName);

            if (_gwc.cartridge.SplashScreenId != -1)
            {
               byte[] data = _gwc.cartridge.GetObject(_gwc.cartridge.SplashScreenId).Data;
               if (data != null)
               {
                  ImageConverter ic = new ImageConverter();
                  Image splashImage = (Image)ic.ConvertFrom(data);
                  Bitmap splashScreen = new Bitmap(splashImage);
                  imSplashScreen.Image = splashScreen;
                  splashImage.Dispose();
               }
            }
            if (_gwc.cartridge.SmallIconId != -1)
            {
               byte[] data = _gwc.cartridge.GetObject(_gwc.cartridge.SmallIconId).Data;
               if (data != null)
               {
                  ImageConverter ic = new ImageConverter();
                  Image smallImage = (Image)ic.ConvertFrom(data);
                  Bitmap smallIcon = new Bitmap(smallImage);
                  imSmallIcon.Image = smallIcon;
                  smallImage.Dispose();
               }
            }

            txContent.Text += String.Format("Name: {0}\r\n", _gwc.cartridge.CatridgeName);
            txContent.Text += String.Format("Author: {0}\r\n", _gwc.cartridge.Author);
            txContent.Text += String.Format("Version: {0}\r\n", _gwc.cartridge.Version);
            txContent.Text += String.Format("Recommend Device: {0}\r\n", _gwc.cartridge.RecommendedDevice);
            txContent.Text += String.Format("Start Location: {0}\r\n", _gwc.cartridge.StartLocationDesc);
            txContent.Text += String.Format("Player Name: {0}\r\n", _gwc.cartridge.PlayerName);
            txContent.Text += String.Format("Completion Code (encrypted): {0}\r\n", _gwc.cartridge.CompletionCode);
            txContent.Text += String.Format("Object count: {0}\r\n", _gwc.cartridge.Obj().Count);
         }
      }

      private void bpObjects_Click(object sender, EventArgs e)
      {
         if (_gwc.cartridge != null)
         {
            ObjectWindow _frm = new ObjectWindow(_gwc);

            _frm.ShowDialog();
         }
      }
   }
}