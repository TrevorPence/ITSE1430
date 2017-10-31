/*
 * Trevor Pence
 * ITSE-1430
 * 10/9/2017
 */
using System;
using System.Windows.Forms;

namespace MovieLib.Windows
{
    public partial class MovieDetailForm : Form
    {
        public Movie Movie { set; get; }

        public MovieDetailForm()
        {
            InitializeComponent();
        }
        public MovieDetailForm(Movie movie)
        {
            InitializeComponent();
            Movie = movie;
        }

        public void PlaceValuesInTextBox(Movie movie)
        {
            _title.Text = movie.Title;
            _description.Text = movie.Description;
            _length.Text = movie.Length.ToString();
            _ownedCheckBox.Checked = movie.IsOwned;
        }

        private void OnCancel( object sender, EventArgs e )
        {
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            int id = 0;
            if (Movie != null)
                id = Movie.Id;

            Movie = new Movie {
                Title = GetTitle(),
                Description = _description.Text,
                Length = GetLength(),
                IsOwned = _ownedCheckBox.Checked
            };
            if (id > 0)
                Movie.Id = id;

            if (!ObjectValidator.TryValidate(Movie, out var errors))
            {
                MessageBox.Show(this, "Not Valid", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private decimal GetLength()
        {
            if (Decimal.TryParse(_length.Text, out decimal length) && length >= 0)
            {
                _lengthError.Clear();
                return length;
            } else
            {
                _lengthError.SetError(_miniuteLabel, "Value must be greater a number greater than or equal to 0.");
                return -1;
            }
        }

        private string GetTitle()
        {
            if (String.IsNullOrEmpty(_title.Text))
            {
                _titleError.SetError(_title, "Must give movie a title");
                return "";
            } else
            {
                _titleError.Clear();
                return _title.Text;
            }
        }
        
        /* \(*_*)/ */
        private void OnTitleValidating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_titleLabel.Text))
            {
                _titleError.SetError(_titleLabel, "Movie must have a title");
                _titleLabel.Text = "N/A";
            } else
                _titleError.SetError(_titleLabel, "");
        }

        private void OnLengthValidating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if (GetLength() < 0)
            {
                e.Cancel = true;
                _titleError.SetError(_lengthLabel, "Length must be greater than or equal to 0.");
            } else
                _titleError.SetError(_lengthLabel, "");
        }
    }
}
