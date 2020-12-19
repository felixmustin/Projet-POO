using System;
namespace PROJET
{
    public class Lines
    {
        private Node from;
        private Node to;
        private int id;
        public int Puissance_Max;
        double mise_aniveau;

        public Lines(Node f, Node t, int id, int Puissance)
        {
            this.Puissance_Max = Puissance;
            this.from = f;
            this.to = t;
            this.id = id;
            validate();
        }

        public int GetId()
        {
            return this.id;
        }

        public Node GetFrom()
        {
            return this.from;
        }
        public Node GetTo()
        {
            return this.to;
        }

        public string GetIdOfFromNode()
        {
            return this.from.GetNodeId();
        }

        public string GetIdOfToNode()
        {
            return this.to.GetNodeId();
        }

        public void validate()
        {
            if (from.Production > Puissance_Max)
            {
                foreach(Lines lignes in to.GetDistribution()){
                    if(lignes.GetTo() is Batterie)
                    {
                        to.Production += Puissance_Max;
                        if (from.Production-Puissance_Max > 0){
                            lignes.GetTo().Production = (from.Production-Puissance_Max);
                            from.Production -= from.Production-Puissance_Max;
                        }
                    }
                }

            }
            else if (from.Production < Puissance_Max)
            {
                if (from is ConsommateurType)
                {
                    throw new Exception("Un consommateur ne peut pas envoyer d'énergie");
                }
                else if (to is CentraleType)
                {
                    throw new Exception("Une centrale ne peut pas recevoir d'énergie");
                }
                else if (to is ConcentrationNode)
                {
                    to.Production += from.Production;               
                }
                else if(to is DistributionNode)
                {
                    to.Production += from.Production;
                    from.Production =0;
                }
                else if (from is DistributionNode)
                {
                    from.Production -= to.Production;
                }
            } 
        }
    }
}

/*         public void mise_a_jour(Graph graphique, Tableau board)
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
                                if (ligne.GetFrom().Production-ligne.Puissance_Max > 0){
                                    if((ligne.GetFrom().Production - ligne.Puissance_Max)>0){
                                        lignesVers.GetTo().addProduction(ligne.GetFrom().Production - ligne.Puissance_Max);
                                    }
                                    else{
                                        lignesVers.GetTo().Production =0;
                                    }       
                                }  
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
            
        } */