using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Manero.Tests;



public class CarouselTest
{
    public async Task MainPage_Should_Load_JsFile()
    {
        string baseUrl = "https://localhost:7073/";
        string jsFileUrl = $"{baseUrl}~/js/carousel.js";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(baseUrl);
            string content = await response.Content.ReadAsStringAsync();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(content.Contains(jsFileUrl), "JS file is not loaded on the main page.");
        }
    }
}
