// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeOfDay.cs" company="OpenSky">
// OpenSky project 2021
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Time of day enum (same as SimConnect).
    /// </summary>
    /// <remarks>
    /// sushi.at, 14/03/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public enum TimeOfDay
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Day.
        /// </summary>
        Day = 1,

        /// <summary>
        /// Dusk/Dawn.
        /// </summary>
        DuskDawn = 2,

        /// <summary>
        /// Night.
        /// </summary>
        Night = 3
    }
}