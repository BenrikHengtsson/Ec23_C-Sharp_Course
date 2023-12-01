namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yo tell me you age now!");
            int Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Thats right muddafukka, {0} are too young!", Age);

            Console.WriteLine(Age + Age);

            Console.ReadKey();

        }
    }
}
