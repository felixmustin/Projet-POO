using System;
namespace PROJET
{
    public class EtrangerCons : ConsommateurType
    {
        public EtrangerCons(string id, double consomation) : base(id, consomation)
        {
            this.id = id;
            this.Production = consomation;
        }
    }
}