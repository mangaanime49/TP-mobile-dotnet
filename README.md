# TP .NET — Entity Framework Core, ASP.NET Core et .NET MAUI (POOAspEntity)

Solution créée pour le TP :
- **P5AspEntity** : ASP.NET Core Minimal API + Entity Framework Core + SQLite (module *Utiliser une base de données avec une API minimale, Entity Framework Core et ASP.NET Core*).
- **P8Maui** : Application .NET MAUI (parcours *Créer des applications mobiles et de bureau avec MAUI .NET*).

## Structure

- `POOAspEntity.slnx` : solution
- `P5AspEntity/` : projet API web minimal (EF Core, SQLite)
- `P8Maui/` : projet .NET MAUI (template multiplateforme)

## 1) P5AspEntity — Minimal API + EF Core + SQLite

### Fonctionnalités implémentées
- Modèle `Pizza` (`Id`, `Name`, `Description`)
- Contexte EF Core `PizzaDb` (`DbSet<Pizza>`)
- Base SQLite `Pizzas.db` (créée au démarrage via `EnsureCreated`) avec données de départ
- Endpoints CRUD :
  - `GET /pizzas` : liste des pizzas
  - `GET /pizzas/{id}` : détail
  - `POST /pizzas` : création
  - `PUT /pizzas/{id}` : mise à jour
  - `DELETE /pizzas/{id}` : suppression
- Swagger/OpenAPI en environnement de développement

### Prérequis
- .NET SDK (10/11 compatible)

### Exécution
```bash
cd P5AspEntity
dotnet run
```
Puis ouvrir : `http://localhost:<port>/swagger` ou tester `GET /pizzas`.

### Test rapide (exemple)
```bash
curl http://localhost:<port>/pizzas
```

## 2) P8Maui — Application .NET MAUI

Projet scaffoldé avec le template officiel `dotnet new maui` (structure multiplateforme Android/iOS/MacCatalyst/Windows, pages XAML, `MauiProgram`, ressources).

### Prérequis pour compiler/exécuter
- Workload .NET MAUI installé :
  ```bash
  dotnet workload install maui
  ```
- Outillage plateforme selon la cible (Android SDK, Xcode sur macOS pour iOS/MacCatalyst, etc.).

> Remarque : sur cet environnement, la charge de travail MAUI n’est pas installée, donc la compilation complète du projet MAUI peut échouer sans installation préalable du workload. Le code source du projet est fourni dans `P8Maui/`.

## Remarques TP (rendu)
- **Compte Microsoft / capture d’écran** (photo, titre de la formation, nombre de points obtenus sur Microsoft Learn) : élément personnel à réaliser avec votre propre compte sur les modules/parcours indiqués.
- **Lien vers le code source** : ce dossier `POOAspEntity/` contient le code source de la solution et des deux projets demandés.

## Liens des formations (TP)
- P5 : https://learn.microsoft.com/fr-fr/training/modules/build-web-api-minimal-database/
- P8 : https://learn.microsoft.com/fr-fr/training/paths/build-apps-with-dotnet-maui/
