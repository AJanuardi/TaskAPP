using System;
using System.Collections.Generic;
using McMaster.Extensions.CommandLineUtils;

namespace app1
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

            rootApp.Command("add", app => 
            {
                app.Description = "Menjumlahkan Angka";
                var text = app.Argument("Masukkan angka","Masukkan text", true);
                app.OnExecute(() =>
                {   
                    var add = 0;
                    foreach (var x in text.Values)
                    {
                        add += Convert.ToInt32(x);
                    }
                    Console.WriteLine(add);
                });
            });

            rootApp.Command("multiply", app => 
            {
                app.Description = "Mengkalikan Angka";
                var text = app.Argument("Masukkan angka","Masukkan text", true);
                app.OnExecute(() =>
                {   
                    var mul = 1;
                    var angka = new List<int>();
                    foreach (var x in text.Values)
                    {
                        var k = Convert.ToInt32(x);
                        angka.Add(k);
                    }
                    foreach (var x in angka)
                    {
                            mul = mul*x;
                    }
                    Console.WriteLine(mul);
                });
            });

            rootApp.Command("divide", app => 
            {
                app.Description = "Membagi Angka";
                var text = app.Argument("Masukkan angka","Masukkan text", true);
                app.OnExecute(() =>
                {   
                    var angka = new List<int>();
                    foreach (var x in text.Values)
                    {
                        var k = Convert.ToInt32(x);
                        angka.Add(k);
                    }

                    var sub = angka[0];
                    for (int i = 0; (i+1)<angka.Count; i++)
                    {
                        sub = sub / angka[i+1];
                    }
                    Console.WriteLine(sub);
                });
            });

            rootApp.Command("substract", app => 
            {
                app.Description = "Mengurangkan Angka";
                var text = app.Argument("Masukkan angka","Masukkan text", true);
                app.OnExecute(() =>
                {   
                    var angka = new List<int>();
                    foreach (var x in text.Values)
                    {
                        var k = Convert.ToInt32(x);
                        angka.Add(k);
                    }

                    var sub = angka[0];
                    for (int i = 0; (i+1)<angka.Count; i++)
                    {
                        sub = sub - angka[i+1];
                    }
                    Console.WriteLine(sub);
                });
            });

            return rootApp.Execute(args);

        }
    }
}
