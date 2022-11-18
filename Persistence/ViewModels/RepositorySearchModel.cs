using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RepositorySearchModel
    {
        [Required(ErrorMessage ="Поле должно быть заполнено!")]
        public string SearchString { get; set; }

        public string Language { get; set; }

        public int Page { get; set; } = 1;

        public int PerPage { get; set; } = 20;
    }
}
