using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Tableau
    {
        string astérix = new string ('*', 30);
        string barre = new string ('-', 30);
        string space = new string (' ', 5);

        private List<CentraleType> list_Producteur = new List<CentraleType>();
        private List<ConsommateurType> list_Consommateur = new List<ConsommateurType>();

        public Tableau (List<CentraleType> liste_1, List<ConsommateurType> liste_2)
        {
            list_Consommateur = liste_2;
            list_Producteur = liste_1;
        }

        public void show()
        {
            Console.WriteLine(astérix);
            foreach (CentraleType producteur in list_Producteur)
            {
                Console.WriteLine(producteur.getid() + space + producteur.getProduction()+ space + producteur.getCO2());
            }
            Console.WriteLine(barre);
            foreach (ConsommateurType consommateur in list_Consommateur)
            {
                Console.WriteLine(consommateur.GetNodeId() + space + consommateur.getConsommation());
            }
        }
    }
}