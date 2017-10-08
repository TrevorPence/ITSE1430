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

        private void _cancelButton_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void _saveButton_Click( object sender, EventArgs e )
        {
            Movie = new Movie {
                Title = getTitle(),
                Description = _description.Text,
                Length = GetLength(),
                IsOwned = _ownedCheckBox.Checked
            };

            if (String.IsNullOrEmpty(Movie.Title) || Movie.Length < 0)
                return;

            Close();
        }

        private decimal GetLength()
        {
            if(Decimal.TryParse(_length.Text, out decimal length) && length >= 0)
            {
                _lengthError.Clear();
                return length;
            }
            else
            {
                _lengthError.SetError(_miniuteLabel, "Value must be greater a number greater than or equal to 0.");
                return -1;
            }
        }

        private string getTitle()
        {
            if (String.IsNullOrEmpty(_title.Text))
            {
                _titleError.SetError(_title, "Must give movie a title");
                return "";
            }
            else
            {
                _titleError.Clear();
                return _title.Text;
            }
        }
    }
}
