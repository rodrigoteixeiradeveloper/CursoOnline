namespace CursoOnline.DomainTest
{
    public class UnitTest1
    {
        [Fact(DisplayName ="Testar")]
        public void DeveAsVariaveisTeremMesmoValor()
        {
            // AAA - Arrange, Act, Assert
            // Recomendado realizar testes curtos

            // Organiza��o
            var variavel1 = 1; 
            var variavel2 = 1;

            // A��o
            variavel1= variavel2;

            // Assert
            Assert.Equal(variavel1, variavel2);
        }
    }
}