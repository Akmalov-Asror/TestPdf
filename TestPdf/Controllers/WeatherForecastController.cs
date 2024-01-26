using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace TestPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("generate-cv")]
        public Stream GeneratePDF()
        {
            var response = GenerateCvPdfVersion().Result;
            Response.ContentType = "application/pdf";
            return response;
        }
        private Task<MemoryStream> GenerateCvPdfVersion()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var memoryStream = new MemoryStream();

            QuestPDF.Fluent.Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);

                    page.Header().Element(header =>
                    {
                        header.Column(column =>
                        {
                            column.Item().Text("BODYLEASE.DEV").FontSize(10);
                        });
                    });

                    page.Content()
                    .Column(column =>
                    {
                        column.Item()
                            .Padding(5)
                            .AlignCenter()
                            .Text("THE PROFILE DESCRIPTION")
                            .FontSize(20)
                            .FontColor("#000000")
                            .Bold();

                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("1. SUMMARY").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text(" .NET developer with nearly one year of experience, I specialize in creating efficient and scalable solutions using C#, ASP.NET, and Entity Framework. My expertise includes working in MyCarrier environment, contributing to project.");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("2. EXPERTISE").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text(" React");
                                innerColumn.Item().PaddingLeft(10).Text(" C#");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("3.PROFESIONAL EXPERIENCE").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text(" MyCarrer Intern (5 month) Until November 27 , 2023");
                                innerColumn.Item().PaddingLeft(10).Text($" I studied JS / React / Blazor technologies");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("4.PROJECTS").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text(" MyCarrer");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("5.EDUCATION").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text("University DEF Latvia (2020-2025)");
                                innerColumn.Item().PaddingLeft(10).Text("Bachelors’s degree in Software Engineering");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("6.CERTIFICATION").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text("IT PM Certificate, Study Center ABC (2022)");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("7.LANGUAGE AND COMMUNICATION").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text("English – work proficiency, B1");
                                innerColumn.Item().PaddingLeft(10).Text("Russian – work proficiency, B1");
                                innerColumn.Item().PaddingLeft(10).Text("Uzbek – mother tongue");
                            });
                        });
                        column.Item().PaddingVertical(5).Element(section =>
                        {
                            section.Column(innerColumn =>
                            {
                                innerColumn.Item().Text("8.CONTACT-INFORMATION").FontSize(16).Bold();
                                innerColumn.Item().PaddingLeft(10).Text("Asror Akmalov, SIA E-Synergy | Bodylease.dev, akmalovasror0@gmail.com, +371 26668609");
                            });
                        });
                    });

                    // ... Additional layout code for other sections such as Education, Certification, etc.
                });
            })
            .GeneratePdf(memoryStream);



            memoryStream.Seek(0, SeekOrigin.Begin);
            return Task.FromResult(memoryStream);
        }
    }
    
}
