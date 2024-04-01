namespace ExercicioCarro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Grupo:
            //Ana Luísa Gato de Lara
            //Heitor Krawczuk Mota
            //Ricardo Amaro Ferreira da Silva


            static void Faz_Linha()
            {
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }

            ConsoleKeyInfo tecla;
            Carro carro = new Carro("Volkswagen", "Fusca");

            carro.ignicao.SetIgnicao(true, carro.acelerador.GetVelocidade(), carro.cambio.GetMarcha());

            while (carro.ignicao.GetLigado())
            {
                Console.Clear();
                Faz_Linha();
                Console.WriteLine("| O carro está: {0, -22} |", "Ligado");
                Console.WriteLine("| Velocidade: {0,-12}  Marcha: {1}  |", carro.acelerador.GetVelocidade().ToString("N2") + " Km/h", carro.cambio.GetMarcha().ToString("0"));
                Console.WriteLine("| Ângulo de direção: {0,-17} |", carro.direcao.GetAngulo() + "º");
                Faz_Linha();
                Console.WriteLine();
                Console.Write("Dê um comando: ");
                tecla = Console.ReadKey();
                

                switch(tecla.Key) 
                {
                    //engatar a 1ª marcha 
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if(carro.cambio.GetMarcha() == 0)
                        {
                            carro.cambio.SetMarcha(1);
                        }
                        break;

                    //acelerar
                    case ConsoleKey.UpArrow:
                        carro.acelerador.SetVelocidade(1f, carro.acelerador.GetVelocidade(), carro.ignicao.GetLigado(), carro.cambio.GetMarcha(), carro.freio.GetFreio());
                        carro.cambio.AlterarMarcha(carro.acelerador.GetVelocidade());
                        break;

                    //desacelerar
                    case ConsoleKey.DownArrow:
                        carro.acelerador.SetVelocidade(-1f, carro.acelerador.GetVelocidade(), carro.ignicao.GetLigado(), carro.cambio.GetMarcha(), carro.freio.GetFreio());
                        carro.cambio.AlterarMarcha(carro.acelerador.GetVelocidade());
                        break;

                    //decrementar ângulo da direção (virar para a esquerda)
                    case ConsoleKey.LeftArrow:
                        carro.direcao.Decrementa_Angulo();
                        carro.Rodas[0].SetAngulo(carro.direcao.GetAngulo());
                        carro.Rodas[1].SetAngulo(carro.direcao.GetAngulo());
                        break;

                    //incrementar ângulo da direção (virar para a direita)
                    case ConsoleKey.RightArrow:
                        carro.direcao.Incrementa_Angulo();
                        carro.Rodas[0].SetAngulo(carro.direcao.GetAngulo());
                        carro.Rodas[1].SetAngulo(carro.direcao.GetAngulo());
                        break;

                    //frear
                    case ConsoleKey.Spacebar:
                        carro.freio.SetFreio(true);
                        carro.acelerador.SetVelocidade(0f, carro.acelerador.GetVelocidade(), carro.ignicao.GetLigado(), carro.cambio.GetMarcha(), carro.freio.GetFreio());
                        carro.cambio.AlterarMarcha(carro.acelerador.GetVelocidade());
                        carro.freio.SetFreio(false);
                        break;

                    //desligar o carro 
                    case ConsoleKey.Escape:
                        carro.ignicao.SetIgnicao(false, carro.acelerador.GetVelocidade(), carro.cambio.GetMarcha());
                        break;

                    default:
                        carro.ignicao.SetIgnicao(false, carro.acelerador.GetVelocidade(), carro.cambio.GetMarcha());
                        break;

                }

            }

            Console.Clear();
            Faz_Linha();
            Console.WriteLine("| O carro está: {0, -22} |", "Desligado");
            Console.WriteLine("| Velocidade: {0,-12}  Marcha: {1}  |", carro.acelerador.GetVelocidade().ToString("N2") + " Km/h", carro.cambio.GetMarcha().ToString("0"));
            Console.WriteLine("| Ângulo de direção: {0,-17} |", carro.direcao.GetAngulo() + "º");
            Faz_Linha();
            Console.WriteLine();
            Console.Write("Aperte qualquer tecla para encerrar. ");
            Console.ReadKey();
        }
    }
}