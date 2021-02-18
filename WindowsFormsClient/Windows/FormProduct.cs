using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient.Windows
{
    public partial class FormProduct : Form
    {
        private ProductDto _product { get; set; }

        public FormProduct(BusinessLogicLayer.DTO.ProductDto product)
        {
            _product = product;
            InitializeComponent();
        }

        private void FormEditUser_Load(object sender, EventArgs e)
        {
            ShowProduct(this._product);
        }

        private void ShowProduct(BusinessLogicLayer.DTO.ProductDto resourceItem)
        {
            if (resourceItem != null)
            {
                tbId.Text = resourceItem.Id.ToString();
                tbName.Text = resourceItem.Name;
                tbCategoryName.Text = resourceItem.ParentContainerName;
                nudPriceSell.Value = (decimal)resourceItem.PriceSell;
            }
        }

        public bool IsCorrect(BusinessLogicLayer.DTO.ProductDto user)
        {
            if (user != null)
            {
                if (user.Name.Trim() != "" & user.PriceSell > 0)
                {           
                    return true;                        
                }
            }

            return false;
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            _product.Name = tbName.Text;
            _product.PriceSell = (float)nudPriceSell.Value;

            if (IsCorrect(_product))
            {
                try
                {
                    await Clients.ClientIProduct.Instance.Update(_product);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No name or price specified", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
