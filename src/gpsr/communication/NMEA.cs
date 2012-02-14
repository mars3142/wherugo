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
using System.Collections.Generic;
using System.Text;

namespace org.mars3142.wherugo.Communication
{
   public class NMEA
   {

      /// <summary>
      /// 
      /// </summary>
      /// <param name="nmea"></param>
      public void LoadData(String nmea)
      {
         if (nmea.Length == 0)
            return;

         switch (nmea.Split(',')[0])
         {
            case "$GPAAM": // Waypoint Arrival Alarm
               ReadAAM(nmea);
               break;

            case "$GPALM": // GPS Almanac Data
               ReadALM(nmea);
               break;

            case "$GPAPA": // Autopilot Sentence "A"
               ReadAPA(nmea); 
               break;

            case "$GPAPB": // Autopilot Sentence "B"
               ReadAPB(nmea);
               break;

            case "$GPASD": // Autopilot System Data 
               // format unknown
               break;

            case "$GPBEC": // Bearing & Distance to Waypoint - Dead Reckoning
               ReadBEC(nmea);
               break;

            case "$GPBOD": // Bearing Origin to Destination
               ReadBOD(nmea);
               break;

            case "$GPBWC": // Bearing and Distance to Waypoint, Latitude, N/S, Longitude, E/W, UTC, Status
               ReadBWC(nmea);
               break;

            case "$GPBWR": // Bearing and Distance to Waypoint - Rhumb Line, Latitude, N/S, Longitude, E/W, UTC, Status
               ReadBWR(nmea);
               break;

            case "$GPBWW": // Bearing - Waypoint to Waypoint
               ReadBWW(nmea);
               break;
         }
      }

      /// <summary>
      /// Waypoint Arrival Alarm 
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadAAM(String nmea)
      {
         // 1) Status, BOOLEAN, A = Arrival circle entered 
         // 2) Status, BOOLEAN, A = perpendicular passed at waypoint 
         // 3) Arrival circle radius 
         // 4) Units of radius, nautical miles 
         // 5) Waypoint ID 
         // 6) Checksum

         return;
      }

      /// <summary>
      /// GPS Almanac Data
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadALM(String nmea)
      {
         //  1) Total number of messages 
         //  2) Message Number 
         //  3) Satellite PRN number (01 to 32) 
         //  4) GPS Week Number : 
         //     Date and time in GPS is computed as number of weeks from 6 January 1980 plus 
         //     number of seconds into the week. 
         //  5) SV health, bits 17-24 of each almanac page 
         //  6) Eccentricity 
         //  7) Almanac Reference Time 
         //  8) Inclination Angle 
         //  9) Rate of Right Ascension 
         // 10) Root of semi-major axis 
         // 11) Argument of perigee 
         // 12) Longitude of ascension node 
         // 13) Mean anomaly 
         // 14) F0 Clock Parameter 
         // 15) F1 Clock Parameter 
         // 16) Checksum

         return;
      }

      /// <summary>
      /// Autopilot Sentence "A"
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadAPA(String nmea)
      {
         //  1) Status 
         //     V = LORAN-C Blink or SNR warning 
         //     V = general warning flag or other navigation systems when a reliable 
         //         fix is not available 
         //  2) Status 
         //     V = Loran-C Cycle Lock warning flag 
         //     A = OK or not used
         //  3) Cross Track Error Magnitude 
         //  4) Direction to steer, L or R 
         //  5) Cross Track Units (Nautic miles or kilometers) 
         //  6) Status 
         //     A = Arrival Circle Entered 
         //  7) Status 
         //     A = Perpendicular passed at waypoint 
         //  8) Bearing origin to destination 
         //  9) M = Magnetic, T = True 
         // 10) Destination Waypoint ID 
         // 11) checksum

         return;
      }

      /// <summary>
      /// Autopilot Sentence "B"
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadAPB(String nmea)
      {
         //  1) Status 
         //     V = LORAN-C Blink or SNR warning 
         //     V = general warning flag or other navigation systems when a reliable 
         //         fix is not available 
         //  2) Status 
         //     V = Loran-C Cycle Lock warning flag 
         //     A = OK or not used 
         //  3) Cross Track Error Magnitude 
         //  4) Direction to steer, L or R 
         //  5) Cross Track Units, N = Nautical Miles 
         //  6) Status 
         //     A = Arrival Circle Entered 
         //  7) Status 
         //     A = Perpendicular passed at waypoint 
         //  8) Bearing origin to destination 
         //  9) M = Magnetic, T = True 
         // 10) Destination Waypoint ID 
         // 11) Bearing, present position to Destination 
         // 12) M = Magnetic, T = True 
         // 13) Heading to steer to destination waypoint 
         // 14) M = Magnetic, T = True 
         // 15) Checksum
         
         return;
      }

      /// <summary>
      /// Bearing & Distance to Waypoint - Dead Reckoning
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadBEC(String nmea)
      {
         //  1) UTCTime 
         //  2) Waypoint Latitude 
         //  3) N = North, S = South 
         //  4) Waypoint Longitude 
         //  5) E = East, W = West 
         //  6) Bearing, True 
         //  7) T = True 
         //  8) Bearing, Magnetic 
         //  9) M = Magnetic 
         // 10) Nautical Miles 
         // 11) N = Nautical Miles 
         // 12) Waypoint ID 
         // 13) Checksum 

         return;
      }

      /// <summary>
      /// Bearing Origin to Destination
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadBOD(String nmea)
      {
         // 1) Bearing Degrees, TRUE 
         // 2) T = True 
         // 3) Bearing Degrees, Magnetic 
         // 4) M = Magnetic 
         // 5) TO Waypoint 
         // 6) FROM Waypoint 
         // 7) Checksum
         
         return;
      }

      /// <summary>
      /// Bearing and Distance to Waypoint, Latitude, N/S, Longitude, E/W, UTC, Status
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadBWC(String nmea)
      {
         //  1) UTCTime 
         //  2) Waypoint Latitude 
         //  3) N = North, S = South 
         //  4) Waypoint Longitude 
         //  5) E = East, W = West 
         //  6) Bearing, True 
         //  7) T = True 
         //  8) Bearing, Magnetic 
         //  9) M = Magnetic 
         // 10) Nautical Miles 
         // 11) N = Nautical Miles 
         // 12) Waypoint ID 
         // 13) Checksum

         return;
      }

      /// <summary>
      /// Bearing and Distance to Waypoint - Rhumb Line, Latitude, N/S, Longitude, E/W, UTC, Status
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadBWR(String nmea)
      {
         //  1) UTCTime 
         //  2) Waypoint Latitude 
         //  3) N = North, S = South 
         //  4) Waypoint Longitude 
         //  5) E = East, W = West 
         //  6) Bearing, True 
         //  7) T = True 
         //  8) Bearing, Magnetic 
         //  9) M = Magnetic 
         // 10) Nautical Miles 
         // 11) N = Nautical Miles 
         // 12) Waypoint ID 
         // 13) Checksum

         return;
      }

      /// <summary>
      /// Bearing - Waypoint to Waypoint
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadBWW(String nmea)
      {
         // 1) Bearing Degrees, TRUE 
         // 2) T = True 
         // 3) Bearing Degrees, Magnetic 
         // 4) M = Magnetic 
         // 5) TO Waypoint 
         // 6) FROM Waypoint 
         // 7) Checksum
         
         return;
      }

      /// <summary>
      /// Depth Below Keel
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadDPK(String nmea)
      {
         // 1) Depth, feet 
         // 2) f = feet 
         // 3) Depth, meters 
         // 4) M = meters 
         // 5) Depth, Fathoms 
         // 6) F = Fathoms 
         // 7) Checksum

         return;
      }

      /// <summary>
      /// Depth Below Surface
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadDBS(String nmea)
      {
         // 1) Depth, feet 
         // 2) f = feet 
         // 3) Depth, meters 
         // 4) M = meters 
         // 5) Depth, Fathoms 
         // 6) F = Fathoms 
         // 7) Checksum
         
         return;
      }

      /// <summary>
      /// Depth below transducer
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadDBT(String nmea)
      {
         // 1) Depth, feet 
         // 2) f = feet 
         // 3) Depth, meters 
         // 4) M = meters 
         // 5) Depth, Fathoms 
         // 6) F = Fathoms 
         // 7) Checksum

         return;
      }

      /// <summary>
      /// Depth of water
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadDPT(String nmea)
      {
         // 1) Depth, meters 
         // 2) Offset from transducer, 
         //    positive means distance from tansducer to water line 
         //    negative means distance from transducer to keel 
         // 3) Checksum
         
         return;
      }

      /// <summary>
      /// Datum Reference
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadDTM(String nmea)
      {
         // 1) Local datum code 
         //    W84 - WGS84 
         //    W72 - WGS72 
         //    S85 - SGS85 
         //    P90 - PE90 
         //    999 - User defined 
         //    IHO datum code 
         // 2) Local datum sub code 
         // 3) Latitude offset (minute) 
         // 4) Latitude offset mark (N: +, S: -) 
         // 5) Longitude offset (minute) 
         // 6) Longitude offset mark (E: +, W: -) 
         // 7) Altitude offset (m) Always null 
         // 8) Datum  
         //    W84 - WGS84 
         //    W72 - WGS72 
         //    S85 - SGS85 
         //    P90 - PE90 
         //    ... 
         // 9) Checksum

         return;
      }

      /// <summary>
      /// Frequency Set Information
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadFSI(String nmea)
      {
         // 1) Transmitting Frequency 
         // 2) Receiving Frequency 
         // 3) Communications Mode (NMEA Syntax 2) 
         // 4) Power Level 
         // 5) Checksum

         return;
      }

      /// <summary>
      /// GPS Satellite Fault Detection
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadGBS(String nmea)
      {
         // 1) UTC time of the GGA fix addociated with this sentence 
         // 2) Expected error in latitude 
         // 3) Expected error in longitude 
         // 4) Expected error in altitude 
         // 5) Most likely failed satellite 
         // 6) Probability of missed detection for most likely failed satellite 
         // 7) Estimate of bias on most likely failed satellite 
         // 8) Standard deviation on bias estimate 
         // 9) Checksum

         return;
      }

      /// <summary>
      /// Global Positioning System Fix Data, Time, Position and fix related data fora GPS receiver.
      /// </summary>
      /// <param name="nmea"></param>
      private void ReadGGA(String nmea)
      {
         //  1) Universal Time Coordinated (UTC) 
         //  2) Latitude 
         //  3) N or S (North or South) 
         //  4) Longitude 
         //  5) E or W (East or West) 
         //  6) GPS Quality Indicator, 
         //     0 - fix not available, 
         //     1 - GPS fix, 
         //     2 - Differential GPS fix 
         //  7) Number of satellites in view, 00 - 12 
         //  8) Horizontal Dilution of precision 
         //  9) Antenna Altitude above/below mean-sea-level (geoid)  
         // 10) Units of antenna altitude, meters 
         // 11) Geoidal separation, the difference between the WGS-84 earth 
         //     ellipsoid and mean-sea-level (geoid), "-" means mean-sea-level 
         //     below ellipsoid 
         // 12) Units of geoidal separation, meters 
         // 13) Age of differential GPS data, time in seconds since last SC104 
         //     type 1 or 9 update, null field when DGPS is not used 
         // 14) Differential reference station ID, 0000-1023 
         // 15) Checksum

         return;
      }
   }
}
