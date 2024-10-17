using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis_4
{
    public class Persons
    {
        public int X {  get; set; }
        public int Y { get; set; }
        private static Random random = new Random();

        public Persons(int x,int y)
        {
            X = x;
            Y = y;
        }
        public void Move(int width,int heigth)// method
        {
            X += random.Next(-1, 2);
            Y += random.Next(-1, 2);

            // om en person ga ut kommer hen tillbaka I andra ändan
            if (X < 0) X = width -1;// vanster - hoger
            if (X >= width) X = 0; // hoger - vanster
                           
            if (Y < 0) Y = heigth - 1; // upp- ner
            if (Y >= heigth) Y = 0; // ner-upp 


        }
        public class Citizen : Persons  // Citizen med arv fran Persons
        {
            public List<string> Inventory { get; set; }

            public Citizen(int x, int y) : base(x, y) // constructor
            {
                Inventory = new List<string>() { "Nycklar ", "Mobiltelefon ", "Pengar ", "Klocka" };
            }

        }
        public class Thief : Persons
        {
            public List <string> ThiefInventory { get; set; }
            public Thief(int x , int y) : base(x, y)
            {
                ThiefInventory = new List<string>() { };
            }
            public void Steal(Citizen citizen) // tjuv method
            {
                if (citizen.Inventory.Count > 0) 
                {
                    Random random = new Random(); // tjuven tar en random item
                    int index = random.Next(citizen.Inventory.Count);
                    string stolenItem = citizen.Inventory[index];


                }
            }
        }
        public class Police : Persons
        {
            public List<string> PoliceInventory { get; set; }

            public Police(int x, int y) : base(x, y)
            {
                PoliceInventory = new List<string>();
            }
        }

    }
}
