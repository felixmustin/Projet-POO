using System;

namespace PROJET
{
    public class ConsommateurType : Node
    {

        public double consommation;

        public ConsommateurType(string id, double consommation) : base(id)
        {
            this.id = id;
            this.Production = consommation;
        }
        public virtual void addConsommation(double montant)
        {
            Production += montant;
        }
        public virtual void substractConsommation(double montant)
        {
            Production -= montant;
        }

        public virtual double getConsommation()
		{
			return this.Production;
		}
    }
}