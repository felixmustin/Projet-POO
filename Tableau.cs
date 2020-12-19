using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Tableau
    {
        string astérix = new string ('*', 100);
        string barre = new string ('-', 100);
        string space = new string (' ', 26);

        private List<CentraleType> list_Producteur = new List<CentraleType>();
        private List<ConsommateurType> list_Consommateur = new List<ConsommateurType>();

        private List<Batterie> list_batteries = new List<Batterie>();
        private List<Node> liste_noeud_achat  = new List<Node>();

        public Tableau (List<CentraleType> liste_1, List<ConsommateurType> liste_2, List<Batterie> liste_3,  List<Node> liste_4)
        {
            list_Consommateur = liste_2;
            list_Producteur = liste_1;
            list_batteries = liste_3;
            liste_noeud_achat = liste_4;
        }

        public void show()
        {
            Console.WriteLine("TABLEAU" + "\n");
            Console.WriteLine(astérix);
            foreach (CentraleType producteur in list_Producteur)
            {
                Console.WriteLine(producteur.GetNodeId() + (space.Remove(0, producteur.GetNodeId().Length)) + producteur.getProduction()+"W"+ " (" + producteur.GetDistribution()[0].Puissance_Max + "W max )" + (space.Remove(0, producteur.getProduction().ToString().Length)) + producteur.getCO2()+"kg"+ (space.Remove(0, producteur.getCO2().ToString().Length)) + producteur.getCout() + "€");
            }
            foreach(Node achat in liste_noeud_achat)
            {
                Console.WriteLine(achat.GetNodeId() + (space.Remove(0, achat.GetNodeId().Length)) + achat.Production +"W " + "\n");
            }
            Console.WriteLine(barre);
            foreach (ConsommateurType consommateur in list_Consommateur)
            {
                Console.WriteLine(consommateur.GetNodeId() + (space.Remove(0, consommateur.GetNodeId().Length)) + consommateur.getConsommation() + "\n");
            }
            Console.WriteLine(barre);
            foreach(ConsommateurType batteries in list_batteries)
            {
                Console.WriteLine(batteries.GetNodeId() + (space.Remove(0, batteries.GetNodeId().Length)) + batteries.getConsommation() + "\n");
            }
        }
    }
}