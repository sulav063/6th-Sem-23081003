using System;
class Animal
{
    // Virtual method
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    // Override method
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    // Override method
    public override void Sound()
    {
        Console.WriteLine("Cat meows");
    }
}

class PolymorphismDemo
{
    static void Main()
    {
        Animal a;

        a = new Dog();
        a.Sound();  // Dog's sound

        a = new Cat();
        a.Sound();  // Cat's sound
    }
}
