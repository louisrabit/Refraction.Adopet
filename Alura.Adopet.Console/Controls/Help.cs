using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Controls;
[DocCommand(instruction: "help", document: "Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n")]


public class Help : IControll
{
    public Task ExecuteAsync(string[] args)
    {
        this.HelpDocument(parameters: args);
        return Task.CompletedTask;
    }


    private Dictionary<string, DocCommand> docs;
    public Help()
    {
        //preciso de popular o dicionario com a chave
        // Ele tem que receber inf em tempo de execuçao --> biblioteca , chamada de Reflection . 
        //  Para recuperar informaçao nos precisamos de recuperar a dll , o nosso executavel --> gerado quando compilamos os projectos
        // queremos pegar em tempo de exucuçao ~: GetExecutingAssembly ; ; queremos todos os tipos : GetTypes
        docs = Assembly.GetExecutingAssembly().GetTypes()
        // So queremos o que tem o atributo DocCommand --> Where
        .Where(t => t.GetCustomAttributes<DocCommand>().Any())
        .Select(t => t.GetCustomAttribute<DocCommand>()!)
        .ToDictionary(d => d.Instruction);
    }



    private void HelpDocument(string[] parameters)
    {
        System.Console.WriteLine("Lista de comandos.");
        // se não passou mais nenhum argumento mostra help de todos os comandos
        if (parameters.Length == 1)
        {
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                 "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            //System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            //System.Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
            //System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");

            //Vamos recuperar a inf do Dicionario !! 
            foreach (var doc in docs.Values)
            {
                System.Console.WriteLine(doc.Document);
            }
        }

        else if (parameters.Length == 2)
        {
            string specificCommand = parameters[1];

            if (docs.ContainsKey(specificCommand))
            {
                var command = docs[specificCommand];
                System.Console.WriteLine(command.Document);
                System.Console.WriteLine(command.Document);
            }



            //if (specificCommand.Equals("import"))
            //{
            //    System.Console.WriteLine(" adopet import <arquivo> " +
            //        "comando que realiza a importação do arquivo de pets.");
            //}
            //if (specificCommand.Equals("show"))
            //{
            //    System.Console.WriteLine(" adopet show <arquivo>  comando que " +
            //        "exibe no terminal o conteúdo do arquivo importado.");
            //}
        }
    }


}




