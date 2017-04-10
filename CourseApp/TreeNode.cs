using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static CourseApp.TreeStructure;

namespace CourseApp
{
    class TreeNode
    {
        private KeyValue _entry;
        private TreeNode _parent;
        private List<TreeNode> _children = new List<TreeNode>();

        public KeyValue Entry
        {
            get { return _entry; }

            set { _entry = value; }
        }

        public TreeNode Parent
        {
            get { return _parent; }

            set { _parent = value; }
        }

        public List<TreeNode> Children
        {
            get { return _children; }            
        }

        public TreeNode(KeyValue entry)
        {
            _entry = entry;
        }

        public void AddChild(TreeNode child)
        {
            _children.Add(child);
        }

        public override string ToString()
        {
            return $"[{_entry.Key}, {_entry.Value}]^({(_parent == null ? "-" : _parent.Entry.Key)})";
        }
    }
}
