using System;
namespace PROJET
{
    public class VilleCons : ConsommateurType
    {
        public VilleCons(string id, double consommation) : base(id, consommation)
        {
            this.id = id;
            this.Production = consommation;
        }
        public override double getConsommation()
		{
			return Production;
		}
    }
}
