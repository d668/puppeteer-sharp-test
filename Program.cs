using System;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();
        }

        private static async Task Test()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://zappatos.ro/adidasi-dama/");
            await page.ScreenshotAsync("png.png"); //OK
            await page.ScreenshotAsync("jpeg.jpg", new ScreenshotOptions() 
            {
                FullPage = true,
                Type = ScreenshotType.Jpeg,
            }); //huge black screenshot
            await browser.CloseAsync();
        }
    }
}
