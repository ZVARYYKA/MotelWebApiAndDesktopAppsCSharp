using System;
using System.Collections.Generic;
using System.Windows;
using System.Threading.Tasks;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private ApiClient apiClient;

        public MainWindow()
        {
            InitializeComponent();
            apiClient = new ApiClient("http://localhost:44338"); // Укажите ваш базовый URL
        }

        #region Guests

        private async void RefreshGuests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Guest> guests = await apiClient.GetGuestsAsync();
                guestListBox.ItemsSource = guests;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Guests: {ex.Message}");
            }
        }

        private async void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для отображения окна добавления гостя
        }

        private async void UpdateGuest_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для отображения окна обновления гостя
        }

        private async void DeleteGuest_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для удаления гостя
        }

        #endregion

        #region Rooms

        private async void RefreshRooms_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Room> rooms = await apiClient.GetRoomsAsync();
                roomListBox.ItemsSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing Rooms: {ex.Message}");
            }
        }

        private async void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для отображения окна добавления комнаты
        }

        private async void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для отображения окна обновления комнаты
        }

        private async void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для удаления комнаты
        }

        #endregion

        #region GuestRooms

        private async void RefreshGuestRooms_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<GuestRoom> guestRooms = await apiClient.GetGuestRoomsAsync();
                guestRoomListBox.ItemsSource = guestRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing GuestRooms: {ex.Message}");
            }
        }

        private async void AddGuestRoom_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для отображения окна добавления промежуточной записи
        }

        private async void UpdateGuestRoom_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для отображения окна обновления промежуточной записи
        }

        private async void DeleteGuestRoom_Click(object sender, RoutedEventArgs e)
        {
            // Ваш код для удаления промежуточной записи
        }

        #endregion
    }
}
