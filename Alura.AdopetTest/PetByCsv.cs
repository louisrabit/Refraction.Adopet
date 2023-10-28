using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.AdopetTest
{
    public  class PetByCsv
    {
        [Fact]
        public void WhenStringIsValidReturnPet()
        {
            //Arrange
            string line = "456b24f4-19e2-4423-845d-4a80e8854a41 - Lima Limao - Cachorro";
            var convert = new PetBy();


            //Act
            Pet pet = convert.ConverserText(line);//Pet vai ser obtido apartir da conversao 
            //linha vai retornar um pet 



            //Assert
            Assert.NotNull(pet);
           
        }

        [Fact]
        public void WhenStringIsNullResturnExceptionPet()
        {
            //Arrange
            string line = null;
            var convert = new PetBy();


            //Act + Asserts
            Assert.Throws<ArgumentException>(() => convert.ConverserText(line));
          


        

        }
    }
    }

