using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Videobutik.Models
{
    [Table("rents")]
    public class Rent
    {
        [Key]
        public int RentId { get; set; }
        /// <summary>
        /// Gets the user
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public String UserId { get; set; }
        /// <summary>
        /// Gets the movie
        /// </summary>
        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }
        /// <summary>
        /// Gets the date it is rented
        /// </summary>
        public DateTime Start { get; set; }

        public DateTime? Returned
        {
            get;set;
        }
        
        public bool IsReturned
        {
            get
            {
                return Returned != null;
            }
        }
        /// <summary>
        /// Gets how long time it is rented
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return DateTime.Now - Start;
            }
        }
        public DateTime End { get; set; }
        /// <summary>
        /// Gets how long time left before it will expire
        /// </summary>
        public TimeSpan TimeLeft
        {
            get
            {
                return End - DateTime.Now;
            }
        }
    }
}