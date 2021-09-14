using System.Collections.Generic;

namespace Cadastro_Series.Interfaces
{

    public interface IRempositorio<T>
    {
        List<T> Lista();
        T RetornaPorId( int id);
        void Insere(T objeto);
        void Excluir(int id);
        void Atualizar(int id, T objeto);
        int ProximoId();
    }
}