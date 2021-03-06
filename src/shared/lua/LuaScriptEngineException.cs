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

//  Original source from http://ttuxen.wordpress.com/2011/02/21/embedding-lua-in-c-net-part-iii

using System;

namespace org.mars3142.wherugo.lua
{
    public class LuaScriptEngineException : Exception
    {
        public LuaScriptEngineException(string msg)
            : base(msg)
        {
        }
    }
}
