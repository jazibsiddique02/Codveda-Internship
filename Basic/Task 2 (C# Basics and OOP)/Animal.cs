using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2__C__Basics_and_OOP_
{
    public class Animal
    {
        private string animalName;

        private int animalAge;

        private string animalHabitat;

        public Animal (string animalName, int animalAge, string animalHabitat)
        {
            this.animalName = animalName;
            this.animalAge = animalAge;
            this.animalHabitat = animalHabitat;
        }

        public string Name
        {
            get { return animalName; }

            set { animalName = value; }
        }

        public int Age
        {
            get { return animalAge; }

            set { animalAge = value; }
        }

        public string Habitat
        {
            get { return animalHabitat; }

            set { animalHabitat = value; }
        }


        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }
}
