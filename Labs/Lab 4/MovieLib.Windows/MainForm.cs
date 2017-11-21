/*
 * Trevor Pence
 * ITSE-1430
 * 10/9/2017
 */
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using MovieLib.Data.Memory;
using MovieLib.Data.Sql;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            string connString = ConfigurationManager.ConnectionStrings["MovieDatabase"].ConnectionString;
            _database = new SqlMovieDatabase(connString);

            _movieGrid.AutoGenerateColumns = false;
            UpdateList();
        }

        private void OnAdd( object sender, EventArgs e )
        {
            var movieDetailForm = new MovieDetailForm();
            if (movieDetailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Add(movieDetailForm.Movie);
            }
            catch(Exception er)
            {
                DisplayError(er);
            }
            UpdateList();
        }

        private void OnEdit( object sender, EventArgs e )
        {
            Movie movie = GetSelectedProduct();
            if (movie == null)
            {
                DialogResult result = MessageBox.Show("There are no movies in the list", "Edit Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EditMovie(movie);
        }

        private void OnDelete( object sender, EventArgs e )
        {
            if (_database.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this movie.", "Delete Movie",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _database.Remove(GetSelectedProduct().Id);
                    }
                    catch(Exception er)
                    {
                        DisplayError(er);
                    }
                    UpdateList();
                }
            } else
            {
                MessageBox.Show("There are no movies for you to delete.", "Delete Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnRowDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            DataGridView grid = sender as DataGridView;

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = grid.Rows[e.RowIndex];
            Movie movie = row.DataBoundItem as Movie;

            EditMovie(movie);
        }

        private void OnKeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Enter)
            {
                Movie movie = GetSelectedProduct();
                EditMovie(movie);
            }

            if (e.KeyCode == Keys.Delete)
            {
                Movie movie = GetSelectedProduct();
                _database.Remove(movie.Id);
                UpdateList();
            }
        }

        private void UpdateList()
        {
            _bindSrc.DataSource = _database.GetAll().ToList();
        }

        private Movie GetSelectedProduct()
        {
            if (_movieGrid.SelectedRows.Count > 0)
                return _movieGrid.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private void EditMovie(Movie movie)
        {
            var movieDetailForm = new MovieDetailForm(movie);
            movieDetailForm.PlaceValuesInTextBox(movie);
            if (movieDetailForm.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _database.Update(movieDetailForm.Movie);
            }
            catch(Exception er)
            {
                DisplayError(er);
            }
            UpdateList();
        }

        private void DisplayError(Exception error)
        {
            MessageBox.Show(this, error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private MovieDatabase _database;
    }
}
