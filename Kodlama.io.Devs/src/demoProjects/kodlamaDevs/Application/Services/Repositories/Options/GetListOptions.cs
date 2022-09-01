using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories.Options
{
    public class GetListOptions<T>
    {
        public Expression<Func<T, bool>>? Filter { get; set; }
        public IEnumerable<Expression<Func<T, object>>>? Includes { get; set; }
        public bool Pagination { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
