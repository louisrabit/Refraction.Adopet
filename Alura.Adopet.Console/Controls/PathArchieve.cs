using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Service;

namespace Alura.Adopet.Console.Controls;

[DocCommand(instruction: "import", document: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
public class PathArchieve : IControll
{
    public async Task ExecuteAsync(string[] args)
    {
        await this.ImportArchieveAsync(pathArchieve: args[1]);
    }


    HttpClient client;

    public PathArchieve()
    {
        client = ConfiguraHttpClient("http://localhost:5057");

    }

    private async Task ImportArchieveAsync(string pathArchieve)
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

