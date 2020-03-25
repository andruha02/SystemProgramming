using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter stream = new StreamWriter("data.txt", true))
            {
                stream.WriteLine($"{SurnameBox.Text} {NameBox.Text} {textBox1.Text} {textBox2.Text} {textBox3.Text} {textBox4.Text} {textBox5.Text}");
            }
            NameBox.Clear();
            SurnameBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        List<Student> count_students = new List<Student>();

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            count_students.Clear();
            using (StreamReader stream = new StreamReader("data.txt"))
            {
                string[] str = new string[7];
                Student student = new Student();

                do
                {
                    str = stream.ReadLine().Split(' ');
                    student = new Student(str[0], str[1], Int32.Parse(str[2]), Int32.Parse(str[3]), Int32.Parse(str[4]), Int32.Parse(str[5]), Int32.Parse(str[6]));

                    count_students.Add(student);

                    listBox1.Items.Add($"{student.surname}, \t {student.result1}, \t {student.result2},\t {student.result3}, \t {student.result4}, \t {student.result5}");

                } while (!stream.EndOfStream);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count_students.Sort((a, b) => a.CompareTo(b));
            listBox1.Items.Clear();
            foreach (var student in count_students)
            {
                if (student.result1 == 4 && student.result2 == 4 && student.result3 == 4 && student.result4 == 4 && student.result5 == 4)
                    listBox1.Items.Add($"{student.surname},\t {student.result1}, \t {student.result2},\t {student.result3}, \t {student.result4}, \t {student.result5}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"data.txt", string.Empty);
        }
    }

    class Student
    {
        public string surname;
        public string name;


        public int result1;
        public int result2;
        public int result3;
        public int result4;
        public int result5;

       

        public int CompareTo(Student student)
        {
                int myCount = 0;
                myCount += this.result1 == 4 ? 4 : 0;
                myCount += this.result2 == 4 ? 4 : 0;
                myCount += this.result3 == 4 ? 4 : 0;
                myCount += this.result4 == 4 ? 4 : 0;
                myCount += this.result5 == 4 ? 4 : 0;

                int studentCount = 0;
                studentCount += student.result1 == 4 ? 4 : 0;
                studentCount += student.result2 == 4 ? 4 : 0;
                studentCount += student.result3 == 4 ? 4 : 0;
                studentCount += student.result4 == 4 ? 4 : 0;
                studentCount += student.result5 == 4 ? 4 : 0;

            return 0;
            
        }

        public Student()
        {
            this.surname = "none";
            this.name = "none";

            this.result1 = 0;
            this.result2 = 0;
            this.result3 = 0;
            this.result4 = 0;
            this.result5 = 0;
        }

        public Student(string surname,string name,int result1,int result2,int result3,int result4, int result5)
        {
            this.surname = surname;
            this.name = name;

            this.result1 = result1;
            this.result2 = result2;
            this.result3 = result3;
            this.result4 = result4;
            this.result5 = result5;
        }

    }
}
