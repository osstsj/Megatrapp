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
            this.components = new System.ComponentModel.Container();
            this.menuMainWindow = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMainWindow = new System.Windows.Forms.TabControl();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEraseAttendanceRecords = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.enrollNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.privilegeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabClocks = new System.Windows.Forms.TabPage();
            this.splitContainerClocks = new System.Windows.Forms.SplitContainer();
            this.textBoxNewClockIP = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelClockIP = new System.Windows.Forms.Label();
            this.dataGridViewClocks = new System.Windows.Forms.DataGridView();
            this.clocksIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteClock = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabAttendanceRecords = new System.Windows.Forms.TabPage();
            this.dataGridViewAttendanceRecords = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerApp = new System.Windows.Forms.Timer(this.components);
            this.errorProviderClocksIP = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuMainWindow.SuspendLayout();
            this.tabControlMainWindow.SuspendLayout();
            this.tabStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.tabClocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClocks)).BeginInit();
            this.splitContainerClocks.Panel1.SuspendLayout();
            this.splitContainerClocks.Panel2.SuspendLayout();
            this.splitContainerClocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClocks)).BeginInit();
            this.tabAttendanceRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendanceRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClocksIP)).BeginInit();
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
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // tabControlMainWindow
            // 
            this.tabControlMainWindow.Controls.Add(this.tabStatus);
            this.tabControlMainWindow.Controls.Add(this.tabUsers);
            this.tabControlMainWindow.Controls.Add(this.tabClocks);
            this.tabControlMainWindow.Controls.Add(this.tabAttendanceRecords);
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
            this.tableLayoutPanel1.Controls.Add(this.buttonEraseAttendanceRecords, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelStatus, 1, 0);
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
            // buttonEraseAttendanceRecords
            // 
            this.buttonEraseAttendanceRecords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEraseAttendanceRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEraseAttendanceRecords.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonEraseAttendanceRecords.Location = new System.Drawing.Point(64, 222);
            this.buttonEraseAttendanceRecords.Name = "buttonEraseAttendanceRecords";
            this.buttonEraseAttendanceRecords.Size = new System.Drawing.Size(135, 33);
            this.buttonEraseAttendanceRecords.TabIndex = 2;
            this.buttonEraseAttendanceRecords.Text = "&Borrar Registros";
            this.buttonEraseAttendanceRecords.UseVisualStyleBackColor = true;
            this.buttonEraseAttendanceRecords.Click += new System.EventHandler(this.buttonEraseAttendanceRecords_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(366, 69);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(59, 21);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Estatus";
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRun.Location = new System.Drawing.Point(311, 222);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(169, 33);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "&Respaldar registros";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.dataGridViewUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 30);
            this.tabUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabUsers.Size = new System.Drawing.Size(802, 329);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Usuarios";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enrollNumber,
            this.nameColumn,
            this.privilegeColumn,
            this.passwordColumn,
            this.machineNumberColumn});
            this.dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUsers.Location = new System.Drawing.Point(4, 5);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(794, 319);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewUsers_CellBeginEdit);
            this.dataGridViewUsers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellEndEdit);
            // 
            // enrollNumber
            // 
            this.enrollNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.enrollNumber.HeaderText = "ID";
            this.enrollNumber.Name = "enrollNumber";
            this.enrollNumber.ReadOnly = true;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Nombre";
            this.nameColumn.Name = "nameColumn";
            // 
            // privilegeColumn
            // 
            this.privilegeColumn.HeaderText = "Privilegio";
            this.privilegeColumn.Name = "privilegeColumn";
            // 
            // passwordColumn
            // 
            this.passwordColumn.HeaderText = "Password";
            this.passwordColumn.Name = "passwordColumn";
            // 
            // machineNumberColumn
            // 
            this.machineNumberColumn.HeaderText = "Numero de Maquina";
            this.machineNumberColumn.Name = "machineNumberColumn";
            this.machineNumberColumn.ReadOnly = true;
            // 
            // tabClocks
            // 
            this.tabClocks.Controls.Add(this.splitContainerClocks);
            this.tabClocks.Location = new System.Drawing.Point(4, 30);
            this.tabClocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabClocks.Name = "tabClocks";
            this.tabClocks.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabClocks.Size = new System.Drawing.Size(802, 329);
            this.tabClocks.TabIndex = 2;
            this.tabClocks.Text = "Relojes Checadores";
            this.tabClocks.UseVisualStyleBackColor = true;
            // 
            // splitContainerClocks
            // 
            this.splitContainerClocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerClocks.Location = new System.Drawing.Point(4, 5);
            this.splitContainerClocks.Name = "splitContainerClocks";
            // 
            // splitContainerClocks.Panel1
            // 
            this.splitContainerClocks.Panel1.Controls.Add(this.textBoxNewClockIP);
            this.splitContainerClocks.Panel1.Controls.Add(this.buttonAdd);
            this.splitContainerClocks.Panel1.Controls.Add(this.labelClockIP);
            // 
            // splitContainerClocks.Panel2
            // 
            this.splitContainerClocks.Panel2.Controls.Add(this.dataGridViewClocks);
            this.splitContainerClocks.Size = new System.Drawing.Size(794, 319);
            this.splitContainerClocks.SplitterDistance = 334;
            this.splitContainerClocks.TabIndex = 0;
            // 
            // textBoxNewClockIP
            // 
            this.textBoxNewClockIP.Location = new System.Drawing.Point(151, 125);
            this.textBoxNewClockIP.MaxLength = 16;
            this.textBoxNewClockIP.Name = "textBoxNewClockIP";
            this.textBoxNewClockIP.Size = new System.Drawing.Size(168, 29);
            this.textBoxNewClockIP.TabIndex = 3;
            this.textBoxNewClockIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewClockIP_KeyPress);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(243, 173);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(76, 33);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "&Agregar";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelClockIP
            // 
            this.labelClockIP.AutoSize = true;
            this.labelClockIP.Location = new System.Drawing.Point(17, 128);
            this.labelClockIP.Name = "labelClockIP";
            this.labelClockIP.Size = new System.Drawing.Size(115, 21);
            this.labelClockIP.TabIndex = 0;
            this.labelClockIP.Text = "IP del checador";
            // 
            // dataGridViewClocks
            // 
            this.dataGridViewClocks.AllowUserToAddRows = false;
            this.dataGridViewClocks.AllowUserToDeleteRows = false;
            this.dataGridViewClocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clocksIP,
            this.deleteClock});
            this.dataGridViewClocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClocks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewClocks.Name = "dataGridViewClocks";
            this.dataGridViewClocks.ReadOnly = true;
            this.dataGridViewClocks.Size = new System.Drawing.Size(456, 319);
            this.dataGridViewClocks.TabIndex = 0;
            this.dataGridViewClocks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClocks_CellContentClick);
            // 
            // clocksIP
            // 
            this.clocksIP.HeaderText = "IP";
            this.clocksIP.Name = "clocksIP";
            this.clocksIP.ReadOnly = true;
            // 
            // deleteClock
            // 
            this.deleteClock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deleteClock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteClock.HeaderText = "Borrar";
            this.deleteClock.Name = "deleteClock";
            this.deleteClock.ReadOnly = true;
            this.deleteClock.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deleteClock.Text = "Borrar";
            this.deleteClock.UseColumnTextForButtonValue = true;
            // 
            // tabAttendanceRecords
            // 
            this.tabAttendanceRecords.Controls.Add(this.dataGridViewAttendanceRecords);
            this.tabAttendanceRecords.Location = new System.Drawing.Point(4, 30);
            this.tabAttendanceRecords.Name = "tabAttendanceRecords";
            this.tabAttendanceRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttendanceRecords.Size = new System.Drawing.Size(802, 329);
            this.tabAttendanceRecords.TabIndex = 3;
            this.tabAttendanceRecords.Text = "Registros";
            this.tabAttendanceRecords.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAttendanceRecords
            // 
            this.dataGridViewAttendanceRecords.AllowUserToAddRows = false;
            this.dataGridViewAttendanceRecords.AllowUserToDeleteRows = false;
            this.dataGridViewAttendanceRecords.AllowUserToResizeRows = false;
            this.dataGridViewAttendanceRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAttendanceRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttendanceRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.employeeName,
            this.date});
            this.dataGridViewAttendanceRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttendanceRecords.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAttendanceRecords.Name = "dataGridViewAttendanceRecords";
            this.dataGridViewAttendanceRecords.ReadOnly = true;
            this.dataGridViewAttendanceRecords.Size = new System.Drawing.Size(796, 323);
            this.dataGridViewAttendanceRecords.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // employeeName
            // 
            this.employeeName.HeaderText = "Nombre";
            this.employeeName.Name = "employeeName";
            this.employeeName.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Fecha";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // timerApp
            // 
            this.timerApp.Interval = 1000;
            this.timerApp.Tick += new System.EventHandler(this.timerApp_Tick);
            // 
            // errorProviderClocksIP
            // 
            this.errorProviderClocksIP.ContainerControl = this;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.tabClocks.ResumeLayout(false);
            this.splitContainerClocks.Panel1.ResumeLayout(false);
            this.splitContainerClocks.Panel1.PerformLayout();
            this.splitContainerClocks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClocks)).EndInit();
            this.splitContainerClocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClocks)).EndInit();
            this.tabAttendanceRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendanceRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClocksIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMainWindow;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMainWindow;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabClocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.TabPage tabAttendanceRecords;
        private System.Windows.Forms.DataGridView dataGridViewAttendanceRecords;
        private System.Windows.Forms.Timer timerApp;
        private System.Windows.Forms.Button buttonEraseAttendanceRecords;
        private System.Windows.Forms.SplitContainer splitContainerClocks;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelClockIP;
        private System.Windows.Forms.DataGridView dataGridViewClocks;
        private System.Windows.Forms.ErrorProvider errorProviderClocksIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clocksIP;
        private System.Windows.Forms.DataGridViewButtonColumn deleteClock;
        private System.Windows.Forms.TextBox textBoxNewClockIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrollNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn privilegeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNumberColumn;
    }
}

