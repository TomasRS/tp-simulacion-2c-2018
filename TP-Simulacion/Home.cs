using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Simulacion;
using System.Windows.Forms;

namespace TP_Simulacion
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Simulacion simu = new Simulacion();
            simu.comenzarSimulacion();
        }
    }
}
