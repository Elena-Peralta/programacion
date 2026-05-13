namespace Ejercicio_8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtEdad = new TextBox();
            xtNombre = new TextBox();
            txtDiagnostico = new TextBox();
            button1 = new Button();
            dgvPacientes = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 179);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 0;
            label1.Text = "Edad";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 113);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 256);
            label3.Name = "label3";
            label3.Size = new Size(107, 25);
            label3.TabIndex = 2;
            label3.Text = "Diagnostico";
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(158, 179);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(150, 31);
            txtEdad.TabIndex = 3;
            // 
            // xtNombre
            // 
            xtNombre.Location = new Point(158, 110);
            xtNombre.Name = "xtNombre";
            xtNombre.Size = new Size(150, 31);
            xtNombre.TabIndex = 4;
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(158, 256);
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.Size = new Size(150, 31);
            txtDiagnostico.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(196, 357);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 6;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvPacientes
            // 
            dgvPacientes.Location = new Point(355, 357);
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.Size = new Size(163, 34);
            dgvPacientes.TabIndex = 7;
            dgvPacientes.Text = "Mayores de 60";
            dgvPacientes.UseVisualStyleBackColor = true;
            dgvPacientes.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(41, 357);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 8;
            button3.Text = "Registrar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(381, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(360, 225);
            dataGridView1.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(dgvPacientes);
            Controls.Add(button1);
            Controls.Add(txtDiagnostico);
            Controls.Add(xtNombre);
            Controls.Add(txtEdad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtEdad;
        private TextBox xtNombre;
        private TextBox txtDiagnostico;
        private Button button1;
        private Button dgvPacientes;
        private Button button3;
        private DataGridView dataGridView1;
    }
}
