using System;
using System.Collections.Generic;
using System.Text;
class Cat : Mammal
{
    public Cat(string name) : base(name) { }

    public virtual void greets()
    {
        Console.WriteLine("Meow");
    }

    public override string ToString()
    {
        return "Cat[Mamaml[Animal[name=" + name + "]]]";
    }
}
