using System;
using System.Collections.Generic;


namespace PROJET
{
    public abstract class CentraleType : Node
    {

		public double[] Production_Energy;

		public int Co2_production;

        public CentraleType(string id) : base(id)
        {
            this.id = id;
        }

		public override void addProduction(double montant)
        {
            Production += montant;
        }

		public override void substractProduction(double montant)
        {
            Production -= montant;
        }

		public virtual double getProduction()
		{
			return Production;
		}
		
		public virtual int getCO2()
		{
			return Co2_production;
		}
		
		public virtual double[] getProduction_Energy()
		{
			return Production_Energy;
		}
		public virtual int getCout()
		{
			return Cout;
		}
	}
}

