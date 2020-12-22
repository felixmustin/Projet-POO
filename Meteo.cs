using System;
namespace PROJET
{
    public class Meteo
    {
        public double ensoleillement;
        public double forceVent;
        public int temperature;
        public Meteo(double forceVent, double ensoleillement, int temperature)
        {
            this.forceVent = forceVent;
            this.ensoleillement = ensoleillement;
            this.temperature = temperature;
        }
        public void Vent(CentraleType central)
        {
            central.Production = central.Production*forceVent;
            Program.Alerte +=("\n" + "Vent de " +forceVent+ " modifiant la production de " + central.GetNodeId());
        }

        public void Ensoleillement(CentraleType central)
        {
            central.Production = central.Production*ensoleillement;
            Program.Alerte +=("\n" + "Ensoleillement de " +ensoleillement+ " modifiant la production de " + central.GetNodeId());
        }

        public void Temperature(CentraleType central)
        {
            central.Production = central.Production*temperature;
        }
    }
}