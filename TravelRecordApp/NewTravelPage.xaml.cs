using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            Post newPost = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(newPost);

                if (rows > 0)
                    DisplayAlert("Succes", "Experience inserted", "ok");
                else
                    DisplayAlert("Failed", "Experience not inserted", "ok");
            }
        }
    }
}