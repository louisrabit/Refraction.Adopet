using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alura.Adopet.Console.Controls;

internal class SystemCommands
{
    private Dictionary<string, IControll> controllSystem = new()
        {
            {"help",new Help() },
            {"import",new PathThru() },
            {"list",new List() },
            {"show",new Show() },
    };

    public IControll? this[string key] => controllSystem.ContainsKey(key) ? controllSystem[key] : null;
}

