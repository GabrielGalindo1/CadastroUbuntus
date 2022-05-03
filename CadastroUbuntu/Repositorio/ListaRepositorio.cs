using CadastroUbuntu.Data;
using CadastroUbuntu.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroUbuntu.Repositorio
{
    public class ListaRepositorio : IListaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ListaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ListaModel> BuscarTodos()
        {
            return _bancoContext.Listas.OrderBy(_ => _.Id).ToList();
        }

        public ListaModel Adicionar(ListaModel lista)
        {
            //gravar no banco de dados
            _bancoContext.Listas.Add(lista);
            _bancoContext.SaveChanges();
            return lista;
        }

        public ListaModel Atualizar(ListaModel vm)
        {
            //gravar no banco de dados
            var exist = _bancoContext.Listas.Where(b => b.Id == vm.Id).FirstOrDefault();

            exist.Linguagem = vm.Linguagem;
            exist.Nome = vm.Nome;
            exist.Conhecimento = vm.Conhecimento;

            _bancoContext.Listas.Update(exist);
            var result = _bancoContext.SaveChanges();

            if (result < 1)
            {
                throw new Exception("Não Salvou");
            }
            return vm;
        }
        
        public ListaModel ListarId(int id)
        {
            //gravar no banco de dados
            var lista = _bancoContext.Listas.FirstOrDefault(b => b.Id == id); 
            return lista;
        }

        public ListaModel Editar(ListaModel lista)
        {
            //gravar no banco de dados
            _bancoContext.Listas.Update(lista);
            _bancoContext.SaveChanges();
            return lista;
        }

        public bool Apagar(int id)
        {
            var lista = _bancoContext.Listas.FirstOrDefault(b => b.Id == id);
            if (lista == null) throw new Exception("Houve um erro ao deletar");
            _bancoContext.Listas.Remove(lista);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
