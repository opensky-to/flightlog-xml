﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlightLog.Properties.cs" company="OpenSky">
// OpenSky project 2021-2023
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Collections.Generic;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Flight log handling.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public partial class FlightLog
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string Agent { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the agent version.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string AgentVersion { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the aircraft registry.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string AircraftRegistry { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the alternate.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public FlightLogAirport Alternate { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public FlightLogAirport Destination { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the zero-based index of the final touchdown.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int FinalTouchDownIndex { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the identifier of the flight.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public Guid FlightID { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the fuel gallons.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double FuelGallons { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the local time zone.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double LocalTimeZone { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the navigation log waypoints.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<Waypoint> NavLogWaypoints { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the OpenSky user.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string OpenSkyUser { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public FlightLogAirport Origin { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string Payload { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the payload pounds.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double PayloadPounds { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the position reports.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<PositionReport> PositionReports { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the time duration the user was connected to an online network during the flight.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public TimeSpan TimeConenctedToOnlineNetwork { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the time saved because of simulation rate.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public TimeSpan TimeSavedBecauseOfSimRate { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the total time paused.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public TimeSpan TotalPaused { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the touchdowns.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<TouchDown> TouchDowns { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the tracking event log entries.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<TrackingEventLogEntry> TrackingEventLogEntries { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the tracking event markers.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public List<TrackingEventMarker> TrackingEventMarkers { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the Date/Time of when the tracking started.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public DateTime TrackingStarted { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the Date/Time of when the tracking stopped.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public DateTime TrackingStopped { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the UTC offset.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double UtcOffset { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether the aircraft was airborne.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool WasAirborne { get; set; }
    }
}