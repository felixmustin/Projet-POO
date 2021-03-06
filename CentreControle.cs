using System;
using System.Collections.Generic;


namespace PROJET
{
    public class CentreControle
    {
        private List<DistributionNode> liste_noeud_Distribution = new List<DistributionNode>();
        private List<ConcentrationNode> liste_noeud_Concentration  = new List<ConcentrationNode>();
        Marché Europe = new Marché(1000, 1000, 1500);
        private int cout_initial;
        private Node Central_reference;

        public CentreControle(List<DistributionNode> liste_3, List<ConcentrationNode> liste_4)
        {
            liste_noeud_Distribution = liste_3;
            liste_noeud_Concentration = liste_4;
        }

        public void ControleProduction(Graph graphique, Tableau board)
        {
            double ConsommationTot=0;
            double ProductionTot=0;

            foreach(DistributionNode distributionNode in liste_noeud_Distribution){
                foreach(Lines lignesV in distributionNode.GetDistribution()){
                    ConsommationTot += (lignesV.GetTo().Production);

                }
            }
                
            foreach(ConcentrationNode concentrationNode in liste_noeud_Concentration){
                foreach(Lines lignesD in concentrationNode.GetReception()){
                    if(lignesD.GetFrom().Production>lignesD.Puissance_Max){
                        ProductionTot += lignesD.Puissance_Max;
                    }
                    else{
                        ProductionTot += (lignesD.GetFrom().Production);
                    }  
                }
            }

            if (ProductionTot<ConsommationTot)
            {
                Console.WriteLine("\n \n" + "/! ALERTE /! La consommation surpasse la production, il manque {0}W",(ConsommationTot-ProductionTot));
                Console.WriteLine("\n");
                // crée valeur global erreur qui récupère les proplèmes trouvé

                foreach(ConcentrationNode noeuds in liste_noeud_Concentration)
                {
                    foreach(Lines lignes in noeuds.GetReception())
                    {
                        if (lignes.GetFrom() is CentraleType){

                            if (lignes.GetId() == noeuds.GetReception()[0].GetId()){
                                cout_initial = Europe.getPrix_Achat();
                            }
                            if (lignes.GetFrom().Cout < cout_initial){
                                if(lignes.GetFrom().Production+(ConsommationTot-ProductionTot)<=lignes.Puissance_Max){
                                    cout_initial = lignes.GetFrom().Cout;
                                    Central_reference = lignes.GetFrom();
                                }
                            }
                        }
                    }
                
                    if (cout_initial == Europe.getPrix_Achat()){
                        foreach(Lines ligne in noeuds.GetDistribution()){
                            if(ligne.GetTo() is DistributionNode){
                                ligne.GetTo().addProduction((ConsommationTot-ProductionTot));
                                Program.Alerte += ("\n" + (ConsommationTot-ProductionTot) + " ont été achetés");
                            }   
                        }
                    }
                    else{
                        Central_reference.addProduction((ConsommationTot-ProductionTot));
                    }        
                }                 
            }
                
            else if (ProductionTot>ConsommationTot)
            {
                Console.WriteLine("\n \n" + "/! ALERTE /! La production surpasse la consommation, il y a {0}W en plus", (ProductionTot-ConsommationTot));
                Console.WriteLine("\n");

                foreach(ConcentrationNode noeuds in liste_noeud_Concentration)
                {
                    foreach(Lines lignes in noeuds.GetReception())
                    {   
                        if (lignes.GetFrom() is CentraleType){

                            if (lignes.GetId() == noeuds.GetReception()[0].GetId()){
                                cout_initial = Europe.getPrix_Vente();
                                        
                            }
                            if ((lignes.GetFrom().Cout*(ProductionTot-ConsommationTot)) > (cout_initial*(ProductionTot-ConsommationTot))){
                                if(lignes.GetFrom().Production-(ProductionTot-ConsommationTot)>=0){
                                    cout_initial = lignes.GetFrom().Cout;
                                    Central_reference = lignes.GetFrom();
                                }
                            }
                        }
                    }
                
                    if (cout_initial == Europe.getPrix_Vente()){
                        noeuds.substractProduction((ProductionTot-ConsommationTot));
                        Program.Alerte += ("\n" + (ProductionTot-ConsommationTot) + " ont été vendus");
                    }
                    else{
                        Central_reference.substractProduction((ProductionTot-ConsommationTot));
                    } 
                } 
            }
            
            //maj
            foreach(Node noeud in graphique.getList())
            {
                if (noeud is ConcentrationNode)
                {
                    noeud.Production = 0;
                    foreach(Lines lignes in noeud.GetReception())
                    {
                        lignes.validate();
                    }
                }
                else if (noeud is DistributionNode)
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
