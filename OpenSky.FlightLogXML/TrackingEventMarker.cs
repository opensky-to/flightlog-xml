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
        /// Initializes a new instance of the <see cref="TrackingEventMarker"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        public TrackingEventMarker()
        {
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="TrackingEventMarker"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <param name="marker">
        /// The marker XML element.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public TrackingEventMarker(XElement marker)
        {
            this.Latitude = double.Parse(marker.EnsureChildElement("Lat").Value);
            this.Longitude = double.Parse(marker.EnsureChildElement("Lon").Value);
            this.Altitude = int.Parse(marker.EnsureChildElement("Alt").Value);
            this.MarkerSize = int.Parse(marker.EnsureChildElement("Size").Value);
            this.MarkerColor = Color.FromArgb(int.Parse(marker.EnsureChildElement("Color").Value));
            this.MarkerTooltip = marker.EnsureChildElement("ToolTip").Value;
        }

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
            marker.SetAttributeValue("Size", $"{this.MarkerSize}");
            marker.SetAttributeValue("Color", $"{this.MarkerColor.ToArgb()}");
            marker.SetAttributeValue("ToolTip", $"{this.MarkerTooltip}");
            return marker;
        }
    }
}