using Cadastro;

namespace Repositorio;

public class ClienteRepositorio
{
    public List<Cliente> clientes = new List<Cliente>();

    private DateOnly LerDataNascimento()
    {
        while (true)
        {
            Console.WriteLine("Data de nascimento: ");
            if (DateOnly.TryParse(Console.ReadLine(), out var data))
            {
                return data;
            }
            Console.WriteLine("Data inválida! Use o formato dd/mm/aaaa.");
        }
    }

    private decimal LerDesconto()
    {
        while (true)
        {
            Console.WriteLine("Desconto: ");
            if (decimal.TryParse(Console.ReadLine(), out var desconto))
            {
                return desconto;
            }
            Console.WriteLine("Desconto inválido! Digite apenas números.");
        }
    }

    public void CadastrarCliente()
    {
        Console.Clear();

        Console.WriteLine("Nome do cliente: ");
        var nome = Console.ReadLine();
        Console.WriteLine(Environment.NewLine);

        var dataNascimento = LerDataNascimento();
        Console.WriteLine(Environment.NewLine);

        var desconto = LerDesconto();
        Console.WriteLine(Environment.NewLine);

        var cliente = new Cliente();
        cliente.Id = clientes.Any() ? clientes.Max(c => c.Id) + 1 : 1;
        cliente.Nome = nome;
        cliente.DataNascimento = dataNascimento;
        cliente.Desconto = desconto;
        cliente.CadastradoEm = DateTime.Now;

        clientes.Add(cliente);

        GravarDadosClientes();

        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
        ImprimirCliente(cliente);
        Console.ReadKey();

    }

    public void EditarCliente()
    {
        Console.Clear();
        Console.WriteLine("Informe o código do cliente");
        var codigo = Console.ReadLine();

        if (!int.TryParse(codigo, out var id))
        {
            Console.WriteLine("Código inválido! [Enter]");
            Console.ReadKey();
            return;
        }

        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        Console.WriteLine("Nome do cliente: ");
        var nome = Console.ReadLine();
        Console.WriteLine(Environment.NewLine);

        var dataNascimento = LerDataNascimento();
        Console.WriteLine(Environment.NewLine);

        var desconto = LerDesconto();
        Console.WriteLine(Environment.NewLine);

        cliente.Nome = nome;
        cliente.DataNascimento = dataNascimento;
        cliente.Desconto = desconto;

        GravarDadosClientes();

        Console.WriteLine("Cliente alterado com sucesso! [Enter]");
        ImprimirCliente(cliente);
        Console.ReadKey();
    }

    public void ImprimirCliente(Cliente cliente)
    {
        Console.WriteLine("ID.............: " + cliente.Id);
        Console.WriteLine("Nome...........: " + cliente.Nome);
        Console.WriteLine("Desconto.......: " + cliente.Desconto.ToString("0.00"));
        Console.WriteLine("Data Nascimento: " + cliente.DataNascimento);
        Console.WriteLine("Data Cadastro..: " + cliente.CadastradoEm);
        Console.WriteLine("------------------------------------");
    }

    public void ExcluirCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        if (!int.TryParse(codigo, out var id))
        {
            Console.WriteLine("Código inválido!");
            Console.ReadKey();
            return;
        }

        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado!");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        clientes.Remove(cliente);

        GravarDadosClientes();

        Console.WriteLine("Cliente removido com sucesso!");
        Console.ReadKey();
    }

    public void ExibirClientes()
    {
        Console.Clear();
        foreach (var cliente in clientes)
        {
            ImprimirCliente(cliente);
        }
        Console.ReadKey();
    }

    public void GravarDadosClientes()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(clientes);

        File.WriteAllText("clientes.txt", json);
    }

    public void LerDadosClientes()
    {
        if (File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("clientes.txt");

            if (string.IsNullOrWhiteSpace(dados))
            {
                return;
            }

            try
            {
                var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

                if (clientesArquivo != null)
                {
                    clientes.AddRange(clientesArquivo);
                }
            }
            catch (System.Text.Json.JsonException)
            {
                Console.WriteLine("Arquivo clientes.txt inválido. Iniciando sem dados. [Enter]");
                Console.ReadKey();
            }
        }

    }

}