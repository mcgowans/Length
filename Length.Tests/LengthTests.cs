// <copyright file="LengthTests.cs" company="McGowans Print">
// Copyright (c) McGowans Print. All rights reserved.
// </copyright>

namespace Length.Tests
{
    using System;
    using System.Collections.Generic;
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
    }
}
