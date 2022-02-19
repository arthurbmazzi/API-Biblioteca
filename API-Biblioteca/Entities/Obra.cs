using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Obra
    {
        public Obra()
        {
        }
        public Obra(int codigoObraProp, string tipo, string titulo, string descFisica, int exDisponiveis, DateTime publicacao, string edicao, string isbnObra, string descTrab)
        {
            CodigoObraProp = codigoObraProp;
            Tipo = tipo;
            Titulo = titulo;
            DescFisica = descFisica;
            ExDisponiveis = exDisponiveis;
            Publicacao = publicacao;
            Edicao = edicao;
            Isbn = isbnObra;
            DescTrab = descTrab;
        }

        public int CodigoObraProp { get; private set; }

        public string Tipo { get; private set; }

        public string Titulo { get; private set; }

        public string DescFisica { get; private set; }

        public int ExDisponiveis { get; private set; }

        public DateTime Publicacao { get; private set; }

        public string Edicao { get; private set; }

        public string Isbn { get; private set; }

        public string DescTrab { get; private set; }

    }
}