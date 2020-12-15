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
                    if (distributionNode.Production < 0 )
                    {
                        Console.WriteLine("/! ALERTE /! La consommation surpasse la production !!!");
                        double difference = distributionNode.Production - concentrationNode.Production;
                        Console.WriteLine("FAITES CHAUFFER LES TURBINES, il manque {0}W", Math.Abs(distributionNode.Production));
                        Console.WriteLine("\n");
                    }

                    else if (distributionNode.Production > 0 )
                    {
                        Console.WriteLine("/! ALERTE /! La production surpasse la consommation !!!");
                        double difference =  concentrationNode.Production - distributionNode.Production;
                        Console.WriteLine("REFROIDISSEZ LES TURBINES, il y a {0}W en plus",Math.Abs(distributionNode.Production));
                        Console.WriteLine("\n");
                    }

                    else {
                        Console.WriteLine("oki drareh");
                    }
                }
            }    
        }
        public void mise_a_jour(Graph graphique, Tableau board)
        {    
            foreach(Node noeud in graphique.getList())
            {
                if (noeud is ConcentrationNode ){
                    noeud.Production = 0;
                    foreach(Lines ligneDe in noeud.GetReception())
                    {
                        if(ligneDe.GetFrom().Production > ligneDe.Puissance_Max){
                            noeud.Production += ligneDe.Puissance_Max;
                        }
                        else{
                            noeud.Production += ligneDe.GetFrom().Production;
                        }
                    }

                    foreach(Lines lignesVers in noeud.GetDistribution()){
                        if(lignesVers.GetTo() is DistributionNode){
                            lignesVers.GetTo().Production=0;
                            lignesVers.GetTo().Production += noeud.Production;
                        }
                        else if (lignesVers.GetTo() is Batterie){
                            lignesVers.GetTo().Production=0;
                            foreach (Lines ligne in noeud.GetReception())
                            {
                                lignesVers.GetTo().Production += (ligne.GetFrom().Production - ligne.Puissance_Max);
                            }
                        }
                    }
                }
                
                else if (noeud is DistributionNode ){
                    foreach(Lines ligneVers in noeud.GetDistribution()){
                        noeud.Production -= ligneVers.GetTo().Production;
                    }       
                }
            }
            

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