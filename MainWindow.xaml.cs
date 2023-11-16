using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CalculadoraSalarioNeto
{
    public partial class MainWindow : Window
    {
        //Creo las variables que luego voy a utilizar para el cálculo
        private double porcentaje = 0;
        private int numSueldos = 0;
        private double sueldo = 0;
        public MainWindow() { InitializeComponent(); }

        //Método al pulsar el CheckBox de Movilidad
        private void CheckBox_Checked(object sender, RoutedEventArgs e) { porcentaje += - 1; }


        //Cojo el número de sueldos para luego dividir el sueldo dependiendo de las veces que va a cobrar al año
        private void radioButton12_Checked(object sender, RoutedEventArgs e) {numSueldos = 12; }
        private void radioButton14_Checked(object sender, RoutedEventArgs e) {numSueldos = 14; } 


        //Método del ComboBox
        private void comboboxFamiliar_SelectionChanged(object sender, SelectionChangedEventArgs e) {
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


        //Métodos ToggleButton
        private void toggleButtonDiscapacidad_Checked(object sender, RoutedEventArgs e) { numSueldos += -5; }


        //Método TextBox
        private void textBoxEdad_TextChanged(object sender, TextChangedEventArgs e) {
            // Verifico si el contenido del TextBox no está vacío
            if (!string.IsNullOrEmpty(textBoxEdad.Text)) {
                // Verifico si el contenido del TextBox es un número
                if (!int.TryParse(textBoxEdad.Text, out int edad)) {
                    // Si no es un número, muestro un mensaje de error y limpio el TextBox
                    MessageBox.Show("Por favor, ingrese solo números en el campo de edad.");
                    textBoxEdad.Text = "";
                }
                if (edad >= 20 && edad < 50) {
                    numSueldos += 1;
                } else if (edad >= 50) {
                    numSueldos += -2;
                }
            }
        }
        private void textBoxSalarioBruto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSalarioBruto.Text)) {
                if (!int.TryParse(textBoxSalarioBruto.Text, out int salario)) {
                    MessageBox.Show("Por favor, ingrese solo números en el campo de salario.");
                    textBoxSalarioBruto.Text = "";
                }
                sueldo = salario;
                if (salario <= 15000) {
                    numSueldos += 8;
                } else if (salario > 15000 && salario <= 30000) {
                    numSueldos += 15;
                }
                else {
                    numSueldos += 20;
                }
            }
        }


        //Método del botón
        private async void botonCalcular_Click(object sender, RoutedEventArgs e)
        {
            //Si no están llenos algunos campos necesarios salta un error
            if(textBoxSalarioBruto.Text == null || textBoxEdad == null || comboboxFamiliar.SelectedItem == null || (radioButton12.IsChecked == false && radioButton14.IsChecked == false)) {
                MessageBox.Show("Has dejado campos sin introducir, por favor, introduce todos los campos antes de continuar.");
                return;
            }
            textBlockSalarioSolucion.Visibility = Visibility.Visible;
            await Task.Delay(2000); // Pauso la ejecución por 2 segundos
            double cuenta;
            cuenta = sueldo - sueldo * (porcentaje/100.0);
            cuenta = cuenta / numSueldos;
            textBlockSalarioSolucion.Text = "Tu salario es de: " + cuenta.ToString("0.00") + " euros.";

        }
    }
}
