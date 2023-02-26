using Bogus;
using CursoOnline.Domain.Cursos;
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
                PublicoAlvo = PublicoAlvo.Empreendedor,
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
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
    }

    public class ArmazenadorCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorCurso(ICursoRepositorio cursoRepositorio)
        {
            this._cursoRepositorio = cursoRepositorio;
        }

        internal void Armazenar(CursoDto cursoDto)
        {
            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, cursoDto.PublicoAlvo, cursoDto.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }
}
