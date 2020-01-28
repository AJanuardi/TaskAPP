using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using McMaster.Extensions.CommandLineUtils;
using System.IO;
using System.Text;

namespace app7
{
    class Program
    {
        public static async Task SS(string url, string format)
        {
            //UTAMA
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });
            
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            var optionScreen = new ScreenshotOptions()
            {
                FullPage = true
            };

            if (format == "pdf")
            {
            string path = "D:/Users/bsi50130/Desktop/app7";
            string[] getFile = Directory.GetFiles(path);
            foreach(string x in getFile)
                {
                    
                        int counter = 1;
                        string data = Path.GetFileNameWithoutExtension(x);
                        string data1 = data.Replace("screenshot--", "");
                        string url1 = url.Replace("/","_").Replace(":","_");
                        if (data1 == Convert.ToString(counter))
                        {
                            counter++;
                            await page.ScreenshotAsync($"{url1}"+counter+".pdf");
                        }
                        else
                        {
                            await page.ScreenshotAsync($"{url1}"+counter+".pdf");
                        }
                }
            }
            else if (format == "jpg")
            {
            string path = "D:/Users/bsi50130/Desktop/app7";
            string[] getFile = Directory.GetFiles(path);
            foreach(string x in getFile)
                {
                    
                        int counter = 1;
                        string data = Path.GetFileNameWithoutExtension(x);
                        string data1 = data.Replace("screenshot--", "");
                        string url1 = url.Replace("/","_").Replace(":","_");
                        if (data1 == Convert.ToString(counter))
                        {
                            counter++;
                            await page.ScreenshotAsync($"{url1}"+counter+".jpg");
                        }
                        else
                        {
                            await page.ScreenshotAsync($"{url1}"+counter+".jpg");
                        }
                }
            }
            else
            {
            string path = "D:/Users/bsi50130/Desktop/app7";
            string[] getFile = Directory.GetFiles(path);
            foreach(string x in getFile)
                {
                    
                        int counter = 1;
                        string data = Path.GetFileNameWithoutExtension(x);
                        string data1 = data.Replace($"{url}", "");
                        string url1 = url.Replace("/","_").Replace(":","_");
                        if (data1 == Convert.ToString(counter))
                        {
                            counter++;
                            await page.ScreenshotAsync($"{url1}"+counter+".png");
                        }
                        else
                        {
                            await page.ScreenshotAsync($"{url1}"+counter+".png");
                        }
                }
            }
        }

        public static async Task<int> Main (string[] args)
        {
          
            var rootApp = new CommandLineApplication()
            {
                Name = "Aplikasi Pertama",
                Description = "Ini digunakan untuk mencetak text",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("screenshot",app => 
            {
                app.Description = "screenshot app";
                var url = app.Argument("text","masukkan text");
                var format = app.Option("--format", "generator screenshot", CommandOptionType.SingleOrNoValue);
                var nama = app.Option("--output", "generator screenshot", CommandOptionType.SingleOrNoValue);

                app.OnExecuteAsync(async cancellationToken =>
                {
                        foreach (string line in File.ReadLines(@"D:\Users\bsi50130\Desktop\app8\List.txt", Encoding.UTF8))
                        {
                            Console.WriteLine(line);
                            Task t = SS(line,format.Value());
                            t.Wait();
                        }
                        
                //    if (nama.HasValue())
                //    {
                //        Task t = Name(url.Value, nama.Value(), format.Value());
                //        t.Wait();
                //    }
                });
            });
           return rootApp.Execute(args);
        }
    }
}
