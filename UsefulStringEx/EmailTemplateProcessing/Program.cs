using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateProcessing
{
    /*
select sm.[Parameters], smt.Content from SLMSMessage sm with(nolock)
inner join Task t with(nolock) on sm.TaskId = t.Id
inner join [dbo].[SLMSMessageTemplate] smt with(nolock) on smt.Id = t.SLMSTemplateId
where sm.Id = 6670576     
         */
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 255;
            a += 5;

            string ParasPath = "Parameters".ConfigStringValue();
            string EmailTemplatePath = "Template".ConfigStringValue();
            string Paras = File.ReadAllText(ParasPath);
            string EmailTemplate = File.ReadAllText(EmailTemplatePath);

            string content = Helper.GetRealContent(EmailTemplate, Paras);
        }
    }
}
