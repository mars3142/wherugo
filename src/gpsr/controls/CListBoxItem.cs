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
using System.Drawing;

namespace org.mars3142.wherugo.controls
{
   public class CListBoxItem
   {
      #region Members
      private String _itemKey;
      private String _itemValue;
      private Image _itemImage;

      /// <summary>
      /// 
      /// </summary>
      public String ItemKey
      {
         get
         {
            return _itemKey;
         }
         set
         {
            _itemKey = value;
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public String ItemValue
      {
         get
         {
            return _itemValue;
         }
         set
         {
            _itemValue = value;
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public Image ItemImage
      {
         get
         {
            return _itemImage;
         }
         set
         {
            _itemImage = value;
         }
      }
      #endregion

      #region Ctr
      /// <summary>
      /// 
      /// </summary>
      /// <param name="key"></param>
      public CListBoxItem(String key)
         : this(key, null, null)
      { }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="key"></param>
      /// <param name="value"></param>
      public CListBoxItem(String key, String value)
         : this(key, value, null)
      { }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="key"></param>
      /// <param name="value"></param>
      /// <param name="image"></param>
      public CListBoxItem(String key, String value, Image image)
      {
         if (String.IsNullOrEmpty(key))
            throw new ArgumentNullException("key");

         _itemKey = key;
         _itemValue = value;
         _itemImage = image;
      }
      #endregion
   }
}
