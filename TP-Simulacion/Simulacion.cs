using System;
using TP_Simulacion;

namespace TP_Simulacion
{
    public class Simulacion
    {
        double TPC;
        double TREP;
        double T;
        double TFINAL;
        double VB;
        double [] contadoresEscalas;
        double BLSAFUERA;
        Random random;

        public void inicializar()
        {
            T = 0;
            TPC = 1;
            TFINAL = 365;
            TREP = 35;
            VB = 500000;
            random = new Random();
            contadoresEscalas = new double[13];
            contadoresEscalas.Initialize();
        }

        public int escalaSegunVolumen(double Vol)
        {
            if (Vol.IsBetween(10, 70)) { return 1; }
            else if (Vol.IsBetween(71, 140)) { return 2; }
            else if (Vol.IsBetween(141, 200)) { return 3; }
            else if (Vol.IsBetween(201, 250)) { return 4; }
            else if (Vol.IsBetween(251, 300)) { return 5; }
            else if (Vol.IsBetween(301, 350)) { return 6; }
            else if (Vol.IsBetween(351, 400)) { return 7; }
            else if (Vol.IsBetween(401, 450)) { return 8; }
            else if (Vol.IsBetween(451, 550)) { return 9; }
            else if (Vol.IsBetween(551, 1000)) { return 10; }
            else if (Vol.IsBetween(1001, 1500)) { return 11; }
            else if (Vol.IsBetween(1501, 2000)) { return 12; }
            else if (Vol >= 2001) { return 13; }
            else { return 0; }
        }

        public void contabilizarloEnLaEscala(double VolCompra, int escala)
        {
            contadoresEscalas[escala-1] = contadoresEscalas[escala-1] + VolCompra;
        }

        public double generoIC()
        {
            return 0.7;
        }

        public double generoVolumenCompraLA()
        {
            double x1;
            double y1;
            while (true)
            {
                double R1 = random.NextDouble();
                double R2 = random.NextDouble();
                x1 = 4496 * R1 + 4;
                y1 = 100 * R2;
                if ((1 / 4496) >= y1)
                {
                    break; 
                }
            }

            return x1;
        }

        public double generoVolumenCompraF()
        {
            double x1;
            double y1;
            while (true)
            {
                double R1 = random.Next();
                double R2 = random.Next();
                x1 = 4449 * R1 + 1;
                y1 = 50 * R2;
                if ((1 / 4449) >= y1)
                {
                    break;
                }
            }

            return x1;
        }

        public void comenzarSimulacion()
        {
            inicializar();
            while (T <= TFINAL)
            {
                if (TPC <= TREP) //me compran
                {
                    T = TPC;
                    double IC = generoIC();
                    TPC = T + IC;
                    Console.Write(TPC.ToString());
                    double R = random.NextDouble();
                    if (R <= 0.16)
                    {
                        double VolumenCompraLA = generoVolumenCompraLA();
                        if (VB >= VolumenCompraLA)
                        {
                            if (VB < 10)
                            {
                                BLSAFUERA = BLSAFUERA + VB;
                            }
                            else
                            {
                                VB = VB - VolumenCompraLA;
                                contabilizarloEnLaEscala(VolumenCompraLA, escalaSegunVolumen(VolumenCompraLA));
                                Console.WriteLine("me compro LA");
                            }
                        }
                        else
                        {
                            Console.WriteLine("again");
                        }
                    }

                    else if (R <= 0.86)
                    {
                        double VolumenCompraF = generoVolumenCompraF();
                        if (VB >= VolumenCompraF)
                        {
                            if (VB < 10)
                            {
                                BLSAFUERA = BLSAFUERA + VB;
                            }
                            else
                            {
                                VB = VB - VolumenCompraF;
                                contabilizarloEnLaEscala(VolumenCompraF, escalaSegunVolumen(VolumenCompraF));
                                Console.WriteLine("me compro F");
                            }
                        }
                        else
                        {
                            Console.WriteLine("again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("again");
                    }
                }
                else  //tiempo de reponer bolsas
                {
                    T = TREP;
                    TREP = T + 35;
                    VB = VB + 500000;
                    Console.WriteLine("repongo");
                }
            
            }

            for (int j = 0; j < 13; j++)
            {
                Console.WriteLine(contadoresEscalas[j]);
            }
            Console.Write(BLSAFUERA.ToString());
        }
    }
}





