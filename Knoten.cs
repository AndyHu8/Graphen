using System;
using System.Collections.Generic;
using System.Text;

namespace Graphen
{
    public class Knoten
    {
        public string Stadt { get; set; }
        public List<Kante> ListeVonKanten { get; set; }
        public Knoten() //Konstruktor
        {
            ListeVonKanten = new List<Kante>();
        }
    }
}
