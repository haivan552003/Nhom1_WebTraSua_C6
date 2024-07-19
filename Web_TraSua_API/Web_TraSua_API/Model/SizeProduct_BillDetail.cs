using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_TraSua_API.Model
{
    public class SizeProduct_BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSizeProBillDetail { get; set; }
        public int IDSizeProduct { get; set; }
        public int IDSBillDetail { get; set; }

        public BillDetail bill_detail { get; set; }
        public Size_Product size_product { get; set; }
    }
}
