namespace FerreteriaJose_Ando.Forms
{
    partial class ProductosForm
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
            this.Dgw_Producto = new System.Windows.Forms.DataGridView();
            this.Cb_Cat = new System.Windows.Forms.ComboBox();
            this.Cb_Prov = new System.Windows.Forms.ComboBox();
            this.Btn_agregar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Tb_Id = new System.Windows.Forms.TextBox();
            this.Tb_Nom = new System.Windows.Forms.TextBox();
            this.Tb_Pre = new System.Windows.Forms.TextBox();
            this.Nud_Sto = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dgw_Producto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Sto)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgw_Producto
            // 
            this.Dgw_Producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgw_Producto.Location = new System.Drawing.Point(65, 54);
            this.Dgw_Producto.Name = "Dgw_Producto";
            this.Dgw_Producto.Size = new System.Drawing.Size(648, 150);
            this.Dgw_Producto.TabIndex = 0;
            this.Dgw_Producto.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgw_Producto_RowHeaderMouseClick);
            // 
            // Cb_Cat
            // 
            this.Cb_Cat.FormattingEnabled = true;
            this.Cb_Cat.Location = new System.Drawing.Point(172, 353);
            this.Cb_Cat.Name = "Cb_Cat";
            this.Cb_Cat.Size = new System.Drawing.Size(157, 21);
            this.Cb_Cat.TabIndex = 1;
            // 
            // Cb_Prov
            // 
            this.Cb_Prov.FormattingEnabled = true;
            this.Cb_Prov.Location = new System.Drawing.Point(172, 381);
            this.Cb_Prov.Name = "Cb_Prov";
            this.Cb_Prov.Size = new System.Drawing.Size(157, 21);
            this.Cb_Prov.TabIndex = 2;
            // 
            // Btn_agregar
            // 
            this.Btn_agregar.Font = new System.Drawing.Font("Castellar", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_agregar.Location = new System.Drawing.Point(449, 326);
            this.Btn_agregar.Name = "Btn_agregar";
            this.Btn_agregar.Size = new System.Drawing.Size(95, 23);
            this.Btn_agregar.TabIndex = 3;
            this.Btn_agregar.Text = "Agregar";
            this.Btn_agregar.UseVisualStyleBackColor = true;
            this.Btn_agregar.Click += new System.EventHandler(this.Btn_agregar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(550, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eliminar.Location = new System.Drawing.Point(550, 355);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(105, 23);
            this.Eliminar.TabIndex = 5;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Tb_Id
            // 
            this.Tb_Id.Location = new System.Drawing.Point(172, 293);
            this.Tb_Id.Name = "Tb_Id";
            this.Tb_Id.Size = new System.Drawing.Size(157, 20);
            this.Tb_Id.TabIndex = 6;
            // 
            // Tb_Nom
            // 
            this.Tb_Nom.Location = new System.Drawing.Point(172, 323);
            this.Tb_Nom.Name = "Tb_Nom";
            this.Tb_Nom.Size = new System.Drawing.Size(157, 20);
            this.Tb_Nom.TabIndex = 7;
            // 
            // Tb_Pre
            // 
            this.Tb_Pre.Location = new System.Drawing.Point(172, 410);
            this.Tb_Pre.Name = "Tb_Pre";
            this.Tb_Pre.Size = new System.Drawing.Size(157, 20);
            this.Tb_Pre.TabIndex = 8;
            // 
            // Nud_Sto
            // 
            this.Nud_Sto.Location = new System.Drawing.Point(172, 440);
            this.Nud_Sto.Name = "Nud_Sto";
            this.Nud_Sto.Size = new System.Drawing.Size(157, 20);
            this.Nud_Sto.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Castellar", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Stock";
            // 
            // ProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 626);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nud_Sto);
            this.Controls.Add(this.Tb_Pre);
            this.Controls.Add(this.Tb_Nom);
            this.Controls.Add(this.Tb_Id);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Btn_agregar);
            this.Controls.Add(this.Cb_Prov);
            this.Controls.Add(this.Cb_Cat);
            this.Controls.Add(this.Dgw_Producto);
            this.Name = "ProductosForm";
            this.Text = "ProductosForm";
            ((System.ComponentModel.ISupportInitialize)(this.Dgw_Producto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Sto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgw_Producto;
        private System.Windows.Forms.ComboBox Cb_Cat;
        private System.Windows.Forms.ComboBox Cb_Prov;
        private System.Windows.Forms.Button Btn_agregar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.TextBox Tb_Id;
        private System.Windows.Forms.TextBox Tb_Nom;
        private System.Windows.Forms.TextBox Tb_Pre;
        private System.Windows.Forms.NumericUpDown Nud_Sto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}