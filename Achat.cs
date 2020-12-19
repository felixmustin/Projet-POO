using System;
namespace PROJET
{
    public class Achat : Node
    {
        public Achat(string id, double production) : base(id)
        {
            this.id = id;
            this.Production = production;
        }
        
    }
}
