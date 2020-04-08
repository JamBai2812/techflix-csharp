using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.UserJourneyTests
{
    public class HomeToCastMemberTest
    {
        [Test]
                public void HomeToCastMember()
                {
                    using var driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("http://localhost:3000/");
                    
                    driver.FindElementByTestId("moreFilms").Click();
                    
                    var heroTitle = driver.FindElementByTestId("hero-title");
                    
                    heroTitle.Text.Should().Be("Films");
                    
                    // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    //
                    //
                    // wait.Until()
     
                    
                }
    }
}