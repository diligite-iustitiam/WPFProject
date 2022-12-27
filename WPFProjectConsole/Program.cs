
using System.Globalization;
using System.Linq;
using System.Net;

namespace WPFProjectConsole;

class Program {
    private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";


    private static async Task<Stream> GetDataStream()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(data_url,HttpCompletionOption.ResponseHeadersRead);
        return await response.Content.ReadAsStreamAsync();
    }

    private static IEnumerable<string> GetDataLines()
    {
        using var data_stream = GetDataStream().Result;
        using var data_reader = new StreamReader(data_stream);
        while (!data_reader.EndOfStream)
        {
            var line = data_reader.ReadLine();
            if (String.IsNullOrWhiteSpace(line)) continue;
            yield return line.Replace("Korea,", "Korea -");
        }
    }
    public static DateTime[] GetDates() => GetDataLines()
        .First()
        .Split(',')
        .Skip(4)
        .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
        .ToArray();

   public static IEnumerable<(string Country, string Province, int[] Counts)> GetData()
    {
        var lines = GetDataLines().
            Skip(1).
            Select(line => line.Split(','));

        foreach(var row in lines)
        {
            var province = row[0].Trim();
            var country = row[1].Trim(',', '"');
            var i = 0;
            if (!int.TryParse(row[4], out int result))
                i = 1;
            var counts = row.Skip(4 + i).Select(int.Parse).ToArray();
            
            

            yield return (country,province, counts);
        }

       
    }





    static void Main(string[] args) {

        //WebClient webClient = new WebClient();
        //var client = new HttpClient();

        //var response = client.GetAsync(data_url).Result;
        //var csv_str = response.Content.ReadAsStringAsync().Result;
        //Console.WriteLine(csv_str);


        var us_data = GetData().
            First(v => v.Country.Equals("US", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine(String.Join("\r\n", GetDates().Zip(us_data.Counts, (date,count)=> $"{date:dd:MM} - {count}")));
        
        //var dates = GetDates();

        //Console.WriteLine(string.Join("\r\n", dates));
    }

}

