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
using System.Windows.Forms;

namespace org.mars3142.wherugo.Controls
{
   public partial class CListBox : UserControl
   {
      VScrollBar _vbar;
      int _vby = 0;

      #region Ctr
      public CListBox() : this(null)
      {
         //
      }

      public CListBox(Dictionary<String, CListBoxItem> Items)
      {
         InitializeComponent();
         InitialControl();
         if (Items != null)
         {

         }
      }

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
         this.Controls.Add(_vbar);
      }
      #endregion
   }
}