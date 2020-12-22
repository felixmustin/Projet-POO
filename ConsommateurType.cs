using System;

namespace PROJET
{
    public class ConsommateurType : Node
    {
        public double consommation;

        public ConsommateurType(string id, double consommation) : base(id)
        {
            this.id = id;
            this.Production = consommation;
        }
        public virtual void addConsommation(double montant)
        {
            Production += montant;
            Program.Alerte +=("\n" + "Ajout de " +montant+ "W de consommation à " + this.GetNodeId());
        }
        public virtual void substractConsommation(double montant)
        {
            Production -= montant;
            if(this.Production ==0){
                Program.Alerte +=("\n" + "Arret de consommation de " + this.GetNodeId());
            }
            else{
                Program.Alerte +=("\n" + "Retrait de " +montant+ "W de consommation à " + this.GetNodeId());
            }
        }

        public virtual double getConsommation()
		{
			return this.Production;
		}
    }
}