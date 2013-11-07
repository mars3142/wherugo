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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using org.mars3142.wherugo.cartridges;
using org.mars3142.wherugo.shared;
using System.Runtime.Serialization.Formatters.Binary;

namespace org.mars3142.wherugo.decoder.Windows
{
   public partial class ObjectWindow : Form
   {
      File gwc = null;

      public ObjectWindow(File gwc)
      {
         InitializeComponent();
         this.Text = Locale.GetString("objectwindow");
         this.pmnItems.Items["mnExportItem"].Text = Locale.GetString("export_item");
         this.pmnItems.Items["mnExportItems"].Text = Locale.GetString("export_items");
         this.gwc = gwc;
         InitializeData();
      }

      private void InitializeData()
      {
         lbObject.Items.Clear();

         try
         {
            foreach (KeyValuePair<short, Objects> pair in gwc.cartridge.Obj())
            {
               if (pair.Value.Data != null)
               {
                  lbObject.Items.Add(String.Format("{0} ({1} - {2:#,###} Bytes)", pair.Value.ObjectId, pair.Value.ObjectTypeString, pair.Value.Data.Length));
               }
               else
               {
                  lbObject.Items.Add(String.Format("{0} ({1})", pair.Value.ObjectId, pair.Value.ObjectTypeString));
               }
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.WherugoApp, ex);
         }
      }

      private void lbObject_SelectedIndexChanged(object sender, EventArgs e)
      {
         short id;
         Objects obj;

         pbImage.Image = null;

         try
         {
            id = Convert.ToInt16(lbObject.SelectedItem.ToString().Split(' ')[0]);
            obj = gwc.cartridge.GetObject(id);
            if (obj.ObjectType >= 1 && obj.ObjectType <= 4)
            {
               ImageConverter ic = new ImageConverter();
               Image objImage = (Image)ic.ConvertFrom(obj.Data);
               Bitmap objBitmap = new Bitmap(objImage);
               pbImage.Image = objBitmap;
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.WherugoApp, ex);
         }
      }

      private void mnExportItem_Click(object sender, EventArgs e)
      {
         try
         {
            short id = Convert.ToInt16(lbObject.SelectedItem.ToString().Split(' ')[0]);
            ExportItem(id);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.WherugoApp, ex);
         }
         finally
         {
            MessageBox.Show(Locale.GetString("export_finished"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      private void mnExportItems_Click(object sender, EventArgs e)
      {
         try
         {
            for (short id = 0; id < gwc.cartridge.Obj().Count; id++)
            {
               ExportItem(id);
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.WherugoApp, ex);
         }
         finally
         {
            MessageBox.Show(Locale.GetString("export_finished"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      private void ExportItem(short id)
      {
         Objects obj;
         System.IO.FileStream file;

         try
         {
            obj = gwc.cartridge.GetObject(id);
            file = new System.IO.FileStream(String.Format("{0}\\obj_{1:000}.{2}", gwc.cartridge.FilePath, id, obj.ObjectTypeString), System.IO.FileMode.Create);
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(file);
            writer.Write(obj.Data);
            writer.Flush();
            writer.Close();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.WherugoApp, ex);
         }
      }
   }
}