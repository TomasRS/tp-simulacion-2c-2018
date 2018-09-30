namespace TP_Simulacion
{
    public class Simulacion
    {
        int TPC;
        int TRED;
        int T;
        int VB;

        public void cargarEscalas()
        {
            //TODO: Logica
        }

        public int generoIC()
        {
            //TODO: Logica
            return 0;
        }

        public int generoR()
        {
            //TODO: Logica
            return 0;
        }

        public int generoVolumenCompra()
        {
            //TODO: Logica
            return 0;
        }

        public void comenzarSimulacion()
        {
            cargarEscalas();
            if(TPC <= TRED)
            {
                T = TPC;
                int IC = generoIC();
                TPC = T + IC;
                int R = generoR();
                if(R <= ___)
                {
                    int VolumenCompraLD = generoVolumenCompra();
                    if(VB >= VolumenCompraLD)
                    {
                        VB = VB - VolumenCompraLD;
                        //Ubicarlo en la escala
                    }
                    else
                    {
                        //No se ve el diagrama
                    }
                }
                else
                {
                    if(R <= ___)
                    {
                        int VolumenCompraF = generoVolumenCompra();
                        if(VB >= VolumenCompraF)
                        {
                            VB = VolumenCompraF;
                            //Ubicarlo en la escala
                        }
                        else
                        {
                            //El diagrama no muestra nada
                        }
                    }
                    else
                    {
                        //El diagrama no muestra nada
                    }
                }
            }
        }
    }
}
