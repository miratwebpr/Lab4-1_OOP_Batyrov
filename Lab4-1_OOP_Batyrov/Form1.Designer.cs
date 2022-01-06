
namespace Lab4_1_OOP_Batyrov
{
    partial class Form1
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorBut = new System.Windows.Forms.Button();
            this.cursorBut = new System.Windows.Forms.Button();
            this.rectangleBut = new System.Windows.Forms.Button();
            this.triangleBut = new System.Windows.Forms.Button();
            this.circleBut = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBut = new System.Windows.Forms.Button();
            this.unGroupBut = new System.Windows.Forms.Button();
            this.delAllBut = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // colorBut
            // 
            this.colorBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.color;
            this.colorBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorBut.Location = new System.Drawing.Point(719, 269);
            this.colorBut.Name = "colorBut";
            this.colorBut.Size = new System.Drawing.Size(70, 68);
            this.colorBut.TabIndex = 5;
            this.colorBut.UseVisualStyleBackColor = true;
            this.colorBut.Click += new System.EventHandler(this.colorBut_Click);
            // 
            // cursorBut
            // 
            this.cursorBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.cursor_size;
            this.cursorBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cursorBut.Location = new System.Drawing.Point(731, 4);
            this.cursorBut.Name = "cursorBut";
            this.cursorBut.Size = new System.Drawing.Size(48, 61);
            this.cursorBut.TabIndex = 1;
            this.cursorBut.UseVisualStyleBackColor = true;
            this.cursorBut.Click += new System.EventHandler(this.cursorBut_Click);
            // 
            // rectangleBut
            // 
            this.rectangleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.rectangle_size;
            this.rectangleBut.Location = new System.Drawing.Point(719, 142);
            this.rectangleBut.Name = "rectangleBut";
            this.rectangleBut.Size = new System.Drawing.Size(70, 46);
            this.rectangleBut.TabIndex = 3;
            this.rectangleBut.UseVisualStyleBackColor = true;
            this.rectangleBut.Click += new System.EventHandler(this.rectangleBut_Click);
            // 
            // triangleBut
            // 
            this.triangleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.triangle_size;
            this.triangleBut.Location = new System.Drawing.Point(719, 195);
            this.triangleBut.Name = "triangleBut";
            this.triangleBut.Size = new System.Drawing.Size(70, 54);
            this.triangleBut.TabIndex = 4;
            this.triangleBut.UseVisualStyleBackColor = true;
            this.triangleBut.Click += new System.EventHandler(this.triangleBut_Click);
            // 
            // circleBut
            // 
            this.circleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.cirlce_size;
            this.circleBut.Location = new System.Drawing.Point(719, 71);
            this.circleBut.Name = "circleBut";
            this.circleBut.Size = new System.Drawing.Size(70, 65);
            this.circleBut.TabIndex = 2;
            this.circleBut.UseVisualStyleBackColor = true;
            this.circleBut.Click += new System.EventHandler(this.circleBut_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sheet.Location = new System.Drawing.Point(212, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(501, 426);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(716, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сменить цвет";
            // 
            // groupBut
            // 
            this.groupBut.Enabled = false;
            this.groupBut.Location = new System.Drawing.Point(719, 344);
            this.groupBut.Name = "groupBut";
            this.groupBut.Size = new System.Drawing.Size(75, 49);
            this.groupBut.TabIndex = 7;
            this.groupBut.Text = "Создать группу";
            this.groupBut.UseVisualStyleBackColor = true;
            this.groupBut.Click += new System.EventHandler(this.groupBut_Click);
            // 
            // unGroupBut
            // 
            this.unGroupBut.Enabled = false;
            this.unGroupBut.Location = new System.Drawing.Point(719, 399);
            this.unGroupBut.Name = "unGroupBut";
            this.unGroupBut.Size = new System.Drawing.Size(75, 49);
            this.unGroupBut.TabIndex = 8;
            this.unGroupBut.Text = "Разгруппировать";
            this.unGroupBut.UseVisualStyleBackColor = true;
            this.unGroupBut.Click += new System.EventHandler(this.unGroupBut_Click);
            // 
            // delAllBut
            // 
            this.delAllBut.Location = new System.Drawing.Point(295, 442);
            this.delAllBut.Name = "delAllBut";
            this.delAllBut.Size = new System.Drawing.Size(411, 10);
            this.delAllBut.TabIndex = 9;
            this.delAllBut.Text = "button1";
            this.delAllBut.UseVisualStyleBackColor = true;
            this.delAllBut.Click += new System.EventHandler(this.delAllBut_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(194, 426);
            this.treeView1.TabIndex = 10;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Удалить все->";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.delAllBut);
            this.Controls.Add(this.unGroupBut);
            this.Controls.Add(this.groupBut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorBut);
            this.Controls.Add(this.cursorBut);
            this.Controls.Add(this.rectangleBut);
            this.Controls.Add(this.triangleBut);
            this.Controls.Add(this.circleBut);
            this.Controls.Add(this.sheet);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Visual Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button circleBut;
        private System.Windows.Forms.Button triangleBut;
        private System.Windows.Forms.Button rectangleBut;
        private System.Windows.Forms.Button cursorBut;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button groupBut;
        private System.Windows.Forms.Button unGroupBut;
        private System.Windows.Forms.Button delAllBut;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
    }
}

