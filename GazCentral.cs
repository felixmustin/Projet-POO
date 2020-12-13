using System;
namespace PROJET
{
    public class GazCentral : CentraleType
    {
        public GazCentral(string id, double production, int Co2, int Cout) : base(id)
        {
            this.id = id;
            this.Production = production;
			Production_Energy = new double[2]{0.8, 0.5 };
            this.Co2_production = Co2;
            this.Cout_Produit = Cout;
        }
        
		public override double getProduction()
		{
			return Production;
		}

        public override int getCO2()
        {
            return Co2_production;
        }
        public override int getCout()
        {
            return Cout_Produit;
        }
    }
}
