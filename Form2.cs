using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_Programacion
{
    public partial class Form2 : Form
    {
        List<Departamento> departamento = new List<Departamento>();
        List<Temperatura> temperatura = new List<Temperatura>();
        public Form2()
        {
            InitializeComponent();
            Leer();
        }
        private void Leer()
        {
            departamento.Clear();
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamReader reader1 = new StreamReader(appPath + "\\Departamentos.txt");
            while (reader1.Peek() > -1)
            {
                Departamento departamentoTemp = new Departamento();

                departamentoTemp.Numero = Convert.ToInt32(reader1.ReadLine());
                departamentoTemp.Nombre = reader1.ReadLine();
                departamento.Add(departamentoTemp);
            }
            reader1.Close();
        }
        private void Leer1()
        {
            temperatura.Clear();
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamReader reader1 = new StreamReader(appPath + "\\Temperatura.txt");
            while (reader1.Peek() > -1)
            {
                Temperatura temperaturaTemp = new Temperatura();

                temperaturaTemp.Numero = Convert.ToInt32(reader1.ReadLine());
                temperaturaTemp.Temp = float.Parse(reader1.ReadLine());
                temperaturaTemp.Fecha = Convert.ToDateTime(reader1.ReadLine());
                temperatura.Add(temperaturaTemp);
            }
            reader1.Close();
        }
        private void cmb_orden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
