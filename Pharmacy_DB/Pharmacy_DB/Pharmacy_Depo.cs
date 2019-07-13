using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_DB
{
    public partial class Pharmacy_Depo : Form
    {
        private Medicine medicine;
        private DataGridView dgv;
        public Pharmacy_Depo()
        {
            InitializeComponent();

            Medicine zeferan = new Medicine("zeferan");
            medicine = zeferan;
            dgv = dgvList;

            dgvList.DataSource = medicine.GetPills();
        }


        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string name = txtmName.Text.Trim();
            string mtype = txtmType.Text.Trim();
            string mprice = txtPrice.Text.Trim();

           

            if (name == ""|| mtype == ""  || mprice == "" )
            {
                MessageBox.Show("Bos Xanalari doldurun","information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            float revprice = float.Parse(mprice);

            Pill zeferan = new Pill { Name = name, Type = mtype, Price = revprice };

            medicine.AddMedicine(zeferan);

            dgvList.DataSource = null;
            dgvList.DataSource = medicine.GetPills();

            txtmName.Text = null;
            txtmType.Text = null;
            txtPrice.Text = null;

        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete(medicine, dgv);
            delete.Show();
        }

        private int ID = 0;

        private void DgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCreate.Visible = false;
            btnUpdate.Visible = true;
            int id=(int)  dgv.Rows[e.RowIndex].Cells[0].Value;
            ID=id;
            Pill pil= medicine.Getpill(id);

            txtmName.Text = pil.Name;
            txtmType.Text = pil.Type;
            txtPrice.Text = pil.Price.ToString();
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
           
            string name = txtmName.Text.Trim();
            string mtype = txtmType.Text.Trim();
            float mprice = float.Parse(txtPrice.Text.Trim());



            if (name == "" || mtype == "" || mprice.ToString() == "")
            {
                MessageBox.Show("Bos Xanalari doldurun", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            medicine.UpdatePills(ID, name, mtype, mprice);

            dgvList.DataSource = null;
            dgvList.DataSource = medicine.GetPills();

            txtmName.Text = null;
            txtmType.Text = null;
            txtPrice.Text = null;
            btnCreate.Visible = true;
            btnUpdate.Visible = false;
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCreate.Visible = true;
            btnUpdate.Visible = false;
        }
    }
}
