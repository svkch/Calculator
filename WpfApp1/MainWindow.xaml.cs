using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        double enterFirst, enterSecond;
        string btnClickPerformed = ""; //значение, которое будет в окне результата при нажатии определенной кнопки

        public MainWindow()
        {           
                InitializeComponent();
            DateTime currentDate = DateTime.Now; 
            statusText.Text = currentDate.ToString(); //вывод времени в строке состояния
        }

        private void btn_click(object sender, RoutedEventArgs e) { // ввод цифр

            Button numbers = (Button) sender;

            if (outputWin.Text == "0")
            {
                outputWin.Clear();
            }
            outputWin.Text += numbers.Content;

        }
        private void operation_click (object sender, RoutedEventArgs e) // нажатие +, -, *, /, степень,  1/x
        {
            Button button = (Button)sender;

            enterFirst = Convert.ToDouble(outputWin.Text);
            btnClickPerformed = (string)button.Content;
            outputWin.Clear();
        }

        private void btnClear_click(object sender, RoutedEventArgs e) //кнопка очистки
        {
            outputWin.Text = "0";          
        }

        private void btn_plsMns(object sender, RoutedEventArgs e) // кнопка, отвечающая за то, положительное ли число или отрицательное
        {
            double value = Convert.ToDouble(outputWin.Text);
            outputWin.Text = Convert.ToString(-1 * value);
        }

        private void sqrt_Click(object sender, RoutedEventArgs e) //корень
        {
            double sq = Convert.ToDouble(outputWin.Text);

            if (sq < 0) // проверка числа на ноль
            {
                MessageBox.Show("Вы пытаетесь взять квадратный корень из отрицательного числа!");
                outputWin.Clear();
            }
            else
            {
                sq = Math.Sqrt(sq);
                outputWin.Text = Convert.ToString(sq);
            }
        }

        private void sin_Click(object sender, RoutedEventArgs e) // синус
        {
            double sn = Convert.ToDouble(outputWin.Text);
            sn = Math.Sin(sn);
            outputWin.Text = Convert.ToString(sn);
        }

        private void cos_Click(object sender, RoutedEventArgs e) // косинус
        {
            double cs = Convert.ToDouble(outputWin.Text);
            cs = Math.Cos(cs);
            outputWin.Text = Convert.ToString(cs);
        }

        private void tg_Click(object sender, RoutedEventArgs e) //тангенс
        {
            double tg = Convert.ToDouble(outputWin.Text);
            tg = Math.Tan(tg);
            outputWin.Text = Convert.ToString(tg);
        }

        private void ctg_Click(object sender, RoutedEventArgs e) //котангенс
        {
            double cg = Convert.ToDouble(outputWin.Text);
            cg = 1 / (Math.Tan(cg));
            outputWin.Text = Convert.ToString(cg);
        }

        private void oneDivX_Click(object sender, RoutedEventArgs e) // 1/x
        {
             double x = Convert.ToDouble(1 / Convert.ToDouble(outputWin.Text));
            if (Convert.ToDouble(outputWin.Text) == 0)
            {
                MessageBox.Show("Попытка деления на ноль!");
                outputWin.Clear();
            }
            outputWin.Text = Convert.ToString(x);

        }

        private void btnEqual_Click(object sender, RoutedEventArgs e) //кнопка равно - показывает результат
        {
          enterSecond = Convert.ToDouble(outputWin.Text);

            if (btnClickPerformed == "+") {

                outputWin.Text = (enterFirst + enterSecond).ToString();
            }

            else if (btnClickPerformed == "-") {

                outputWin.Text = (enterFirst - enterSecond).ToString();
            }

            else if (btnClickPerformed == "*"){

                outputWin.Text = (enterFirst * enterSecond).ToString();
            }

            else if (btnClickPerformed == "/") {

                outputWin.Text = (enterFirst / enterSecond).ToString();

                if (enterSecond == 0)
                {
                    MessageBox.Show("Попытка деления на ноль!");
                    outputWin.Clear();
                }

            }
            else if (btnClickPerformed == "x^n") //возведение числа в любую степень
            {
                outputWin.Text = (Math.Pow(enterFirst, enterSecond)).ToString();
            }
            

        }

    }
}
