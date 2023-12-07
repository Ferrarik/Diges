using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lesson;

class Program
{
    public static async Task Main()
    {
        await DESIF.Run();
        await LogDesif.Run();
        await DESIFother.Run();





    }
}
