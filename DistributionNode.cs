using System;
namespace PROJET
{
    public class DistributionNode : Node
    {

        public DistributionNode(string id, double consommation) : base (id)
        {
            this.id = id;
            this.Production = consommation;
        }
    }
}