using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class VoucherImporterFactory
    {
        public static readonly List<IVoucherImportChecker> IVoucherImporterList;        

        static VoucherImporterFactory()
        {
            IVoucherImporterList = new List<IVoucherImportChecker>(16);
            var assembly = Assembly.GetExecutingAssembly();
            var list = assembly.GetExportedTypes().Where(t => (t.IsClass && !t.IsAbstract && typeof(IVoucherImportChecker).IsAssignableFrom(t)));
            foreach (Type item in list)
            {
                IVoucherImportChecker obj = Activator.CreateInstance(item) as IVoucherImportChecker;
                IVoucherImporterList.Add(obj);
            }
        }

        public IVoucherImporter Create(VoucherImportTemplateType template)
        {
            IVoucherImporter iVoucherImporter = null;

            switch (template)
            {
                case VoucherImportTemplateType.GRVoucher:
                    iVoucherImporter = new GRVoucherImporter();
                    break;
                case VoucherImportTemplateType.TWStarbucksVoucher:
                    iVoucherImporter = new TWStarbucksVoucherImporter();
                    break;
                case VoucherImportTemplateType.TWSoftWorldVoucher:
                    iVoucherImporter = new TWSoftWorldVoucherImporter();
                    break;
                case VoucherImportTemplateType.SGVoucher:
                    iVoucherImporter = new SGImporter();
                    break;
                default:
                    break;
            }

            if (iVoucherImporter != null)
            {
                return iVoucherImporter;
            }

            foreach (var importer in IVoucherImporterList)
            {
                if (importer.CheckImporter(template))
                {
                    iVoucherImporter = importer;
                    break;
                }
            }

            if (iVoucherImporter == null)
            {
                throw new Exception("Can Find Importer For This Type");
            }

            return iVoucherImporter;

            /**********新Program流程**********/
            //数据库
            //1.新增一个Program
            //2.ProgramVoucherRoute增加对应数据
            //3.VoucherImportTemplate增加对应数据
            //4.Adora的ExpirationPolicy

            //1.增加VoucherImportTemplateType枚举
            //3.继承BaseVoucherImporter，在构造函数里赋值
            //4.DataProvider.InsertThirdPartVoucherExt 增加一个case

            //如果需要Api调用，还需要下面操作
            //1.在Api.Internal的VoucherService增加对应方法
            //2.在ClientLib的VoucherManager增加对应方法
        }
    }
}
