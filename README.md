# Simulateur de Réseau Electrique
Bienvenue sur notre plateforme de simulation d'un réseau électrique.


## INTRODUCTION
Notre plateforme simule un réseau sur un laps de temps donné, durant ce laps de temps, il est possible de faire autant de modifications que souhaité dans le réseau.
Le réseau s'auto-régule selon les différentes modifications apportées. 
Ce simulateur permet donc d'observer les différents états du réseau selon différents critères.



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


**Lancement simulation et modification sur le réseau**
Pour faire des modifications sur le réseau, il suffit de rajouter un bloc comme ci dessous, et d'y mettre la commande de modification souhaitée pour le réseau

`Alerte="";`
`Gaz.addProduction(5000);`
`Nasa.ControleProduction(graph, tableau);`
`graph.GetGraph();`
`Console.WriteLine("\n");`
`tableau.show();`



## MODIFICATIONS
Il est également possible de rajouter des éléments au code si l'on souhaite.
Pour rajouter d'autres types de consommateurs ou de centrales de production, il suffit simplement de rajouter un fichier à son nom, héritant de la classe `CentraleType` pour une centrale ou `ConsommateurType`pour un consommateur.