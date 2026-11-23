using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesLib
{
    public static class ChecksumHelper
    {
        private const string MachineKey = "asdf";
        private const char EqualSign = '=';

        public static void CalcChecksum(this Account account)
        {
            account.Checksum = Md5Helper.Encrypt(GetChecksumInput(account), MachineKey);
        }

        public static void CalcChecksum(this AccountHistory account)
        {
            account.Checksum = Md5Helper.Encrypt(GetChecksumInput(account), MachineKey);
        }

        public static bool IsChecksumValid(this Account account, string value)
        {
            return Md5Helper.VerifyMd5Hash(GetChecksumInput(account), value, account.Checksum);
        }

        public static bool IsChecksumValid(this Account account)
        {
            return Md5Helper.VerifyMd5Hash(GetChecksumInput(account), MachineKey, account.Checksum);
        }

        public static bool IsChecksumValid(this AccountHistory account)
        {
            return Md5Helper.VerifyMd5Hash(GetChecksumInput(account), MachineKey, account.Checksum);
        }

        private static string GetChecksumInput(Account account)
        {
            return Helper.Append(account.ProgramId, EqualSign, account.AccountNumber, EqualSign, account.ValueType, EqualSign, account.BalanceAvailable, EqualSign, account.BalanceFrozen, EqualSign,
                account.Status);
        }

        private static string GetChecksumInput(AccountHistory account)
        {
            return Helper.Append(account.ProgramId, EqualSign, account.AccountNumber, EqualSign, account.ValueType, EqualSign, account.BalanceAvailable, EqualSign, account.BalanceFrozen, EqualSign,
                account.Status);
        }

        public static void CalcChecksum(this Transaction transaction, string securityKeyValue)
        {
            transaction.Checksum = Md5Helper.Encrypt(GetChecksumInput(transaction), securityKeyValue);
        }

        //public static void CalcChecksum(this Transaction transaction)
        //{
        //    transaction.Checksum = Md5Helper.Encrypt(GetChecksumInput(transaction), transaction.SecurityKey.Value);
        //}

        //public static void CalcChecksum(this TransactionHistory transaction)
        //{
        //    transaction.Checksum = Md5Helper.Encrypt(GetChecksumInput(transaction), transaction.SecurityKey.Value);
        //}

        public static void CalcChecksum(this TransactionHistory transaction, string securityKeyValue)
        {
            transaction.Checksum = Md5Helper.Encrypt(GetChecksumInput(transaction), securityKeyValue);
        }

        public static bool IsChecksumValid(this Transaction transaction, string securityKeyValue)
        {
            return Md5Helper.VerifyMd5Hash(GetChecksumInput(transaction), securityKeyValue, transaction.Checksum);
        }

        //public static bool IsChecksumValid(this Transaction transaction)
        //{
        //    return Md5Helper.VerifyMd5Hash(GetChecksumInput(transaction), transaction.SecurityKey.Value, transaction.Checksum);
        //}

        private static string GetChecksumInput(Transaction transaction)
        {
            return Helper.Append(transaction.AccountNumber, EqualSign, transaction.BalanceAvailable, EqualSign, transaction.BalanceFrozen, EqualSign, transaction.TranCode, EqualSign,
                transaction.TranCodeRef, EqualSign, transaction.RefundedAmount, EqualSign, transaction.TranType.ToString(), EqualSign, transaction.TranAmount, EqualSign, transaction.Status,
                EqualSign, transaction.ResponseCode);
        }

        private static string GetChecksumInput(TransactionHistory transaction)
        {
            return Helper.Append(transaction.AccountNumber, EqualSign, transaction.BalanceAvailable, EqualSign, transaction.BalanceFrozen, EqualSign, transaction.TranCode, EqualSign,
                transaction.TranCodeRef, EqualSign, transaction.RefundedAmount, EqualSign, transaction.TranType.ToString(), EqualSign, transaction.TranAmount, EqualSign, transaction.Status,
                EqualSign, transaction.ResponseCode);
        }
    }
}
