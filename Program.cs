using System;
using System.Collections.Generic;
using System.Threading;

namespace PROJET
{
    class Program
    {
        public static string Alerte ="";

        public static void Main(string[] args)
        {   
            Thread myThread = new Thread(new ThreadStart(ThreadLoop));

            myThread.Start();
            Thread.Sleep(20000);
            myThread.Interrupt();
        } 
        static public void ThreadLoop()
        {
            Graph graph = new Graph();

            ConcentrationNode Concentration1 = new ConcentrationNode("Noeud de reception 1", 0);
            DistributionNode Distribution1 = new DistributionNode("Noeud de distribution 1", 0);

            GazCentral Gaz = new GazCentral("Centrale à Gaz", 6000, 25, 200);
            EolienCentral Eolienne = new EolienCentral("Centrale Eolienne",4000, 5, 100);

            VilleCons Bruxelles = new VilleCons("Bruxelles", 6000);
            EntrepriseCons ECAM = new EntrepriseCons("ECAM", 3000);
            EtrangerCons France = new EtrangerCons("France", 9000);

            Meteo brabant = new Meteo(0.8, 0.1, 28);

            Batterie batterie_1 = new Batterie("Batterie de stockage", 0);

            var liste_producteur1 = new List<CentraleType>(){Eolienne, Gaz};
            var liste_consommateur1 = new List<ConsommateurType>(){Bruxelles, ECAM, France};
            var liste_distribution1 = new List<DistributionNode>(){Distribution1};
            var liste_concentration1 = new List<ConcentrationNode>(){Concentration1};  
            var liste_batteries1 = new List<Batterie>(){batterie_1};

            graph.CreateNode(Gaz);
            graph.CreateNode(Eolienne);
            graph.CreateNode(Concentration1);
            graph.CreateNode(Distribution1);
            graph.CreateNode(ECAM);
            graph.CreateNode(Bruxelles);
            graph.CreateNode(France);
            graph.CreateNode(batterie_1);

            Lines e38 = new Lines(Concentration1, batterie_1, 8, 100000);
            Concentration1.AddDistribution(e38);
            Lines e13 = new Lines(Gaz, Concentration1, 1, 10000);
            Gaz.AddDistribution(e13);
            Lines e23 = new Lines(Eolienne, Concentration1, 2, 10000);
            Eolienne.AddDistribution(e23);
            Lines e34 = new Lines(Concentration1, Distribution1, 3,100000);
            Concentration1.AddDistribution(e34);
            Lines e45 = new Lines(Distribution1, Bruxelles, 4,20000);
            Distribution1.AddDistribution(e45);
            Lines e46 = new Lines(Distribution1, ECAM, 5,20000);
            Distribution1.AddDistribution(e46);
            Lines e47 = new Lines(Distribution1, France, 6,20000);
            Distribution1.AddDistribution(e47);

            Tableau tableau = new Tableau(liste_producteur1, liste_consommateur1, liste_batteries1);
            CentreControle Nasa = new CentreControle(liste_distribution1, liste_concentration1);


            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
            Nasa.ControleProduction(graph, tableau);
            graph.GetGraph();
            Console.WriteLine("\n"+"heEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            tableau.show();

            // Attente de 5
            Thread.Sleep(5000);

            Alerte="";
            brabant.Vent(Eolienne);
            Nasa.ControleProduction(graph, tableau);
            graph.GetGraph();
            Console.WriteLine("\n");
            tableau.show();

            // Attente de 5s
            Thread.Sleep(5000);

            Alerte="";
            Gaz.addProduction(5000);
            Nasa.ControleProduction(graph, tableau);
            graph.GetGraph();
            Console.WriteLine("\n");
            tableau.show();

            // Attente de 5s
            Thread.Sleep(5000);  

            Alerte="";
            France.substractConsommation(5000);
            Nasa.ControleProduction(graph, tableau);
            graph.GetGraph();
            Console.WriteLine("\n");
            tableau.show();

            Thread.Sleep(5000);
            }
        }
    }
}




            //Modifications sur le réseau


            /* brabant.Vent(Eolienne);
            Gaz.addProduction(5000);
            France.substractConsommation(5000);

            Nasa.ControleProduction(graph, tableau);

            if (graph.checkForAvailability()){
                graph.GetGraph();
                Console.WriteLine("\n");
                tableau.show();
            }
            else{
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }*/

            