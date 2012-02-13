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
using System.IO.Ports;

using org.mars3142.wherugo.Shared;

namespace org.mars3142.wherugo.Communication
{
   public class GPS
   {
      const String _resetCommand = "$PSRF101,0,0,0,000,0,0,12,8*1C";
      SerialPort _serialPort = new SerialPort();
      String _data = null;

      #region Ctr
      /// <summary>
      /// 
      /// </summary>
      public GPS()
      {
         try
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, "GPS Constructor");
            _serialPort.PortName = "COM2";
            _serialPort.BaudRate = 57600;
            //_serialPort.DataBits = 8;
            //_serialPort.Parity = Parity.None;
            //_serialPort.StopBits = 0;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            _serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, Trace.TraceEventType.Error, ex);
         }
      }

      ~GPS()
      {
         Stop();
      }
      #endregion

      /// <summary>
      /// 
      /// </summary>
      public void Start()
      {
         try
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, "Start GPS");
            _serialPort.Close();
            _serialPort.Open();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, Trace.TraceEventType.Error, ex);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public void Stop()
      {
         try
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, "Stop GPS");
            if (_serialPort.IsOpen == true)
            {
               _serialPort.Close();
            }
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, Trace.TraceEventType.Error, ex);
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.Communication, "The method serialPort_ErrorReceived is not implemented.");
      }

      void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         try
         {
            SerialPort port = (SerialPort)sender;
            if (port != null)
            {
               _data = port.ReadExisting();
            }
            Trace.DoTrace(Trace.TraceCategories.Communication, _data);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, Trace.TraceEventType.Error, ex);
         }
      }
   }
}
