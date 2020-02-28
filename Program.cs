using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphen
{
    public class Program
    {
        static void Main(string[] args)
        {
            var Graph = new Graph();

            //Breitensuche
            /*Graph.AddKnoten("Berlin");
            Graph.AddKnoten("Hamburg");
            Graph.AddKnoten("Köln");
            Graph.AddKnoten("Stuttgart");
            Graph.AddKnoten("München");

            Graph.AddKante("Berlin", "Hamburg", 5);
            Graph.AddKante("Berlin", "Köln", 8);
            Graph.AddKante("Hamburg", "Köln", 10);
            Graph.AddKante("Köln", "Stuttgart", 15);
            Graph.AddKante("Stuttgart", "München", 20);
            Graph.AddKante("München", "Berlin", 25);*/

            /*Graph.AddKnoten("Berlin");
            Graph.AddKnoten("Sachsen");
            Graph.AddKnoten("Hamburg");
            Graph.AddKnoten("München");
            Graph.AddKnoten("Köln");
            Graph.AddKnoten("Frankfurt");
            Graph.AddKnoten("Bremen");
            Graph.AddKnoten("Hessen");
            Graph.AddKnoten("Stuttgart");

            Graph.AddKante("Berlin", "Sachsen", 2);
            Graph.AddKante("Berlin", "Hamburg", 5);
            Graph.AddKante("Berlin", "München", 10);
            Graph.AddKante("Berlin", "Köln", 15);
            Graph.AddKante("Hamburg", "Frankfurt", 20);
            Graph.AddKante("München", "Bremen", 25);
            Graph.AddKante("München", "Hessen", 30);
            Graph.AddKante("Köln", "Stuttgart", 35);*/

            //Tiefensuche
            Graph.AddKnoten("E");
            Graph.AddKnoten("F");
            Graph.AddKnoten("B");
            Graph.AddKnoten("D");
            Graph.AddKnoten("H");
            Graph.AddKnoten("C");
            Graph.AddKnoten("A");
            Graph.AddKnoten("G");
            Graph.AddKnoten("K");
            Graph.AddKnoten("Q");
            Graph.AddKnoten("Z");

            Graph.AddKante("E", "B", 10);
            Graph.AddKante("E", "F", 1);
            Graph.AddKante("E", "H", 7);
            Graph.AddKante("E", "D", 5);
            Graph.AddKante("D", "C", 4);
            Graph.AddKante("C", "A", 2);
            Graph.AddKante("D", "G", 1);
            Graph.AddKante("H", "G", 5);
            Graph.AddKante("H", "K", 10);
            Graph.AddKante("K", "Q", 2);
            Graph.AddKante("G", "Z", 3);
            Graph.AddKante("K", "Z", 1);

            var start = Graph.ListeVonKnoten.First(n => n.Stadt == "E");
            var ziel = Graph.ListeVonKnoten.First(n => n.Stadt == "Z");

            //Graph.RemoveKnoten("Berlin");

            //Graph.RemoveKante("Berlin", "Hamburg");

            Graph.DisplayListe();

            Console.WriteLine("----------------");
            //Graph.NachbarnWissen("Berlin");

            Console.WriteLine("-----------------");
            //Graph.Breitensuche("Berlin", "Stuttgart");

            Console.WriteLine("-----------------");
            //Graph.Tiefensuche(new Knoten("´Berlin", ), "Frankfurt");

            List<Knoten> JohannesListe = new List<Knoten>();
            Graph.SearchWaysRecursive(start, ziel, JohannesListe);




        }
    }
}
