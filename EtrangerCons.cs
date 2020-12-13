using System;
namespace PROJET
{
    public class EtrangerCons : ConsommateurType
    {
        public EtrangerCons(string id, int consomation) : base(id, consomation)
        {
            this.id = id;
            this.consommation = consomation;
        }
    }
}