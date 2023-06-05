using Gestform.Models;
using Shouldly;
using Xunit;

namespace Gestform.Tests.Unit
{
    public class ProgramTests
    {
        [Fact]
        public void RandomIntegersInList_ListWithCorrectNumberOfIntegers()
        {
            // Arrange
            int n = 4;

            // Act
            IList<int> result = Gestform.Helpers.GetRandomNumbers(n);

            // Assert
            Assert.Equal(result.Count, n);
        }

        [Fact]
        public void GetDisplayValues_WhenGivenValidEntry_ThenShouldReturnResult()
        {
            // Arrange
            var numbers = new List<int>() { 3, 5 };

            // Act
            var result = Program.GetDisplayValues(numbers);

            // Assert
            result.ShouldNotBeNull();
            Assert.Equal(result.Count, numbers.Count());
        }

        [Fact]
        public void GetDisplayValues_WhenGivenNullParameter_ShouldThrowArgumentNullException()
        {
            Should.Throw<ArgumentNullException>(() => Program.GetDisplayValues(null!));
        }

        [Fact]
        public void GetDisplayValues_ListWithPositiveAndNegativeNumbers()
        {
            // Arrange
            var numbers = new List<int>() { -12, 0, 25, -10, -8 };
            var listEqualValue = new List<DisplayValueModel>();
            listEqualValue.Add(new DisplayValueModel(-12, "Geste"));
            listEqualValue.Add(new DisplayValueModel(0, "Gestform"));
            listEqualValue.Add(new DisplayValueModel(25, "Forme"));
            listEqualValue.Add(new DisplayValueModel(-10, "Forme"));
            listEqualValue.Add(new DisplayValueModel(-8, "-8"));

            // Act
            var result = Program.GetDisplayValues(numbers);

            //Assert
            for(int i = 0; i < result.Count; i++)
            {
                Assert.Equal(result[i].Text, listEqualValue[i].Text);
            }
        }

        [Fact]
        public void GetTextByNumber_NumDivisibleBy3And5()
        {
            //Assign
            int num = 15;

            //Act
            string result = Gestform.Program.GetTextByNumber(num);

            //Assert
            Assert.Equal(result, "Gestform");
        }

        [Fact]
        public void GetTextByNumber_NumDivisibleBy3()
        {
            //Assign
            int num = 9;

            //Act
            string result = Gestform.Program.GetTextByNumber(num);

            //Assert
            Assert.Equal(result, "Geste");
        }

        [Fact]
        public void GetTextByNumber_NumDivisibleBy5()
        {
            //Assign
            int num = -5;

            //Act
            string result = Gestform.Program.GetTextByNumber(num);

            //Assert
            Assert.Equal(result, "Forme");
        }

        [Fact]
        public void GetTextByNumber_NumNotDivisibleBy5Or3()
        {
            //Assign
            int num = 4;

            //Act
            string result = Gestform.Program.GetTextByNumber(num);

            //Assert
            Assert.Equal(result, "4");
        }

    }
}