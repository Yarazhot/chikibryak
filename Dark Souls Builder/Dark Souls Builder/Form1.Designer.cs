namespace Dark_Souls_Builder
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ObjectsLB = new System.Windows.Forms.ListBox();
            this.ClassesCB = new System.Windows.Forms.ComboBox();
            this.CreateBT = new System.Windows.Forms.Button();
            this.InfoLB = new System.Windows.Forms.ListBox();
            this.PropertiesCB = new System.Windows.Forms.ComboBox();
            this.PropTB = new System.Windows.Forms.TextBox();
            this.ConfrimBT = new System.Windows.Forms.Button();
            this.RemoveBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ObjectsLB
            // 
            this.ObjectsLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ObjectsLB.FormattingEnabled = true;
            this.ObjectsLB.ItemHeight = 20;
            this.ObjectsLB.Location = new System.Drawing.Point(10, 10);
            this.ObjectsLB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ObjectsLB.Name = "ObjectsLB";
            this.ObjectsLB.Size = new System.Drawing.Size(212, 264);
            this.ObjectsLB.TabIndex = 1;
            this.ObjectsLB.SelectedIndexChanged += new System.EventHandler(this.ObjectsLB_SelectedIndexChanged);
            // 
            // ClassesCB
            // 
            this.ClassesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassesCB.FormattingEnabled = true;
            this.ClassesCB.Location = new System.Drawing.Point(226, 11);
            this.ClassesCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClassesCB.Name = "ClassesCB";
            this.ClassesCB.Size = new System.Drawing.Size(228, 21);
            this.ClassesCB.TabIndex = 2;
            // 
            // CreateBT
            // 
            this.CreateBT.Location = new System.Drawing.Point(226, 46);
            this.CreateBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateBT.Name = "CreateBT";
            this.CreateBT.Size = new System.Drawing.Size(107, 33);
            this.CreateBT.TabIndex = 3;
            this.CreateBT.Text = "Create";
            this.CreateBT.UseVisualStyleBackColor = true;
            this.CreateBT.Click += new System.EventHandler(this.CreateBT_Click);
            // 
            // InfoLB
            // 
            this.InfoLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLB.FormattingEnabled = true;
            this.InfoLB.ItemHeight = 20;
            this.InfoLB.Location = new System.Drawing.Point(457, 10);
            this.InfoLB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InfoLB.Name = "InfoLB";
            this.InfoLB.Size = new System.Drawing.Size(212, 264);
            this.InfoLB.TabIndex = 5;
            this.InfoLB.SelectedIndexChanged += new System.EventHandler(this.InfoLB_SelectedIndexChanged);
            // 
            // PropertiesCB
            // 
            this.PropertiesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PropertiesCB.FormattingEnabled = true;
            this.PropertiesCB.Location = new System.Drawing.Point(672, 11);
            this.PropertiesCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PropertiesCB.Name = "PropertiesCB";
            this.PropertiesCB.Size = new System.Drawing.Size(228, 21);
            this.PropertiesCB.TabIndex = 6;
            // 
            // PropTB
            // 
            this.PropTB.Location = new System.Drawing.Point(673, 11);
            this.PropTB.Name = "PropTB";
            this.PropTB.Size = new System.Drawing.Size(228, 20);
            this.PropTB.TabIndex = 7;
            // 
            // ConfrimBT
            // 
            this.ConfrimBT.Location = new System.Drawing.Point(736, 46);
            this.ConfrimBT.Name = "ConfrimBT";
            this.ConfrimBT.Size = new System.Drawing.Size(107, 33);
            this.ConfrimBT.TabIndex = 8;
            this.ConfrimBT.Text = "Confirm";
            this.ConfrimBT.UseVisualStyleBackColor = true;
            this.ConfrimBT.Click += new System.EventHandler(this.ConfrimBT_Click);
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(346, 46);
            this.RemoveBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(107, 33);
            this.RemoveBT.TabIndex = 9;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            this.RemoveBT.Click += new System.EventHandler(this.RemoveBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 284);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.ConfrimBT);
            this.Controls.Add(this.PropTB);
            this.Controls.Add(this.PropertiesCB);
            this.Controls.Add(this.InfoLB);
            this.Controls.Add(this.CreateBT);
            this.Controls.Add(this.ClassesCB);
            this.Controls.Add(this.ObjectsLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ObjectsLB;
        private System.Windows.Forms.ComboBox ClassesCB;
        private System.Windows.Forms.Button CreateBT;
        private System.Windows.Forms.ListBox InfoLB;
        private System.Windows.Forms.ComboBox PropertiesCB;
        private System.Windows.Forms.TextBox PropTB;
        private System.Windows.Forms.Button ConfrimBT;
        private System.Windows.Forms.Button RemoveBT;
    }
}

