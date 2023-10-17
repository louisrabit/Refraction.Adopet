using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console;

public class PathArchieve
{
    HttpClient client;

    public PathArchieve()
    {
        this.client = ConfiguraHttpClient("http://localhost:5057");

    }

    public async Task ImportArchieveAsync(string pathArchieve)
    {

        // vamos precisar de um objecto de tipo leitor de arquivo
        ReadArchieve reader = new ReadArchieve();
        // Criar uma variavel que vai receber o retorno da leitura 
        List<Pet> listaDePet = reader.ReadHappen(pathArchieve);

        //Exibir a List
        foreach (var pet in listaDePet)
        {
            System.Console.WriteLine(pet);
            try
            {
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }








    Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
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
}

