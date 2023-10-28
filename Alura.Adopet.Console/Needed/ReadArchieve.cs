using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Service
{
    public class ReadArchieve
    {
        

        //Pega uma linha , tipo texto e converte em um objecto tipo pet 
        //Podemos isolar o codigo em uma classe , fazer uma extraçao de claase 
        // Vamos fazer , para o caso de haver uma mudança de codigo conseguirmos mudar dinammicamente 
        //vamos fazer um teste para modelar o codigo --> fazer um design
        public List<Pet>  ReadHappen(string caminhoDoArquivoDeImportacao, Pet pet)
        {
            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoDeImportacao))
            {
                while (!sr.EndOfStream)
                {
                    //// separa linha usando ponto e vírgula
                    //string[] propriedades = sr.ReadLine().Split(';');
                    //// cria objeto Pet a partir da separação
                    //Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    //  propriedades[1],
                    //  TipoPet.Cachorro
                    // );

                    //System.Console.WriteLine(pet);
                    listaDePet.Add(pet);
                }

            }

            return listaDePet;
        }

        internal IEnumerable<Pet?> ReadHappen(string specificCommandShow)
        {
            throw new NotImplementedException();
        }
    }

}
