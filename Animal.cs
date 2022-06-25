using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Animals
{
//    public class Animal
    class Program
    {
        static void Main()
        {
            // Create a list of animals
            Animal[] animals = new Animal[]{
                new Frog("Pasca", 2, Sex.Male),
                new Kitten("Dresla", 6, Sex.Male),
                new Frog("Jaspa", 3, Sex.Female),
                new Dog("Puppy", 13, Sex.Female),
                new Tomcat("Tomot", 8),
                new Cat("Ress", 2, Sex.Female),
                new Dog("Tepe", 31, Sex.Male)
            };

            Console.WriteLine("The avarage age of all Animals is: {0:0.0}", Animal.AvarageAge(animals));
            
            foreach (ISound animial in animals)
            {
                Console.WriteLine("{0}. My Sound is '{1}'", animial, animial.ProduceSound());
            }
        }
    }

//    public class Animal
    public abstract class Animal
    {
        private string name;
        private Sex sex;
        private int age;

        protected Animal(string inttialName, int intialAge, Sex initialSex)
        {
            this.Name = inttialName;
            this.Age = intialAge;
            this.sex = initialSex;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty!");
                }
                this.name = value;
            }
        }
//        public string Name Define the property Name with get and set accessors.
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age must be at least 1 !");
                }
                this.age = value;
            }
        }
//        public int Age Define the property Age with get and set accessors.
        public Sex Sex
        {
            get { return sex; }
            protected set { sex = value; }
        }

        public override string ToString()// 
        {
            return string.Format("Name of Animal|{0}: {1} Gender: {2} Age: {3}", this.name,
                this.GetType().Name, this.sex, this.age);
        }

        public static double AvarageAge(IEnumerable<Animal> animals) //calculate the average age of each kind of animal using a static method with LINQ
        {
            return animals.Average(x => x.Age);//x is the animal
        }
        
    }
    // Sex
    public enum Sex
    {
        Male,
        Female,
    }
}