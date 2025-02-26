using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListApp
{
    public partial class Form1 : Form
    {
        private List<string> tasks = new List<string>();
        private TextBox taskInput;
        private ListBox taskListBox;
        private Button addButton;
        private Button deleteButton;
        public Form1()
        {
            InitializeComponent();
        }
        DataTable todoList = new DataTable();
        bool isEditing = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Create colums
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            // point datagridview to data scource
            ToDoListView.DataSource = todoList;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            //fill text fields with data from table
            titleTextbox.Text = todoList.Rows[ToDoListView.CurrentRow.Index][0].ToString();
            descriptionTextbox.Text = todoList.Rows[ToDoListView.CurrentRow.Index][1].ToString();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try 
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Title"] = titleTextbox.Text;
                todoList.Rows[ToDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextbox.Text;
            }
            else
            {
                //add new row
                todoList.Rows.Add(titleTextbox.Text, descriptionTextbox.Text);
            }
            //clear text fields
            titleTextbox.Text = "";
            descriptionTextbox.Text = "";
            isEditing = false;
        }
    }
}
