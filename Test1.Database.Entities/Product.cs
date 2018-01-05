using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Database.Entities
{
	public partial class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool ECommercePublished { get; set; }
		public virtual ICollection<Article> Articles { get; set; }

	}
}
