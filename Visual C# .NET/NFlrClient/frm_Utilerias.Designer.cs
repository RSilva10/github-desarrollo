namespace NFlrClient
{
    partial class frm_Utilerias
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnu_Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_Cif = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Des = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Cifrar = new System.Windows.Forms.Panel();
            this.btn_Cifrar = new System.Windows.Forms.Button();
            this.txt_Cifrado = new System.Windows.Forms.TextBox();
            this.lbl_Cifrado = new System.Windows.Forms.Label();
            this.txt_Texto = new System.Windows.Forms.TextBox();
            this.lbl_Texto = new System.Windows.Forms.Label();
            this.pnl_Descifrar = new System.Windows.Forms.Panel();
            this.btn_Descifrar = new System.Windows.Forms.Button();
            this.txt_Descifrar = new System.Windows.Forms.TextBox();
            this.lbl_Descifrar = new System.Windows.Forms.Label();
            this.txt_Texto2 = new System.Windows.Forms.TextBox();
            this.lbl_Texto2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnl_Cifrar.SuspendLayout();
            this.pnl_Descifrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Clientes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnu_Clientes
            // 
            this.mnu_Clientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.mnu_Cif,
            this.mnu_Des});
            this.mnu_Clientes.Name = "mnu_Clientes";
            this.mnu_Clientes.Size = new System.Drawing.Size(99, 20);
            this.mnu_Clientes.Text = "Ménu principal";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnu_Cif
            // 
            this.mnu_Cif.Name = "mnu_Cif";
            this.mnu_Cif.Size = new System.Drawing.Size(181, 22);
            this.mnu_Cif.Text = "Cifrar texto";
            this.mnu_Cif.Click += new System.EventHandler(this.mnu_Cif_Click);
            // 
            // mnu_Des
            // 
            this.mnu_Des.Name = "mnu_Des";
            this.mnu_Des.Size = new System.Drawing.Size(180, 22);
            this.mnu_Des.Text = "Descifrar texto";
            this.mnu_Des.Click += new System.EventHandler(this.mnu_Des_Click);
            // 
            // pnl_Cifrar
            // 
            this.pnl_Cifrar.Controls.Add(this.btn_Cifrar);
            this.pnl_Cifrar.Controls.Add(this.txt_Cifrado);
            this.pnl_Cifrar.Controls.Add(this.lbl_Cifrado);
            this.pnl_Cifrar.Controls.Add(this.txt_Texto);
            this.pnl_Cifrar.Controls.Add(this.lbl_Texto);
            this.pnl_Cifrar.Location = new System.Drawing.Point(12, 34);
            this.pnl_Cifrar.Name = "pnl_Cifrar";
            this.pnl_Cifrar.Size = new System.Drawing.Size(588, 139);
            this.pnl_Cifrar.TabIndex = 1;
            // 
            // btn_Cifrar
            // 
            this.btn_Cifrar.Location = new System.Drawing.Point(472, 113);
            this.btn_Cifrar.Name = "btn_Cifrar";
            this.btn_Cifrar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cifrar.TabIndex = 4;
            this.btn_Cifrar.Text = "Cifrar";
            this.btn_Cifrar.UseVisualStyleBackColor = true;
            this.btn_Cifrar.Click += new System.EventHandler(this.btn_Cifrar_Click);
            // 
            // txt_Cifrado
            // 
            this.txt_Cifrado.Location = new System.Drawing.Point(168, 64);
            this.txt_Cifrado.Name = "txt_Cifrado";
            this.txt_Cifrado.Size = new System.Drawing.Size(379, 20);
            this.txt_Cifrado.TabIndex = 2;
            // 
            // lbl_Cifrado
            // 
            this.lbl_Cifrado.AutoSize = true;
            this.lbl_Cifrado.Location = new System.Drawing.Point(3, 64);
            this.lbl_Cifrado.Name = "lbl_Cifrado";
            this.lbl_Cifrado.Size = new System.Drawing.Size(75, 13);
            this.lbl_Cifrado.TabIndex = 3;
            this.lbl_Cifrado.Text = "Texto cifrado: ";
            // 
            // txt_Texto
            // 
            this.txt_Texto.Location = new System.Drawing.Point(168, 23);
            this.txt_Texto.Name = "txt_Texto";
            this.txt_Texto.Size = new System.Drawing.Size(379, 20);
            this.txt_Texto.TabIndex = 3;
            // 
            // lbl_Texto
            // 
            this.lbl_Texto.AutoSize = true;
            this.lbl_Texto.Location = new System.Drawing.Point(3, 23);
            this.lbl_Texto.Name = "lbl_Texto";
            this.lbl_Texto.Size = new System.Drawing.Size(142, 13);
            this.lbl_Texto.TabIndex = 2;
            this.lbl_Texto.Text = "Proporcione el texto a cifrar: ";
            // 
            // pnl_Descifrar
            // 
            this.pnl_Descifrar.Controls.Add(this.btn_Descifrar);
            this.pnl_Descifrar.Controls.Add(this.txt_Descifrar);
            this.pnl_Descifrar.Controls.Add(this.lbl_Descifrar);
            this.pnl_Descifrar.Controls.Add(this.txt_Texto2);
            this.pnl_Descifrar.Controls.Add(this.lbl_Texto2);
            this.pnl_Descifrar.Location = new System.Drawing.Point(12, 202);
            this.pnl_Descifrar.Name = "pnl_Descifrar";
            this.pnl_Descifrar.Size = new System.Drawing.Size(588, 139);
            this.pnl_Descifrar.TabIndex = 2;
            // 
            // btn_Descifrar
            // 
            this.btn_Descifrar.Location = new System.Drawing.Point(472, 113);
            this.btn_Descifrar.Name = "btn_Descifrar";
            this.btn_Descifrar.Size = new System.Drawing.Size(75, 23);
            this.btn_Descifrar.TabIndex = 4;
            this.btn_Descifrar.Text = "Descifrar";
            this.btn_Descifrar.UseVisualStyleBackColor = true;
            this.btn_Descifrar.Click += new System.EventHandler(this.btn_Descifrar_Click);
            // 
            // txt_Descifrar
            // 
            this.txt_Descifrar.Location = new System.Drawing.Point(168, 64);
            this.txt_Descifrar.Name = "txt_Descifrar";
            this.txt_Descifrar.Size = new System.Drawing.Size(379, 20);
            this.txt_Descifrar.TabIndex = 2;
            // 
            // lbl_Descifrar
            // 
            this.lbl_Descifrar.AutoSize = true;
            this.lbl_Descifrar.Location = new System.Drawing.Point(3, 64);
            this.lbl_Descifrar.Name = "lbl_Descifrar";
            this.lbl_Descifrar.Size = new System.Drawing.Size(92, 13);
            this.lbl_Descifrar.TabIndex = 3;
            this.lbl_Descifrar.Text = "Texto descifrado: ";
            // 
            // txt_Texto2
            // 
            this.txt_Texto2.Location = new System.Drawing.Point(168, 23);
            this.txt_Texto2.Name = "txt_Texto2";
            this.txt_Texto2.Size = new System.Drawing.Size(379, 20);
            this.txt_Texto2.TabIndex = 3;
            // 
            // lbl_Texto2
            // 
            this.lbl_Texto2.AutoSize = true;
            this.lbl_Texto2.Location = new System.Drawing.Point(3, 23);
            this.lbl_Texto2.Name = "lbl_Texto2";
            this.lbl_Texto2.Size = new System.Drawing.Size(159, 13);
            this.lbl_Texto2.TabIndex = 2;
            this.lbl_Texto2.Text = "Proporcione el texto a descifrar: ";
            // 
            // frm_Utilerias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 365);
            this.Controls.Add(this.pnl_Descifrar);
            this.Controls.Add(this.pnl_Cifrar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_Utilerias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilerias";
            this.Load += new System.EventHandler(this.frm_Utilerias_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_Cifrar.ResumeLayout(false);
            this.pnl_Cifrar.PerformLayout();
            this.pnl_Descifrar.ResumeLayout(false);
            this.pnl_Descifrar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Clientes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnu_Cif;
        private System.Windows.Forms.ToolStripMenuItem mnu_Des;
        private System.Windows.Forms.Panel pnl_Cifrar;
        private System.Windows.Forms.TextBox txt_Texto;
        private System.Windows.Forms.Label lbl_Texto;
        private System.Windows.Forms.Label lbl_Cifrado;
        private System.Windows.Forms.Button btn_Cifrar;
        private System.Windows.Forms.TextBox txt_Cifrado;
        private System.Windows.Forms.Panel pnl_Descifrar;
        private System.Windows.Forms.Button btn_Descifrar;
        private System.Windows.Forms.TextBox txt_Descifrar;
        private System.Windows.Forms.Label lbl_Descifrar;
        private System.Windows.Forms.TextBox txt_Texto2;
        private System.Windows.Forms.Label lbl_Texto2;
    }
}

