using System;
using McMaster.Extensions.CommandLineUtils;

namespace app9
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

            rootApp.Command("sum", app => 
            {
                app.Description = "infinity sum";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {   
                    int sum = 0;
                    int counter = 1;
                    for (int i = 1; i <= counter; i++ )
                    {
                    Console.WriteLine("Masukkan ke {0}", counter);
                    string masukkan = Console.ReadLine();
                    if (masukkan !="")
                    {
                        sum += Convert.ToInt32(masukkan);
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine("Jumlah: " + sum);
                    }
                    }
                    
                    
                    
                });
            });

            return rootApp.Execute(args);
        }
    }
}
