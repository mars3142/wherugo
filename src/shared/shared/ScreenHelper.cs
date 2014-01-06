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
using System.Drawing;
using System.Windows.Forms;

namespace org.mars3142.wherugo.shared
{
   public class ScreenHelper
   {
      delegate void SetValueDelegate(TextBox textBox, Property property, String value);

      public enum Property
      {
         Text,
         Height,
         Width
      }

      public static void SetValue(TextBox textBox, Property property, String value)
      {
         try
         {
            if (textBox.InvokeRequired)
            {
               SetValueDelegate d = new SetValueDelegate(SetValue);
               textBox.Invoke(d, new Object[] { textBox, property, value });
            }
            else
            {
               switch (property)
               {
                  case Property.Text:
                     textBox.Text = value;
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Shared, ex);
         }
      }
   }
}
