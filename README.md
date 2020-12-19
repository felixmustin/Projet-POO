# Simulateur de Réseau Electrique
Bienvenue sur notre plateforme de simulation d'un réqeau électrique.


## INTRODUCTION




## UTILISATION

**Création noeud**
Producteur
`GazCentral Gaz = new GazCentral("Centrale à Gaz", 1000, 25, 222);`
*Paramètres : id, production W/h, CO2/W, cout/W*

Consommateur
`VilleCons Bruxelles = new VilleCons("Bruxelles", 5000);`
*Paramètres : id, consommation W/h*

Batterie
`Batterie batterie_1 = new Batterie("Batterie de stockage", 0);`
*Paramètres : id, production W/h=0*

Météo
`Meteo brabant = new Meteo(0.8, 0.1, 28);`
*Paramètres : coefficient force du vent, coefficient d'ensoleillement, température*

Achat
`Achat achat1 = new Achat("Achat", 0);`
*Paramètres : id, production W/h=0*


**Ajout noeud**
`graph.CreateNode(Gaz);`


**Création ligne**
`Lines ligne1 = new Lines(Gaz, Concentration1, 1, 5000);`
*Paramètres : noeud de départ, noeud d'arrivée, id, puissance maximum*


**Ajout ligne**
`Gaz.AddDistribution(ligne1);`


**Création listes**
`var liste_producteur1 = new List<CentraleType>(){Eolienne, Gaz};`
Les listes permettent d'importer les différents élements vers les classes de controle et d'affichage


**Création tableau**
`Tableau tableau = new Tableau(liste_producteur1, liste_consommateur1, liste_batteries1, liste_achat1);`
Le tableau est l'affichage recapitulatif du réseau et ses différents noeuds


**Création centre de controle**
`CentreControle Nasa = new CentreControle(liste_distribution1, liste_concentration1, liste_achat1);`
Le centre de controle s'assure que le réseau soit fonctionnel et l'ajuste en fonction des différentes modifications


**Affichage**
`graph.GetGraph();`
`tableau.show();`
Permet l'affichage du graph ainsi que du tableau


## MODIFICATIONS

En dessous du message : //Modifications sur le réseau

