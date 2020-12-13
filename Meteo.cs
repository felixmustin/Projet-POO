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
        }

        public void Ensoleillement(CentraleType central)
        {
            central.Production = central.Production*ensoleillement;
        }

        public void Temperature(CentraleType central)
        {
            central.Production = central.Production*temperature;
        }

    }
}