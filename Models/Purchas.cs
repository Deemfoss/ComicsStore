using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ComicsStores.Models
    {
    
    public class Purchas
    {
       public int Id { get; set; }
       public DateTime Data { get; set; }
       public int  IdProducts { get; set; }

        [Required(ErrorMessage = "Введите свое имя")]
        public string NameUser { get; set; }

        [Required(ErrorMessage = "Введите почту")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage ="Введите ")]//http://emailregex.com/
        public string Mail { get; set; }


        public string Delivery { get; set; }


        [Required(ErrorMessage = "Заполните адресс")]
        public string Adress { get; set; }
        
        [Required(ErrorMessage = "Введите номер телефона")]
       // [DisplayFormat(DataFormatString = "{0:###-###-####}")]
         public string PhoneNumber { get; set; }
    //  public  Product Product{ get; set; }
       // public ICollection<ShopingCart> ShopingCart { get; set; }

        //public Purchas()
        ///{
          //  ShopingCart = new List<ShopingCart>();
        //}
    }
}