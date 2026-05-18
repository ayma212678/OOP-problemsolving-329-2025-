using System;
using System.Collections.Generic;
using System.Text;
class Mammal : Animal
{
    public Mammal(string name) : base(name) { }
    public override string ToString()
    {
        return "Mamaml[Animal[name=" + name + "]]";
    }
}