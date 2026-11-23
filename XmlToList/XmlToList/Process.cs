using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public class Process
    {
        private DataProvider dp;
        public Process()
        {
            dp = new DataProvider();
        }

        public void Check(int MessageId)
        {
            List<List<ParamDTO>> repeaterParamList = null;
            SampleData sample = dp.CheckSampleData(MessageId);
            List<string> tempList = ContentTagValueHelper.GetMWVEmailTemplateTags(sample.EmailTemplate);
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
        }

        public void Do()
        {
            int ProcessingId = dp.GetProcessingId();
            List<SampleData> sampleDataList = dp.GetSampleData(100, ProcessingId);

            foreach (SampleData data in sampleDataList)
            {
                bool DoNotHaveTag = false;
                bool DoNotHaveVal = false;
                string Tag = string.Empty;
                string Val = string.Empty;
                string OrderNumber = string.Empty;
                StringBuilder sbTag = new StringBuilder();
                StringBuilder sbVal = new StringBuilder();
                List<string> tempEmailTemplateTagList = new List<string>();
                List<string> tempList = ContentTagValueHelper.GetMWVEmailTemplateTags(data.EmailTemplate).Select(item => "{" + item.ToLower() + "}").ToList();
                foreach (string item in tempList)
                {
                    if (item.Count() < 50)
                    {
                        tempEmailTemplateTagList.Add(item);
                    }
                }

                List<ParamDTO> paraList = CommonMethod.XmlToList(data.Parameters);
                List<string> tempXmlTagList = paraList.Select(item => item.Name.ToLower()).ToList();

                foreach (string EmailTemplateTag in tempEmailTemplateTagList)
                {
                    if (!tempXmlTagList.Contains(EmailTemplateTag))
                    {
                        sbTag.AppendLine(EmailTemplateTag);
                    }
                }

                foreach (ParamDTO para in paraList)
                {
                    if (string.IsNullOrEmpty(para.Value) || string.IsNullOrWhiteSpace(para.Value))
                    {
                        sbVal.AppendLine(para.Name);
                    }
                }

                if (sbTag.Length > 0)
                {
                    DoNotHaveTag = true;
                }

                if (sbVal.Length > 0)
                {
                    DoNotHaveVal = true;
                }

                if (DoNotHaveTag && !DoNotHaveVal)//1
                {
                    OrderNumber = dp.GetOrderNumber(data.MessageLocalId);
                    string str = sbTag.ToString();
                    if (!str.Contains("font"))
                    {
                        dp.InsertCheckingResult(data.MessageId, data.MessageLocalId, 1, str, null, OrderNumber);
                    }
                    else
                    {

                    }                    
                }
                else if (!DoNotHaveTag && DoNotHaveVal)//2
                {
                    OrderNumber = dp.GetOrderNumber(data.MessageLocalId);
                    dp.InsertCheckingResult(data.MessageId, data.MessageLocalId, 2, null, sbVal.ToString(), OrderNumber);
                }
                else if (DoNotHaveTag && DoNotHaveVal)//3
                {
                    OrderNumber = dp.GetOrderNumber(data.MessageLocalId);
                    string str = sbTag.ToString();
                    if (!str.Contains("font"))
                    {
                        dp.InsertCheckingResult(data.MessageId, data.MessageLocalId, 3, str, sbVal.ToString(), OrderNumber);
                    }
                    else
                    {

                    }                    
                }
                else
                {
                    dp.InsertCheckingResult(data.MessageId, data.MessageLocalId, 0, null, null, null);
                }
            }
        }
    }
}
