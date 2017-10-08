/*
 * Trevor Pence
 * ITSE-1430
 * 10/9/2017
 */

namespace MovieLib
{
    public class Movie
    {
        public string Title
        {
            set { _title = value; }
            get { return _title ?? ""; }
        }
        public string Description
        {
            set { _description = value; }
            get { return _description ?? ""; }
        }
        public decimal Length { get; set; }
        public bool IsOwned { get; set; }

        private string _title;
        private string _description;
    }
}
