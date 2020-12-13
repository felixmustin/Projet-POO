using System;
namespace PROJET
{
    public class Lines
    {
        private Node from;
        private Node to;
        private int id;
        int Puissance_Max;

        public Lines(Node f, Node t, int id, int Puissance)
        {
            validate(f, t);
            this.from = f;
            this.to = t;
            this.id = id;
            this.Puissance_Max = Puissance;
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
                t.Production += f.Production;
            }
            else if (t is ConsommateurType)
            {
                f.Production -= t.Production;
            }
        } 
    }
}