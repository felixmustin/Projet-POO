using System;
namespace PROJET
{
    public class EntrepriseCons : ConsommateurType
    {
        public EntrepriseCons(string id, int consomation) : base(id, consomation)
        {
            this.id = id;
            this.consommation = consomation;
        }
    }
}
