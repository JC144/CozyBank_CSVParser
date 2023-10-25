namespace CozyBank_Importer.FromGererMesComptes
{
    internal class Mapping
    {
        internal static Dictionary<string, string> Categories = new Dictionary<string, string>()
        {
            { "Pension", "400460" },
            { "", "0" },
            { "Impôts & Taxes", "400500" },
            { "Retraits & Chq. & Vir.", "300" }, //Not exactly
            { "Banque & Assurance","0"},
            { "Santé", "400600" },
            { "Auto & Transport", "400200" },
            { "Habitation", "401000" },
            { "Abonnements & Factures","0"},
            { "Initialisation comptes", "0" },
            { "Achat & Shopping", "400112" },
            { "Vacances", "400800" },
            { "Hors budget", "600100" },
            { "Sorties", "400820" },
            { "Revenus", "200100" },
            { "Alimentation & Restaurant", "400810" },
            { "Autre", "0" },
            { "Bien être & Soins", "400190" },
            { "Vie quotidienne", "400100" },
            { "Notes de frais", "600140" },
            { "Hobby", "400760" },
            { "Loisir", "400700" },
            { "Animaux", "400140" },
        };



        internal static Dictionary<string, string> SubCategories = new Dictionary<string, string>()
        {
            {"Impôts & Taxes/Taxe d'habitation", "400540"},
            {"Retraits & Chq. & Vir./Chèque", "200"},
            {"Banque & Assurance/Frais bancaires", "400340"},
            {"Santé/Ostéopathe / Kiné", "400610"},
            {"Habitation/Bricolage / Travaux", "401050"},
            {"Achat & Shopping/High Tech", "400112"},
            {"Impôts & Taxes/Impôt sur les revenus", "400510"},
            {"Habitation/Électroménager", "401060"},
            {"Banque & Assurance/Assurance prêt", "401040"},//Not exactly
            {"Abonnements & Factures/Musique", "400300"},//Not exactly
            {"Banque & Assurance/Prêt", "600130"},
            {"Santé/Laboratoire", "400600"},
            {"Vacances/Dépense partagée", "400800"},
            {"Abonnements & Factures/Internet / Téléphone", "400150"},
            {"Retraits & Chq. & Vir./Virement", "100"},
            {"Banque & Assurance/Assurance vie", "600170"},
            {"Abonnements & Factures/Électricité", "401080"},
            {"Achat & Shopping/Cadeau", "400180"},
            {"Banque & Assurance/Epargne", "600170"},
            {"Achat & Shopping/Livres", "400112"},//Not exactly
            {"Santé/Sécurité Sociale", "400600"},
            {"Sorties/Cinéma", "400830"},
            {"Alimentation & Restaurant/Restaurant", "400810"},
            {"Habitation/Décorations / Accessoires", "401060"},
            {"Revenus/Salaire", "200100"},
            {"Habitation/Jardin", "401060"},
            {"Alimentation & Restaurant/Petit commerce", "400110"},//Not exactly
            {"Sorties/Sortie culturelle", "400830"},
            {"Bien être & Soins/Coiffeur", "400190"},//Not exactly
            {"Sorties/Voyage / Vacances", "400800"},
            {"Revenus/Primes","200180"},
            {"Habitation/Meubles", "401060"},
            {"Impôts & Taxes/Taxe foncière", "400540"},
            {"Habitation/Charges", "401030"},
            {"Alimentation & Restaurant/Supermarché / Épicerie", "400110"},
            {"Auto & Transport/Carburant", "400250"},
            {"Sorties/Restaurants", "400810"},
            {"Vie quotidienne/La Poste", "400310"},
            {"Santé/Pharmacie", "400610"},
            {"Santé/Ophtalmologiste","400610"},
            {"Retraits & Chq. & Vir./Retrait d'espèces", "300"},
            {"Auto & Transport/Billets train", "400200"},
            {"Sorties/Anniversaire", "400820"},
            {"Sorties/Bar / Club / ...", "400820"},
            {"Habitation/Loyer",  "401020"},
            {"Alimentation & Restaurant/Fast Food", "400810"},
            {"Auto & Transport/Location", "400220"},
            {"Auto & Transport/Transports en commun / Taxi", "400290"},
            {"Habitation/Assurance", "401040"},
            {"Achat & Shopping/Musique", "400750"},
            {"Sorties/Hôtel / Location", "400800"},
            {"Autre/Note de frais", "600140"},
            {"Banque & Assurance/Intérêts", "200130"},
            {"Auto & Transport/Assurance véhicule", "400230"},
            {"Abonnements & Factures/Journaux / Magazines", "400111"},
            {"Achat & Shopping/Contenu multimédia", "400112"},
            {"Notes de frais/Déplacement", "600140"},
            {"Notes de frais/Restaurant", "600140"},
            {"Sorties/Concert / Spectacle", "400830"},
            {"Auto & Transport/Pièces / Accessoires", "400240"},
            {"Sorties/Parc de loisirs", "400820"},
            {"Santé/Mutuelle", "400620"},
            {"Santé/Médecin", "400610"},
            {"Auto & Transport/Parking / Stationnement", "400270"},
            {"Auto & Transport/Entretien / Maintenance", "400240"},
            {"Abonnements & Factures/Eau", "401070"},
            {"Santé/Autres praticiens", "400610"},
            {"Banque & Assurance/Autre assurance", "401040"},
            {"Animaux/Vétérinaire", "400140"},
            {"Vie quotidienne/Tabac / Presse", "400111"},
            {"Vacances/Restaurants", "400800"}
        };

        internal static Dictionary<string, string> PaymentType = new Dictionary<string, string>()
        {
            {"Virement","transfer" },
            {"Carte Bancaire","debit card" },
            {"Prélèvement","direct debit" },
            {"Chèque","check" },
            {"Remise de chèque(s)","deposit" },
            {"DAB","cash" },
            {"Solde initial","none" },
            {"Frais de service","none" }
        };

        internal static CozyBanks.CSVOperationModel ConvertOperation(OperationModel operation)
        {
            CozyBanks.CSVOperationModel nOperation = new CozyBanks.CSVOperationModel();
            nOperation.Date = DateTime.Parse(operation.DateOperation);
            nOperation.RealisationDate = DateTime.Parse(operation.DateValeur);
            nOperation.AssignedDate = DateTime.Parse(operation.DateOperation);
            nOperation.ExpectedDebitDate = nOperation.RealisationDate.AddDays(10); //Random number to avoid a date before realisation
            nOperation.Label = operation.Libelle;
            nOperation.OriginalBankLabel = operation.Libelle;
            if (!String.IsNullOrEmpty(operation.SousCategorie))
            {
                nOperation.CategoryName = CozyBanks.Categories.Values[SubCategories[$"{operation.Categorie}/{operation.SousCategorie}"]];
            }
            else
            {
                nOperation.CategoryName = CozyBanks.Categories.Values[Categories[operation.Categorie]];
            }

            nOperation.Amount = operation.Montant;
            nOperation.Currency = "EUR";
            nOperation.Type = PaymentType[operation.Type];

            nOperation.BankName = operation.BankInformation.BankName;
            nOperation.AccountName = operation.BankInformation.AccountName;
            nOperation.CustomAccountName = operation.BankInformation.AccountName;
            nOperation.AccountNumber = operation.BankInformation.AccountNumber;
            nOperation.AccountOriginalNumber = operation.BankInformation.AccountOriginalNumber;
            nOperation.AccountType = operation.BankInformation.AccountType;
            nOperation.AccountBalance = operation.Solde;
            nOperation.UniqueID = operation.BankInformation.UniqueID;

            return nOperation;
        }


    }
}
