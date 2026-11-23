using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 100000; i++)
            //{
            //    Process p = new Process();
            //    p.Do();
            //    Console.WriteLine($"Finished {i}");
            //}

            DataProvider dp = new DataProvider();
            List<CheckParaData> list = dp.GetCheckParaData();

            foreach (CheckParaData data in list)
            {
                StringBuilder sbTag = new StringBuilder();
                StringBuilder sbVal = new StringBuilder();
                List<List<ParamDTO>> repeaterParamList = null;
                List<string> tempEmailTemplateTagList = new List<string>();
                SampleData sample = dp.CheckSampleData(data.MessageId);
                VoucherInfo vi = dp.GetVoucherInfo(data.MessageLocalId);
                List<string> tempList = ContentTagValueHelper.GetMWVEmailTemplateTags(sample.EmailTemplate).Select(item => "{" + item.ToLower() + "}").ToList();
                List<ParamDTO> paraList = CommonMethod.XmlToList(sample.Parameters);
                var repeaterParam = paraList.Where(p => p.Name.Equals(ApplicationConstant.RepeaterFlag)).FirstOrDefault();
                if (repeaterParam != null)
                {
                    repeaterParamList = CommonMethod.DeserializeFromJson<List<List<ParamDTO>>>(repeaterParam.Value);
                    if (repeaterParamList != null)
                    {
                        repeaterParamList.ForEach(p => paraList.AddRange(p));
                    }

                    paraList.Remove(repeaterParam);
                }

                foreach (string item in tempList)
                {
                    if (item.Count() < 50)
                    {
                        tempEmailTemplateTagList.Add(item);
                    }
                }

                List<string> tempXmlTagList = paraList.Select(item => item.Name.ToLower()).ToList();

                foreach (string EmailTemplateTag in tempEmailTemplateTagList)
                {
                    if (!tempXmlTagList.Contains(EmailTemplateTag))
                    {
                        sbTag.AppendLine(EmailTemplateTag);
                    }
                }

                string str = sbTag.ToString();

                if (sbTag.Length > 0)
                {
                    Console.WriteLine($"CheckingId: {data.CheckParaId}");
                    dp.UpdateCheckingResultWithMissingTag(data.CheckParaId, vi.ClientName, vi.ProductCode, str);
                }
                else
                {
                    Console.WriteLine($"CheckingId: {data.CheckParaId} needs to be corrected");
                    dp.UpdateCheckingResult(data.CheckParaId, vi.ClientName, vi.ProductCode);
                }

           
            }



        }
    }
}
