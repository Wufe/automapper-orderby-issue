using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Database.Entities
{
	public partial class Article
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public bool IsDefault { get; set; }
		public short NationId { get; set; }
		public virtual Product Product { get; set; }
	}
}
