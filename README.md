# Convertisseur de CSV vers le format Cozy Banks

Ce projet a été réalisé dans le cadre d'un export de données depuis GererMesComptes pour un réimport vers Cozy Banks.

Seul le connecteur GererMesComptes existe actuellement, libre à vous de forker ou de faire une PR pour supporter d'autres exports.

Oui, le code est un peu en Franglais parce que voilà \o/

# Comment ça marche ?

C'est une moulinette en console assez basique.

1. Mettez vos exports csv dans un dossier Import (ça sort d'un côté, ça rentre de l'autre).
2. Créez un dossier pour les Exports
3. Dans programs.cs, modifiez les variables csvImportPath et csvExportPath avec les paths vers ces répertoires
4. Modifiez le dictionnaire mappingFileAccount avec les informations bancaires correspondantes (dans le cas de GererMesComptes, ces données ne sont pas dans le CSV)
5. Exécutez le programme, normalement vous devriez retrouver vos petits dans le dossier d'Export
6. Plus qu'à importer dans Cozy Banks!

# Pour aller plus loin

Si comme moi, vous avez créé des catégories custom, vous pouvez modifier le fichier FromGererMesComptes/Mapping.cs pour ajouter vos catégories avec les ids correspondants dans les dictionnaires de CozyBanks/Categories.cs
