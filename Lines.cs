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
                        }
                    }
                    else
                    {
                        throw new Exception("Attention surchage sur la ligne " + this.GetId() + " veuillez baisser la production ou rajouter une batterie");
                    }
                }
                if (to.GetDistribution().Count ==0){
                    throw new Exception("Attention surchage sur la ligne " + this.GetId() + " veuillez baisser la production ou augmenter la demande");
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
                else if (to is ConcentrationNode || to is DistributionNode)
                {
                    to.Production += from.Production;               
                }
                else if (from is DistributionNode)
                {
                    from.Production -= to.Production;
                }
            } 
        }
    }
}
