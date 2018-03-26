using Econtact.contactClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }

        classContact c = new classContact();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the value from the inputs fields
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text; //Select value from Combobox

            //Inserting data into database using the method we created in previous episode
            bool success = c.Insert(c);
            if (success==true)
            {
                //successfully Inserted
                MessageBox.Show("New contact seccessfully inserted");
                //Call the clear method here
                Clear();
            }
            else
            {
                //failed to contact
                MessageBox.Show("Failed to add new contact. Try again.");
            }

            //Load data on data Gridview
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;

        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method for Clear Fields
        public void Clear()
        {
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtBoxContactNumber.Text = "";
            txtBoxAddress.Text = "";
            cmbGender.Text = "";
            txtboxContactID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;
            //Update data in database
            bool success = c.Update(c);
            if (success == true)
            {
                //update successfuly
                MessageBox.Show("Contact has been successfully Update ");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call the celar method
                Clear(); 
        
            }
            else
            {
                //failed to update
                MessageBox.Show("Failed to update Contact. Try again.");
            }
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from the data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked 
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString(); 

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //call clear method here
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the contactID  from application
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delte(c);
            if (success == true)
            {
                //successfully deleted
                MessageBox.Show("Contact successfully deleted");
                //Refresh data gridview
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call clear method here
                Clear();
            }
            else
            {
                //failed to delete
                MessageBox.Show("Failed to deleted contact. Try again");
            }

        }
    }
}
