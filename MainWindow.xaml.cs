using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraSalarioNeto
{
    public partial class MainWindow : Window
    {
        //Creo las variables que luego voy a utilizar para el cálculo
        private int porcentaje = 0;
        private int numSueldos = 0;
        private int sueldo = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        //Método al pulsar el CheckBox de Movilidad
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBoxMovilidad.IsChecked == true)
            {
                //Al pulsar el checkBox había que quitarle un 1%
                porcentaje += - 1;
            }else if(checkBoxMovilidad.IsChecked != false)
            {
                //Si quita la selección de la casilla vuelve al estado original
                porcentaje += 1;
            }
        }


        //Cojo el número de sueldos para luego dividir el sueldo dependiendo de las veces que va a cobrar al año
        private void radioButton12_Checked(object sender, RoutedEventArgs e) {numSueldos = 12;}
        private void radioButton14_Checked(object sender, RoutedEventArgs e) {numSueldos = 14;}


        //Método del ComboBox
        private void comboboxFamiliar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Hago un switch para cada caso del propio comboBox
            string situacionSeleccionada = comboboxFamiliar.SelectedItem as string;
            switch (situacionSeleccionada) {
                case "Soltero":
                    numSueldos += 2;
                    break;
                case "Viudo":
                    numSueldos += -2;
                    break;
                case "Divorciado":
                    numSueldos += -1;
                    break;
                default:
                    numSueldos += 0;
                    break;
            }
        }


        //Método ToggleButton
        private void toggleButtonDiscapacidad_Checked(object sender, RoutedEventArgs e)
        {
            numSueldos += -5;
        }


        //Método TextBox
        private void textBoxEdad_TextChanged(object sender, TextChangedEventArgs e) {
            // Verifico si el contenido del TextBox es un número
            if (!int.TryParse(textBoxEdad.Text, out int edad))
            {
                // Si no es un número, muestro un mensaje de error y limpio el TextBox
                MessageBox.Show("Por favor, ingrese solo números en el campo de edad.");
                textBoxEdad.Text = "";
            }
            if(edad >= 20 && edad < 50) {
                numSueldos += 1;
            }else if (edad >= 50) {
                numSueldos += -2;
            }
        }
        private void textBoxSalarioBruto_TextChanged(object sender, TextChangedEventArgs e) {
            if (!int.TryParse(textBoxEdad.Text, out int salario)) {
                MessageBox.Show("Por favor, ingrese solo números en el campo de salario.");
                textBoxEdad.Text = "";
            }
            sueldo = salario;
            if (salario <= 15000) {
                numSueldos += 8;
            }else if (salario > 15000 && salario <= 30000) {
                numSueldos += 15;
            }else {
                numSueldos += 20;
            }
        }

        private void botonCalcular_Click(object sender, RoutedEventArgs e)
        {
            textBlockSalarioSolucion.Visibility = Visibility.Visible;

        }
    }
}
