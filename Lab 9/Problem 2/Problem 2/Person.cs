using System;
using System.Collections.Generic;
using System.Text;

class Person
{
    protected string name;
    protected string address;
    public Person(string name, string address)
    {
        this.name = name;
        this.address = address;
    }
    public string getName() { return name; }
    public string getAddress() { return address; }
    public void setAddress(string address) { this.address = address; }

    public override string ToString()
    {
        return "Person[name=" + name + ",address=" + address + "]";
    }
}