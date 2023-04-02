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
            dateTimePicker1.DataBindings.Add(nameof(DateTimePicker.Text),employee, nameof(employee.Date));
            numericUpDown2.DataBindings.Add(nameof(NumericUpDown.Value), employee, nameof(employee.Experience));
            trackBar1.DataBindings.Add(nameof(NumericUpDown.Value),employee, nameof(employee.HoursWorked));
        }
        private void btnOK(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public void ChangeButtonText(string text)
        {
            button1.Text = text;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = String.Format("Текущее значение: {0}", trackBar1.Value);
        }

        private void btnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
