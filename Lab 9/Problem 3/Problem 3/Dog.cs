using System;
using System.Collections.Generic;
using System.Text;
class Dog : Mammal
{
    public Dog(string name) : base(name) { }

    public virtual void greets()
    {
        Console.WriteLine("Woof");
    }

    public void greets(Dog another)
    {
        Console.WriteLine("Woooof");
    }

    public override string ToString()
    {
        return "Dog[Mamaml[Animal[name=" + name + "]]]";
    }
}
