using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasketForm
{
    public partial class ShoppingBasket : Form
    {
        public ShoppingBasket()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToBasket_Click(object sender, EventArgs e)
        {
            string prodPrice = Price.Text;
            string prodQuant = Quantity.Text;
            string product = ProductName.Text;
            decimal quan = Convert.ToDecimal(prodQuant);
            decimal price = Convert.ToDecimal(prodPrice);
            string quan2 = Convert.ToString(quan);
            string price2 = Convert.ToString(price);

                var item = new ListViewItem(product);
                item.SubItems.Add(quan2);
                item.SubItems.Add(price2);
                basket.Items.Add(item);

                ProductName.Clear();
                Quantity.Value = 0;
                Price.Clear();

        }

        private void removeSelected_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < basket.Items.Count; i++)
            {
                if (basket.Items[i].Selected)
                {
                    basket.Items[i].Remove();
                    i--;
                }
            }
        }

        private void clearBasket_Click(object sender, EventArgs e)
        {
            basket.Items.Clear();
            TotalCost.Text = "0";
        }

        private void editSelected_Click(object sender, EventArgs e)
        {
                EditDLG frm = new EditDLG(this);
                frm.productName = basket.Items[basket.SelectedItems[0].Index].SubItems[0].Text;
                frm.productQuan = basket.Items[basket.SelectedItems[0].Index].SubItems[1].Text;
                frm.productPrice = basket.Items[basket.SelectedItems[0].Index].SubItems[2].Text;
                frm.Show();
        }




        private void saveOrder_Click(object sender, EventArgs e)
        {


            string location = "@/Documents"; //location to where you want to save it, leave the @ at the start
                    using (StreamWriter writer = new StreamWriter(location))
                    {
                        StringBuilder line = new StringBuilder();
                        foreach (ListViewItem item in basket.Items)
                        {
                            line.Clear();
                            for (int i = 0; i < item.SubItems.Count; i++)
                            {
                                if (i > 0)
                                    line.Append("/");
                                line.Append(item.SubItems[i].Text);
                            }
                            writer.WriteLine(line);
                        }
                    }
                    
        } 
    }
}
