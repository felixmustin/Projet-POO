using System;

namespace PROJET
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph graph = new Graph();

            GazCentral Gaz = new GazCentral("Centrale à Gaz");

            VilleCons Bxl = new VilleCons("Bruxelles");

            graph.CreateNode(Gaz);
            graph.CreateNode(Bxl);

            Lines e12 = new Lines(Gaz, Bxl, 1);

            if (graph.checkForAvailability())
            {
                Gaz.AddDistribution(e12);

                graph.GetGraph();
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }
        }
    }
}