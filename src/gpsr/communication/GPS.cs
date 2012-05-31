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
using System.Threading;

using org.mars3142.wherugo.shared;

namespace org.mars3142.wherugo.communication
{
   public class GPS
   {
      private const String resetCommand = "$PSRF101,0,0,0,000,0,0,12,8*1C";

      private Object lockObject = new Object();
      private SerialPort serialPort = new SerialPort();
      private String data = null;

      public delegate void NewDataEventHandler(Object sender, GPSEventArgs e);
      public event NewDataEventHandler NewData;

      #region Ctr
      /// <summary>
      /// Instanciate the serialPort and add the event-handler
      /// </summary>
      public GPS()
      {
         try
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, "GPS Constructor");
            serialPort.PortName = "COM2"; // DeviceConfig.PortName;
            serialPort.BaudRate = 57600; // Convert.ToInt32(DeviceConfig.BaudRate);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
            serialPort.PinChanged += new SerialPinChangedEventHandler(serialPort_PinChanged);
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, Trace.TraceEventType.Error, ex);
         }
      }

      ~GPS()
      {
         StopGPS();
      }
      #endregion

      /// <summary>
      /// Open the GPS-port to receive data
      /// </summary>
      public void StartGPS()
      {
         try
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, "Start GPS");
            if (serialPort.IsOpen == true)
            {
               serialPort.Close();
            }
            serialPort.Open();
         }
         catch (Exception ex)
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, Trace.TraceEventType.Error, ex);
         }
      }

      /// <summary>
      /// If GPS-port is open, it will be closed
      /// </summary>
      public void StopGPS()
      {
         try
         {
            Trace.DoTrace(Trace.TraceCategories.Communication, "Stop GPS");
            if (serialPort.IsOpen == true)
            {
               serialPort.Close();
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
      void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         try
         {
            lock (lockObject)
            {
               SerialPort portSender = (SerialPort)sender;
               if (portSender != null)
               {
                  data = portSender.ReadExisting();
               }
               Trace.DoTrace(Trace.TraceCategories.Communication, data);

               OnNewData(new GPSEventArgs(DateTime.Now, data));
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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void serialPort_PinChanged(object sender, SerialPinChangedEventArgs e)
      {
         Trace.DoTrace(Trace.TraceCategories.Communication, "The method serialPort_PinChanged is not implemented.");
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="e"></param>
      protected virtual void OnNewData(GPSEventArgs e)
      {
         if (NewData != null)
         {
            NewData(this, e);
         }
      }
   }
}
