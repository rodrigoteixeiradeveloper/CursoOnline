using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.DomainTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            const string nome = "Informática Básica";
            const double cargaHoraria = 80;
            const string publicoAlvo = "Estudantes";
            const double valor = 950;

            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);
        }
    }

    public class Curso
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }

        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }
}
