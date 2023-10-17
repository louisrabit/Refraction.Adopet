using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Controls;
using Alura.Adopet.Console.Models;

// cria instância de HttpClient para consumir API Adopet
HttpClient client = ConfiguraHttpClient("http://localhost:5057");

Dictionary<string, IControll> SystemControll = new()
{
    {"help", new Help() },
     {"import", new PathArchieve() },
      {"show", new Show() },
       {"list", new List() },

};
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string control = args[0].Trim();
    if (SystemControll.ContainsKey(control))
    {
        IControll cmd = SystemControll[control];
         await cmd.ExecuteAsync(args);
    }
    else
    {
        Console.WriteLine("Invalid Control");
    }



    //switch (control)
    //{
    //    case "import":
    //        var import = new PathArchieve();
    //        await import.ExecuteAsync(args);
    //        break;

    //    case "help":
    //        var help = new Help();
    //      await  help.ExecuteAsync( args);
    //        break;


    //    case "show":
    //        var show = new Show();
    //        await show.ExecuteAsync(args);
    //        break;




    //    case "list":
    //     var list = new List();
    //      await  list.ExecuteAsync(args);
    //        break;



    //    default:
    //        // exibe mensagem de comando inválido
    //        Console.WriteLine("Comando inválido!");
    //        break;
    //}
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}

HttpClient ConfiguraHttpClient(string url)
{
    HttpClient _client = new HttpClient();
    _client.DefaultRequestHeaders.Accept.Clear();
    _client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    _client.BaseAddress = new Uri(url);
    return _client;
}

Task<HttpResponseMessage> CreatePetAsync(Pet pet)
{
    HttpResponseMessage? response = null;
    using (response = new HttpResponseMessage())
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }
}

async Task<IEnumerable<Pet>?> ListPetsAsync()
{
    HttpResponseMessage response = await client.GetAsync("pet/list");
    return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
}