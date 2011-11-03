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

namespace org.mars3142.wherugo.Shared
{
   public static class Trace
   {
      public enum TraceEventType
      {
         Critical,      //Fatal error or application crash.  
         Error,         //Recoverable error.  
         Information,   //Informational message.  
         Resume,        //Resumption of a logical operation.  
         Start,         //Starting of a logical operation.  
         Stop,          //Stopping of a logical operation.  
         Suspend,       //Suspension of a logical operation.  
         Transfer,      //Changing of correlation identity.  
         Verbose,       //Debugging trace.  
         Warning        //Noncritical problem.  
      }

      public enum TraceCategories
      {
         Exception,
         WherugoApp,
         Cartridge,
         Communication,
         Control,
         Lua,
         Shared
      }

      public static void DoTrace(TraceCategories categories, Exception exception)
      {

      }

      public static void DoTrace(TraceCategories categories, String message)
      {

      }
      
      public static void DoTrace(TraceCategories categories, TraceEventType eventType, Exception exception)
      {
         
      }

      public static void DoTrace(TraceCategories categories, TraceEventType eventType, String message)
      {
         
      }

      public static void DoTrace(TraceCategories categories, TraceEventType eventType, String message, Exception exception)
      {
         
      }
   }
}
