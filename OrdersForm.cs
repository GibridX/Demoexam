using Demoexam.Database;
using Demoexam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demoexam
{
    public partial class OrdersForm : Form
    {
        private readonly User _user;
        private int _selectedId;

        public OrdersForm(User user)
        {
            InitializeComponent();
            _user = user;
            Load += OrdersForm_Load;
            this.Icon = new Icon("Photos/Icon.ico");
        }

        private void OrdersForm_Load(object? sender, EventArgs e)
        {
            LoadOrders();
            btnAdd.Visible = _user.IsAdmin;
            btnDelete.Visible = _user.IsAdmin;
            btnEdit.Visible = _user.IsAdmin;

            btnAdd.Click += (s, e) => OpenOrderForm(null);
            btnEdit.Click += (s, e) => OpenOrderForm(_selectedId);
            btnDelete.Click += (s, e) => DeleteOrder();

            dgvOrders.SelectionChanged += (s, e) =>
            {
                if (dgvOrders.CurrentRow != null)
                    _selectedId = (int)dgvOrders.CurrentRow.Cells["OrderId"].Value;
            };

            btnBack.Click += (s, e) => Close();
        }

        private void LoadOrders()
        {
            using var db = new AppDbContext();
            dgvOrders.DataSource = db.Orders.ToList();
            dgvOrders.Columns["OrderId"].HeaderText = "ID";
        }

        private void OpenOrderForm(int? id)
        {
            if (Application.OpenForms.OfType<OrderForm>().Any())
            {
                MessageBox.Show("Закройте окно редактирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var f = new OrderForm(id, _user);
            f.FormClosed += (s, e) => LoadOrders();
            f.Show();
        }

        private void DeleteOrder()
        {
            if (_selectedId == 0) return;

            if (MessageBox.Show("Вы уверены, что хотите удалить закак? Операцию нельзя отменить", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            using var db = new AppDbContext();
            var order = db.Orders.Find(_selectedId);

            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }

            LoadOrders();
        }
    }
}
