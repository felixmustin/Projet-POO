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
        public override void addConsommation(double montant)
        {
            Production += montant;
        }
        public override void substractConsommation(double montant)
        {
            Production -= montant;
        }
    }
}
