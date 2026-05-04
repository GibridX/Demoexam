using Demoexam.Database;
using Demoexam.Models;

namespace Demoexam
{
    public partial class OrderForm : Form
    {
        private readonly int? _id;
        private readonly User _user;
        public OrderForm(int? id, User user)
        {
            _id = id;
            _user = user;
            InitializeComponent();
            Load += OrderForm_Load;
            this.Icon = new Icon("Photos/Icon.ico");
        }

        private void OrderForm_Load(object? sender, EventArgs e)
        {
            Text = _id == null ? "Добавить заказ" : "Редактировать заказ";

            if (_id != null)
            {
                using var db = new AppDbContext();
                var o = db.Orders.First(x => x.OrderId == _id);

                txtClient.Text = o.ClientFullName;
                txtArticle.Text = o.OrderArticle;
                dtpOrder.Value = o.OrderDate.ToDateTime(TimeOnly.MinValue);
                dtpDelivery.Value = o.DeliveryDate.ToDateTime(TimeOnly.MinValue);
                txtStatus.Text = o.Status;
                txtCode.Text = o.PickupCode.ToString();
            }

            btnSave.Click += (s, e) => Save();
            btnCancel.Click += (s, e) => Close();
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(txtClient.Text))
            {
                MessageBox.Show("Введите ФИО клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var db = new AppDbContext();
                Order o = _id == null ? new Order() : db.Orders.First(x => x.OrderId == _id);

                if (_id == null)
                    db.Orders.Add(o);

                o.ClientFullName = txtClient.Text;
                o.OrderArticle = txtArticle.Text;
                o.OrderDate = DateOnly.FromDateTime(dtpOrder.Value);
                o.DeliveryDate = DateOnly.FromDateTime(dtpDelivery.Value);
                o.Status = txtStatus.Text;
                o.PickupCode = int.TryParse(txtCode.Text, out int code) ? code : 0;

                db.SaveChanges();

                MessageBox.Show("Сохранено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
