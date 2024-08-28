using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.ServiceReference1;

namespace WpfApp2
{
  /// <summary>
  /// Interaction logic for AddChallengeWindow.xaml
  /// </summary>
  public partial class AddChallengeWindow : Window
  {
    DataGrid challengesDataGrid;
    public AddChallengeWindow(DataGrid challengesDataGrid)
    {
      InitializeComponent();
      this.challengesDataGrid = challengesDataGrid;
    }

    private void pointsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      Regex regex = new Regex("[^0-9]+");
      e.Handled = regex.IsMatch(e.Text);
    }

    private void addChallengeButton_Click(object sender, RoutedEventArgs e)
    {

      if (titleTextBox.Text.Length == 0) { ShowErrorBox("You must provide a title!"); return; }
      if (descriptionTextBox.Text.Length == 0) { ShowErrorBox("You must provide a description!"); return; }
      bool success = int.TryParse(pointsTextBox.Text, out int points);
      if (!success) { ShowErrorBox("You must provide a points number!"); return; }

      Service1Client service = new Service1Client();
      Challenge challenge = new Challenge();
      challenge.title = titleTextBox.Text;
      challenge.points = points;
      challenge.description = descriptionTextBox.Text;
      service.AddChallenge(challenge);
      challengesDataGrid.ItemsSource = service.GetAllChallenges();
      challengesDataGrid.Items.Refresh();
      this.Close();
    }

    private void ShowErrorBox(string errorMessage)
    {
      errorTextBlock.Visibility = Visibility.Visible;
      errorTextBlock.Text = errorMessage;
    }
  }
}
