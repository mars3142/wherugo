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
using System.Windows.Forms;

using org.mars3142.wherugo.decoder.Windows;
using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.decoder
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
         
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Main());
      }

      static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
      {
         try
         {
            Exception ex = (Exception)e.ExceptionObject;
            Trace.DoTrace(Trace.TraceCategories.Unhandled, Trace.TraceEventType.Critical, ex);
         }
         finally
         {
            Application.Exit();
         }
      }
   }
}