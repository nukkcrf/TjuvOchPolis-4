using System.ComponentModel;
using System.IO.Pipes;
using static TjuvOchPolis_4.Persons;

namespace TjuvOchPolis_4
{
    public class Program
    {
       static Random random = new Random();
        static void Main(string[] args)
            {
            int width = 100;
            int height = 25;

            List<Persons> persons = new List<Persons>(); // list for Medborgare,Tjuvar och Polis

            for (int i = 0; i < 30; i++)// add 30 medborgare

            {
                persons.Add(new Citizen(random.Next(width), random.Next(height)));
            }
            for (int i = 0; i < 20; i++)  // add 20 tjuvar
            {
                persons.Add(new Thief(random.Next(width), random.Next(height)));
            }
            for(int i = 0;i < 10; i++)// add 10 polis
            {
                persons.Add(new Police(random.Next(width), random.Next(width)));
            }

            while (true)
            {
                Console.Clear();

                foreach (Persons person in persons)

                {
                    person.Move(width, height);
                }

                // Kontrollera om det finns interaktioner (tjuvar stjäl från medborgare, poliser som arresterar tjuvar)
                for (int i = 0; i < persons.Count; i++)
                {
                    for (int j = 0; j< persons.Count; j++) 
                    {
                        if (persons[i].X == persons[j].X && persons[j].Y == persons[j].Y)

                        {
                            //Lista Personer, kan vara antingen Medborgare, Tjuv eller Polis.
                            //För att ta reda på exakt vilken typ av objekt det är använder vi " as " för att göra konverteringen.
                            Thief thief = persons[i] as Thief;
                            Citizen citizen = persons[j] as Citizen;
                            Police police = persons[i] as Police;
                            // vi andvander "as" for konvertion. Metoden "is" bara kontrolera om objektet ar en vis typ.

                            // om person 1 ar medborgare och person 2 ar tjuv
                            if (thief != null && citizen != null)
                            {
                                thief.Steal(citizen);
                            }
                            // och tvart om.... p1 tjuv och p2 medborgare
                            if (citizen != null && persons[i] is Thief thief2)
                            {
                                thief2.Steal(citizen);
                            }
                            if (police != null && persons[j] is Thief thief3)
                            {
                                police.Arrest(thief3);
                            }
                            if (persons[j] is Police police2 && persons[i] is Thief thief4)
                            {
                                police2.Arrest(thief4);
                            }
                        }
                    }
                }
            }
            char[,] grid = new char[width, height];// new grid tom  
            // add persons
            // 
            foreach (Persons person in persons)
            {
                if (person is Citizen)
                {
                    grid[person.X, person.Y] = 'M'; // M for Medborgare
                }
                else if (person is Police)
                {
                    grid[person.X, person.Y] = 'P'; // P fro Polis
                }
                else if (person is Thief)
                {
                    grid[person.X, person.Y] = 'T';// T for Tjuv
                }


            }
            for (int y = 0;y< height;y++)
            {
                for (int x = 0;x< width;x++)
                {
                    Console.WriteLine(grid[x,y]);
                }
                Console.WriteLine();
            }
           Thread.Sleep(2000);
        }
    }
 }


