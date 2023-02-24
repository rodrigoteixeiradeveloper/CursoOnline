using Bogus;
using CursoOnline.Domain.Cursos;
using CursoOnline.DomainTest._Builders;
using CursoOnline.DomainTest._Utils;
using ExpectedObjects;
using Xunit.Abstractions;

namespace CursoOnline.DomainTest.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Construtor sendo executado");

            var faker = new Faker();

            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(50,100);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(500, 1000);
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("Construtor sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao,
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-12)]
        public void NaoDeveCursoTerCargaHorariaMenosQueUm(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga Horaria Inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-12)]
        public void NaoDeveCursoTerValorMenosQueUm(double valorInvalida)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalida).Build())
                .ComMensagem("Valor Inválido");
        }

        
    }

    
}
