using System;
using System.IO;
using Xamarin.Forms;
namespace Notes
{
    public partial class MainPage : ContentPage
    {
        string _fileName =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }
        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);

            DisplayAlert("Mensagem pra tu!", "Texto salvo com sucesso, parça", "Demorô");
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Mensagem pra tu", "Deseja realmente apagar o bagulho?", "Yes", "No"))
            {
                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                }
                editor.Text = string.Empty;
            }
        }
    }
}