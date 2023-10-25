namespace CozyBank_Importer.FromGererMesComptes
{
    internal class OperationModel
    {
        public string DateOperation { get; set; }
        public string DateValeur { get; set; }
        public string Type { get; set; }
        public string NumeroIdentification { get; set; }
        public string Tiers { get; set; }
        public string Categorie { get; set; }
        public string SousCategorie { get; set; }
        public string Libelle { get; set; }
        public decimal Montant { get; set; }
        public decimal Solde { get; set; }
        public bool Pointage { get; set; }

        public BankInformation BankInformation { get; set; }

    }
}
