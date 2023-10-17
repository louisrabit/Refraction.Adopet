using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console;

public class Show
{



    public void ShowExecute(string specificCommandShow)
    {
        // vamos precisar de um objecto de tipo leitor de arquivo
        ReadArchieve reader = new ReadArchieve();
        // Criar uma variavel que vai receber o retorno da leitura 
        var receiveLIstPets = reader.ReadHappen(specificCommandShow);
        //Exibir a List
        foreach ( var pet in receiveLIstPets)
        {
            System.Console.WriteLine(pet);
        }
    }
}



