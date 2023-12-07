using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Lesson
{
    internal class DESIF
    {
        public static async Task Run()
        {
                    using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();

        await page.GotoAsync("https://desif.hml.sf.prefeitura.sp.gov.br/desif-intranet/");

        var h1Selector = "h1";
        var headerElement = await page.WaitForSelectorAsync(h1Selector);

        if (headerElement != null)
        {
            // Get the bounding box of the <h1> element
            var boundingBox = await headerElement.BoundingBoxAsync();

            if (boundingBox != null)
            {
                Console.WriteLine($"Bounding Box of <h1>: X={boundingBox.X}, Y={boundingBox.Y}, Width={boundingBox.Width}, Height={boundingBox.Height}");
            }
            else
            {
                Console.WriteLine("Bounding box is null.");
            }
        }
        else
        {
            Console.WriteLine($"No <h1> element found with selector '{h1Selector}' on the page.");
        }

        await browser.CloseAsync();
    }

        }
    }

