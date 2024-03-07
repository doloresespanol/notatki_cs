using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Notatki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        ObservableCollection<Notatka> listaNotatek = new ObservableCollection<Notatka>();
        List<string> nieposortowaneNotatki = new List<string>();
        string path = "\"C:\\\\Users\\\\egzamin\\\\Desktop\\\\4PGr1\\\\notatkaDesktop\\\\Notatki\\\\notatki.txt\"";
        public MainWindow()
        {
            InitializeComponent();
            listaNotatek.Add(new Notatka("1", "sc Pozdrowienia tresc"));
            //listaNotatek.Add(new Notatka("2", " Pozdrowienia tresc Pozdrowienia tresc"));
            //listaNotatek.Add(new Notatka("3", "ozdrowienia tresc"));
            //listaNotatek.Add(new Notatka("4", "96wienia tresc"));
            wypiszNotatki();
        
        }
        public void wypiszNotatki()
        {
            StreamReader reader = new StreamReader("../../../notatki.txt");
            /*string line = "";
            line = reader.ReadLine();
            while (line != null)
            {
                string lina = line;
                nieposortowaneNotatki.Add(lina.ToString());
                if(reader.ReadLine() == null ) { break; }
            }
            reader.Close();*/

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if(line != null)
                {
                    nieposortowaneNotatki.Add(line);
                    //MessageBox.Show(line.ToString());
                }
            }

           for (int i = 0;i<nieposortowaneNotatki.Count-1;i+=2)
            {
                listaNotatek.Add(new Notatka(nieposortowaneNotatki[i], nieposortowaneNotatki[i + 1]));
            }

            tytul_block.Text = listaNotatek[0].tytul;
            tresc_block.Text = listaNotatek[0].tresc;


        }

        private void Nastepna_Click(object sender, RoutedEventArgs e)
        {
            if (i < listaNotatek.Count - 1)
            {
                i++;
                tytul_block.Text = listaNotatek[i].tytul;
                tresc_block.Text = listaNotatek[i].tresc;
            }
            else
            {
                i = 0;
                tytul_block.Text = listaNotatek[i].tytul;
                tresc_block.Text = listaNotatek[i].tresc;
            }
        }

        private void Poprzednia_Click(object sender, RoutedEventArgs e)
        {
            if (i > 0)
            {
                i--;
                tytul_block.Text = listaNotatek[i].tytul;
                tresc_block.Text = listaNotatek[i].tresc;
            }
            else
            {
                i = listaNotatek.Count-1;
                tytul_block.Text = listaNotatek[i].tytul;
                tresc_block.Text = listaNotatek[i].tresc;
            }
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            if(tytul.Text == null || tresc.Text == null || tytul.Text == "" || tresc.Text == "")
            {
                MessageBox.Show("Brak tytułu lub treści notatki");
            }
            else{
                string tytul1 = tytul.Text;
                string tresc1 = tresc.Text;

                List<string> lista = new List<string>();

                lista.Add(tytul1);
                lista.Add(tresc1);

                File.AppendAllLines(path, lista);
                listaNotatek.Add(new Notatka(tytul.Text,tresc.Text));
                MessageBox.Show("Notatka dodana :)))");
            }
        }
    }
}
