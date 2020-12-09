using System;

namespace PROJET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Writeline('salut');
            GazCentral G1 = new GazCentral("Centrale à Gaz");

            Graph graph = new Graph();

            Node node1 = new Node("Centrale 1");

            Node node2 = new Node("Maison");

            Node node3 = new Node("Entreprise");

            graph.CreateNode(node1);
            graph.CreateNode(node2);
            graph.CreateNode(node3);

            graph.CreateNode(G1);

            Lines e12 = new Lines(node1, node2, 1);
            Lines e13 = new Lines(node1, node3, 2);

            Lines e34 = new Lines(G1, node3, 3);

            if (graph.checkForAvailability())
            {
                node1.AddDistribution(e12);
                node1.AddDistribution(e13);
                G1.AddDistribution(e34);

                graph.GetGraph();
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }
        }
    }
}