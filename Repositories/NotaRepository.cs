using System.Security.Cryptography.X509Certificates;
using Dapper;
using Microsoft.Data.SqlClient;

public class NotaRepository{
    private readonly SqlConnection _connection;

    public NotaRepository(SqlConnection connection) => _connection = connection;

    public List<NotaModel> Read()
    {
        var query = @"select 
                        Nota.Id,
                        Nota.Nota,
                        Nota.Serie,
                        ItemNota.Seq,
                        ItemNota.IdProduto,
                        ItemNota.Quantidade
                    from Nota
                    inner join ItemNota on
                        Nota.Id = ItemNota.Id";

        var notas = new List<NotaModel>();

        var item = _connection.Query<NotaModel, ItemNotaModel, NotaModel>(
            query,
            (notaModel, item) => {
                var nota = notas.Where(x => x.Id == notaModel.Id).FirstOrDefault();

                if (nota == null){
                    nota = notaModel;
                    nota.Itens.Add(item);
                    notas.Add(nota);
                }else {
                    nota.Itens.Add(item);
                }

                return notaModel; 
            }, splitOn: "Seq"
        );

        return notas;
    }
}