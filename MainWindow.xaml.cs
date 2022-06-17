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


namespace Zaliczenie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal firstNumber, secoundNumber, thirdNumber, total1, total2, getKursEuro, getKursDolar ; 
                        // Zmienne przechowujące liczby zmiennoprzecinkowych o ściśle określonej precyzji
        bool c, d; 
                        // Zmienne przechowujące liczby zmiennoprzecinkowych o ściśle określonej precyzji

        public MainWindow()
        {
            InitializeComponent();
        }

        decimal ZapiszKursEuro()
        {
            getKursEuro = Convert.ToDecimal(CEuro.Text);

            return getKursEuro;                             //Metody służące do zapisywania kursów walut.
        }
        decimal ZapiszKursDolar()
        {
            getKursDolar = Convert.ToDecimal(CDolar.Text);

            return getKursDolar;
        }


        decimal dolar1(decimal firstNumber, decimal thirdNumber)
        {
            d = decimal.TryParse(Hajs.Text, out firstNumber);
            lb2.Items.Clear();
            if (d && firstNumber >= 0)
            {
                decimal b = firstNumber / thirdNumber;
                total2 = b;
            }
            else
            {
                MessageBox.Show("Wprowadź poprawną liczbę. Musi być większa od zera.");
                Hajs.Clear();
                Hajs.AppendText("Podana kwota nie może być mniejsza niż 0.");
            }
            if (d && thirdNumber >= 0)
            {
                decimal b = firstNumber / thirdNumber;
                total2 = b;

            }
            else
            {
                MessageBox.Show("Wprowadź poprawną liczbę. Musi być większa od zera.");
                Hajs.Clear();
                MessageBox.Show("Kurs nie może być mniejszy niż 0.");
            }
            lb2.Items.Add(Math.Round(total2, 2) + "$");
            return (total2);
            // Metoda do obliczania kursu dolara razem z pokazywaniem błędów oraz czyszczenia TextBoxów. Zbudowana z 2 pętli IF.
        }

        private void zapiszButton_Click(object sender, RoutedEventArgs e)
        {
            ZapiszKursEuro();                                           // Przycisk z metodami które zapisują dane z textboxów z kursami
            ZapiszKursDolar();
        }

        private void wczytajButton_Click(object sender, RoutedEventArgs e)
        {
            CEuro.Text = getKursEuro.ToString();                        // Przycisk który służy do wczytywania wcześniej zapisanych danych. 
            CDolar.Text=getKursDolar.ToString();
        }
        private void ButtonEuro(object sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDecimal(Hajs.Text);
            secoundNumber = Convert.ToDecimal(CEuro.Text);

            c = decimal.TryParse(Hajs.Text, out firstNumber);
            lb1.Items.Clear();
            if (c && firstNumber >= 0)
            {
                decimal v = firstNumber / secoundNumber;
                total1 = v;

            }
            else
            {
                MessageBox.Show("Wprowadź poprawną liczbę. Musi być większa od zera.");
                Hajs.Clear();
                Hajs.AppendText("Podana kwota nie może być mniejsza niż 0.");
            }
            if (c && secoundNumber >= 0)
            {
                decimal v = firstNumber / secoundNumber;
                total1 = v;
            }
            else
            {
                MessageBox.Show("Wprowadź poprawną liczbę. Musi być większa od zera.");
                Hajs.Clear();
                MessageBox.Show("Kurs nie może być mniejszy niż 0.");
            }
            lb1.Items.Add(Math.Round(total1,2) + "€");

            // Część programu obliczająca kurs euro z pokazywaniem błędów oraz czyszczeniem TextBoxów. Zbudowania z 2 pętli IF.
            // Posiada też konwersji stringa na Decimale.
        }
        private void ButtonDolar(object sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDecimal(Hajs.Text);
            thirdNumber = Convert.ToDecimal(CDolar.Text);

            dolar1(firstNumber, thirdNumber);
            // Tu znajduje się konwersja stringów na decimalne oraz wykorzystuje metode stworzoną wyżej.
        }
        private void CEuro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CDolar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Hajs_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        // Puste okno dialogowe.
    }
}
