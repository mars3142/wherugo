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
using System.Windows.Forms;

using org.mars3142.wherugo.lua;

namespace org.mars3142.wherugo.wherigo
{
   public class Wherigo
   {
      ScriptEngine m_engine = null;

      public Wherigo(ScriptEngine engine)
      {
         m_engine = engine;
      }

      public void InitWherigo()
      {
         if (m_engine == null)
         {
            return;
         }

         RegisterMethods();
         CreateTable();
         AssociateTableWithFunctions();
      }

      private void RegisterMethods()
      {
         m_engine.RegisterLuaFunction(new Lua.LuaFunction(Lua_MsgBox), "msgbox");
      }

      private void CreateTable()
      {
         m_engine.CreateLuaTable("Wherigo");
      }

      private void AssociateTableWithFunctions()
      {
         m_engine.SetTableFieldToLuaIdentifier("Wherigo", "msgbox", "msgbox");
      }

      public Boolean MsgBox(String text)
      {
         MessageBox.Show(text);
         return true;
      }

      int Lua_MsgBox(IntPtr m_lua_state)
      {
         string text = String.Empty;

         if (Lua.lua_type(m_lua_state, -1) == Lua.LUA_TSTRING)
         {
            text = Lua.lua_tostring(m_lua_state, -1);
            Lua.lua_pop(m_lua_state, 1);
            Lua.lua_pushboolean(m_lua_state, MsgBox(text));
            return 1;
         }
         else
         {
            Lua.lua_settop(m_lua_state, 0);
         }

         Lua.lua_pushstring(m_lua_state, "invalid argument to function: msgbox(string text)");
         return Lua.lua_error(m_lua_state);
      }
   }
}
