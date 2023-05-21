using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApplication
{
    public partial class frmEmployeeDatabase : Form
    {
        public frmEmployeeDatabase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeID = EmployeeIDTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string position = PositionTextBox.Text;

            Employee employee = new Employee(employeeID, firstName, lastName, position);

            dataGridView1.Rows.Add(employee.EmployeeID, employee.FirstName, employee.LastName, employee.Position);

            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };
            func(Controls);
           }

        }
        public class Employee
        {
            private string employeeID;
            private string firstName;
            private string lastName;
            private string position;

            public string EmployeeID
            {
              get { return employeeID; }
               set { employeeID = value; }
            }
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            public string Position
            {
                get { return position; }
                set { position = value; }
            }
            public Employee(string employeeID, string firstName, string lastName, string position) 
            { 
                this.EmployeeID = employeeID;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Position = position;
            }
        }
 
    }
