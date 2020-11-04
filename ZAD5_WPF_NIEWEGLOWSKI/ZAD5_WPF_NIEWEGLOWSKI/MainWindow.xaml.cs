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

namespace ZAD5_WPF_NIEWEGLOWSKI
{

    public partial class MainWindow : Window
    {

        Uzytkownik uzytkownik = new Uzytkownik();
        List<Uzytkownik> uzytkownikLista = new List<Uzytkownik>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 dlg = new Window1();
            dlg.ShowDialog();
            // poniższy kod wykona się po zamknięciu okna dialogowego
            if (dlg.DialogResult == true && dlg.Imie.Text.Length != 0 && dlg.Nazwisko.Text.Length != 0 && dlg.Email.Text.Length != 0)
            {

                Uzytkownik uzytkownik = new Uzytkownik(dlg.Imie.Text, dlg.Nazwisko.Text, dlg.Email.Text);
                uzytkownikLista.Add(uzytkownik);
                UsunU.IsEnabled = true;
                EdytujU.IsEnabled = true;
            }
            else
                return;

            String dodawany = $"{dlg.Imie.Text}, {dlg.Nazwisko.Text}, {dlg.Email.Text}";
            output.Items.Add(dodawany.ToString());
        }

        private void Usun(object sender, RoutedEventArgs e)
        {
            int wybor = output.SelectedIndex;
            if (output.SelectedIndex >= 0)
            {
                if (MessageBox.Show(
                    "Czy na pewno chcesz usunąć wskazany element?",
                    "Usuń element", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) != MessageBoxResult.Yes)
                    return;

                uzytkownikLista.RemoveAt(wybor);
                output.Items.RemoveAt(wybor);

            }

            if (output.Items.Count == 0)
            {
                UsunU.IsEnabled = false;
                EdytujU.IsEnabled = false;
                PodgladU.IsEnabled = false;

            }
        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            if (output.SelectedIndex >= 0)
            {
                Window1 dlg = new Window1();


                int wybor = output.SelectedIndex;
                dlg.Imie.Text = uzytkownikLista[wybor].Imie;
                dlg.Nazwisko.Text = uzytkownikLista[wybor].Nazwisko;
                dlg.Email.Text = uzytkownikLista[wybor].Email;

                dlg.ShowDialog();

                if (dlg.DialogResult == true)
                {
                    uzytkownikLista[wybor].Imie = dlg.Imie.Text;
                    uzytkownikLista[wybor].Nazwisko = dlg.Nazwisko.Text;
                    uzytkownikLista[wybor].Email = dlg.Email.Text;
                    String dodawany = $"{dlg.Imie.Text}, {dlg.Nazwisko.Text}, {dlg.Email.Text}";


                    output.Items.Insert(output.SelectedIndex, dodawany);
                    output.Items.RemoveAt(output.SelectedIndex);
                }

            }
        }

        Window2 dlg = null;
        private void Podglad(object sender, RoutedEventArgs e)
        {
            dlg = new Window2();
            int wybor = output.SelectedIndex;
            if (wybor >= 0)
            {
                dlg.Imie.Content += uzytkownikLista[wybor].Imie;
                dlg.Nazwisko.Content += uzytkownikLista[wybor].Nazwisko;
                dlg.Email.Content += uzytkownikLista[wybor].Email;
                dlg.Show();
            }
        }

        private void aktualizujPodglad(object sender, RoutedEventArgs e)
        {

            if (dlg != null)
            {
                int wybor = output.SelectedIndex;
                if (wybor >= 0)
                {
                    try
                    {
                        dlg.Imie.Content = $"Imię:{uzytkownikLista[wybor].Imie}";
                        dlg.Nazwisko.Content = $"Nazwisko:{uzytkownikLista[wybor].Nazwisko}";
                        dlg.Email.Content = $"Email:{uzytkownikLista[wybor].Email}";
                        dlg.Show();
                    }
                    catch (Exception x)
                    {

                    }
                }
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
