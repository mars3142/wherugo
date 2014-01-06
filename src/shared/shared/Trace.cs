//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011-2014 Peter Siegmund <developer@mars3142.org>
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
using System.IO;
using System.Reflection;

namespace org.mars3142.wherugo.shared
{
   public static class Trace
   {
      #region Declares

      /// <summary>
      /// 
      /// </summary>
      public enum TraceEventType
      {
         Critical,      // Fatal error or application crash
         Error,         // Recoverable error
         Information,   // Informational message
         Resume,        // Resumption of a logical operation
         Start,         // Starting of a logical operation
         Stop,          // Stopping of a logical operation
         Suspend,       // Suspension of a logical operation
         Transfer,      // Changing of correlation identity
         Verbose,       // Debugging trace
         Warning        // Noncritical problem
      }

      /// <summary>
      /// 
      /// </summary>
      public enum TraceCategories
      {
         Unhandled,
         Exception,
         WherugoApp,
         Cartridge,
         Communication,
         Control,
         Lua,
         Shared
      }

      #endregion // Declares

      #region Private

      private static void WriteException(StreamWriter stream, Exception exception, Int32 level)
      {
         stream.WriteLine(String.Format("{0:00}# {1}", level, exception.Message));
         if (exception.InnerException != null)
         {
            WriteException(stream, exception.InnerException, ++level);
         }
      }
      
      #endregion // Private

      /// <summary>
      /// 
      /// </summary>
      /// <param name="categories"></param>
      /// <param name="exception"></param>
      public static void DoTrace(TraceCategories categories, Exception exception)
      {
         DoTrace(categories, TraceEventType.Error, null, exception);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="categories"></param>
      /// <param name="message"></param>
      public static void DoTrace(TraceCategories categories, String message)
      {
         DoTrace(categories, TraceEventType.Information, message, null);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="categories"></param>
      /// <param name="eventType"></param>
      public static void DoTrace(TraceCategories categories, TraceEventType eventType)
      {
         DoTrace(categories, eventType, null, null);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="categories"></param>
      /// <param name="eventType"></param>
      /// <param name="exception"></param>
      public static void DoTrace(TraceCategories categories, TraceEventType eventType, Exception exception)
      {
         DoTrace(categories, eventType, null, exception);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="categories"></param>
      /// <param name="eventType"></param>
      /// <param name="message"></param>
      public static void DoTrace(TraceCategories categories, TraceEventType eventType, String message)
      {
         DoTrace(categories, eventType, message, null);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="categories"></param>
      /// <param name="eventType"></param>
      /// <param name="message"></param>
      /// <param name="exception"></param>
      public static void DoTrace(TraceCategories categories, TraceEventType eventType, String message, Exception exception)
      {
         String path = String.Empty;

#if WindowsCE
         path = @"\SDMMC\Wherugo\Log\";
#else
         path = String.Format("{0}\\", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
#endif
         StreamWriter stream = new StreamWriter(String.Format("{0}{1}", path , "trace.txt"), true);

         try
         {
            stream.WriteLine(String.Format("{0:yyyy-MM-dd HH:mm:ss} {1}: {2}", DateTime.Now, categories.ToString(), eventType.ToString()));
            if (message != null)
            {
               stream.WriteLine(message);
            }
            if (exception != null)
            {
               WriteException(stream, exception, 1);
               stream.WriteLine();
               stream.WriteLine("StackTrace:");
               stream.WriteLine(exception.StackTrace);
            }
            stream.WriteLine();
         }
         finally
         {
            stream.Close();
         }
      }
   }
}
