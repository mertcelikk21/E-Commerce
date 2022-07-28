using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicaret.Dtos
{
    public class CustomerBasketDto
    {
        
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } 
    }
}
