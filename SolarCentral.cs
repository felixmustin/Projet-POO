using System;
namespace PROJET
{
    public class SolarCentral : CentraleType
    {
        public SolarCentral(string id, double production) : base(id)
        {
            this.id = id;
            this.Production = production;
        }
        public override double getProduction()
		{
			return Production;
		}

    }
}
