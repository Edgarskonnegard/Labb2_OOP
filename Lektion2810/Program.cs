namespace Lektion2810
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal bear = new Bear("roar", 4, false, false, 3, "grizzly bear");
            //bear.MakeSound();
            bear.ShowInfo();
        }
    }
}

public class Animal
{
    public string Sound { get; set; } = "Default";
    public int NumberOfLegs { get; set; } = 4;
    public bool HasTail { get; set; } = false;
    public bool IsPet { get; set; } = false;
    public int Age { get; set; } = -1;
    public Animal(string sound, int numberOfLegs, bool hasTail, bool isPet, int age)
    {
        Sound = sound;
        NumberOfLegs = numberOfLegs;
        HasTail = hasTail;
        IsPet = isPet;
        Age = age;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine(
            $" Sound : {Sound}\n" +
            $" Number of legs : {NumberOfLegs}\n" +
            $" Has tail : {HasTail}\n" +
            $" Is a pet : {IsPet}\n" +
            $" Animals age : {Age}\n");
    }
    public virtual void Feat()
    {
        Console.WriteLine();
    }
    public virtual void MakeSound()
    {
        foreach(var s in Sound)
        {
            Console.Write(s);
            Thread.Sleep(500);
        }
    }

}

public class Bear : Animal
{
    /*
    public string Sound { get; set; } = "Default";
    public int NumberOfLegs { get; set; } = 4;
    public bool HasTail { get; set; } = false;
    public bool IsPet { get; set; } = false;
    public int Age { get; set; } = -1;
    */
    public string TypeOfBear { get; set; } = "Bumbibjörn";
    public Bear(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, string typeOfBear) : base(sound, numberOfLegs, hasTail, isPet, age)
    {
        TypeOfBear = typeOfBear;
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"This bear is an {TypeOfBear}");
        base.ShowInfo();
    }
}

public class Dog : Animal
{
    private bool _isGoodBoy { get; set; } = true;
    public Dog(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isGoodBoy) : base(sound, numberOfLegs, hasTail, isPet, age)
    {
        _isGoodBoy = isGoodBoy;
    }
    public override void ShowInfo()
    {
        Console.WriteLine("This animal is a dog");
        base.ShowInfo();
    }
    public void IsGoodBoy()
    {
        Console.WriteLine(_isGoodBoy ? $"This dog is a good boy" : $"This dog is not a good boy");
    }
}

public class Pitbull : Dog
{
    private string _myFriends { }
    public Pitbull(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isGoodBoy) : base(sound, numberOfLegs, hasTail, isPet, age, isGoodBoy)
    {
        _isGoodBoy = isGoodBoy;
    }
}

public class Cat : Animal
{
    private bool _isPregnant { get; set; } = true;
    public Cat(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isPregnant) : base(sound, numberOfLegs, hasTail, isPet, age)
    {
        _isPregnant = isPregnant;
    }
    public override void ShowInfo()
    {
        Console.WriteLine("This animal is a cat");
        base.ShowInfo();
    }
    public void IsPregnant()
    {
        Console.WriteLine(_isPregnant ? $"This cat is pregnant again" : $"This cat is not pregnant, phew.");
    }
}