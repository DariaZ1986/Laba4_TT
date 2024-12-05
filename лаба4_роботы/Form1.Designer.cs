namespace Krasnyanskaya221327Var1
{
    partial class Controller
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.map_draw = new System.Windows.Forms.PictureBox();
            this.Load_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.Create_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.X_Start = new System.Windows.Forms.TextBox();
            this.Y_Start = new System.Windows.Forms.TextBox();
            this.X_Stop = new System.Windows.Forms.TextBox();
            this.Y_Stop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Save_Path = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.map_draw)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 83);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(145, 63);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "127.0.0.1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 32);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "8000";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(9, 55);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(74, 24);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(11, 150);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(143, 183);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // map_draw
            // 
            this.map_draw.Location = new System.Drawing.Point(160, 12);
            this.map_draw.Name = "map_draw";
            this.map_draw.Size = new System.Drawing.Size(640, 400);
            this.map_draw.TabIndex = 7;
            this.map_draw.TabStop = false;
            this.map_draw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.map_draw_MouseClick);
            // 
            // Load_button
            // 
            this.Load_button.Location = new System.Drawing.Point(159, 417);
            this.Load_button.Margin = new System.Windows.Forms.Padding(2);
            this.Load_button.Name = "Load_button";
            this.Load_button.Size = new System.Drawing.Size(99, 24);
            this.Load_button.TabIndex = 8;
            this.Load_button.Text = "Load labyrinth";
            this.Load_button.UseVisualStyleBackColor = true;
            this.Load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(262, 417);
            this.Save_button.Margin = new System.Windows.Forms.Padding(2);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(99, 24);
            this.Save_button.TabIndex = 9;
            this.Save_button.Text = "Save labyrinth";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Create_button
            // 
            this.Create_button.Location = new System.Drawing.Point(365, 417);
            this.Create_button.Margin = new System.Windows.Forms.Padding(2);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(99, 24);
            this.Create_button.TabIndex = 10;
            this.Create_button.Text = "Create the path";
            this.Create_button.UseVisualStyleBackColor = true;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Location = new System.Drawing.Point(468, 417);
            this.edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(99, 24);
            this.edit_button.TabIndex = 11;
            this.edit_button.Text = "Edit labirynth";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(571, 417);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(99, 24);
            this.clear_button.TabIndex = 12;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // X_Start
            // 
            this.X_Start.Location = new System.Drawing.Point(48, 379);
            this.X_Start.Name = "X_Start";
            this.X_Start.Size = new System.Drawing.Size(50, 20);
            this.X_Start.TabIndex = 13;
            // 
            // Y_Start
            // 
            this.Y_Start.Location = new System.Drawing.Point(104, 379);
            this.Y_Start.Name = "Y_Start";
            this.Y_Start.Size = new System.Drawing.Size(50, 20);
            this.Y_Start.TabIndex = 13;
            // 
            // X_Stop
            // 
            this.X_Stop.Location = new System.Drawing.Point(48, 417);
            this.X_Stop.Name = "X_Stop";
            this.X_Stop.Size = new System.Drawing.Size(50, 20);
            this.X_Stop.TabIndex = 13;
            // 
            // Y_Stop
            // 
            this.Y_Stop.Location = new System.Drawing.Point(104, 417);
            this.Y_Stop.Name = "Y_Stop";
            this.Y_Stop.Size = new System.Drawing.Size(50, 20);
            this.Y_Stop.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Stop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Coordinates";
            // 
            // Save_Path
            // 
            this.Save_Path.Location = new System.Drawing.Point(674, 417);
            this.Save_Path.Margin = new System.Windows.Forms.Padding(2);
            this.Save_Path.Name = "Save_Path";
            this.Save_Path.Size = new System.Drawing.Size(122, 24);
            this.Save_Path.TabIndex = 9;
            this.Save_Path.Text = "Save path to CSV";
            this.Save_Path.UseVisualStyleBackColor = true;
            this.Save_Path.Click += new System.EventHandler(this.Save_Path_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 451);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Y_Stop);
            this.Controls.Add(this.X_Stop);
            this.Controls.Add(this.Y_Start);
            this.Controls.Add(this.X_Start);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.Create_button);
            this.Controls.Add(this.Save_Path);
            this.Controls.Add(this.Save_button);
            this.Controls.Add(this.Load_button);
            this.Controls.Add(this.map_draw);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Controller";
            this.Text = "Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Controller_FormClosed);
            this.Load += new System.EventHandler(this.Controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.map_draw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox map_draw;
        private System.Windows.Forms.Button Load_button;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.Button Create_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.TextBox X_Start;
        private System.Windows.Forms.TextBox Y_Start;
        private System.Windows.Forms.TextBox X_Stop;
        private System.Windows.Forms.TextBox Y_Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Save_Path;
    }
}

