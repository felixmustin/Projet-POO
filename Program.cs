using System;
using System.Collections.Generic;

namespace PROJET
{
    class Program
    {
        public static string Alerte ="";
        static void Main(string[] args)
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

            Achat achat1 = new Achat("Achat", 0);

            var liste_producteur1 = new List<CentraleType>(){Eolienne, Gaz};
            var liste_consommateur1 = new List<ConsommateurType>(){Bruxelles, ECAM, France};
            var liste_distribution1 = new List<DistributionNode>(){Distribution1};
            var liste_concentration1 = new List<ConcentrationNode>(){Concentration1};  
            var liste_batteries1 = new List<Batterie>(){batterie_1};
            var liste_achat1 = new List<Node>(){achat1};


            graph.CreateNode(Gaz);
            graph.CreateNode(Eolienne);
            graph.CreateNode(Concentration1);
            graph.CreateNode(Distribution1);
            graph.CreateNode(ECAM);
            graph.CreateNode(Bruxelles);
            graph.CreateNode(France);
            graph.CreateNode(batterie_1);
            graph.CreateNode(achat1);

            Lines e38 = new Lines(Concentration1, batterie_1, 8, 100000);
            Concentration1.AddDistribution(e38);
            Lines e13 = new Lines(Gaz, Concentration1, 1, 10000);
            Gaz.AddDistribution(e13);
            Lines e23 = new Lines(Eolienne, Concentration1, 2, 10000);
            Eolienne.AddDistribution(e23);
            Lines e93 = new Lines(achat1, Concentration1, 9, 10000);
            achat1.AddDistribution(e93);
            Lines e34 = new Lines(Concentration1, Distribution1, 3,100000);
            Concentration1.AddDistribution(e34);
            Lines e45 = new Lines(Distribution1, Bruxelles, 4,20000);
            Distribution1.AddDistribution(e45);
            Lines e46 = new Lines(Distribution1, ECAM, 5,20000);
            Distribution1.AddDistribution(e46);
            Lines e47 = new Lines(Distribution1, France, 6,20000);
            Distribution1.AddDistribution(e47);

            Tableau tableau = new Tableau(liste_producteur1, liste_consommateur1, liste_batteries1, liste_achat1);
            CentreControle Nasa = new CentreControle(liste_distribution1, liste_concentration1, liste_achat1);


            //Modifications sur le réseau


            brabant.Vent(Eolienne);
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
            }
        }
    }
}