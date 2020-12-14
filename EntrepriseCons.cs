using System;
namespace PROJET
{
    public class EntrepriseCons : ConsommateurType
    {
        public EntrepriseCons(string id, double consomation) : base(id, consomation)
        {
            this.id = id;
            this.Production = consomation;
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
