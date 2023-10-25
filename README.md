# Convertisseur de CSV vers le format Cozy Banks

Ce projet a �t� r�alis� dans le cadre d'un export de donn�es depuis GererMesComptes pour un r�import vers Cozy Banks.

Seul le connecteur GererMesComptes existe actuellement, libre � vous de forker ou de faire une PR pour supporter d'autres exports.

Oui, le code est un peu en Franglais parce que voil� \o/

# Comment �a marche ?

C'est une moulinette en console assez basique.

1. Mettez vos exports csv dans un dossier Import (�a sort d'un c�t�, �a rentre de l'autre).
2. Cr�ez un dossier pour les Exports
3. Dans programs.cs, modifiez les variables csvImportPath et csvExportPath avec les paths vers ces r�pertoires
4. Modifiez le dictionnaire mappingFileAccount avec les informations bancaires correspondantes (dans le cas de GererMesComptes, ces donn�es ne sont pas dans le CSV)
5. Ex�cutez le programme, normalement vous devriez retrouver vos petits dans le dossier d'Export
6. Plus qu'� importer dans Cozy Banks!

# Pour aller plus loin

Si comme moi, vous avez cr�� des cat�gories custom, vous pouvez modifier le fichier FromGererMesComptes/Mapping.cs pour ajouter vos cat�gories avec les ids correspondants dans les dictionnaires de CozyBanks/Categories.cs
