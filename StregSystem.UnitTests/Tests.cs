using System;
using Microsoft.Win32;
using NUnit.Framework;
using StregSystem2.Model;

namespace StregSystem.UnitTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        //Method_Scenario_expectedBehavior
        public void User_FirstNameIsNull_ThrowNullArgumentException()
        {
            //Arrange
            //Act
            //Assert
            try
            {
                new User(1, "", "Qauomi", "25_massir", "hh@23.dk", 500);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is System.ArgumentNullException);
                Console.WriteLine(e);
            }
        }

        [Test]
            //Method_Scenario_expectedBehavior
            public void User_LastNameIsNull_ThrowNullArgumentException()
            {
                //Arrange
                //Act
                //Assert
                try
                { 
                    new User(1, "Massir", "", "25_massir", "hh@23.dk", 500);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    Assert.IsTrue(e is System.ArgumentNullException);
                    Console.WriteLine(e);
                }
            
            

        }
            [Test]
            //Method_Scenario_expectedBehavior
            public void User_UserNameIncludeOtherCharactersThana_z0_9__ThrowNullArgumentException()
            {
                //Arrange
                //Act
                //Assert
                try
                { 
                    new User(1, "Massir", "Qauomi", "25_maS", "hh@23.dk", 500);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    Assert.IsTrue(e is System.ArgumentException);
                    Console.WriteLine(e);
                }
            
            

            }
            
            [Test]
            //Method_Scenario_expectedBehavior
            public void User_InvalidEmail_ThrowArgumentException()
            {
                //Arrange
                //Act
                //Assert
                try
                { 
                    new User(1, "Massir", "Qauomi", "25_ma", "eksempel(2)@-mit_domain.dk", 500);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    Assert.IsTrue(e is System.ArgumentException);
                    Console.WriteLine(e);
                }
            
            

            }
    }
}