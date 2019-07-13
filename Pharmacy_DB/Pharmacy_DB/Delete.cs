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
    public partial class Delete : Form
    {
        private Medicine medicine;
        private DataGridView dgv;

        public Delete(Medicine med, DataGridView d)
        {
            InitializeComponent();
            dgv = d;
            medicine = med; 
            cmbDeletemedicine.DataSource = medicine.GetPills();
            
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
          int id= int.Parse(cmbDeletemedicine.SelectedValue.ToString().Substring(0,1).Trim());
            medicine.Delete_Medicine(id);

            cmbDeletemedicine.DataSource = null;
            cmbDeletemedicine.DataSource = medicine.GetPills();

            dgv.DataSource = null;
            dgv.DataSource = medicine.GetPills();

        }

    }
}
