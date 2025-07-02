using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2__C__Basics_and_OOP_
{
    class Elephant:Animal
    {
        private double animalTrunkLength;

        public Elephant(string animalName, int animalAge, string animalHabitat, double animalTrunkLength) :base(animalName,animalAge,animalHabitat)
        {
            this.animalTrunkLength = animalTrunkLength;
        }

        public double trunkLength
        {
            get { return animalTrunkLength; }

            set { animalTrunkLength = value; }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Trumpet! I am an elephant.");
        }
    }
}
