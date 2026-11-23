using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagEx
{
    public class ProductTagHelper
    {
        public static Dictionary<string, bool> GetProductTagValue(int value)
        {
            Dictionary<string, bool> tags = new Dictionary<string, bool>();
            tags.Add(CommonConsts.Digital, false);
            tags.Add(CommonConsts.Delivery, false);
            tags.Add(CommonConsts.Paper, false);

            ProductTag voucherTag = (ProductTag)value;
            tags[CommonConsts.Digital] = voucherTag.HasFlag(ProductTag.Digital);
            tags[CommonConsts.Delivery] = voucherTag.HasFlag(ProductTag.Delivery);
            tags[CommonConsts.Paper] = voucherTag.HasFlag(ProductTag.Paper);

            return tags;
        }
    }
}
