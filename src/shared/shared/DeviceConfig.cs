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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace org.mars3142.wherugo.shared
{
   public class DeviceConfig
   {
      #region Declares

#if WindowsCE
      const String FILE_PATH = @"\HDD\APP\";
#else
      const String FILE_PATH = @".\";
#endif
      const String FILE_NAME = @"atlas.ini";

      #endregion // Declares

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
      #endregion // Members

      #region Private
      private static void GetPrivateProfileString(String section, String key, String defaultValue, StringBuilder sb)
      {
         String line = String.Empty;
         String sec = String.Empty;
         String[] value;

         StreamReader stream = new StreamReader(IniFile);

         try
         {
            while (!stream.EndOfStream)
            {
               line = stream.ReadLine().Trim();
               if (line.Length != 0)
               {
                  switch (line[0])
                  {
                     case ';':
                        // ignore comments
                        break;
                     case '[':
                        sec = line.Substring(1, line.Length - 2);
                        break;
                     default:
                        if (sec == section)
                        {
                           value = line.Split('=');
                           if (value[0].Trim() == key)
                           {
                              sb.Append(value[1].Trim());
                           }
                        }
                        break;
                  }
               }
               if (sb.Length != 0)
               {
                  break;
               }
            }
            if (sb.Length != 0)
            {
               sb.Append(defaultValue);
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Shared, Trace.TraceEventType.Error, ex);
         }
         finally
         {
            stream.Close();
         }
      }

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
            if (entries.Length >= index)
            {
               retValue = entries[index - 1];
            }
            else
            {
               throw new ArgumentOutOfRangeException("index", String.Format("Value have to be between 1 to {0}", entries.Length));
            }
         }

         return retValue;
      }

      private static String ReadKey(String section, String key)
      {
         StringBuilder sb = new StringBuilder();
         try
         {
            GetPrivateProfileString(section, key, String.Empty, sb);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Shared, Trace.TraceEventType.Error, ex);
         }
         return sb.ToString();
      }
      #endregion // Private
   }
}
