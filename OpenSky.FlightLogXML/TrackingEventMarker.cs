// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackingEventMarker.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System.Drawing;
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// OpenSky tracking event marker.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class TrackingEventMarker
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int Altitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether this is an airport marker (we don't save those).
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public bool IsAirportMarker { get; set; }

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
        /// Gets or sets the color of the marker.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public Color MarkerColor { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the size of the marker.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int MarkerSize { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the marker tooltip.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string MarkerTooltip { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the event marker entry XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The marker.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement()
        {
            if (this.IsAirportMarker)
            {
                return null;
            }

            var marker = new XElement("Marker");
            marker.SetAttributeValue("Lat", $"{this.Latitude}");
            marker.SetAttributeValue("Lon", $"{this.Longitude}");
            marker.SetAttributeValue("Alt", $"{this.Altitude}");
            marker.SetAttributeValue("MarkerSize", $"{this.MarkerSize}");
            marker.SetAttributeValue("MarkerColor", $"{this.MarkerColor}");
            marker.SetAttributeValue("ToolTip", $"{this.MarkerTooltip}");
            return marker;
        }
    }
}