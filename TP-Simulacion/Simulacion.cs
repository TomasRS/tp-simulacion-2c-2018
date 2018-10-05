using System;
using TP_Simulacion;

namespace TP_Simulacion
{
    public class Simulacion
    {
        int TPC;
        int TREP;
        int T;
        int TFINAL;
        int VB;
        int[] contadoresEscalas;

        public void inicializar()
        {
            T = 0;
            TFINAL = 175;
            TREP = 35;
            contadoresEscalas = new int[13];
            contadoresEscalas.Initialize();
        }

        public int escalaSegunVolumen(int Vol)
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

        public void contabilizarloEnLaEscala(int VolCompra, int escala)
        {
            contadoresEscalas[escala] = contadoresEscalas[escala] + VolCompra;
        }

        public int generoIC()
        {
            //TODO: Logica
            return 0;
        }

        public double generoR()
        {
            return 0;
        }

        public int generoVolumenCompra()
        {
            //TODO: Logica
            return 0;
        }

        public void comenzarSimulacion()
        {
            inicializar();
            while (T <= TFINAL)
            {
                if (TPC <= TREP) //me compran
                {
                    T = TPC;
                    int IC = generoIC();
                    TPC = T + IC;
                    double R = generoR();
                    if (R <= 0.16)
                    {
                        int VolumenCompraLA = generoVolumenCompra();
                        if (VB >= VolumenCompraLA)
                        {
                            VB = VB - VolumenCompraLA;
                            contabilizarloEnLaEscala(VolumenCompraLA, escalaSegunVolumen(VolumenCompraLA));
                        }
                        else
                        {
                            //volver al while
                        }
                    }

                    else if (R <= 0.86)
                    {
                        int VolumenCompraF = generoVolumenCompra();
                        if (VB >= VolumenCompraF)
                        {
                            VB = VB - VolumenCompraF;
                            contabilizarloEnLaEscala(VolumenCompraF, escalaSegunVolumen(VolumenCompraF));
                        }
                        else
                        {
                            //volver al while
                        }
                    }
                    else
                    {
                        //volver al while
                    }
                }
                else  //tiempo de reponer bolsas
                {
                    T = TREP;
                    TREP = T + 35;
                    VB = VB + 500000;
                }
            }
        }
    }
}

    

