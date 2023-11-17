using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Manero.Tests;



public class CarouselTest
{
    private IWebDriver? _driver;

    [Fact]
    public void TestInitialize()
    {
        _driver = new ChromeDriver();
    }
    [Fact]
    public void Carousel_Script_Should_Load()
    {
        _driver.Navigate().GoToUrl("https://localhost:7073/");

        // Replace "your-app-url" with the actual URL of your application.

        // Perform assertions
        IWebElement jsFile = _driver.FindElement(By.CssSelector("script[src*='carousel.js']"));

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(jsFile, "JS file is not loaded on the main page.");
    }

    [Fact]
    public void TestCleanup()
    {
        _driver.Quit();
    }
}
