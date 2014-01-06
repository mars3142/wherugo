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
using System.Data;
using System.Collections.Generic;
using System.IO;

using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.cartridges
{
   public class Cartridge
   {
      #region Members

      #region Private

      private readonly Dictionary<short, Objects> objects;

      private readonly double altitude;
      private readonly string author;
      private readonly string cartridgeDesc;
      private readonly string cartridgeGuid;
      private readonly string cartridgeName;
      private readonly string company;
      private readonly string completionCode;
      private string filepath;
      private readonly double latitude;              // N+/S-
      private readonly double longitude;             // E+/W-
      private readonly bool ok;
      private readonly string playerName;            //  name of player who downloaded this cartridge
      private readonly string recommendedDevice;
      private readonly short smallIconId;            // -1 = without
      private readonly short splashScreenId;         // -1 = without
      private readonly string startLocationDesc;
      private readonly string typeOfCartridge;       // "Tour guide", "Wherigo cache", etc.
      private readonly long unknown0;
      private readonly long unknown1;
      private readonly long unknown2;
      private readonly long unknown3;
      private readonly long unknown4;
      private readonly string version;
      
      #endregion

      /// <summary>
      /// filename
      /// </summary>
      public string FilePath
      {
         get { return filepath; }
         set { filepath = value; }
      }

      /// <summary>
      /// altitude
      /// </summary>
      public double Altitude
      {
         get { return altitude; }
      }

      /// <summary>
      /// author name
      /// </summary>
      public string Author
      {
         get { return author; }
      }

      /// <summary>
      /// latitude of the start position
      /// </summary>
      public double Latitude
      {
         get { return latitude; }
      }

      /// <summary>
      /// human readable latitude of start position
      /// </summary>
      public String LatitudeHuman
      {
         get { return Geo.FromDouble(latitude).ToString("NS"); }
      }

      /// <summary>
      /// longitude of the startposition
      /// </summary>
      public double Longitude
      {
         get { return longitude; }
      }

      /// <summary>
      /// human readable longitude of start position
      /// </summary>
      public String LongitudeHuman
      {
         get { return Geo.FromDouble(longitude).ToString("WE"); }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown0
      {
         get { return unknown0; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown1
      {
         get { return unknown1; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown2
      {
         get { return unknown2; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown3
      {
         get { return unknown3; }
      }

      /// <summary>
      /// objectid of the splashscreen object (-1 not exists)
      /// </summary>
      public short SplashScreenId
      {
         get { return splashScreenId; }
      }

      /// <summary>
      /// objectid of the smallicon object (-1 not exists)
      /// </summary>
      public short SmallIconId
      {
         get { return smallIconId; }
      }

      /// <summary>
      /// type of the cartridge
      /// </summary>
      public string TypeOfCartridge
      {
         get { return typeOfCartridge; }
      }

      /// <summary>
      /// playername (downloader of file)
      /// </summary>
      public string PlayerName
      {
         get { return playerName; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown4
      {
         get { return unknown4; }
      }

      /// <summary>
      /// cartridgename
      /// </summary>
      public string CartridgeName
      {
         get { return cartridgeName; }
      }

      /// <summary>
      /// unique guid of cartridge
      /// </summary>
      public string CartridgeGuid
      {
         get { return cartridgeGuid; }
      }

      /// <summary>
      /// cartridge description
      /// </summary>
      public string CartridgeDesc
      {
         get { return cartridgeDesc; }
      }

      /// <summary>
      /// startlocation description
      /// </summary>
      public string StartLocationDesc
      {
         get { return startLocationDesc; }
      }

      /// <summary>
      /// cartridge version
      /// </summary>
      public string Version
      {
         get { return version; }
      }

      /// <summary>
      /// companyname (?)
      /// </summary>
      public string Company
      {
         get { return company; }
      }

      /// <summary>
      /// recommended device for that cartridge
      /// </summary>
      public string RecommendedDevice
      {
         get { return recommendedDevice; }
      }

      /// <summary>
      /// encrypted completioncode
      /// </summary>
      public string CompletionCode
      {
         get { return completionCode; }
      }

      /// <summary>
      /// cartridgefile is valid
      /// </summary>
      public bool Ok
      {
         get { return ok; }
      }

      #endregion

      #region Ctr
      /// <summary>
      /// 
      /// </summary>
      /// <param name="binaryReader"></param>
      public Cartridge(BinaryReader binaryReader)
      {
         try
         {
            objects = new Dictionary<short, Objects>();
            ok = false;

            ushort count = SeekFile.GetUShort(binaryReader);
            for (int i = 0; i < count; i++)
            {
               short objectId = SeekFile.GetShort(binaryReader);
               long address = SeekFile.GetLong(binaryReader);
               Objects obj = new Objects(objectId, address);
               objects.Add(obj.ObjectId, obj);
            }

            long headerLenght = SeekFile.GetLong(binaryReader);

            latitude = SeekFile.GetDouble(binaryReader);
            longitude = SeekFile.GetDouble(binaryReader);
            altitude = SeekFile.GetDouble(binaryReader);
            
            unknown0 = SeekFile.GetLong(binaryReader);
            unknown1 = SeekFile.GetLong(binaryReader);

            splashScreenId = SeekFile.GetShort(binaryReader);
            smallIconId = SeekFile.GetShort(binaryReader);

            typeOfCartridge = SeekFile.GetASCIIZ(binaryReader);
            playerName = SeekFile.GetASCIIZ(binaryReader);

            unknown2 = SeekFile.GetLong(binaryReader);
            unknown3 = SeekFile.GetLong(binaryReader);

            cartridgeName = SeekFile.GetASCIIZ(binaryReader);
            cartridgeGuid = SeekFile.GetASCIIZ(binaryReader);
            cartridgeDesc = SeekFile.GetASCIIZ(binaryReader);
            startLocationDesc = SeekFile.GetASCIIZ(binaryReader);
            version = SeekFile.GetASCIIZ(binaryReader);
            author = SeekFile.GetASCIIZ(binaryReader);
            company = SeekFile.GetASCIIZ(binaryReader);
            recommendedDevice = SeekFile.GetASCIIZ(binaryReader);

            unknown4 = SeekFile.GetLong(binaryReader);

            completionCode = SeekFile.GetASCIIZ(binaryReader);

            foreach (Objects obj in objects.Values)
            {
               obj.LoadObject(binaryReader);
            }

            ok = true;
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Cartridge, Trace.TraceEventType.Error, ex);
         }
      }
      #endregion

      #region Methods

      public Objects GetObject(short objectId)
      {
         if (objectId == -1) return null;

         if (objectId >= 0 && objectId <= objects.Count - 1)
         {
            return objects[objectId];
         }
         else
         {
            throw new ArgumentOutOfRangeException("objectId", String.Format("Value have to be between 0 and {0}", objects.Count - 1));
         }
      }

      public Dictionary<short, Objects> Obj()
      {
         return objects;
      }

      #endregion
   }
}
