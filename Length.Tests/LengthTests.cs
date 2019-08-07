// <copyright file="LengthTests.cs" company="McGowans Print">
// Copyright (c) McGowans Print. All rights reserved.
// </copyright>

namespace LengthLib.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Xunit;

    public class LengthTests
    {
        #region Constructors
        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void Constructor_SetsPositiveLengthInMetres_LengthAsSupplied(double length)
        {
            Length l = new Length(length);
            Assert.Equal(length, l.LengthInMeters);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100000)]
        [InlineData(double.MinValue)]
        [InlineData(double.NegativeInfinity)]
        public void Constructor_SetsNegativeLengthInMetres_ThrowsException(double length)
        {
            Assert.Throws<ArgumentException>(() => new Length(length));
        }

        [Fact]
        public void Constructor_SetNonNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Length(double.NaN));
        }

        [Fact]
        public void Constructor_SetInfinity_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Length(double.PositiveInfinity));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void Constructor_SetsPositiveLengthInCentimetres_LengthAsSupplied(double length)
        {
            Length l = new Length(length, Units.Centimeters);
            Assert.Equal(length, l.Value);
            Assert.Equal(length / 100, l.LengthInMeters);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void Constructor_SetsPositiveLengthInMillimetres_LengthAsSupplied(double length)
        {
            Length l = new Length(length, Units.Millimeters);
            Assert.Equal(length, l.Value);
            Assert.Equal(length / 1000, l.LengthInMeters);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void Constructor_SetsPositiveLengthInInches_LengthAsSupplied(double length)
        {
            Length l = new Length(length, Units.Inches);
            Assert.Equal(length, l.Value);

            double meters = length / 39.3700787401;
            if (meters > 0.0)
                Assert.Equal(1.0, meters / l.LengthInMeters,  5);
        }
        #endregion

        #region Equality Operators
        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void EqualityOperator_CompareTwoEqualLengths_ValuesAreEqual(double l)
        {
            Length l1 = new Length(l);
            Length l2 = new Length(l);

            Assert.True(l1 == l2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 10.0)]
        [InlineData(1, 100)]
        [InlineData(100000, 10000000)]
        public void EqualityOperator_CompareTwoEqualLengthsMetersVsCentimeters_ValuesAreEqual(double m, double cm)
        {
            Length l1 = new Length(m);
            Length l2 = new Length(cm, Units.Centimeters);

            Assert.True(l1 == l2);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.1, 100.0)]
        [InlineData(1, 1000)]
        [InlineData(100000, 100000000)]
        public void EqualityOperator_CompareTwoEqualLengthsMetersVsMillimeters_ValuesAreEqual(double m, double mm)
        {
            Length l1 = new Length(m);
            Length l2 = new Length(mm, Units.Millimeters);

            Assert.True(l1 == l2);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0.1, 0.5)]
        [InlineData(1, 100)]
        [InlineData(100000, 100000.001)]
        [InlineData(double.MaxValue, double.MaxValue / 2)]
        [InlineData(double.Epsilon, 0)]
        public void EqualityOperator_CompareTwoUnequalLengths_ValuesAreNotEqual(double a, double b)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(b);

            Assert.False(l1 == l2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void NotEqualOperator_CompareTwoEqualLengths_ValuesAreEqual(double l)
        {
            Length l1 = new Length(l);
            Length l2 = new Length(l);

            Assert.False(l1 != l2);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0.1, 0.5)]
        [InlineData(1, 100)]
        [InlineData(100000, 100000.001)]
        [InlineData(double.MaxValue, double.MaxValue / 2)]
        [InlineData(double.Epsilon, 0)]
        public void NotEqualOperator_CompareTwoUnequalLengths_ValuesAreNotEqual(double a, double b)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(b);

            Assert.True(l1 != l2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void EqualityOperator_CompareLengthWithEqualDouble_ValuesAreEqual(double a)
        {
            Length l = new Length(a);

            Assert.True(l == a);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void EqualityOperator_CompareDoubleWithEqualLength_ValuesAreEqual(double a)
        {
            Length l = new Length(a);

            Assert.True(a == l);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0.1, 0.5)]
        [InlineData(1, 100)]
        [InlineData(100000, 100000.001)]
        [InlineData(double.MaxValue, double.MaxValue / 2)]
        [InlineData(double.Epsilon, 0)]
        public void NotEqualOperator_CompareDoubleWithUnequalLengths_ValuesAreNotEqual(double a, double b)
        {
            Length l = new Length(a);

            Assert.True(l != b);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0.1, 0.5)]
        [InlineData(1, 100)]
        [InlineData(100000, 100000.001)]
        [InlineData(double.MaxValue, double.MaxValue / 2)]
        [InlineData(double.Epsilon, 0)]
        public void NotEqualOperator_CompareLengthWithUnequalDouble_ValuesAreNotEqual(double a, double b)
        {
            Length l = new Length(a);

            Assert.True(l != b);
        }
        #endregion

        #region Casting
        [Theory]
        [InlineData(0, 10)]
        [InlineData(0.1, 0.6)]
        [InlineData(1, 5)]
        [InlineData(100000, 200000)]
        [InlineData(double.MaxValue / 2, double.MaxValue / 3)]
        [InlineData(double.Epsilon, double.Epsilon)]
        public void ImplicitCast_AddsLengthToDouble_ValuesAddCorrectly(double a, double b)
        {
            Length l = new Length(a);

            double total1 = a + b;
            double total2 = l + b;

            Assert.Equal(total1, total2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(100000)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void ExplicitCast_ConvertsDoubleToLength_InstanceCreatedCorrectly(double a)
        {
            Length l = (Length)a;

            Assert.Equal(a, l.LengthInMeters);
        }
        #endregion

        #region IComparable
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 20)]
        [InlineData(double.Epsilon, double.MaxValue)]
        public void IComparable_CompareTwoLengths_FirstIsLess(double a, double b)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(b);

            Assert.True(l1 < l2);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(20, 0)]
        [InlineData(double.MaxValue, double.Epsilon)]
        public void IComparable_CompareTwoLengths_FirstIsMore(double a, double b)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(b);

            Assert.True(l1 > l2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void IComparable_CompareTwoLengths_BothEqual(double a)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(a);
            int cmp = l1.CompareTo(l2);

            Assert.True(cmp == 0);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 2, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(1, double.MaxValue, double.Epsilon)]
        public void IComparable_SortThreeValues_SortedCorrectly(double a, double b, double c)
        {
            List<Length> lengths = new List<Length>();
            lengths.Add((Length)a);
            lengths.Add((Length)b);
            lengths.Add((Length)c);
            lengths.Sort();

            double current = lengths[0];

            foreach(Length l in lengths)
            {
                Assert.True(current <= l);
                current = l;
            }
        }
        #endregion

        #region IEquatable
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void IEquatable_CompareTwoLengths_BothEqual(double a)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(a);

            Assert.True(l1.Equals(l2));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 20)]
        [InlineData(double.Epsilon, double.MaxValue)]
        public void IEquatable_CompareTwoLengths_NotEqual(double a, double b)
        {
            Length l1 = new Length(a);
            Length l2 = new Length(b);

            Assert.False(l1.Equals(l2));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(double.MaxValue)]
        [InlineData(double.Epsilon)]
        public void IEquatable_CompareLengthWithObject_BothEqual(double a)
        {
            Length l1 = new Length(a);
            object l2 = new Length(a);

            Assert.True(l1.Equals(l2));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 20)]
        [InlineData(double.Epsilon, double.MaxValue)]
        public void IEquatable_CompareLengthWithObject_NotEqual(double a, double b)
        {
            Length l1 = new Length(a);
            object l2 = new Length(b);

            Assert.False(l1.Equals(l2));
        }
        #endregion

        #region IConvertible
        [Fact]
        public void IConvertible_GetTypeCode_ReturnCorrectTypeCode()
        {
            Length l = new Length(1);
            TypeCode tc = l.GetTypeCode();

            Assert.Equal(TypeCode.Double, tc);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(double.Epsilon)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToBoolean_IsTrue(double a)
        {
            Length l = new Length(a);
            bool b = l.ToBoolean(null);

            Assert.True(b);
        }

        [Theory]
        [InlineData(0)]
        public void IConvertible_ToBoolean_IsFalse(double a)
        {
            Length l = new Length(a);
            bool b = l.ToBoolean(null);

            Assert.False(b);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(255)]
        public void IConvertible_ToByteInRange_ConversionSuccessful(double a)
        {
            Length l = new Length(a);
            byte b = l.ToByte(null);

            Assert.Equal(a, (double)b);
        }

        [Theory]
        [InlineData(double.Epsilon)]
        [InlineData(0.5)]
        [InlineData(255.1)]
        public void IConvertible_ToByteInRange_ConversionRounded(double a)
        {
            Length l = new Length(a);
            byte b = l.ToByte(null);

            Assert.Equal((byte)a, b);
        }

        [Theory]
        [InlineData(256)]
        [InlineData(1000)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToByteOutOfRange_ThrowsOverflowException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<OverflowException>(() => l.ToByte(null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void IConvertible_ToChar_ThrowsInvalidCastException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<InvalidCastException>(() => l.ToChar(null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void IConvertible_ToDateTime_ThrowsInvalidCastException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<InvalidCastException>(() => l.ToDateTime(null));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(200.25)]
        public void IConvertible_ToDecimal_ConversionSuccessful(double a)
        {
            Length l = new Length(a);
            decimal d = l.ToDecimal(null);

            Assert.Equal(a, (double)d);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(200.25)]
        [InlineData(double.Epsilon)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToDouble_ConversionSuccessful(double a)
        {
            Length l = new Length(a);
            double d = l.ToDouble(null);

            Assert.Equal(a, d);
        }

        [Theory]
        [InlineData(double.Epsilon)]
        [InlineData(0.5)]
        [InlineData(255.1)]
        public void IConvertible_ToInt16InRange_ConversionRounded(double a)
        {
            Length l = new Length(a);
            short i = l.ToInt16(null);

            Assert.Equal((short)a, i);
        }

        [Theory]
        [InlineData(short.MaxValue + 1.0)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToInt16OutOfRange_ThrowsOverflowException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<OverflowException>(() => l.ToInt16(null));
        }

        [Theory]
        [InlineData(double.Epsilon)]
        [InlineData(0.5)]
        [InlineData(255.1)]
        public void IConvertible_ToInt32InRange_ConversionRounded(double a)
        {
            Length l = new Length(a);
            int i = l.ToInt32(null);

            Assert.Equal((int)a, i);
        }

        [Theory]
        [InlineData(int.MaxValue + 1.0)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToInt32OutOfRange_ThrowsOverflowException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<OverflowException>(() => l.ToInt32(null));
        }

        [Theory]
        [InlineData(double.Epsilon)]
        [InlineData(0.5)]
        [InlineData(1024.5)]
        public void IConvertible_ToInt64InRange_ConversionRounded(double a)
        {
            Length l = new Length(a);
            long i = l.ToInt64(null);

            Assert.Equal((int)a, i);
        }

        [Theory]
        [InlineData(long.MaxValue + 1.0)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToInt64OutOfRange_ThrowsOverflowException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<OverflowException>(() => l.ToInt64(null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MaxValue)]
        public void IConvertible_ToSByteInRange_ConversionSuccessful(double a)
        {
            Length l = new Length(a);
            sbyte b = l.ToSByte(null);

            Assert.Equal(a, (double)b);
        }

        [Theory]
        [InlineData(double.Epsilon)]
        [InlineData(0.5)]
        [InlineData(127.1)]
        public void IConvertible_ToSByteInRange_ConversionRounded(double a)
        {
            Length l = new Length(a);
            sbyte b = l.ToSByte(null);

            Assert.Equal((sbyte)a, b);
        }

        [Theory]
        [InlineData(sbyte.MaxValue + 1.0)]
        [InlineData(1000)]
        [InlineData(double.MaxValue)]
        public void IConvertible_ToSByteOutOfRange_ThrowsOverflowException(double a)
        {
            Length l = new Length(a);
            Assert.Throws<OverflowException>(() => l.ToSByte(null));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(200.25)]
        [InlineData(float.MaxValue)]
        public void IConvertible_ToSingle_ConversionSuccessful(double a)
        {
            Length l = new Length(a);
            float f = l.ToSingle(null);

            Assert.Equal(a, (double)f);
        }

        [Theory]
        [InlineData(0.5, "de-DE", "0,5")]
        [InlineData(0.5, "en-US", "0.5")]
        public void IConvertible_ToString_FormatCorrectly(double a, string provider, string expected)
        {
            IFormatProvider p = CultureInfo.GetCultureInfo(provider).NumberFormat;
            Length l = new Length(a);
            string s = l.ToString(p);
            Assert.Equal(expected, s);
        }

        [Theory]
        [InlineData(double.Epsilon, typeof(double))]
        [InlineData(0.0, typeof(float))]
        [InlineData(int.MaxValue, typeof(int))]
        [InlineData(int.MaxValue, typeof(object))]
        public void IConvertible_ToType_ConversionSuccessful(double a, Type t)
        {
            Length l = new Length(a);
            object o1 = l.ToType(t, null);
            object o2 = Convert.ChangeType(a, t);

            Assert.Equal(o1, o2);
        }

        #endregion
    }
}
