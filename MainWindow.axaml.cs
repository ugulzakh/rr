using System.Collections.Generic;
using Avalonia.Controls;
using MySql.Data.MySqlClient;

namespace KR;

public partial class MainWindow : Window
{
    private string _connString = "server=10.10.1.24;database=pro1_20;port=3306;User Id=user_01;password=user01pro";
    private List<Teacher> _teachers;
    private MySqlConnection _connection;
    string fullTable = "select ID, Surname, Name from Teacher";
    
    public MainWindow()
    {
        InitializeComponent();
        ShowTable(fullTable);
    }

    public void ShowTable(string sql)
    {
        _teachers = new List<Teacher>();
        _connection = new MySqlConnection(_connString);
        _connection.Open();
        MySqlCommand command = new MySqlCommand(sql, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentTeach = new Teacher()
            {
                ID = reader.GetInt32("ID"),
                Surname = reader.GetString("Surname"),
                Name = reader.GetString("name"),
            };
            _teachers.Add(currentTeach);
        }
        _connection.Close();
        Teacher.ItemsSource = _teachers;
    }

    private void TxtSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        
    }
}