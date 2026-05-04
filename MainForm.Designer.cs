namespace Demoexam
{
    partial class MainForm
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
            lblUser = new Label();
            btnLogout = new Button();
            txtSearch = new TextBox();
            cbSupplier = new ComboBox();
            cbSort = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            flpCard = new FlowLayoutPanel();
            btnOrders = new Button();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(496, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(38, 15);
            lblUser.TabIndex = 0;
            lblUser.Text = "label1";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(677, 36);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(23, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск...";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 2;
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(138, 12);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(121, 23);
            cbSupplier.TabIndex = 3;
            cbSupplier.Text = "Производитель";
            // 
            // cbSort
            // 
            cbSort.FormattingEnabled = true;
            cbSort.Location = new Point(265, 12);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(121, 23);
            cbSort.TabIndex = 4;
            cbSort.Text = "Сортировка";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(23, 415);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(113, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // flpCard
            // 
            flpCard.AutoScroll = true;
            flpCard.Location = new Point(23, 65);
            flpCard.Name = "flpCard";
            flpCard.Size = new Size(729, 319);
            flpCard.TabIndex = 7;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(677, 415);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(75, 23);
            btnOrders.TabIndex = 8;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOrders);
            Controls.Add(flpCard);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(cbSort);
            Controls.Add(cbSupplier);
            Controls.Add(txtSearch);
            Controls.Add(btnLogout);
            Controls.Add(lblUser);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Button btnLogout;
        private TextBox txtSearch;
        private ComboBox cbSupplier;
        private ComboBox cbSort;
        private Button btnAdd;
        private Button btnDelete;
        private FlowLayoutPanel flpCard;
        private Button btnOrders;
    }
}