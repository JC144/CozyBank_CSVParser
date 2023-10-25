using System.Globalization;

namespace CozyBank_Importer.FromGererMesComptes
{
    internal static class Parser
    {
        /// <summary>
        /// Transform a CSV as a string array into a list of operations
        /// </summary>
        /// <param name="lines">CSV as a string array</param>
        /// <param name="informations">Bank and account informations</param>
        /// <returns>List of operations</returns>
        public static List<OperationModel> ParseCsv(string[] lines, BankInformation informations = null)
        {
            List<OperationModel> csvData = new List<OperationModel>();

            string[] headerFields = lines[0].Split(';').Select(s => s.Trim('\"')).ToArray();
            for (int i = 1; i < lines.Length; i++)
            {
                string dataLine = lines[i];
                string[] dataFields = dataLine.Split(';').Select(s => s.Trim('\"')).ToArray();

                OperationModel csvRow = new OperationModel();
                csvRow.DateOperation = dataFields[Array.IndexOf(headerFields, "Date d'opération")];
                csvRow.DateValeur = dataFields[Array.IndexOf(headerFields, "Date de valeur")];
                csvRow.Type = dataFields[Array.IndexOf(headerFields, "Type")];
                csvRow.NumeroIdentification = dataFields[Array.IndexOf(headerFields, "Numéro d'identification")];
                csvRow.Tiers = dataFields[Array.IndexOf(headerFields, "Tiers")];
                csvRow.Categorie = dataFields[Array.IndexOf(headerFields, "Catégorie")];
                csvRow.SousCategorie = dataFields[Array.IndexOf(headerFields, "Sous-catégorie")];
                csvRow.Libelle = dataFields[Array.IndexOf(headerFields, "Libéllé")];
                csvRow.Montant = decimal.Parse(dataFields[Array.IndexOf(headerFields, "Montant")], CultureInfo.InvariantCulture);
                csvRow.Solde = decimal.Parse(dataFields[Array.IndexOf(headerFields, "Solde")], CultureInfo.InvariantCulture);
                csvRow.Pointage = dataFields[Array.IndexOf(headerFields, "Pointage")] == "P";
                csvRow.BankInformation = informations;
                csvData.Add(csvRow);
            }

            return csvData;
        }
    }
}
