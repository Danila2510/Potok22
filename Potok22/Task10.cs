﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potok22
{
    public partial class Task10 : Form
    {
        List<Shop> goods = new List<Shop>();
        public Task10()
        {
            InitializeComponent();

            Shop item1 = new Shop("Фрукты", "Яблоки", "ООО 'Сады Придонья'", new DateTime(2023, 4, 10), TimeSpan.FromDays(14));
            Shop item2 = new Shop("Молочные продукты", "Молоко 'Простоквашино'", "ОАО 'Винзавод'", new DateTime(2023, 4, 18), TimeSpan.FromDays(10));
            Shop item3 = new Shop("Кондитерские изделия", "Печенье 'Орео'", "Mondelēz International, Inc.", new DateTime(2023, 5, 1), TimeSpan.FromDays(30));
            Shop item4 = new Shop("Напитки", "Кола 'Coca-Cola'", "The Coca-Cola Company", new DateTime(2023, 4, 15), TimeSpan.FromDays(90));
            Shop item5 = new Shop("Мясные продукты", "Филе куриное", "ООО 'Курочка Ряба'", new DateTime(2023, 4, 8), TimeSpan.FromDays(5));
            Shop item6 = new Shop("Морепродукты", "Креветки", "ОАО 'Дальрыба'", new DateTime(2023, 4, 20), TimeSpan.FromDays(7));
            Shop item7 = new Shop("Овощи", "Помидоры", "ООО 'Тепличный рай'", new DateTime(2023, 4, 12), TimeSpan.FromDays(7));
            Shop item8 = new Shop("Консервы", "Рыбные консервы", "ОАО 'Бычковский консервный завод'", new DateTime(2023, 4, 1), TimeSpan.FromDays(365));
            Shop item9 = new Shop("Крупы и макаронные изделия", "Макароны 'Barilla'", "Barilla G. e R. Fratelli Società per Azioni", new DateTime(2023, 5, 10), TimeSpan.FromDays(365));
            Shop item10 = new Shop("Хлебобулочные изделия", "Хлеб 'Бородинский'", "ООО 'Хлебозавод №1'", new DateTime(2023, 4, 16), TimeSpan.FromDays(3));

            goods = new List<Shop> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 };

            listView1.Columns.Add("Группа");
            listView1.Columns.Add("Товар");
            listView1.Columns.Add("Изготовитель");
            listView1.Columns.Add("Дата изготовления");
            listView1.Columns.Add("Срок годности");

            foreach (Shop shop in goods)
            {
                ListViewItem item = new ListViewItem(shop.Group);
                item.SubItems.Add(shop.Name);
                item.SubItems.Add(shop.Manufacturer);
                item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                item.SubItems.Add(shop.ShelfLife.TotalDays.ToString());
                listView1.Items.Add(item);
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                button1.Enabled = false;

        }
        public async Task FinalCount()
        {
            listView1.Items.Clear();
            DateTime interval = DateTime.Parse(textBox1.Text);
            foreach (Shop shop in goods)
            {
               DateTime shelf = shop.DateManufacture + shop.ShelfLife;
                if(interval > shelf)
                {
                    ListViewItem item = new ListViewItem(shop.Group);
                    item.SubItems.Add(shop.Name);
                    item.SubItems.Add(shop.Manufacturer);
                    item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                    item.SubItems.Add(shop.ShelfLife.TotalDays.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
    public class Shop
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateManufacture { get; set; }
        public TimeSpan ShelfLife { get; set; }

        public Shop(string group, string name, string manufacturer, DateTime dateManufacture, TimeSpan shelfLife)
        {
            Group = group;
            Name = name;
            Manufacturer = manufacturer;
            DateManufacture = dateManufacture;
            ShelfLife = shelfLife;
        }
    }

}
