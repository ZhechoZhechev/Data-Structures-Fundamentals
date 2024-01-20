namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Tree<T> : IAbstractTree<T>
    {
        private T Value { get; set; }
        private List<Tree<T>> Children { get; set; }
        private Tree<T> Parent { get; set; }

        public Tree(T value)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.Children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parent = this.FindNodeWithBFS(parentKey);


            if (parent is null)
            {
                throw new ArgumentNullException();
            }

            parent.Children.Add(child);
            child.Parent = parent;
        }

        private Tree<T> FindNodeWithBFS(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                if (subTree.Value.Equals(parentKey))
                {
                    return subTree;
                }
                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            List<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
             
            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.Value);
                foreach(var child in subTree.Children) 
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            List<T> result = new List<T>();
            this.DFS(this, result);
            return result;
        }

        private void DFS(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                DFS(child, result);
            }

            result.Add(tree.Value);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> nodeToRemove =  this.FindNodeWithBFS(nodeKey);
            if (nodeToRemove is null) 
            {
                throw new ArgumentNullException();
            }

            Tree<T> parent = nodeToRemove.Parent;
            if (parent is null)
            {
                throw new ArgumentException();
            }

            parent.Children.Remove(nodeToRemove);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNodeWithBFS(firstKey);
            var secondNode = this.FindNodeWithBFS(secondKey);

            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.Parent;
            var secondNodeParent = secondNode.Parent;

            if(firstNodeParent is null || secondNodeParent is null)
            {
                throw new ArgumentException();
            }

            var firstChildIndex = firstNodeParent.Children.IndexOf(firstNode);
            var secondChildIndex = secondNodeParent.Children.IndexOf(secondNode);

            firstNodeParent.Children[firstChildIndex] = secondNode;
            secondNode.Parent = firstNodeParent;

            secondNodeParent.Children[secondChildIndex] = firstNode;
            firstNode.Parent = secondNodeParent;
        }
    }
}
