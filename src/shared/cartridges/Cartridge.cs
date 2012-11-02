//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011-2012 Peter Siegmund <developer@mars3142.org>
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
using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.cartridges
{
   public class Cartridge
   {
      #region Members

      #region Private

      private readonly Dictionary<short, Objects> _objects;

      private readonly string _author;
      private readonly string _cartridgeDesc;
      private readonly string _cartridgeGuid;
      private readonly string _cartridgeName;
      private readonly string _company;
      private readonly string _completionCode;
      private readonly double _latitude;              // N+/S-
      private readonly double _longitude;             // E+/W-
      private readonly bool _ok;
      private readonly string _playerName;            //  name of player who downloaded this cartridge
      private readonly string _recommendedDevice;
      private readonly short _smallIconId;            // -1 = without
      private readonly short _splashScreenId;         // -1 = without
      private readonly string _startLocationDesc;
      private readonly string _typeOfCartridge;       // "Tour guide", "Wherigo cache", etc.
      private readonly long _unknown0;
      private readonly long _unknown1;
      private readonly long _unknown2;
      private readonly long _unknown3;
      private readonly long _unknown4;
      private readonly long _unknown5;
      private readonly long _unknown6;
      private readonly string _version;
      
      #endregion

      /// <summary>
      /// authorname
      /// </summary>
      public string Author
      {
         get { return _author; }
      }

      /// <summary>
      /// latitude of the startposition
      /// </summary>
      public double Latitude
      {
         get { return _latitude; }
      }

      /// <summary>
      /// longitude of the startposition
      /// </summary>
      public double Longitude
      {
         get { return _longitude; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown0
      {
         get { return _unknown0; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown1
      {
         get { return _unknown1; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown2
      {
         get { return _unknown2; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown3
      {
         get { return _unknown3; }
      }

      /// <summary>
      /// objectid of the splashscreen object (-1 not exists)
      /// </summary>
      public short SplashScreenId
      {
         get { return _splashScreenId; }
      }

      /// <summary>
      /// objectid of the smallicon object (-1 not exists)
      /// </summary>
      public short SmallIconId
      {
         get { return _smallIconId; }
      }

      /// <summary>
      /// type of the cartridge
      /// </summary>
      public string TypeOfCartridge
      {
         get { return _typeOfCartridge; }
      }

      /// <summary>
      /// playername (downloader of file)
      /// </summary>
      public string PlayerName
      {
         get { return _playerName; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown4
      {
         get { return _unknown4; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown5
      {
         get { return _unknown5; }
      }

      /// <summary>
      /// cartridgename
      /// </summary>
      public string CartridgeName
      {
         get { return _cartridgeName; }
      }

      /// <summary>
      /// unique guid of cartridge
      /// </summary>
      public string CatridgeGuid
      {
         get { return _cartridgeGuid; }
      }

      /// <summary>
      /// catridgedescription
      /// </summary>
      public string CatridgeDesc
      {
         get { return _cartridgeDesc; }
      }

      /// <summary>
      /// startlocation description
      /// </summary>
      public string StartLocationDesc
      {
         get { return _startLocationDesc; }
      }

      /// <summary>
      /// cartridge version
      /// </summary>
      public string Version
      {
         get { return _version; }
      }

      /// <summary>
      /// companyname (?)
      /// </summary>
      public string Company
      {
         get { return _company; }
      }

      /// <summary>
      /// recommended device for that catridge
      /// </summary>
      public string RecommendedDevice
      {
         get { return _recommendedDevice; }
      }

      /// <summary>
      /// unknown value
      /// </summary>
      public long Unknown6
      {
         get { return _unknown6; }
      }

      /// <summary>
      /// encrypted completioncode
      /// </summary>
      public string CompletionCode
      {
         get { return _completionCode; }
      }

      /// <summary>
      /// cartridgefile is valid
      /// </summary>
      public bool Ok
      {
         get { return _ok; }
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
            _objects = new Dictionary<short, Objects>();
            _ok = false;

            ushort count = SeekFile.GetUShort(binaryReader);
            for (int i = 0; i < count; i++)
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

            _cartridgeName = SeekFile.GetASCIIZ(binaryReader);
            _cartridgeGuid = SeekFile.GetASCIIZ(binaryReader);
            _cartridgeDesc = SeekFile.GetASCIIZ(binaryReader);
            _startLocationDesc = SeekFile.GetASCIIZ(binaryReader);
            _version = SeekFile.GetASCIIZ(binaryReader);
            _author = SeekFile.GetASCIIZ(binaryReader);
            _company = SeekFile.GetASCIIZ(binaryReader);
            _recommendedDevice = SeekFile.GetASCIIZ(binaryReader);

            _unknown6 = SeekFile.GetLong(binaryReader);

            _completionCode = SeekFile.GetASCIIZ(binaryReader);

            foreach (Objects obj in _objects.Values)
            {
               obj.LoadObject(binaryReader);
            }

            _ok = true;
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

         if (objectId >= 0 && objectId <= _objects.Count - 1)
         {
            return _objects[objectId];
         }
         else
         {
            throw new ArgumentOutOfRangeException("objectId", String.Format("Value have to be between 0 and {0}", _objects.Count - 1));
         }
      }

      public Dictionary<short, Objects> Obj()
      {
         return _objects;
      }

      #endregion
   }
}
