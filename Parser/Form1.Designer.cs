
namespace Parser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.redraw = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tokenscheck = new System.Windows.Forms.CheckBox();
            this.FeedBack = new System.Windows.Forms.RichTextBox();
            this.Draw_tree = new System.Windows.Forms.Button();
            this.Fileloc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TokensLoc = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(206)))), ((int)(((byte)(233)))));
            this.panel1.Controls.Add(this.redraw);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.tokenscheck);
            this.panel1.Controls.Add(this.FeedBack);
            this.panel1.Controls.Add(this.Draw_tree);
            this.panel1.Controls.Add(this.Fileloc);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-15, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 814);
            this.panel1.TabIndex = 0;
            // 
            // redraw
            // 
            this.redraw.Location = new System.Drawing.Point(1079, 5);
            this.redraw.Name = "redraw";
            this.redraw.Size = new System.Drawing.Size(103, 44);
            this.redraw.TabIndex = 7;
            this.redraw.Text = "Redraw Tree";
            this.redraw.UseVisualStyleBackColor = true;
            this.redraw.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Indent = 20;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(13, 51);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1346, 611);
            this.treeView1.TabIndex = 6;
            // 
            // tokenscheck
            // 
            this.tokenscheck.AutoSize = true;
            this.tokenscheck.Enabled = false;
            this.tokenscheck.Location = new System.Drawing.Point(587, 19);
            this.tokenscheck.Name = "tokenscheck";
            this.tokenscheck.Size = new System.Drawing.Size(132, 17);
            this.tokenscheck.TabIndex = 5;
            this.tokenscheck.Text = "All Tokens Are Correct";
            this.tokenscheck.UseVisualStyleBackColor = true;
            // 
            // FeedBack
            // 
            this.FeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedBack.Location = new System.Drawing.Point(13, 662);
            this.FeedBack.Name = "FeedBack";
            this.FeedBack.ReadOnly = true;
            this.FeedBack.Size = new System.Drawing.Size(1343, 149);
            this.FeedBack.TabIndex = 4;
            this.FeedBack.Text = "";
            // 
            // Draw_tree
            // 
            this.Draw_tree.Location = new System.Drawing.Point(1188, 4);
            this.Draw_tree.Name = "Draw_tree";
            this.Draw_tree.Size = new System.Drawing.Size(108, 45);
            this.Draw_tree.TabIndex = 3;
            this.Draw_tree.Text = "Draw Parse Tree";
            this.Draw_tree.UseVisualStyleBackColor = true;
            this.Draw_tree.Click += new System.EventHandler(this.Draw_tree_Click);
            // 
            // Fileloc
            // 
            this.Fileloc.Enabled = false;
            this.Fileloc.Location = new System.Drawing.Point(27, 14);
            this.Fileloc.Name = "Fileloc";
            this.Fileloc.ReadOnly = true;
            this.Fileloc.Size = new System.Drawing.Size(444, 20);
            this.Fileloc.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Tokens File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TokensLoc
            // 
            this.TokensLoc.FileName = "TokensLoc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 805);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parser";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Fileloc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog TokensLoc;
        private System.Windows.Forms.CheckBox tokenscheck;
        private System.Windows.Forms.Button Draw_tree;
        private System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.RichTextBox FeedBack;
        private System.Windows.Forms.Button redraw;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

