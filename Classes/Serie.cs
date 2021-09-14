using System;


namespace Cadastro_Series

{
    public class Serie : EntidadeBase //Herdando de EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; } 
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private int Temporadas { get; set; }
        private bool Excluido { get; set; }

        //Métodos
        public Serie( int id, Genero genero, string titulo, string descricao, int ano, int temporadas)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Temporadas = temporadas;
            this.Excluido = false;
        }

        public override string ToString() //Retornará string
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine; 
            retorno += "Temporadas: " + this.Temporadas + Environment.NewLine;
            retorno += "Série excluída? " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

         public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }        
    }
}