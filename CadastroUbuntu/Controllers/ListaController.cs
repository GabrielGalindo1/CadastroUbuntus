using CadastroUbuntu.Models;
using CadastroUbuntu.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroUbuntu.Controllers
{
    public class ListaController : Controller
    {
        private readonly IListaRepositorio _listaRepositorio;

        public ListaController(IListaRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public IActionResult Index()
        {
            List<ListaModel> listas =_listaRepositorio.BuscarTodos();
            return View(listas);
        } 

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
          ListaModel listaModel = _listaRepositorio.ListarId(id);
            return View(listaModel);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ListaModel listaModel = _listaRepositorio.ListarId(id);
            return View(listaModel);
          
        }
        public IActionResult Apagar(int id)
        {
            _listaRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ListaModel lista)
        {
            _listaRepositorio.Adicionar(lista);
            return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public IActionResult Editar(ListaModel lista)
        {
            if(lista == null)
            {
                throw new Exception("Lista não pode ser vazia");
            }
            _listaRepositorio.Atualizar(lista);
            return RedirectToAction("Index");
        }

    }
}
