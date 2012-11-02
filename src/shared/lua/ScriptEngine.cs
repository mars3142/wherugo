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

//  Original source from http://ttuxen.wordpress.com/2011/02/21/embedding-lua-in-c-net-part-iii

using System;
using System.Collections.Generic;
using System.Text;

namespace org.mars3142.wherugo.lua
{
   public class ScriptEngine
   {
        private static IntPtr m_lua_State = IntPtr.Zero;   
        private static List<Delegate> m_refs = new List<Delegate>();
        private static List<string> m_errors = new List<string>();

        public static List<string> Errors
        {
            get { return m_errors; }
            set { m_errors = value; }
        }

        /// <summary>
        /// Is the top of the lua stack nil ?
        /// </summary>
        private bool IsTopNil
        {
            get
            {
                return Lua.lua_type(m_lua_State, -1) == Lua.LUA_TNIL ? true : false;
            }
        }

        /// <summary>
        /// Default constructor, initializes a new Lua state by calling ResetLua() method
        /// </summary>
        public ScriptEngine()
        { 
            //initialize lua
            ResetLua();
        }

        /// <summary>
        /// Constructor, initializes a new Lua state by calling ResetLua() method
        /// Asssigns the internal errorlog to the passed in value
        /// </summary>
        public ScriptEngine(List<string> errorLog) : this()
        {
            if (errorLog != null)
                m_errors = errorLog;

            //initialize lua
            ResetLua();
        }

        /// <summary>
        /// Constructor, initializes a new Lua state by calling ResetLua() method
        /// if lua is already open, then close current lua state, and assign the passed in state as the curent state
        /// </summary>
        public ScriptEngine(IntPtr lua_State)
        {
            //if lua is already open, then close current lua state
            CloseLua();
            //assign injected lua state
            m_lua_State = lua_State;
        }
        
        /// <summary>
        /// Closes lua and clear errorlog and any references to functions that was registered with lua
        /// </summary>
        public static void CloseLua()
        {
            if (m_lua_State != IntPtr.Zero)
            {
                Lua.lua_close(m_lua_State);
            }
            //clear any references to callbacks to allow the garbage collector collect them
            m_refs.Clear();
            m_errors.Clear();
        }

        /// <summary>
        /// Closes lua by calling CloseLua() method, then opens a new lua state with all libs open
        /// </summary>
        public static void ResetLua()
        { 
            //if lua is already open, then close current lua state, and open a new one
            CloseLua();

            //open lua
            m_lua_State = Lua.lua_open();
        
            //open libraries
            Lua.luaL_openlibs(m_lua_State);
        }

        /// <summary>
        /// looks in the lua stack top if theres a string on top
        /// if it is a string then it adds it as an error message to the Errors list
        /// Clears the method off the stack by setting the top to 0
        /// </summary>
        public void LogError()
        {
            //log error
            if (Lua.lua_isstring(m_lua_State, -1) > 0)
                Errors.Add(Lua.lua_tostring(m_lua_State, -1));

            //clear the stack
            Lua.lua_settop(m_lua_State, 0);
        }

        /// <summary>
        /// Does the same as the staic method CloseLua(), but this method is a wrapper as an instance method
        /// </summary>
        public void StopEngineAndCleanup()
        {
            CloseLua();
        }

        /// <summary>
        /// Registers a .net method denoted by the delegate Lua.LuaFunction as a lua function
        /// the function will take on the name luaFuncName, in lua
        /// </summary>
        /// <param name="func">.net function to register with lua</param>
        /// <param name="luaFuncName">name of .net function in lua</param>
        public void RegisterLuaFunction(Lua.LuaFunction func, string luaFuncName)
        {
            Lua.lua_register(m_lua_State, luaFuncName, func);

            //make sure the delegate callback is not collected by the garbage collector before
            //unmanaged code has called back
            m_refs.Add(func);
        }

        /// <summary>
        /// Creates a table with tableName if it does not already exist.
        /// After creation or if the table already exists, stack will be empty and balanced.
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateLuaTable(string tableName)
        {
            Lua.lua_getglobal(m_lua_State, tableName);
            if (IsTopNil)
            {
                //remove the nil value
                Lua.lua_pop(m_lua_State, 1);
                Lua.lua_newtable(m_lua_State);
                Lua.lua_setglobal(m_lua_State, tableName);
                //stack is empty
            }
            else
            {
                //remove the existing table from the stack
                Lua.lua_pop(m_lua_State, 1);
            }
        }

        /// <summary>
        /// Gets the value of a field of a table and returns it as type object i.e. return luaTable.someField
        /// After the call the lua stack is balanced
        /// </summary>
        /// <param name="tableName">name of lua table</param>
        /// <param name="fieldName">name of table field</param>
        /// <returns>returns luaTable.someField</returns>
        public object GetTableField(string tableName, string fieldName)
        {
            //push table on the stack
            Lua.lua_getglobal(m_lua_State, tableName);

            if (IsTopNil)
                throw new LuaScriptEngineException("GetTableField, the table does not exist: " + tableName);

            //push table field name on the stack
            Lua.lua_pushstring(m_lua_State, fieldName);

            //get value of field of table: get tableName[fieldName]
            Lua.lua_gettable(m_lua_State, -2);

            //get the result of the stack
            int luaType = 0;
            object value = GetValueOfStack(out luaType);

            //pop table of the stack
            Lua.lua_pop(m_lua_State, 1);

            //stack is balanced
            return value;
        }

        /// <summary>
        /// Gets the value of a field of a lua table and returns it as type object i.e. return luaTable.someField
        /// The table to operate on must currently be on top of the lua stack.
        /// After the call the lua table is still on top of the stack
        /// </summary>
        /// <param name="fieldName">
        /// the name of the field, belonging to a lua table currently sitting on 
        /// top of the lua stack
        /// </param>
        /// <returns>returns luaTable.someField</returns>
        public object GetTableField(string fieldName)
        {
            if (IsTopNil)
                throw new LuaScriptEngineException("GetTableField, no table on top of stack");

            //push table field name on the stack
            Lua.lua_pushstring(m_lua_State, fieldName);

            //get value of field of table: get tableName[fieldName]
            Lua.lua_gettable(m_lua_State, -2);

            //get the result of the stack
            int luaType = 0;
            object value = GetValueOfStack(out luaType);

            //table is still on top of the stack
            return value;
        }

        /// <summary>
        /// Sets a field of a lua table to a lua variable identified by luaIdentifier i.e. luaTable.someField = luaVariable
        /// After the call the lua stack is balanced.
        /// </summary>
        /// <param name="tableName">name of the lua table</param>
        /// <param name="fieldName">name of the field</param>
        /// <param name="luaIdentifier">the identifier identifying the lua variable</param>
        public void SetTableFieldToLuaIdentifier(string tableName, string fieldName, string luaIdentifier)
        {
            Lua.lua_getglobal(m_lua_State, tableName);
            Lua.lua_pushstring(m_lua_State, fieldName);
            Lua.lua_getglobal(m_lua_State, luaIdentifier);
            Lua.lua_settable(m_lua_State, -3);
            Lua.lua_pop(m_lua_State, 1);
            //stack is balanced
        }

        /// <summary>
        /// Sets a field of a lua table to a lua variable identified by luaIdentifier i.e. luaTable.someField = luaVariable
        /// The table to operate on must currently be on top of the lua stack.
        /// After the call the lua table is still on top of the stack.
        /// </summary>
        /// <param name="fieldName">name of the field</param>
        /// <param name="luaIdentifier">the identifier identifying the lua variable</param>
        public void SetTableFieldToLuaIdentifier(string fieldName, string luaIdentifier)
        {
            Lua.lua_pushstring(m_lua_State, fieldName);
            Lua.lua_getglobal(m_lua_State, luaIdentifier);
            Lua.lua_settable(m_lua_State, -3);
            //table is still on top of the stack
        }

        /// <summary>
        /// Sets a field of a lua table to a .net variable value i.e. luaTable.someField = value of .net variable.
        /// After the call the lua stack is balanced.
        /// </summary>
        /// <param name="tableName">name of the lua table</param>
        /// <param name="fieldName">name of the field</param>
        /// <param name="value">.net variable</param>
        public void SetTableField(string tableName, string fieldName, object value)
        {
            //push table on the stack
            Lua.lua_getglobal(m_lua_State, tableName);

            if (IsTopNil)
                throw new LuaScriptEngineException("SetTableField, the table does not exist: " + tableName);

            //push table field name on the stack
            Lua.lua_pushstring(m_lua_State, fieldName);
            
            //push value on the stack
            PushBasicValue(value);

            //set field of table to value: tableName[fieldName]=value
            Lua.lua_settable(m_lua_State, -3);
            //pop table of the stack
            Lua.lua_pop(m_lua_State, 1);
            //stack is balanced
        }

        /// <summary>
        /// Sets a field of a lua table to a .net variable value i.e. luaTable.someField = value of .net variable.
        /// After the call the lua table is still on top of the stack.
        /// </summary>
        /// <param name="fieldName">name of the field</param>
        /// <param name="value">.net variable</param>
        public void SetTableField(string fieldName, object value)
        {
            if (IsTopNil)
                throw new LuaScriptEngineException("SetTableField, no table on top of the stack");

            //push table field name on the stack
            Lua.lua_pushstring(m_lua_State, fieldName);

            //push value on the stack
            PushBasicValue(value);

            //set field of table to value: tableName[fieldName]=value
            Lua.lua_settable(m_lua_State, -3);
            
            //table is still on top of the stack
        }

        /// <summary>
        /// Pops the value sitting on top of the lua stack
        /// </summary>
        /// <param name="luaType">the lua type of the value that was retrieved from the stack, is stored in this out parameter</param>
        /// <returns>the value popped off the stack</returns>
        public object GetValueOfStack(out int luaType)
        {
            luaType = 0;
            object value = null;
            switch (Lua.lua_type(m_lua_State, -1))
            {
                case Lua.LUA_TNONE:
                {
                    value = null;
                    luaType = Lua.LUA_TNONE;
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }
                case Lua.LUA_TNIL:
                {
                    value = null;
                    luaType = Lua.LUA_TNIL;
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }
                case Lua.LUA_TSTRING:
                {
                    luaType = Lua.LUA_TSTRING;
                    value = Lua.lua_tostring(m_lua_State, -1);
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }
                case Lua.LUA_TNUMBER:
                {
                    luaType = Lua.LUA_TNUMBER;
                    value = Lua.lua_tonumber(m_lua_State, -1);
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }
                case Lua.LUA_TBOOLEAN:
                {
                    luaType = Lua.LUA_TBOOLEAN;
                    int intToBool = Lua.lua_toboolean(m_lua_State, -1);
                    value = intToBool > 0 ? true : false;
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }
                case Lua.LUA_TTABLE:
                {
                    luaType = Lua.LUA_TTABLE;
                    value = "table";
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }
                default:
                {
                    value = null;
                    //pop value from stack
                    Lua.lua_pop(m_lua_State, 1);
                    break;
                }

                //case Lua.LUA_TINTEGER:
                //{
                //    value = Lua.lua_tointeger(m_lua_State, -1);
                //    //pop value from stack
                //    Lua.lua_pop(m_lua_State, 1);
                //    break;
                //}
            }

            return value;
        }

        /// <summary>
        /// Pushes the value on to the lua stack based on value.GetType(), and how that type maps to a lua type.
        /// Pushes nil if object is null or typeof object is not a basic type
        /// </summary>
        /// <param name="value">the value to push on to the stack</param>
        public void PushBasicValue(object value)
        {
            //push nil if the value cannot be mapped to a lua type
            bool handleAsNil = false;
            if (value != null)
            {
                handleAsNil = true;
            }

            //push value on the stack
            if (value == null || handleAsNil)
            {
                Lua.lua_pushnil(m_lua_State);
                return;
            }
            if (value.GetType() == typeof(string))
            {
                Lua.lua_pushstring(m_lua_State, value.ToString());
                return;
            }
            if (value.GetType() == typeof(bool))
            {
                Lua.lua_pushboolean(m_lua_State, (bool)value);
                return;
            }
            if (value.GetType() == typeof(decimal))
            {
                Lua.lua_pushnumber(m_lua_State, Convert.ToDouble(((decimal)value)));
                return;
            }
            if (value.GetType() == typeof(float))
            {
                Lua.lua_pushnumber(m_lua_State, Convert.ToDouble(((float)value)));
                return;
            }
            if (value.GetType() == typeof(double))
            {
                Lua.lua_pushnumber(m_lua_State, Convert.ToDouble(((double)value)));
                return;
            }
            if (value.GetType() == typeof(int))
            {
                Lua.lua_pushinteger(m_lua_State, (int)value);
                return;
            }
            if (value.GetType() == typeof(DateTime))
            {
                Lua.lua_pushstring(m_lua_State, ((DateTime)value).ToString());
                return;
            }
            if (value.GetType() == typeof(Guid))
            {
                Lua.lua_pushstring(m_lua_State, ((Guid)value).ToString());
                return;
            }
            if (value.GetType().IsEnum)
            {
                Lua.lua_pushstring(m_lua_State, value.ToString());
                return;
            }
        }

        /// <summary>
        /// Runs a lua script and returns true on success
        /// </summary>
        /// <param name="script">the string containing the script to run</param>
        /// <returns>returns teu if successfull otherwise false</returns>
        public bool RunLuaScript(string script)
        {
            if (m_lua_State == IntPtr.Zero)
                return false;

            if (Lua.luaL_dostring(m_lua_State, script) == 0)
                return true;

            //log the error if possible
            LogError();
            return false;
        }
   }
}
