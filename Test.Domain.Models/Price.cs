using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Domain.Models
{
    public class Price
    {
		public int Id { get; set; }

		public short RegionId { get; set; }

		public bool IsDefault { get; set; }
	}
}
