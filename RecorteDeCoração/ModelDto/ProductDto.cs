using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorteDeCoração.ModelDto
{
    // TABLE NAME 'PRODUCT'
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }


        public ModelDto[] ProductModels { get; set; }
        public FileDto[] ProductPictures { get; set; }
    }
}
