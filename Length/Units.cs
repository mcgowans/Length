// <copyright file="Unit.cs" company="McGowans Print">
// Copyright (c) McGowans Print. All rights reserved.
// </copyright>

namespace Length
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Provides predefined units for convenience.
    /// </summary>
    public static class Units
    {
        public static readonly Unit Centimeters = new Unit(0.01, "centimeters", "cm");
        public static readonly Unit Inches = new Unit(0.0254, "inches", "in");
        public static readonly Unit Meters = new Unit(1.0, "meters", "m");
    }
}
