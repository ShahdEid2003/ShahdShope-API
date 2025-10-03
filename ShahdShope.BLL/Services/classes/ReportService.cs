using ShahdShope.DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;

namespace ShahdShope.BLL.Services.classes
{
    public class ReportService
    {
        private readonly IProductRepository _productRepository;

        public ReportService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public void GenerateProductReport()
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("ShahdShope-Products")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            foreach (var products in _productRepository.GetAllproductWithImage())
                            {
                                x.Item().Text($"Name: {products.Name}.. Id: {products.Id}");
                            }

                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf("ShahdShope-Products.pdf!");
        }
    }
}
