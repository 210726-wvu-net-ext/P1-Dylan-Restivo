using System;
using Xunit;
using UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Models;

namespace UI_UnitTests
{
    public class RatingTest_LT
    {   
        [Fact]
        public void Rating_GT0_LT5_ReturnFalse()
        {
        //Given
            int rating = 0;
            bool result = true;
        //When
            if (rating < 1)
        {
             result = false;
        }
        //Then
            Assert.False(result, "Rating shuld be between 1 and 5");
        }

    }
        public class RatingTest_GT
    {   
        [Fact]
        public void Rating_GT0_LT5_ResultFalse()
        {
        //Given
            int rating = 6;
            bool result = true;
        //When
            if (rating > 1)
        {
             result = false;
        }
        //Then
            Assert.False(result, "Rating shuld be between 1 and 5");
        }

    }
        public class AdminPass
        {
            [Fact]
            public void AdminPass_ET(){
        //Given
                bool result = false;
                string adminPass = "Admin";
                string truePass = "Admin";


        //When
                if(truePass == adminPass){
                    result = true;
                }
        //Then
                Assert.True(result);
        }
    }


            public class AverageTest_Small
        {
            [Fact]
            public void AverageSmall(){
        //Given
            bool result = false;
            double[] numbers = {1, 2, 3 ,4 ,5};
            int count = 0;
            int total = 0;
            foreach(int number in numbers)
            {
                total = total + number;
                count++;
            }
            double actual = total/count;
            double expected = 3;
        //When
            if(actual == expected){
                result = true;
            }
        //Then
                Assert.True(result);
        }
    }

            public class AverageTest_Large
        {
            [Fact]
            public void AverageLarge(){
        //Given
            bool result = false;
            double[] numbers = {1000, 2000, 3000 ,4000 ,5000};
            int count = 0;
            int total = 0;
            foreach(int number in numbers)
            {
                total = total + number;
                count++;
            }
            double actual = total/count;
            double expected = 3000;
        //When
            if(actual == expected){
                result = true;
            }
        //Then
                Assert.True(result);
        }
    }

}

