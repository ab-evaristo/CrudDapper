using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CrudDapper
{
    internal class Program
    {
        private const string CONNECTION_STRING = @"Server=DESKTOP-P5S613Q;Database=DesafioDapper;User Id=sa;Password=h7r6az;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            // MenuProdutoScreen menuProduto = new MenuProdutoScreen(connection);
            // menuProduto.Load();

            NotaRepository notaRepository = new NotaRepository(connection);
            var notas = notaRepository.Read();

            foreach(var items in notas){
                Console.WriteLine($"{items.Nota} - {items.Serie}");

                foreach(var itemsNota in items.Itens){
                    Console.WriteLine($"{itemsNota.IdProduto} - {itemsNota.Quantidade}");
                }
            }
        }
    }
}