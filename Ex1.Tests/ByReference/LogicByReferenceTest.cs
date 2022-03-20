using System.Collections.Generic;
using FluentAssertions;
using Logic;
using Logic.Models;
using Xunit;

namespace Tests.ByReference
{
    public class LogicByReferenceTest
    {
        private User User9 = new User() {Id = 9, Name = "Vladyslav", Username = "user9"};
        private User User10 = new User() {Id = 10, Name = "Vladymir", Username = "user10"};
        
        [Fact]
        public void UnionTest()
        {
            // ARRANGE
            var setC = new List<User>()
            {
                User9,
                User9,
                User10
            };

            var setD = new List<User>()
            {
                User9,
                User9,
            };

            var expected = new List<User>() {User9, User10};

            // ACT
            var actual = setC.UnionByReference(setD);

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DistinctTest()
        {
            // ARRANGE
            var setC = new List<User>()
            {
                User9,
                User9,
                User10
            };

            var expected = new List<User>() {User9, User10};

            // ACT
            var actual = setC.DistinctByReference();

            // ASSERT
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ExceptTest()
        {
            // ARRANGE
            var setC = new List<User>()
            {
                User9,
                User9,
                User10
            };

            var setD = new List<User>()
            {
                User9,
                User9,
            };

            var expected = new List<User>() {User10};

            // ACT
            var actual = setC.ExceptByReference(setD);

            // ASSET
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void IntersectTest()
        {
            // ARRANGE
            var setC = new List<User>()
            {
                User9,
                User9,
                User10
            };

            var setD = new List<User>()
            {
                User9,
                User9,
            };

            var expected = new List<User>() {User9};

            // ACT
            var actual = setC.IntersectByReference(setD);

            // ASSET
            actual.Should().BeEquivalentTo(expected);
        }
    }
}