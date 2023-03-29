using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using itog.circus2DataSetTableAdapters;

namespace itog
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        staffTableAdapter adapter = new staffTableAdapter();
        positionTableAdapter adapter1 = new positionTableAdapter();
        public Window1()
        {
            InitializeComponent();
            gr1.ItemsSource = adapter.GetData();
            gr2.ItemsSource = adapter1.GetData();
            combo1.ItemsSource = adapter1.GetData();
            combo1.DisplayMemberPath = "nameID";
        }

        public void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gr1.SelectedItem != null)
                {
                    var sel = gr1.SelectedItem as DataRowView;
                    text1.Text = sel.Row[1].ToString();
                    text2.Text = sel.Row[2].ToString();
                    combo1.Text = adapter1.GetData().First(element => element.id == (int)(gr1.SelectedItem as DataRowView).Row[3]).nameID;
                }


            }
            catch
            {
                text1.Text = null;
                text2.Text = null;
                combo1.Text = null;
                gr1.ItemsSource = adapter.GetData();
            }
        }

        private void add1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text1.Text) && string.IsNullOrWhiteSpace(text2.Text))
            {

            }
            else if (text2.Text.FirstOrDefault(element => char.IsDigit(element)).ToString() != "\0")
            {

            }
            else
            {
                try
                {
                    adapter.InsertQuery(text1.Text, text2.Text, (int)(combo1.SelectedItem as DataRowView).Row[0]);
                    gr1.ItemsSource = adapter.GetData();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
                finally
                {
                    gr1.ItemsSource = adapter.GetData();
                    text1.Text = null;
                    text2.Text = null;
                    combo1.Text = null;
                }
            }
        }



        private void del1_Click(object sender, RoutedEventArgs e)
        {
            if (gr1.SelectedItems != null)
            {
                adapter.DeleteQuery(Convert.ToInt32((gr1.SelectedItem as DataRowView).Row[0]));
                gr1.ItemsSource = adapter.GetData();
            }
        }

        private void chan1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text1.Text) && string.IsNullOrWhiteSpace(text2.Text))
            {

            }
            else if (text2.Text.FirstOrDefault(element => char.IsDigit(element)).ToString() != "\0")
            {

            }
            else
            {
                try
                {
                    adapter.UpdateQuery(text1.Text, text2.Text, (int)(combo1.SelectedItem as DataRowView).Row[1]);
                    gr1.ItemsSource = adapter.GetData();
                    text1.Text = null;
                    text2.Text = null;
                    combo1.Text = null;
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
                finally
                {
                    gr1.ItemsSource = adapter.GetData();
                    text1.Text = null;
                    text2.Text = null;
                    combo1.Text = null;
                }
            }
        }

        public void gr2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gr2.SelectedItem != null)
                {   
                    var sel = gr2.SelectedItem as DataRowView;
                    text11.Text = sel.Row[1].ToString();
                    text22.Text = sel.Row[2].ToString();
                    combo11.Text = sel.Row[3].ToString();
                }


            }
            catch
            {
                text11.Text = null;
                text22.Text = null;
                combo11.Text = null;
                gr2.ItemsSource = adapter1.GetData();
            }

        }

        private void add11_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text11.Text))
            {

            }
            else
            {
                try
                {
                    adapter1.InsertQuery1(text11.Text, Convert.ToInt32(text22.Text), Convert.ToInt32(combo11.Text));
                    gr2.ItemsSource = adapter1.GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    gr2.ItemsSource = adapter1.GetData();
                    text11.Text = null;
                    text22.Text = null;
                    combo11.Text = null;
                }
            }
        }



        private void del11_Click(object sender, RoutedEventArgs e)
        {
            if (gr2.SelectedItems != null)
            {
                adapter1.DeleteQuery2(Convert.ToInt32((gr2.SelectedItem as DataRowView).Row[0]));
                gr2.ItemsSource = adapter1.GetData();
            }
        }

        private void chan11_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text11.Text) && string.IsNullOrWhiteSpace(text22.Text) && string.IsNullOrWhiteSpace(combo11.Text))
            {

            }
            else if (text22.Text.FirstOrDefault(element => char.IsDigit(element)).ToString() != "\0")
            {

            }
            else
            {
                try
                {
                    object id = (gr2.SelectedItem as DataRowView).Row[0];
                    adapter1.UpdateQuery1(text11.Text, Convert.ToInt32(text22.Text), Convert.ToInt32(combo11.Text), Convert.ToInt32(id));
                    gr2.ItemsSource = adapter1.GetData();
                    text11.Text = null;
                    text22.Text = null;
                    combo11.Text = null;
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
                finally
                {
                    gr2.ItemsSource = adapter1.GetData();
                    text11.Text = null;
                    text22.Text = null;
                    combo11.Text = null;
                }
            }
        }
    }
}

