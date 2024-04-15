namespace Aplicativo1
{
    partial class Movimento
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
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            listBox1 = new ListBox();
            label3 = new Label();
            listBox2 = new ListBox();
            label4 = new Label();
            listBox3 = new ListBox();
            panel2 = new Panel();
            listBox7 = new ListBox();
            label9 = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            listBox6 = new ListBox();
            label6 = new Label();
            listBox5 = new ListBox();
            label5 = new Label();
            listBox4 = new ListBox();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 30);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(337, 2);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 1;
            label1.Text = "Movimento";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Red;
            button1.FlatAppearance.MouseOverBackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(776, 2);
            button1.Name = "button1";
            button1.Size = new Size(24, 25);
            button1.TabIndex = 0;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 73);
            label2.Name = "label2";
            label2.Size = new Size(51, 17);
            label2.TabIndex = 1;
            label2.Text = "Cliente ";
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.ForeColor = SystemColors.WindowText;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(72, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(234, 17);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 114);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 3;
            label3.Text = "Conta";
            // 
            // listBox2
            // 
            listBox2.BorderStyle = BorderStyle.FixedSingle;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(72, 118);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(234, 17);
            listBox2.TabIndex = 4;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(478, 26);
            label4.Name = "label4";
            label4.Size = new Size(43, 17);
            label4.TabIndex = 5;
            label4.Text = "Banco";
            // 
            // listBox3
            // 
            listBox3.BorderStyle = BorderStyle.FixedSingle;
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(534, 26);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(252, 17);
            listBox3.TabIndex = 6;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(listBox7);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(listBox6);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(listBox5);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(listBox4);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(listBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(listBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(listBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 188);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // listBox7
            // 
            listBox7.BorderStyle = BorderStyle.FixedSingle;
            listBox7.FormattingEnabled = true;
            listBox7.ItemHeight = 15;
            listBox7.Location = new Point(72, 155);
            listBox7.Name = "listBox7";
            listBox7.Size = new Size(234, 17);
            listBox7.TabIndex = 20;
            listBox7.SelectedIndexChanged += listBox7_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 159);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 19;
            label9.Text = "Agência";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 29);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 18;
            label8.Text = "Buscar";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(72, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 23);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox6
            // 
            listBox6.BorderStyle = BorderStyle.FixedSingle;
            listBox6.FormattingEnabled = true;
            listBox6.ItemHeight = 15;
            listBox6.Location = new Point(534, 155);
            listBox6.Name = "listBox6";
            listBox6.Size = new Size(252, 17);
            listBox6.TabIndex = 16;
            listBox6.SelectedIndexChanged += listBox6_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(488, 155);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 15;
            label6.Text = "Valor";
            // 
            // listBox5
            // 
            listBox5.BorderStyle = BorderStyle.FixedSingle;
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 15;
            listBox5.Location = new Point(534, 112);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(254, 17);
            listBox5.TabIndex = 14;
            listBox5.SelectedIndexChanged += listBox5_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(490, 112);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 13;
            label5.Text = "Data";
            // 
            // listBox4
            // 
            listBox4.BorderStyle = BorderStyle.FixedSingle;
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 15;
            listBox4.Location = new Point(534, 71);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(252, 17);
            listBox4.TabIndex = 12;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(461, 71);
            label7.Name = "label7";
            label7.Size = new Size(67, 17);
            label7.TabIndex = 11;
            label7.Text = "Transação";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 214);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(801, 237);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button2.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 472);
            button2.Name = "button2";
            button2.Size = new Size(98, 29);
            button2.TabIndex = 9;
            button2.Text = "Inclui";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button3.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(232, 472);
            button3.Name = "button3";
            button3.Size = new Size(97, 29);
            button3.TabIndex = 10;
            button3.Text = "Exclui";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button5.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(470, 472);
            button5.Name = "button5";
            button5.Size = new Size(97, 29);
            button5.TabIndex = 12;
            button5.Text = "Processa";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button6.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(691, 472);
            button6.Name = "button6";
            button6.Size = new Size(97, 29);
            button6.TabIndex = 13;
            button6.Text = "Exporta";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Movimento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 513);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Movimento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimento";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private Label label3;
        private ListBox listBox2;
        private Label label4;
        private ListBox listBox3;
        private Panel panel2;
        private ListBox listBox4;
        private Label label7;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button5;
        private Button button6;
        private ListBox listBox5;
        private Label label5;
        private ListBox listBox6;
        private Label label6;
        private TextBox textBox1;
        private Label label8;
        private Label label9;
        private ListBox listBox7;
    }
}