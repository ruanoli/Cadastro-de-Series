using System;
using System.Collections.Generic;
using Cadastro_Series.Interfaces;

namespace Cadastro_Series
{
    public class SerieRepositorio : IRempositorio<Serie> //Herdando de IRempositorio
    {
        private List<Serie> ListaSerie = new List<Serie>();
        public void Atualizar(int id, Serie objeto)
        {
            //Pega o elemento do vetor pelo id, e ele irá receber o objeto e colocá-lo na posição do vetor.
            ListaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            ListaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return ListaSerie[id];
        }

        Serie IRempositorio<Serie>.RetornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}