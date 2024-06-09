using VillageOfTesting;
using Xunit;

namespace TestingClass.Tests
{
    public class VillageTests
    {
        [Fact]
        public void Test_AddWorker_ValidOccupation()
        {
            // Arrange
            var village = new Village();

            // Act
            village.AddWorker("John", "farmer");

            // Assert
            Assert.Single(village.Workers);
            Assert.Equal("John", village.Workers[0].Name);
            Assert.Equal("farmer", village.Workers[0].Occupation);
        }

        [Fact]
        public void Test_AddProject_ValidProjectEnoughResources()
        {
            // Arrange
            var village = new Village();
            village.Wood = 10;
            village.Metal = 10;

            // Act
            village.AddProject("Woodmill");

            // Assert
            Assert.Single(village.Projects);
            Assert.Equal("Woodmill", village.Projects[0].Name);
            Assert.Equal(5, village.Wood);
            Assert.Equal(5, village.Metal);
        }

        [Fact]
        public void Test_Day_WorkersStarveNoFood()
        {
            // Arrange
            var village = new Village();
            village.Food = 0;
            village.AddWorker("John", "farmer");

            // Act
            village.Day();

            // Assert
            Assert.Single(village.Workers);
            Assert.False(village.Workers[0].Alive);
            Assert.Equal(1, village.Workers[0].DaysHungry);
        }
    }
}
