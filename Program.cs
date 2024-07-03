//Screm sound
string mensagemeBoasVindas = "Boas vindas ao Screm Sound";
List<string> ListaDasBandas = new List<string>();  

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); //o dictionary "dicionario" vai receber valores de 
bandasRegistradas.Add("lupa", new List<int> {10, 8, 6}); //esses numeros são as notas
bandasRegistradas.Add("papa", new List<int>());


void exibirStatus()
{
    string mensagem = "bem vindo!";
    Console.WriteLine(mensagem);

}

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("digite 2 para mostrar todas as bandas");
    Console.WriteLine("digite 3 para avaliar uma banda");
    Console.WriteLine("digite 4 para ver a media da banda");
    Console.WriteLine("digite 0 para sair");

    string opsecolhida = Console.ReadLine()!;
    int opsescolhidaint = int.Parse(opsecolhida);

    switch (opsescolhidaint)
    {
        case 1: registrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: avaliarUmaBanda();
            break;
        case 4: Console.WriteLine("você escolheu a opção: " + opsescolhidaint);
            break;
        case 0: Console.WriteLine("tchau tchau.... " + opsescolhidaint);
            break; 
    }
}

void registrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("registro das bandas");
    Console.Write("digite o nome da banda que dejesa registrar: ");    //a diferença de write e writeLine é a quebra de linha
    string NomeDaBanda = Console.ReadLine()!; // a esclamação (!) que dizer que não queremos valores null 
    ListaDasBandas.Add(NomeDaBanda);
    Console.WriteLine($"A banda {NomeDaBanda} foi Registrada"); //o $ é usado para indicar que vai ser usado uma variavel dentro da string
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

ExibirOpcoesDoMenu();

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo bandas registradas");
    for (int i = 0; i < ListaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda:  {ListaDasBandas[i]}");
    }
    Console.WriteLine("aperte qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();

}

void ExibirTituloDaOpcao(string titulo)
{
    int quantiddaeDLetras = titulo.Length;
    string asteristicos = string.Empty.PadLeft(quantiddaeDLetras, '*');
    Console.WriteLine(titulo);
    Console.WriteLine(asteristicos + "\n")  ;
}

void avaliarUmaBanda()
{
    //digitar a banda que dejesa avalivar
    //se a banda existe no dicionario >> atribuir uma nota
    //senão volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("avaliar banda");
    Console.Write("digite o nome da banda que deseja avaliar"); //digita a banda que quer avaliar
    string nomeDaBanda = Console.ReadLine()!; //pegar o nome da banda que o usuario quer avaliar
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) //Containskey é ultilizado para verificar ser existe contem alguma chave(valor) exitente na viriavel 
    {
        Console.Write($"qual a nota que você da a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine())!; // quando exclamação é etribuida é porquer o valor não pode ser nulo na aplicação
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\na nota {nota} foi atribuida a {nomeDaBanda} com sucesso. ");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\na banda {nomeDaBanda} não foi encontrada"); //o \n serve para dar um espaço
        Console.WriteLine("aperte em qualquer tecla para voltar ao menu");
        Console.ReadKey(true);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}