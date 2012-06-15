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
using System.Windows.Forms;
using System.Collections.Generic;

using org.mars3142.wherugo.lua;
using org.mars3142.wherugo.shared;
using System.ComponentModel;

namespace org.mars3142.wherugo.luatester.Windows
{
   public partial class Main : Form
   {
      private static IntPtr m_lua_State = IntPtr.Zero;
      private static List<Delegate> m_refs = new List<Delegate>();

      public Main()
      {
         InitializeComponent();
         m_lua_State = Lua.luaL_newstate();

         txtLua.Text = "TwoPlusTwo = 2+2; print('Hello World'); MsgBox('Test'); print('TwoPlusTwo:', TwoPlusTwo); ";
      }

      private void btnExecute_Click(object sender, EventArgs e)
      {
         if (m_lua_State == IntPtr.Zero)
         {
            MessageBox.Show("Error");
         }

         //open the Lua libraries for table, string, math etc.
         Lua.luaL_openlibs(m_lua_State);

         string luaScriptString = txtLua.Text;
         if (Lua.luaL_dostring(m_lua_State, luaScriptString) != 0)
         {
            Lua.lua_error(m_lua_State);
         }

         //clean up nicely
         Lua.lua_close(m_lua_State);
      }

      int Lua_MessageBox(IntPtr m_lua_State)
      {
         String text = String.Empty;

         if (Lua.lua_type(m_lua_State, -1) == 4)
         {
            text = Lua.lua_tostring(m_lua_State, -1);
            Lua.lua_pop(m_lua_State, 1);
            MessageBox.Show(text);
         }
         else
         {
            Lua.lua_settop(m_lua_State, 0);
         }

         return 0;
      }

      public void RegisterLuaFunction(Lua.LuaFunction func, string luaFuncName)
      {
         //call the lua_register API function to register a .Net function with
         Lua.lua_register(m_lua_State, luaFuncName, func);

         m_refs.Add(func);
      }
   }
}