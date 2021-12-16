using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kursach1.DataBase;

namespace Kursach1
{
    public partial class Form1 : Form
    {
        private List<RentCar> _cars = new List<RentCar>();

        private List<MyCar> _myCars = new List<MyCar>(); 

        public Form1()
        {
            InitializeComponent();
            InitCarPark();
            InitCars();

            InitComboBox();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void InitComboBox()
        {
            comboBox1.DisplayMember = "CarBrand";
            comboBox1.ValueMember = "CarBrand";
            comboBox1.DataSource = _cars;
        }

        private void InitCars()
        {
            _cars = DataBaseHelper.GetCars();
        }

        private void InitMyCars()
        {
            _myCars = DataBaseHelper.GetMyCars();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VisiblePanel2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisiblePanel3();
        }

        public void InitCarPark()
        {
            listBox2.Items.Clear();
            InitCars();
            foreach (var car in _cars)
            {
                listBox2.Items.Add(car);
            }
        }

        public void InitMyCarListBox()
        {
            InitMyCars();
            listBox1.Items.Clear();
            foreach (var car in _myCars)
            {
                listBox1.Items.Add(car);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitMyCarListBox();
            CalculateTotalRevenue();
            VisiblePanel4();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = $@"Год: {((Car)comboBox1.SelectedItem).YearOfIssue}";
            label5.Text = $@"Пробег: {((Car)comboBox1.SelectedItem).Mileage}";
            label6.Text = $@"Цена за час: {((Car)comboBox1.SelectedItem).CostOf1Hour}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VisiblePanel1();
            button3.Visible = true;


            if (_myCars.All(x => x.Car.Id != ((Car)comboBox1.SelectedItem).Id))
            {
                MyCar myCar = new MyCar()
                {
                    Car = (RentCar)comboBox1.SelectedItem,
                    Hours = (double)numericUpDown1.Value
                };

                DataBaseHelper.RentCar(myCar);

                InitMyCars();
                listBox1.Items.Add(myCar);
            }
        }

        private void CalculateTotalRevenue()
        {
            double rev = 0;
            foreach (var car in _myCars)
            {
                rev += car.CalculatedRevenue(); ;
            }

            label8.Text = $@"Сумма: {rev}";
        }

        private void VisiblePanel1()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void VisiblePanel2()
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void VisiblePanel3()
        {
            errorProvider1.Clear();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
        }
        private void VisiblePanel4()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
        }

        private void VisiblePanel5()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            VisiblePanel1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VisiblePanel1();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            VisiblePanel1();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataBaseHelper.TakeOffRentCar((MyCar)listBox1.SelectedItem);
            InitMyCarListBox();

            CalculateTotalRevenue();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            VisiblePanel5();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var rentCar = new RentCar(textBox1.Text, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);

            DataBaseHelper.AddCar(rentCar);

            textBox1.Clear();
            numericUpDown2.Value = 1980;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;

            InitCarPark();

            InitComboBox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            VisiblePanel3();
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            var car = (RentCar)listBox2.SelectedItem;

            var myCars = DataBaseHelper.GetMyCars();

            if (myCars.Any(x => x.Car.Id == car.Id))
            {
                errorProvider1.SetError(button12, "Невозможно удалить заказанное авто");
                return;
            }
            
            errorProvider1.Clear();

            DataBaseHelper.DeleteCar((RentCar)listBox2.SelectedItem);

            InitCarPark();

            InitComboBox();
        }
    }
}
