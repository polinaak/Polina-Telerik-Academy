using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
//Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
//Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only
//female and tomcats can be only male. Each animal produces a specific sound. Create arrays of
//different kinds of animals and calculate the average age of each kind of animal using a static
//method (you may use LINQ).

namespace _03Animals
{
    class Test
    {
        static void Main()
        {
            Cat cat = new Cat(2, "Kitty", Cat.Sex.female);
            cat.Sound();

            Kitten kitty = new Kitten(1, "Zori");
            kitty.Sound();

            Tomcat tc = new Tomcat(4, "Tom");
            tc.Sound();

            Frog[] frogs = new Frog[3];
            Frog f1 = new Frog(2, "Froxi", Frog.Sex.female);
            f1.Sound();
            Frog f2 = new Frog(4, "Froxcho", Frog.Sex.male);
            Frog f3 = new Frog(6, "Fifi", Frog.Sex.female);
            frogs[0] = f1;
            frogs[1] = f2;
            frogs[2] = f3;
            //Test AverageAge method
            Console.WriteLine(Animal.AverageAge(frogs));

            Dog[] dogs = new Dog[5];
            Dog d1 = new Dog(12, "Sharo", Animal.Sex.male);
            d1.Sound();
            Dog d2 = new Dog(2, "Rex", Animal.Sex.male);
            Dog d3 = new Dog(10, "Balkan", Animal.Sex.male);
            Dog d4 = new Dog(15, "Lasi", Animal.Sex.female);
            Dog d5 = new Dog(25, "Kari", Animal.Sex.female);
            dogs[0] = d1;
            dogs[1] = d2;
            dogs[2] = d3;
            dogs[3] = d4;
            dogs[4] = d5;

            //Test Average method
            Console.WriteLine(Animal.AverageAge(dogs));

            
        }
    }
}
