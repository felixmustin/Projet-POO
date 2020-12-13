using System;
namespace PROJET
{
    public class DistributionNode : Node
    {
        public double consommation;
        public DistributionNode(string id, double consommation) : base (id)
        {
            this.id = id;
            this.consommation = consommation;
        }


    }
}