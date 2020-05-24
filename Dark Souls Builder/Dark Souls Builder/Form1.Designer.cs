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
            this.OpenFileD = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileD = new System.Windows.Forms.SaveFileDialog();
            this.SerializersCB = new System.Windows.Forms.ComboBox();
            this.LoadBT = new System.Windows.Forms.Button();
            this.SaveBT = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DecodeBT = new System.Windows.Forms.Button();
            this.EncodeBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ObjectsLB
            // 
            this.ObjectsLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ObjectsLB.FormattingEnabled = true;
            this.ObjectsLB.ItemHeight = 26;
            this.ObjectsLB.Location = new System.Drawing.Point(13, 12);
            this.ObjectsLB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ObjectsLB.Name = "ObjectsLB";
            this.ObjectsLB.Size = new System.Drawing.Size(281, 264);
            this.ObjectsLB.TabIndex = 1;
            this.ObjectsLB.SelectedIndexChanged += new System.EventHandler(this.ObjectsLB_SelectedIndexChanged);
            // 
            // ClassesCB
            // 
            this.ClassesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassesCB.FormattingEnabled = true;
            this.ClassesCB.Location = new System.Drawing.Point(301, 14);
            this.ClassesCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClassesCB.Name = "ClassesCB";
            this.ClassesCB.Size = new System.Drawing.Size(303, 24);
            this.ClassesCB.TabIndex = 2;
            // 
            // CreateBT
            // 
            this.CreateBT.Location = new System.Drawing.Point(301, 57);
            this.CreateBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateBT.Name = "CreateBT";
            this.CreateBT.Size = new System.Drawing.Size(143, 41);
            this.CreateBT.TabIndex = 3;
            this.CreateBT.Text = "Create";
            this.CreateBT.UseVisualStyleBackColor = true;
            this.CreateBT.Click += new System.EventHandler(this.CreateBT_Click);
            // 
            // InfoLB
            // 
            this.InfoLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLB.FormattingEnabled = true;
            this.InfoLB.ItemHeight = 26;
            this.InfoLB.Location = new System.Drawing.Point(609, 12);
            this.InfoLB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InfoLB.Name = "InfoLB";
            this.InfoLB.Size = new System.Drawing.Size(281, 264);
            this.InfoLB.TabIndex = 5;
            this.InfoLB.SelectedIndexChanged += new System.EventHandler(this.InfoLB_SelectedIndexChanged);
            // 
            // PropertiesCB
            // 
            this.PropertiesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PropertiesCB.FormattingEnabled = true;
            this.PropertiesCB.Location = new System.Drawing.Point(896, 14);
            this.PropertiesCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PropertiesCB.Name = "PropertiesCB";
            this.PropertiesCB.Size = new System.Drawing.Size(303, 24);
            this.PropertiesCB.TabIndex = 6;
            // 
            // PropTB
            // 
            this.PropTB.Location = new System.Drawing.Point(897, 14);
            this.PropTB.Margin = new System.Windows.Forms.Padding(4);
            this.PropTB.Name = "PropTB";
            this.PropTB.Size = new System.Drawing.Size(303, 22);
            this.PropTB.TabIndex = 7;
            // 
            // ConfrimBT
            // 
            this.ConfrimBT.Location = new System.Drawing.Point(981, 57);
            this.ConfrimBT.Margin = new System.Windows.Forms.Padding(4);
            this.ConfrimBT.Name = "ConfrimBT";
            this.ConfrimBT.Size = new System.Drawing.Size(143, 41);
            this.ConfrimBT.TabIndex = 8;
            this.ConfrimBT.Text = "Confirm";
            this.ConfrimBT.UseVisualStyleBackColor = true;
            this.ConfrimBT.Click += new System.EventHandler(this.ConfrimBT_Click);
            // 
            // RemoveBT
            // 
            this.RemoveBT.Location = new System.Drawing.Point(461, 57);
            this.RemoveBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveBT.Name = "RemoveBT";
            this.RemoveBT.Size = new System.Drawing.Size(143, 41);
            this.RemoveBT.TabIndex = 9;
            this.RemoveBT.Text = "Remove";
            this.RemoveBT.UseVisualStyleBackColor = true;
            this.RemoveBT.Click += new System.EventHandler(this.RemoveBT_Click);
            // 
            // OpenFileD
            // 
            this.OpenFileD.FileName = "openFileDialog1";
            // 
            // SerializersCB
            // 
            this.SerializersCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerializersCB.FormattingEnabled = true;
            this.SerializersCB.Location = new System.Drawing.Point(301, 146);
            this.SerializersCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SerializersCB.Name = "SerializersCB";
            this.SerializersCB.Size = new System.Drawing.Size(303, 24);
            this.SerializersCB.TabIndex = 11;
            // 
            // LoadBT
            // 
            this.LoadBT.Location = new System.Drawing.Point(301, 194);
            this.LoadBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadBT.Name = "LoadBT";
            this.LoadBT.Size = new System.Drawing.Size(143, 41);
            this.LoadBT.TabIndex = 12;
            this.LoadBT.Text = "Load";
            this.LoadBT.UseVisualStyleBackColor = true;
            this.LoadBT.Click += new System.EventHandler(this.LoadBT_Click);
            // 
            // SaveBT
            // 
            this.SaveBT.Location = new System.Drawing.Point(461, 194);
            this.SaveBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveBT.Name = "SaveBT";
            this.SaveBT.Size = new System.Drawing.Size(143, 41);
            this.SaveBT.TabIndex = 13;
            this.SaveBT.Text = "Save";
            this.SaveBT.UseVisualStyleBackColor = true;
            this.SaveBT.Click += new System.EventHandler(this.SaveBT_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 293);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // DecodeBT
            // 
            this.DecodeBT.Location = new System.Drawing.Point(173, 331);
            this.DecodeBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DecodeBT.Name = "DecodeBT";
            this.DecodeBT.Size = new System.Drawing.Size(143, 41);
            this.DecodeBT.TabIndex = 16;
            this.DecodeBT.Text = "Decode";
            this.DecodeBT.UseVisualStyleBackColor = true;
            this.DecodeBT.Click += new System.EventHandler(this.DecodeBT_Click);
            // 
            // EncodeBT
            // 
            this.EncodeBT.Location = new System.Drawing.Point(13, 331);
            this.EncodeBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EncodeBT.Name = "EncodeBT";
            this.EncodeBT.Size = new System.Drawing.Size(143, 41);
            this.EncodeBT.TabIndex = 15;
            this.EncodeBT.Text = "Encode";
            this.EncodeBT.UseVisualStyleBackColor = true;
            this.EncodeBT.Click += new System.EventHandler(this.EncodeBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 436);
            this.Controls.Add(this.DecodeBT);
            this.Controls.Add(this.EncodeBT);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SaveBT);
            this.Controls.Add(this.LoadBT);
            this.Controls.Add(this.SerializersCB);
            this.Controls.Add(this.RemoveBT);
            this.Controls.Add(this.ConfrimBT);
            this.Controls.Add(this.PropTB);
            this.Controls.Add(this.PropertiesCB);
            this.Controls.Add(this.InfoLB);
            this.Controls.Add(this.CreateBT);
            this.Controls.Add(this.ClassesCB);
            this.Controls.Add(this.ObjectsLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
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
        private System.Windows.Forms.OpenFileDialog OpenFileD;
        private System.Windows.Forms.SaveFileDialog SaveFileD;
        private System.Windows.Forms.ComboBox SerializersCB;
        private System.Windows.Forms.Button LoadBT;
        private System.Windows.Forms.Button SaveBT;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button DecodeBT;
        private System.Windows.Forms.Button EncodeBT;
    }
}

