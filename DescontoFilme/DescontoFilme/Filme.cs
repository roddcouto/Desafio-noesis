using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescontoFilme
{
    public class Filme
    {
    public int id { get; set; }
    public string nome { get; set; }
    public string genero { get; set; }
    public double preco { get; set; }

    public Filme()
    {

    }

    public Filme(int id, string nome, string genero, double preco)
    {
      this.id = id;
      this.nome = nome;
      this.genero = genero;
      this.preco = preco;
    }
  }
}
