using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Logic;
using Logic.Compares;
using Logic.Models;
using Xunit;

namespace Tests
{
    public class LogicForCatsByUniqueGenericComparerByNameTest
    {
        private Cat Vaska =  new Cat() {Id = 1, Name = "Vaska", Color = "Red-head"};
        private Cat FelixBlack = new Cat() {Id = 3, Name = "Felix", Color = "Black"};
        private Cat BarsikWhite = new Cat() {Id = 4, Name = "Barsik", Color = "White"};
        private Cat MashkaGray = new Cat() {Id = 5, Name = "Mashka", Color = "Gray"};
        private Cat FelixCream = new Cat() {Id = 6, Name = "Felix", Color = "Cream"};
        private Cat FelixChocolate = new Cat() {Id = 7, Name = "Felix", Color = "Chocolate"};
     
        [Fact]
        public void UnionTest()
        {
            // ARRANGE
            var setA = new List<Cat>()
            {
                Vaska,
                FelixBlack,
            };
            
            var setB = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixCream,
                FelixChocolate,
            };

            var expected = new List<Cat>()
            {
                Vaska, 
                FelixBlack, 
                BarsikWhite,
                MashkaGray
            };
            
            // ACT
            var actual = setA
                .UnionByComparer(setB, new UniqueGenericComparer<Cat>(c => c.Name));
            
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
                FelixCream,
                FelixChocolate,
            };

            var expected = new List<Cat>()
            {
                BarsikWhite,
                MashkaGray,
                FelixCream,
            };
            
            // ACT
            var actual = setB
                .DistinctByComparer(new UniqueGenericComparer<Cat>(c => c.Name));
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ExceptTest()
        {
            // ARRANGE 
            var setA = new List<Cat>()
            {
                Vaska,
                FelixBlack,
            };
            
            var setB = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixCream,
                FelixChocolate,
            };

            var expected = new List<Cat>()
            {
                Vaska
            };
            
            // ACT
            var actual = setA
                .ExceptByComparer(setB, new UniqueGenericComparer<Cat>(c => c.Name));
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void IntersectTest()
        {
            // ARRANGE
            var setA = new List<Cat>()
            {
                Vaska,
                FelixBlack,
            };
            
            var setB = new List<Cat>()
            {
                BarsikWhite, 
                MashkaGray,
                FelixCream,
                FelixChocolate,
            };

            var expected = new List<Cat>()
            {
                FelixBlack
            };
            
            // ACT
            var actual = setA
                .IntersectByComparer(setB, new UniqueGenericComparer<Cat>(c => c.Name));

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }
    }
}