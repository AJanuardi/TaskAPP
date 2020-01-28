using System;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace app2
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

            rootApp.Command("polindrome", app => 
            {
                app.Description = "Check polindrome";
                var text = app.Argument("text","Masukkan text");
                app.OnExecute(() =>
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < text.Value.Length; i++)
                    {
                    if ((text.Value[i] >= 'A' && text.Value[i] <= 'z'))
                    {
                        sb.Append(text.Value[i]);
                    }
                    }

                    string da = sb.ToString();
                    string dat = da.ToLower();
                    string dat1 = dat.Substring(0, dat.Length);
                    char[] arr = dat1.ToCharArray();
                    Console.WriteLine(arr);

                    Array.Reverse(arr);

                    string dat3 = new string (arr);
                    string dat4 = dat3.Substring(0, dat3.Length);
                    Console.WriteLine(dat4);

                    if (dat1 == dat4)
                    {
                        Console.WriteLine("Polindrome");
                    }
                    else
                    {
                        Console.WriteLine("Bukan Polindrome");
                    }
                });
            });
            return rootApp.Execute(args);
        }
    }
}
