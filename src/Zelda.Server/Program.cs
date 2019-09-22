using System;
using Microsoft.Owin.Hosting;

namespace Zelda.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine($"Server running on {url}");
                Console.ReadLine();
            }
        }
    }
}