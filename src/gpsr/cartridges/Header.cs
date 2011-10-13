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
using org.mars3142.wherugo.Shared;

namespace org.mars3142.wherugo.Cartridges
{
   class Header
   {
      #region Member
      private double _latitude;              // N+/S-
      public double Latitude
      {
         get { return _latitude; }
      }

      private double _longitude;             // E+/W-
      public double Longitude
      {
         get { return _longitude; }
      }

      private long _unknown0;
      public long Unknown0
      {
         get { return _unknown0; }
      }

      private long _unknown1;
      public long Unknown1
      {
         get { return _unknown1; }
      }

      private long _unknown2;
      public long Unknown2
      {
         get { return _unknown2; }
      }

      private long _unknown3;
      public long Unknown3
      {
         get { return _unknown3; }
      }

      private short _splashScreenYn;        // -1 = without
      public short SplashScreenYN
      {
         get { return _splashScreenYn; }
      }

      private short _smallIconYn;          // -1 = without
      public short SmallIconYN
      {
         get { return _smallIconYn; }
      }

      private string _typeOfCartridge;     // "Tour guide", "Wherigo cache", etc.
      public string TypeOfCartridge
      {
         get { return _typeOfCartridge; }
      }

      private string _playerName;           //  name of player who downloaded this cartridge
      public string PlayerName
      {
         get { return _playerName; }
      }

      private long _unknown4;
      public long Unknown4
      {
         get { return _unknown4; }
      }

      private long _unknown5;
      public long Unknown5
      {
         get { return _unknown5; }
      }

      private string _catridgeName;
      public string CatridgeName
      {
         get { return _catridgeName; }
      }

      private string _catridgeGuid;
      public string CatridgeGuid
      {
         get { return _catridgeGuid; }
      }

      private string _catridgeDesc;
      public string CatridgeDesc
      {
         get { return _catridgeDesc; }
      }

      private string _startLocationDesc;
      public string StartLocationDesc
      {
         get { return _startLocationDesc; }
      }

      private string _version;
      public string Version
      {
         get { return _version; }
      }

      private string _author;
      public string Author
      {
         get { return _author; }
      }

      private string _company;
      public string Company
      {
         get { return _company; }
      }

      private string _recommendedDevice;
      public string RecommendedDevice
      {
         get { return _recommendedDevice; }
      }

      private long _unknown6;
      public string Unknown6
      {
         get { return _unknown6; }
      }

      private string _completionCode
      {
         get { return _completionCode; }
      }
   #endregion

      #region Ctr
      public Header(String text, ref int position)
      {
         Init();

         _latitude = Strings.getDouble(text, ref position);
         _longitude = Strings.getDouble(text, ref position);

         _unknown0 = Strings.getLong(text, ref position);
         _unknown1 = Strings.getLong(text, ref position);
         _unknown2 = Strings.getLong(text, ref position);
         _unknown3 = Strings.getLong(text, ref position);

         _splashScreenYn = Strings.getShort(text, ref position);
         _smallIconYn = Strings.getShort(text, ref position);

         _typeOfCartridge = Strings.getASCIIZ(text, ref position);
         _playerName = Strings.getASCIIZ(text, ref position);

         _unknown4 = Strings.getLong(text, ref position);
         _unknown5 = Strings.getLong(text, ref position);

         _catridgeName = Strings.getASCIIZ(text, ref position);
         _catridgeGuid = Strings.getASCIIZ(text, ref position);
         _catridgeDesc = Strings.getASCIIZ(text, ref position);
         _startLocationDesc = Strings.getASCIIZ(text, ref position);
         _version = Strings.getASCIIZ(text, ref position);
         _author = Strings.getASCIIZ(text, ref position);
         _company = Strings.getASCIIZ(text, ref position);
         _recommendedDevice = Strings.getASCIIZ(text, ref position);

         _unknown6 = Strings.getLong(text, ref position);

         _completionCode = Strings.getASCIIZ(text, ref position);
      }

      ~Header()
      {
         Init();
      }
      #endregion

      private void Init()
      {
         _latitude = 0;
         _longitude = 0;
         _unknown0 = 0;
         _unknown1 = 0;
         _unknown2 = 0;
         _unknown3 = 0;
         _splashScreenYn = -1;
         _smallIconYn = -1;
         _typeOfCartridge = null;
         _playerName = null;
         _unknown4 = 0;
         _unknown5 = 0;
         _catridgeName = null;
         _catridgeGuid = null;
         _catridgeDesc = null;
         _startLocationDesc = null;
         _version = null;
         _author = null;
         _company = null;
         _recommendedDevice = null;
         _unknown6 = 0;
         _completionCode = null;
      }
   }
}
