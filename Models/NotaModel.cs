
using Dapper.Contrib.Extensions;

[Table("Nota")]
public class NotaModel {
    public NotaModel() => Itens = new List<ItemNotaModel>();    
    
    [Key]
    public int Id { get; set; } 
    public int Nota { get; set; }    
    public string Serie { get; set; }
    public List<ItemNotaModel> Itens { get; set; }
}