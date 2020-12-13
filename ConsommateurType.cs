using System;

namespace PROJET
{
    public class ConsommateurType : Node
    {

        public double consommation;


        public ConsommateurType(string id, int consommation) : base(id)
        {
            this.id = id;
            this.consommation = consommation;
        }
        public void addConsommation(int montant)
        {
            consommation = consommation + montant;
        }
        public void substractConsommation(int montant)
        {
            consommation = consommation - montant;
        }

        public double total()
        {
            double total = consommation;
            return total;
        }
    }
}