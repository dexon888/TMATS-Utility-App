namespace TMATDashboardApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            merge2 = new Button();
            mergeBtn = new Button();
            splitBtn = new Button();
            tree_btn = new Button();
            raw_btn = new Button();
            pictureBox2 = new PictureBox();
            outputBox = new RichTextBox();
            file_box = new TextBox();
            label1 = new Label();
            inputButton = new Button_WOC();
            clear_btn = new Button_WOC();
            file_1_box = new RichTextBox();
            file_2_box = new RichTextBox();
            label2 = new Label();
            file_1_btn = new Button_WOC();
            file_2_btn = new Button_WOC();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.MaximumSize = new Size(1000, 1000);
            panel1.Name = "panel1";
            panel1.Size = new Size(291, 576);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(207, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(merge2);
            panel2.Controls.Add(mergeBtn);
            panel2.Controls.Add(splitBtn);
            panel2.Controls.Add(tree_btn);
            panel2.Controls.Add(raw_btn);
            panel2.Location = new Point(0, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(297, 384);
            panel2.TabIndex = 6;
            // 
            // merge2
            // 
            merge2.BackColor = Color.FromArgb(24, 30, 54);
            merge2.FlatAppearance.BorderSize = 0;
            merge2.FlatStyle = FlatStyle.Flat;
            merge2.Font = new Font("Microsoft JhengHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            merge2.ForeColor = Color.White;
            merge2.Location = new Point(3, 292);
            merge2.Name = "merge2";
            merge2.Size = new Size(288, 92);
            merge2.TabIndex = 8;
            merge2.Text = "Merge Same TMAT File";
            merge2.UseVisualStyleBackColor = false;
            merge2.Click += merge2_Click;
            // 
            // mergeBtn
            // 
            mergeBtn.BackColor = Color.FromArgb(24, 30, 54);
            mergeBtn.FlatAppearance.BorderSize = 0;
            mergeBtn.FlatStyle = FlatStyle.Flat;
            mergeBtn.Font = new Font("Microsoft JhengHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            mergeBtn.ForeColor = Color.White;
            mergeBtn.Location = new Point(3, 212);
            mergeBtn.Name = "mergeBtn";
            mergeBtn.Size = new Size(288, 74);
            mergeBtn.TabIndex = 7;
            mergeBtn.Text = "Merge TMAT Files";
            mergeBtn.UseVisualStyleBackColor = false;
            mergeBtn.Click += mergeBtnClick;
            // 
            // splitBtn
            // 
            splitBtn.BackColor = Color.FromArgb(24, 30, 54);
            splitBtn.FlatAppearance.BorderSize = 0;
            splitBtn.FlatStyle = FlatStyle.Flat;
            splitBtn.Font = new Font("Microsoft JhengHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            splitBtn.ForeColor = Color.White;
            splitBtn.Location = new Point(-3, 132);
            splitBtn.Name = "splitBtn";
            splitBtn.Size = new Size(294, 53);
            splitBtn.TabIndex = 6;
            splitBtn.Text = "Split TMAT File";
            splitBtn.UseVisualStyleBackColor = false;
            splitBtn.Click += splitBtnClick;
            // 
            // tree_btn
            // 
            tree_btn.BackColor = Color.FromArgb(24, 30, 54);
            tree_btn.FlatAppearance.BorderSize = 0;
            tree_btn.FlatStyle = FlatStyle.Flat;
            tree_btn.Font = new Font("Microsoft JhengHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            tree_btn.ForeColor = Color.White;
            tree_btn.Location = new Point(3, 56);
            tree_btn.Name = "tree_btn";
            tree_btn.Size = new Size(285, 70);
            tree_btn.TabIndex = 5;
            tree_btn.Text = "Create CSV";
            tree_btn.UseVisualStyleBackColor = false;
            tree_btn.Click += tree_btnClick;
            // 
            // raw_btn
            // 
            raw_btn.Dock = DockStyle.Top;
            raw_btn.FlatAppearance.BorderSize = 0;
            raw_btn.FlatStyle = FlatStyle.Flat;
            raw_btn.Font = new Font("Microsoft JhengHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            raw_btn.ForeColor = Color.White;
            raw_btn.Location = new Point(0, 0);
            raw_btn.Name = "raw_btn";
            raw_btn.Size = new Size(297, 50);
            raw_btn.TabIndex = 4;
            raw_btn.Text = "Raw Format";
            raw_btn.UseVisualStyleBackColor = true;
            raw_btn.Click += raw_btn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(21, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(180, 141);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // outputBox
            // 
            outputBox.BackColor = Color.FromArgb(24, 30, 54);
            outputBox.Font = new Font("Microsoft JhengHei", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            outputBox.ForeColor = SystemColors.Window;
            outputBox.Location = new Point(321, 155);
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.Size = new Size(313, 263);
            outputBox.TabIndex = 8;
            outputBox.Text = "";
            // 
            // file_box
            // 
            file_box.BackColor = Color.FromArgb(24, 30, 54);
            file_box.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            file_box.ForeColor = SystemColors.Window;
            file_box.Location = new Point(321, 112);
            file_box.Name = "file_box";
            file_box.ReadOnly = true;
            file_box.Size = new Size(313, 23);
            file_box.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft JhengHei", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InactiveBorder;
            label1.Location = new Point(321, 9);
            label1.Name = "label1";
            label1.Size = new Size(433, 50);
            label1.TabIndex = 9;
            label1.Text = "TMATS Utility Dashboard";
            // 
            // inputButton
            // 
            inputButton.BorderColor = Color.Silver;
            inputButton.ButtonColor = Color.FromArgb(46, 51, 73);
            inputButton.FlatAppearance.BorderSize = 0;
            inputButton.FlatStyle = FlatStyle.Flat;
            inputButton.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            inputButton.Location = new Point(655, 104);
            inputButton.Name = "inputButton";
            inputButton.OnHoverBorderColor = Color.Gray;
            inputButton.OnHoverButtonColor = Color.MidnightBlue;
            inputButton.OnHoverTextColor = Color.Gray;
            inputButton.Size = new Size(99, 39);
            inputButton.TabIndex = 10;
            inputButton.Text = "TMAT File Input";
            inputButton.TextColor = Color.White;
            inputButton.UseVisualStyleBackColor = true;
            inputButton.Click += inputBtn_Click;
            // 
            // clear_btn
            // 
            clear_btn.BorderColor = Color.Silver;
            clear_btn.ButtonColor = Color.FromArgb(46, 51, 73);
            clear_btn.FlatAppearance.BorderSize = 0;
            clear_btn.FlatStyle = FlatStyle.Flat;
            clear_btn.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            clear_btn.Location = new Point(655, 363);
            clear_btn.Name = "clear_btn";
            clear_btn.OnHoverBorderColor = Color.Gray;
            clear_btn.OnHoverButtonColor = Color.MidnightBlue;
            clear_btn.OnHoverTextColor = Color.Gray;
            clear_btn.Size = new Size(99, 32);
            clear_btn.TabIndex = 11;
            clear_btn.Text = "Clear All";
            clear_btn.TextColor = Color.White;
            clear_btn.UseVisualStyleBackColor = true;
            clear_btn.Click += clearBtn_Click;
            // 
            // file_1_box
            // 
            file_1_box.BackColor = Color.FromArgb(24, 30, 54);
            file_1_box.Font = new Font("Microsoft JhengHei", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            file_1_box.ForeColor = SystemColors.Window;
            file_1_box.Location = new Point(321, 474);
            file_1_box.Name = "file_1_box";
            file_1_box.ReadOnly = true;
            file_1_box.Size = new Size(313, 29);
            file_1_box.TabIndex = 12;
            file_1_box.Text = "";
            // 
            // file_2_box
            // 
            file_2_box.BackColor = Color.FromArgb(24, 30, 54);
            file_2_box.Font = new Font("Microsoft JhengHei", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            file_2_box.ForeColor = SystemColors.Window;
            file_2_box.Location = new Point(321, 528);
            file_2_box.Name = "file_2_box";
            file_2_box.ReadOnly = true;
            file_2_box.Size = new Size(313, 36);
            file_2_box.TabIndex = 13;
            file_2_box.Text = "";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft JhengHei", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.InactiveBorder;
            label2.Location = new Point(321, 433);
            label2.Name = "label2";
            label2.Size = new Size(413, 31);
            label2.TabIndex = 14;
            label2.Text = "Merge";
            // 
            // file_1_btn
            // 
            file_1_btn.BorderColor = Color.Silver;
            file_1_btn.ButtonColor = Color.FromArgb(46, 51, 73);
            file_1_btn.FlatAppearance.BorderSize = 0;
            file_1_btn.FlatStyle = FlatStyle.Flat;
            file_1_btn.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            file_1_btn.Location = new Point(655, 474);
            file_1_btn.Name = "file_1_btn";
            file_1_btn.OnHoverBorderColor = Color.Gray;
            file_1_btn.OnHoverButtonColor = Color.MidnightBlue;
            file_1_btn.OnHoverTextColor = Color.Gray;
            file_1_btn.Size = new Size(99, 29);
            file_1_btn.TabIndex = 15;
            file_1_btn.Text = "File #1";
            file_1_btn.TextColor = Color.White;
            file_1_btn.UseVisualStyleBackColor = true;
            file_1_btn.Click += input_1Click;
            // 
            // file_2_btn
            // 
            file_2_btn.BorderColor = Color.Silver;
            file_2_btn.ButtonColor = Color.FromArgb(46, 51, 73);
            file_2_btn.FlatAppearance.BorderSize = 0;
            file_2_btn.FlatStyle = FlatStyle.Flat;
            file_2_btn.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point);
            file_2_btn.Location = new Point(655, 537);
            file_2_btn.Name = "file_2_btn";
            file_2_btn.OnHoverBorderColor = Color.Gray;
            file_2_btn.OnHoverButtonColor = Color.MidnightBlue;
            file_2_btn.OnHoverTextColor = Color.Gray;
            file_2_btn.Size = new Size(99, 27);
            file_2_btn.TabIndex = 16;
            file_2_btn.Text = "File #2";
            file_2_btn.TextColor = Color.White;
            file_2_btn.UseVisualStyleBackColor = true;
            file_2_btn.Click += input_2Click;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft JhengHei", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.InactiveBorder;
            label3.Location = new Point(321, 62);
            label3.Name = "label3";
            label3.Size = new Size(413, 31);
            label3.TabIndex = 17;
            label3.Text = "Split";
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(797, 576);
            Controls.Add(label3);
            Controls.Add(file_2_btn);
            Controls.Add(file_1_btn);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(file_2_box);
            Controls.Add(file_1_box);
            Controls.Add(clear_btn);
            Controls.Add(inputButton);
            Controls.Add(outputBox);
            Controls.Add(file_box);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion
        private Panel panel1;
        private RichTextBox file_1_box;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox file_box;
        private Button tree_btn;
        private Button raw_btn;
        private Panel panel2;
        private Button splitBtn;
        private Button mergeBtn;
        private Button_WOC inputButton;
        private RichTextBox outputBox;
        private Button_WOC clear_btn;
        private PictureBox pictureBox1;
        private RichTextBox file_2_box;
        private Label label2;
        private Button_WOC file_1_btn;
        private Button_WOC file_2_btn;
        private Label label3;
        private Button merge2;
    }
}