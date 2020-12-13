using System;
using System.Collections.Generic;


namespace PROJET
{
    public abstract class CentraleType : Node
    {
        public double Production;
		public double[] Production_Energy;
		public int Co2_production;
        public CentraleType(string id) : base(id)
        {
            this.id = id;
        }
        public virtual string getid()
		{
			return id;
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
	}
}

