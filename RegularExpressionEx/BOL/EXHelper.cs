using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BOL
{
    public static class EXHelper
    {
        /// <summary>
        /// check emailAddresses is validation or not
        /// </summary>
        /// <param name="emailAddresses"></param>
        /// <returns></returns>
        //public static int isValidEmail(string emailAddresses)
        //{
        //    int ret = 0;

        //    if (emailAddresses == null || emailAddresses.Length == 0)
        //    {
        //        return ret;
        //    }

        //    if (!emailAddresses.Contains(';'))
        //    {
        //        if (isEmail(emailAddresses))
        //        {
        //            ret++;
        //        }
        //        return ret;
        //    }
        //    else
        //    {
        //        string[] emailArray = emailAddresses.Split(';');
        //        for (int i = 0; i < emailArray.Count(); i++)
        //        {
        //            //这里防止出现heyitang@qq.com;heyitang@163.com;;多加了;这时候，数组中可能有元素没有内容
        //            if (emailArray[i] != null && emailArray[i].Trim() != "")
        //            {
        //                if (!isEmail(emailArray[i]))
        //                {
        //                    ret = 0;
        //                    break;
        //                }
        //                else
        //                {
        //                    ret++;
        //                }
        //            }
        //        }
        //    }
        //    return ret;
        //}

        /// <summary>
        /// check emailAddresses is validation or not
        /// </summary>
        /// <param name="emailAddresses"></param>
        /// <returns></returns>
        public static int isValidEmail(string emailAddresses)
        {
            int ret = 0;

            if (emailAddresses == null || emailAddresses.Length == 0)
            {
                return ret;
            }

            if (!emailAddresses.Contains(';'))
            {
                if (isEmail(emailAddresses))
                {
                    ret++;
                }
                return ret;
            }
            else
            {
                string[] emailArray = emailAddresses.Split(';');
                for (int i = 0; i < emailArray.Count(); i++)
                {
                    //这里防止出现heyitang@qq.com;heyitang@163.com;;多加了;这时候，数组中可能有元素没有内容
                    if (emailArray[i] != null && emailArray[i].Trim() != "")
                    {
                        if (!isEmail(emailArray[i]))
                        {
                            ret = 0;
                            break;
                        }
                        else
                        {
                            ret++;
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// IS Email
        /// </summary>
        /// <param name="inputEmail"></param>
        /// <returns></returns>
        public static bool isEmail(string inputEmail)
        {
            string strRegex =
            @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(inputEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //public static bool IsValidEmail(string email)
        //{
        //    return System.Text.RegularExpressions.Regex.IsMatch(email, CommonRegularExpression.ValidEmail);
        //}

        public static bool IsValidMobileNo(string mobileNo)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(mobileNo, CommonRegularExpression.ValidMobileNo);
        }


    }
}
