using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2__C__Basics_and_OOP_
{
    //Concepts Covered
    //Encapsulation: Private fields + public properties

    //Constructors: Parameterized for initialization

    //Inheritance: Animal → Lion, Parrot, Elephant

    //Polymorphism: virtual and override with MakeSound()




    public class MainClass
    {
        public static void Main(string[] args)
        {
            Animal Cat = new Animal("Loofa", 3, "jungle");

            Lion lion = new Lion("Simba", 6, "grasslands", true);

            Parrot parrot = new Parrot("Coco",1,"forests","green");

            Elephant elephant = new Elephant("Suzi",9,"savannas",4.7);


           


            // changing value of lion name with parent class setter and getter
            lion.Name = "Mufasa";
            Console.WriteLine(lion.Name);



            // Implementing polymorphism. As lion, parrot, elephant are derived classes of Animal, their objects can be stored in animal list/

            List<Animal> animals = new List<Animal> { Cat, lion, parrot, elephant };





            // executing methods

            //the MakeSound method of each object in the list has its own implementation, thus enforcing polymorphism.
            //An animal can be a lion, a parrot ,an elephant

            foreach (var animal in animals)
            {
                animal.MakeSound();
            }

        }
    }
}
