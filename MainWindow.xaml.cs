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
                porcentaje = porcentaje - 1;
            }else if(checkBoxMovilidad.IsChecked != false)
            {
                //Si quita la selección de la casilla vuelve al estado original
                porcentaje = porcentaje + 1;
            }
        }



    }
}
