
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
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // colorBut
            // 
            this.colorBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.color;
            this.colorBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorBut.Location = new System.Drawing.Point(1078, 414);
            this.colorBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.colorBut.Name = "colorBut";
            this.colorBut.Size = new System.Drawing.Size(105, 105);
            this.colorBut.TabIndex = 5;
            this.colorBut.UseVisualStyleBackColor = true;
            this.colorBut.Click += new System.EventHandler(this.colorBut_Click);
            // 
            // cursorBut
            // 
            this.cursorBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.cursor_size;
            this.cursorBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cursorBut.Location = new System.Drawing.Point(1096, 18);
            this.cursorBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cursorBut.Name = "cursorBut";
            this.cursorBut.Size = new System.Drawing.Size(72, 94);
            this.cursorBut.TabIndex = 1;
            this.cursorBut.UseVisualStyleBackColor = true;
            this.cursorBut.Click += new System.EventHandler(this.cursorBut_Click);
            // 
            // rectangleBut
            // 
            this.rectangleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.rectangle_size;
            this.rectangleBut.Location = new System.Drawing.Point(1078, 219);
            this.rectangleBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rectangleBut.Name = "rectangleBut";
            this.rectangleBut.Size = new System.Drawing.Size(105, 71);
            this.rectangleBut.TabIndex = 3;
            this.rectangleBut.UseVisualStyleBackColor = true;
            this.rectangleBut.Click += new System.EventHandler(this.rectangleBut_Click);
            // 
            // triangleBut
            // 
            this.triangleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.triangle_size;
            this.triangleBut.Location = new System.Drawing.Point(1078, 300);
            this.triangleBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.triangleBut.Name = "triangleBut";
            this.triangleBut.Size = new System.Drawing.Size(105, 83);
            this.triangleBut.TabIndex = 4;
            this.triangleBut.UseVisualStyleBackColor = true;
            this.triangleBut.Click += new System.EventHandler(this.triangleBut_Click);
            // 
            // circleBut
            // 
            this.circleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.cirlce_size;
            this.circleBut.Location = new System.Drawing.Point(1078, 122);
            this.circleBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.circleBut.Name = "circleBut";
            this.circleBut.Size = new System.Drawing.Size(105, 78);
            this.circleBut.TabIndex = 2;
            this.circleBut.UseVisualStyleBackColor = true;
            this.circleBut.Click += new System.EventHandler(this.circleBut_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sheet.Location = new System.Drawing.Point(18, 18);
            this.sheet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(1050, 654);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1074, 389);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сменить цвет";
            // 
            // groupBut
            // 
            this.groupBut.Enabled = false;
            this.groupBut.Location = new System.Drawing.Point(1078, 529);
            this.groupBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBut.Name = "groupBut";
            this.groupBut.Size = new System.Drawing.Size(112, 75);
            this.groupBut.TabIndex = 7;
            this.groupBut.Text = "Создать группу";
            this.groupBut.UseVisualStyleBackColor = true;
            this.groupBut.Click += new System.EventHandler(this.groupBut_Click);
            // 
            // unGroupBut
            // 
            this.unGroupBut.Enabled = false;
            this.unGroupBut.Location = new System.Drawing.Point(1078, 614);
            this.unGroupBut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unGroupBut.Name = "unGroupBut";
            this.unGroupBut.Size = new System.Drawing.Size(112, 75);
            this.unGroupBut.TabIndex = 8;
            this.unGroupBut.Text = "Разгруппировать";
            this.unGroupBut.UseVisualStyleBackColor = true;
            this.unGroupBut.Click += new System.EventHandler(this.unGroupBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}

