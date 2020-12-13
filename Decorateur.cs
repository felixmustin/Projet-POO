using System;

namespace PROJET
{
    public class Grève: Decorateur
    {
        public Grève(CentraleType centrale, double impact, string id): base(centrale, impact, id)
        {
            this.Production = this.Production*impact;
        }
    }
    public class Vent:Decorateur
    {
        public Vent(CentraleType centrale, double impact, string id): base(centrale, impact, id)
        {
            this.Production= this.Production*impact;
        }
    }
}