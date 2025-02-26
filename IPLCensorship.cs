using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

class Program
{
    static void Main()
    {
        string jsonInputPath = "ipl_data.json";
        string csvInputPath = "ipl_data.csv";
        string jsonOutputPath = "ipl_data_censored.json";
        string csvOutputPath = "ipl_data_censored.csv";

        ProcessJsonFile(jsonInputPath, jsonOutputPath);
        ProcessCsvFile(csvInputPath, csvOutputPath);
    }

    static void ProcessJsonFile(string inputPath, string outputPath)
    {
        string json = File.ReadAllText(inputPath);
        var matches = JsonConvert.DeserializeObject<List<IplMatch>>(json);
        matches.ForEach(CensorMatchData);
        string censoredJson = JsonConvert.SerializeObject(matches, Formatting.Indented);
        File.WriteAllText(outputPath, censoredJson);
    }

    static void ProcessCsvFile(string inputPath, string outputPath)
    {
        using var reader = new StreamReader(inputPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<IplMatch>().ToList();
        records.ForEach(CensorMatchData);
        using var writer = new StreamWriter(outputPath);
        using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
        csvWriter.WriteRecords(records);
    }

    static void CensorMatchData(IplMatch match)
    {
        match.Team1 = MaskTeamName(match.Team1);
        match.Team2 = MaskTeamName(match.Team2);
        match.Winner = MaskTeamName(match.Winner);
        match.PlayerOfMatch = "REDACTED";
        var newScore = new Dictionary<string, int>();
        foreach (var entry in match.Score)
            newScore[MaskTeamName(entry.Key)] = entry.Value;
        match.Score = newScore;
    }

    static string MaskTeamName(string teamName)
    {
        var words = teamName.Split(' ');
        if (words.Length > 1)
            words[1] = "***";
        return string.Join(" ", words);
    }
}

class IplMatch
{
    public int MatchId { get; set; }
    public string Team1 { get; set; }
    public string Team2 { get; set; }
    public Dictionary<string, int> Score { get; set; }
    public string Winner { get; set; }
    public string PlayerOfMatch { get; set; }
}
