namespace CursoOnline.DomainTest
{
    public class UnitTest1
    {
        [Fact(DisplayName ="Testar")]
        public void DeveAsVariaveisTeremMesmoValor()
        {
            // AAA - Arrange, Act, Assert
            // Recomendado realizar testes curtos

            // Organização
            var variavel1 = 1; 
            var variavel2 = 1;

            // Ação
            variavel1= variavel2;

            // Assert
            Assert.Equal(variavel1, variavel2);
        }
    }
}