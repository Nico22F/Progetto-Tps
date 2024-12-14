namespace CLIENT___LAVAGNA
{
    partial class menu
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
            this.label_nome = new System.Windows.Forms.Label();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.button_accedi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_nome
            // 
            this.label_nome.AutoSize = true;
            this.label_nome.Location = new System.Drawing.Point(380, 104);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(187, 16);
            this.label_nome.TabIndex = 0;
            this.label_nome.Text = "INSERISCI IL NOME UTENTE";
            // 
            // textBox_nome
            // 
            this.textBox_nome.Location = new System.Drawing.Point(287, 144);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(347, 22);
            this.textBox_nome.TabIndex = 1;
            // 
            // button_accedi
            // 
            this.button_accedi.Location = new System.Drawing.Point(399, 195);
            this.button_accedi.Name = "button_accedi";
            this.button_accedi.Size = new System.Drawing.Size(150, 23);
            this.button_accedi.TabIndex = 2;
            this.button_accedi.Text = "ACCEDI";
            this.button_accedi.UseVisualStyleBackColor = true;
            this.button_accedi.Click += new System.EventHandler(this.button_accedi_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 564);
            this.Controls.Add(this.button_accedi);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.label_nome);
            this.Name = "menu";
            this.Text = "menu";
            this.Load += new System.EventHandler(this.menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.Button button_accedi;
    }
}