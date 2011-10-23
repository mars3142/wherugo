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
using System.IO;
using org.mars3142.wherugo.Shared;

namespace org.mars3142.wherugo.Cartridges
{
   class Header
   {
      #region Members
      private readonly Dictionary<short, Objects> _objects;
      public Dictionary<short, Objects> Objects
      {
         get { return _objects; }
      }

      private readonly double _latitude;              // N+/S-
      public double Latitude
      {
         get { return _latitude; }
      }

      private readonly double _longitude;             // E+/W-
      public double Longitude
      {
         get { return _longitude; }
      }

      private readonly long _unknown0;
      public long Unknown0
      {
         get { return _unknown0; }
      }

      private readonly long _unknown1;
      public long Unknown1
      {
         get { return _unknown1; }
      }

      private readonly long _unknown2;
      public long Unknown2
      {
         get { return _unknown2; }
      }

      private readonly long _unknown3;
      public long Unknown3
      {
         get { return _unknown3; }
      }

      private readonly short _splashScreenId;        // -1 = without
      public short SplashScreenId
      {
         get { return _splashScreenId; }
      }

      private readonly short _smallIconId;          // -1 = without
      public short SmallIconId
      {
         get { return _smallIconId; }
      }

      private readonly string _typeOfCartridge;     // "Tour guide", "Wherigo cache", etc.
      public string TypeOfCartridge
      {
         get { return _typeOfCartridge; }
      }

      private readonly string _playerName;          //  name of player who downloaded this cartridge
      public string PlayerName
      {
         get { return _playerName; }
      }

      private readonly long _unknown4;
      public long Unknown4
      {
         get { return _unknown4; }
      }

      private readonly long _unknown5;
      public long Unknown5
      {
         get { return _unknown5; }
      }

      private readonly string _catridgeName;
      public string CatridgeName
      {
         get { return _catridgeName; }
      }

      private readonly string _catridgeGuid;
      public string CatridgeGuid
      {
         get { return _catridgeGuid; }
      }

      private readonly string _catridgeDesc;
      public string CatridgeDesc
      {
         get { return _catridgeDesc; }
      }

      private readonly string _startLocationDesc;
      public string StartLocationDesc
      {
         get { return _startLocationDesc; }
      }

      private readonly string _version;
      public string Version
      {
         get { return _version; }
      }

      private readonly string _author;
      public string Author
      {
         get { return _author; }
      }

      private readonly string _company;
      public string Company
      {
         get { return _company; }
      }

      private readonly string _recommendedDevice;
      public string RecommendedDevice
      {
         get { return _recommendedDevice; }
      }

      private readonly long _unknown6;
      public long Unknown6
      {
         get { return _unknown6; }
      }

      private readonly string _completionCode;
      public string CompletionCode
      {
         get { return _completionCode; }
      }

      private readonly bool _ok;
      public bool Ok
      {
         get { return _ok; }
      }
      #endregion

      #region Ctr
      public Header(BinaryReader binaryReader)
      {
         try
         {
            _objects = new Dictionary<short, Objects>();
            _ok = false;

            ushort i = SeekFile.GetUShort(binaryReader);
            for (int i2 = 0; i2 < i; i2++)
            {
               short objectId = SeekFile.GetShort(binaryReader);
               long address = SeekFile.GetLong(binaryReader);
               Objects obj = new Objects(objectId, address);
               _objects.Add(obj.ObjectId, obj);
            }

            long headerLenght = SeekFile.GetLong(binaryReader);

            _latitude = SeekFile.GetDouble(binaryReader);
            _longitude = SeekFile.GetDouble(binaryReader);

            _unknown0 = SeekFile.GetLong(binaryReader);
            _unknown1 = SeekFile.GetLong(binaryReader);
            _unknown2 = SeekFile.GetLong(binaryReader);
            _unknown3 = SeekFile.GetLong(binaryReader);

            _splashScreenId = SeekFile.GetShort(binaryReader);
            _smallIconId = SeekFile.GetShort(binaryReader);

            _typeOfCartridge = SeekFile.GetASCIIZ(binaryReader);
            _playerName = SeekFile.GetASCIIZ(binaryReader);

            _unknown4 = SeekFile.GetLong(binaryReader);
            _unknown5 = SeekFile.GetLong(binaryReader);

            _catridgeName = SeekFile.GetASCIIZ(binaryReader);
            _catridgeGuid = SeekFile.GetASCIIZ(binaryReader);
            _catridgeDesc = SeekFile.GetASCIIZ(binaryReader);
            _startLocationDesc = SeekFile.GetASCIIZ(binaryReader);
            _version = SeekFile.GetASCIIZ(binaryReader);
            _author = SeekFile.GetASCIIZ(binaryReader);
            _company = SeekFile.GetASCIIZ(binaryReader);
            _recommendedDevice = SeekFile.GetASCIIZ(binaryReader);

            _unknown6 = SeekFile.GetLong(binaryReader);

            _completionCode = SeekFile.GetASCIIZ(binaryReader);

            _ok = true;
         }
         catch (Exception ex)
         {
            throw new WherugoException("Cartridges.Header.Header()", ex);
         }
      }
      #endregion
   }
}
