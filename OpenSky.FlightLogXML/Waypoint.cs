// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Waypoint.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// NavLog waypoint.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class Waypoint
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Latitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Longitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the name of the waypoint.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string WaypointName { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the type of the waypoint.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string WaypointType { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the navlog waypoint XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The waypoint.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement()
        {
            var waypoint = new XElement("Waypoint");
            waypoint.SetAttributeValue("Lat", $"{this.Latitude}");
            waypoint.SetAttributeValue("Lon", $"{this.Longitude}");
            waypoint.SetAttributeValue("Name", $"{this.WaypointName}");
            waypoint.SetAttributeValue("Type", $"{this.WaypointType}");
            return waypoint;
        }
    }
}