using System;
using System.IO;
using System.Net;
using McMaster.Extensions.CommandLineUtils;

namespace app6
{
    class Program
    {
        static int Main(string[] args)
        {
            var rootApp = new CommandLineApplication()
            {
                Name = "Aplikasi Pertama",
                Description = "Ini digunakan untuk mencetak text",
                ShortVersionGetter = () => "1.0.0"
            };
            rootApp.Command("ip-external", app => 
            {
                app.Description = "Mengambil external ip";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {
                string url = "http://checkip.dyndns.org";
                WebRequest req = System.Net.WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                Console.WriteLine(a4); 
                });
            });
            return rootApp.Execute(args);
        }
    }
}
