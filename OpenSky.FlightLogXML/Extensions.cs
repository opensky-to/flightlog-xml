// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="OpenSky">
// OpenSky project 2021-2023
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OpenSky.FlightLogXML
{
    using System;
    using System.Diagnostics;
    using System.Xml.Linq;

    using JetBrains.Annotations;

    /// -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Extension methods.
    /// </summary>
    /// <remarks>
    /// sushi.at, 16/11/2021.
    /// </remarks>
    /// -------------------------------------------------------------------------------------------------
    public static class Extensions
    {
        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Extension method that ensures that a specific XAttribute of a XElement exists - throws
        /// exception if not.
        /// </summary>
        /// <remarks>
        /// sushi.at, 16/11/2021.
        /// </remarks>
        /// <exception cref="Exception">
        /// Thrown when an exception error condition occurs.
        /// </exception>
        /// <param name="element">
        /// The element to act on.
        /// </param>
        /// <param name="attribute">
        /// The attribute. This cannot be null.
        /// </param>
        /// <returns>
        /// An XAttribute. This will never be null.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        [NotNull]
        public static XAttribute EnsureAttribute(this XElement element, [NotNull] string attribute)
        {
            var xAttribute = element.Attribute(attribute);
            if (xAttribute == null)
            {
                Debug.WriteLine($"Flight log file malformed: Missing attribute {attribute}");
                throw new Exception("Flight log file malformed!");
            }

            return xAttribute;
        }

        /// -------------------------------------------------------------------------------------------------
        /// <summary>
        /// Extension method that ensures that a specific child XElement of a parent one exists - throws exception if not.
        /// </summary>
        /// <remarks>
        /// sushi.at, 01/04/2021.
        /// </remarks>
        /// <exception cref="Exception">
        /// Thrown when an exception error condition occurs.
        /// </exception>
        /// <param name="parent">
        /// The parent. This cannot be null.
        /// </param>
        /// <param name="child">
        /// The child. This cannot be null.
        /// </param>
        /// <returns>
        /// An XElement. This will never be null.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        [NotNull]
        public static XElement EnsureChildElement(this XElement parent, [NotNull] string child)
        {
            var childElement = parent.Element(child);
            if (childElement == null)
            {
                Debug.WriteLine($"Flight log file malformed: Missing element {child}");
                throw new Exception("Flight log file malformed!");
            }

            return childElement;
        }
    }
}