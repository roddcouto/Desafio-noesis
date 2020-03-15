using System;
using System.Collections;

namespace Carrinho
{
  class Program
  {
    static void Main(string[] args)
    {
      Filme senhorDosAneis = new Filme();
      senhorDosAneis.id = 1;
      senhorDosAneis.nome = "Senhor dos Anéis";
      senhorDosAneis.genero = "Fantasia";
      senhorDosAneis.preco = 45;
      
      Filme asBranquelas = new Filme();
      asBranquelas.id = 2;
      asBranquelas.nome = "As Branquelas";
      asBranquelas.genero = "Comédia";
      asBranquelas.preco = 55;
      
      Filme velozesEFuriosos7 = new Filme();
      velozesEFuriosos7.id = 3;
      velozesEFuriosos7.nome = "Velozes e Furiosos 7";
      velozesEFuriosos7.genero = "Ação";
      velozesEFuriosos7.preco = 100;
      
      Filme velozesEFuriosos6 = new Filme();
      velozesEFuriosos7.id = 4;
      velozesEFuriosos7.nome = "Velozes e Furiosos 7";
      velozesEFuriosos7.genero = "Ação";
      velozesEFuriosos7.preco = 100;

      Filme theScapeGoat = new Filme();
      theScapeGoat.id = 5;
      theScapeGoat.nome = "The Scape Goat";
      theScapeGoat.genero = "Drama";
      theScapeGoat.preco = 100;

      Filme meuMalvadoFavorito = new Filme();
      meuMalvadoFavorito.id = 6;
      meuMalvadoFavorito.nome = "Meu Malvado Favorito";
      meuMalvadoFavorito.genero = "Animação";
      meuMalvadoFavorito.preco = 200;

      ArrayList carrinho = new ArrayList();

      Console.WriteLine("{0} | {1} | {2} | {3}", senhorDosAneis.id, senhorDosAneis.nome, senhorDosAneis.genero, senhorDosAneis.preco);
      Console.ReadKey();
    }
  }
}
