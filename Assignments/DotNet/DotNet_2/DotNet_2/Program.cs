using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person[] Personclass = new Person[5];
            Personclass[0] = new Student("Raguvaran", 90);
            Personclass[1] = new Student("Prakash", 50);
            Personclass[2] = new Student("Shankar", 86);
            Personclass[3] = new Professor("Santhosh", 5);
            Personclass[4] = new Professor("Sakthi", 2);
            foreach(var p in Personclass)
            {
                if(p.IsOutStanding())
                {
                    if(p is Student)
                    {
                        ((Student)p).display();
                    }
                    else if (p is Professor)
                    {
                        ((Professor)p).print();
                    }
                }
            }
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        #region Constructor
        public Person()
        {

        }

        public Person(string Name)
        {
            this.Name = Name;
        }
        #endregion Constructor

        #region Methods
        public virtual bool IsOutStanding()
        {
            return true;
        }

        #endregion



    }

    public class Professor : Person
    {
        public int booksPublished { get; set; }

        #region Constructor
        public Professor()
        {

        }

        public Professor(string name, int bookspublished)
        {
            this.booksPublished = bookspublished;
            this.Name = name;
        }

        #endregion Constructor

        #region Methods

        public void print()
        {
            Console.WriteLine("Professor " + this.Name + " has published " + this.booksPublished + " number of books");
        }

        public override bool IsOutStanding()
        {
            return booksPublished > 4;
        }


        #endregion
    }

    public class Student : Person
    {
        public double percentage { get; set; }

        #region Constructor
        public Student()
        {

        }

        public Student(string name, double Percentage)
        {
            this.percentage = Percentage;
            this.Name = name;
        }

        #endregion Constructor

        #region Methods

        public void display()
        {
            Console.WriteLine("Student " + this.Name + " has scroed " + this.percentage + " percentage");
        }

        public override bool IsOutStanding()
        {
            return percentage > 85;
        }


        #endregion
    }
}
