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
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.IO;

namespace org.mars3142.wherugo.shared
{
   public static class Locale
   {
      public static string GetString(string key)
      {
         string retValue = string.Empty;

         retValue = GetString(key, CultureInfo.CurrentCulture.ToString()); 
         
         return retValue;
      }

      public static string GetString(string key, string culture)
      {
         string path = string.Empty;
         string retValue = string.Empty;
         ResourceManager rm;

         path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\locale";
         rm = ResourceManager.CreateFileBasedResourceManager("locale", path, null);

         try
         {
            retValue = rm.GetString(key, new CultureInfo(culture));
            if (String.IsNullOrEmpty(retValue))
            {
               retValue = key;
            }
         }
         catch (MissingManifestResourceException ex)
         {
            retValue = key;
         }
         return retValue;
      }
   }
}