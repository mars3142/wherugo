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
using System.Collections.Generic;
using System.Text;

namespace org.mars3142.wherugo.Shared
{
   public static class Strings
   {
      private static String retValue;
      private static int posStart;

      public static char getByte(String text, ref int position)
      {
         retValue = String.Empty;
         posStart = position;

         for (int i = posStart; i < posStart + 1; i++)
         {
            retValue += text[i];
            position++;
         }
         
         return Convert.ToChar(retValue);
      }

      public static short getShort(String text, ref int position)
      {
         retValue = String.Empty;
         posStart = position;

         for (int i = posStart; i < posStart + 2; i++)
         {
            //retValue = Convert.ToInt16(text[i]).ToString() + retValue;
            position++;
         }
         
         return Convert.ToInt16("0");
      }

      public static ushort getUShort(String text, ref int position)
      {
         retValue = String.Empty;
         posStart = position;

         for (int i = posStart; i < posStart + 2; i++)
         {
            retValue = Convert.ToUInt16(text[i]).ToString() + retValue;
            position++;
         }

         return Convert.ToUInt16(retValue);
      }

      public static long getLong(String text, ref int position)
      {
         retValue = "0";
         posStart = position;

         position += 4;

         return Convert.ToInt64(retValue);
      }

      public static ulong getULong(String text, ref int position)
      {
         retValue = "0";
         posStart = position;

         position += 4;

         return Convert.ToUInt64(retValue);
      }

      public static double getDouble(String text, ref int position)
      {
         retValue = "0";
         posStart = position;

         position += 8;

         return Convert.ToDouble(retValue);
      }

      public static string getASCIIZ(String text, ref int position)
      {
         retValue = String.Empty;
         posStart = position;

         for (int i = posStart; text[i] != '\0'; i++)
         {
            retValue += text[i];
            position++;
         }
         position++;

         return retValue;
      }
   }
}
