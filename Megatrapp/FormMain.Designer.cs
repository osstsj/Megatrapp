namespace Megatrapp
{
    partial class frmMain
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
            this.menuMainWindow = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMainWindow = new System.Windows.Forms.TabControl();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.tabClocks = new System.Windows.Forms.TabPage();
            this.listBoxClocks = new System.Windows.Forms.ListBox();
            this.menuMainWindow.SuspendLayout();
            this.tabControlMainWindow.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabClocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMainWindow
            // 
            this.menuMainWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuMainWindow.Location = new System.Drawing.Point(0, 0);
            this.menuMainWindow.Name = "menuMainWindow";
            this.menuMainWindow.Padding = new System.Windows.Forms.Padding(9, 4, 0, 4);
            this.menuMainWindow.Size = new System.Drawing.Size(810, 27);
            this.menuMainWindow.TabIndex = 0;
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // tabControlMainWindow
            // 
            this.tabControlMainWindow.Controls.Add(this.tabStatus);
            this.tabControlMainWindow.Controls.Add(this.tabUsers);
            this.tabControlMainWindow.Controls.Add(this.tabClocks);
            this.tabControlMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMainWindow.Location = new System.Drawing.Point(0, 27);
            this.tabControlMainWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlMainWindow.Name = "tabControlMainWindow";
            this.tabControlMainWindow.SelectedIndex = 0;
            this.tabControlMainWindow.Size = new System.Drawing.Size(810, 363);
            this.tabControlMainWindow.TabIndex = 1;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.tableLayoutPanel1);
            this.tabStatus.Location = new System.Drawing.Point(4, 30);
            this.tabStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabStatus.Size = new System.Drawing.Size(802, 329);
            this.tabStatus.TabIndex = 0;
            this.tabStatus.Text = "Estatus";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonRun, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 319);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estatus";
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRun.Location = new System.Drawing.Point(347, 222);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(98, 33);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "&Iniciar";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.listBoxUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 30);
            this.tabUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabUsers.Size = new System.Drawing.Size(802, 329);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Usuarios";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 21;
            this.listBoxUsers.Location = new System.Drawing.Point(4, 5);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(794, 319);
            this.listBoxUsers.TabIndex = 0;
            // 
            // tabClocks
            // 
            this.tabClocks.Controls.Add(this.listBoxClocks);
            this.tabClocks.Location = new System.Drawing.Point(4, 30);
            this.tabClocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabClocks.Name = "tabClocks";
            this.tabClocks.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabClocks.Size = new System.Drawing.Size(802, 329);
            this.tabClocks.TabIndex = 2;
            this.tabClocks.Text = "Relojes Checadores";
            this.tabClocks.UseVisualStyleBackColor = true;
            // 
            // listBoxClocks
            // 
            this.listBoxClocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClocks.FormattingEnabled = true;
            this.listBoxClocks.ItemHeight = 21;
            this.listBoxClocks.Location = new System.Drawing.Point(4, 5);
            this.listBoxClocks.Name = "listBoxClocks";
            this.listBoxClocks.Size = new System.Drawing.Size(794, 319);
            this.listBoxClocks.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 390);
            this.Controls.Add(this.tabControlMainWindow);
            this.Controls.Add(this.menuMainWindow);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuMainWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "Megatrapp";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuMainWindow.ResumeLayout(false);
            this.menuMainWindow.PerformLayout();
            this.tabControlMainWindow.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabUsers.ResumeLayout(false);
            this.tabClocks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMainWindow;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMainWindow;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabClocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.ListBox listBoxClocks;
    }
}

