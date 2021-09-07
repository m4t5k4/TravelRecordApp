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
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Succes", "Post updated", "Ok");
                } else
                {
                    DisplayAlert("Failure", "Post not updated", "Ok");
                }
            }
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DBLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Succes", "Post deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Post not deleted", "Ok");
                }
            }
        }
    }
}