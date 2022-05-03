using CadastroUbuntu.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroUbuntu.Repositorio
{
    public interface IListaRepositorio
    {
        ListaModel ListarId(int id);

        //public IQueryable<ListaModel> GetItem();
        List<ListaModel> BuscarTodos();
        public ListaModel Editar(ListaModel lista);

        ListaModel Adicionar(ListaModel lista);

        ListaModel Atualizar(ListaModel lista);

        bool Apagar(int id);
    }
}
