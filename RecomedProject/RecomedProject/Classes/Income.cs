using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecomedProject.Classes
{
    class Income
    {
        List<int> debt;
        List<int> salary;
        List<int> dividends;
        

        public Income()
        {
            debt = new List<int>();
            salary = new List<int>();
            dividends = new List<int>();
        }

        public void addDebt(int price)
        {
            debt.Add(price);
        }

        public void addSalary(int price)
        {
            salary.Add(price);
        }

        public void addDividends(int price)
        {
            dividends.Add(price);
        }

        public int getGeneralDebt()
        {
            int sum = 0;
            if (debt.Count > 0)
                foreach (var elem in debt)
                    sum += elem;
            return sum;
        }

        public int getGeneralSalary()
        {
            int sum = 0;
            if (salary.Count > 0)
                foreach (var elem in salary)
                    sum += elem;
            return sum;
        }

        public int getGeneralDividends()
        {
            int sum = 0;
            if (dividends.Count > 0)
                foreach (var elem in dividends)
                    sum += elem;
            return sum;
        }

        public int getAll()
        {
            int sum = 0;
            sum += getGeneralDebt();
            sum += getGeneralDividends();
            sum += getGeneralSalary();
            return sum;
        }
    }
}
