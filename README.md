# Simulateur de Réseau Electrique
Bienvenue sur notre plateforme de simulation d'un réqeau électrique.


## INTRODUCTION




## UTILISATION

**Création noeud**
*Producteur*
`GazCentral Gaz = new GazCentral("Centrale à Gaz", 1000, 25, 222);`
            
*Consommateur*
`VilleCons Bruxelles = new VilleCons("Bruxelles", 5000);`

*Batterie*
`Batterie batterie_1 = new Batterie("Batterie de stockage", 0);`

*Météo*
`Meteo brabant = new Meteo(0.8, 0.1, 28);`

**Ajout noeud**
`graph.CreateNode(Gaz);`


**Création ligne**
`Lines ligne1 = new Lines(Gaz, Concentration1, 1, 5000);`

**Ajout ligne**
`Gaz.AddDistribution(ligne1);`


**Création listes**
`var liste_producteur1 = new List<CentraleType>(){Eolienne, Gaz};`


**Création tableau**
`Tableau tableau = new Tableau(liste_producteur1, liste_consommateur1, liste_batteries1);`


**Création centre de controle**
`CentreControle Nasa = new CentreControle(liste_distribution1, liste_concentration1);`


## MODIFICATION

En dessous du message : //Modifications sur le réseau