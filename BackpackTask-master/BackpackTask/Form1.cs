using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackpackTask
{
    public partial class Form1 : Form
    {
        private List<Item> items;

        public Form1()
        {
            InitializeComponent();

            AddItems();
            ShowItems(items);
        }

        private void AddItems()
        {
            items = new List<Item>();

            items.Add(new Item("Книга", 3, 77));
            items.Add(new Item("Бинокль", 4, 36));
            items.Add(new Item("Аптечка", 4, 44));
            items.Add(new Item("Ноутбук", 5, 18));
            items.Add(new Item("Котелок", 7, 21));
            items.Add(new Item("Котелок", 6, 38));
            items.Add(new Item("Котелок", 10, 60));
            items.Add(new Item("Котелок", 9, 99));
            items.Add(new Item("Котелок", 10, 32));

        }

        private void ShowItems(List<Item> _items)
        {
            itemsListView.Items.Clear();
            double p = 0, w = 0;
            foreach (Item i in _items)
            {
                itemsListView.Items.Add(new ListViewItem(new string[] { i.name, i.weigth.ToString(), 
                    i.price.ToString() }));
                w += i.weigth;
                p += i.price;
            }
            textBox1.Text = w.ToString();
            textBox2.Text = p.ToString();
        }

        //показать исходные данные
        private void ShowConditionsButton_Click(object sender, EventArgs e)
        {
            ShowItems(items);
        }

        //решить задачу
        private void solveButton_Click(object sender, EventArgs e)
        {
            Backpack bp = new Backpack(Convert.ToDouble(weightTextBox.Text));

            bp.MakeAllSets(items);

            List<Item> solve = bp.GetBestSet();

            if(solve == null)
            {
                MessageBox.Show("Нет решения!");
            }
            else
            {
                itemsListView.Items.Clear();

                ShowItems(solve);

                MessageBox.Show("Решение приведено в таблице");
            }
        }
    }
}