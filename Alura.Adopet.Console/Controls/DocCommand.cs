using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Controls

{

    [AttributeUsage(AttributeTargets.Class)]
    public class DocCommand : Attribute
    {

        public DocCommand(string instruction, string document)
        {
            Instruction = instruction;
            Document = document;
        }

        public string Instruction { get; set; }
        public string Document { get; set; }
    }

    // Nos queremos que a classe herde um atributo --> vamos fazer com que a classe represente um atributo
    // vai herdar uma classe => Attribute

}
