using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendMacnhine
{
    public class VendMAchine
    {
        int amount;
        public int Change{get; set;}

        public int GetTotal()
        {
            return amount;
        }

        public bool Insert(int amountMoney)
        {

            var okMoney = new List<int> { 10, 50, 100, 500, 1000 };

            if (okMoney.Contains(amountMoney))
            {
                amount += amountMoney;
            }
            else
            {
                this.Change = amountMoney;
            }
            return true;
        }

        public void PayBack()
        {
            this.Change = this.amount;
            this.amount=0;
        }



    }
}
