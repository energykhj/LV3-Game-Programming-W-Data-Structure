namespace HKAssignment2
{
    partial class DesignForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.btnBox = new System.Windows.Forms.Button();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.btnGoal = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnHero = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rows:";
            // 
            // txtRows
            // 
            this.txtRows.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRows.Location = new System.Drawing.Point(156, 27);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(224, 32);
            this.txtRows.TabIndex = 1;
            this.txtRows.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Columns:";
            // 
            // txtCols
            // 
            this.txtCols.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCols.Location = new System.Drawing.Point(558, 27);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(224, 32);
            this.txtCols.TabIndex = 2;
            this.txtCols.Text = "5";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(821, 23);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(178, 41);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(365, 163);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(650, 539);
            this.Panel.TabIndex = 6;
            // 
            // btnBox
            // 
            this.btnBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBox.ImageIndex = 3;
            this.btnBox.ImageList = this.iconList;
            this.btnBox.Location = new System.Drawing.Point(18, 312);
            this.btnBox.Name = "btnBox";
            this.btnBox.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.btnBox.Size = new System.Drawing.Size(245, 65);
            this.btnBox.TabIndex = 7;
            this.btnBox.Text = "&Box";
            this.btnBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBox.UseVisualStyleBackColor = true;
            this.btnBox.Click += new System.EventHandler(this.BtnBox_Click);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "none.PNG");
            this.iconList.Images.SetKeyName(1, "hero.png");
            this.iconList.Images.SetKeyName(2, "wall.png");
            this.iconList.Images.SetKeyName(3, "box.png");
            this.iconList.Images.SetKeyName(4, "goal.png");
            // 
            // btnGoal
            // 
            this.btnGoal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoal.ImageIndex = 4;
            this.btnGoal.ImageList = this.iconList;
            this.btnGoal.Location = new System.Drawing.Point(18, 400);
            this.btnGoal.Name = "btnGoal";
            this.btnGoal.Size = new System.Drawing.Size(245, 65);
            this.btnGoal.TabIndex = 8;
            this.btnGoal.Text = "&Destination";
            this.btnGoal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoal.UseVisualStyleBackColor = true;
            this.btnGoal.Click += new System.EventHandler(this.BtnGoal_Click);
            // 
            // btnNone
            // 
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.ImageIndex = 0;
            this.btnNone.ImageList = this.iconList;
            this.btnNone.Location = new System.Drawing.Point(18, 48);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(245, 65);
            this.btnNone.TabIndex = 4;
            this.btnNone.Text = "&None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.BtnNone_Click);
            // 
            // btnWall
            // 
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.ImageIndex = 2;
            this.btnWall.ImageList = this.iconList;
            this.btnWall.Location = new System.Drawing.Point(18, 224);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(245, 65);
            this.btnWall.TabIndex = 6;
            this.btnWall.Text = "&Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.BtnWall_Click);
            // 
            // btnHero
            // 
            this.btnHero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHero.ImageIndex = 1;
            this.btnHero.ImageList = this.iconList;
            this.btnHero.Location = new System.Drawing.Point(18, 136);
            this.btnHero.Name = "btnHero";
            this.btnHero.Size = new System.Drawing.Size(245, 65);
            this.btnHero.TabIndex = 5;
            this.btnHero.Text = "&Hero";
            this.btnHero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHero.UseVisualStyleBackColor = true;
            this.btnHero.Click += new System.EventHandler(this.BtnHero_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBox);
            this.groupBox1.Controls.Add(this.btnGoal);
            this.groupBox1.Controls.Add(this.btnNone);
            this.groupBox1.Controls.Add(this.btnWall);
            this.groupBox1.Controls.Add(this.btnHero);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(45, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 539);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ToolBox";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenerate);
            this.groupBox2.Controls.Add(this.txtCols);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtRows);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(45, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1010, 78);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "by Heuijin Ko";
            // 
            // DesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 744);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DesignForm";
            this.Text = "Design Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button btnHero;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button btnGoal;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
    }
}