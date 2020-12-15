using System;
namespace PROJET
{
    public class SolarCentral : CentraleType
    {
        public SolarCentral(string id, double production, int Cout) : base(id)
        {
            this.id = id;
            this.Production = production;
            this.Cout = Cout;
        }
        public override double getProduction()
		{
			return Production;
		}
        public override int getCout()
        {
            return Cout;
        }

    }
}
