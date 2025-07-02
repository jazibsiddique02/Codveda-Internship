using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2__C__Basics_and_OOP_
{
    public class Lion : Animal
    {
        private bool animalIsAlphaMale;

        public Lion (string animalName, int animalAge, string animalHabitat, bool animalIsAlphaMale): base(animalName,animalAge,animalHabitat)
        {
            this.animalIsAlphaMale = animalIsAlphaMale;
        }

        public bool isAlphaMale
        {
            get { return animalIsAlphaMale; }

            set { animalIsAlphaMale = value; }
        }


        public override void MakeSound()
        {
            Console.WriteLine("Roar! I am a Lion.");
        }
    }
}
