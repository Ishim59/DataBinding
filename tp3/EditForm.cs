using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp3
{
    public partial class EditForm : Form
    {
        private Employee employee;
        public EditForm(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            numericUpDown1.DataBindings.Add(nameof(NumericUpDown.Value), employee, nameof(employee.Id));
            textBox1.DataBindings.Add(nameof(TextBox.Text), employee, nameof(employee.Name));
            

           // bndName.BindingComplete += BndName_BindingComplete;

            dateTimePicker1.DataBindings.Add(nameof(DateTimePicker.Text),employee, nameof(employee.Date));
            numericUpDown2.DataBindings.Add(nameof(NumericUpDown.Value), employee, nameof(employee.Experience));
            trackBar1.DataBindings.Add(nameof(NumericUpDown.Value),employee, nameof(employee.HoursWorked));

            //employee.PropertyChanged += EmployeePropertyChanged;
        }

        

       

        private void btnOK(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Split(' ').Length >= 2)
            {
                employee.Name = textBox1.Text;
            }
            else
            {
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                MessageBox.Show("Введите только имя и фамилия", "Ой-ой", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (DateTime.Today.Year - dateTimePicker1.Value.Year > 14)
            {
                employee.Date = dateTimePicker1.Value;
                
            }
            else
            {
                dateTimePicker1.BackColor = Color.Red;
                dateTimePicker1.Focus();
                MessageBox.Show("Тебе должно быть больше 14 лет", "Ой-ой", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox1.Text.Trim().Split(' ').Length == 2 && DateTime.Today.Year - dateTimePicker1.Value.Year > 14)
                DialogResult = DialogResult.OK;
        }
        public void ChangeButtonText(string text)
        {
            button1.Text = text;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = string.Format("Текущее значение: {0}", trackBar1.Value);
        }

        private void btnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }
    }
}
