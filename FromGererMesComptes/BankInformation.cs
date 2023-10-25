namespace CozyBank_Importer.FromGererMesComptes
{
    internal class BankInformation
    {
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string CustomAccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountOriginalNumber { get; set; }
        public string AccountType { get; set; }
        public string UniqueID { get; set; }

        public BankInformation(string bankName, string accountName, string customAccountName,
                                string accountNumber, string accountOriginalNumber, string accountType)
        {
            BankName = bankName;
            AccountName = accountName;
            CustomAccountName = customAccountName;
            AccountNumber = accountNumber;
            AccountOriginalNumber = accountOriginalNumber;
            AccountType = accountType;
        }

        public BankInformation()
        {

        }
    }
}
