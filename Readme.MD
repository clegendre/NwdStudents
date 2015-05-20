# TD NwdMusik


> Réaliser une application MVC qui permet de gérer sa collection d’album de musique.

## Fonctionnalités

Il y aura une partie publique de consultation de la musique et une partie privée pour l’administration.
La partie Publiques de l’application sera majoritairement en AJAX, 
La partie BackOffice sera composé principalement de formulaire, scaffolding, validation, sont de la partie.

Il y a deux contextes vraiment délimités : un pour la partie *Front* et un pour la partie *Back*.

### Front
Le Front de l’application possède les fonctionnalités suivantes :

*	Consulter le catalogue de musique en ligne
*	Lire une musique sélectionnée
Créer son compte sur le site pour pouvoir :
*	Créer des playlist
*	Ajouter des musiques à ses playlists
*	Gérer ses playlists

### Back
Le BackOffice de l’application possède les fonctionnalités suivantes :

*	Création de nouveaux albums
*	Modification des albums existants
*	Ajouts de nouvelles musiques


## Backoffice

La partie privée est une section restreinte à un seul utilisateur uniquement qui s'appelle “SuperAdmin”. Son url est la suivante : [http://localhost/Admin/](http://localhost/Admin/)

La liste des albums se trouve sur la page [http://localhost/Admin/Album/List](http://localhost/Admin/Album/List).
Cette liste affiche le nom de l’album et deux actions possible : **éditer**, **supprimer**.

Au-dessus de la liste, un lien **créer**, qui envoie sur la page [http://localhost/Admin/Album/Create](http://localhost/Admin/Album/Create) permet de saisir un nouvel album.

> Pour des raisons de simplicité les choix ci-dessous sont effectués

* il n’y a pas de gestion particulière des artistes. Uniquement son nom sera demandé lors de la création. A chaque création d’album, un nouvel artiste est recréé dans la base de données, même si un artiste déjà saisie précédemment possède le même nom.

*	Le formulaire d’édition ainsi que le formulaire de création seront le même

###Détail du formulaire de création / édition :

Les champs obligatoires sont : 

*	Titre de l’album
*	La durée
*	Année de sortie
*	Genre de musique
*	L’image de la pochette
*	L’artiste principal

L’ajout des pistes de musiques se fait de manière dynamique :

*	un bouton “ajouter” affiche un nouveau formulaire à chaque clic. 
Les champs obligatoires d’une piste de musique sont
*	Titre de la musique
*	L’url du fichier
*	La durée de la musique

Le nom d’un album est unique, il faut donc que le formulaire vérifie dynamiquement (directement lors de la saisie) l’existence ou non d’un album dans la base de données.

Enfin, un bouton **Créer** soumet l’intégralité du formulaire (album et ses musiques).

> Nous éviterons de faire un formulaire Ajax, car il y a de l’envoi de fichiers. Pensez-donc au content-type du formulaire : multipart/form-data.

## Front Office - Partie Publique

La partie publique dispose d’une page de catalogue qui affiche l’intégralité des albums dans une liste de vignettes (chacune reprenant l’image de couverture de son album)
Ces vignettes sont cliquables, et amènent vers une page de consultation de l’album.

La page de consultation reprend les informations de l’album (titre/artiste/cover) ainsi que toutes les pistes musicales.
Sur cette page, on peut écouter la musique des pistes audios. L’intégration d’un lecteur audio est donc envisagé soit par pistes / soit globalement pour l’album.

Pour des questions de SEO

*	L’url de la page de consultation des albums est : **http://localhost/music/albums/catalog/**
*	L’url de la page de consultation d’un album est le suivant : **http://localhost/music/album/<AlbumID>**
*	La page de consultation d’un album contient des métas donnés (<meta>) qui décrivent l’album 
*	Le contenu de l’attribut “content” de la balise meta (<meta name=”description” content=”” />) contient tous les titres des musiques concaténés et séparés par une virgule.
*	Le contenu de la balise <title> reprendra le titre de l’album
*	Dans le cas où l’utilisateur consulte un album qui n’existe pas, il doit être redirigé vers une page 404 spécifique au catalogue et qui indique que l’album demandé n’existe plus.


## Pour aller plus loin : les Playlists

A côté de chaque pistes de l’album consulté, ou à coté directement de l’album, un bouton “Ajouter à ma playlist” est disponible, et permet d’ajouter le morceau ou tous les morceaux de l’album dans une playlist.

Pour que le système soit souple, une petite popup apparait à chaque clic sur le bouton. Cette popup liste les playlists disponibles et/ou un formulaire pour créer une Playlist. (Pour créer une playlist, seul son nom suffit, mais attention, le nom des playlists doit être unique par utilisateur). Il est de bon gout que tout se fasse en Ajax.... 

> Consulter l’interface *IPlaylistManagement* pour voir les méthodes disponibles pour gérer les playlists dans le système.

Enfin, on souhaite également afficher toutes les playlists que l’utilisateur actuellement connecté dispose, et ce, sur toutes les pages du site. Par exemple un widget en colonne de droite.

 
Guidelines
===

*	Création du site ASP.Net MVC 5
*	Utiliser le template MVC avec authentification
*	Mise en place de l’architecture du site
*	Connexion à la BDD fournie
*	Implémenter les interfaces de services fournies
*	Utilisation des sources directement dans le projet
*	Lancer le test unitaire pour vérifier que la base de données fonctionne bien
*	Mise en place de l’architecture d’authentification : Comprendre le sample fourni avec MVC
*	Tester que la création d’utilisateur / l’authentification fonctionne bien
*	Création de la zone Admin
*	Créer la page de Création d’Album
*	Pour des raisons de simplicité, nous pouvons utiliser les entités EF en tant que ViewModel même s'il est préférable de faire des ViewModel dédiés
*	Décrire, en commentaire dans le code du contrôlleur, les limitations que vous rencontrerez lors de l’utilisation d’un DomainModel en tant que ViewModel
*	Pour l’upload de fichier, créer un éditeur spécifique (qui se nommera File par exemple)
*	Le nom de l’album est repris en tant que Dossier sur le disque. Il faut donc que son nom ne contienne PAS de caractères invalides pour le système de fichier
*	Il ne peut pas y avoir deux albums avec le même nom. Penser à faire une validation ajax qui vérifie l’existence d’un Album avec le nom saisie.
*	Pour la page de listes des Albums dans la zone Admin, rajouter une méthode ICollection<Album> GetAllAlbums() sur la classe AlbumRepository.
