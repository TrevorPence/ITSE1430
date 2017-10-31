/*
 * Trevor Pence
 * ITSE-1430
 * 10/9/2017
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib
{
    public class Movie : IValidatableObject
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
        public int Id { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(_title))
                yield return new ValidationResult("title cannot be null or empty.", new[] { nameof(Title) });

            if (Length < 0)
                yield return new ValidationResult("Length cannot be less than 0", new[] { nameof(Length) });

        }

        private string _title;
        private string _description;
    }
}
