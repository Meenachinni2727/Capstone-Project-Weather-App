using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_API.Models
{
    public class UserFavourites
    {
        #region Properties
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string UserId { get; set; }
        #endregion
    }

    public class UserRequest
    {
        public string UserId { get; set; }
        public string City { get; set; }
    }
}
