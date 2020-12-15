using System;
namespace PROJET
{
    public class NuclearCentral : CentraleType
    {
        public NuclearCentral(string id, int production, int Cout) : base(id)
        {
            this.id = id;
            this.Production = production;
			Production_Energy = new double[2]{0.8, 0.5 };
            this.Cout= Cout;
        }
		public override double getProduction()
		{
			return Production;
		}
    }
}
