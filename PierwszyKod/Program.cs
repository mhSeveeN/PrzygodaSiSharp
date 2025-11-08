internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("podaj swoje imię: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Witaj " + firstName + "!!");
        Console.WriteLine("Podaj swój rok urodzenia: ");
        int userInput1 = int.Parse(Console.ReadLine());
        int age = 2025 - userInput1;
        Console.WriteLine("Witaj " + firstName + " , już wiem, że masz " + age + " lat.");
        if (age <= 18)
        {
            Console.WriteLine("Dostęp zablokowany - jesteś niepełnoletni:(");
        } else
        {
            Console.WriteLine("Dostęp odblokowany:)");
        }
    }
}