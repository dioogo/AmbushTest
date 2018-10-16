using System;
using System.IO.Abstractions;

namespace AmbushTest
{
    class Program
    {
        static void Main(string[] args)
        {
            NasaParser parser = new NasaParser(new FileSystem());

            NasaController controller = new NasaController(parser);

            var rovers = controller.Execute();

            foreach(var rover in rovers)
            {
                Console.WriteLine(rover);
            }
            Console.ReadKey();
        }
    }
}
