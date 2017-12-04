using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecomedProject.Classes;

namespace RecomedProject
{
    public partial class Form1 : Form
    {
        List<Month> monthes;
        Dictionary<int, string> month_name;
        public Form1()
        {
            monthes = new List<Month>();
            InitializeComponent();
            //Month m1 = new Month((int)Months.November, 2017);
            Month m1 = new Month("November 2017");
            m1.addForCharges(1, 25);
            m1.addForCharges(2, 10);
            m1.addForCharges(3, 10);
            m1.addForCharges(4, 10);
            m1.addForCharges(5, 10);
            m1.addForCharges(6, 10);
            m1.addForCharges(7, 10);
            m1.addForCharges(8, 10);

            m1.addForIncome(1, 50);
            m1.addForIncome(2, 30);
            m1.addForIncome(3, 10);

            monthes.Add(m1);

            foreach (Month el in monthes)
                comboBox1.Items.Add(el.getMonthName());
            //comboBox1.SelectedIndex = 0;
            //comboBox1.DisplayMember = monthes.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 8;
            dataGridView1.Columns[0].HeaderText =  "Позиция";
            dataGridView1.Columns[1].HeaderText = "Сумма";
            dataGridView1.Rows[0].Cells[0].Value = "Продукты";
            dataGridView1.Rows[1].Cells[0].Value = "Еда вне дома";
            dataGridView1.Rows[2].Cells[0].Value = "Транспорт";
            dataGridView1.Rows[3].Cells[0].Value = "Автомобиль";
            dataGridView1.Rows[4].Cells[0].Value = "Шоппинг";
            dataGridView1.Rows[5].Cells[0].Value = "Коммунальные";
            dataGridView1.Rows[6].Cells[0].Value = "Связь и Интернет";
            dataGridView1.Rows[7].Cells[0].Value = "Кредит";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.ColumnCount = 2;
            dataGridView2.RowCount = 3;
            dataGridView2.Columns[0].HeaderText = "Позиция";
            dataGridView2.Columns[1].HeaderText = "Сумма";
            dataGridView2.Rows[0].Cells[0].Value = "Отданный долг";
            dataGridView2.Rows[1].Cells[0].Value = "Зарплата";
            dataGridView2.Rows[2].Cells[0].Value = "Дивиденды";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month_id = comboBox1.SelectedIndex;
            double a = monthes.ElementAt(month_id).getCanCharge();
            if (a <= 30)
                label2.Text = "Вам нужно тратить значительно меньше";
            else
            {
                if (a > 30 && a <= 50)
                    label2.Text = "Вам нужно тратить меньше";
                else
                {
                    if (a > 50 && a <= 75)
                        label2.Text = "Ваши траты соразмерны расходам";
                    else
                        //if (a > 75)
                            label2.Text = "Вы можете тратить больше";
                }
                        
            }

            Month thisMonth = monthes.ElementAt(month_id);
            double b = thisMonth.getCredit();
            label3.Text = b.ToString();

            dataGridView1.Rows[0].Cells[1].Value = thisMonth.charges.getGeneralFood().ToString();
            dataGridView1.Rows[1].Cells[1].Value = thisMonth.charges.getGeneralOutFood().ToString();
            dataGridView1.Rows[2].Cells[1].Value = thisMonth.charges.getGeneralTransport().ToString();
            dataGridView1.Rows[3].Cells[1].Value = thisMonth.charges.getGeneralCar().ToString();
            dataGridView1.Rows[4].Cells[1].Value = thisMonth.charges.getGeneralShopping().ToString();
            dataGridView1.Rows[5].Cells[1].Value = thisMonth.charges.getGeneralCommunals().ToString();
            dataGridView1.Rows[6].Cells[1].Value = thisMonth.charges.getGeneralConnections().ToString();
            dataGridView1.Rows[7].Cells[1].Value = thisMonth.charges.getGeneralCredit().ToString();

            dataGridView2.Rows[0].Cells[1].Value = thisMonth.incomes.getGeneralDebt().ToString();
            dataGridView2.Rows[1].Cells[1].Value = thisMonth.incomes.getGeneralSalary().ToString();
            dataGridView2.Rows[2].Cells[1].Value = thisMonth.incomes.getGeneralDividends().ToString();
            //label2.Text = a.ToString();
        }
    }

    
}
