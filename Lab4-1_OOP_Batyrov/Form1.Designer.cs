
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
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // colorBut
            // 
            this.colorBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.color;
            this.colorBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorBut.Location = new System.Drawing.Point(719, 313);
            this.colorBut.Name = "colorBut";
            this.colorBut.Size = new System.Drawing.Size(70, 68);
            this.colorBut.TabIndex = 5;
            this.colorBut.UseVisualStyleBackColor = true;
            // 
            // cursorBut
            // 
            this.cursorBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.cursor_size;
            this.cursorBut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cursorBut.Location = new System.Drawing.Point(731, 12);
            this.cursorBut.Name = "cursorBut";
            this.cursorBut.Size = new System.Drawing.Size(48, 71);
            this.cursorBut.TabIndex = 1;
            this.cursorBut.UseVisualStyleBackColor = true;
            this.cursorBut.Click += new System.EventHandler(this.cursorBut_Click);
            // 
            // rectangleBut
            // 
            this.rectangleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.rectangle_size;
            this.rectangleBut.Location = new System.Drawing.Point(719, 176);
            this.rectangleBut.Name = "rectangleBut";
            this.rectangleBut.Size = new System.Drawing.Size(70, 46);
            this.rectangleBut.TabIndex = 3;
            this.rectangleBut.UseVisualStyleBackColor = true;
            this.rectangleBut.Click += new System.EventHandler(this.rectangleBut_Click);
            // 
            // triangleBut
            // 
            this.triangleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.triangle_size;
            this.triangleBut.Location = new System.Drawing.Point(719, 228);
            this.triangleBut.Name = "triangleBut";
            this.triangleBut.Size = new System.Drawing.Size(70, 54);
            this.triangleBut.TabIndex = 4;
            this.triangleBut.UseVisualStyleBackColor = true;
            this.triangleBut.Click += new System.EventHandler(this.triangleBut_Click);
            // 
            // circleBut
            // 
            this.circleBut.BackgroundImage = global::Lab4_1_OOP_Batyrov.Properties.Resources.cirlce_size;
            this.circleBut.Location = new System.Drawing.Point(719, 100);
            this.circleBut.Name = "circleBut";
            this.circleBut.Size = new System.Drawing.Size(70, 70);
            this.circleBut.TabIndex = 2;
            this.circleBut.UseVisualStyleBackColor = true;
            this.circleBut.Click += new System.EventHandler(this.circleBut_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sheet.Location = new System.Drawing.Point(12, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(701, 426);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(716, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сменить цвет";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

