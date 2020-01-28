using System;
using McMaster.Extensions.CommandLineUtils;

namespace _2
{
    class Program
    {
        public static string random (int length = 32, bool numbers = true, bool letters = true)
        {
            var p = "";
            if (letters == false)
            {
                p = "0123456789";
            }
            if (numbers == false)
            {
                p = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            }

            var chars = p;
            var stringchar = new char[length];
            var random = new Random();
            for (int i =0; i< stringchar.Length; i++)
            {
                stringchar[i] =chars[random.Next(chars.Length)];
            }
            var data = new string(stringchar);
            return data;
        }
        static int Main(string[] args)
        {
            
            var rootApp = new CommandLineApplication()
            {
                Name = "Aplikasi Pertama",
                Description = "Ini digunakan untuk mencetak text",
                ShortVersionGetter = () => "1.0.0"
            };

             rootApp.Command("random", app => 
            {
                app.Description = "random generator";
                var lengths = app.Option("--lengths", "generator random", CommandOptionType.SingleOrNoValue);
                var letters = app.Option("--letters", "generator random", CommandOptionType.SingleOrNoValue);
                var numbers = app.Option("--numbers", "generator random", CommandOptionType.SingleOrNoValue);
                var uppercase = app.Option("--uppercase", "generator random", CommandOptionType.SingleOrNoValue);
                var lower = app.Option("--lowercase", "generator random", CommandOptionType.SingleOrNoValue);

                app.OnExecute(() =>
                {
                    if (lengths.HasValue())
                    {
                        Console.WriteLine(random(Convert.ToInt32(lengths.Value()), true, true));
                    }
                    if (letters.HasValue())
                    {
                        Console.WriteLine(random(32, false, Convert.ToBoolean(letters.Value())));
                    }
                    if (numbers.HasValue())
                    {
                        Console.WriteLine(random(32, Convert.ToBoolean(numbers.Value()), true));
                    }
                    if (uppercase.HasValue())
                    {
                        Console.WriteLine(random(32, false, true).ToUpper());
                    }
                    if (lower.HasValue())
                    {
                        Console.WriteLine(random(Convert.ToInt32(lengths.Value()), Convert.ToBoolean(numbers.Value()), true).ToLower());
                    }
                });
            });
            return rootApp.Execute(args);
        }

    }
}
