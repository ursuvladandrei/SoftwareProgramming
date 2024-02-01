// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace DesignPatterns
{
    #region ChainOfResponsability
    public interface IHandler
    {
        public IHandler? SetNext(IHandler handler);
        public object? Handle(object request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler? _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object? Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    public class MonkeyHandler : AbstractHandler
    {
        public override object? Handle(object request)
        {
            if ((request as string) == "Banana")
            {
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            } 
        }
    }

    public class SquirrelHandler : AbstractHandler
    {
        public override object? Handle(object request)
        {
            if ((request as string) == "Nut")
            {
                return $"Squirrel: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    #endregion

    #region Command
    public interface ICommand
    {
        void Execute();
    }

    public class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this._payload = payload;
        }

        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this._payload})");
        }
    }

    public class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        private string _a;
        private string _b;

        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }

        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    public class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            Console.WriteLine("Invoker: ...doing something really important...");

            Console.WriteLine("Invoker: Does anybody want something done after I finish?");

            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }

    #endregion Command

    #region Iterator
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract int Key();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }

    public class AlphabeticalOrderIterator : Iterator
    {
        private WordsCollection _collection;
        private int _position = -1;
        private bool _reverse = false;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = collection.getItems().Count;
            }
        }
        public override object Current()
        {
            return this._collection.getItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._collection.getItems().Count - 1 : 0;
        }

    }

    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    public class WordsCollection : IteratorAggregate
    {
        List<string> _collection = new List<string>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<string> getItems()
        {
            return _collection;
        }

        public void AddItem(string item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction);
        }


    }

    #endregion Iterator

    #region Mediator
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }

    public class ConcreteMediator : IMediator
    {
        private Component1 _component1;
        private Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            this._component1 = component1;
            this._component1.SetMediator(this);
            this._component2 = component2;
            this._component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers the following ops:");
                this._component2.DoC();
            }
            if (ev == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers the following ops:");
                this._component1.DoB();
                this._component2.DoC();
            }
        }
    }

    public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    public class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");
            this._mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");
            this._mediator.Notify(this, "B");
        }
    }

    public class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");
            this._mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");
            this._mediator.Notify(this, "D");
        }
    }


    #endregion Mediator

    #region Observer
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    public class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State > 1 )
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; } = -0;

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }

    #endregion Observer

    #region Strategy
    public class Context
    {
        private IStrategy _strategy;

        public Context() {}

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy
    {
        public object DoAlgorithm(object data);
    }

    public class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }
    #endregion Strategy

    #region Visitor
    public interface IComponent
    {
        public void Accept(IVisitor visitor);
    }

    public class ConcreteComponentA : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentA(this);
        }

        public string ExclusiveMethodOfConcreteComponentA()
        {
            return "A";
        }
    }

    public class ConcreteComponentB : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentB(this);
        }

        public string SpecialMethodOfConcreteComponentB()
        {
            return "B";
        }
    }

    public interface IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponentA element);
        public void VisitConcreteComponentB(ConcreteComponentB element);
    }

    public class ConcreteVisitor1 : IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponentA element)
        {
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " ConcreteVisitor1");
        }

        public void VisitConcreteComponentB(ConcreteComponentB element)
        {
            Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " ConcreteVisitor1");
        }
    }

    public class ConcreteVisitor2 : IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponentA element)
        {
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " ConcreteVisitor2");
        }

        public void VisitConcreteComponentB(ConcreteComponentB element)
        {
            Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " ConcreteVisitor2");
        }
    }

    public class Client
    {
        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }

    #endregion Visitor


    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("This is the Chain of Responsibility");
            AbstractHandler monkey = new MonkeyHandler();
            AbstractHandler squirrel = new SquirrelHandler();
            monkey.SetNext(squirrel);
            Console.WriteLine("Chain: Monkey > Squirrel\n");
            ChainClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("This is the Command");
            CommandClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Iterator");
            IteratorClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Mediator");
            MediatorClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Observer");
            ObserverClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Strategy");
            StrategyClientCode();
            Console.WriteLine();

            Console.WriteLine("This is Visitor");
            VisitorClientCode();
            Console.WriteLine();
        }

        public static void ChainClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana"})
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"    {result}");
                }
                else
                {
                    Console.WriteLine($"    {food} was not eaten");
                }
            }
        }

        public static void CommandClientCode()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));
        
            invoker.DoSomethingImportant();
        }

        public static void IteratorClientCode()
        {
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }

        public static void MediatorClientCode()
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggers operation A");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }

        public static void ObserverClientCode()
        {
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);
            subject.SomeBusinessLogic();
        }

        public static void StrategyClientCode()
        {
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }

        public static void VisitorClientCode()
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitor1();
            Client.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitor2();
            Client.ClientCode(components, visitor2);
        }
    }
}