// <copyright file="Length.cs" company="McGowans Print">
// Copyright (c) McGowans Print. All rights reserved.
// </copyright>

namespace Length
{
    using System;

    /// <summary>
    /// Represents a physical length in meters.
    /// </summary>
    public struct Length : IComparable, IComparable<Length>, IEquatable<Length>, IConvertible
    {
        /// <summary>
        /// Internal storage of this length expressed in meters.
        /// </summary>
        private readonly double lengthInMeters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> struct expressed in meters.
        /// </summary>
        /// <param name="lengthInMeters">The size of this <see cref="Length"/> in meters.</param>
        public Length(double lengthInMeters)
        {
            if (double.IsNaN(lengthInMeters))
            {
                throw new ArgumentException("A length must be a valid positive number.");
            }

            if (lengthInMeters < 0)
            {
                throw new ArgumentException("A length must be positive.");
            }

            if (double.IsPositiveInfinity(lengthInMeters))
            {
                throw new ArgumentException("A length must be a positive, finite number.");
            }

            this.lengthInMeters = lengthInMeters;
        }

        /// <summary>
        /// Gets the value of this <see cref="Length"/> expressed in meters.
        /// </summary>
        public double LengthInMeters
        {
            get { return this.lengthInMeters; }
        }

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
        /// <returns>The value of this instance converted to a <c>decimal</c>.</returns>
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
            return Convert.ChangeType(this.LengthInMeters, conversionType, provider);
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
    }
}
