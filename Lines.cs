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
            validate(f, t);
            this.from = f;
            this.to = t;
            this.id = id;
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

        public void validate(Node f, Node t)
        {
            if (f is ConsommateurType)
            {
                throw new Exception("Un consommateur ne peut pas envoyer d'énergie");
            }
            else if (t is CentraleType)
            {
                throw new Exception("Une centrale ne peut pas recevoir d'énergie");
            }
            else if (t is ConcentrationNode || t is DistributionNode)
            {
                if (f.Production > Puissance_Max)
                {
                    foreach(Lines lignes in t.GetDistribution()){
                        if(lignes.GetTo() is Batterie)
                        {
                            t.Production += Puissance_Max;
                            lignes.GetTo().Production = (f.Production-Puissance_Max);
                        }
                        else
                        {
                            Console.WriteLine("Attention surchage sur la ligne {0}, veuillez baisser la production ou rajouter une batterie", lignes.GetId());
                        }
                    }
                    if(t.GetDistribution().Count == 0){
                        throw new Exception("Surcharge sur la ligne de tranfert");
                    }
                    
                }
                else{
                    t.Production += f.Production;
                }
            }
            else if (t is ConsommateurType)
            {
                f.Production -= t.Production;
            }
        }
        public void Maj ()
        {
            if (to is ConcentrationNode)
            {
                to.Production = 0;
                foreach (Lines ligne in to.GetReception())
                {
                    if(ligne.GetFrom().Production > this.Puissance_Max)
                    {
                        to.Production += this.Puissance_Max;
                    }
                    else{to.Production += ligne.GetFrom().Production;}
                }
            }

            if (to is DistributionNode)
            {
                to.Production=0;
                foreach (Lines ligne in to.GetReception())
                {
                    to.Production += ligne.GetFrom().Production;
                }
            }

            else if (to is Batterie)
            {
                to.Production=0;
                foreach (Lines ligne in this.GetFrom().GetReception())
                {
                    to.Production += (ligne.GetFrom().Production - ligne.Puissance_Max);
                }
            }

            else if (from is DistributionNode)
            {
                from.Production -= to.Production;
            }
        }
    }
}
