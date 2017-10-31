/*
 * Trevor Pence
 * ITSE-1430
 * 10/9/2017
 */
using System;
using System.Windows.Forms;
using MovieLib.Data.Memory;
using System.Linq;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();

            _database.Add(new Movie {
                Title = "Rise of the Dawn of the War for the Planet of the Apes",
                Description = "A Description",
                Length = 120,
                IsOwned = false
            });
            _database.Add(new Movie {
                Title = "Bee Movie 2: Electric Boogaloo",
                Description = "",
                Length = 92,
                IsOwned = true
            });
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            _movieGrid.AutoGenerateColumns = false;
            UpdateList();
        }

        private void OnAdd( object sender, EventArgs e )
        {
            var movieDetailForm = new MovieDetailForm();
            if (movieDetailForm.ShowDialog(this) != DialogResult.OK)
                return;

            _database.Add(movieDetailForm.Movie);
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
                    _database.Remove(GetSelectedProduct().Id);
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
            if (movie != null)
            {
                var movieDetailForm = new MovieDetailForm(movie);
                movieDetailForm.PlaceValuesInTextBox(movie);
                if (movieDetailForm.ShowDialog(this) != DialogResult.OK)
                    return;

                _database.Update(movieDetailForm.Movie);
                UpdateList();
            }
        }

        private MovieDatabase _database = new MovieDatabase();
    }
}
