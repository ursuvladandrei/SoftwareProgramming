// See https://aka.ms/new-console-template for more information

using System;

namespace DesignPatterns
{
    #region FactoryMethod
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            IProduct product = FactoryMethod();
            string result = "Creator: The same creator's code has just worked with " + product.Operation();
            return result;
        }
    }

    public class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    public class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    public interface IProduct
    {
        public abstract string Operation();
    }

    public class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    public class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }
    #endregion FactoryMethod

    #region AbstractFactory
    public interface IAbstractFactory
    {
        public IAbstractProductA CreateProductA();

        public IAbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }


    public interface IAbstractProductA
    {
        public string UsefulFunctionA();
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1.";
        }
    }

    public class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A2.";
        }
    }

    public interface IAbstractProductB
    {
        public string UsefulFunctionB();

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B1.";
        }

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            string result = collaborator.UsefulFunctionA();

            return $"The result of the B1 collaborating with the ({result})";
        }
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B2.";
        }

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            string result = collaborator.UsefulFunctionA();

            return $"The result of the B1 collaborating with the ({result})";
        }
    }
    #endregion AbstractFactory

    #region Builder
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();     
        }

        public void BuildPartA()
        {
            this._product.Add("Part1");
        }

        public void BuildPartB()
        {
            this._product.Add("Part2");
        }

        public void BuildPartC()
        {
            this._product.Add("Part3");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder = null!;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.BuildPartA();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.BuildPartA();
            this._builder.BuildPartB();
            this._builder.BuildPartC();
        }
    }
    #endregion Builder

    #region Prototype
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
    #endregion Prototype

    #region Singleton
    public class Singleton
    {
        private Singleton() {}

        private static Singleton _instance;
        private static readonly object _lock = new object();
        public string Value { get; set; }

        public static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }
    }

    #endregion Singleton
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("This is the FactoryMethod");

            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            FactoryMethodClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            FactoryMethodClientCode(new ConcreteCreator2());
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("This is the Abstract Factory");
            Console.WriteLine("Client: Testing client code with the first factory type");
            AbstractFactoryClientCode(new ConcreteFactory1());

            Console.WriteLine("");

            Console.WriteLine("Client: Testing the same client code with the second factory type");
            AbstractFactoryClientCode(new ConcreteFactory2());
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("This is the Builder");
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("This is Prototype");
            PrototypeClientCode();
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("---------------------------------------");
            SingletonClientCode();
            Console.WriteLine("---------------------------------------");
        }

        public static void FactoryMethodClientCode(Creator creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class. " + creator.SomeOperation());
        }

        public static void AbstractFactoryClientCode(IAbstractFactory factory)
        {
            IAbstractProductA productA = factory.CreateProductA();
            IAbstractProductB productB = factory.CreateProductB();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }

        public static void PrototypeClientCode()
        {
            Person p1 = new Person() { Age = 42, BirthDate = Convert.ToDateTime("1977-01-01"), Name = "Jack Daniels", IdInfo = new IdInfo(666) };
            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }

        public static void SingletonClientCode()
        {
            Thread process1 = new Thread(() => 
            {
                Thread.Sleep(1);
                TestSingleton("FOO");
            });

            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            Singleton singleton = Singleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }

    }
}
