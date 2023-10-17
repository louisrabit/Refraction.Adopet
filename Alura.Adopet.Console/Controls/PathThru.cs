using Alura.Adopet.Console.Controls;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Service;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos;

[DocCommand(instruction: "import",
    document: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
internal class PathThru : IControll
{
   

    public async Task ExecuteAsync(string[] args)
    {
        await this.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
    }

    private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        var leitor = new ReadArchieve();
        List<Pet> listaDePet = leitor.ReadHappen(caminhoDoArquivoDeImportacao);
        foreach (var pet in listaDePet)
        {
            System.Console.WriteLine(pet);
            try
            {
                var httpCreatePet = new HttpClientPet();
                await httpCreatePet.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }
}
