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

namespace org.mars3142.wherugo.Data
{
   class Cartridge
   {
      private String creator;
      public String Creator
      {
         get
         {
            return creator;
         }
         set
         {
            creator = value;
         }
      }

      private String location;
      public String Location
      {
         get
         {
            return location;
         }
         set
         {
            location = value;
         }
      }

      private String cartridgeName;
      public String CartridgeName
      {
         get
         {
            return cartridgeName;
         }
         set
         {
            cartridgeName = value;
         }
      }

      private String playTime;
      public String PlayTime
      {
         get
         {
            return playTime;
         }
         set
         {
            playTime = value;
         }
      }

      private String submitter;
      public String Submitter
      {
         get
         {
            return submitter;
         }
         set
         {
            submitter = value;
         }
      }
   }
}
