namespace _06.SequenceN_M;

internal class Program
{
    public class Node
    {
        public int value { get; set; }
        public Node? previous { get; set; }

        public Node(int value)
        {
            this.value = value;
            this.previous = null;
        }
        public Node(int value, Node previous)
        {
            this.value = value;
            this.previous = previous;
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        int m = int.Parse(Console.ReadLine()!);

        Queue<Node> queue = new Queue<Node>();
        List<int> list = new List<int>();

        Node start = new Node(n);
        queue.Enqueue(start);

        while (queue.Count > 0 && list.Count == 0)
        {
            Node current = queue.Dequeue();
            if (current.value < m)
            {
                queue.Enqueue(new Node(current.value + 1, current));
                queue.Enqueue(new Node(current.value + 2, current));
                queue.Enqueue(new Node(current.value * 2, current));
            }
            if (current.value == m)
            {
                while (current != null)
                {
                    list.Add(current.value);
                    current = current.previous;
                }

            }
        }

        if (list.Count != 0)
        {
            list.Reverse();
            Console.WriteLine(string.Join(" -> ", list));
        }
        else
        {
            Console.WriteLine("(no solution)");
        }
    }
}
