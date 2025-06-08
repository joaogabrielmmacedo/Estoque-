
using MySql.Data.MySqlClient;
using System;


string connectionString = "Server=localhost;Database=ControleEstoqueDB;User=root;Password=Ugb2024;";

while (true)
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("  SISTEMA DE CONTROLE DE ESTOQUE");
    Console.WriteLine("================================");
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Listar Produtos");
    Console.WriteLine("3 - Atualizar Estoque");
    Console.WriteLine("4 - Remover Produto");
    Console.WriteLine("5 - Sair");
    Console.Write("\nEscolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1": // --- CADASTRAR PRODUTO ---
            Console.Clear();
            Console.WriteLine("--- Cadastro de Novo Produto ---");

            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Preço do Produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Quantidade em Estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Produtos (Nome, Preco, QuantidadeEmEstoque) VALUES (@Nome, @Preco, @Quantidade)";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Preco", preco);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("\nProduto cadastrado! Pressione qualquer tecla para voltar.");
            Console.ReadKey();
            break;

        case "2": // --- LISTAR PRODUTOS ---
            Console.Clear();
            Console.WriteLine("--- Lista de Produtos em Estoque ---");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Nome, Preco, QuantidadeEmEstoque FROM Produtos ORDER BY Nome";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("{0,-5} {1,-30} {2,-15} {3,-10}", "ID", "Nome", "Preço (R$)", "Estoque");
                        Console.WriteLine("--------------------------------------------------------------------");
                        while (reader.Read())
                        {
                            Console.WriteLine("{0,-5} {1,-30} {2,-15:C2} {3,-10}",
                                reader["Id"], reader["Nome"], reader["Preco"], reader["QuantidadeEmEstoque"]);
                        }
                    }
                }
            }
            Console.WriteLine("\nListagem concluída. Pressione qualquer tecla para voltar.");
            Console.ReadKey();
            break;

        case "3": // --- ATUALIZAR ESTOQUE ---
            Console.Clear();
            Console.WriteLine("--- Atualizar Estoque de Produto ---");
            Console.Write("Digite o ID do produto: ");
            int idAtualizar = int.Parse(Console.ReadLine());
            Console.Write("Digite a nova quantidade: ");
            int novaQuantidade = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Produtos SET QuantidadeEmEstoque = @Quantidade WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Quantidade", novaQuantidade);
                    command.Parameters.AddWithValue("@Id", idAtualizar);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("\nEstoque atualizado! Pressione qualquer tecla para voltar.");
            Console.ReadKey();
            break;

        case "4": // --- REMOVER PRODUTO ---
            Console.Clear();
            Console.WriteLine("--- Remover Produto ---");
            Console.Write("Digite o ID do produto: ");
            int idRemover = int.Parse(Console.ReadLine());

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Produtos WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", idRemover);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("\nProduto removido! Pressione qualquer tecla para voltar.");
            Console.ReadKey();
            break;

        case "5": // --- SAIR ---
            Console.WriteLine("\nSaindo do sistema...");
            return;

        default: // --- OPÇÃO INVÁLIDA ---
            Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            break;
    }
}