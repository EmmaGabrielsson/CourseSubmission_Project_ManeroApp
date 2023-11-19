namespace Manero.Tests
{
    public class FooterTest
    {
        private readonly string _cssFilePath;

        public FooterTest()
        {
            _cssFilePath = Path.Combine(GetProjectPath(), "wwwroot", "css", "site.css");
        }

        [Fact]
        public void Footer_Should_Be_Shown_Only_On_Big_Screen()
        {
            // Arrange
            string expectedText = "@media (max-width: 1400px) {\r\n    .footer-big {\r\n        display: none;\r\n    }\r\n}";
            string expectedText2 = "@media (max-width: 1400px) {\r\n               .footer-big {\r\n                   display: none;\r\n               }\r\n           }";

            // Act
            string cssContent = File.ReadAllText(_cssFilePath);

            // Assert
            if (!(cssContent.Contains(expectedText) || cssContent.Contains(expectedText2)))
            {
                Assert.True(false, "The CSS content did not match any expected patterns.");
            }
        }
        private string GetProjectPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Manero");
        }
    }
}
