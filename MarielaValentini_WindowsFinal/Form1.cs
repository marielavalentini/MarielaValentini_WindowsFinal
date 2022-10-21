using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MarielaValentini_WindowsFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            validarLongitud(nombre);
            string apellido = txtApellido.Text;
            validarLongitud(apellido);
            decimal sueldo = Convert.ToDecimal(txtSueldo.Text);
            validarSueldo(sueldo);
            string puesto = txtPuesto.Text.ToUpper();
            validarPuesto(puesto);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            decimal sueldo = Convert.ToDecimal(txtSueldo.Text);
            validarSueldo(sueldo);
            string puesto = txtPuesto.Text.ToUpper();

            imprimir(nombre, apellido, puesto);
        }

        private void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            int[] horasTrabajadasSemana = new int[5];
            int suma = 0;

            cargarArreglo(horasTrabajadasSemana);

            for(int i= 0; i < horasTrabajadasSemana.Length; i++)
            {
                suma = horasTrabajadasSemana[i] + suma;
            }

            double promedio = horasTrabajadasSemana.Average();
            int contador = contarDias(horasTrabajadasSemana);

            MessageBox.Show("El total de horas trabajadas es: " + suma + "\nEl promedio de las horas trabajadas esta semana es: " + promedio + "\nEsta semana se trabajaron  " + contador + " dias menos de 4 hs diarias");
          
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        #region Metodos

        public void cargarDatos ()
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            decimal sueldo = Convert.ToDecimal(txtSueldo.Text);
            validarSueldo(sueldo);
            string puesto = txtPuesto.Text.ToUpper();
            validarPuesto(puesto);
        }

        //metodos para validaciones

        private void validarSueldo (decimal sueldo)
        {
            if (sueldo <= 0)
            {
                MessageBox.Show("ERROR, EL SUELDO INGRESADO DEBE SER MAYOR A CERO. POR FAVOR INTENTE NUEVAMENTE");
            }
        }

        private void validarPuesto (string puesto)
        {
            if(puesto == "SOPORTE TECNICO" || puesto == "DBA" || puesto == "DESARROLLADOR")
            {
                MessageBox.Show("PUESTO INGRESADO CORRECTAMENTE");
            }else
            {
                MessageBox.Show("ERROR AL INGRESAR EL PUESTO, DEBE INGRESAR ALGUNA DE LAS SIGUIENTES OPCIONES: \n\nSOPORTE TECNICO \nDBA \nDESARROLLADOR");
            }
        }

        private void validarLongitud (string nombre)
        {
            if(nombre.Length < 2)
            {
                MessageBox.Show("ERROR \nLos datos ingresados deben tener mas de dos caracteres");
            }else if(nombre.Length > 50)
            {
                MessageBox.Show("ERROR \nLos datos ingresados deben tener menos de 50 caracteres");
            }
        }

        //

        public void imprimir (string nombre, string apellido, string puesto)
        {
             MessageBox.Show("Nombre: " + nombre.ToUpper() + "\nApellido: " + apellido.ToUpper() + "\nPuesto: " + puesto);
        }

        public void cargarArreglo (int[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                int horasDiarias = Convert.ToInt32(Interaction.InputBox("Ingrese las horas trabajadas diariamente"));
                arreglo[i] = horasDiarias;
            }
        }
        public int contarDias(int[] arreglo)
        {
            int contador = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] < 4)
                {
                    contador++;
                }
            }
            return contador;
        }
        public void limpiar ()
        {
            txtNombre.Clear();
            txtApellido.Clear();    
            txtSueldo.Clear();
            txtPuesto.Clear();
        }
        #endregion
    }
}
