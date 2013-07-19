//  wherugo - WherUGo for Magellan eXplorist x10
//  Copyright (C) 2011-2013 Peter Siegmund <developer@mars3142.org>
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace org.mars3142.wherugo.controls
{
   public partial class CCompass : UserControl
   {
      #region Members
      const double Radius = 6371;

      private double _distance;
      private double _targetLatitude;
      private double _targetLongitude;
      private double _currentLatitude;
      private double _currentLongitude;
      private double _speed;
      private double _heading;

      /// <summary>
      /// 
      /// </summary>
      public double Heading
      {
         get { return _heading; }
         set
         {
            if (Math.Abs(_heading - value) > Double.Epsilon)
            {
               if (value >= 0 && value < 360)
               {
                  _heading = value;
                  DrawCompass();
               }
               else
               {
                  throw new ArgumentOutOfRangeException("Heading", "Value have to be between 0 and 359");
               }
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public double Speed
      {
         get { return _speed; }
         set
         {
            if (Math.Abs(_speed - value) > Double.Epsilon)
            {
               if (value >= 0)
               {
                  _speed = value;
                  DrawCompass();
               }
               else
               {
                  throw new ArgumentOutOfRangeException("Speed", "Value have to be equal or greater than 0");
               }
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public double Distance
      {
         get { return _distance; }
         set
         {
            if (value != _distance)
            {
               _distance = value;
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public double TargetLatitude
      {
         get { return _targetLatitude; }
         set
         {
            if (value != _targetLatitude)
            {
               _targetLatitude = value;
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public double TargetLongitude
      {
         get { return _targetLongitude; }
         set
         {
            if (value != _targetLongitude)
            {
               _targetLongitude = value;
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public double CurrentLatitude
      {
         get { return _currentLatitude; }
         set
         {
            if (value != _currentLatitude)
            {
               _currentLatitude = value;
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      public double CurrentLongitude
      {
         get { return _currentLongitude; }
         set
         {
            if (value != _currentLongitude)
            {
               _currentLongitude = value;
            }
         }
      }
      #endregion

      #region Ctr
      public CCompass()
         : this(0)
      { }

      public CCompass(double heading)
         : this(heading, 0)
      {
      }

      public CCompass(double heading, double speed)
      {
         _speed = speed;
         InitializeComponent();
         Heading = heading;
         Speed = speed;
      }
      #endregion

      #region Events
      protected override void OnPaint(PaintEventArgs pe)
      {
         DrawCompass();
         base.OnPaint(pe);
      }
      #endregion

      private static void DrawCompass()
      {

      }

      private void CalcValues()
      {
      }
   }
}
