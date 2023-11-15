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
        private int porcentaje = 0;
        private int numSueldos = 0;
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
    }
}
