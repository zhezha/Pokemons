using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    class Node
    {
        public int id { get; set; }
        public string word { get; set; }
        public List<int> EdgesIn { get; set; }
        public List<int> EdgesOut { get; set; }


        public Node(int id, string word)
        {
            this.id = id;
            this.word = word;
            EdgesIn = new List<int>();
            EdgesOut = new List<int>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Node p = obj as Node;
            if (p == null) return false;

            return this.word == p.word;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
