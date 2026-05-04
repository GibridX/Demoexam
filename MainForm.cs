using Demoexam.Database;
using Demoexam.Models;
using System.Data;

namespace Demoexam
{
    public partial class MainForm : Form
    {
        private readonly User _user;
        private string _selectedArticle = "";
        private readonly Form1 _loginForm;
        public MainForm(User user, Form1 loginForm)
        {
            InitializeComponent();
            _user = user;
            _loginForm = loginForm;
            this.FormClosed += (s, e) => _loginForm.Show();
            Load += MainForm_Load;
            this.Icon = new Icon("Photos/Icon.ico");
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            lblUser.Text = $"{_user.Fullname} | {_user.Role}";
            if (_user.Role.Contains("Гость"))
            {
                Point point = btnLogout.Location;
                int x = point.X;
                lblUser.Location = new Point(x);
            }
            btnLogout.Click += (s, ev) => Close();

            bool can = _user.CanSearch;
            txtSearch.Visible = can; cbSupplier.Visible = can; cbSort.Visible = can;
            btnAdd.Visible = _user.IsAdmin; btnDelete.Visible = _user.IsAdmin;
            btnOrders.Visible = can;

            cbSupplier.Items.Add("Все поставщики");
            using var db = new AppDbContext();
            foreach (var s in db.Products.Select(p => p.Supplier).Distinct().OrderBy(x => x))
            {
                cbSupplier.Items.Add(s);
            }
            cbSupplier.SelectedIndex = 0;

            cbSort.Items.AddRange(["На складе ув.", "На складе ум.", "Без сортировка"]);
            cbSort.SelectedIndex = 2;

            txtSearch.TextChanged += (s, e) => LoadCards();
            cbSupplier.SelectedIndexChanged += (s, e) => LoadCards();
            cbSort.SelectedIndexChanged += (s, e) => LoadCards();

            btnAdd.Click += (s, e) => OpenProductForm(null);
            btnDelete.Click += (s, e) => DeleteSelected();
            btnOrders.Click += (s, e) =>
            {
                var f = new OrdersForm(_user);
                f.Show();
            };
            LoadCards();
        }

        public void LoadCards()
        {
            flpCard.Controls.Clear(); _selectedArticle = "";
            using var db = new AppDbContext();
            var q = db.Products.AsQueryable();

            if (_user.CanSearch && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var s = txtSearch.Text.ToLower();
                q = q.Where(p => p.Name.ToLower().Contains(s) || p.Article.ToLower().Contains(s)
                    || p.Description.ToLower().Contains(s) || p.Supplier.ToLower().Contains(s) || p.Manifacturer.ToLower().Contains(s));
            }

            if (_user.CanSearch && cbSupplier.SelectedIndex > 0) q = q.Where(p => p.Supplier == cbSupplier.Text);
            if (_user.CanSearch)
            {
                q = cbSort.SelectedIndex switch
                {
                    0 => q.OrderBy(p => p.StockQuantity),
                    1 => q.OrderByDescending(p => p.StockQuantity),
                    _ => q
                };
            }

            var list = q.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var p = list[i];

                var card = new ProductCardControl
                {
                    Width = flpCard.Width - 40,
                    Margin = new Padding(5),
                    CardIndex = i
                };

                card.SetData(p);

                card.Click += (s, e) =>
                {
                    var clickedCard = (ProductCardControl)s!;
                    int index = clickedCard.CardIndex;

                    _selectedArticle = list[index].Article;
                    flpCard.Controls
                        .OfType<ProductCardControl>()
                        .ToList()
                        .ForEach(c => c.BorderStyle = BorderStyle.None);
                    clickedCard.BorderStyle = BorderStyle.FixedSingle;
                };

                if (_user.IsAdmin)
                {
                    card.DoubleClick += (s, e) =>
                    {
                        var clickedCard = (ProductCardControl)s!;
                        int index = clickedCard.CardIndex;
                        OpenProductForm(list[index].Article);
                    };

                    card.Cursor = Cursors.Hand;
                }
                flpCard.Controls.Add(card);
            }
        }

        public void DeleteSelected()
        {
            if (string.IsNullOrEmpty(_selectedArticle))
            {
                MessageBox.Show("Выберите товар кликом", "Внимание"); return;
            }
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранный товар? Операцию нельзя отменить.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            using var db = new AppDbContext();
            var orders = db.Orders
                .AsEnumerable()
                .Any(o => o.OrderArticle.Split(',', StringSplitOptions.TrimEntries).Any(a => a == _selectedArticle));
            if (orders)
            {
                MessageBox.Show("Нельзя удалить товар: товар присутствует в заказах", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var prod = db.Products.FirstOrDefault(p => p.Article == _selectedArticle);
            if (prod != null) { db.Products.Remove(prod); db.SaveChanges(); }
            LoadCards();
        }

        public static Image? GetPhoto(string? fileName)
        {
            string name = string.IsNullOrWhiteSpace(fileName) ? "picture.png" : fileName;
            string path = Path.Combine(AppContext.BaseDirectory, "Photos", name);
            if (!File.Exists(path)) return null;

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return Image.FromStream(stream);
        }

        public void OpenProductForm(string? article)
        {
            if (Application.OpenForms.OfType<ProductForm>().Any())
            {
                MessageBox.Show("Закройте окно редактирования", "Внимание");
                return;
            }
            var f = new ProductForm(article, _user);
            f.FormClosed += (s, e) => LoadCards();
            f.Show();
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
