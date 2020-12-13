﻿using System;
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

            var liste_producteur = new List<CentraleType>(){Eolienne, Gaz};
            var liste_consommateur = new List<ConsommateurType>(){Bruxelles, ECAM, France};
            var liste_distribution = new List<DistributionNode>(){Distribution1};
            var liste_concentration = new List<ConcentrationNode>(){Concentration1};  

            graph.CreateNode(Gaz);
            graph.CreateNode(Eolienne);
            graph.CreateNode(Concentration1);
            graph.CreateNode(Distribution1);
            graph.CreateNode(Bruxelles);
            graph.CreateNode(ECAM);
            graph.CreateNode(France);

            Lines e13 = new Lines(Gaz, Concentration1, 1,1000);
            Lines e23 = new Lines(Eolienne, Concentration1, 2,1000);
            Lines e34 = new Lines(Concentration1, Distribution1, 3,1000);
            Lines e45 = new Lines(Distribution1, Bruxelles, 4,1000);
            Lines e46 = new Lines(Distribution1, ECAM, 5,1000);
            Lines e47 = new Lines(Distribution1, France, 6,1000);

            Tableau tableau = new Tableau(liste_producteur, liste_consommateur);
            CentreControle Nasa = new CentreControle(liste_distribution, liste_concentration);


            if (graph.checkForAvailability())
            {
                Gaz.AddDistribution(e13);
                Eolienne.AddDistribution(e23);
                Concentration1.AddDistribution(e34);
                Distribution1.AddDistribution(e45);
                Distribution1.AddDistribution(e46);
                Distribution1.AddDistribution(e47);
                
                graph.GetGraph();

                Console.WriteLine("\n");

                tableau.show();
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }
            
            brabant.Vent(Eolienne);
            Gaz.addProduction(500);

            Nasa.mise_a_jour(graph, tableau);
            Nasa.ControleProduction();

        }
    }
}