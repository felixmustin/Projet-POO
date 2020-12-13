using System;

namespace PROJET
{
    public class Marché
    {  
        int Prix_achat;
        int Prix_Vente;
        int Prix_Combustible;

        public Marché(int achat, int vente, int combustible)
        {
            achat = Prix_achat;
            vente = Prix_Vente;
            combustible = Prix_Combustible;
        }
    
        public int getPrix_Achat()
        {
            return Prix_achat;
        }
        public int getPrix_Vente()
        {
            return Prix_Vente;
        }
        public int getPrix_Combustible()
        {
            return Prix_Combustible;
        }
    }
}