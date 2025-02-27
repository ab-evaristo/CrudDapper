
using Dapper.Contrib.Extensions; // Importante!

[Table("Produto")]
public class ProdutoModel 
{
    [Key]
    public int IdProduto { get; set; }
    public string? Descricao { get; set; }
}