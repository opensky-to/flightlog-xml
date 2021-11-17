// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlightLogAirport.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Flight log airport.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class FlightLogAirport
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightLogAirport"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        public FlightLogAirport()
        {
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightLogAirport"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <param name="airport">
        /// The airport XML element.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public FlightLogAirport(XElement airport)
        {
            this.Icao = airport.EnsureAttribute("ICAO").Value;
            this.Name = airport.EnsureAttribute("Name").Value;
            this.Latitude = double.Parse(airport.EnsureAttribute("Lat").Value);
            this.Longitude = double.Parse(airport.EnsureAttribute("Lon").Value);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the ICAO code.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string Icao { get; set; }

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
        /// Gets or sets the name.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public string Name { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the airport XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The airport.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement(string elementName)
        {
            var airport = new XElement(elementName);
            airport.SetAttributeValue("ICAO", $"{this.Icao}");
            airport.SetAttributeValue("Name", $"{this.Name}");
            airport.SetAttributeValue("Lat", $"{this.Latitude}");
            airport.SetAttributeValue("Lon", $"{this.Longitude}");
            return airport;
        }
    }
}