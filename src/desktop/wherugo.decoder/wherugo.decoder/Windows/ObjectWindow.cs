using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using org.mars3142.wherugo.Cartridges;

namespace org.mars3142.wherugo.decoder.Windows
{
   public partial class ObjectWindow : Form
   {
      File _gwc = null;

      public ObjectWindow(File gwc)
      {
         InitializeComponent();
         _gwc = gwc;
         InitializeData();
      }

      private void InitializeData()
      {
         lbObject.Items.Clear();
         foreach (KeyValuePair<short, Objects> pair in _gwc.cartridge.Obj())
         {
            lbObject.Items.Add(String.Format("{0} ({1})", pair.Value.ObjectId, pair.Value.ObjectTypeString));
         }
      }

      private void lbObject_SelectedIndexChanged(object sender, EventArgs e)
      {
         short Id;
         Objects obj;

         Id = Convert.ToInt16(lbObject.SelectedItem.ToString().Split(' ')[0]);
         obj = _gwc.cartridge.GetObject(Id);
         if (obj.ObjectType >= 1 && obj.ObjectType <= 4)
         {
            ImageConverter ic = new ImageConverter();
            Image objImage = (Image)ic.ConvertFrom(obj.Data);
            Bitmap objBitmap = new Bitmap(objImage);
            pbImage.Image = objBitmap;
         }
         else
         {
            pbImage.Image = null;
         }
      }
   }
}