using System.IO.Pipes;

namespace TjuvOchPolis_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = 100;
            int height = 25;

            //test temporal

            Persons p1 = new Persons(50,3);
            Persons p2 = new Persons(66,5);
            Persons p3 = new Persons(2,12);
            Console.WriteLine($"{ p1.X},{ p1.Y}");
            Console.WriteLine($"{p3.X},{p3.Y}");
            Console.WriteLine($"{p2.X},{p2.Y}");

            p1.Move(width,height);
            p2.Move(width,height);
            p3.Move(width,height);


            // test temporal
            Console.WriteLine($"Persoana1 se misca :{p1.X } , {p1.Y}");
            Console.WriteLine($"Persoana 2 se misca : {p2.X}, {p2.Y}");
        }
    }
}
