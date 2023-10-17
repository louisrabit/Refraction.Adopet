using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Controls;

internal interface IControll
{
    // o comando , o metodo tem  que ter um comportamento identico a todos eles => Executar
    // O metodo é assincrono => vai receber paranetros => vai receber uma lista de strings , do tipo args
     Task ExecuteAsync(string[] args);

}
