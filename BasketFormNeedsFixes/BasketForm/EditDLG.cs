using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketForm
{
    public partial class EditDLG : Form
    {
        private ShoppingBasket EditorForm;
        public EditDLG(ShoppingBasket EditForm)
        {
            EditorForm = EditForm;
            InitializeComponent();
        }

        public string productName = "";
        public string productQuan = "";
        public string productPrice = "";

        private void EditDLG_Load(object sender, EventArgs e)
        {
            decimal productQuant = Convert.ToDecimal(productQuan); 
            textBox1.Text = productName;
            numericUpDown1.Value = productQuant;
            textBox2.Text = productPrice;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            EditorForm.basket.Items[EditorForm.basket.SelectedItems[0].Index].SubItems[0].Text = textBox1.Text;
            EditorForm.basket.Items[EditorForm.basket.SelectedItems[0].Index].SubItems[1].Text = numericUpDown1.Text;
            EditorForm.basket.Items[EditorForm.basket.SelectedItems[0].Index].SubItems[2].Text = textBox2.Text;
                Close();
        }
    }
}
