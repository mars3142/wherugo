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
   public class Objects
   {
      #region Members
      private readonly short objectId;
      private readonly long address;
      private byte[] data;
      private long objectType;

      /// <summary>
      /// the unique key of the object
      /// </summary>
      public short ObjectId
      {
         get { return objectId; }
      }

      /// <summary>
      /// the adress in the cartridge-file
      /// </summary>
      public long Address
      {
         get { return address; }
      }

      /// <summary>
      /// bytecode of the object
      /// </summary>
      public byte[] Data
      {
         get { return data; }
      }

      /// <summary>
      /// objecttype of the bytecode
      /// </summary>
      public long ObjectType
      {
         get 
         {
            if (objectId != 0 && objectType == 0) // because of unknown data
            {
               return -1;
            }
            else
            {
               return objectType;
            }
         }
      }

      /// <summary>
      /// human readable objecttype
      /// </summary>
      public string ObjectTypeString
      {
         get
         {
            string type = String.Format("invalid ({0})", ObjectType);
            
            switch (ObjectType)
            {
               case -1: // unknown for some devices
                  type = "DELETED";
                  break;

               case 0:
                  type = "LUAC";
                  break;

               case 1:
                  type = "BMP";
                  break;

               case 2:
                  type = "PNG";
                  break;

               case 3:
                  type = "JPG";
                  break;

               case 4:
                  type = "GIF";
                  break;

               case 17:
                  type = "WAV";
                  break;

               case 18:
                  type = "MP3";
                  break;

               case 19:
                  type = "FDL";
                  break;
            }
            return type;
         }
      }
      #endregion

      #region Ctr
      public Objects(short objectId, long address)
      {
         this.objectId = objectId;
         this.address = address;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Read the object directly from the file
      /// </summary>
      /// <param name="binaryReader">filehandle</param>
      /// <returns>True, if no errors occured</returns>
      public bool LoadObject(BinaryReader binaryReader)
      {
         bool retValue = false;

         binaryReader.BaseStream.Seek(address, SeekOrigin.Begin);
         try
         {
            long length;
            if (objectId == 0)
            {
               length = SeekFile.GetLong(binaryReader);
               data = new byte[length];
               for (int i = 0; i < length; i++)
               {
                  data[i] = binaryReader.ReadByte();
               }
            }
            else
            {
               byte validObj = SeekFile.GetByte(binaryReader);
               if (validObj != 0)
               {
                  objectType = SeekFile.GetLong(binaryReader);
                  length = SeekFile.GetLong(binaryReader);
                  data = new byte[length];
                  for (int i = 0; i < length; i++)
                  {
                     data[i] = binaryReader.ReadByte();
                  }
               }
            }

            retValue = true;
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }

         return retValue;
      }
      #endregion
   }
}
