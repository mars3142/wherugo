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

using org.mars3142.wherugo.communication;
using org.mars3142.wherugo.controls;
using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.Windows
{
   public partial class Start : Form
   {
      GPS gps = new GPS();

      public Start()
      {
         try
         {
            InitializeComponent();

            Button btn = new Button();
            btn.Click += btn_Click;
            Controls.Add(btn);

            Button btn2 = new Button();
            btn2.Top = 20;
            btn2.Click += btn2_Click;
            Controls.Add(btn2);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Exception, ex);
         }
      }

      void btn_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btn_Click");
         Application.Exit();
      }

      void btn2_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btn2_Click");
         gps.StartGPS();
      }
   }
}