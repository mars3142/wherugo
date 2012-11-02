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
using org.mars3142.wherugo.wherigo;

namespace org.mars3142.wherugo.luatester.Windows
{
   public partial class Main : Form
   {
      private static List<Delegate> m_refs = new List<Delegate>();

      private static ScriptEngine engine = new ScriptEngine();
      private static Wherigo wherigo = new Wherigo(engine);

      public Main()
      {
         InitializeComponent();
         //wherigo.InitWherigo();

         txtLua.Text = "require 'Wherigo'; TwoPlusTwo = 2+2; print('Hello world, from', _VERSION, '!'); print('TwoPlusTwo:', TwoPlusTwo); ";
      }

      private void btnExecute_Click(object sender, EventArgs e)
      {

         engine.RunLuaScript(txtLua.Text);
      }

      private void Main_FormClosing(object sender, FormClosingEventArgs e)
      {
         engine.StopEngineAndCleanup();
      }
   }
}