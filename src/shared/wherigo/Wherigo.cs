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
using System.Text;
using org.mars3142.wherugo.lua;

namespace org.mars3142.wherugo.wherigo
{
   public class Wherigo
   {
      public void MessageBox(String text)
      {
         //
      }

      int Lua_MessageBox(IntPtr m_lua_state)
      {
         //string text = lua_tostring(m_lua_state, -1);
         return 0;
      }
   }
}
