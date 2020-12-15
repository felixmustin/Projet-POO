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

            var liste_producteur1 = new List<CentraleType>(){Eolienne, Gaz};
            var liste_consommateur1 = new List<ConsommateurType>(){Bruxelles, ECAM, France};
            var liste_distribution1 = new List<DistributionNode>(){Distribution1};
            var liste_concentration1 = new List<ConcentrationNode>(){Concentration1};  
            var liste_batteries1 = new List<Batterie>(){batterie_1};

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

            Tableau tableau = new Tableau(liste_producteur1, liste_consommateur1, liste_batteries1);
            CentreControle Nasa = new CentreControle(liste_distribution1, liste_concentration1);

            /*if (graph.checkForAvailability()){               
                graph.GetGraph();

                Console.WriteLine("\n");

                tableau.show();

                Nasa.ControleProduction();
                Console.Write("{0} et {1}", Concentration1.Production, Distribution1.Production);}
            else{
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");}
            */
            
            //Modifications sur le réseau

            brabant.Vent(Eolienne);
            Gaz.addProduction(500);
            Eolienne.addProduction(1000);
            Bruxelles.substractConsommation(500);        
            
            Nasa.mise_a_jour(graph, tableau);
            Nasa.ControleProduction();







            Graph graph2 = new Graph();

            ConcentrationNode Concentration2 = new ConcentrationNode("Noeud de reception 2", 0);
            DistributionNode Distribution2 = new DistributionNode("Noeud de distribution 2", 0);

            SolarCentral Solar = new SolarCentral("Centrale solaire", 1000, 200);
            EolienCentral Eolienne2 = new EolienCentral("Centrale Eolienne 2", 2000, 5, 100);

            VilleCons Mons = new VilleCons("Mons", 1000);
            EntrepriseCons Google = new EntrepriseCons("Google", 1500);
            EtrangerCons New_York = new EtrangerCons("New York", 4000);

            Meteo wallonnie = new Meteo(0.9, 2.5, 27);

            Batterie batterie_2 = new Batterie("Batterie de stockage 2", 0);

            var liste_producteur2 = new List<CentraleType>(){Eolienne2, Solar};
            var liste_consommateur2 = new List<ConsommateurType>(){Mons, Google, New_York};
            var liste_distribution2 = new List<DistributionNode>(){Distribution2};
            var liste_concentration2 = new List<ConcentrationNode>(){Concentration2};  
            var liste_batteries2 = new List<Batterie>(){batterie_2};

            graph2.CreateNode(Solar);
            graph2.CreateNode(Eolienne2);
            graph2.CreateNode(Concentration2);
            graph2.CreateNode(Distribution2);
            graph2.CreateNode(Mons);
            graph2.CreateNode(Google);
            graph2.CreateNode(New_York);
            graph2.CreateNode(batterie_2);

            Lines a = new Lines(Concentration2, batterie_2, 8, 100000);
            Concentration2.AddDistribution(a);
            Lines b = new Lines(Solar, Concentration2, 1, 5000);
            Solar.AddDistribution(b);
            Lines c = new Lines(Eolienne2, Concentration2, 2, 5000);
            Eolienne2.AddDistribution(c);
            Lines d = new Lines(Concentration2, Distribution2, 3,100000);
            Concentration2.AddDistribution(d);
            Lines e = new Lines(Distribution2, Mons, 4,20000);
            Distribution2.AddDistribution(e);
            Lines f = new Lines(Distribution2, Google, 5,20000);
            Distribution2.AddDistribution(f);
            Lines g = new Lines(Distribution2, New_York, 6,20000);
            Distribution2.AddDistribution(g);

            Tableau tableau2 = new Tableau(liste_producteur2, liste_consommateur2, liste_batteries2);
            CentreControle Nasa2 = new CentreControle(liste_distribution2, liste_concentration2);

            /*if (graph.checkForAvailability()){               
                graph.GetGraph();

                Console.WriteLine("\n");

                tableau.show();

                Nasa.ControleProduction();
                Console.Write("{0} et {1}", Concentration1.Production, Distribution1.Production);}
            else{
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");}
            */
            
            //Modifications sur le réseau
       
            wallonnie.Ensoleillement(Solar);
            Bruxelles.substractConsommation(1000);
            New_York.substractConsommation(3000);

            Nasa2.mise_a_jour(graph2, tableau2);
            Nasa2.ControleProduction();



        }
    }
}