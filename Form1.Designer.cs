﻿namespace Clock
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
            this.clock = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clock)).BeginInit();
            this.SuspendLayout();
            // 
            // clock
            // 
            this.clock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clock.Location = new System.Drawing.Point(0, 0);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(800, 450);
            this.clock.TabIndex = 0;
            this.clock.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "SOZLASH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clock);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox clock;
        private System.Windows.Forms.Button button1;
    }
}

