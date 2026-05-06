using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Demoexam.Database;
using Demoexam.Models;

namespace Demoexam
{
    public partial class ProductForm : Form
    {
        private readonly string? _article;
        private readonly User _user;
        private string _photo = "picture.png";

        public ProductForm(string? article, User user)
        {
            _article = article;
            _user = user;
            InitializeComponent();
            Load += Form_Load;
            btnBack.Click += (s, e) => Close();
            this.Icon = new Icon("Photos/Icon.ico");
        }

        private void Form_Load(object? sender, EventArgs e)
        {
            Text = string.IsNullOrEmpty(_article) ? "Добавить товар" : "Редактировать товар";
            cbCategory.Items.AddRange(["Женская обувь", "Мужская обувь"]);
            cbManifacturer.Items.AddRange(["Kari", "Marco Tozzi", "Рос", "Rieker", "Alessio Nesca", "CROSBY"]);
            cbUnit.Items.AddRange(["шт.", "пара"]);

            if (!string.IsNullOrEmpty(_article))
            {
                using var db = new AppDbContext();
                var p = db.Products.First(x => x.Article == _article);
                txtArticle.Text = p.Article; txtName.Text = p.Name; cbCategory.SelectedItem = p.Category;
                txtDesc.Text = p.Description;
                cbManifacturer.SelectedItem = p.Manifacturer; txtSupplier.Text = p.Supplier;
                nudPrice.Value = p.Price; cbUnit.SelectedItem = p.Unit; nudStock.Value = p.StockQuantity; nudDiscount.Value = p.Discount;
                _photo = string.IsNullOrWhiteSpace(p.Photo) ? "picture.png" : p.Photo; LoadPhoto();
                txtArticle.ReadOnly = true;
            }
            else
            {
                txtArticle.Visible = false;
            }

            btnPhoto.Click += (s, e) => SelectPhoto();
            btnSave.Click += (s, e) => Save();
            btnCancel.Click += (s, e) => Close();
        }

        private void SelectPhoto()
        {
            using var dlg = new OpenFileDialog { Filter = "Изображения|*.jpg;*.png" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using var img = Image.FromFile(dlg.FileName);
                if (img.Width <= 300 && img.Height <= 200)
                {
                    string fn = Path.GetFileName(dlg.FileName);
                    string dest = Path.Combine(AppContext.BaseDirectory, "Photos", fn);
                    Directory.CreateDirectory(Path.GetDirectoryName(dest)!);
                    File.Copy(dlg.FileName, dest, true);
                    _photo = fn;
                    LoadPhoto();
                }
                else MessageBox.Show("Максимум 300x200 px", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPhoto()
        {
            pbPhoto.Image?.Dispose();
            pbPhoto.Image = MainForm.GetPhoto(_photo);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using var db = new AppDbContext();
                Product p = _article == null ? new Product() : db.Products.First(x => x.Article == _article);

                if (_article == null) 
                {
                    p.Article = Guid.NewGuid().ToString("N")[..6].ToUpper();
                    db.Products.Add(p);
                }
                else
                {
                    string oldPhoto = string.IsNullOrWhiteSpace(p.Photo) ? "picture.png" : p.Photo;
                    string newPhoto = string.IsNullOrWhiteSpace(_photo) ? "picture.png" : _photo;

                    if (oldPhoto != newPhoto && oldPhoto != "picture.png")
                    {
                        try
                        {
                            string oldPath = Path.Combine(AppContext.BaseDirectory, "Photos", oldPhoto);
                            if (File.Exists(oldPath)) File.Delete(oldPath);
                        }
                        catch { }
                    }
                }

                p.Name = txtName.Text;
                p.Category = cbCategory.Text ?? "";
                p.Description = txtDesc.Text ?? "";
                p.Manifacturer = cbManifacturer.Text ?? "";
                p.Supplier = txtSupplier.Text ?? "";
                p.Price = nudPrice.Value;
                p.Unit = cbUnit.Text ?? "шт.";
                p.StockQuantity = (int)nudStock.Value;
                p.Discount = (int)nudDiscount.Value;
                p.Photo = _photo;

                db.SaveChanges(); MessageBox.Show("Сохранено", "Успех"); Close();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }
    }
}
