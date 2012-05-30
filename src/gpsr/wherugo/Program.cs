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

using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo
{
   internal static class Program
   {
      [MTAThread]
      private static void Main()
      {
         AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, Trace.TraceEventType.Start);
         Windows.Start startForm = new Windows.Start();
         Application.Run(startForm);
         Trace.DoTrace(Trace.TraceCategories.WherugoApp, Trace.TraceEventType.Stop);
      }

      private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
      {
         try
         {
            Exception ex = (Exception) e.ExceptionObject;
            Trace.DoTrace(Trace.TraceCategories.Exception, ex);
         }
         finally
         {
            Application.Exit();
         }
      }
   }
}