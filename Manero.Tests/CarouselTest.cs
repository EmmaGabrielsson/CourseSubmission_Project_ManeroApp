using System.Text.RegularExpressions;
using Xunit;

namespace Manero.Tests
{
    public class CarouselTest
    {
        private readonly string _viewPath;

        public CarouselTest()
        {
            _viewPath = Path.Combine(GetProjectPath(), "Views", "Partials", "_CarouselPartial.cshtml");
        }

        [Fact]
        public void Test_Correct_Js_File_Is_Loaded()
        {
            string expectedJsFileName = "carousel.js";

            string viewContent = File.ReadAllText(_viewPath);

            Assert.True(ContainsJsFile(viewContent, expectedJsFileName));
        }

        private bool ContainsJsFile(string content, string jsFileName)
        {
            string pattern = $"<script\\s+.*src\\s*=\\s*['\"](.*/{jsFileName})['\"].*></script>";
            return Regex.IsMatch(content, pattern, RegexOptions.IgnoreCase);
        }

        // Helper method to get the project path
        private string GetProjectPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Manero");
        }
    }
}
