using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Tableau
    {
        string astérix = new string ('*', 100);
        string barre = new string ('-', 100);
        string space = new string (' ', 21);

        private List<CentraleType> list_Producteur = new List<CentraleType>();
        private List<ConsommateurType> list_Consommateur = new List<ConsommateurType>();

        public Tableau (List<CentraleType> liste_1, List<ConsommateurType> liste_2)
        {
            list_Consommateur = liste_2;
            list_Producteur = liste_1;
        }

        public void show()
        {
            Console.WriteLine("TABLEAU" + "\n");
            Console.WriteLine(astérix);
            foreach (CentraleType producteur in list_Producteur)
            {
                Console.WriteLine(producteur.GetNodeId() + (space.Remove(0, producteur.GetNodeId().Length)) + producteur.getProduction()+"W"+ (space.Remove(0, producteur.getProduction().ToString().Length)) + producteur.getCO2()+"kg"+ (space.Remove(0, producteur.getCO2().ToString().Length)) + producteur.getCout() + "€");
            }
            Console.WriteLine(barre);
            foreach (ConsommateurType consommateur in list_Consommateur)
            {
                Console.WriteLine(consommateur.GetNodeId() + (space.Remove(0, consommateur.GetNodeId().Length)) + consommateur.getConsommation() + "\n");
            }
            Console.WriteLine(barre);
        }
    }
}