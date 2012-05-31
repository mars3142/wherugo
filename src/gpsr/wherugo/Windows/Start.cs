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
      private GPS m_gps = new GPS();
      private Button m_btn = new Button();
      private Button m_btn2 = new Button();
      private TextBox m_txt = new TextBox();

      public Start()
      {
         try
         {
            InitializeComponent();

            m_btn.Text = "Exit";
            m_btn.Click += new EventHandler(btn_Click);
            Controls.Add(m_btn);

            m_btn2.Text = "StartGPS";
            m_btn2.Top = 20;
            m_btn2.Click += new EventHandler(btn2_Click);
            Controls.Add(m_btn2);

            m_txt.Top = 40;
            m_txt.Multiline = true;
            m_txt.Height = Screen.PrimaryScreen.Bounds.Height - 60;
            m_txt.Width = Screen.PrimaryScreen.Bounds.Width;
            Controls.Add(m_txt);

            m_gps.NewData += new GPS.NewDataEventHandler(gps_NewData);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Exception, ex);
         }
      }

      private void gps_NewData(object sender, GPSEventArgs e)
      {
         ScreenHelper.SetValue(ref m_txt, ScreenHelper.Property.Text, e.Data);
      }

      private void btn_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btn_Click");
         m_gps.StopGPS();
         Application.Exit();
      }

      private void btn2_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btn2_Click");
         m_gps.StartGPS();
      }
   }
}