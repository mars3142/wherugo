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
using System.Windows.Forms;

namespace org.mars3142.wherugo.controls
{
   public partial class CListBox : UserControl
   {
      private Dictionary<String, CListBoxItem> _items;
      private VScrollBar _vbar;
      private int _vby = 0;
      private Button _buttonOk;
      private Button _buttonCancel;

      /// <summary>
      /// 
      /// </summary>
      public event EventHandler OkClick;

      /// <summary>
      /// 
      /// </summary>
      public event EventHandler CancelClick;

      #region Ctr
      /// <summary>
      /// 
      /// </summary>
      public CListBox()
         : this(null)
      { }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="items"></param>
      public CListBox(Dictionary<String, CListBoxItem> items)
      {
         InitializeComponent();
         InitialControl();
         if (items != null)
         {
            _items = items;
         }
         else
         {
            _items = new Dictionary<string, CListBoxItem>();
         }
      }
      #endregion

      #region Event
      protected virtual void OnOkClick(EventArgs e)
      {
         EventHandler okClick = OkClick;
         if (okClick != null)
         {
            OkClick(this, e);
         }
      }

      protected virtual void OnCancelClick(EventArgs e)
      {
         EventHandler cancelClick = CancelClick;
         if (cancelClick != null)
         {
            CancelClick(this, e);
         }
      }
      #endregion

      /// <summary>
      /// 
      /// </summary>
      private void InitialControl()
      {
         _vbar = new VScrollBar();
         _vbar.Dock = DockStyle.Right;
         _vbar.Minimum = 0;
         _vbar.Maximum = 150;
         _vbar.Value = 0;
         _vbar.SmallChange = 5;
         _vbar.LargeChange = 50;
         _vbar.Visible = true;
         //_vbar.Scroll += new ScrollEventHandler(scrollvertikal);
         Controls.Add(_vbar);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="pe"></param>
      protected override void OnPaint(PaintEventArgs pe)
      {
         base.OnPaint(pe);
      }

      /// <summary>
      /// Added a new item to the list (not overwriting).
      /// </summary>
      /// <param name="item">An item</param>
      /// <returns>True if added.</returns>
      public bool Add(CListBoxItem item)
      {
         bool retValue = false;

         try
         {
            if (!_items.ContainsKey(item.ItemKey))
            {
               _items.Add(item.ItemKey, item);
               retValue = true;
            }
         }
         catch (Exception ex)
         {
            throw new ControlException("CListBox.Add()", ex);
         }

         return retValue;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public bool Clear()
      {
         _items.Clear();
         return (_items.Count == 0);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool Replace(CListBoxItem item)
      {
         bool retValue = false;

         try
         {
            if (_items.ContainsKey(item.ItemKey))
            {
               _items[item.ItemKey] = item;
               retValue = true;
            }
         }
         catch (Exception ex)
         {
            throw new ControlException("CListBox.Replace()", ex);
         }

         return retValue;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="key"></param>
      /// <returns></returns>
      public bool Remove(String key)
      {
         bool retValue = false;

         try
         {
            if (_items.ContainsKey(key))
            {
               _items.Remove(key);
               retValue = true;
            }
         }
         catch (Exception ex)
         {
            throw new ControlException("CListBox.Remove()", ex);
         }

         return retValue;
      }
   }
}