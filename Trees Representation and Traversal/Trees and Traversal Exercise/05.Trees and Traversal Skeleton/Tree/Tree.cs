namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.children = new List<Tree<T>>();
            this.Key = key;

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        public string AsString()
        {
            var sb = new StringBuilder();
            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            return this.BFSSearchForKeys(tree => tree.children.Count > 0 &&
            tree.Parent != null)
                .Select(tree => tree.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.BFSSearchForKeys(tree => tree.children.Count == 0)
                .Select(tree => tree.Key);
        }

        public T GetDeepestKey()
        {
            return this.GetDeepestNode().Key;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var deepsetNode = this.GetDeepestNode();
            var path = new List<T>();

            while (deepsetNode != null) 
            {
                path.Add(deepsetNode.Key);
                deepsetNode = deepsetNode.Parent;
            }
            path.Reverse();
            return path;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.BFSSearchForKeys(tree => tree.children.Count == 0);

            Tree<T> deepestNode = null;
            var maxDepth = 0;

            foreach (var leaf in leafs)
            {
                var depth = CalcDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }
            return deepestNode;
        }

        private IEnumerable<Tree<T>> BFSSearchForKeys(Predicate<Tree<T>> predicate) 
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var currSubtree = queue.Dequeue();

                if (predicate.Invoke(currSubtree))
                {
                    result.Add(currSubtree);
                }

                foreach (var child in currSubtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }
        }

        private int CalcDepth(Tree<T> leaf)
        {
            var depth = 0;
            var tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }
    }
}
