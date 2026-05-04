using Demoexam.Models;

namespace Demoexam
{
    public partial class ProductCardControl : UserControl
    {
        public int CardIndex { get; set; }

        public ProductCardControl()
        {
            InitializeComponent();
            BindClickEvents(this);
        }

        public void SetData(Product p)
        {
            lblTitle.Text = $"{p.Category} | {p.Name}";
            lblDesc.Text = $"Описание: {p.Description}";
            lblMfg.Text = $"Производитель: {p.Manifacturer}";
            lblSupplier.Text = $"Поставщик: {p.Supplier}";
            lblPrice.Text = $"Цена: {p.Price:F2}";
            lblUnit.Text = $"Ед. изм: {p.Unit}";
            lblStock.Text = $"На складе: {p.StockQuantity} шт.";

            if (p.Discount > 0)
            {
                decimal finalPrice = p.Price * (1 - p.Discount / 100m);
                lblPrice.Text = $"{p.Price:F2} ₽";
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Strikeout);
                lblPrice.ForeColor = Color.Red;

                lblFinalPrice.Text = $"Итог: {finalPrice:F2} ₽";
                lblFinalPrice.Visible = true;

                lblDiscount.Text = $"-{p.Discount}%";
                lblDiscount.Visible = true;
            }
            else
            {
                lblPrice.Text = $"{p.Price:F2} ₽";
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Regular);
                lblPrice.ForeColor = SystemColors.WindowText;
                lblFinalPrice.Visible = false;
                lblDiscount.Visible = false;
            }

            pbPhoto.Image?.Dispose();
            pbPhoto.Image = MainForm.GetPhoto(p.Photo);

            panelCard.BackColor = p.StockQuantity == 0 ? Color.LightBlue :
                p.Discount > 15 ? ColorTranslator.FromHtml("#2E8B57") : Color.White;
            ForeColor = p.Discount > 15 ? Color.White : SystemColors.WindowText;
        }

        private void BindClickEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Click += (s, e) => OnClick(e);
                ctrl.DoubleClick += (s, e) => OnDoubleClick(e);

                if (ctrl.HasChildren)
                    BindClickEvents(ctrl);
            }
        }
    }
}
