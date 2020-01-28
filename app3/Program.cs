using System;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace app3
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

            rootApp.Command("obfuscator", app => 
            {
                app.Description = "Obfuscating teks";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {
                    Encoding ascii = Encoding.ASCII;
                    Byte[] encodedBytes = ascii.GetBytes(text.Value);
                    foreach (Byte b in encodedBytes) 
                    {
                        Console.Write("&#{0};", b);
                    }
                });
            });

            return rootApp.Execute(args);
        }
    }
}
