// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;


#region Adapter
public interface ITarget
{
    public string GetRequest();
}

public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        this._adaptee = adaptee;
    }

    public string GetRequest()
    {
        return $"This is '{this._adaptee.GetSpecificRequest()}'";
    }
}

#endregion Adapter

#region Decorator
public abstract class Component
{
    public abstract string Operation();
}

public class ConcreteComponent : Component
{
    public override string Operation()
    {
        return "ConcreteComponent";   
    }
}

public abstract class Decorator : Component
{
    protected Component _component;

    public Decorator(Component component)
    {
        this._component = component;
    }

    public void SetComponent(Component component)
    {
        this._component = component;
    }

    public override string Operation()
    {
        if (this._component != null)
        {
            return this._component.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}

public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(Component comp) : base(comp)
    {
    }

    public override string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(Component comp) : base(comp)
    {
    }

    public override string Operation()
    {
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}

#endregion Decorator

#region Facade
public class Facade
{
    protected Subsystem1 _subsystem1;
    protected Subsystem2 _subsystem2;

    public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
    {
        this._subsystem1 = subsystem1;
        this._subsystem2 = subsystem2;
    }

    public string Operation()
    {
        string result = "Facade initializes subsystems:\n";
        result += this._subsystem1.operation1();
        result += this._subsystem2.operation1();
        result += "Facade orders subsystems to perform the action:\n";
        result += this._subsystem1.operationN();
        result += this._subsystem2.operationZ();
        return result;
    }
}

public class Subsystem1
{
    public string operation1()
    {
        return "Subsystem1: Ready!\n";
    }

    public string operationN()
    {
        return "Subsystem1: Go!\n";
    }
}

public class Subsystem2
{
    public string operation1()
    {
        return "Subsystem2: Get ready!\n";
    }

    public string operationZ()
    {
        return "Subsystem2: Fire!\n";
    }
}

#endregion Facade

#region Proxy
public interface ISubject
{
    public void Request();
}

public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}

public class Proxy : ISubject
{
    private RealSubject _realSubject;

    public Proxy(RealSubject realSubject)
    {
        this._realSubject = realSubject;
    }

    public void Request()
    {
        
    }
}

#endregion Proxy

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This is Adapter");
            AdapterClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Decorator");
            DecoratorClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Facade");
            FacadeClientCode();
            Console.WriteLine();
        }

        public static void AdapterClientCode()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But the adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }

        public static void DecoratorClientCode()
        {
            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            Console.WriteLine("RESULT: " + simple.Operation());
            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            Console.WriteLine("RESULT: " + decorator2.Operation());
        }

        public static void FacadeClientCode()
        {
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Console.WriteLine(facade.Operation());
        }
    }
}
