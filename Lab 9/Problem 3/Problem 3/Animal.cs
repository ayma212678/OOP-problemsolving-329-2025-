using System;
using System.Collections.Generic;
using System.Text;
class Animal
{
    protected string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public virtual string ToString()
    {
        return "Animal[name=" + name + "]";
    }
}
