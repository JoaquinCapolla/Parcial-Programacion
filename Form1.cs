using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_Programacion
{
    public partial class Form1 : Form
    {
        List<DatosAutos> datosAutos = new List<DatosAutos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Leer()
        {
            datosAutos.Clear();
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamReader reader1 = new StreamReader(appPath + "\\DatosAutos.txt");
            while (reader1.Peek() > -1)
            {
                DatosAutos datosautosTemp = new DatosAutos();

                datosautosTemp.Placa = reader1.ReadLine();
                datosautosTemp.Marca = reader1.ReadLine();
                datosautosTemp.Modelo = reader1.ReadLine();
                datosautosTemp.Color = reader1.ReadLine();
                datosautosTemp.Precio = Convert.ToInt32(reader1.ReadLine());
                datosAutos.Add(datosautosTemp);
            }
            reader1.Close();
        }
        private void btn_almacenar_Click(object sender, EventArgs e)
        {

        }
    }
}
