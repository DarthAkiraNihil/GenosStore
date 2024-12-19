using System;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Services.Interface.Navigation;
using GenosStore.Utility.AbstractViewModels;
using GenosStore.Utility.Types.Enum;
using GenosStore.ViewModel.Admin;
using GenosStore.ViewModel.AuthRegister;
using GenosStore.ViewModel.ItemList;
using GenosStore.ViewModel.ItemPage;
using GenosStore.ViewModel.Main;
using GenosStore.ViewModel.Order;

namespace GenosStore.Services.Implementation.Navigation {
    public class ViewModelFactory: IViewModelFactory {
        
        public AbstractViewModel CreateViewModel(PageTypeDescriptor pageType, IServices services) {
            switch (pageType) {
                case PageTypeDescriptor.Authorization: {
                    return new AuthorizationPageModel(services);
                }
                case PageTypeDescriptor.RegisterIndividual: {
                    return new RegisterIndividualPageModel(services);
                }
                case PageTypeDescriptor.RegisterLegal: {
                    return new RegisterLegalPageModel(services);
                }
            }
            
            return null;
        }


        public AbstractViewModel CreateViewModel(PageTypeDescriptor pageType, IServices services, User user, int? id = null, ItemTypeDescriptor? itemType = null) {
            switch (pageType) {
                case PageTypeDescriptor.Dashboard: {
                    return new DashboardPageModel(services, user);
                }
                case PageTypeDescriptor.OrderManagement: {
                    return new OrderManagementPageModel(services, user);
                }
                case PageTypeDescriptor.SingleOrderManagement: {
                    return new SingleOrderManagementPageModel(services, user, (int) id);
                }
                case PageTypeDescriptor.LegalEntityVerification: {
                    return new LegalEntityVerificationPageModel(services, user);
                }
                case PageTypeDescriptor.SalesAnalysisReport: {
                    return new SalesAnalysisReportPageModel(services, user);
                }

                case PageTypeDescriptor.DiscountManagement: {
                    return new DiscountManagementPageModel(services, user);
                }
                
                case PageTypeDescriptor.ItemPage: {
                    if (itemType == null || id == null) {
                        throw new ArgumentException("Invalid page type or id for item page");
                    }

                    switch (itemType) {
                        case ItemTypeDescriptor.ComputerCase: {
                            return new ComputerCasePageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.CPU: {
                            return new CPUPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.CPUCooler: {
                            return new CPUCoolerPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.Display: {
                            return new DisplayPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.GraphicsCard: {
                            return new GraphicsCardPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.HDD: {
                            return new HDDPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.Keyboard: {
                            return new KeyboardPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.Motherboard: {
                            return new MotherboardPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.Mouse: {
                            return new MousePageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.NVMeSSD: {
                            return new NVMeSSDPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.PowerSupply: {
                            return new PowerSupplyPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.PreparedAssembly: {
                            return new PreparedAssemblyPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.RAM: {
                            return new RAMPageModel(services, user, (int) id);
                        }
                        case ItemTypeDescriptor.SataSSD: {
                            return new SataSSDPageModel(services, user, (int) id);
                        }
                    }
                    
                    return null;
                }
                
                case PageTypeDescriptor.ItemList: {
                    if (itemType == null) {
                        throw new ArgumentException("Invalid page type for item list page");
                    }

                    switch (itemType) {
                        case ItemTypeDescriptor.ComputerCase: {
                            return new ComputerCasesListModel(services, user);
                        }
                        case ItemTypeDescriptor.CPU: {
                            return new CPUsListModel(services, user);
                        }
                        case ItemTypeDescriptor.CPUCooler: {
                            return new CPUCoolersListModel(services, user);
                        }
                        case ItemTypeDescriptor.Display: {
                            return new DisplaysListModel(services, user);
                        }
                        case ItemTypeDescriptor.GraphicsCard: {
                            return new GraphicsCardsListModel(services, user);
                        }
                        case ItemTypeDescriptor.HDD: {
                            return new HDDsListModel(services, user);
                        }
                        case ItemTypeDescriptor.Keyboard: {
                            return new KeyboardsListModel(services, user);
                        }
                        case ItemTypeDescriptor.Motherboard: {
                            return new MotherboardsListModel(services, user);
                        }
                        case ItemTypeDescriptor.Mouse: {
                            return new MousesListModel(services, user);
                        }
                        case ItemTypeDescriptor.NVMeSSD: {
                            return new NVMeSSDsListModel(services, user);
                        }
                        case ItemTypeDescriptor.PowerSupply: {
                            return new PowerSuppliesListModel(services, user);
                        }
                        case ItemTypeDescriptor.PreparedAssembly: {
                            return new PreparedAssembliesListModel(services, user);
                        }
                        case ItemTypeDescriptor.RAM: {
                            return new RAMsListModel(services, user);
                        }
                        case ItemTypeDescriptor.SataSSD: {
                            return new SataSSDsListModel(services, user);
                        }
                    }
                    
                    return null;
                }
        
                case PageTypeDescriptor.BankCards: {
                    return new BankCardsModel(services, user);
                }
                case PageTypeDescriptor.Cart: {
                    return new CartPageModel(services, user);
                }
                case PageTypeDescriptor.ItemCatalogue: {
                    return new ItemCatalogueModel(services, user);
                }
                case PageTypeDescriptor.Main: {
                    return new MainPageModel(services, user);
                }
        
                // case PageTypeDescriptor.Payment: {
                //     return new PaymentPageModel(services, user, id);
                // }
                case PageTypeDescriptor.Order: {
                    return new OrderPageModel(services, user, id);
                }
                case PageTypeDescriptor.OrderHistory: {
                    return new OrderHistoryPageModel(services, user);
                }
                // case PageTypeDescriptor.SuccessfulPayment: {
                //     return new SuccessfulPaymentPageModel(services, user);
                // }
            }

            return null;
        }

        public AbstractViewModel CreateViewModel(PageTypeDescriptor pageType, IServices services, User user, Order order) {
            switch (pageType) {
                case PageTypeDescriptor.Payment: {
                    return new PaymentPageModel(services, user, order);
                }
                case PageTypeDescriptor.SuccessfulPayment: {
                    return new SuccessfulPaymentPageModel(services, user, order);
                }
            }

            return null;
        }
    }
}