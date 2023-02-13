using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xunit;
using ExerciseApp.Validators;
using System.ComponentModel.DataAnnotations;

namespace ExerciseApp.Tests
{
	public class ModelAttibuteTests
    {
        [Theory]
        [InlineData("2022-03-29")]
        public void Test_Validation_Fail(string input)
        {
            //Arrange
            var checkDateOfBirth = new CustomValidation.checkDateOfBirth();

            //Act
            var actualIsValidResult = checkDateOfBirth.IsValid(DateTime.Parse(input));

            //Assert
            Assert.False(actualIsValidResult);


        }

        [Theory]
        [InlineData("1985-03-29")]
        public void Test_Validation_Pass(string input)
        {
            //Arrange
            var checkDateOfBirth = new CustomValidation.checkDateOfBirth();

            //Act
            var actualIsValidResult = checkDateOfBirth.IsValid(DateTime.Parse(input));

            //Assert
            Assert.True(actualIsValidResult);


        }

    }
}

