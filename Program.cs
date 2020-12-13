using System;

namespace PROJET
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            GazCentral Gaz = new GazCentral("Centrale à Gaz", 1000);
            EolienCentral Eolienne = new EolienCentral("Centrale Eolienne",15000);

            ConcentrationNode Concentration1 = new ConcentrationNode("Noeud de reception 1");
            DistributionNode Distribution1 = new DistributionNode("Noeud de distribution 1");

            VilleCons Bruxelles = new VilleCons("Bruxelles", 5000);
            EntrepriseCons ECAM = new EntrepriseCons("ECAM", 1000);


            graph.CreateNode(Gaz);
            graph.CreateNode(Eolienne);
            graph.CreateNode(Concentration1);
            graph.CreateNode(Distribution1);
            graph.CreateNode(Bruxelles);
            graph.CreateNode(ECAM);

            Lines e13 = new Lines(Gaz, Concentration1, 1);
            Lines e23 = new Lines(Eolienne, Concentration1, 2);
            Lines e34 = new Lines(Concentration1, Distribution1, 3);
            Lines e45 = new Lines(Distribution1, Bruxelles, 4);
            Lines e46 = new Lines(Distribution1, ECAM, 5);


            if (graph.checkForAvailability())
            {
                Gaz.AddDistribution(e13);
                Eolienne.AddDistribution(e23);
                Concentration1.AddDistribution(e34);
                Distribution1.AddDistribution(e45);
                Distribution1.AddDistribution(e46);
                
                graph.GetGraph();
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }

            Vent brabant = new Vent(Eolienne, 0.5, "Centrale Eolienne");
            Grève Pont_a_Celle = new Grève(Gaz, 0.3, "Centrale à Gaz");

        }

    }
}