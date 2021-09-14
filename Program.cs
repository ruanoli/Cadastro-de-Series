using System;

namespace Cadastro_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio(); //Herdando de SerieRepositorio 

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao sistema de Cadastro de Séries!");
            Console.WriteLine();
            string opcaoUsuario = ObterOpcaoUsuario();

            //Enquanto o usuário não apertar o "X" para sair, o looping continuará.
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            } 
            Console.WriteLine("Obrigado por utilizar nosso serviço!");
            Console.ReadLine();
        }
    
/*  - Mostra as séries adicionadas e seus respectivos Id's e títulos;
    - Se a lista estiver vazia, o usuário será informado;
    - Se a série for excluída ela ficará marcada na lista como *Excluída*.
    */
    private static void ListarSeries()
    {
        Console.WriteLine("Lista de séries cadastradas:");
        
        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }

        foreach( var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            Console.WriteLine("ID {0} - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluìda*" : ""));
        }
    }

/*  - Adicionará uma nova série à lista;
    - Pegará o número atribuído a cada gênero no enum, que servirá como um acesso para selecioná-los;
    - O usuário digitará como entrada o gênero, título, ano, descrição e temporadas da sére;
    - Ao cadastrar uma nova série ela irá gerar um novo número de ID em ordem crescente, graças ao método ProximoId().
    */
    private static void InserirSerie()
    {
        Console.Clear();

        foreach( int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.WriteLine();
        Console.WriteLine("Digite o número que corresponde ao gênero desejado entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o título da série: ");

        string entradaTitulo =  Console.ReadLine();

        Console.WriteLine("Digite o ano da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a descrição da série: ");
        string entradaDescricao =  Console.ReadLine();

        Console.WriteLine("Digite a quantidade de temporadas da série:");
        int entradaTemporada = int.Parse(Console.ReadLine());

        Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao,
                                    temporadas: entradaTemporada);
        repositorio.Insere(novaSerie);

    }

/*  - Edita as séries já adicionadas à lista;
    - A série é selecionada pelo seu ID;
    - Podendo alterar seu Gênero, título, ano, descrição e quant de temporadas.
    */
    private static void AtualizarSerie()
    {
        Console.WriteLine("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach( int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.WriteLine("Digite o número que corresponde ao gênero desejado entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o título da série: ");
        string entradaTitulo =  Console.ReadLine();

        Console.WriteLine("Digite o ano da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a descrição da série: ");
        string entradaDescricao =  Console.ReadLine();

        Console.WriteLine("Digite a quantidade de temporadas da série:");
        int entradaTemporada = int.Parse(Console.ReadLine());

        Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao,
                                    temporadas: entradaTemporada);
        repositorio.Atualizar(indiceSerie, atualizaSerie);
    }

/*  - Marca uma série já cadastrada como excluída;
    - Selecionamos a série que queremos excluir pelo ID;
    - Será exibida uma mensagem para o usuário confirmar se quer prosseguir ou não com a exclusão da série;
    - Apenas marca como excluída, não exclui a série da memória.
    */
    private static void ExcluirSerie()
    {
        Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());
        
        Console.Clear();

        Console.WriteLine("Você confirma a exclusão desse item? Digite 'S' para sim ou 'N' para não.");
        string confirmaExclusao = Console.ReadLine().ToUpper();

        do 
        {
            switch(confirmaExclusao)
            {
                case "S":
                    Console.WriteLine();
                    Console.WriteLine("SÉRIE EXCLUÍDA!");
                    Console.WriteLine();
                    repositorio.Excluir(indiceSerie);
                    break;
                
                case "N":
                    Console.WriteLine();
                    Console.WriteLine("OPERAÇÃO CANCELADA!");
                    Console.WriteLine();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException("ERRO! Digite apenas as teclas 'S' ou 'N'");
            }
        } while (confirmaExclusao.ToUpper() != "S" && confirmaExclusao.ToUpper() != "N");
    }

/*  - Mostra todos os atributos da série selecionada devidamente preenchidos;
    - A série é selecionada pelo seu ID.
    */
    private static void VizualizarSerie()
    {
        Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        Console.Clear();

        var serie = repositorio.RetornaPorId(indiceSerie);
        Console.WriteLine(serie);
    }

        //Orientação para o usuário
        private static string ObterOpcaoUsuario()
        { 
            Console.WriteLine();
            Console.WriteLine("INFORME A OPÇÃO DESEJADA: ");
            Console.WriteLine("1 - Lista de séries.");
            Console.WriteLine("2 - Inserir nova série.");
            Console.WriteLine("3 - Editar série.");
            Console.WriteLine("4 - Excluir série.");
            Console.WriteLine("5 - Vizualizar série.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}