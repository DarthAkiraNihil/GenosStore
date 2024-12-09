using System.Collections.Generic;
using System.Windows.Documents;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Utility.QuestPDFExtensions;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GenosStore.Services.Implementation.Common {
    public class ReceiptService: IReceiptService {
        
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;

        private readonly List<string> _headerTitles = new List<string> {
            "Наименование предмета", "Цена за единицу (руб.)", "Количество (шт.)", "Итого (руб.)"
        };

        public ReceiptService(IPaymentService paymentService, IOrderService orderService) {
            _paymentService = paymentService;
            _orderService = orderService;
        }

        public void CreateOrderReceipt(Customer customer, Order order, string path) {

            string orderer = _paymentService.GetOrdererInfo(customer);
            string createdAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
            
            Document.Create(container => {
                container.Page(page => {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(8).FontFamily("Arial"));

                    page.Header()
                        .Text($"Чек для заказа №{order.Id}")
                        .SemiBold()
                        .FontSize(16)
                        .AlignCenter();

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column => {
                            column.Item().Text($"Создан: {createdAt}").FontSize(12);
                            column.Item().Text($"Заказчик: {orderer}").FontSize(12);
                            column.Item().Text($"Статус: {order.OrderStatus.Name}").FontSize(12);
                            column.Item().Table(table => {
                                table.ColumnsDefinition(columns => {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                foreach (var title in _headerTitles) {
                                    table.Cell().LabelCell(title);
                                }
                            
                                foreach (var item in order.Items) {
                                    _fillItemRow(table, item);
                                }
                            });
                            column.Item()
                                  .Text($"Итого: {_orderService.CalculateTotal(order)} руб.")
                                  .AlignRight()
                                  .FontSize(14)
                                  .Bold();
                        });
                        
                    
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Страница ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(path);
        }

        private void _fillItemRow(TableDescriptor table, OrderItems item) {
            var boughtFor = item.BoughtFor;
            var quantity = item.Quantity;
            var total = boughtFor * quantity;
            
            table.Cell()
                 .ValueCell()
                 .Text(item.Item.Name);
            table.Cell()
                 .ValueCell()
                 .Text(boughtFor.ToString("0.00"));
            table.Cell()
                 .ValueCell()
                 .Text(quantity.ToString());
            table.Cell()
                 .ValueCell()
                 .Text(total.ToString("0.00"));
        }
    }
}