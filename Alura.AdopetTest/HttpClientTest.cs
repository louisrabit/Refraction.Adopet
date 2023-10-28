using Alura.Adopet.Console.Servicos;

namespace Alura.AdopetTest
{
    public class HttpClientTest
    {
        [Fact]
        public async Task PetsListReturnListNotEmpty()
        {
            //Arrange
            var clientpet = new HttpClientPet();
            //Act
            var listPet = await clientpet.ListPetsAsync();
            //Assert
            Assert.NotNull(listPet);
            Assert.NotEmpty(listPet);
        }

        // Mudança aqui , vamos fazer com o nosso teste HttpClient receba o Endereço/ Url  , onde a classe faz conexao para Api 
        //passamos um url ivalida , para simular uma api fora do ar 
        // no 1 exemplo temos a api no ar
        [Fact]
        public async Task WhenApiIsOutGiveException()
        {
            //Arrange
            var clientpet = new HttpClientPet(uri: "http://localhost:1111");
            //Act +  Assert
            // Testar qualquer tipo de exceçao
            await Assert.ThrowsAnyAsync<Exception>(() => clientpet.ListPetsAsync());
        }
        // Nos neste moemento estamos a depender de outros fatores , para fazer um teste -> precisamos de por/tirar a Api 
        // temos que fazer com o nosso teste seja diferenciado 

    }
}