using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class TreeStructure
    {
        private TreeNode _root = new TreeNode(new KeyValue { Key = "0", Value = "root" });
        private List<TreeNode> _nodes = new List<TreeNode>();

        public struct KeyValue
        {
            public string Key;
            public string Value;

            public KeyValue(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        public void Initialize(KeyValue[] items)
        {           
            var nodes = new TreeNode[items.Length];

            foreach (var item in items)
            {
                _nodes.Add(new TreeNode(item));
            }

            _nodes.ForEach(node => LinkChildParent(node));                        
        }       

        public void Add(KeyValue item)
        {
            var newNode = new TreeNode(item);
            _nodes.Add(newNode);
            LinkChildParent(newNode);

            _nodes.ForEach(node => {
                if (node.Entry.Key.Length > newNode.Entry.Key.Length)
                {
                    LinkChildParent(node);
                }
            });            
        }

        public List<TreeNode> Find(string key)
        {
            var path = new List<TreeNode>();

            _nodes.ForEach(node => {
                if (node.Entry.Key.Equals(key))
                {                    
                    var current = node;                    

                    while (current != null)
                    {
                        path.Add(current);
                        current = current.Parent;
                    }
                }
            });

            return path;
        }

        public List<TreeNode> FindOptimized(string key)
        {
            var path = new List<TreeNode>();
            SearchInChildren(_root.Children, key, path);

            return path;
        }

        private void SearchInChildren(List<TreeNode> children, string key, List<TreeNode> path)
        {
            if (!children.Any()) { return; }

            foreach (var iterNode in children)
            {
                if (iterNode.Entry.Key.Equals(key))
                {
                    path.Add(iterNode);
                    return;
                }
            }

            int barrier = 1;

            while (barrier != key.Length)
            {
                var keyPrefix = key.Substring(0, barrier);

                foreach (var iterNode in children)
                {
                    if (iterNode.Entry.Key.Equals(keyPrefix))
                    {
                        path.Add(iterNode);
                        SearchInChildren(iterNode.Children, key, path);
                        return;
                    }
                }

                barrier++;
            }            
        }

        private void LinkChildParent(TreeNode node)
        {
            var currentParent = node.Parent;
            var parent = FindParent(node);

            if (parent != currentParent)
            {
                parent.AddChild(node);

                if (currentParent != null)
                {
                    currentParent.Children.Remove(node);
                }

                node.Parent = parent;                
            }            
        }

        private TreeNode FindParent(TreeNode node)
        {
            var key = node.Entry.Key;

            if (key.Length == 1)
            {                
                return _root;
            }
            
            var barrier = key.Length - 1;            

            while (barrier != 0)
            {
                string possibleParentKey = key.Substring(0, barrier);                

                foreach (var iterNode in _nodes)
                {
                    if (iterNode.Entry.Key.Equals(possibleParentKey))
                    {
                        return iterNode;
                    }
                }

                barrier--;
            }                     

            return _root;
        }       

        public void print()
        {            
            Console.WriteLine($"{_root}");
            var queue = _root.Children;

            while (queue.Count != 0)
            {
                queue.ForEach(node => Console.Write($"{node} "));                

                Console.WriteLine();

                var clearBarrier = queue.Count;
                var tempQueue = new List<TreeNode>();

                queue.ForEach(node => tempQueue.AddRange(node.Children));                

                queue = tempQueue;
            }            
        }
    }
}
