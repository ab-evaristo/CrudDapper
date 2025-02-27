using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class ProdutoRepository{
    private readonly SqlConnection _connection;
    public ProdutoRepository(SqlConnection connection) => _connection = connection;
    public List<ProdutoModel> Read() => _connection.GetAll<ProdutoModel>().ToList();
    public ProdutoModel Read(int id) => _connection.Get<ProdutoModel>(id);
    public void Create(ProdutoModel model) => _connection.Insert<ProdutoModel>(model);
    public void Update(ProdutoModel model) => _connection.Update<ProdutoModel>(model);
    public void Delete(ProdutoModel model) => _connection.Delete<ProdutoModel>(model);
}