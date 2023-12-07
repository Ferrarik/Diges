using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson
{
    internal class LogDesif
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

            await page.GotoAsync("https://desif.hml.sf.prefeitura.sp.gov.br/desif-intranet/pages/home.xhtml");

            await page.Locator("#j_username").ClickAsync();

            await page.Locator("#j_username").FillAsync("A946201");

            await page.Locator("#j_password").ClickAsync();

            await page.Locator("#j_password").FillAsync("prodam40");

            await page.GetByRole(AriaRole.Link, new() { Name = " Acessar" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "Parametrizações" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "Parametrizar Erros e Alertas" }).ClickAsync();
        }
    }
}
