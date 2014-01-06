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
using System.Windows.Forms;
using System.Collections.Generic;

//using org.mars3142.wherugo.lua;
using org.mars3142.wherugo.shared;
using org.mars3142.wherugo.wherigo;
using KopiLua;

namespace org.mars3142.wherugo.luatester.Windows
{
   public partial class Main : Form
   {
      private static List<Delegate> m_refs = new List<Delegate>();

      //private static ScriptEngine engine = new ScriptEngine();
      //private static Wherigo wherigo = new Wherigo(engine);
      private static Lua lua = new Lua();
      private Lua.lua_State lState;

      public Main()
      {
         InitializeComponent();
         //wherigo.InitWherigo();

         txtLua.Text = "TwoPlusTwo = 2+2; print('Hello world, from', _VERSION, '!'); print('TwoPlusTwo:', TwoPlusTwo); ";
      }

      private void btnExecute_Click(object sender, EventArgs e)
      {
         lState = Lua.luaL_newstate();
         Lua.luaL_openlibs(lState);
         Lua.luaL_loadstring(lState, txtLua.Text);
         Lua.lua_pcall(lState, 0, -1, 0);

         //engine.RunLuaScript(txtLua.Text);
      }

      private void Main_FormClosing(object sender, FormClosingEventArgs e)
      {
         Lua.lua_close(lState);
         //engine.StopEngineAndCleanup();
      }
   }
}