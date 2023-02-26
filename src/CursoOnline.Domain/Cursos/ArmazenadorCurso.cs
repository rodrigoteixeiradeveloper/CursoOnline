namespace CursoOnline.Domain.Cursos
{
    public class ArmazenadorCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorCurso(ICursoRepositorio cursoRepositorio)
        {
            this._cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var cursoExistente = _cursoRepositorio.ObterPeloNome(cursoDto.Nome);
            if (cursoExistente != null)
                throw new ArgumentException("Este curso já existe no banco de dados");

            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
                throw new ArgumentException("Público alvo innválido");

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}
