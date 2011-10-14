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
using System.Text;
using org.mars3142.wherugo.Shared;

namespace org.mars3142.wherugo.Cartridges
{
   public class File
   {
      private byte[] CART_ID = { 0x02, 0x0a, 0x43, 0x41, 0x52, 0x54, 0x00 };	// 02 0a CART 00 

      private String _content = null;
      private int _position = 0;

      private Boolean FileOk()
      {
         for (_position = 0; _position < CART_ID.Length; _position++)
            if (_content[_position] != CART_ID[_position])
               return false;

         return true;
      }

      public Boolean Read(String fileName)
      {
         StreamReader sr = null;

         try
         {
            _content = null;

            sr = new StreamReader(fileName);
            _content += sr.ReadToEnd();
            sr.Close();

            if (FileOk()) 
            {
               ushort i = Strings.GetUShort(_content, ref _position);
               for (int i2 = 0; i2 < i; i2++)
               {
                  short objectId = Strings.GetShort(_content, ref _position);
                  long address = Strings.GetLong(_content, ref _position);
               }
            }

            long headerLenght = Strings.GetLong(_content, ref _position);
            Header header = new Header(_content, ref _position);
         }

         catch (Exception ex)
         {
            throw new FileException("Error in org.mars3142.wherugo.Cartridges.File.Open()", ex);
         }
         finally
         {
            sr.Close();
         }
         return true;
      }
   }
}
