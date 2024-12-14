namespace CLIENT___LAVAGNA
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.tela = new System.Windows.Forms.Panel();
            this.button_colore = new System.Windows.Forms.Button();
            this.button_pulisci = new System.Windows.Forms.Button();
            this.spessorePennello = new System.Windows.Forms.TrackBar();
            this.button_gomma = new System.Windows.Forms.Button();
            this.textBox_chat = new System.Windows.Forms.TextBox();
            this.listBox_chat = new System.Windows.Forms.ListBox();
            this.tela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spessorePennello)).BeginInit();
            this.SuspendLayout();
            // 
            // tela
            // 
            this.tela.Controls.Add(this.button_colore);
            this.tela.Controls.Add(this.button_pulisci);
            this.tela.Controls.Add(this.spessorePennello);
            this.tela.Controls.Add(this.button_gomma);
            this.tela.Controls.Add(this.textBox_chat);
            this.tela.Controls.Add(this.listBox_chat);
            this.tela.Location = new System.Drawing.Point(2, 1);
            this.tela.Name = "tela";
            this.tela.Size = new System.Drawing.Size(1118, 584);
            this.tela.TabIndex = 0;
            this.tela.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tela_MouseDown);
            this.tela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tela_MouseMove);
            this.tela.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tela_MouseUp);
            // 
            // button_colore
            // 
            this.button_colore.Location = new System.Drawing.Point(11, 96);
            this.button_colore.Name = "button_colore";
            this.button_colore.Size = new System.Drawing.Size(100, 23);
            this.button_colore.TabIndex = 5;
            this.button_colore.Text = "colore";
            this.button_colore.UseVisualStyleBackColor = true;
            this.button_colore.Click += new System.EventHandler(this.button_colore_Click);
            // 
            // button_pulisci
            // 
            this.button_pulisci.Location = new System.Drawing.Point(11, 54);
            this.button_pulisci.Name = "button_pulisci";
            this.button_pulisci.Size = new System.Drawing.Size(100, 23);
            this.button_pulisci.TabIndex = 4;
            this.button_pulisci.Text = "pulisci";
            this.button_pulisci.UseVisualStyleBackColor = true;
            this.button_pulisci.Click += new System.EventHandler(this.button_pulisci_Click);
            // 
            // spessorePennello
            // 
            this.spessorePennello.Location = new System.Drawing.Point(10, 515);
            this.spessorePennello.Name = "spessorePennello";
            this.spessorePennello.Size = new System.Drawing.Size(195, 56);
            this.spessorePennello.TabIndex = 3;
            this.spessorePennello.Scroll += new System.EventHandler(this.spessorePennello_Scroll);
            // 
            // button_gomma
            // 
            this.button_gomma.Location = new System.Drawing.Point(11, 12);
            this.button_gomma.Name = "button_gomma";
            this.button_gomma.Size = new System.Drawing.Size(100, 23);
            this.button_gomma.TabIndex = 2;
            this.button_gomma.Text = "gomma";
            this.button_gomma.UseVisualStyleBackColor = true;
            this.button_gomma.Click += new System.EventHandler(this.button_gomma_Click);
            // 
            // textBox_chat
            // 
            this.textBox_chat.Location = new System.Drawing.Point(889, 470);
            this.textBox_chat.Name = "textBox_chat";
            this.textBox_chat.Size = new System.Drawing.Size(216, 22);
            this.textBox_chat.TabIndex = 1;
            // 
            // listBox_chat
            // 
            this.listBox_chat.FormattingEnabled = true;
            this.listBox_chat.ItemHeight = 16;
            this.listBox_chat.Location = new System.Drawing.Point(889, 11);
            this.listBox_chat.Name = "listBox_chat";
            this.listBox_chat.Size = new System.Drawing.Size(216, 452);
            this.listBox_chat.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 586);
            this.Controls.Add(this.tela);
            this.Name = "Form1";
            this.Text = "premi \"m\" per mostrare il menù";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tela.ResumeLayout(false);
            this.tela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spessorePennello)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tela;
        private System.Windows.Forms.Button button_gomma;
        private System.Windows.Forms.TextBox textBox_chat;
        private System.Windows.Forms.ListBox listBox_chat;
        private System.Windows.Forms.Button button_colore;
        private System.Windows.Forms.Button button_pulisci;
        private System.Windows.Forms.TrackBar spessorePennello;
    }
}

