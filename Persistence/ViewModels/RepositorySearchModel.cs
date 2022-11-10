using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RepositorySearchModel
    {
        public string SearchString { get; set; }

        public string RepoSearchSort { get; set; }

        public string Language { get; set; }

        public int Page { get; set; }

        public int PerPage { get; set; }

    }
}
