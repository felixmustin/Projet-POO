using System;
namespace PROJET
{
    public class ConcentrationNode : Node
    {
        public ConcentrationNode(string id, double production) : base (id)
        {
            this.id = id;
            this.Production = production;
        }
    }
}