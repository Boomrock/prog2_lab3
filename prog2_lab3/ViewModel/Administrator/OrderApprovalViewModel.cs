using prog2_lab3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class OrderApprovalViewModel: ViewModel
    {
        private ObservableCollection<Order> ordersForAproval;
        public ObservableCollection<Order> OrdersForAproval { get => ordersForAproval; set => ordersForAproval = value; }
        public OrderApprovalViewModel()
        {
            OrdersForAproval = new ObservableCollection<Order>
            {
                new Order(1, Сategories.SecondCatigory, new Models.realisation.Owner("Fedor", "Lyagushin", "Alekseevich", 1, "gorlopan", "123321q"), false),
            };

        }

       
    }
}
