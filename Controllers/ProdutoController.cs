using System.Text;
using Microsoft.AspNetCore.Mvc;
using webGerenciaLoja.Models;

namespace webGerenciaLoja.Controllers;

public class ProdutoController : Controller
{
    private static List<ProdutoModel> _produtos = new List<ProdutoModel>()
    {
        new ()
        {
            Id = 1,
            Nome = "Coca cola 2L",
            Preco = 10.0m,
            Categoria = "Bebidas",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 2,
            Nome = "Arroz Agulhinha 5kg",
            Preco = 25.5m,
            Categoria = "Alimentos",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 3,
            Nome = "Detergente Neutro 500ml",
            Preco = 2.99m,
            Categoria = "Limpeza",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 4,
            Nome = "Sabonete Lux 85g",
            Preco = 1.79m,
            Categoria = "Higiene Pessoal",
            EmEstoque = false,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 5,
            Nome = "Leite Integral 1L",
            Preco = 4.49m,
            Categoria = "Laticínios",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 6,
            Nome = "Papel Higiênico Neve 12 rolos",
            Preco = 18.90m,
            Categoria = "Higiene Pessoal",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 7,
            Nome = "Feijão Carioca 1kg",
            Preco = 7.20m,
            Categoria = "Alimentos",
            EmEstoque = false,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 8,
            Nome = "Água Mineral com Gás 500ml",
            Preco = 2.50m,
            Categoria = "Bebidas",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 9,
            Nome = "Café Torrado e Moído 500g",
            Preco = 14.75m,
            Categoria = "Alimentos",
            EmEstoque = true,
            DataCadastro = DateTime.Now
        },
        new ()
        {
            Id = 10,
            Nome = "Shampoo Seda 325ml",
            Preco = 9.99m,
            Categoria = "Higiene Pessoal",
            EmEstoque = false,
            DataCadastro = DateTime.Now
        },
    };
    
    // GET
    public IActionResult Index()
    {
        return View(_produtos);
    }
    
    public IActionResult Detalhes(int id)
    {
        var item = _produtos.FirstOrDefault(x => x.Id == id)
        ?? new ProdutoModel
        {
            Id = -1,
            Nome = "Não encontrado"
        };
        return View(item);
    }

    public IActionResult Categoria(string categoria)
    {
        var itens = 
            _produtos.Where(x => x.Categoria == categoria).ToList();
        return View(itens);
    }

    public JsonResult ObterProdutosJson()
    {
        return Json(_produtos);
    }

    public JsonResult BuscarProduto(int id)
    {
        var produto = _produtos.FirstOrDefault(x => x.Id == id);
        if (produto == null) return Json(new { message = "Não encontrado" });
        return Json(produto);
    }

    public JsonResult ProdutoPorCategoria(string categoria)
    {
        var produtos = _produtos.Where(x => x.Categoria == categoria).ToList();
        return Json(produtos);
    }
    // Gerar arquivo CSV com lista de produtos
    public FileResult ExportarCsv()
    {
        var csv = new StringBuilder();
        csv.AppendLine("Id;Nome;Preco;Categoria;EmEstoque;DataCadastro;");
        foreach (var prod in _produtos)
        {
            csv.AppendLine($"{prod.Id};{prod.Nome};{prod.Preco};" +
                           $"{prod.Categoria};{prod.EmEstoque};{prod.DataCadastro};");
        }
        byte[] bytes = Encoding.UTF8.GetBytes(csv.ToString());

        return File(bytes, "text/csv", "Produtos.csv");
    }
    
    // Gerar relatório em texto com estatísticas
    public FileResult RelatorioTxt()
    {
        var txt = new StringBuilder();
        foreach (var prod in _produtos)
        {
            txt.AppendLine($"{prod.Id};{prod.Nome};{prod.Preco};" +
                           $"{prod.Categoria};{prod.EmEstoque};{prod.DataCadastro};");
        }

        txt.AppendLine();
        txt.AppendLine("**************** RELATORIO DE VENDAS ****************");
        txt.AppendLine($"Total de produtos: {_produtos.Count}");
        txt.AppendLine();
        txt.AppendLine($" >>>>>>>>>>>>>>> Produtos por categoria <<<<<<<<<<<<< ");
        var agrupado = _produtos.GroupBy(x => x.Categoria);
        foreach (var item in agrupado)
        {
            txt.AppendLine($"{item.Key}: {item.Count()}");
        }
        txt.AppendLine();
        txt.AppendLine($" >>>>>>>>>>>>>>> Estoque <<<<<<<<<<<<< ");
        txt.AppendLine($"Em estoque: {_produtos.Count(x => x.EmEstoque)}");
        txt.AppendLine($"Sem estoque: {_produtos.Count(x => x.EmEstoque)}");
        txt.AppendLine();
        txt.AppendLine(" >>>>>>>>>>>>>>> Preços <<<<<<<<<<<<<");
        txt.AppendLine($"Maior preço: {_produtos.Max(x => x.Preco)}");
        txt.AppendLine($"Maior preço: {_produtos.Min(x => x.Preco)}");
        txt.AppendLine($"Media de preços: {_produtos.Average(x => x.Preco)}");
        
        byte[] bytes = Encoding.UTF8.GetBytes(txt.ToString());
        return File(bytes, "text/plain", "RelatorioProdutos.txt");
    }
    
    // Baixar arquivo JSON com todos os produtos
    public FileResult ExportarJson()
    {
        var data = new
        {
            produtos =  _produtos.Select(p => new
            {
                p.Id,
                p.Nome,
                p.Preco,
                p.Categoria,
                p.EmEstoque,
                DataCadastro = p.DataCadastro.ToString("dd/MM/yyyy HH:mm:ss")
            })
        };
        
        //essa etapa aqui é cabulosa em
        var json = System.Text.Json.JsonSerializer.Serialize(data);
        
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        return File(bytes,"application/json","produtos.json");
    }

}