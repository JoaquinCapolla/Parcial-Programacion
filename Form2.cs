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
        List<Datos> datos = new List<Datos>();
        public Form2()
        {
            InitializeComponent();
            Leer();
            Leer1();
            Guardar();
            Mostrar();
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
                temperaturaTemp.Temp = Convert.ToInt32(reader1.ReadLine());
                temperaturaTemp.Fecha = Convert.ToDateTime(reader1.ReadLine());
                temperatura.Add(temperaturaTemp);
            }
            reader1.Close();
        }
        private void Guardar()
        {
            for (int i = 0; i < temperatura.Count; i++)
            {
                for (int j = 0; j < departamento.Count; j++)
                {
                    if (departamento[j].Numero == temperatura[i].Numero)
                    {
                        Datos datosTemp = new Datos();
                        datosTemp.Nombre = departamento[j].Nombre;
                        datosTemp.Temp = temperatura[i].Temp;
                        datosTemp.Fecha = temperatura[i].Fecha;
                        datos.Add(datosTemp);
                    }
                }
            }
        }
        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();
        }
        private void cmb_orden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_orden.SelectedIndex == 0)
            {
                int cont = 0; ;
                for (int i = 0; i < datos.Count; i++)
                {
                    for (int j = 0; j < datos.Count - 1; j++)
                    {
                        if (datos[j].Temp > datos[j+1].Temp)
                        {
                            Datos datosTemp = new Datos();

                            datosTemp.Nombre = datos[j + 1].Nombre;
                            datosTemp.Temp = datos[j + 1].Temp;
                            datosTemp.Fecha = datos[j + 1].Fecha;
                            datos[j + 1].Nombre = datos[j].Nombre;
                            datos[j + 1].Temp = datos[j].Temp;
                            datos[j + 1].Fecha = datos[j].Fecha;
                            datos[j].Nombre = datosTemp.Nombre;
                            datos[j].Temp = datosTemp.Temp;
                            datos[j].Fecha = datosTemp.Fecha;
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        break;
                    }
                }
                Mostrar();
            }
            else if (cmb_orden.SelectedIndex == 1)
            {
                int cont = 0; ;
                for (int i = 0; i < datos.Count; i++)
                {
                    for (int j = 0; j < datos.Count - 1; j++)
                    {
                        if (datos[j].Temp < datos[j + 1].Temp)
                        {
                            Datos datosTemp = new Datos();

                            datosTemp.Nombre = datos[j + 1].Nombre;
                            datosTemp.Temp = datos[j + 1].Temp;
                            datosTemp.Fecha = datos[j + 1].Fecha;
                            datos[j + 1].Nombre = datos[j].Nombre;
                            datos[j + 1].Temp = datos[j].Temp;
                            datos[j + 1].Fecha = datos[j].Fecha;
                            datos[j].Nombre = datosTemp.Nombre;
                            datos[j].Temp = datosTemp.Temp;
                            datos[j].Fecha = datosTemp.Fecha;
                            cont++;
                        }
                    }
                    if (cont == 0)
                    {
                        break;
                    }
                }
                Mostrar();
            }
            else if (cmb_orden.SelectedIndex == 2)
            {
                int x = 0;
                int suma = 0;
                for(int i = 0; i < datos.Count; i++)
                {
                    suma = suma + datos[i].Temp;
                    x++;
                }
                suma = suma / x;
                label3.Text = suma.ToString();
            }
        }
    }
}
