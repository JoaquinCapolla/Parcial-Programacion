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
    public partial class Form1 : Form
    {
        List<Departamento> departamento = new List<Departamento>();
        List<Temperatura> temperatura = new List<Temperatura>();
        public Form1()
        {
            InitializeComponent();
            Leer();
            for(int i = 0; i < departamento.Count; i++)
            {
                cmb_departamentos.Items.Add(departamento[i].Nombre);
            }
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
        private void Guardar()
        {
            File.Delete("Temperatura.txt");
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamWriter writer1 = new StreamWriter(appPath + "\\Temperatura.txt", true);

            for (int i = 0; i < temperatura.Count; i++)
            {
                writer1.WriteLine(temperatura[i].Numero);
                writer1.WriteLine(temperatura[i].Temp);
                writer1.WriteLine(temperatura[i].Fecha);
            }
            writer1.Close();
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
        private void btn_almacenar_Click(object sender, EventArgs e)
        {
            Leer();
            Leer1();
            Temperatura temperaturaTemp = new Temperatura();
            int num=0;
            temperaturaTemp.Numero = cmb_departamentos.SelectedIndex + 1;
            temperaturaTemp.Temp = Convert.ToInt32(txt_temperatura.Text);
            temperaturaTemp.Fecha = mnt_fecha.SelectionStart;
            temperatura.Add(temperaturaTemp);
            cmb_departamentos.Text = "";
            txt_temperatura.Text = "";
            Guardar();
        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            frm.Show();
        }
    }
}
