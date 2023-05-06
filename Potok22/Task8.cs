using System;
using System.Collections;
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
    public partial class Task8 : Form
    {
        List<Student> students = null;
        public Task8()
        {
            InitializeComponent();

            Student s1 = new Student("Иванов К.Г.", "Группа КН-214", 80, 90, 72, new DateTime(2023, 4, 15));
            Student s2 = new Student("Петров А.А.", "Группа ИС-313", 75, 85, 95, new DateTime(2023, 4, 17));
            Student s3 = new Student("Сидорова Е.В.", "Группа ПИ-416", 90, 85, 80, new DateTime(2023, 4, 15));
            Student s4 = new Student("Козлов Д.В.", "Группа КН-214", 85, 95, 100, new DateTime(2023, 4, 16));
            Student s5 = new Student("Николаев В.П.", "Группа ИС-313", 70, 80, 90, new DateTime(2023, 4, 15));
            Student s6 = new Student("Федоров И.А.", "Группа ПИ-416", 95, 85, 90, new DateTime(2023, 4, 17));
            Student s7 = new Student("Михайлов К.С.", "Группа КН-214", 80, 90, 85, new DateTime(2023, 4, 15));
            Student s8 = new Student("Смирнова А.В.", "Группа ИС-313", 66, 85, 95, new DateTime(2023, 4, 16));
            Student s9 = new Student("Васильева Л.А.", "Группа ПИ-416", 81, 85, 80, new DateTime(2023, 4, 17));
            Student s10 = new Student("Попов Г.С.", "Группа КН-214", 85, 100, 75, new DateTime(2023, 4, 15));

            students = new List<Student> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };

            listView1.Columns.Add("ФИО");
            listView1.Columns.Add("Номер группы");
            listView1.Columns.Add("Физика");
            listView1.Columns.Add("Математика");
            listView1.Columns.Add("Информатика");
            listView1.Columns.Add("Дата сдачи экзамена");

            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.FullName);
                item.SubItems.Add(student.GroupNumber);
                item.SubItems.Add(student.PhysicsGrade.ToString());
                item.SubItems.Add(student.MathGrade.ToString());
                item.SubItems.Add(student.InformaticsGrade.ToString());
                item.SubItems.Add(student.LastExamDate.ToShortDateString());
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
            DateTime dateTime = DateTime.Parse(textBox1.Text);
            listView1.Items.Clear();
            listView1.Columns.Add("Средний балл");

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            foreach (Student student in students)
            {
                if (student.LastExamDate <= dateTime)
                {
                    double GPA = (student.InformaticsGrade + student.MathGrade +
                        student.PhysicsGrade)/3;
                    ListViewItem item = new ListViewItem(student.FullName);
                    item.SubItems.Add(student.GroupNumber);
                    item.SubItems.Add(student.PhysicsGrade.ToString());
                    item.SubItems.Add(student.MathGrade.ToString());
                    item.SubItems.Add(student.InformaticsGrade.ToString());
                    item.SubItems.Add(student.LastExamDate.ToShortDateString());
                    item.SubItems.Add(GPA.ToString());
                    listView1.Items.Add(item);
                }
            }
            listView1.ListViewItemSorter = new GPAComparer(6); 
            listView1.Sort();
        }
    }
    class Student
    {
        public string FullName { get; set; }
        public string GroupNumber { get; set; }
        public int PhysicsGrade { get; set; } 
        public int MathGrade { get; set; } 
        public int InformaticsGrade { get; set; } 
        public DateTime LastExamDate { get; set; } 
        public Student(string fullName, string groupNumber, int physicsGrade, int mathGrade, int informaticsGrade, DateTime lastExamDate)
        {
            FullName = fullName;
            GroupNumber = groupNumber;
            PhysicsGrade = physicsGrade;
            MathGrade = mathGrade;
            InformaticsGrade = informaticsGrade;
            LastExamDate = lastExamDate;
        }
    }
    public class GPAComparer : IComparer
    {
        private int column;

        public GPAComparer(int column)
        {
            this.column = column;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            double gpaX = double.Parse(itemX.SubItems[column].Text);
            double gpaY = double.Parse(itemY.SubItems[column].Text);

            return gpaX.CompareTo(gpaY);
        }
    }
}
