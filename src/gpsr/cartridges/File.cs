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

namespace org.mars3142.wherugo.Cartridges
{
   public class File
   {
      private readonly byte[] _cartId = { 0x02, 0x0a, 0x43, 0x41, 0x52, 0x54, 0x00 };  // 02 0a CART 00 

      private BinaryReader _binaryReader;
      private FileStream _fileStream;

      public Cartridge cartridge = null;

      private Boolean FileOk()
      {
         bool retValue = true;

         try
         {
            _fileStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < _cartId.Length; i++)
            {
               if (Convert.ToChar(_binaryReader.Read()) != _cartId[i])
               {
                  retValue = false;
               }
            }
         }
         catch(Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="fileName"></param>
      /// <returns></returns>
      public Boolean Read(String fileName)
      {
         _fileStream = new FileStream(fileName, FileMode.Open);
         try
         {  
            _binaryReader = new BinaryReader(_fileStream);

            if (FileOk())
            {
               cartridge = new Cartridge(_binaryReader);
               foreach (Objects obj in cartridge.Objects.Values)
               {
                  obj.LoadObject(_binaryReader);
               }
            }
         }

         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }
         finally
         {
            _fileStream.Close();
         }
         return true;
      }
   }
}
