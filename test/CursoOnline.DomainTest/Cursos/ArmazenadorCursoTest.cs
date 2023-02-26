using Bogus;
using CursoOnline.Domain.Cursos;
using CursoOnline.DomainTest._Builders;
using CursoOnline.DomainTest._Utils;
using Moq;

namespace CursoOnline.DomainTest.Cursos
{
    public class ArmazenadorCursoTest
    {
        private CursoDto _cursoDto;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
        private ArmazenadorCurso _armazenadorCurso;

        public ArmazenadorCursoTest()
        {
            var faker = new Faker();

            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Word(),
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Double(50,100),
                PublicoAlvo = "Empreendedor",
                Valor = faker.Random.Double(500, 1000)
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorCurso = new ArmazenadorCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorCurso.Armazenar(_cursoDto);

            // Verifica se o curso foi instanciado
            //cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>())); 

            // Verifica seo objeto instaciado tem a mesma propriedade que o dto
            _cursoRepositorioMock.Verify(r => r.Adicionar(
                    It.Is<Curso>(c => c.Nome == _cursoDto.Nome)
                ), Times.AtLeast(1) // Verifica quantas vezes foi instanciado o objeto
            ); 
        }

        [Fact]
        public void DeveInformarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorCurso.Armazenar(_cursoDto))
                .ComMensagem("Público alvo innválido");
        }

        [Fact]
        public void NaoDeveAdicionarCursoComNomesRepetidos()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => _armazenadorCurso.Armazenar(_cursoDto))
                .ComMensagem("Este curso já existe no banco de dados");
        }
    }
  
    } 
}
