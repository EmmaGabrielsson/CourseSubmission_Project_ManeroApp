using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Manero.Tests;

public class FooterTest
{
    private const string CssFilePath = "C:\\Users\\tommy\\source\\repos\\CourseSubmission_Project_ManeroApp\\Manero\\wwwroot\\css\\site.css";

    [Fact]
    public void Test_Text_Should_Be_In_Css_File()
    {
        // Arrange
        string expectedText = "@media (max-width: 1400px) {\r\n    .footer-big {\r\n        display: none;\r\n    }\r\n}";

        // Act
        string cssContent = File.ReadAllText(CssFilePath);

        // Assert
        Assert.Contains(expectedText, cssContent);
    }
}
