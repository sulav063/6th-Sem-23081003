using System;

// Single Inheritance
class A
{
    public void ShowA() => Console.WriteLine("Class A");
}

// Multilevel Inheritance (B -> A, C -> B)
class B : A
{
    public void ShowB() => Console.WriteLine("Class B");
}

class C : B
{
    public void ShowC() => Console.WriteLine("Class C");
}

// Hierarchical Inheritance (D and E inherit from A)
class D : A
{
    public void ShowD() => Console.WriteLine("Class D");
}

class E : A
{
    public void ShowE() => Console.WriteLine("Class E");
}

class InheritanceDemo
{
    static void Main()
    {
        // Single/Multilevel
        C c = new C();
        c.ShowA(); c.ShowB(); c.ShowC();

        // Hierarchical
        D d = new D();
        d.ShowA(); d.ShowD();

        E e = new E();
        e.ShowA(); e.ShowE();
    }
}
