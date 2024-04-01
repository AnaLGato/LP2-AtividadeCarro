using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCarro
{
    internal class Carro
    {
        //Atributos da classe Carro
        public string Fabricante;
        public string Modelo;
        public Direcao direcao;
        public Roda[] Rodas = new Roda[4];
        public Ignicao ignicao;
        public Acelerador acelerador;
        public Freio freio;
        public Cambio cambio;
        
        public Carro(string fabricante, string modelo) //método construtor
        { 
            Fabricante = fabricante;
            Modelo = modelo;
            direcao = new Carro.Direcao();
            Rodas[0] = new Carro.Roda("Frontal","Esquerda", 0f);
            Rodas[1] = new Carro.Roda("Frontal", "Direita", 0f);
            Rodas[2] = new Carro.Roda("Traseira", "Esquerda", 0f);
            Rodas[3] = new Carro.Roda("Traseira", "Direita", 0f);
            ignicao = new Carro.Ignicao();
            acelerador = new Carro.Acelerador();
            freio = new Carro.Freio();
            cambio = new Carro.Cambio();
        }

        //Classe Direção
        internal class Direcao
        {
            public float Angulo;

            public Direcao() //construtor
            {
                Angulo = 0;
            }

            public void SetAngulo(float angulo)
            {
                Angulo = angulo;
            }
            public float GetAngulo()
            {
                return Angulo; 
            }

            public void Incrementa_Angulo()
            {
                if (Angulo + 5 <= 30)
                {
                    Angulo += 5;
                }
            }
            public void Decrementa_Angulo()
            {
                if (Angulo - 5 >= -30)
                {
                    Angulo -= 5;
                }
            }
        }

        //Classe Roda
        internal class Roda
        {

            public string PosLong; //"Frontal" ou "Traseira"
            public string PosTrans; //"Esquerda" ou "Direita"
            public float Angulo;

            //método construtor:
            public Roda(string posLong, string posTrans, float angulo) //o ângulo passado como parâmetro deve ser o mesmo ângulo da direção
            {
                PosTrans = posTrans;
                PosLong = posLong;

                if(posLong == "Frontal")
                {
                    Angulo = angulo;
                }
                else
                {
                    Angulo = 0f;
                }
            }

            public void SetAngulo(float angulo)
            {
                Angulo = angulo;
            }
        }

        //Classe Ignição
        internal class Ignicao
        {
            public bool Ligado;

            public Ignicao()
            {
                Ligado = false;
            }

            public bool GetLigado()
            {
                return Ligado; 
            }
            public void SetIgnicao(bool ligado, float velocidade, int marcha)
            {
                if(ligado == true && Ligado == false)
                {
                    Ligado = ligado;
                }
                else
                {
                    if(Ligado && !ligado && velocidade == 0f && marcha == 0)
                    {
                        Ligado = ligado;
                    }
                }
            }
        }

        //Classe Acelerador
        internal class Acelerador
        {
            public float Velocidade;

            public Acelerador() //método construtor
            {
                Velocidade = 0f;
            }

            public float GetVelocidade()
            {
                return Velocidade;
            }

            public void SetVelocidade(float num, float velocidade, bool ligado, int marcha, bool freio)
            {
                if (freio && velocidade != 0)
                {
                    Velocidade = 0f;
                }
                else
                {
                    if (ligado && marcha != 0 && velocidade + num <= 120 && velocidade + num >= 0)
                    {
                        Velocidade += num;
                    }
                }
                
            }

        }

        //Classe Freio
        internal class Freio
        {
            public bool FreioAcionado;

            public Freio() // método construtor
            {
                FreioAcionado = false;   
            }

            public bool GetFreio()
            {
                return FreioAcionado;
            }

            public void SetFreio(bool freioAcionado)
            {
                FreioAcionado = freioAcionado;
            }
        }

        //Classe Câmbio
        internal class Cambio
        {
            public int Marcha;

            public Cambio() //método construtor
            {
                Marcha = 0;
            }

            public int GetMarcha()
            {
                return Marcha;
            }

            public void SetMarcha(int marcha)
            {
                Marcha = marcha;
            }
            public int AlterarMarcha(float velocidade)
            {
                switch (velocidade)
                {
                    //Ponto morto
                    case 0:
                        return Marcha = 0;
                    break;

                    
                    case >= 1:
                        if (velocidade <= 20) //1º Marcha
                        { return Marcha = 1; }
                        else 
                        {
                            if (velocidade <= 40) //2º Marcha
                            { return Marcha = 2; }
                            else 
                            { 
                                if (velocidade <= 50) //3º Marcha 
                                { return Marcha = 3; } 
                                else
                                {
                                    if (velocidade <= 60) //4º Marcha
                                    { return Marcha = 4; }
                                    else
                                    {
                                       return Marcha = 5; //5º Marcha <= 120 
                                    }
                                }
                            }
                        }
                     break;

                    default: return Marcha;
                }
            }
        }
    }
}
