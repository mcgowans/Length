// <copyright file="Length.cs" company="McGowans Print">
// Copyright (c) McGowans Print. All rights reserved.
// </copyright>

namespace LengthLib
{
    using System;

    /// <summary>
    /// Represents a physical length in meters.
    /// </summary>
    public struct Length : IComparable, IComparable<Length>, IEquatable<Length>, IConvertible
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> struct expressed in the given units.
        /// </summary>
        /// <param name="length">The size of this <see cref="Length"/> in the given units.</param>
        /// <param name="units">The <see cref="Unit"/> to express this value in.</param>
        public Length(double length, Unit units)
        {
            if (double.IsNaN(length))
            {
                throw new ArgumentException("A length must be a valid positive number.");
            }

            if (length < 0)
            {
                throw new ArgumentException("A length must be positive.");
            }

            if (double.IsPositiveInfinity(length))
            {
                throw new ArgumentException("A length must be a positive, finite number.");
            }

            this.Units = units ?? LengthLib.Units.Meters;
            this.LengthInMeters = length * this.Units.Multiplier;
            this.Value = length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> struct expressed in meters.
        /// </summary>
        /// <param name="lengthInMeters">The size of this <see cref="Length"/> in meters.</param>
        public Length(double lengthInMeters) : this(lengthInMeters, null)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the value of this <see cref="Length"/> expressed in meters.
        /// </summary>
        public double LengthInMeters { get; }

        /// <summary>
        /// Gets the unit to use for this <see cref="Length"/>.
        /// </summary>
        public Unit Units { get; }

        /// <summary>
        /// Gets the value of this <see cref="Length"/> expressed in the given units.
        /// </summary>
        public double Value { get; }
        #endregion

        #region Equality Operators
        /// <summary>
        /// Determines if two <see cref="Length"/> instances are equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> represent the same value. Otherwise,
        /// <c>false</c>.</returns>
        public static bool operator ==(Length a, Length b)
        {
            return a.LengthInMeters == b.LengthInMeters;
        }

        /// <summary>
        /// Determines if a <see cref="Length"/> instance in meters is equal to a given <c>double</c>.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The <c>double</c> to compare to the <see cref="Length"/> in meters.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> represent the same value. Otherwise,
        /// <c>false</c>.</returns>
        public static bool operator ==(Length a, double b)
        {
            return a.LengthInMeters == b;
        }

        /// <summary>
        /// Determines if a given <c>double</c> is equal to a <see cref="Length"/> instance in meters.
        /// </summary>
        /// <param name="a">The <c>double</c> to compare to the <see cref="Length"/> in meters.</param>
        /// <param name="b">The <see cref="Length"/> instance to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> represent the same value. Otherwise,
        /// <c>false</c>.</returns>
        public static bool operator ==(double a, Length b)
        {
            return a == b.LengthInMeters;
        }

        /// <summary>
        /// Determines if two <see cref="Length"/> instances are not equal.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The second instance to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal. Otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Length a, Length b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Determines if a <see cref="Length"/> instance in meters is not equal to a given <c>double</c>.
        /// </summary>
        /// <param name="a">The first instance to compare.</param>
        /// <param name="b">The <c>double</c> to compare to the <see cref="Length"/> in meters.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal. Otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Length a, double b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Determines if a given <c>double</c> is not equal to a <see cref="Length"/> instance in meters.
        /// </summary>
        /// <param name="a">The <c>double</c> to compare to the <see cref="Length"/> in meters.</param>
        /// <param name="b">The <see cref="Length"/> instance to compare.</param>
        /// <returns><c>true</c> if <c>a</c> and <c>b</c> are not equal. Otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(double a, Length b)
        {
            return !(a == b);
        }
        #endregion

        #region Unary Operators
        /// <summary>
        /// Increments a <see cref="Length"/> instance by one unit to produce a new value.
        /// </summary>
        /// <param name="a">The <see cref="Length"/> to increment by one unit.</param>
        /// <returns>A new <see cref="Length"/> value that's 1 greater than the input value.</returns>
        public static Length operator ++(Length a)
        {
            double newLength = a.Value;
            newLength++;

            return new Length(newLength, a.Units);
        }

        /// <summary>
        /// Decrement a <see cref="Length"/> instance by one unit to produce a new value.
        /// </summary>
        /// <param name="a">The <see cref="Length"/> to decrement by one unit.</param>
        /// <returns>A new <see cref="Length"/> value that's 1 less than the input value.</returns>
        public static Length operator --(Length a)
        {
            double newLength = a.Value;
            newLength--;

            return new Length(newLength, a.Units);
        }
        #endregion

        #region Binary Operators
        /// <summary>
        /// Adds two <see cref="Length"/> instances to produce a new value.
        /// </summary>
        /// <param name="a">The first <see cref="Length"/> to add.</param>
        /// <param name="b">The second <see cref="Length"/> to add.</param>
        /// <returns>A new <see cref="Length"/> value representing the addition of both inputs.</returns>
        /// <remarks>If both inputs use the same units, this will carry through to the result.
        /// Otherwise, the result will be calculated in meters.</remarks>
        public static Length operator +(Length a, Length b)
        {
            if (a.Units == b.Units)
            {
                return new Length(a.Value + b.Value, a.Units);
            }

            return new Length(a.LengthInMeters + b.LengthInMeters);
        }

        /// <summary>
        /// Subtracts one <see cref="Length"/> instance from another to produce a new value.
        /// </summary>
        /// <param name="a">The first <see cref="Length"/> instance.</param>
        /// <param name="b">The second <see cref="Length"/> to subtract from the first.</param>
        /// <returns>A new <see cref="Length"/> value representing the subtraction of both inputs.</returns>
        /// <remarks>If both inputs use the same units, this will carry through to the result.
        /// Otherwise, the result will be calculated in meters.</remarks>
        /// <exception cref="ArgumentException">Thrown when <paramref name="b"/> is greater than
        /// <paramref name="a"/>, as this would result in an invalid, negative <see cref="Length"/>.</exception>
        public static Length operator -(Length a, Length b)
        {
            if (a < b)
            {
                throw new ArgumentException("Cannot subtract lengths as it would generate a negative result.");
            }

            if (a.Units == b.Units)
            {
                return new Length(a.Value - b.Value, a.Units);
            }

            return new Length(a.LengthInMeters - b.LengthInMeters);
        }

        /// <summary>
        /// Multiplies two <see cref="Length"/> instances to produce a new value.
        /// </summary>
        /// <param name="a">The first <see cref="Length"/> to multiply.</param>
        /// <param name="b">The second <see cref="Length"/> to multiply.</param>
        /// <returns>A new <see cref="Length"/> value representing the multiplication of both inputs.</returns>
        /// <remarks>If both inputs use the same units, this will carry through to the result.
        /// Otherwise, the result will be calculated in meters.</remarks>
        public static Length operator *(Length a, Length b)
        {
            if (a.Units == b.Units)
            {
                return new Length(a.Value * b.Value, a.Units);
            }

            return new Length(a.LengthInMeters * b.LengthInMeters);
        }

        /// <summary>
        /// Divides two <see cref="Length"/> instances to produce a new value.
        /// </summary>
        /// <param name="a">The first <see cref="Length"/> to divide.</param>
        /// <param name="b">The second <see cref="Length"/> to divide the first input by.</param>
        /// <returns>A new <see cref="Length"/> value representing the division of both inputs.</returns>
        /// <remarks>If both inputs use the same units, this will carry through to the result.
        /// Otherwise, the result will be calculated in meters.</remarks>
        /// <exception cref="DivideByZeroException">Thrown if attempting to divide <paramref name="a"/>
        /// by a zero <see cref="Length"/>.</exception>
        public static Length operator /(Length a, Length b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide a Length by zero.");
            }

            if (a.Units == b.Units)
            {
                return new Length(a.Value / b.Value, a.Units);
            }

            return new Length(a.LengthInMeters / b.LengthInMeters);
        }
        #endregion

        #region Casting
        /// <summary>
        /// Defines an implicit cast from a <see cref="Length"/> to a <c>double</c> value.
        /// </summary>
        /// <param name="l">The <see cref="Length"/> instance to cast to a <c>double</c>.</param>
        public static implicit operator double(Length l) => l.LengthInMeters;

        /// <summary>
        /// Defines an explicit cast from a <c>double</c> to a <see cref="Length"/>.
        /// </summary>
        /// <param name="l">The <c>double</c> value to convert to a <see cref="Length"/> using meters.</param>
        public static explicit operator Length(double l) => new Length(l);
        #endregion

        #region IComparable
        /// <summary>
        /// Compares the current <see cref="Length"/> with another, returning an integer that represents
        /// whether this value precedes, follows, or occurs in the same position as the other value.
        /// </summary>
        /// <param name="other">A <see cref="Length"/> to compare with this value.</param>
        /// <returns>An integer that will be negative if this value precedes <paramref name="other"/>,
        /// positive if it follows it, or zero if they both have the same sort order.</returns>
        public int CompareTo(Length other)
        {
            return this.LengthInMeters.CompareTo(other.LengthInMeters);
        }

        /// <summary>
        /// Compares the current <see cref="Length"/> with another, returning an integer that represents
        /// whether this value precedes, follows, or occurs in the same position as the other value.
        /// </summary>
        /// <param name="obj">An object to compare with this value.</param>
        /// <returns>An integer that will be negative if this value precedes <paramref name="other"/>,
        /// positive if it follows it, or zero if they both have the same sort order.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Length other = (Length)obj;
            if (other != null)
            {
                return this.LengthInMeters.CompareTo(other.LengthInMeters);
            }
            else
            {
                throw new ArgumentException("Object is not a Length");
            }
        }
        #endregion

        #region IEquatable
        /// <summary>
        /// Determines if this <see cref="Length"/> value is equal to another object.
        /// </summary>
        /// <param name="obj">An object to compare to this value.</param>
        /// <returns><c>true</c> if the other object is a <see cref="Length"/> instance, and it has the
        /// same value as this instance. Otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is Length && this == (Length)obj;
        }

        /// <summary>
        /// Determines if this <see cref="Length"/> value is equal to another instance.
        /// </summary>
        /// <param name="other">A <see cref="Length"/> instance to compare to this one.</param>
        /// <returns><c>true</c> if the other instance has the same value as this instance. Otherwise,
        /// <c>false</c>.</returns>
        public bool Equals(Length other)
        {
            return this == other;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.LengthInMeters.GetHashCode();
        }

        /// <summary>
        /// Converts the value of this <see cref="Length"/> object to its string representation.
        /// </summary>
        /// <returns>A string representation of the value of the current <see cref="Length"/> object.</returns>
        public override string ToString()
        {
            return this.LengthInMeters.ToString();
        }
        #endregion

        #region IConvertible
        /// <summary>
        /// Obtains the type code for this <see cref="Length"/> instance.
        /// </summary>
        /// <returns>The value <see cref="TypeCode.Double"/>.</returns>
        public TypeCode GetTypeCode()
        {
            return this.LengthInMeters.GetTypeCode();
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>bool</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns><c>true</c> if the value of this instance is not zero, otherwise it returns
        /// <c>false</c>.</returns>
        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>byte</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>byte</c>.</returns>
        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(this.LengthInMeters);
        }

        /// <summary>
        /// This conversion is not supported. Attempting to use this method throws an
        /// <see cref="InvalidCastException"/>.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>This conversion is not supported. No value is returned.</returns>
        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// This conversion is not supported. Attempting to use this method throws an
        /// <see cref="InvalidCastException"/>.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>This conversion is not supported. No value is returned.</returns>
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>decimal</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>decimal</c>.</returns>
        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>double</c> value. It effectively
        /// just returns the length value unchanged.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>double</c>.</returns>
        public double ToDouble(IFormatProvider provider)
        {
            return this.LengthInMeters;
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>short</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>short</c>.</returns>
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>int</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to an <c>int</c>.</returns>
        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>long</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>long</c>.</returns>
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>sbyte</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>sbyte</c>.</returns>
        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>float</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>float</c>.</returns>
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>string</c> value using the specified
        /// culture-specific formatting.
        /// </summary>
        /// <param name="provider">The culture-specific formatting information.</param>
        /// <returns>The value of this instance converted to a <c>string</c>.</returns>
        public string ToString(IFormatProvider provider)
        {
            return this.LengthInMeters.ToString(provider);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to another <see cref="Type"/> with an equivalent value using the
        /// specified culture-specific formatting.
        /// </summary>
        /// <param name="conversionType">The <see cref="Type"/> to convert this value to.</param>
        /// <param name="provider">The culture-specific formatting information.</param>
        /// <returns>The value of this instance converted to the given <see cref="Type"/>.</returns>
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            string msg = "Conversion from Length to {0} is not currently supported";

            if (typeof(Length).Equals(conversionType))
            {
                return this;
            }

            switch (Type.GetTypeCode(conversionType))
            {
                case TypeCode.Boolean:
                    return this.ToBoolean(provider);
                case TypeCode.Byte:
                    return this.ToByte(provider);
                case TypeCode.Char:
                    return this.ToChar(provider);
                case TypeCode.DateTime:
                    return this.ToDateTime(provider);
                case TypeCode.Decimal:
                    return this.ToDecimal(provider);
                case TypeCode.Double:
                    return this.ToDouble(provider);
                case TypeCode.Int16:
                    return this.ToInt16(provider);
                case TypeCode.Int32:
                    return this.ToInt32(provider);
                case TypeCode.Int64:
                    return this.ToInt64(provider);
                case TypeCode.SByte:
                    return this.ToSByte(provider);
                case TypeCode.Single:
                    return this.ToSingle(provider);
                case TypeCode.String:
                    return this.ToString(provider);
                case TypeCode.UInt16:
                    return this.ToUInt16(provider);
                case TypeCode.UInt32:
                    return this.ToUInt32(provider);
                case TypeCode.UInt64:
                    return this.ToUInt64(provider);
                case TypeCode.Object:
                    return (object)this.LengthInMeters;
                default:
                    throw new InvalidCastException(string.Format(msg, conversionType.Name));
            }
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>ushort</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>ushort</c>.</returns>
        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>uint</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>uint</c>.</returns>
        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(this.LengthInMeters);
        }

        /// <summary>
        /// Converts this <see cref="Length"/> to the equivalent <c>ulong</c> value.
        /// </summary>
        /// <param name="provider">This value is ignored.</param>
        /// <returns>The value of this instance converted to a <c>ulong</c>.</returns>
        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(this.LengthInMeters);
        }
        #endregion
    }
}
