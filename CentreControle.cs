using System;
using System.Collections.Generic;


namespace PROJET
{
    public class CentreControle
    {
        private List<DistributionNode> liste_noeud_Distribution = new List<DistributionNode>();
        private List<ConcentrationNode> liste_noeud_Concentration  = new List<ConcentrationNode>();

        public CentreControle(List<DistributionNode> liste_3, List<ConcentrationNode> liste_4)
        {
            liste_noeud_Distribution = liste_3;
            liste_noeud_Concentration = liste_4;
        }

        public void ControleProduction()
        {
            foreach(DistributionNode distributionNode in liste_noeud_Distribution)
            {
                foreach(ConcentrationNode concentrationNode in liste_noeud_Concentration)
                {
                    if (distributionNode.Production > concentrationNode.Production)
                    {
                        Console.WriteLine("/! ALERTE /! La consommation surpasse la production !!!");
                        double difference = distributionNode.Production - concentrationNode.Production;
                        Console.WriteLine("FAITES CHAUFFER LES TURBINES, il manque {0}W", difference);
                    }

                    else if (distributionNode.Production < concentrationNode.Production)
                    {
                        Console.WriteLine("/! ALERTE /! La production surpasse la consommation !!!");
                        double difference =  concentrationNode.Production - distributionNode.Production;
                        Console.WriteLine("REFROIDISSEZ LES TURBINES, il y a {0}W en plus",difference);
                    }

                    else {
                        Console.WriteLine("oki drareh");
                    }
                }
            }    
        }
        public void mise_a_jour(Graph graphique, Tableau board)
        {
            if (graphique.checkForAvailability())
            {
                graphique.GetGraph();

                Console.WriteLine("\n");

                board.show();
            }
            else
            {
                Console.WriteLine("There are less than 2 nodes. Add more to connect.");
            }
        }    
    }
}


