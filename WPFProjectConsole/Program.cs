
using System.Net;

namespace WPFProjectConsole;

class Program {
    private const string data_url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports_us/01-01-2022.csv";
    static void Main(string[] args) {

        //WebClient webClient = new WebClient();
        var client = new HttpClient();

        var response = client.GetAsync(data_url).Result;
        var csv_str = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(csv_str);
        

    }

}

