using System.Globalization;
using System.Text;

namespace CozyBank_Importer.CozyBanks
{
    internal class CSVOperationModel
    {
        public DateTime Date { get; set; }
        public DateTime RealisationDate { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Label { get; set; }
        public string OriginalBankLabel { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public bool Expected { get; set; }
        public DateTime ExpectedDebitDate { get; set; }
        public string ReimbursementStatus { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string CustomAccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountOriginalNumber { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal AccountComingBalance { get; set; }
        public string AccountIBAN { get; set; }
        public bool AccountVendorDeleted { get; set; }
        public bool Recurrent { get; set; }
        public string RecurrenceName { get; set; }
        public string RecurrenceStatus { get; set; }
        public string RecurrenceFrequency { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public string UniqueID { get; set; }
        public string UniqueAccountID { get; set; }
        public decimal LoanAmount { get; set; }
        public double InterestRate { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public decimal NextPaymentAmount { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime RepaymentDate { get; set; }

        public static string GenerateCsv(IEnumerable<CSVOperationModel> dataList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Date;Realisation date;Assigned date;Label;Original bank label;Category name;Amount;Currency;Type;Expected?;Expected debit date;Reimbursement status;Bank name;Account name;Custom account name;Account number;Account originalNumber;Account type;Account balance;Account coming balance;Account IBAN;Account vendorDeleted;Recurrent?;Recurrence name;Recurrence status;Recurrence frequency;Tag 1;Tag 2;Tag 3;Tag 4;Tag 5;Unique ID;Unique account ID;Loan amount;Interest rate;Next payment date;Next payment amount;Subscription date;Repayment date");

            // Écrire les données
            foreach (var data in dataList)
            {
                sb.AppendLine($"\"{data.Date:yyyy-MM-dd}\";" +
                              $"\"{data.RealisationDate:yyyy-MM-dd}\";" +
                              $"\"\";" +
                              $"\"{data.Label.ToUpper()}\";" +
                              $"\"{data.OriginalBankLabel.ToUpper()}\";" +
                              $"\"{data.CategoryName}\";" +
                              $"\"{data.Amount.ToString("0.00", CultureInfo.InvariantCulture)}\";" +
                              $"\"{data.Currency}\";" +
                              $"\"\";" +
                              //$"\"{data.Type}\";" +
                              $"\"{(data.Expected ? "yes" : "no")}\";" +
                              $"\"{data.ExpectedDebitDate:yyyy-MM-dd}\";" +
                              $"\"{data.ReimbursementStatus}\";" +
                              $"\"{data.BankName}\";" +
                              $"\"{data.AccountName}\";" +
                              $"\"{data.CustomAccountName}\";" +
                              $"\"{data.AccountNumber}\";" +
                              $"\"{data.AccountOriginalNumber}\";" +
                              $"\"{data.AccountType}\";" +
                              $"\"{data.AccountBalance.ToString("0.00", CultureInfo.InvariantCulture)}\";" +
                              $"\"{data.AccountComingBalance.ToString("0.00", CultureInfo.InvariantCulture)}\";" +
                              $"\"{data.AccountIBAN}\";" +
                              $"\"{data.AccountVendorDeleted}\";" +
                              $"\"\";" +
                              //$"\"{data.Recurrent}\";" +
                              $"\"{data.RecurrenceName}\";" +
                              $"\"{data.RecurrenceStatus}\";" +
                              $"\"{data.RecurrenceFrequency}\";" +
                              $"\"{data.Tag1}\";\"{data.Tag2}\";\"{data.Tag3}\";\"{data.Tag4}\";\"{data.Tag5}\";" +
                              $"\"{data.UniqueID}\";" +
                              $"\"{data.UniqueAccountID}\";" +
                              $"\"{PrepareValue(data.LoanAmount)}\";" +
                              $"\"{PrepareValue(data.InterestRate)}\";" +
                              $"\"{PrepareValue(data.NextPaymentDate)}\";" +
                              $"\"{PrepareValue(data.NextPaymentAmount)}\";" +
                              $"\"{PrepareValue(data.SubscriptionDate)}\";" +
                              $"\"{PrepareValue(data.RepaymentDate)}\"");
            }
            return sb.ToString();
        }

        private static string PrepareValue(DateTime item)
        {
            return item != DateTime.MinValue ? item.ToString("yyyy-MM-dd") : "";
        }

        private static string PrepareValue(decimal item)
        {
            return item != Decimal.Zero ? item.ToString("0.00", CultureInfo.InvariantCulture) : "";
        }

        private static string PrepareValue(double item)
        {
            return item != 0 ? item.ToString("0.00", CultureInfo.InvariantCulture) : "";
        }
    }
}
