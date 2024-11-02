namespace Lektion2810
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();


            Animal bear = new Bear("roar", 4, false, false, 3, "grizzly bear");
            Animal cat = new Cat("meow", 4, true, true, 7, true);
            Animal chihuahua = new Chihuahua("Small bark", 4, true, true, 2, false, true);
            Animal pitbull = new Pitbull("Bark", 4, true, true, 2, false, true);
            Animal dog = new Dog("Woff", 4, true, true, 8, true);

            animals.Add(bear);
            animals.Add(cat);
            animals.Add(chihuahua);
            animals.Add(pitbull);
            animals.Add(dog);

            foreach (var animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}

public class Animal
{
    public string Sound { get; set; }
    public int NumberOfLegs { get; set; }
    public bool HasTail { get; set; }
    public bool IsPet { get; set; }
    public int Age { get; set; }

    //Abstract property must be overridden in subclasses. When in use it refers
    //to the class objects own property.
    public virtual int[] Limit { get; }

    public Animal(string sound, int numberOfLegs, bool hasTail, bool isPet, int age)
    {
        Sound = sound;
        NumberOfLegs = numberOfLegs;
        HasTail = hasTail;
        IsPet = isPet;
        Age = age;
    }

    public void MakeSound()
    {
        Console.Clear();
        Console.WriteLine($"Sound : {Sound}");
        Console.ReadKey();
    }

    public virtual int TameBeast()
    {
        string[] options = { "1. Pet animal", "2. Run for your life!", "3. Stare it down" };
        int currentSelection = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine("The Beast stares at you\n");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(i == currentSelection ? $"> {options[i]}" : $"  {options[i]}");
            }

            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow)
            {
                currentSelection = (currentSelection == 0) ? options.Length - 1 : currentSelection - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                currentSelection = (currentSelection == options.Length - 1) ? 0 : currentSelection + 1;
            }
        } while (key != ConsoleKey.Enter);

        return currentSelection;
    }

    public virtual int SavingThrow()
    {
        Console.WriteLine("Roll your 1d9 dice");
        int choice = TameBeast();
        Console.WriteLine($"\nAttempting option {choice + 1}\n");
        Console.WriteLine($"Roll at least {Limit[choice]} to succed\n");
        Console.WriteLine((RollAnimation() >= Limit[choice]) ? "\nAttempt was successful!" : "\nAttempt failed");

        return choice;
    }

    public int RollAnimation()
    {
        Random rng = new Random();
        int duration = 50;
        int k = rng.Next(1, 10);

        for (int i = 1; i < duration; i++)
        {
            k = rng.Next(1, 10);
            Console.Write($"\rRolling : {k}");
            Thread.Sleep(80 - i);
        }
        Console.WriteLine();
        return k;
    }
}

public class Bear : Animal
{
    public override int[] Limit { get; } = { 7, 6, 5 };  
    public string TypeOfBear { get; set; }

    public Bear(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, string typeOfBear)
        : base(sound, numberOfLegs, hasTail, isPet, age)
    {
        TypeOfBear = typeOfBear;
    }

    public void ShowType()
    {
        Console.WriteLine($"This bear is a {TypeOfBear}");
    }
}

public class Dog : Animal
{
    public override int[] Limit { get; } = { 5, 5, 6 }; 
    private bool _isGoodBoy { get; set; } = true;

    public Dog(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isGoodBoy)
        : base(sound, numberOfLegs, hasTail, isPet, age)
    {
        _isGoodBoy = isGoodBoy;
    }

    public void IsGoodBoy()
    {
        Console.WriteLine(_isGoodBoy ? "This dog is a good boy." : "This dog is not a good boy.");
    }
}

public class Chihuahua : Dog
{
    public override int[] Limit { get; } = { 6, 4, 5 }; 
    private bool _isBarking { get; set; } = true;

    public Chihuahua(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isGoodBoy, bool isBarking)
        : base(sound, numberOfLegs, hasTail, isPet, age, isGoodBoy)
    {
        _isBarking = isBarking;
    }

    public void EffectOnPublic()
    {
        Console.WriteLine(_isBarking ? "Chihuahua is barking, people are annoyed." : "Chihuahua is quiet, people are calm.");
    }
}

public class Pitbull : Dog
{
    public override int[] Limit { get; } = { 6, 6, 7 };
    private bool _tailIsWagging { get; set; } = false;

    public Pitbull(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isGoodBoy, bool tailIsWagging)
        : base(sound, numberOfLegs, hasTail, isPet, age, isGoodBoy)
    {
        _tailIsWagging = hasTail ? tailIsWagging : false;
    }

    public void WagTail()
    {
        if (_tailIsWagging)
        {
            int duration = 50;
            for (int i = 1; i < duration; i++)
            {
                Console.Write(i % 2 == 0 ? $"\r/" : "\r\\");
                Thread.Sleep(80);
            }
            Console.WriteLine();
        }
    }
}

public class Cat : Animal
{
    public override int[] Limit { get; } = { 4, 5, 7 }; 
    private bool _isPregnant { get; set; } = true;

    public Cat(string sound, int numberOfLegs, bool hasTail, bool isPet, int age, bool isPregnant)
        : base(sound, numberOfLegs, hasTail, isPet, age)
    {
        _isPregnant = isPregnant;
    }

    public void IsPregnant()
    {
        Console.WriteLine(_isPregnant ? "This cat is pregnant again." : "This cat is not pregnant, phew.");
    }
}
