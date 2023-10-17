using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Service;

namespace Alura.Adopet.Console.Controls;
[DocCommand(instruction: "show", document: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.\" + \"\\n\\n\\n\\n")]

public class Show : IControll
{
    public Task ExecuteAsync(string[] args)
    {
        this.ShowExecute(specificCommandShow: args[1]);
        return Task.CompletedTask;
        //depois do metodo sincrono tenho que dizer que foi completada
        //return Task.CompletedAtsk
    }

    private void ShowExecute(string specificCommandShow)
    {
        // vamos precisar de um objecto de tipo leitor de arquivo
        ReadArchieve reader = new ReadArchieve();
        // Criar uma variavel que vai receber o retorno da leitura 
        var receiveLIstPets = reader.ReadHappen(specificCommandShow);
        //Exibir a List
        foreach (var pet in receiveLIstPets)
        {
            System.Console.WriteLine(pet);
        }
    }
}



