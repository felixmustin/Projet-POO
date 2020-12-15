using System;
using System.Collections.Generic;

namespace PROJET
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            ConcentrationNode Concentration1 = new ConcentrationNode("Noeud de reception 1", 0);
            DistributionNode Distribution1 = new DistributionNode("Noeud de distribution 1", 0);

            GazCentral Gaz = new GazCentral("Centrale à Gaz", 1000, 25, 222);
            EolienCentral Eolienne = new EolienCentral("Centrale Eolienne",15000, 5, 100);
            NuclearCentral Nuclear = new NuclearCentral("centrale nucléaire", 2000);

            VilleCons Bruxelles = new VilleCons("Bruxelles", 5000);
            EntrepriseCons ECAM = new EntrepriseCons("ECAM", 1000);
            EtrangerCons France = new EtrangerCons("France", 2000);

            Meteo brabant = new Meteo(0.8, 0.1, 28);

            Batterie batterie_1 = new Batterie("Batterie de stockage", 0);

            var liste_producteur = new List<CentraleType>(){Eolienne, Gaz};
            var liste_consommateur = new List<ConsommateurType>(){Bruxelles, ECAM, France};
            var liste_distribution = new List<DistributionNode>(){Distribution1};
            var liste_concentration = new List<ConcentrationNode>(){Concentration1};  
            var liste_batteries = new List<Batterie>(){batterie_1};

            graph.CreateNode(Gaz);
            graph.CreateNode(Eolienne);
            graph.CreateNode(Concentration1);
            graph.CreateNode(Distribution1);
            graph.CreateNode(Bruxelles);
            graph.CreateNode(ECAM);
            graph.CreateNode(France);
            graph.CreateNode(batterie_1);

            Lines e38 = new Lines(Concentration1, batterie_1, 8, 100000);
            Concentration1.AddDistribution(e38);
            Lines e13 = new Lines(Gaz, Concentration1, 1, 5000);
            Gaz.AddDistribution(e13);
            Lines e23 = new Lines(Eolienne, Concentration1, 2, 5000);
            Eolienne.AddDistribution(e23);
            Lines e34 = new Lines(Concentration1, Distribution1, 3,100000);
            Concentration1.AddDistribution(e34);
            Lines e45 = new Lines(Distribution1, Bruxelles, 4,20000);
            Distribution1.AddDistribution(e45);
            Lines e46 = new Lines(Distribution1, ECAM, 5,20000);
            Distribution1.AddDistribution(e46);
            Lines e47 = new Lines(Distribution1, France, 6,20000);
            Distribution1.AddDistribution(e47);

            Tableau tableau = new Tableau(liste_producteur, liste_consommateur, liste_batteries);
            CentreControle Nasa = new CentreControle(liste_distribution, liste_concentration);

            
            /*if (graph.checkForAvailability())
            {               
                graph.GetGraph();

                Console.WriteLine("\n");

                tableau.show();

                Nasa.ControleProduction();
                Console.Write("{0} et {1}", Concentration1.Production, Distribution1.Production);
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }
            */
            

            //Modifications sur le réseau

            
            brabant.Vent(Eolienne);
            Gaz.addProduction(500);
            Eolienne.addProduction(1000);
            Bruxelles.substractConsommation(500);        
            
            Nasa.mise_a_jour(graph, tableau);
            Nasa.ControleProduction();
        }
    }
}