/*
 * Trevor Pence
 * ITSE-1430
 * 10/9/2017
 */
using System;
using System.Windows.Forms;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        Movie _movie;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load( object sender, EventArgs e ) { }

        private void addToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var movieDetailForm = new MovieDetailForm();
            movieDetailForm.ShowDialog(this);

            _movie = movieDetailForm.Movie;
        }

        private void editToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (_movie == null)
            {
                MessageBox.Show("There are no movies for you to edit.", "Edit Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movieDetailForm = new MovieDetailForm(_movie);
            movieDetailForm.PlaceValuesInTextBox(_movie);
            movieDetailForm.ShowDialog(this);

            _movie = movieDetailForm.Movie;
        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (_movie != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this movie.", "Delete Movie",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    _movie = null;
            }
            else
            {
                MessageBox.Show("There are no movies for you to delete.", "Delete Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }

        private void quitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Close();
        }
    }
}
