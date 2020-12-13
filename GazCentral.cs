using System;
namespace PROJET
{
    public class GazCentral : CentraleType
    {
        public GazCentral(string id, int production) : base(id)
        {
            this.id = id;
            Production = production;
			Production_Energy = new double[2]{0.8, 0.5 };
        }
        public override string getid()
		{
			return id;
		}
		public override double getProduction()
		{
			return Production;
		}
    }
}
