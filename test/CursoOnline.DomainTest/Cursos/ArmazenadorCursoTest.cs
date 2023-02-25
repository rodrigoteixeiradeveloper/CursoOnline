using CursoOnline.Domain.Cursos;
using Moq;

namespace CursoOnline.DomainTest.Cursos
{
    public class ArmazenadorCursoTest
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descrição A",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = (double)100
            };

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var armazenadorCurso = new ArmazenadorCurso(cursoRepositorioMock.Object);

            armazenadorCurso.Armazenar(cursoDto);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
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
