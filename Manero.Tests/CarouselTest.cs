using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Manero.Tests;



public class CarouselTest
{
    private const string ViewPath = "C:\\Users\\tommy\\source\\repos\\CourseSubmission_Project_ManeroApp\\Manero\\Views\\Partials\\_CarouselPartial.cshtml"; // Replace with the actual path to your view

    [Fact]
    public void Test_Correct_Js_File_Is_Loaded()
    {
        string expectedJsFileName = "carousel.js";

        string viewContent = File.ReadAllText(ViewPath);

        Assert.True(ContainsJsFile(viewContent, expectedJsFileName));
    }
    private bool ContainsJsFile(string content, string jsFileName)
    {
        string pattern = $"<script\\s+.*src\\s*=\\s*['\"](.*/{jsFileName})['\"].*></script>";
        return Regex.IsMatch(content, pattern, RegexOptions.IgnoreCase);
    }
}
