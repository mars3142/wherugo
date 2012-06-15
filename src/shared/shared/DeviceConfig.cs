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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace org.mars3142.wherugo.shared
{
   public class DeviceConfig
   {
      [DllImport("kernel32")]
      private static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);

      const String FILE_PATH = @"\HDD\APP\";
      const String FILE_NAME = @"Atlas.ini";

      #region Members
      /// <summary>
      /// Path and filename of ini-file
      /// </summary>
      public static String IniFile
      {
         get
         {
            return String.Format("{0}{1}", FILE_PATH, FILE_NAME);
         }
      }

      /// <summary>
      /// Path of the SD-Card
      /// </summary>
      public static String MediaRoot
      {
         get
         {
            return ReadKey("PATH", "MediaRoot");
         }
      }

      /// <summary>
      /// COM-Port of the GPS-receiver
      /// </summary>
      public static String PortName
      {
         get
         {
            return ReadKey("SIRF_STANDALONE", "COM");
         }
      }

      /// <summary>
      /// Baudrate of COM-Port
      /// </summary>
      public static String BaudRate
      {
         get
         {
            return Param(1);
         }
      }
      #endregion

      #region Private
      private static String Param(int index)
      {
         if (index <= 0)
         {
            throw new ArgumentOutOfRangeException("index", "Value have to be greater than zero.");
         }

         String retValue = String.Empty;
         String param = String.Empty;
         
         param = ReadKey("SIRF_STANDALONE", "Params");

         if (!String.IsNullOrEmpty(param))
         {
            String[] entries = param.Split(',');
            if (entries.Length <= index)
            {
               retValue = entries[index - 1];
            }
         }

         return retValue;
      }

      private static String ReadKey(String section, String key)
      {
         StringBuilder sb = new StringBuilder(255);
         try
         {
            GetPrivateProfileString(section, key, String.Empty, sb, sb.Length, IniFile);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Shared, Trace.TraceEventType.Error, ex);
         }
         return sb.ToString();
      }
      #endregion
   }
}
