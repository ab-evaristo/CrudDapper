using Dapper.Contrib.Extensions;

[Table("ItemNota")]
public class ItemNotaModel{
    
    [Key]
    public int Id { get; set; }

    [Key]
    public int Seq { get; set; }
    public int IdProduto { get; set; }
    public float Quantidade { get; set; }
}