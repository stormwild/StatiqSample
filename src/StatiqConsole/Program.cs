// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bootstrapping Statiq.Web!");

await Bootstrapper.Factory
                  .CreateWeb(args)
                  .RunAsync();
