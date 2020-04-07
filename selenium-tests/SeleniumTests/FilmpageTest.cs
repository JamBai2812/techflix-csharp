using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class FilmpageTest
    {
        [Test]
        public void TestFilmPageLoads()
        {
            using var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:3000/films");

            var heroTitle = driver.FindElementByTestId("hero-title");

            heroTitle.Text.Should().Be("Films");
        }
    }
}