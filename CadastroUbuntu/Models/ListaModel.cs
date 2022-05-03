using System.ComponentModel.DataAnnotations;

namespace CadastroUbuntu.Models
{
    public class ListaModel
    { 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Linguagem { get; set; }
        public string Conhecimento { get; set; }

        public ListaModel() { }
        public ListaModel(string nome, string linguagem, string conhecimento)
        {
            Nome = nome;
            Linguagem = linguagem;
            Conhecimento = conhecimento;
        }
    }
}
