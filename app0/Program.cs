using System;
using McMaster.Extensions.CommandLineUtils;

namespace app
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

            rootApp.Command("uppercase", app => 
            {
                app.Description = "Membesarkan huruf kecil";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {   
                    Console.WriteLine(text.Value.ToUpper());
                });
            });

            rootApp.Command("capitalize", app => 
            {
                app.Description = "Kapitalisasi huruf";
                var text = app.Argument("text","Masukkan text");
                
                app.OnExecute(() =>
                {
                    var text1 = text.Value.ToLower();
                    if (text1 == null)
                    {
                        Console.WriteLine("Tidak dapat dilakukan Capitalize");
                    }

                    if (text1.Length > 1)
                    {
                        Console.WriteLine(char.ToUpper(text1[0]) + text1.Substring(1));
                    }
                });
            });

            rootApp.Command("lowercase", app => 
            {
                app.Description = "Mengecilkan huruf besar";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {
                    Console.WriteLine(text.Value.ToLower());
                });
            });

            return rootApp.Execute(args);
        }
    }
}
