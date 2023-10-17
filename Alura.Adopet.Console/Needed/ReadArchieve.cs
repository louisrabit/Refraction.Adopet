﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Service
{
    public class ReadArchieve
    {

        public List<Pet> ReadHappen(string readfileHappen)
        {
            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(readfileHappen))
            {
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                      propriedades[1],
                      TipoPet.Cachorro
                     );

                    System.Console.WriteLine(pet);
                    listaDePet.Add(pet);
                }

            }

            return listaDePet;
        }


    }

}