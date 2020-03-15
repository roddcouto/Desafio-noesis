using DescontoFilme;
using NUnit.Framework;
using System;
using System.Collections;

namespace DescontoTests
{
  [TestFixture]
  public class CarrinhoDescontoTests
  {
    #region Preparação dos testes
    ArrayList carrinho;

    Filme senhorDosAneis = new Filme(1, "Senhor dos Anéis", "Fantasia", 45);
    Filme asBranquelas = new Filme(2, "As Branquelas", "Comédia", 55);
    Filme velozesEFuriosos7 = new Filme(3, "Velozes e Furiosos 7", "Ação", 100);
    Filme velozesEFuriosos6 = new Filme(4, "Velozes e Furiosos 6", "Ação", 55);
    Filme theScapeGoat = new Filme(5, "The Scape Goat", "Drama", 100);
    Filme meuMalvadoFavorito = new Filme(6, "Meu Malvado Favorito", "Animação", 200);

    public double CalculaDesconto(ArrayList carrinho)
    {
      int desconto = 0;
      double valorTotal = 0;
      bool acao = false;
      
      foreach (Filme filme in carrinho)
      {
        valorTotal += filme.preco;
        if (filme.genero == "Ação")
          acao = true;
      }

      if (valorTotal > 100 && valorTotal <= 200)
      {
        desconto = 10;
      }
      else if (valorTotal > 200 && valorTotal <= 300)
      {
        desconto = 20;
      }
      else if (valorTotal > 300 && valorTotal <= 400)
      {
        desconto = 25;
      }
      else if (valorTotal > 400)
      {
        desconto = 30;
      }

      if(acao)
        desconto += 5;

      return desconto;
    }
    
    #endregion

    #region Testes unitários
    [Test]
    public void SemDesconto()
    {
      carrinho = new ArrayList();
      carrinho.Add(senhorDosAneis);
      double desconto = CalculaDesconto(carrinho);
      Assert.AreEqual(0.0, desconto);
    }

    [Test]
    public void DescontoGeneroAcao()
    {
      carrinho = new ArrayList();
      carrinho.Add(velozesEFuriosos6);
      double desconto = CalculaDesconto(carrinho);
      Assert.AreEqual(5.0, desconto);
    }

    [Test]
    public void DescontoDezPorCento()
    {
      carrinho = new ArrayList();
      carrinho.Add(senhorDosAneis);
      carrinho.Add(theScapeGoat);
      double desconto = CalculaDesconto(carrinho);

      Assert.AreEqual(10.0, desconto);
    }

    [Test]
    public void DescontoQuinzePorCento()
    {
      carrinho = new ArrayList();
      carrinho.Add(asBranquelas);
      carrinho.Add(velozesEFuriosos7);
      double desconto = CalculaDesconto(carrinho);

      Assert.AreEqual(15.0, desconto);
    }

    [Test]
    public void DescontoVintePorCento()
    {
      carrinho = new ArrayList();
      carrinho.Add(meuMalvadoFavorito);
      carrinho.Add(asBranquelas);
      double desconto = CalculaDesconto(carrinho);
      
      Assert.AreEqual(20.0, desconto);
    }

    [Test]
    public void DescontoVinteECincoPorCento()
    {
      carrinho = new ArrayList();
      carrinho.Add(meuMalvadoFavorito);
      carrinho.Add(velozesEFuriosos6);
      double desconto = CalculaDesconto(carrinho);

      Assert.AreEqual(25.0, desconto);
    }

    [Test]
    public void DescontoTrintaPorCento()
    {
      carrinho = new ArrayList();
      carrinho.Add(meuMalvadoFavorito);
      carrinho.Add(asBranquelas);
      carrinho.Add(asBranquelas);
      carrinho.Add(theScapeGoat);
      double desconto = CalculaDesconto(carrinho);

      Assert.AreEqual(30.0, desconto);
    }

    [Test]
    public void DescontoTrintaECincoPorCento()
    {
      carrinho = new ArrayList();
      carrinho.Add(meuMalvadoFavorito);
      carrinho.Add(asBranquelas);
      carrinho.Add(velozesEFuriosos7);
      carrinho.Add(theScapeGoat);
      double desconto = CalculaDesconto(carrinho);

      Assert.AreEqual(35.0, desconto);
    }

    #endregion
  }
}
