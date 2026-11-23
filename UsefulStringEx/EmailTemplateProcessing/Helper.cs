using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EmailTemplateProcessing
{
    public class Helper
    {
        public static string GetRealContent(string template, string parameters)
        {
            string result = template;
            if (string.IsNullOrEmpty(parameters))
                return result;
            List<ParamDTO> paramList = CommonMethod.XmlToList(parameters);

            var repeaterParam = paramList.Where(p => p.Name.Equals(Consts.RepeaterFlag)).FirstOrDefault();
            var INTableParam = paramList.Where(p => p.Name.Equals(Consts.INTableTag)).FirstOrDefault();
            var INSVTableParam = paramList.Where(p => p.Name.Equals(Consts.INSVTableTag)).FirstOrDefault();
            List<List<ParamDTO>> repeaterParamList = null;
            List<ParamDTO> repeaterParams = new List<ParamDTO>();
            if (repeaterParam != null)
            {
                repeaterParamList = CommonMethod.DeserializeFromJson<List<List<ParamDTO>>>(repeaterParam.Value);
                if (repeaterParamList != null)
                {
                    repeaterParamList.ForEach(p => repeaterParams.AddRange(p));
                }
            }

            if (INTableParam != null)
            {
                var INTableParamList = CommonMethod.DeserializeFromJson<List<List<ParamDTO>>>(INTableParam.Value);
                var hasPinCode = INTableParamList.All(x => x.Any(y => y.Name == "{IN.TablePinCode}" && !string.IsNullOrEmpty(y.Value)));
                var hasGCID = INTableParamList.All(x => x.Any(y => y.Name == "{IN.TableGCID}" && !string.IsNullOrEmpty(y.Value)));
                var tableContent = BuildINTable(hasPinCode, hasGCID, INTableParamList);
                result = result.Replace(Consts.INTableTag, tableContent);

                foreach (ParamDTO dto in INTableParamList[0])
                {
                    result = result.Replace(dto.Name, dto.Value);
                }
            }

            if (INSVTableParam != null)
            {
                var INTableParamList = CommonMethod.DeserializeFromJson<List<List<ParamDTO>>>(INSVTableParam.Value);
                var tableContent = BuildINSVTable(INTableParamList);
                result = result.Replace(Consts.INSVTableTag, tableContent);

                foreach (ParamDTO dto in INTableParamList[0])
                {
                    result = result.Replace(dto.Name, dto.Value);
                }
            }

            if (result.IndexOf(Consts.RepeaterFlag, StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                foreach (ParamDTO dto in paramList)
                {
                    result = result.Replace(dto.Name, dto.Value);
                }
                if (result.IndexOf("{") > 0)
                {
                    foreach (ParamDTO dto in repeaterParams)
                    {
                        result = result.Replace(dto.Name, dto.Value);
                        if (result.IndexOf("{") <= 0)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                string temp = template;
                StringBuilder sb = new StringBuilder();
                do
                {
                    var repeaterBefore = CommonMethod.StringBefore(temp, Consts.RepeaterFlag);
                    foreach (ParamDTO dto in paramList)
                    {
                        repeaterBefore = repeaterBefore.Replace(dto.Name, dto.Value);
                    }
                    if (repeaterBefore.IndexOf("{") > 0)
                    {
                        foreach (ParamDTO dto in repeaterParams)
                        {
                            repeaterBefore = repeaterBefore.Replace(dto.Name, dto.Value);
                            if (repeaterBefore.IndexOf("{") <= 0)
                            {
                                break;
                            }
                        }
                    }
                    sb.Append(repeaterBefore);

                    var repeaterString = CommonMethod.StringBetween(temp, Consts.RepeaterFlag, Consts.RepeaterEndFlag);
                    if (repeaterParamList != null && repeaterParamList.Count > 0)
                    {
                        foreach (var ps in repeaterParamList)
                        {
                            var rs = string.Copy(repeaterString);
                            foreach (var p in ps)
                            {
                                rs = rs.Replace(p.Name, p.Value);
                            }
                            if (rs.IndexOf("{") > 0)
                            {
                                foreach (ParamDTO dto in paramList)
                                {
                                    rs = rs.Replace(dto.Name, dto.Value);
                                }
                            }
                            sb.Append(rs);
                        }
                    }
                    else
                    {
                        sb.Append(repeaterString);
                    }
                    temp = CommonMethod.StringAfter(temp, Consts.RepeaterEndFlag);

                } while (temp.IndexOf(Consts.RepeaterFlag, StringComparison.InvariantCultureIgnoreCase) > 0);
                if (!string.IsNullOrEmpty(temp))
                {
                    foreach (ParamDTO dto in paramList)
                    {
                        temp = temp.Replace(dto.Name, dto.Value);
                    }
                    if (temp.IndexOf("{") > 0)
                    {
                        foreach (ParamDTO dto in repeaterParams)
                        {
                            temp = temp.Replace(dto.Name, dto.Value);
                            if (temp.IndexOf("{") <= 0)
                            {
                                break;
                            }
                        }
                    }
                    sb.Append(temp);
                }

                result = sb.ToString();
            }

            if (result.IndexOf("{") > 0)
            {
                string pattern = @"<img[^<>]*[{][0-9a-zA-Z_\.]+[}][^<>]*>";//替换掉未赋值的img标签
                var matches = Regex.Matches(result, pattern);
                if (matches != null && matches.Count > 0)
                {
                    foreach (Match item in matches)
                    {
                        result = result.Replace(item.Value, string.Empty);
                    }
                }
            }

            return result;
        }

        private static string BuildINTable(bool hasPinCode, bool hasGCID, List<List<ParamDTO>> paramDTOs)
        {
            var sb = new StringBuilder();
            //sb.Append("<table style='border-collapse:collapse;border-spacing:0;border-color:#aaa; width:100%;'><tr>" +
            sb.Append("<table cellpadding='5' cellspacing='0' border='1' bordercolor='#aaa' width='100%'><tr>" +
                "<TH align='center'  style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BACKGROUND-COLOR: #666'>Face Value</TH>" +
                "<TH align='center' style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid; BACKGROUND-COLOR: #666' align=center>QR Code</TH>" +
                "<TH align='center' style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid; BACKGROUND-COLOR: #666'>Voucher Code</TH>" +
                    (hasPinCode ? "<TH align='center' style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid; BACKGROUND-COLOR: #666' align=center>Voucher Pin</TH>" : string.Empty) +
                    "<TH align='center' style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; WORD-BREAK: break-all; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid; BACKGROUND-COLOR: #666' align=center>Expiry Date</TH>" +
                    (hasGCID ? "<TH align='center' style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; WORD-BREAK: break-all; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid; BACKGROUND-COLOR: #666'>GCID</TH></tr>" : "<TH align='center' style='FONT-SIZE: 14px; FONT-FAMILY: Helvetica, arial, sans-serif; WORD-BREAK: break-all; FONT-WEIGHT: 600; COLOR: #fff;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid; BACKGROUND-COLOR: #666'>GUID</TH></tr>"));

            foreach (var paras in paramDTOs)
            {
                sb.Append("<tr><td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TableFaceValue}").Value +
                    "</td><td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TableQrCode}").Value + "</td>" +
                    "<td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TableVoucherNumber}").Value + "</td>" +
                    (hasPinCode ? "<td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TablePinCode}").Value + "</td>" : string.Empty) +
                    "<td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TableExpiryDate}").Value + "</td>" +
                    (hasGCID ? "<td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; WORD-BREAK: break-all; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TableGCID}").Value + "</td></tr>" : "<td align='center' style='FONT-SIZE: 12px; BORDER-TOP: #aaa 1px solid; FONT-FAMILY: Helvetica, arial, sans-serif; BORDER-RIGHT: #aaa 1px solid; BORDER-BOTTOM: #aaa 1px solid; WORD-BREAK: break-all; COLOR: #555;border-style:solid;border-width:1px;border-color:#aaa; TEXT-ALIGN: center; BORDER-LEFT: #aaa 1px solid' align=center>" + paras.FirstOrDefault(x => x.Name == "{IN.TableGUID}").Value + "</td></tr>"));
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        private static string BuildINSVTable(List<List<ParamDTO>> paramDTOs)
        {
            var sb = new StringBuilder();
            sb.Append("<table cellspacing='0' style='text-align:center; FONT-FAMILY:Helvetica,arial,sans-serif;' cellpadding='5' border='1' bordercolor='#aaa' align='center'><tr>" +
                "<TH style='FONT-SIZE: 14px; FONT-WEIGHT: 600; COLOR: #fff; TEXT-ALIGN: center; BACKGROUND-COLOR: #666'; width: 50px;>Face Value</TH>" +
                "<TH style='FONT-SIZE: 14px; FONT-WEIGHT: 600; COLOR: #fff; TEXT-ALIGN: center; BACKGROUND-COLOR: #666'; width: 300px;>Short URL</TH>" +
                "<TH style='FONT-SIZE: 14px; FONT-WEIGHT: 600; COLOR: #fff; TEXT-ALIGN: center; BACKGROUND-COLOR: #666'; width: 50px;>PIN</TH>" +
                "<TH style='FONT-SIZE: 14px; FONT-WEIGHT: 600; COLOR: #fff; TEXT-ALIGN: center; BACKGROUND-COLOR: #666'; width: 100px;>Expiry Date</TH>");

            foreach (var paras in paramDTOs)
            {
                var shortUrlvalue = paras.FirstOrDefault(x => x.Name == "{ShortUrl}").Value;
                sb.Append("<tr><td style='FONT-SIZE: 12px;'>" + paras.FirstOrDefault(x => x.Name == "{IN.TableFaceValue}").Value + "</td>" +
                    "<td style='FONT-SIZE: 12px;'><a href='" + shortUrlvalue + "' target='_blank'>" + shortUrlvalue + "</a></td>" +
                    "<td style='FONT-SIZE: 12px;'>" + paras.FirstOrDefault(x => x.Name == "{IN.TableShortUrlAuthCode}").Value + "</td>" +
                     "<td style='FONT-SIZE: 12px;'>" + paras.FirstOrDefault(x => x.Name == "{IN.TableExpiryDate}").Value + "</td>" + "</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
    }
}
