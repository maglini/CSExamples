using System;
using System.Collections.Generic;
using FluentAssertions;
using Logic;
using Logic.Compares;
using Logic.Models;
using Xunit;

namespace Tests.ByComparer
{
    public class LogicForCatsByUniqueGenericComparerByNameAndColorTest
    {
        private Cat Vaska =  new Cat() {Id = 1, Name = "Vaska", Color = "Red-head"};
        private Cat FelixBlack1 = new Cat() {Id = 3, Name = "Felix", Color = "Black"};
        private Cat BarsikWhite = new Cat() {Id = 4, Name = "Barsik", Color = "White"};
        private Cat MashkaGray = new Cat() {Id = 5, Name = "Mashka", Color = "Gray"};
        private Cat FelixBlack2 = new Cat() {Id = 6, Name = "Felix", Color = "Black"};
        private Cat FelixChocolate = new Cat() {Id = 7, Name = "Felix", Color = "Chocolate"};

        [Fact]
        public void UnionTest()
        {
            // ARRANGE
            var setA = new List<Cat>()
            {
                Vaska,
                FelixBlack1,
            };
            
            var setB = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixBlack2,
                FelixChocolate,
            };

            var expected = new List<Cat>()
            {
                Vaska,
                FelixBlack1,
                BarsikWhite, 
                MashkaGray,
                FelixChocolate,
            };
            
            // ACT
            var actual = setA
                .UnionByComparer(setB, new UniqueGenericComparer<Cat>(new List<Func<Cat, object>>()
                {
                    new Func<Cat, object>(c=>c.Name),
                    new Func<Cat, object>(c=>c.Color)
                }));
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DistinctTest()
        {
            // ARRANGE
            var setB = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixBlack1,
                FelixBlack2,
                FelixChocolate,
            };

            var expected = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixBlack1,
                FelixChocolate,
            };
            
            // ACT
            var actual = setB
                .DistinctByComparer(new UniqueGenericComparer<Cat>(new List<Func<Cat, object>>()
                {
                    new Func<Cat, object>(c=>c.Name),
                    new Func<Cat, object>(c=>c.Color)
                }));
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ExceptTest()
        {
            // ARRANGE
            var setA = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixBlack2,
                FelixChocolate,
            };
            
            var setB = new List<Cat>()
            {
                Vaska,
                FelixBlack1,
            };

            var expected = new List<Cat>()
            { 
                BarsikWhite, 
                MashkaGray,
                FelixChocolate,
            };
            
            // ACT
            var actual = setA.ExceptByComparer(setB, new UniqueGenericComparer<Cat>(new List<Func<Cat, object>>()
            {
                new Func<Cat, object>(c=>c.Name),
                new Func<Cat, object>(c=>c.Color)
            }));

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void IntersectTest()
        {
            // ARRANGE
            var setA = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixBlack2,
                FelixChocolate,
            };
            
            var setB = new List<Cat>()
            {
                Vaska,
                FelixBlack1,
            };

            var expected = new List<Cat>()
            {
                FelixBlack2,
            };
            
            // ACT
            var actual = setA.IntersectByComparer(setB, new UniqueGenericComparer<Cat>(new List<Func<Cat, object>>()
            {
                new Func<Cat, object>(c=>c.Name),
                new Func<Cat, object>(c=>c.Color)
            }));

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }
    }
}