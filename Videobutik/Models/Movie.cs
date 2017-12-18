using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;    
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Videobutik.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String ImageUrl { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }


        [Obsolete("Property 'Duration' should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long RentalDurationTicks
        {
            get;set;
        }

        [Obsolete("Property 'Duration' should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [NotMapped]
        public TimeSpan RentalDuration
        {
            get
            {
                return new TimeSpan(RentalDurationTicks);
            }
            set
            {
                RentalDurationTicks = value.Ticks;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public long NumberOfDaysInRentalPeriod
        {
            get
            {
                return (long)RentalDuration.TotalDays;
            }
            set
            {
                RentalDuration = new TimeSpan((TimeSpan.TicksPerDay * value));
            }
        }
        public Rent Rent(string userId)
        {
            Rent rent = new Models.Rent();
            rent.End = DateTime.Now.AddDays(NumberOfDaysInRentalPeriod);
            rent.Start = DateTime.Now;
            rent.MovieId = this.MovieId;
            rent.UserId = userId;
            this.Rents.Add(rent);
            return rent;
        }

        public Decimal Price { get; set; }
    }
}