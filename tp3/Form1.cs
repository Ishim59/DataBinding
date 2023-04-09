using Microsoft.TeamFoundation.Test.WebApi;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace tp3
{
    public partial class Form1 : Form
    {

        private BindingList<Employee> ?employee = new();

        public int rowIndex = 0;
        public Form1()
        {
            InitializeComponent();
            employee.Add(new Employee() { Id = 1, Name = "Name1",  Date = new DateTime(1990,01,01), Experience = 5, HoursWorked = 20}) ;
            dataGridView1.DataSource = employee;

            BindingList<Employee> defaultJson = null;
            string json = JsonSerializer.Serialize(defaultJson);
            File.WriteAllText("data.json", json);

        }
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Employee newEmployee = new Employee();
            newEmployee.Date = DateTime.Today;
            newEmployee.HoursWorked = 10;
            EditForm ef = new(newEmployee);
            if (ef.ShowDialog(this) == DialogResult.OK)
                employee.Add(newEmployee);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0) 
            {
                var currentRow = dataGridView1.SelectedRows[0].Index;
                var clnEmployee = employee[(int)currentRow].Clone();
                EditForm ef = new(clnEmployee);
                ef.ChangeButtonText("��������");
                if (ef.ShowDialog(this) == DialogResult.OK)
                {
                    employee[(int)currentRow] = clnEmployee;
                }

            }
            else
            {
                MessageBox.Show("�� ������� ������ ��� ��������������!",
                     "���",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var toDel = dataGridView1.SelectedRows[0].Index;
                employee.RemoveAt(toDel);
            }
            catch
            {
                MessageBox.Show("�� ������� ������ ��� ��������!",
                    "���",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        
        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("data.json", FileMode.Open))
            {
                BindingList<Employee?> data = JsonSerializer.Deserialize<BindingList<Employee>>(fs);
                if (data != null)
                {
                    foreach (var employee in data)
                    {
                        this.employee.Add(employee);
                    }
                }
                else
                {
                    MessageBox.Show("���� ����", "��-��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //using (FileStream fs = new FileStream("data.json", FileMode.Open))
            //{
            //    try
            //    {
            //        BindingList<Employee?> data = JsonSerializer.Deserialize<BindingList<Employee>>(fs);
            //        if (data != null)
            //        {
            //            foreach (var employee in data)
            //            {
            //                this.employee.Add(employee);
            //            }
            //        }
            //    }

            //    catch (JsonException)
            //    {
            //        MessageBox.Show("���� ����", "��-��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (FileStream fs = new("data.json", FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, employee);
                }
            }
        }

        private void �����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            reference.ShowDialog();

        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingList<Employee> defaultJson = null;
            string json = JsonSerializer.Serialize(defaultJson);
            File.WriteAllText("data.json", json);
            //employee.Clear();
            //string json = JsonSerializer.Serialize(employee);
            //File.WriteAllText("data.json", json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employee.Clear();
            employee.Add(new Employee() { Id = 1, Name = "Name1", Date = DateTime.Today, Experience = 5, HoursWorked = 20 });
            dataGridView1.DataSource = employee;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ��������ToolStripMenuItem_Click(sender, e);
        }
    }
}