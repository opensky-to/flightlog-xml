// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TouchDown.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Globalization;
    using System.Xml.Linq;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Touchdown.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public class TouchDown
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="TouchDown"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// -------------------------------------------------------------------------------------------------
        public TouchDown()
        {
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="TouchDown"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 17/11/2021.
        /// </remarks>
        /// <param name="timestamp">
        /// The timestamp of the landing.
        /// </param>
        /// <param name="latitude">
        /// Gets or sets the latitude.
        /// </param>
        /// <param name="longitude">
        /// Gets or sets the longitude.
        /// </param>
        /// <param name="altitude">
        /// Gets or sets the altitude.
        /// </param>
        /// <param name="landingRate">
        /// The landing rate.
        /// </param>
        /// <param name="gForce">
        /// The G-force.
        /// </param>
        /// <param name="forwardSpeed">
        /// The forward speed.
        /// </param>
        /// <param name="sidewardsSpeed">
        /// The sidewards speed.
        /// </param>
        /// <param name="headWind">
        /// The head wind.
        /// </param>
        /// <param name="crossWind">
        /// The cross wind.
        /// </param>
        /// <param name="bankAngle">
        /// The bank angle.
        /// </param>
        /// <param name="groundSpeed">
        /// The ground speed.
        /// </param>
        /// <param name="airspeed">
        /// The airspeed.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public TouchDown(DateTime timestamp, double latitude, double longitude, int altitude, double landingRate, double gForce, double forwardSpeed, double sidewardsSpeed, double headWind, double crossWind, double bankAngle, double groundSpeed, double airspeed)
        {
            this.Timestamp = timestamp;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
            this.LandingRate = landingRate;
            this.GForce = gForce;
            this.SideSlipAngle = Math.Atan(sidewardsSpeed / forwardSpeed) * 180.0 / Math.PI;
            this.HeadWind = headWind;
            this.CrossWind = crossWind;
            this.BankAngle = bankAngle;
            this.GroundSpeed = groundSpeed;
            this.Airspeed = airspeed;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="TouchDown"/> class.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <param name="touchdown">
        /// The touchdown XML element.
        /// </param>
        /// -------------------------------------------------------------------------------------------------
        public TouchDown(XElement touchdown)
        {
            this.Timestamp= DateTime.ParseExact(touchdown.EnsureAttribute("Timestamp").Value, "O", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            this.Latitude = double.Parse(touchdown.EnsureAttribute("Lat").Value);
            this.Longitude = double.Parse(touchdown.EnsureAttribute("Lon").Value);
            this.Altitude = int.Parse(touchdown.EnsureAttribute("Alt").Value);
            this.LandingRate = double.Parse(touchdown.EnsureAttribute("LandingRate").Value);
            this.GForce = double.Parse(touchdown.EnsureAttribute("GForce").Value);
            this.SideSlipAngle = double.Parse(touchdown.EnsureAttribute("SideSlipAngle").Value);
            this.HeadWind = double.Parse(touchdown.EnsureAttribute("HeadWind").Value);
            this.CrossWind = double.Parse(touchdown.EnsureAttribute("CrossWind").Value);
            this.BankAngle = double.Parse(touchdown.EnsureAttribute("BankAngle").Value);
            this.GroundSpeed = double.Parse(touchdown.EnsureAttribute("GroundSpeed").Value);
            this.Airspeed = double.Parse(touchdown.EnsureAttribute("Airspeed").Value);
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the airspeed.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double Airspeed { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public int Altitude { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the bank angle.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double BankAngle { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the cross wind.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double CrossWind { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the G-force.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double GForce { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the ground speed.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double GroundSpeed { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the head wind.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double HeadWind { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the landing rate.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double LandingRate { get; set; }

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
        /// Gets or sets the side slip angle.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double SideSlipAngle { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the timestamp of the landing.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public DateTime Timestamp { get; set; }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the wind angle in degrees.
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double WindAngle => Math.Atan2(this.CrossWind, this.HeadWind) * 180.0 / Math.PI;

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the wind in knots (direction in WindAngle!).
        /// </summary>
        /// -------------------------------------------------------------------------------------------------
        public double WindKnots => Math.Sqrt(Math.Pow(this.CrossWind, 2) + Math.Pow(this.HeadWind, 2));

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the touchdown XElement for the flight log XML file.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <returns>
        /// The touchdown.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        public XElement GetXMLElement()
        {
            var touchdown = new XElement("Touchdown");
            touchdown.SetAttributeValue("Timestamp", $"{this.Timestamp:O}");
            touchdown.SetAttributeValue("Lat", $"{this.Latitude}");
            touchdown.SetAttributeValue("Lon", $"{this.Longitude}");
            touchdown.SetAttributeValue("Alt", $"{this.Altitude}");
            touchdown.SetAttributeValue("LandingRate", $"{this.LandingRate:F0}");
            touchdown.SetAttributeValue("GForce", $"{this.GForce:F2}");
            touchdown.SetAttributeValue("SideSlipAngle", $"{this.SideSlipAngle:F2}");
            touchdown.SetAttributeValue("HeadWind", $"{this.HeadWind:F2}");
            touchdown.SetAttributeValue("CrossWind", $"{this.CrossWind:F2}");
            touchdown.SetAttributeValue("BankAngle", $"{this.CrossWind:F2}");
            touchdown.SetAttributeValue("GroundSpeed", $"{this.GroundSpeed:F0}");
            touchdown.SetAttributeValue("Airspeed", $"{this.Airspeed:F0}");
            return touchdown;
        }
    }
}