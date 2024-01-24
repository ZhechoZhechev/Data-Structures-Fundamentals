namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        public BinarySearchTree() { }

        private Node Root { get; set; }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        public bool Contains(T element)
        {
            return this.FindNode(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            this.EachInOrder(action, node.Right);
        }

        public void Insert(T element)
        {
            this.Root = this.InsertNode(element, this.Root);
        }

        private Node InsertNode(T element, Node node)
        {
            if(node == null)
            {
                node = new Node(element);
            }
            else if(element.CompareTo(node.Value) < 0)
            {
                node.Left = this.InsertNode(element, node.Left);
            }
            else if(element.CompareTo(node.Value) > 0)
            {
                node.Right = this.InsertNode(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private Node FindNode(T element)
        {
            var node = this.Root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }
    }
}
