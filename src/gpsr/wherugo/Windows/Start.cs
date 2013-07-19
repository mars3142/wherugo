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

using org.mars3142.wherugo.communication;
using org.mars3142.wherugo.controls;
using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.Windows
{
   public partial class Start : Form
   {
      private GPS m_gps = new GPS();
      private Button m_btnExit = new Button();
      private Button m_btnStart = new Button();
      private Button m_btnStop = new Button();
      private TextBox m_txt = new TextBox();

      public Start()
      {
         try
         {
            InitializeComponent();

            m_btnExit.Text = "Exit";
            m_btnExit.Click += new EventHandler(btnExit_Click);
            Controls.Add(m_btnExit);

            m_btnStart.Text = "StartGPS";
            m_btnStart.Top = 20;
            m_btnStart.Click += new EventHandler(btnStart_Click);
            Controls.Add(m_btnStart);

            m_btnStop.Text = "StopGPS";
            m_btnStop.Top = m_btnStart.Top;
            m_btnStop.Left = m_btnStart.Width + 5;
            m_btnStop.Click += new EventHandler(btnStop_Click);
            Controls.Add(m_btnStop);

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
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "gps_NewData");
         ScreenHelper.SetValue(m_txt, ScreenHelper.Property.Text, e.Data);
      }

      private void btnExit_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btnExit_Click");
         Application.Exit();
      }

      private void btnStart_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btnStart_Click");
         m_gps.StartGPS();
      }

      private void btnStop_Click(object sender, System.EventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, "btnStop_Click");
         m_gps.StopGPS();
      }
   }
}