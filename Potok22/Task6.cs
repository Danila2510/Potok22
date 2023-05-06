using System;
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
    public partial class Task6 : Form
    {
        List<CompanyEmployees> employees = null;
        public Task6()
        {
            InitializeComponent();

            employees = new List<CompanyEmployees>
{
    new CompanyEmployees("Иваненко", "Иван", "Иванович", new DateTime(2000, 2, 10), "+380541234567", "Улица Шевченко", 10, "5"),
    new CompanyEmployees("Петренко", "Петр", "Петрович", new DateTime(1980, 7, 15), "+380982345678", "Улица Леси Украинки", 120, "10"),
    new CompanyEmployees("Сидоренко", "Сидор", "Сидорович", new DateTime(1990, 4, 20), "+380933456789", "Улица Мазепы", 30, "15"),
    new CompanyEmployees("Коваленко", "Ковало", "Ковалович", new DateTime(1988, 11, 5), "+380324567890", "Улица Коперника", 40, "20"),
    new CompanyEmployees("Бондаренко", "Бондарь", "Бондаревич", new DateTime(1995, 9, 23), "+3801095678901", "Улица Ломоносова", 50, "25"),
    new CompanyEmployees("Григоренко", "Григорий", "Григорьевич", new DateTime(1987, 6, 7), "+380656789012", "Улица Терещенкова", 60, "30"),
    new CompanyEmployees("Кравченко", "Кравчо", "Кравченко", new DateTime(1992, 3, 12), "+380987890123", "Улица Гринченка", 71, "35"),
    new CompanyEmployees("Мельникенко", "Мельник", "Мельникович", new DateTime(2003, 12, 28), "+380938901234", "Улица Гагарина", 80, "40"),
    new CompanyEmployees("Романенко", "Роман", "Романович", new DateTime(1991, 8, 19), "+380769012345", "Улица Каразина", 54, "45"),
    new CompanyEmployees("Короленко", "Король", "Королевич", new DateTime(1986, 5, 17), "+380970123456", "Улица Мироносицкая", 7, "50"),
    new CompanyEmployees("Даниленко", "Данила", "Данилович", new DateTime(2008, 2, 27), "+380972345678", "Улица Шевченко", 12, "55"),
    new CompanyEmployees("Ткаченко", "Ткач", "Ткачевич", new DateTime(1989, 11, 11), "+380983456789", "Улица Сагайдачного", 120, "60") };


            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Телефон");
            listView1.Columns.Add("Улица");
            listView1.Columns.Add("Номер дома");
            listView1.Columns.Add("Номер кв.");
            foreach (CompanyEmployees employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.Street);
                item.SubItems.Add(employee.HouseNumber.ToString());
                item.SubItems.Add(employee.ApartmentNumber);

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
            string street = textBox1.Text;
            listView1.Items.Clear();
            int totalAge = 0;

            foreach (CompanyEmployees employee in employees)
            {
                if ((street == employee.Street) && (employee.HouseNumber % 2 == 0))
                {
                    ListViewItem item = new ListViewItem(employee.LastName);
                    totalAge += DateTime.Now.Year - employee.BirthDate.Year;
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.Phone);
                    item.SubItems.Add(employee.Street);
                    item.SubItems.Add(employee.HouseNumber.ToString());
                    item.SubItems.Add(employee.ApartmentNumber);

                    listView1.Items.Add(item);
                }
            }

            double averageAge = totalAge / listView1.Items.Count;
            MessageBox.Show($"Средний возраст сотрудников: {averageAge:F1} лет");

        }
    }
    class CompanyEmployees
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public CompanyEmployees(string lastName, string firstName, string middleName, DateTime birthDate, string phone, string street, int houseNumber, string apartmentNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Phone = phone;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }
    }


}
