using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerHerramientas
{
    public partial class Form1 : Form
    {
        // lista para almacenar estudiantes

        private List<Estudiante> estudiantes = new List<Estudiante> ();
        public Form1()
        {
            InitializeComponent();
        }

        // validar el nombre
        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new NombreInvalidoException("El nombre no puede estar vacio o ser nulo");
            }

            if (nombre.Length >= 3 || ! nombre.All(char.IsLetter))
            {
                throw new NombreInvalidoException("El nombre debe tener solo letras y al menos 3 caracteres");
            }
        }

        private bool ValidarEdad(string edadTexto, out int edad)
        {
            // parsear la edad
            return int.TryParse(edadTexto, out edad) && edad >= 15 && edad <= 100;
        }

        private bool ValidarPromedio(string promedioTexto, out double promedio)
        {
            if (double.TryParse(promedioTexto, out promedio) && promedio >= 0 && promedio <= 10)
            {
                return true;
            }
            return false;
            //return bool.TryParse(promedioTexto, out promedio) && promedio >= 0 && promedio <= 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim(); // quitar el trim para ver qué pasa

                int edad;

                double promedio;

                ValidarNombre(nombre);

                if (!ValidarEdad(txtEdad.Text, out edad)) 
                {
                    MessageBox.Show("La edad debe estar entre los 15 y 100 años. ");
                    return;
                }

                if(!ValidarPromedio(txtPromedio.Text, out promedio))
                {
                    MessageBox.Show("El promedio debe estar entre 0 y 10");
                    return;
                }
            }
            catch { }
        }
    }
}
