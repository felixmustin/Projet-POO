using System;
using System.Collections.Generic;


namespace PROJET
{
    public class CentreControle
    {
        private List<DistributionNode> liste_noeud_Distribution = new List<DistributionNode>();
        private List<ConcentrationNode> liste_noeud_Concentration  = new List<ConcentrationNode>();
        private List<Node> liste_noeud_achat  = new List<Node>();
        Marché Europe = new Marché(1000, 1000, 1500);
        private int cout_initial;
        private Node Central_reference;

        public CentreControle(List<DistributionNode> liste_3, List<ConcentrationNode> liste_4, List<Node> liste_5)
        {
            liste_noeud_Distribution = liste_3;
            liste_noeud_Concentration = liste_4;
            liste_noeud_achat = liste_5;
        }

        public void ControleProduction(Graph graphique, Tableau board)
        {
            foreach(DistributionNode distributionNode in liste_noeud_Distribution)
            {
                foreach(ConcentrationNode concentrationNode in liste_noeud_Concentration)
                {
                    if (distributionNode.Production < 0 )
                    {
                        Console.WriteLine("/! ALERTE /! La consommation surpasse la production !!!");
                        Console.WriteLine("FAITES CHAUFFER LES TURBINES, il manque {0}W", Math.Abs(distributionNode.Production));
                        Console.WriteLine("\n");
                        // crée valeur global erreur qui récupère les proplèmes trouvé

                        foreach(ConcentrationNode noeuds in liste_noeud_Concentration)
                        {
                            foreach(Lines lignes in noeuds.GetReception())
                            {
                                if (lignes.GetId() == noeuds.GetReception()[0].GetId()){
                                    cout_initial = Europe.getPrix_Achat();
                                }
                                if (lignes.GetFrom().Cout < cout_initial){
                                    if(lignes.GetFrom().Production+Math.Abs(distributionNode.Production)<=lignes.Puissance_Max){
                                        cout_initial = lignes.GetFrom().Cout;
                                        Central_reference = lignes.GetFrom();
                                    }
                                }
                            }
                        }
                        if (cout_initial == Europe.getPrix_Achat()){
                            foreach(Node noeud_achat in liste_noeud_achat){
                                noeud_achat.addProduction(Math.Abs(distributionNode.Production));
                                Console.WriteLine(Math.Abs(distributionNode.Production) + " ont été achetés");
                            }
                        }
                        else{
                            Central_reference.addProduction(Math.Abs(distributionNode.Production));
                        }                         
                    }
                
                    else if (distributionNode.Production > 0 )
                    {
                        Console.WriteLine("/! ALERTE /! La production surpasse la consommation !!!");
                        Console.WriteLine("REFROIDISSEZ LES TURBINES, il y a {0}W en plus",Math.Abs(distributionNode.Production));
                        Console.WriteLine("\n");

                        foreach(ConcentrationNode noeuds in liste_noeud_Concentration)
                        {
                            foreach(Lines lignes in noeuds.GetReception())
                            {   
                                if (lignes.GetId() == noeuds.GetReception()[0].GetId()){
                                    cout_initial = Europe.getPrix_Vente();
                                    
                                }
                                if ((lignes.GetFrom().Cout*Math.Abs(distributionNode.Production)) > (cout_initial*Math.Abs(distributionNode.Production))){
                                    if(lignes.GetFrom().Production-Math.Abs(distributionNode.Production)>=0){
                                        cout_initial = lignes.GetFrom().Cout;
                                        Central_reference = lignes.GetFrom();
                                    }
                                }
                            }
                        }
                        if (cout_initial == Europe.getPrix_Vente()){
                            concentrationNode.substractProduction(Math.Abs(distributionNode.Production));
                            Console.WriteLine(Math.Abs(distributionNode.Production) + " ont été vendus");
                        }
                        else{
                            Central_reference.substractProduction(Math.Abs(distributionNode.Production));
                        } 
                    }
                }
            } 
            //maj
            foreach(Node noeud in graphique.getList())
            {
                if (noeud is ConcentrationNode )
                {
                    noeud.Production = 0;
                    foreach(Lines lignes in noeud.GetReception())
                    {
                        lignes.validate();
                    }
                }
                else if (noeud is DistributionNode )
                {
                    noeud.Production = 0;
                    foreach(Lines lignes in noeud.GetDistribution())
                    {
                       lignes.validate();
                    }
                    foreach(Lines lignes in noeud.GetReception())
                    {
                       lignes.validate();
                    }  
                }  
            }   
        }
    }  
}
