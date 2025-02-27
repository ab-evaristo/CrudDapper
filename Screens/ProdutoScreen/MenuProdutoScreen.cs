using System.Collections;
using Microsoft.Data.SqlClient;

public class MenuProdutoScreen{
    private readonly SqlConnection _connection;
    public MenuProdutoScreen(SqlConnection connection) => _connection = connection;
    public void Load(){
        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Gestão de Produtos");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("o que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Consultar Todos");
        Console.WriteLine("2 - Consultar");
        Console.WriteLine("3 - Inserir");
        Console.WriteLine("4 - Atualizar");
        Console.WriteLine("5 - Excluir");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ConsultarTodos();
                break;
            case 3:
                Inserir();
                break;
        }
    }

    public void Inserir(){
        Console.Clear();
        Console.WriteLine("Informe o nome do produto:");
        string nome = Console.ReadLine();

        ProdutoModel produtoModel = new ProdutoModel();
        produtoModel.Descricao = nome;

        ProdutoRepository produtoRepository = new ProdutoRepository(_connection);

        produtoRepository.Create(produtoModel);

        Console.Clear();
        Console.WriteLine("Produto cadastrado com sucesso");
        Console.ReadLine();
        Load();
    }
    public void ConsultarTodos(){

        ProdutoRepository produtoRepository = new ProdutoRepository(_connection);

        List<ProdutoModel> lista = produtoRepository.Read();

        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Lista de Produtos");
        Console.WriteLine("--------------------------------");

        foreach(var item in lista)
            Console.WriteLine($"{item.IdProduto} - {item.Descricao}");
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1 - Voltar | 2 - Inicio");
        
        var option = short.Parse(Console.ReadLine());
    }
}