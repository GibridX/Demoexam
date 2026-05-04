namespace Demoexam
{
    partial class ProductCardControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            panelCard = new Panel();
            lblFinalPrice = new Label();
            lblDiscount = new Label();
            lblStock = new Label();
            lblUnit = new Label();
            lblPrice = new Label();
            lblSupplier = new Label();
            lblMfg = new Label();
            lblDesc = new Label();
            lblTitle = new Label();
            pbPhoto = new PictureBox();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.Controls.Add(lblFinalPrice);
            panelCard.Controls.Add(lblDiscount);
            panelCard.Controls.Add(lblStock);
            panelCard.Controls.Add(lblUnit);
            panelCard.Controls.Add(lblPrice);
            panelCard.Controls.Add(lblSupplier);
            panelCard.Controls.Add(lblMfg);
            panelCard.Controls.Add(lblDesc);
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(pbPhoto);
            panelCard.Dock = DockStyle.Fill;
            panelCard.Location = new Point(0, 0);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(670, 214);
            panelCard.TabIndex = 0;
            // 
            // lblFinalPrice
            // 
            lblFinalPrice.AutoSize = true;
            lblFinalPrice.Location = new Point(575, 72);
            lblFinalPrice.Name = "lblFinalPrice";
            lblFinalPrice.Size = new Size(38, 15);
            lblFinalPrice.TabIndex = 10;
            lblFinalPrice.Text = "label1";
            // 
            // lblDiscount
            // 
            lblDiscount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDiscount.AutoSize = true;
            lblDiscount.BackColor = Color.IndianRed;
            lblDiscount.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiscount.ForeColor = SystemColors.Control;
            lblDiscount.Location = new Point(578, 98);
            lblDiscount.Margin = new Padding(0, 10, 10, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Padding = new Padding(5, 0, 3, 0);
            lblDiscount.Size = new Size(67, 22);
            lblDiscount.TabIndex = 9;
            lblDiscount.Text = "label1";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(202, 182);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(38, 15);
            lblStock.TabIndex = 8;
            lblStock.Text = "label1";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(202, 154);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(38, 15);
            lblUnit.TabIndex = 7;
            lblUnit.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(202, 130);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 15);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "label1";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(202, 104);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(38, 15);
            lblSupplier.TabIndex = 4;
            lblSupplier.Text = "label1";
            // 
            // lblMfg
            // 
            lblMfg.AutoSize = true;
            lblMfg.Location = new Point(202, 80);
            lblMfg.Name = "lblMfg";
            lblMfg.Size = new Size(38, 15);
            lblMfg.TabIndex = 3;
            lblMfg.Text = "label1";
            // 
            // lblDesc
            // 
            lblDesc.Location = new Point(202, 44);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(300, 36);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "label1";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(202, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(59, 22);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "label1";
            // 
            // pbPhoto
            // 
            pbPhoto.Location = new Point(19, 18);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(160, 160);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 0;
            pbPhoto.TabStop = false;
            // 
            // ProductCardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCard);
            Name = "ProductCardControl";
            Size = new Size(670, 214);
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private PictureBox pbPhoto;
        private Label lblDiscount;
        private Label lblStock;
        private Label lblUnit;
        private Label lblPrice;
        private Label lblSupplier;
        private Label lblMfg;
        private Label lblDesc;
        private Label lblTitle;
        private Label lblFinalPrice;
    }
}
