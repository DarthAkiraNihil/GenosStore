﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenosStore.Model.Entity.Orders {
    [Table("public.CartItems")]
    public class CartItem {
        [Key]
        [Column(Order = 1)]
        public int CartId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ItemId { get; set; }
		
        [Column(Order = 3)]
        public int Quantity { get; set; }

        public virtual Item.Item Item { get; set; }
        public virtual Cart Cart { get; set; }
    }
}