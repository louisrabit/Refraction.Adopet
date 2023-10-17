using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Controls;
[DocCommand(instruction: "lsit", document: "adopet list comando que exibe no terminal cadastro na base de dados da AdoPet" + "\n")]

public class List : IControll
{
    public async Task ExecuteAsync(string[] args)
    {
       await  this.ListPetsAsyncpets();
        
        //depois do metodo sincrono tenho que dizer que foi completada
        //return Task.CompletedAtsk
    }

    HttpClient client;
    public List()
    {
        client = new HttpClient();
    }

 

    private async Task ListPetsAsyncpets()
    {
        var pets = await ListPetsAsync();
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
    private async Task<IEnumerable<Pet>> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}

