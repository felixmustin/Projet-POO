﻿using System;
using System.Collections.Generic;

namespace PROJET
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            ConcentrationNode Concentration1 = new ConcentrationNode("Noeud de reception 1");
            DistributionNode Distribution1 = new DistributionNode("Noeud de distribution 1", 0);

            GazCentral Gaz = new GazCentral("Centrale à Gaz", 1000);
            EolienCentral Eolienne = new EolienCentral("Centrale Eolienne",15000);

            VilleCons Bruxelles = new VilleCons("Bruxelles", 5000);
            EntrepriseCons ECAM = new EntrepriseCons("ECAM", 1000);
            EtrangerCons France = new EtrangerCons("France", 2000);

            Bruxelles.addConsommation(1000);
            Console.WriteLine(Bruxelles.consommation);

            Distribution1.consommation = Bruxelles.consommation + ECAM.consommation + France.consommation;

            Console.WriteLine(Distribution1.consommation);




            Meteo brabant = new Meteo(0.8, 0.1, 28);

            var liste_producteur = new List<CentraleType>(){Eolienne, Gaz};
            var liste_consommateur = new List<ConsommateurType>(){Bruxelles, ECAM};

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
            Lines e47 = new Lines(Distribution1, France, 6);

            brabant.Vent(Eolienne);


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
                Tableau tableau = new Tableau(liste_producteur, liste_consommateur);
                tableau.show();
                
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }
            // Vent brabant = new Vent(Eolienne, 0.5, "Centrale Eolienne");
            // Grève Pont_a_Celle = new Grève(Gaz, 0.3, "Centrale à Gaz");

            
        }
    }
}