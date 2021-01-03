using System;
namespace PROJET
{
    public class EolienCentral : CentraleType
    {
        public EolienCentral(string id, double production, int Co2, int Cout) : base(id)
        {
            this.id = id;
            this.Production = production;
			Production_Energy = new double[2]{0.8, 0.5 };
            this.Co2_production = Co2;
            this.Cout = Cout;
        }
        
    }
}
