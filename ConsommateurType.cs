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
        public void addConsommation(int montant)
        {
            this.Production += montant;
        }
        public void substractConsommation(int montant)
        {
            this.Production -= montant;
        }

        public virtual double getConsommation()
		{
			return this.Production;
		}
    }
}