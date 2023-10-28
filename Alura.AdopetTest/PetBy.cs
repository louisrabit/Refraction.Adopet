using Alura.Adopet.Console.Models;

namespace Alura.AdopetTest
{
    public class PetBy
    {
        internal Pet ConverserText(string line)
        {
            if(line is null ) throw new ArgumentNullException("Texto nao pode ser nulo");
            // separa linha usando ponto e vírgula
            string[] propriedades = line.Split(';');
            // cria objeto Pet a partir da separação
            return new Pet(Guid.Parse(propriedades[0]),
               propriedades[1],
               int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
              );

           
        }
    }
}