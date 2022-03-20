using System.Collections.Generic;
using FluentAssertions;
using Logic;
using Logic.Compares;
using Logic.Models;
using Xunit;

namespace Tests
{
    public class LogicForUsersByUserComparerTest
    {
        private User Vasilii =  new User() {Id = 1, Name = "Vasilii", Username = "user1"};
        private User Kristina = new User() {Id = 2, Name = "Kristina", Username = "user2"};
        private User Boris = new User() {Id = 3, Name = "Boris", Username = "user3"};
        
        [Fact]
        public void UnionTest()
        {
            // ARRANGE
            var setA = new List<User>()
            {
                Vasilii,
                Kristina
            };
            
            var setB = new List<User>()
            {
                Boris,
                Kristina
            };

            var expected = new List<User>()
            {
                Vasilii, 
                Kristina,
                Boris
            };
            
            // ACT
            var actual = setA.UnionByComparer(setB, new UserComparer());
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void DistinctTest()
        {
            // ARRANGE
            var setA = new List<User>()
            {
                Vasilii,
                Kristina,
                Kristina,
            };
            
            var expected = new List<User>()
            {
                Vasilii, 
                Kristina
            };
            
            // ACT
            var actual = setA.DistinctByComparer(new UserComparer());
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void ExceptTest()
        {
            // ARRANGE
            var setA = new List<User>()
            {
                Vasilii,
                Kristina
            };
            
            var setB = new List<User>()
            {
                Boris,
                Kristina
            };
            
            var expected = new List<User>()
            {
                Vasilii
            };
            
            // ACT
            var actual = setA.ExceptByComparer(setB, new UserComparer());
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void IntersectTest()
        {
            // ARRANGE
            var setA = new List<User>()
            {
                Vasilii,
                Kristina
            };
            
            var setB = new List<User>()
            {
                Boris,
                Kristina
            };
            
            var expected = new List<User>()
            {
                Kristina
            };
            
            // ACT
            var actual = setA.IntersectByComparer(setB, new UserComparer());
            
            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }
    }
}