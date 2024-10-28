namespace Lektion2810
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
    public Animal(string sound)
    {
        Sound = sound;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Details of this animal\n" +
            $"Sound : {Sound}\n" +
            $"Number of legs : {NumberOfLegs}\n" +
            $"Has tail : {HasTail}\n" +
            $"Is a pet : {IsPet}\n" +
            $"Animals age : {Age}\n");
    }
    public virtual void feat()
    {
        Console.WriteLine();
    }
    public virtual void MakeSound()
    {
        Console.WriteLine(Sound);
        foreach(var s in Sound)
        {
            Console.Write(s);
            Thread.Sleep(200);
        }
    }

}

public class Bear : Animal
{
    public string Sound { get; set; } = "Default";
    public int NumberOfLegs { get; set; } = 4;
    public bool HasTail { get; set; } = false;
    public bool IsPet { get; set; } = false;
    public int Age { get; set; } = -1;
    public Bear(string sound) : base(sound)
    {

    }
    public override void MakeSound() 
    {
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        throw new NotImplementedException();
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        throw new NotImplementedException();
    }
}