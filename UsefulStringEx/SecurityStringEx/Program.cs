using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityStringEx
{
    class Program
    {
        public static void EF()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("eVoucher.Mo.UnitTest"));
            string file = path + @"eVoucher.MO.Entity\eVoucher.MO.Entity.edmx";

            CommonHelper.AddEFColumn(file, "Merchant",
                new System.Data.SqlClient.SqlParameter("IssuerType", "")
                {
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                    DbType = System.Data.DbType.Byte,
                    IsNullable = true,
                    Size = 0
                });

            //无需设置DbType

            CommonHelper.AddEFColumn(file, "VoucherNumberRule",
                new System.Data.SqlClient.SqlParameter("MerchantId", "")
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    DbType = System.Data.DbType.Int32,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("RuleName", "")
                {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    DbType = System.Data.DbType.String,
                    IsNullable = true,
                    Size = 20
                },
                new System.Data.SqlClient.SqlParameter("Operater", "")
                {
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    DbType = System.Data.DbType.String,
                    IsNullable = true,
                    Size = 20
                },
                new System.Data.SqlClient.SqlParameter("GeneratedBy", "")
                {
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                    DbType = System.Data.DbType.Byte,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("PinCodeType", "")
                {
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                    DbType = System.Data.DbType.Byte,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("HasMultiBarcode", "")
                {
                    SqlDbType = System.Data.SqlDbType.Bit,
                    DbType = System.Data.DbType.Boolean,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("ShowCodeType", "")
                {
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    IsNullable = true,
                    Size = 20
                },
                new System.Data.SqlClient.SqlParameter("DisplayText", "")
                {
                    SqlDbType = System.Data.SqlDbType.Bit,
                    DbType = System.Data.DbType.Boolean,
                    IsNullable = true,
                    Size = 0
                },

                new System.Data.SqlClient.SqlParameter("ProgramId", "")
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    DbType = System.Data.DbType.Int32,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("RequireExpiryDate", "")
                {
                    SqlDbType = System.Data.SqlDbType.Bit,
                    DbType = System.Data.DbType.Boolean,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("InStockWatermark", "")
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    DbType = System.Data.DbType.Int32,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("VoucherSupplierId", "")
                {
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                    DbType = System.Data.DbType.Byte,
                    IsNullable = true,
                    Size = 0
                },
                new System.Data.SqlClient.SqlParameter("OperationParameters", "")
                {
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    IsNullable = true,
                    Size = 100
                });
        }

        static void Main(string[] args)
        {
            //string pwd = CommonHelper.GenerateRandomPassword(8);
            //EF();
            int i = new Random().Next(0, int.MaxValue);
            string str = CommonHelper.ConvertToBase36String(i, 3);
        }


    }
}
