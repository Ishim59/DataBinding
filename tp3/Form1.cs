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

        private BindingList<Employee> ?employees = new();

        public int rowIndex = 0;
        public Form1()
        {
            InitializeComponent();
            employees.Add(new Employee() { Id = 1, Name = "Name1",  Date = DateTime.Today, Experience = 5, HoursWorked = 20}) ;
            dataGridView1.DataSource = employees;

            BindingList<Employee> clnEmploye = null;
            string json = JsonSerializer.Serialize(clnEmploye);
            File.WriteAllText("data.json", json);

        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Employee newEmployee = new Employee();
            newEmployee.Date = DateTime.Today;
            newEmployee.HoursWorked = 10;
            EditForm ef = new(newEmployee);
            if (ef.ShowDialog(this) == DialogResult.OK)
                employees.Add(newEmployee);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0) 
            {
                
                var currentRow = dataGridView1.SelectedRows[0].Index;
                var clnEmployee = employees[(int)currentRow].Clone();
                EditForm ef = new(clnEmployee);
                ef.ChangeButtonText("Изменить");
                if (ef.ShowDialog(this) == DialogResult.OK)
                {
                    employees[(int)currentRow] = clnEmployee;
                }

            }
            else
            {
                MessageBox.Show("Не выбрана запись для редактирования!",
                     "Упс",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var toDel = dataGridView1.SelectedRows[0].Index;
                employees.RemoveAt(toDel);
            }
            catch
            {
                MessageBox.Show("Не выбрана запись для удаления!",
                    "Упс",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        
        private void ДобавитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                using (FileStream fs = new FileStream("data.json", FileMode.Open))
                {
                    BindingList<Employee?> data = JsonSerializer.Deserialize<BindingList<Employee>>(fs);
                    if (data != null)
                    {
                        foreach (var employee in data)
                        {
                            employees.Add(employee);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл пуст", "Ой-ой", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new("data.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, employees);
            }
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reference reference = new Reference();
            reference.ShowDialog();

        }

        private void очиститьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingList<Employee> clnEmploye = null;
            string json = JsonSerializer.Serialize(clnEmploye);
            File.WriteAllText("data.json", json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            employees.Clear();
            employees.Add(new Employee() { Id = 1, Name = "Name1", Date = DateTime.Today, Experience = 5, HoursWorked = 20 });
            dataGridView1.DataSource = employees;
        }
    }
}