namespace _05.CalculateSequenceWithQueue
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintSequence(n);
        }
        static void PrintSequence(int n)
        {
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            for (int i = 1; i <= 50; i++)
            {
                sequence.Enqueue(n + 1);
                sequence.Enqueue(2 * n + 1);
                sequence.Enqueue(n + 2);
                n = sequence.ElementAtOrDefault(i);
            }
            Console.WriteLine(string.Join(", ", sequence.Take(50)));
        }
    }
}
