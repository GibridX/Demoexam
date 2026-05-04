namespace Demoexam
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtArticle = new TextBox();
            txtName = new TextBox();
            cbCategory = new ComboBox();
            txtDesc = new TextBox();
            cbManifacturer = new ComboBox();
            txtSupplier = new TextBox();
            cbUnit = new ComboBox();
            nudPrice = new NumericUpDown();
            nudStock = new NumericUpDown();
            nudDiscount = new NumericUpDown();
            pbPhoto = new PictureBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnPhoto = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).BeginInit();
            SuspendLayout();
            // 
            // txtArticle
            // 
            txtArticle.Location = new Point(236, 64);
            txtArticle.Name = "txtArticle";
            txtArticle.PlaceholderText = "Артикул";
            txtArticle.Size = new Size(100, 23);
            txtArticle.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(383, 64);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Название";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(236, 216);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 23);
            cbCategory.TabIndex = 2;
            cbCategory.Text = "Категория";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(236, 111);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderText = "Описание";
            txtDesc.Size = new Size(399, 84);
            txtDesc.TabIndex = 3;
            // 
            // cbManifacturer
            // 
            cbManifacturer.FormattingEnabled = true;
            cbManifacturer.Location = new Point(383, 216);
            cbManifacturer.Name = "cbManifacturer";
            cbManifacturer.Size = new Size(121, 23);
            cbManifacturer.TabIndex = 4;
            cbManifacturer.Text = "Производитель";
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(535, 64);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.PlaceholderText = "Производитель";
            txtSupplier.Size = new Size(100, 23);
            txtSupplier.TabIndex = 5;
            // 
            // cbUnit
            // 
            cbUnit.FormattingEnabled = true;
            cbUnit.Location = new Point(535, 216);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(121, 23);
            cbUnit.TabIndex = 6;
            cbUnit.Text = "Единица";
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new Point(239, 287);
            nudPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(120, 23);
            nudPrice.TabIndex = 7;
            nudPrice.ThousandsSeparator = true;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(383, 287);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 8;
            // 
            // nudDiscount
            // 
            nudDiscount.Location = new Point(535, 290);
            nudDiscount.Name = "nudDiscount";
            nudDiscount.Size = new Size(120, 23);
            nudDiscount.TabIndex = 9;
            // 
            // pbPhoto
            // 
            pbPhoto.Location = new Point(14, 64);
            pbPhoto.Name = "pbPhoto";
            pbPhoto.Size = new Size(160, 160);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.TabIndex = 10;
            pbPhoto.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(240, 339);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(117, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(383, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 260);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 13;
            label1.Text = "Цена";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(383, 260);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 14;
            label2.Text = "Количество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(535, 272);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 15;
            label3.Text = "Скидка";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 37);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 16;
            label4.Text = "Фото";
            // 
            // btnPhoto
            // 
            btnPhoto.Location = new Point(28, 243);
            btnPhoto.Name = "btnPhoto";
            btnPhoto.Size = new Size(133, 32);
            btnPhoto.TabIndex = 17;
            btnPhoto.Text = "Загрузить фото";
            btnPhoto.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(588, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 18;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 410);
            Controls.Add(btnBack);
            Controls.Add(btnPhoto);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pbPhoto);
            Controls.Add(nudDiscount);
            Controls.Add(nudStock);
            Controls.Add(nudPrice);
            Controls.Add(cbUnit);
            Controls.Add(txtSupplier);
            Controls.Add(cbManifacturer);
            Controls.Add(txtDesc);
            Controls.Add(cbCategory);
            Controls.Add(txtName);
            Controls.Add(txtArticle);
            Name = "ProductForm";
            Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtArticle;
        private TextBox txtName;
        private ComboBox cbCategory;
        private TextBox txtDesc;
        private ComboBox cbManifacturer;
        private TextBox txtSupplier;
        private ComboBox cbUnit;
        private NumericUpDown nudPrice;
        private NumericUpDown nudStock;
        private NumericUpDown nudDiscount;
        private PictureBox pbPhoto;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnPhoto;
        private Button btnBack;
    }
}