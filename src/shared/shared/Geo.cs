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
//
//  found: http://stackoverflow.com/questions/6862684/converting-from-decimal-degrees-to-degrees-minutes-seconds-tenths

using System;
public class Geo
{
   private bool isNegative;
   public bool IsNegative
   {
      get { return isNegative; }
      set { isNegative = value; }
   }

   private int degrees;
   public int Degrees 
   {
      get { return degrees; }
      set { degrees = value; }
   }

   private int minutes;
   public int Minutes 
   {
      get { return minutes; }
      set { minutes = value; }
   }

   private int seconds;
   public int Seconds 
   {
      get { return seconds; }
      set { seconds = value; }
   }

   private int milliseconds;
   public int Milliseconds 
   {
      get { return milliseconds; }
      set { milliseconds = value; }
   }

   public static Geo FromDouble(double angleInDegrees)
   {
      //ensure the value will fall within the primary range [-180.0..+180.0]
      while (angleInDegrees < -180.0)
         angleInDegrees += 360.0;

      while (angleInDegrees > 180.0)
         angleInDegrees -= 360.0;

      Geo result = new Geo();

      //switch the value to positive
      result.IsNegative = angleInDegrees < 0;
      angleInDegrees = Math.Abs(angleInDegrees);

      //gets the degree
      result.Degrees = (int)Math.Floor(angleInDegrees);
      double delta = angleInDegrees - result.Degrees;

      //gets minutes and seconds
      int seconds = (int)Math.Floor(3600.0 * delta);
      result.Seconds = seconds % 60;
      result.Minutes = (int)Math.Floor(seconds / 60.0);
      delta = delta * 3600.0 - seconds;

      //gets fractions
      result.Milliseconds = (int)(1000.0 * delta);

      return result;
   }



   public override string ToString()
   {
      int degrees = this.IsNegative
          ? -this.Degrees
          : this.Degrees;

      return string.Format(
          "{0}° {1:00}' {2:00}\"",
          degrees,
          this.Minutes,
          this.Seconds);
   }



   public string ToString(string format)
   {
      switch (format)
      {
         case "NS":
            return string.Format(
                "{0}° {1:00}' {2:00}\".{3:000} {4}",
                this.Degrees,
                this.Minutes,
                this.Seconds,
                this.Milliseconds,
                this.IsNegative ? 'S' : 'N');

         case "WE":
            return string.Format(
                "{0}° {1:00}' {2:00}\".{3:000} {4}",
                this.Degrees,
                this.Minutes,
                this.Seconds,
                this.Milliseconds,
                this.IsNegative ? 'W' : 'E');

         default:
            throw new NotImplementedException();
      }
   }
}
