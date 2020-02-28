using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphen
{
    public class Graph
    {
        public List<Knoten> ListeVonKnoten { get; set; } = new List<Knoten>();

        public int nodeCount = 0;
        public void AddKnoten(string stadtname)
        {
            ListeVonKnoten.Add(new Knoten { Stadt = stadtname });
            Console.WriteLine(stadtname);
            nodeCount++;
        }

        public void RemoveKnoten(string Knotenname) //den Knoten raussuchen mit dem stadtnamen
        {
            foreach (var i in ListeVonKnoten)
            {
                if (i.Stadt == Knotenname)
                {
                    foreach (var item in i.ListeVonKanten.ToArray())
                    {
                        i.ListeVonKanten.Remove(item);
                    }

                    ListeVonKnoten.Remove(i);
                    return;
                }
            }
        }

        public void AddKante(string Stadt1, string Stadt2, int UserKosten)
        {
            var k1 = ListeVonKnoten.Find(t => t.Stadt == Stadt1);
            var k2 = ListeVonKnoten.Find(t => t.Stadt == Stadt2);

            if (k1 != null && k2 != null)
            {
                var kante = new Kante()
                {
                    A = k1,
                    B = k2,
                    Kosten = UserKosten
                };

                k1.ListeVonKanten.Add(kante);
                k2.ListeVonKanten.Add(kante);
                return;
            }
        }

        public void RemoveKante(string RemoveStadt1, string RemoveStadt2)
        {
            var knoten1 = ListeVonKnoten.Find(t => t.Stadt == RemoveStadt1);
            var knoten2 = ListeVonKnoten.Find(t => t.Stadt == RemoveStadt2);

            foreach (var kante in knoten1.ListeVonKanten)
            {
                if (kante.Equals(knoten2.ListeVonKanten))
                {
                    knoten1.ListeVonKanten.Remove(kante);
                }
            }
        }

        /*public List<Knoten> NachbarnWissen(string DieStadt)
        {
            var dieStadt = ListeVonKnoten.Find(t => t.Stadt == DieStadt);
            List<Knoten> NeueListe = new List<Knoten>();

            foreach (var item in dieStadt.ListeVonKanten)
            {
                if (dieStadt.ListeVonKanten == item.A.ListeVonKanten)
                {
                    NeueListe.Add(item.B);
                    //Console.WriteLine(item.B.Stadt);
                }
                else
                {
                    NeueListe.Add(item.A);
                    //Console.WriteLine(item.A.Stadt);
                }
            }
            return NeueListe;
        }*/

        /*public List<Knoten> Breitensuche(string Startknoten, string Zielknoten) //Liste
        {
            List<Knoten> Offen = new List<Knoten>();
            List<Knoten> Besucht = new List<Knoten>();
            List<Knoten> Ergebnis = new List<Knoten>();

            var startknoten = ListeVonKnoten.Find(t => t.Stadt == Startknoten);
            Knoten AktuellerKnoten = new Knoten();
            AktuellerKnoten = startknoten;
            Offen.Add(AktuellerKnoten);

            while (Offen.Count != 0)
            {
                AktuellerKnoten = Offen.ToArray()[0];

                if (Besucht.Contains(AktuellerKnoten))
                {
                    Offen.Remove(AktuellerKnoten);
                    continue;
                }

                if (Offen == null)
                {
                    Console.WriteLine("Zielknoten wurde nicht gefunden.");
                    break;
                }
                else
                {
                    if (AktuellerKnoten.Stadt == Zielknoten)
                    {
                        Ergebnis.Add(AktuellerKnoten);
                        break;
                    }
                    else
                    {
                        Offen = NachbarnWissen(AktuellerKnoten.Stadt);
                        Offen.Remove(AktuellerKnoten);
                        Besucht.Add(AktuellerKnoten);
                    }
                }
            }
            return Ergebnis;
        }*/

        /**********************************************************************************/
        /*public List<List<Knoten>> Tiefensuche(Knoten start, Knoten target) //Stack
        {
            List<Knoten> temp = new List<Knoten>();
            Stack<Knoten> stack = new Stack<Knoten>();
            List<List<Knoten>> solutions = new List<List<Knoten>>();
            List<Knoten> visited = new List<Knoten>();

            stack.Push(start);
            Knoten current = start;

            while (stack.Count > 0)
            {
                var tempNachbar = nachBaren(current);
                while (tempNachbar.Count != 0)
                {
                    current = tempNachbar.Where(n => !temp.Contains(n)).ToArray()[0];
                    stack.Push(current);

                    if (current == target)
                    {
                        if (!listExistiert(stack.ToList()))
                        {
                            solutions.Add(stack.ToList());
                            stack.Pop();
                            current = stack.Peek();
                        }

                        if (tempNachbar.Count != tempCount(temp, current))
                        {
                            temp.Add(current);
                        }
                        else
                        {
                            stack.Pop();
                            current = stack.Peek();
                            tempNachbar = nachBaren(current);
                        }
                        break;
                    }
                    tempNachbar = nachBaren(current);
                }

                if (tempNachbar.Count == 0)
                {
                    stack.Pop();
                    visited.Add(current);
                    current = stack.Peek();
                }
            }
            return solutions;

            List<Knoten> nachBaren(Knoten aktuell)
            {
                var tempnachbarn = NachbarnWissen(aktuell.Stadt)
                                  .Where(e => !stack.Contains(e))
                                  .Where(e => !visited.Contains(e))
                                  .ToList();
                return tempnachbarn;
            }

            int tempCount(List<Knoten> gesamteListe, Knoten element)
            {
                int Zähler = 0;
                foreach (var item in gesamteListe)
                {
                    if (item == element)
                        Zähler++;
                }
                return Zähler;
            }

            bool listExistiert(List<Knoten> zuPrüfen)
            {
                var _zuPrüfen = zuPrüfen.ToArray();
                if (solutions.Count == 0)
                {
                    return false;
                }
                foreach (var lösung in solutions)
                {
                    var _lösung = lösung.ToArray();
                    for (int i = 0; i < zuPrüfen.Count; i++)
                    {
                        if (_zuPrüfen[i] == _lösung[i])
                        {
                            if (i == zuPrüfen.Count - 1)
                                return true;
                        }
                        else
                            break;
                    }
                }
                return false;
            }
        }*/
        /**********************************************************************************/

        public void DisplayListe()
        {
            Console.WriteLine("-----------------");
            foreach (var item in ListeVonKnoten)
            {
                if (item.ListeVonKanten != null)
                {
                    Console.WriteLine(item.Stadt);
                }
            }

        }

        //Johannes Code
        /// <summary>
        /// Um Rekursion zu verstehen, muss man Rekursion verstehen ;        /// </summary>
        /// <param name="start">Der Startknoten</param>
        /// <param name="ziel">Der Zielknoten</param>
        /// <param name="history">Der bisher gegangene Weg</param>
        /// <returns>Lösungswege</returns>
        public List<List<Knoten>> SearchWaysRecursive(Knoten start, Knoten ziel, List<Knoten> history)
        {
            Console.WriteLine(new string('-', history.Count) + "Starte " + start.Stadt);
            var solutions = new List<List<Knoten>>();
            //Alle Nachbarn holen, die noch nicht in der History sind
            var neighborNodes =
                start.ListeVonKanten.Select(e => e.A)
                .Union(start.ListeVonKanten.Select(e => e.B))
                .Where(e => !history.Contains(e)) //nicht gleich mit Elemente in der Liste
                .ToArray();
            foreach (var neighbor in neighborNodes)
            {
                if (neighbor == ziel)
                {
                    //ist der Nachbar das Ziel, speichern wir das
                    var solution = new List<Knoten>(history) { neighbor };
                    solutions.Add(solution);
                }
                else
                {
                    //ist es nicht das Ziel, dann erweitern wir die History und gehen ein Level tiefer
                    //die Lösungen aus dieser Ebene adden wir zu den solutions
                    var nextHistory = new List<Knoten>(history) { neighbor };
                    solutions.AddRange(SearchWaysRecursive(neighbor, ziel, nextHistory));
                }
            }
            Console.WriteLine(new string('-', history.Count) + "Beende " + start.Stadt);
            return solutions;
        }

    }
}
