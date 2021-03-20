using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_API.Models
{
    public class City
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
