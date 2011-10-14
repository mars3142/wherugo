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

namespace org.mars3142.wherugo.Shared
{
   public static class Strings
   {
      private static String _retValue;
      private static int _posStart;

      public static char GetByte(String text, ref int position)
      {
         _retValue = String.Empty;
         _posStart = position;

         for (int i = _posStart; i < _posStart + 1; i++)
         {
            _retValue += text[i];
            position++;
         }
         
         return Convert.ToChar(_retValue);
      }

      public static short GetShort(String text, ref int position)
      {
         _retValue = String.Empty;
         _posStart = position;

         for (int i = _posStart; i < _posStart + 2; i++)
         {
            //retValue = Convert.ToInt16(text[i]).ToString() + retValue;
            position++;
         }
         
         return Convert.ToInt16("0");
      }

      public static ushort GetUShort(String text, ref int position)
      {
         _retValue = String.Empty;
         _posStart = position;

         for (int i = _posStart; i < _posStart + 2; i++)
         {
            _retValue = Convert.ToUInt16(text[i]).ToString() + _retValue;
            position++;
         }

         return Convert.ToUInt16(_retValue);
      }

      public static long GetLong(String text, ref int position)
      {
         _retValue = "0";
         _posStart = position;

         position += 4;

         return Convert.ToInt64(_retValue);
      }

      public static ulong GetULong(String text, ref int position)
      {
         _retValue = "0";
         _posStart = position;

         position += 4;

         return Convert.ToUInt64(_retValue);
      }

      public static double GetDouble(String text, ref int position)
      {
         _retValue = "0";
         _posStart = position;

         position += 8;

         return Convert.ToDouble(_retValue);
      }

      public static string GetASCIIZ(String text, ref int position)
      {
         _retValue = String.Empty;
         _posStart = position;

         for (int i = _posStart; text[i] != '\0'; i++)
         {
            _retValue += text[i];
            position++;
         }
         position++;

         return _retValue;
      }
   }
}
