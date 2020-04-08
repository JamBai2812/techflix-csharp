using OpenQA.Selenium;

namespace SeleniumTests
{
    public static class TestExtensions
    {
        public static IWebElement FindElementByTestId(this IWebDriver driver, string testId)
        {
            return driver.FindElement(By.XPath($"//*[@data-test-id='{testId}']"));
        }

        // public static IWebElement FindElementByTitle(this IWebDriver driver, string title)
        // {
        //     pageTitle
        //     
        //     if()
        //     
        //     return driver.FindElementByTestId("page-title");
        // }
    }
}