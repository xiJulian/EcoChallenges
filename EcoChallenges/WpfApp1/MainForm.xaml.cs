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

namespace WpfApp2
{
  /// <summary>
  /// Interaction logic for MainForm.xaml
  /// </summary>
  public partial class MainForm : Window
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void homeMenuItem_Click(object sender, RoutedEventArgs e)
    {
      mainFrame.Navigate(new Home());
    }

    private void challengesMenuItem_Click(object sender, RoutedEventArgs e)
    {
      mainFrame.Navigate(new Challenges());
    }

    private void mailboxMenuItem_Click(object sender, RoutedEventArgs e)
    {
      mainFrame.Navigate(new Mailbox());
    }

    private void logoutMenuItem_Click(object sender, RoutedEventArgs e)
    {
      Window window = new MainWindow();
      this.Close();
      window.Show();
    }
  }
}
