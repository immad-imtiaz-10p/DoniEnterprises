using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NReco.PdfGenerator;
using System.IO;

namespace de_server.Reporting
{
    public class PdfService
    {
        public static string reportFooter = "/App_Config/ReportTemplate/ReportFooter.html";
        public static string reportHeader = "/App_Config/ReportTemplate/ReportHeader.html";
        public static string allProduct = "/App_Config/ReportTemplate/allProductTemplate.html";
        public byte[] getPDF()
        {
            HtmlToPdfConverter pdfConverter = GetConverter();
            return pdfConverter.GeneratePdf(CreatePDFScript() + ShowHTML() + "</body></html>");
        }

        public byte[] getPDF(string content)
        {
            HtmlToPdfConverter pdfConverter = GetConverter();
            return pdfConverter.GeneratePdf(CreatePDFScript() + content + "</body></html>");
        }
        public HtmlToPdfConverter GetConverter()
        {
            HtmlToPdfConverter pdfConverter = new HtmlToPdfConverter();
            pdfConverter.Orientation = PageOrientation.Portrait;
            pdfConverter.PageFooterHtml = CreatePDFFooter();
            pdfConverter.PageHeaderHtml = CreatePDFHeader();
            pdfConverter.CustomWkHtmlArgs = "--margin-top 20 --header-spacing 10 --margin-left 15 --margin-right 15 --margin-bottom 15";
            return pdfConverter;
        }

        public string ShowHTML()
        {
            
            return "<div>My PDF</div>";
        }

        public string CreatePDFFooter()
        {
            String body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(PdfService.reportFooter)))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        public string CreatePDFHeader()
        {
            String body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(PdfService.reportHeader)))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Date}", DateTime.Today.ToString("D"));
            return body;
        }

        private string CreatePDFScript()
        {
            return "<html><head><style>body{font-family: 'Open Sans', sans-serif;}td,th{line-height:20px;}" +
                   "tr { page-break-inside: avoid }</style><script>function subst()" +
                   "{var vars={};var x=document.location.search.substring(1).split('&');" +
                   "for(var i in x) {var z=x[i].split('=',2);vars[z[0]] = unescape(z[1]);}" +
                   "var x=['frompage','topage','page','webpage','section','subsection','subsubsection'];for(var i in x)" +
                   "{var y = document.getElementsByClassName(x[i]);for(var j=0; j<y.length; ++j)" +
                   " y[j].textContent = vars[x[i]];}}</script><link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'></head><body onload=\"subst()\">";
        }
    }
}