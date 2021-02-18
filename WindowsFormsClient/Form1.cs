using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        private delegate void WindowUpdate(BusinessLogicLayer.DTO.ProductDto[] users);

        private bool isIncludeChildContainers = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                btnRefresh.Enabled = false;
                var dataResult = await Task.Run<BusinessLogicLayer.DTO.CategoryDto[]>(() => Clients.ClientICategory.Instance.GetCategories());
                UpdateTreeConteaners(dataResult);
                
                btnRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                btnRefresh.Enabled = true;
            }
        }

        private void UpdateTreeConteaners(BusinessLogicLayer.DTO.CategoryDto[] containers)
        {
            lock (treeContainers)
            {
                labelPath.Text = "";
                treeContainers.Nodes.Clear();

                if (containers != null && containers.Length > 0)
                {
                    var rootContainers = containers.Where(x => x.ParentContainerId == Guid.Empty).ToList();

                    if (rootContainers.Count >= 0)
                    {
                        foreach (var rootContainer in rootContainers)
                        {
                            TreeNode treeNode = CreateTreeNode(rootContainer, containers);
                            treeContainers.Nodes.Add(treeNode);
                        }
                    }
                }
            }
        }


        private TreeNode CreateTreeNode(BusinessLogicLayer.DTO.CategoryDto containerRoot, BusinessLogicLayer.DTO.CategoryDto[] containers)
        {
            TreeNode treeNode = new TreeNode()
            {
                Text = containerRoot.Name,
                Tag = containerRoot 
            };

            var childrenContainers = containers.Where(x => x.ParentContainerId == containerRoot.Id).ToList();

            foreach (var item in childrenContainers)
            {
                treeNode.Nodes.Add(CreateTreeNode(item, containers));
            }

            return treeNode;
        }

        private async void treeContainers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            labelPath.Text = e.Node.FullPath;

            TreeNode treeNode = e.Node;

            BusinessLogicLayer.DTO.CategoryDto container = (BusinessLogicLayer.DTO.CategoryDto) treeNode.Tag;
            try 
            { 
                if (container != null)
                {
                    BusinessLogicLayer.DTO.ProductDto[] resourceItems = await Clients.ClientIProduct.Instance.GetProducts(container.Id);

                    UpdateTable(resourceItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTable(BusinessLogicLayer.DTO.ProductDto[] users)
        {
            try
            {
                WindowUpdate windowUpdate = UpdateTable;

                if (this.InvokeRequired)
                {
                    this.Invoke(windowUpdate, users);
                }
                else
                {                    
                    lock (this.dataGridViewUsers)
                    {
                        dataGridViewUsers.Rows.Clear();

                        foreach (var user in users)
                        {
                            dataGridViewUsers.Rows.Add(user.Id.ToString(), user.Name, user.PriceSell);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            this.isIncludeChildContainers = checkBox.Checked;
        }

        private void TreeNodeUpdate()
        {
            var treeNode = treeContainers.SelectedNode;
            treeContainers.SelectedNode = null;
            treeContainers.SelectedNode = treeNode;
        }

        private async void dataGridViewUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0)
            {
                try
                {
                    DataGridView dataGridView = (DataGridView) sender;

                    if (dataGridView != null)
                    {
                        Guid id = Guid.Parse(dataGridView.Rows[rowIndex].Cells[0].Value.ToString());
                        BusinessLogicLayer.DTO.ProductDto productDTO = await Clients.ClientIProduct.Instance.GetProduct(id);

                        if (productDTO != null)
                        {
                            Windows.FormProduct form = new Windows.FormProduct(productDTO);
                            form.ShowDialog();

                            TreeNodeUpdate();
                        }
                        else
                        {
                            MessageBox.Show($"Error: Product not found, ID={id}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
    }
}
