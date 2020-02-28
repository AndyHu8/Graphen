using System;
using System.Collections.Generic;
using System.Text;

namespace Graphen
{
    public class Kante
    {
        public Knoten A { get; set; }
        public Knoten B { get; set; }
        public int Kosten { get; set; }
    }
}
