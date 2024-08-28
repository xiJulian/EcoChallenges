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
using WpfApp2.ServiceReference1;

namespace WpfApp2
{
  /// <summary>
  /// Interaction logic for Mailbox.xaml
  /// </summary>
  public partial class Mailbox : Page
  {
    Service1Client service = new Service1Client();

    public Mailbox()
    {
      InitializeComponent();

      messagesDataGrid.ItemsSource = service.GetAllMessages();
    }

    private bool _handle = true;
    private void messagesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
      if (_handle)
      {
        _handle = false;
        messagesDataGrid.CommitEdit();
        Message message = e.Row.Item as Message;
        service.MarkMessageAsRead(message.id, message.isRead);
        _handle = true;
      }
    }

    private void deleteButton_Click(object sender, RoutedEventArgs e)
    {
      if (messagesDataGrid.SelectedItem != null)
      {
        Message message = messagesDataGrid.SelectedItem as Message;
        service.DeleteMessage(message.id);
        messagesDataGrid.ItemsSource = service.GetAllMessages();
        messagesDataGrid.Items.Refresh();
      }
    }
  }
}
