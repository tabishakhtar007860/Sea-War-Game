
namespace gamePacOop
{
    partial class StartForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.looseLbl = new System.Windows.Forms.Label();
            this.winLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(143, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 85);
            this.button2.TabIndex = 2;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(364, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 66);
            this.label1.TabIndex = 1;
            this.label1.Text = " Sea War Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(457, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(541, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Have a Fun by playing that Game";
            // 
            // looseLbl
            // 
            this.looseLbl.AutoSize = true;
            this.looseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.looseLbl.ForeColor = System.Drawing.Color.Red;
            this.looseLbl.Location = new System.Drawing.Point(559, 326);
            this.looseLbl.Name = "looseLbl";
            this.looseLbl.Size = new System.Drawing.Size(361, 52);
            this.looseLbl.TabIndex = 4;
            this.looseLbl.Text = "Oops! You Loos.";
            this.looseLbl.Visible = false;
            // 
            // winLbl
            // 
            this.winLbl.AutoSize = true;
            this.winLbl.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLbl.ForeColor = System.Drawing.Color.Lime;
            this.winLbl.Location = new System.Drawing.Point(455, 344);
            this.winLbl.Name = "winLbl";
            this.winLbl.Size = new System.Drawing.Size(746, 51);
            this.winLbl.TabIndex = 5;
            this.winLbl.Text = "Congralution! You Won the Game.";
            this.winLbl.Visible = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1101, 562);
            this.Controls.Add(this.winLbl);
            this.Controls.Add(this.looseLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label looseLbl;
        private System.Windows.Forms.Label winLbl;
    }
}