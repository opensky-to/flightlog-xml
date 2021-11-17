// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlightLogTests.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML.Tests
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Xml.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Flight log tests.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    [TestClass]
    public class FlightLogTests
    {
        private const string EmptyLog =
            "<OpenSky.FlightLog>\r\n  <LogVersion>1.0</LogVersion>\r\n  <Agent />\r\n  <AgentVersion />\r\n  <OpenSkyUser />\r\n  <LocalTimeZone>0</LocalTimeZone>\r\n  <TrackingStarted>0001-01-01T00:00:00.0000000</TrackingStarted>\r\n  <TrackingStopped>0001-01-01T00:00:00.0000000</TrackingStopped>\r\n  <WasAirborne>false</WasAirborne>\r\n  <WarpTimeSaved>00:00:00</WarpTimeSaved>\r\n  <TotalPaused>00:00:00</TotalPaused>\r\n  <Flight>\r\n    <ID>00000000-0000-0000-0000-000000000000</ID>\r\n    <AircraftRegistry></AircraftRegistry>\r\n    <UtcOffset>0.0</UtcOffset>\r\n    <Origin ICAO=\"\" Name=\"\" Lat=\"0\" Lon=\"0\" />\r\n    <Destination ICAO=\"\" Name=\"\" Lat=\"0\" Lon=\"0\" />\r\n    <Alternate ICAO=\"\" Name=\"\" Lat=\"0\" Lon=\"0\" />\r\n    <FuelGallons>0.00</FuelGallons>\r\n    <Payload />\r\n    <PayloadPounds>0.00</PayloadPounds>\r\n  </Flight>\r\n  <EventLog />\r\n  <EventMapMarkers />\r\n  <PositionReports />\r\n  <LandingReport />\r\n  <NavLogWaypoints />\r\n</OpenSky.FlightLog>";

        private const string DemoLog =
            "<OpenSky.FlightLog>\r\n  <LogVersion>1.0</LogVersion>\r\n  <Agent>OpenSky.AgentMSFS</Agent>\r\n  <AgentVersion>1.0.0</AgentVersion>\r\n  <OpenSkyUser>sushi.at</OpenSkyUser>\r\n  <LocalTimeZone>0</LocalTimeZone>\r\n  <TrackingStarted>2021-11-16T23:00:00.0000000Z</TrackingStarted>\r\n  <TrackingStopped>2021-11-16T23:30:00.0000000Z</TrackingStopped>\r\n  <WasAirborne>true</WasAirborne>\r\n  <WarpTimeSaved>00:05:00</WarpTimeSaved>\r\n  <TotalPaused>00:00:30</TotalPaused>\r\n  <Flight>\r\n    <ID>12345678-9012-3456-7890-123456789012</ID>\r\n    <AircraftRegistry>OE-FIX</AircraftRegistry>\r\n    <UtcOffset>3.5</UtcOffset>\r\n    <Origin ICAO=\"LOWW\" Name=\"Schwechat\" Lat=\"48.110279083252\" Lon=\"16.5697212219238\" />\r\n    <Destination ICAO=\"LOWS\" Name=\"Salzburg\" Lat=\"47.7944450378418\" Lon=\"13.0033330917358\" />\r\n    <Alternate ICAO=\"EDDM\" Name=\"Munich\" Lat=\"48.3537826538086\" Lon=\"11.7860860824585\" />\r\n    <FuelGallons>1509.01</FuelGallons>\r\n    <Payload>Test Crash Dummies</Payload>\r\n    <PayloadPounds>5000.00</PayloadPounds>\r\n  </Flight>\r\n  <EventLog>\r\n    <LogEntry Type=\"20\" Time=\"2021-11-16T23:05:00.0000000Z\" Lat=\"48.1225693354019\" Lon=\"16.5341279584542\" Alt=\"648\" Color=\"-16744320\" Message=\"Airborne\" />\r\n  </EventLog>\r\n  <EventMapMarkers>\r\n    <Marker Lat=\"48.0573668507386\" Lon=\"14.3947947598309\" Alt=\"23177\" Size=\"8\" Color=\"-16744320\" ToolTip=\"Altitude: 23176 ft (AGL: 21961 ft, OnGround: False)&#xD;&#xA;TAS: 401 kts, GS: 408 kts&#xD;&#xA;Heading: 26&#xD;&#xA;Fuel on board: 2357.0 gallons&#xD;&#xA;Simulation rate: 1.0&#xD;&#xA;Time of day: Day&#xD;&#xA;&#xD;&#xA;15.11.2021 12:27:13: Position report\" />\r\n  </EventMapMarkers>\r\n  <PositionReports>\r\n    <Position Timestamp=\"2021-11-16T23:10:00.0000000Z\" Lat=\"48.0497967653612\" Lon=\"15.1616691515661\" Alt=\"30222\" AS=\"446\" GS=\"445\" Ground=\"False\" RadAlt=\"29072\" Hdg=\"265\" Fuel=\"2357.31\" SimR=\"1.0\" TOD=\"1\" />\r\n  </PositionReports>\r\n  <LandingReport>\r\n    <Touchdown Timestamp=\"2021-11-16T23:27:00.0000000Z\" Lat=\"47.798559091916\" Lon=\"13.0007162672299\" Alt=\"1422\" LandingRate=\"-111\" GForce=\"1.30\" SideSlipAngle=\"-0.93\" HeadWind=\"1.99\" CrossWind=\"-2.28\" BankAngle=\"-2.28\" GroundSpeed=\"124\" Airspeed=\"122\" />\r\n  </LandingReport>\r\n  <NavLogWaypoints>\r\n    <Waypoint Lat=\"48.057819\" Lon=\"14.289717\" Name=\"BAGSI\" Type=\"wpt\" />\r\n  </NavLogWaypoints>\r\n</OpenSky.FlightLog>";

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Test the save and restore methods.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        [TestMethod]
        public void TestSaveAndRestore()
        {
            var flightLog = new FlightLog();

            var xml = $"{flightLog.GenerateFlightLog()}";
            Debug.WriteLine(xml);
            Assert.AreEqual(xml, EmptyLog);

            flightLog.Agent = "OpenSky.AgentMSFS";
            flightLog.AgentVersion = "1.0.0";
            flightLog.OpenSkyUser = "sushi.at";
            flightLog.LocalTimeZone = 0;
            flightLog.TrackingStarted = new DateTime(2021, 11, 16, 23, 0, 0, DateTimeKind.Utc);
            flightLog.TrackingStopped = new DateTime(2021, 11, 16, 23, 30, 0, DateTimeKind.Utc);
            flightLog.WasAirborne = true;
            flightLog.TimeSavedBecauseOfSimRate = TimeSpan.FromMinutes(5);
            flightLog.TotalPaused = TimeSpan.FromSeconds(30);

            flightLog.FlightID = Guid.Parse("12345678-9012-3456-7890-123456789012");
            flightLog.AircraftRegistry = "OE-FIX";
            flightLog.UtcOffset = 3.5;

            flightLog.Origin = new FlightLogAirport
            {
                Icao = "LOWW",
                Name = "Schwechat",
                Latitude = 48.110279083252,
                Longitude = 16.5697212219238
            };

            flightLog.Destination = new FlightLogAirport
            {
                Icao = "LOWS",
                Name = "Salzburg",
                Latitude = 47.7944450378418,
                Longitude = 13.0033330917358
            };

            flightLog.Alternate = new FlightLogAirport
            {
                Icao = "EDDM",
                Name = "Munich",
                Latitude = 48.3537826538086,
                Longitude = 11.7860860824585
            };

            flightLog.FuelGallons = 1509.01;
            flightLog.Payload = "Test Crash Dummies";
            flightLog.PayloadPounds = 5000;

            flightLog.TrackingEventLogEntries.Add(new TrackingEventLogEntry
            {
                EventTime = new DateTime(2021, 11, 16, 23, 5, 0, DateTimeKind.Utc),
                EventType = FlightTrackingEventType.Airborne,
                Latitude = 48.1225693354019,
                Longitude = 16.5341279584542,
                Altitude = 648,
                EventColor = Color.FromArgb(Color.Teal.ToArgb()),
                LogMessage = "Airborne"
            });

            flightLog.TrackingEventMarkers.Add(new TrackingEventMarker
            {
                Latitude = 48.0573668507386,
                Longitude = 14.3947947598309,
                Altitude = 23177,
                MarkerSize = 8,
                MarkerColor = Color.FromArgb(Color.Teal.ToArgb()),
                MarkerTooltip = "Altitude: 23176 ft (AGL: 21961 ft, OnGround: False)\r\nTAS: 401 kts, GS: 408 kts\r\nHeading: 26\r\nFuel on board: 2357.0 gallons\r\nSimulation rate: 1.0\r\nTime of day: Day\r\n\r\n15.11.2021 12:27:13: Position report"
            });

            flightLog.PositionReports.Add(new PositionReport
            {
                Timestamp = new DateTime(2021, 11, 16, 23, 10, 0, DateTimeKind.Utc),
                Latitude = 48.0497967653612,
                Longitude = 15.1616691515661,
                Altitude = 30222,
                Airspeed = 446,
                Groundspeed = 445,
                OnGround = false,
                RadioAlt = 29072,
                Heading = 265,
                FuelOnBoard = 2357.31,
                SimulationRate = 1.0,
                TimeOfDay = TimeOfDay.Day
            });

            flightLog.TouchDowns.Add(new TouchDown
            {
                Timestamp = new DateTime(2021, 11, 16, 23, 27, 0, DateTimeKind.Utc),
                Latitude = 47.798559091916,
                Longitude = 13.0007162672299,
                Altitude = 1422,
                LandingRate = -111,
                GForce = 1.3,
                SideSlipAngle = -0.93,
                HeadWind = 1.99,
                CrossWind = -2.28,
                BankAngle = -2.28,
                GroundSpeed = 124,
                Airspeed = 122
            });

            flightLog.NavLogWaypoints.Add(new Waypoint
            {
                Latitude = 48.057819,
                Longitude = 14.289717,
                WaypointName = "BAGSI",
                WaypointType = "wpt"
            });

            xml = $"{flightLog.GenerateFlightLog()}";
            Debug.WriteLine(xml);
            Assert.AreEqual(xml, DemoLog);

            var newFlightLog = new FlightLog();
            newFlightLog.RestoreFlightLog(XElement.Parse(xml));

            Assert.AreEqual(newFlightLog.Agent, flightLog.Agent);
            Assert.AreEqual(newFlightLog.AgentVersion, flightLog.AgentVersion);
            Assert.AreEqual(newFlightLog.OpenSkyUser, flightLog.OpenSkyUser);
            Assert.AreEqual(newFlightLog.LocalTimeZone, flightLog.LocalTimeZone);
            Assert.AreEqual(newFlightLog.TrackingStarted, flightLog.TrackingStarted);
            Assert.AreEqual(newFlightLog.TrackingStopped, flightLog.TrackingStopped);
            Assert.AreEqual(newFlightLog.WasAirborne, flightLog.WasAirborne);
            Assert.AreEqual(newFlightLog.TimeSavedBecauseOfSimRate, flightLog.TimeSavedBecauseOfSimRate);
            Assert.AreEqual(newFlightLog.TotalPaused, flightLog.TotalPaused);

            Assert.AreEqual(newFlightLog.FlightID, flightLog.FlightID);
            Assert.AreEqual(newFlightLog.AircraftRegistry, flightLog.AircraftRegistry);
            Assert.AreEqual(newFlightLog.UtcOffset, flightLog.UtcOffset);

            Assert.AreEqual(newFlightLog.Origin.Icao, flightLog.Origin.Icao);
            Assert.AreEqual(newFlightLog.Origin.Name, flightLog.Origin.Name);
            Assert.AreEqual(newFlightLog.Origin.Latitude, flightLog.Origin.Latitude);
            Assert.AreEqual(newFlightLog.Origin.Longitude, flightLog.Origin.Longitude);

            Assert.AreEqual(newFlightLog.Destination.Icao, flightLog.Destination.Icao);
            Assert.AreEqual(newFlightLog.Destination.Name, flightLog.Destination.Name);
            Assert.AreEqual(newFlightLog.Destination.Latitude, flightLog.Destination.Latitude);
            Assert.AreEqual(newFlightLog.Destination.Longitude, flightLog.Destination.Longitude);

            Assert.AreEqual(newFlightLog.Alternate.Icao, flightLog.Alternate.Icao);
            Assert.AreEqual(newFlightLog.Alternate.Name, flightLog.Alternate.Name);
            Assert.AreEqual(newFlightLog.Alternate.Latitude, flightLog.Alternate.Latitude);
            Assert.AreEqual(newFlightLog.Alternate.Longitude, flightLog.Alternate.Longitude);

            Assert.AreEqual(newFlightLog.FuelGallons, flightLog.FuelGallons);
            Assert.AreEqual(newFlightLog.Payload, flightLog.Payload);
            Assert.AreEqual(newFlightLog.PayloadPounds, flightLog.PayloadPounds);

            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].EventType, flightLog.TrackingEventLogEntries[0].EventType);
            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].EventTime, flightLog.TrackingEventLogEntries[0].EventTime);
            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].Latitude, flightLog.TrackingEventLogEntries[0].Latitude);
            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].Longitude, flightLog.TrackingEventLogEntries[0].Longitude);
            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].Altitude, flightLog.TrackingEventLogEntries[0].Altitude);
            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].EventColor, flightLog.TrackingEventLogEntries[0].EventColor);
            Assert.AreEqual(newFlightLog.TrackingEventLogEntries[0].LogMessage, flightLog.TrackingEventLogEntries[0].LogMessage);

            Assert.AreEqual(newFlightLog.TrackingEventMarkers[0].Latitude, flightLog.TrackingEventMarkers[0].Latitude);
            Assert.AreEqual(newFlightLog.TrackingEventMarkers[0].Longitude, flightLog.TrackingEventMarkers[0].Longitude);
            Assert.AreEqual(newFlightLog.TrackingEventMarkers[0].Altitude, flightLog.TrackingEventMarkers[0].Altitude);
            Assert.AreEqual(newFlightLog.TrackingEventMarkers[0].MarkerSize, flightLog.TrackingEventMarkers[0].MarkerSize);
            Assert.AreEqual(newFlightLog.TrackingEventMarkers[0].MarkerColor, flightLog.TrackingEventMarkers[0].MarkerColor);
            Assert.AreEqual(newFlightLog.TrackingEventMarkers[0].MarkerTooltip, flightLog.TrackingEventMarkers[0].MarkerTooltip);

            Assert.AreEqual(newFlightLog.TouchDowns[0].Timestamp, flightLog.TouchDowns[0].Timestamp);
            Assert.AreEqual(newFlightLog.TouchDowns[0].Latitude, flightLog.TouchDowns[0].Latitude);
            Assert.AreEqual(newFlightLog.TouchDowns[0].Longitude, flightLog.TouchDowns[0].Longitude);
            Assert.AreEqual(newFlightLog.TouchDowns[0].Altitude, flightLog.TouchDowns[0].Altitude);
            Assert.AreEqual(newFlightLog.TouchDowns[0].LandingRate, flightLog.TouchDowns[0].LandingRate);
            Assert.AreEqual(newFlightLog.TouchDowns[0].GForce, flightLog.TouchDowns[0].GForce);
            Assert.AreEqual(newFlightLog.TouchDowns[0].SideSlipAngle, flightLog.TouchDowns[0].SideSlipAngle);
            Assert.AreEqual(newFlightLog.TouchDowns[0].HeadWind, flightLog.TouchDowns[0].HeadWind);
            Assert.AreEqual(newFlightLog.TouchDowns[0].CrossWind, flightLog.TouchDowns[0].CrossWind);
            Assert.AreEqual(newFlightLog.TouchDowns[0].BankAngle, flightLog.TouchDowns[0].BankAngle);
            Assert.AreEqual(newFlightLog.TouchDowns[0].GroundSpeed, flightLog.TouchDowns[0].GroundSpeed);
            Assert.AreEqual(newFlightLog.TouchDowns[0].Airspeed, flightLog.TouchDowns[0].Airspeed);

            Assert.AreEqual(newFlightLog.NavLogWaypoints[0].Latitude, flightLog.NavLogWaypoints[0].Latitude);
            Assert.AreEqual(newFlightLog.NavLogWaypoints[0].Longitude, flightLog.NavLogWaypoints[0].Longitude);
            Assert.AreEqual(newFlightLog.NavLogWaypoints[0].WaypointName, flightLog.NavLogWaypoints[0].WaypointName);
            Assert.AreEqual(newFlightLog.NavLogWaypoints[0].WaypointType, flightLog.NavLogWaypoints[0].WaypointType);

            xml = xml.Replace("Lat", "Latitude");
            Assert.ThrowsException<Exception>(() => newFlightLog.RestoreFlightLog(XElement.Parse(xml)));
        }
    }
}