using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
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
using WpfApp2.ServiceReference1;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Challenges.xaml
    /// </summary>
    public partial class Challenges : Page
    {
      Service1Client service = new Service1Client();

      public Challenges()
        {
            InitializeComponent();

            challengesDataGrid.ItemsSource = service.GetAllChallenges();
        }

    private bool _handle = true;
    private void challengesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
      {
        if (_handle)
        {
          _handle = false;
          challengesDataGrid.CommitEdit();
          Challenge challenge = e.Row.Item as Challenge;
          service.UpdateChallenge(challenge);
          _handle = true;
        }
      }

    private void addChallengeButton_Click(object sender, RoutedEventArgs e)
    {
      Window addChallengeWindow = new AddChallengeWindow(challengesDataGrid);
      addChallengeWindow.Show();
    }

    private void deleteButton_Click(object sender, RoutedEventArgs e)
    {
      if (challengesDataGrid.SelectedItem != null)
      {
        Challenge challenge = challengesDataGrid.SelectedItem as Challenge;
        service.DeleteChallenge(challenge.id);
        challengesDataGrid.ItemsSource = service.GetAllChallenges();
        challengesDataGrid.Items.Refresh();
      }
    }
  }
}
