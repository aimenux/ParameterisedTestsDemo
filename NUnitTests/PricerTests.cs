using FluentAssertions;
using Lib;
using Lib.Models;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NUnitTests
{
    public class PricerTests
    {
        private const decimal precision = 0.00001m;

        [TestCase(0, 1.5, 0)]
        [TestCase(1, 2.5, 2.5)]
        [TestCase(2, 3.5, 7)]
        public void Given_Product_Should_Compute_Price(int quantity, double unitPrice, double expectedPrice)
        {
            // arrange
            var productUnitPrice = Convert.ToDecimal(unitPrice);
            var productExpectedPrice = Convert.ToDecimal(expectedPrice);

            var product = new Product
            {
                Quantity = quantity,
                UnitPrice = productUnitPrice
            };

            var pricer = new Pricer();

            // act
            var price = pricer.Compute(product);

            // assert
            price.Should().BeApproximately(productExpectedPrice, precision);
        }

        [Test, TestCaseSource(typeof(FactoryTestCases), nameof(FactoryTestCases.ProductDynamicData))]
        public decimal Given_Product_Should_Compute_Price(int quantity, double unitPrice)
        {
            // arrange
            var productUnitPrice = Convert.ToDecimal(unitPrice);

            var product = new Product
            {
                Quantity = quantity,
                UnitPrice = productUnitPrice
            };

            var pricer = new Pricer();

            // act
            // assert
            return pricer.Compute(product);
        }

        [Test, TestCaseSource(nameof(GetDynamicData))]
        public void Given_Basket_Should_Compute_Price(Basket basket, double expectedPrice)
        {
            // arrange
            var productExpectedPrice = Convert.ToDecimal(expectedPrice);

            var pricer = new Pricer();

            // act
            var price = pricer.Compute(basket);

            // assert
            price.Should().BeApproximately(productExpectedPrice, precision);
        }

        private static IEnumerable<object[]> GetDynamicData()
        {
            var basket1 = new Basket();
            var basket2 = new Basket
            {
                new Product
                {
                    Quantity = 1,
                    UnitPrice = 2.5m
                }
            };
            var basket3 = new Basket
            {
                new Product
                {
                    Quantity = 1,
                    UnitPrice = 2.5m
                },
                new Product
                {
                    Quantity = 3,
                    UnitPrice = 2.5m
                }
            };

            yield return new object[] { basket1, 0 };
            yield return new object[] { basket2, 2.5 };
            yield return new object[] { basket3, 10 };
        }

        private class FactoryTestCases
        {
            public static IEnumerable ProductDynamicData
            {
                get
                {
                    yield return new TestCaseData(1, 1.5).Returns(1.5);
                    yield return new TestCaseData(3, 1.5).Returns(4.5);
                    yield return new TestCaseData(5, 1.5).Returns(7.5);
                }
            }
        }
    }
}
