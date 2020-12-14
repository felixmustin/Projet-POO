using System;

namespace PROJET
{
    public class Batterie : ConsommateurType
    {
         public Batterie(string id, double consomation) : base(id, consomation)
        {
            this.Production = consomation;
            this.id = id;
        }     
    }
}