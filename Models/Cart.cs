using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models.Entity;
namespace WebApplication5.Models
{
    public class Cart                                   //total cart                              
    {
        private List<CartLine> _cartLines = new List<CartLine>(); // we collect all datas on _cartLines when we would getting the _carLine
                                                                  // using by public CartLines.
        public List<CartLine> CartLines      //G
        {
            get
            {
                return _cartLines;
            }
        }

        public void AddProduct(tbl_urunler urunler, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Urunler.urunid == urunler.urunid); // query is it empty ?
            if (line == null)
            {
                {
                    _cartLines.Add(new CartLine()
                    {
                        Urunler = urunler,
                        Quantity = quantity
                    }
                    );
                }
            }
            else
            {
                line.Quantity += quantity;  //while THE cart contain product, increase quantity of product.
            }
        }



        public void DeleteProduct(tbl_urunler urunler)
        {
            _cartLines.RemoveAll(i => i.Urunler.urunid == urunler.urunid);

        }

        public double Total()
        {
            return (double)_cartLines.Sum(i => i.Urunler.urunfiyat * i.Quantity);
        }

        public void Clear()




        {
            _cartLines.Clear();
        }
        public class CartLine //each line
        {
            public tbl_urunler Urunler { get; set; }
            public int Quantity { get; set; }
        }
    }
}

