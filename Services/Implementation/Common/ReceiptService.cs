using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Common;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GenosStore.Services.Implementation.Common {
    public class ReceiptService: IReceiptService {
        
        private readonly IPaymentService paymentService;

        public ReceiptService(IPaymentService paymentService) {
            this.paymentService = paymentService;
        }

        public void CreateOrderReceipt(Customer customer, Order order, string path) {

            string orderer = paymentService.GetOrdererInfo(customer);
            string createdAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            
            Document.Create(container => {
                container.Page(page => {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text($"Чек для заказа №{order.Id}")
                        .SemiBold()
                        .FontSize(36)
                        .FontColor(Colors.Blue.Medium)
                        .FontFamily("Arial");

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().ColumnSpan(3).Text("I've fucked with dis");

                            foreach (var item in order.Items) {
                                table.Cell().Text(item.Item.Name);
                                table.Cell().Text(item.Quantity.ToString());
                                table.Cell().Text((item.Quantity * item.BoughtFor).ToString());
                            }
                        });
                        
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Penis music ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(path);
        }
    }
}