using System;
namespace PROJET
{
    public class VilleCons : ConsommateurType
    {
        public VilleCons(string id, int consommation) : base(id, consommation)
        {
            this.id = id;
            this.consommation = consommation;
        }
    }
}
