using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Controls;
[DocCommand(instruction: "lsit", document: "adopet list comando que exibe no terminal cadastro na base de dados da AdoPet" + "\n")]

public class List : IControll
{
    public  Task ExecuteAsync(string[] args)
    {
       return  this.ListPetsAsyncpets();
        
        //depois do metodo sincrono tenho que dizer que foi completada
        //return Task.CompletedAtsk
    }


    private async Task ListPetsAsyncpets()
    {
        var httpListPet = new HttpClientPet();
        IEnumerable<Pet>? pets = await httpListPet.ListPetsAsync();
        System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
    
}

