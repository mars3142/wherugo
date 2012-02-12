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
         _serialPort.PortName = "COM2";
         _serialPort.BaudRate = 57600;
         _serialPort.DataBits = 8;
         _serialPort.Parity = Parity.None;
         _serialPort.StopBits = 0;

         _serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
         _serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(serialPort_ErrorReceived);
      }
      #endregion

      public void Start()
      {
         try
         {
            _serialPort.Close();
            _serialPort.Open();
         }
         catch (Exception ex)
         {
            //
         }
      }

      public void Stop()
      {
         try
         {
            if (_serialPort.IsOpen == true)
            {
               _serialPort.Close();
            }
         }
         catch (Exception ex)
         {
            //
         }
      }

      void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
      {
         throw new Exception("The method or operation is not implemented.");
      }

      void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
      {
         SerialPort port = (SerialPort)sender;
         if (port != null)
         {
            _data = port.ReadExisting();
         }
      }
   }
}
