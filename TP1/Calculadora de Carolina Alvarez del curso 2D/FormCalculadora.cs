using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            List<string> listaResultadoOperaciones = new List<string>();
        }

        /// <summary>
        /// Setea los valores de los text box, el comboBox y la label en vacío o 0
        /// </summary>
        private void Limpiar()
        {
            textBoxOperando1.Text = "";
            textBoxOperando2.Text = "";
            comboBoxOperando.Text = null;
            lblResultado.Text = "0";
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            comboBoxOperando.Items.Add("+");
            comboBoxOperando.Items.Add("-");
            comboBoxOperando.Items.Add("/");
            comboBoxOperando.Items.Add("*");
            Limpiar();

        }

        /// <summary>
        /// Llama al método de Calculadora "Operar" para realizar una operación matemática
        /// </summary>
        /// <param name="numero1">Primer Operando</param>
        /// <param name="numero2">Segundo Operando</param>
        /// <param name="operador">Operador de operación matemática a realizar</param>
        /// <returns>Resultado de operación matemática</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando ingreso1 = new Operando(numero1);
            Operando ingreso2 = new Operando(numero2);
            double resultado;
            char operadorChar;
            char.TryParse(operador, out operadorChar);

            resultado = Calculadora.Operar(ingreso1, ingreso2, operadorChar);

            return resultado;
        }

        /// <summary>
        /// Al hacer click en Operar toma los valores del form para realizar una operación matemática determinada por el comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOperar_Click(object sender, EventArgs e)
        {
            string resultado;
            double operacion;

            operacion = Operar(textBoxOperando1.Text, textBoxOperando2.Text, comboBoxOperando.Text);

            if (operacion == double.MinValue)
            {
                resultado = "Operación inválida";
                lstOperaciones.Items.Add(textBoxOperando1.Text + " " + comboBoxOperando.Text + " " + textBoxOperando2.Text + " " + "=" + " " + resultado);
            }
            else
            {
                resultado = operacion.ToString();
                lstOperaciones.Items.Add(textBoxOperando1.Text + " " + comboBoxOperando.Text + " " + textBoxOperando2.Text + " " + "=" + " " + resultado);
            }
            this.lblResultado.Text = resultado;
        }

        /// <summary>
        /// Evento a realizar cuando el usuario desea cerrar la aplicación, para confirmarlo previamente
        /// De responder sí se cierra, sino vuelve al Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            string mensaje = "¿Seguro que desea salir?";
            string titulo = "Salir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mensaje, titulo, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Al hacer click en botón cerrar se llama a método Closing para confirmar previamente que desea finalizar la app realmente
        /// De responder sí se cierra, sino vuelve al Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); //llama a closing
        }

        /// <summary>
        /// Al presionar el botón ejecuta el método DecimalBinario de Operando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
            lstOperaciones.Items.Add(lblResultado.Text);
        }

        /// <summary>
        /// Al presionar el botón ejecuta el método BinarioDecimal de Operando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
            lstOperaciones.Items.Add(lblResultado.Text);
        }

        /// <summary>
        /// Al presionar el botón ejecuta el método Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void textBoxOperando1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 58 && e.KeyChar <= 255) || (e.KeyChar == 47) || (e.KeyChar == 45))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            //esto no lo vimos puntualmente pero me pareció pertinente agregarlo, lo encontré en google y lo adapté para que reconozca . y , Fuente: vaidrollteam.blogspot.com
        }

        private void textBoxOperando2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 58 && e.KeyChar <= 255) || (e.KeyChar == 47) || (e.KeyChar == 45))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
