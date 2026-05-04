namespace Demoexam
{
    partial class OrderForm
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
            lblClient = new Label();
            txtClient = new TextBox();
            label1 = new Label();
            txtArticle = new TextBox();
            label2 = new Label();
            dtpOrder = new DateTimePicker();
            label3 = new Label();
            dtpDelivery = new DateTimePicker();
            label4 = new Label();
            txtStatus = new TextBox();
            label5 = new Label();
            txtCode = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Location = new Point(12, 9);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(81, 15);
            lblClient.TabIndex = 0;
            lblClient.Text = "ФИО клиента";
            // 
            // txtClient
            // 
            txtClient.Location = new Point(12, 36);
            txtClient.Name = "txtClient";
            txtClient.Size = new Size(100, 23);
            txtClient.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 9);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 2;
            label1.Text = "Артикулы товаров";
            // 
            // txtArticle
            // 
            txtArticle.Location = new Point(144, 36);
            txtArticle.Name = "txtArticle";
            txtArticle.Size = new Size(100, 23);
            txtArticle.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 77);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Дата заказа";
            // 
            // dtpOrder
            // 
            dtpOrder.Format = DateTimePickerFormat.Short;
            dtpOrder.Location = new Point(13, 104);
            dtpOrder.Name = "dtpOrder";
            dtpOrder.Size = new Size(99, 23);
            dtpOrder.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 77);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 6;
            label3.Text = "Дата доставки";
            // 
            // dtpDelivery
            // 
            dtpDelivery.Format = DateTimePickerFormat.Short;
            dtpDelivery.Location = new Point(144, 104);
            dtpDelivery.Name = "dtpDelivery";
            dtpDelivery.Size = new Size(100, 23);
            dtpDelivery.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 147);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 8;
            label4.Text = "Статус";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(13, 174);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(99, 23);
            txtStatus.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(144, 147);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 10;
            label5.Text = "Код получения";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(144, 174);
            txtCode.MaxLength = 6;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(100, 23);
            txtCode.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(13, 223);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(144, 223);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 274);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtCode);
            Controls.Add(label5);
            Controls.Add(txtStatus);
            Controls.Add(label4);
            Controls.Add(dtpDelivery);
            Controls.Add(label3);
            Controls.Add(dtpOrder);
            Controls.Add(label2);
            Controls.Add(txtArticle);
            Controls.Add(label1);
            Controls.Add(txtClient);
            Controls.Add(lblClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OrderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClient;
        private TextBox txtClient;
        private Label label1;
        private TextBox txtArticle;
        private Label label2;
        private DateTimePicker dtpOrder;
        private Label label3;
        private DateTimePicker dtpDelivery;
        private Label label4;
        private TextBox txtStatus;
        private Label label5;
        private TextBox txtCode;
        private Button btnSave;
        private Button btnCancel;
    }
}