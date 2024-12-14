using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface.Common;
using GenosStore.Services.Interface.Entity.Items;
using GenosStore.Services.Interface.Entity.Orders;
using GenosStore.Utility.QuestPDFExtensions;
using Microcharts;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace GenosStore.Services.Implementation.Common {
    public class ReportService: IReportService {
        
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IItemTypeService _itemTypeService;

        private readonly List<string> _receiptHeaderTitles = new List<string> {
            "Наименование предмета", "Цена за единицу (руб.)", "Количество (шт.)", "Итого (руб.)"
        };

        private readonly List<string> _invoiceHeadertitles = new List<string> {
            "Наименование товара",
            "Код вида товара",
            "Единица измерения",
            "Количество",
            "Цена за единицу",
            "Стоимость товаров всего"
        };
        
        private const string _traderName = "ООО \"Genos Store Incorporated\"";
        private const string _traderAddress = "ООО \"Genos Store Incorporated\"";
        private const int _traderINN = 1000000;
        private const int _traderKPP = 1000000;
        

        public ReportService(IPaymentService paymentService, IOrderService orderService, IItemTypeService itemTypeService) {
            _paymentService = paymentService;
            _orderService = orderService;
            _itemTypeService = itemTypeService;
        }

        public void CreateOrderReceipt(Customer customer, Order order, string path) {

            if (!(customer is IndividualEntity)) {
                throw new ArgumentException("Customer must be an individual entity in order to generate receipt");
            }

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

                                foreach (var title in _receiptHeaderTitles) {
                                    table.Cell().LabelCell(title);
                                }
                            
                                foreach (var item in order.Items) {
                                    _fillReceiptItemRow(table, item);
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

        private void _fillReceiptItemRow(TableDescriptor table, OrderItems item) {
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

        public void CreateOrderInvoice(Customer customer, Order order, string path) {

            if (!(customer is LegalEntity)) {
                throw new ArgumentException("Customer must be an legal entity in order to generate invoice");
            }
            var entity = customer as LegalEntity;
            
            
            string createdAt = order.CreatedAt.ToString("dd/MM/yyyy");
            
            Document.Create(container => {
                container.Page(page => {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(8).FontFamily("Arial"));

                    page.Header()
                        .Text($"Счёт-фактура для заказа №{order.Id} от {createdAt}")
                        .SemiBold()
                        .FontSize(16)
                        .AlignCenter();

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column => {
                           _fillExtendedOrderInformation(column, entity, order);
                            column.Item().Table(table => {
                                table.ColumnsDefinition(columns => {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                foreach (var title in _invoiceHeadertitles) {
                                    table.Cell().LabelCell(title);
                                }
                            
                                foreach (var item in order.Items) {
                                    _fillInvoiceItemRow(table, item);
                                }
                            });
                            column.Item()
                                  .Text($"Всего к оплате: {_orderService.CalculateTotal(order)} руб.")
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

        private void _fillExtendedOrderInformation(ColumnDescriptor column, LegalEntity legalEntity, Order order) {
            
            string orderer = _paymentService.GetOrdererInfo(legalEntity);

            foreach (var text in new List<string> {
                 $"Продавец: {_traderName}",
                 $"Адрес: {_traderAddress}",
                 $"ИНН продавца: {_traderINN}",
                 $"КПП продавца: {_traderKPP}",
                 $"Покупатель: {orderer}",
                 $"Адрес: {legalEntity.LegalAddress}",
                 $"ИНН покупателя: {legalEntity.INN}",
                 $"КПП покупателя: {legalEntity.KPP}",
                 "Валюта: руб.",
            }) {
                column.Item().Text(text).FontSize(14);
            }
            
            
            
        }
        
        private void _fillInvoiceItemRow(TableDescriptor table, OrderItems item) {
            var boughtFor = item.BoughtFor;
            var quantity = item.Quantity;
            var total = boughtFor * quantity;
            
            table.Cell()
                 .ValueCell()
                 .Text(item.Item.Name);
            table.Cell()
                 .ValueCell()
                 .Text(item.Item.ItemType.Id.ToString());
            table.Cell()
                 .ValueCell()
                 .Text("шт.");
            table.Cell()
                 .ValueCell()
                 .Text(quantity.ToString());
            table.Cell()
                 .ValueCell()
                 .Text(boughtFor.ToString("0.00"));
            table.Cell()
                 .ValueCell()
                 .Text(total.ToString("0.00"));
        }

        public void CreateOrderHistoryReport(Customer customer, string path) {

            var orders = _orderService.ListOfSpecificCustomer(customer);
            orders.Sort((x, y) => x.Id < y.Id ? -1 : 1);
            string orderer = _paymentService.GetOrdererInfo(customer);

            Document.Create(container => {
                foreach (var order in orders) {
                    string createdAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm");

                    container.Page(page => {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8).FontFamily("Arial"));

                        page.Header()
                            .Text($"Данные по заказу №{order.Id}")
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

                                    foreach (var title in _receiptHeaderTitles) {
                                        table.Cell().LabelCell(title);
                                    }

                                    foreach (var item in order.Items) {
                                        _fillReceiptItemRow(table, item);
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
                            .Text(x => {
                                x.Span("Страница ");
                                x.CurrentPageNumber();
                            });
                    });
                }
            })
            .GeneratePdf(path);
        }

        public void GenerateSalesAnalysisReport(DateTime startDate, DateTime endDate, string path) {
            var orders = _orderService.List().Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate);
            
            var itemsFrequency = new Dictionary<string, int>();
            foreach (var type in _itemTypeService.List()) {
                itemsFrequency.Add(type.Name, 0);
            }

            foreach (var order in orders) {
                foreach (var item in order.Items) {
                    itemsFrequency[item.Item.ItemType.Name]++;
                }
            }

            var entries = new List<ChartEntry>();

            foreach (var k in itemsFrequency) {
                entries.Add(
                    new ChartEntry(k.Value) {
                        Label = k.Key,
                        ValueLabel = k.Value.ToString(),
                        Color = SKColor.Parse("#2c3e50")
                    });
            }
            
            //var chart = new PieChart() {Entries = entries};
            
            Document.Create(container => {
                container.Page(page => {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(8).FontFamily("Arial"));
                    
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            var titleStyle = TextStyle
                                             .Default
                                             .FontSize(20)
                                             .SemiBold()
                                             .FontColor(Colors.Blue.Medium);

                            column
                                .Item()
                                .PaddingBottom(10)
                                .Text("Chart example")
                                .Style(titleStyle);
    
                            column
                                .Item()
                                .Border(1)
                                .ExtendHorizontal()
                                .Height(300)
                                .SkiaSharpCanvas((canvas, size) =>
                                {
                                    var chart = new PieChart
                                    {
                                        Entries = entries,

                                        //LabelOrientation = Orientation.Horizontal,
                                        //ValueLabelOrientation = Orientation.Horizontal,
                
                                        IsAnimated = false,
                                    };
            
                                    chart.DrawContent(canvas, (int)size.Width, (int)size.Height);
                                });
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
    }
}