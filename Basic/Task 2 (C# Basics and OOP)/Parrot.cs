using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2__C__Basics_and_OOP_
{
    public class Parrot:Animal
    {
        private string parrotColor;
        public Parrot(string animalName, int animalAge, string animalHabitat,string parrotColor) : base(animalName,animalAge,animalHabitat)
        {
            this.parrotColor = parrotColor;
        }

        public string color
        {
            get { return parrotColor; }

            set { parrotColor = value; }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Squawk! I can talk.");
        }
    }
}
