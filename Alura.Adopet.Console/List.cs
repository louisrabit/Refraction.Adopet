using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    public class List
    {
        HttpClient client;
        public List()
        {
            this.client = new HttpClient();
        }

        public async  Task ListPetsAsyncpets()
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
   
}
