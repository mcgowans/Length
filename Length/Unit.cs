// <copyright file="Unit.cs" company="McGowans Print">
// Copyright (c) McGowans Print. All rights reserved.
// </copyright>

namespace LengthLib
{
    /// <summary>
    /// Represents a unit of physical measurement.
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class
        /// </summary>
        /// <param name="multiplier">The value to multiply a length in meters by to convert it to this <see cref="Unit"/>.</param>
        /// <param name="name">The name of this <see cref="Unit"/>.</param>
        /// <param name="abbreviation">The abbreviated form of this <see cref="Unit"/>.</param>
        public Unit(double multiplier, string name, string abbreviation)
        {
            this.Multiplier = multiplier;
            this.Name = name;
            this.Abbreviation = abbreviation;
        }

        /// <summary>
        /// Gets the value to multiply a length in meters by to convert it to this <see cref="Unit"/>.
        /// </summary>
        public double Multiplier { get; }

        /// <summary>
        /// Gets the name of this <see cref="Unit"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the abbreviated form of this <see cref="Unit"/>.
        /// </summary>
        public string Abbreviation { get; }
    }
}
