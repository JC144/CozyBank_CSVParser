using CozyBank_Importer.CozyBanks;
using CozyBank_Importer.FromGererMesComptes;

internal class Program
{
    //MODIFY THIS
    private const string csvImportPath = "PATH_TO_YOUR_FOLDER\\IMPORT";
    
    //MODIFY THIS
    private const string csvExportPath = "PATH_TO_YOUR_FOLDER\\EXPORT";

    //MODIFY THIS
    private static readonly Dictionary<string, BankInformation> mappingFileAccount = new Dictionary<string, BankInformation>()
        {
            {
                "NAME_OF_YOUR_EXPORTED_FILE.csv",
                new BankInformation()
                    {
                        BankName = "VOTRE BANQUE",
                        AccountName = "LIBELLE DU COMPTE",
                        AccountNumber = "NUMERO DU COMPTE",
                        AccountType = "TYPE DE COMPTE (Compte de chèques, Livret A, PEL, etc)"
                    }
            },
            {
                "NAME_OF_YOUR_EXPORTED_FILE.csv",
                new BankInformation()
                    {
                        BankName = "VOTRE BANQUE",
                        AccountName = "LIBELLE DU COMPTE",
                        AccountNumber = "NUMERO DU COMPTE",
                        AccountType = "TYPE DE COMPTE (Compte de chèques, Livret A, PEL, etc)"
                    }
            }
        };

    private static void Main(string[] args)
    {
        IEnumerable<string> files = GetCsvFilesInFolder(csvImportPath);

        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            if (mappingFileAccount.ContainsKey(fileName))
            {
                BankInformation bankInformation = mappingFileAccount[fileName];
                string[] importedCsv = ReadCsv(file);
                List<OperationModel>  allOperations = Parser.ParseCsv(importedCsv, bankInformation);
                string csv = CSVOperationModel.GenerateCsv(allOperations.Select(o => Mapping.ConvertOperation(o)));
                WriteCsv(Path.Combine(csvExportPath, $"{bankInformation.AccountNumber}.csv"), csv);
            }
        }
    }

    /// <summary>
    /// Get CSV files in a specific folder
    /// </summary>
    /// <param name="folderPath">Folder containing CSV files we want to import</param>
    /// <returns>A list of csv file paths</returns>
    /// <exception cref="FileNotFoundException"></exception>
    private static IEnumerable<string> GetCsvFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            throw new FileNotFoundException();
        }

        return Directory.GetFiles(folderPath).Where(f => Path.GetExtension(f).Equals(".csv", StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Get a string array from a Csv file
    /// </summary>
    /// <param name="filePath">Path to the CSV</param>
    /// <returns>String array of each lines inside the CSV</returns>
    private static string[] ReadCsv(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

    /// <summary>
    /// Write CSV in Export folder specified at the beginning of the Program
    /// </summary>
    /// <param name="filePath">Path to the csv file to create</param>
    /// <param name="csv">Csv file to write</param>
    private static void WriteCsv(string filePath, string csv)
    {
        using (var writer = new StreamWriter(filePath))
        {
            writer.Write(csv);
        }
    }


    /// <summary>
    /// Method used for debug to analyse existing categories to build the mapping
    /// </summary>
    /// <param name="files">CSV files from GererMesComptes</param>
    private static void AnalyseCsvFiles(IEnumerable<string> files)
    {
        List<OperationModel> allOperations = new List<OperationModel>();

        foreach (string file in files)
        {
            if (File.Exists(file))
            {
                string fileName = Path.GetFileName(file);
                BankInformation bankInformation = mappingFileAccount[fileName];
                string[] importedCsv = ReadCsv(file);
                allOperations.AddRange(Parser.ParseCsv(importedCsv, bankInformation));
            }
        }

        IEnumerable<string> distinctCategories = allOperations.Select(o => o.Categorie.Trim('\"')).Distinct();
        IEnumerable<string> distinctSousCategories = allOperations.Where(o => !String.IsNullOrEmpty(o.SousCategorie.Trim('\"'))).Select(o => o.Categorie.Trim('\"') + "/" + o.SousCategorie.Trim('\"')).Distinct();
        IEnumerable<string> distinctTypes = allOperations.Select(o => o.Type.Trim('\"')).Distinct();
        IEnumerable<string> distinctTiers = allOperations.Select(o => o.Tiers.Trim('\"')).Distinct();

        Console.WriteLine("Categories: ");
        Console.WriteLine("-------");
        foreach (string category in distinctCategories)
        {
            Console.WriteLine($"{{\"{category}\", \"\"}},");
        }
        Console.WriteLine("-------");
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Sous-Categories");
        Console.WriteLine("-------");
        foreach (string subcategory in distinctSousCategories)
        {
            Console.WriteLine($"{{\"{subcategory}\", \"\"}},");
        }
        Console.WriteLine("-------");
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Types");
        Console.WriteLine("-------");
        foreach (string type in distinctTypes)
        {
            Console.WriteLine(type);
        }
        Console.WriteLine("-------");
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Tiers");
        Console.WriteLine("-------");
        foreach (string tier in distinctTiers)
        {
            Console.WriteLine(tier);
        }
        Console.WriteLine("-------");
        Console.WriteLine("");
        Console.WriteLine("");
    }


}
