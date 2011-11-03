//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011 Peter Siegmund <developer@mars3142.org>
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;

using org.mars3142.wherugo.Shared;

namespace org.mars3142.wherugo.Shared
{
   public static class SeekFile
   {
      private static String _tempValue;
      private static int _posStart;

      public static byte GetByte(BinaryReader binaryReader)
      {
         byte retValue = 0;

         try
         {
            retValue = binaryReader.ReadByte();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      public static short GetShort(BinaryReader binaryReader)
      {
         short retValue = 0;

         try
         {
            retValue = binaryReader.ReadInt16();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      public static ushort GetUShort(BinaryReader binaryReader)
      {
         ushort retValue = 0;

         try
         {
            retValue = binaryReader.ReadUInt16();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      public static long GetLong(BinaryReader binaryReader)
      {
         long retValue = 0;

         try
         {
            retValue = binaryReader.ReadInt32();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      public static ulong GetULong(BinaryReader binaryReader)
      {
         ulong retValue = 0;

         try
         {
            retValue = binaryReader.ReadUInt32();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      public static double GetDouble(BinaryReader binaryReader)
      {
         double retValue = 0;

         try
         {
            retValue = binaryReader.ReadDouble();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      public static string GetASCIIZ(BinaryReader binaryReader)
      {
         string retValue = String.Empty;
         char temp = ' ';

         try
         {
            while (temp != '\0')
            {
               temp = binaryReader.ReadChar();
               if (temp != '\0')
               {
                  retValue += temp;
               }
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }
   }
}