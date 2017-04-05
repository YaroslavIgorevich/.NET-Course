using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp
{
    class TreeStructure
    {
        private KeyValue[] items;

        public struct KeyValue
        {
            public string key;
            public string value;

            public KeyValue(string key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public void Initialize(KeyValue[] items)
        {
            this.items = items;
        }
        
        public void Add(KeyValue item)
        {
            items = items.Concat(new KeyValue[] { item }).ToArray();
        }

        public KeyValue[] Find(string key)
        {            
            KeyValue[] foundItems = {};

            foreach (var item in items)
            {
                if (key.Contains(item.key))
                {
                    foundItems = foundItems.Concat(new KeyValue[] { item }).ToArray();
                }    
            }

            return foundItems;
        }        
    }
}
