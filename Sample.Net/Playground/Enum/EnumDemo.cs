using System;

namespace Playground.Enum
{
    public class EnumDemo
    {
        public static void Run()
        {
            Animal cat = Animal.CAT;
            Console.WriteLine(cat.GetAnimalName());
        }
    }
    public enum Animal
    {
        DOG,
        CAT,
        DOLPHIN,
    }

    public static class MethodExtensions
    {
        public static string GetAnimalName(this Animal animal)
        {
            return animal.ToString().ToLower();
        }
    }

}