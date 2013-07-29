//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011-2013 Peter Siegmund <developer@mars3142.org>
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

using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.cartridges
{
   public class File
   {
      #region Members

      #region Private
      
      private readonly byte[] cartId = { 0x02, 0x0a, 0x43, 0x41, 0x52, 0x54, 0x00 };  // 02 0a CART 00 

      private BinaryReader binaryReader;
      private String filePath;
      private FileStream fileStream;

      #endregion

      /// <summary>
      /// Data of the cartridge
      /// </summary>
      public Cartridge cartridge = null;

      #endregion

      #region Methods

      #region Private

      /// <summary>
      /// Checks, if the file has the desired format
      /// </summary>
      /// <returns>True, if file format is correct</returns>
      private Boolean FileOk()
      {
         bool retValue = true;

         try
         {
            fileStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < cartId.Length; i++)
            {
               if (Convert.ToChar(binaryReader.Read()) != cartId[i])
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

      #endregion

      /// <summary>
      /// Read the file and generate a cartridge, if the format is correct
      /// </summary>
      /// <param name="fileName">filename of cartridge</param>
      /// <returns>True, if cartridge is opened</returns>
      public Boolean Read(String fileName)
      {
         Boolean retValue = false;

         filePath = Path.GetDirectoryName(fileName);
         fileStream = new FileStream(fileName, FileMode.Open);
         try
         {  
            binaryReader = new BinaryReader(fileStream);

            if (FileOk())
            {
               cartridge = new Cartridge(binaryReader);
               cartridge.FilePath = filePath;
               retValue = true;
            }
         }

         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }
         finally
         {
            fileStream.Close();
         }
         return retValue;
      }

      #endregion
   }
}
