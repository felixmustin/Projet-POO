using System;

namespace PROJET
{
    public class Decorateur: CentraleType
    {
        CentraleType Central = null;
        public Decorateur(CentraleType centrale, double impact, string id): base(id)
        {
            this.id = id;
            centrale.Production *= impact;
        }
    }

}