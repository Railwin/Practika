using itog.circus2DataSetTableAdapters;
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

namespace itog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        infoTableAdapter adapter = new infoTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var alllogins = adapter.GetData().Rows;

            for (int i = 0; i < alllogins.Count; i++)
            {
                if (alllogins[i][1].ToString() == logintbx.Text && alllogins[i][2].ToString() == passwordtbx.Text)
                {
                    int roleId = (int) alllogins[i][3];
                    switch (roleId)
                    {
                        case 1:
                            Window1 role = new Window1();
                            role.Show();
                            break;
                        case 2:
                            Window second = new Window();
                            second.Show();
                            break;
                    }
                }
            }
        }
    }
}
