using System;
using Xunit;
using Dob_Gy.Modules;

namespace Dob_Gy_TEST
{
    public class UnitTest1
    {

        Actor A = new Actor();
        Movie M = new Movie();

        [Theory]
        [InlineData(50, 1970)]
        [InlineData(40, 1980)]
        [InlineData(30, 1990)]
        [InlineData(10, 2010)]

        public void GetAge_Test1(int expect, short AgeMovie)
        {
            M.ReleasYear = AgeMovie;
            Assert.Equal(expect, M.GetAgeMovie());    
        }

        [Fact]
        public void GetAge_Test(){
            M.ReleasYear = 2000;
            Assert.Equal(20, M.GetAgeMovie());    
        }
     
        [Fact]
        public void FullName_Test()
        {
            A.GivenName = "Waymel";
            A.SurName = "Alex";
            
            Assert.Equal("Alex Waymel", A.setFullName(A.SurName, A.GivenName));            
        }

       
        
    }
}
