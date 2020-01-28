using System;
using System.Net;
using System.Net.Sockets;
using McMaster.Extensions.CommandLineUtils;

namespace app5
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
            rootApp.Command("ip", app => 
            {
                app.Description = "Mengambil local ip";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Console.WriteLine(ip.ToString());
                        }
                    }
                });
            });
            return rootApp.Execute(args);
        }
    }
}
