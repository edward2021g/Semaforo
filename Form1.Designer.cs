
namespace Semaforo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pct_semaforo1 = new System.Windows.Forms.PictureBox();
            this.pct_semaforo2 = new System.Windows.Forms.PictureBox();
            this.pct_semaforo3 = new System.Windows.Forms.PictureBox();
            this.pct_semaforo4 = new System.Windows.Forms.PictureBox();
            this.grp_Operaciones = new System.Windows.Forms.GroupBox();
            this.btn_Preventivas = new System.Windows.Forms.Button();
            this.btn_apagar = new System.Windows.Forms.Button();
            this.btn_parar = new System.Windows.Forms.Button();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.timer_verde = new System.Windows.Forms.Timer(this.components);
            this.lbl_contador = new System.Windows.Forms.Label();
            this.timer_preventivas = new System.Windows.Forms.Timer(this.components);
            this.timer_verde_parpadeante = new System.Windows.Forms.Timer(this.components);
            this.timer_amarillo = new System.Windows.Forms.Timer(this.components);
            this.timer_rojo = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pct_vehiculo1 = new System.Windows.Forms.PictureBox();
            this.pct_vehiculo2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo4)).BeginInit();
            this.grp_Operaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_vehiculo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_vehiculo2)).BeginInit();
            this.SuspendLayout();
            // 
            // pct_semaforo1
            // 
            this.pct_semaforo1.BackColor = System.Drawing.Color.Transparent;
            this.pct_semaforo1.Image = global::Semaforo.Properties.Resources.apagado;
            this.pct_semaforo1.Location = new System.Drawing.Point(632, 27);
            this.pct_semaforo1.Name = "pct_semaforo1";
            this.pct_semaforo1.Size = new System.Drawing.Size(54, 80);
            this.pct_semaforo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pct_semaforo1.TabIndex = 0;
            this.pct_semaforo1.TabStop = false;
            // 
            // pct_semaforo2
            // 
            this.pct_semaforo2.BackColor = System.Drawing.Color.Transparent;
            this.pct_semaforo2.Image = global::Semaforo.Properties.Resources.apagado;
            this.pct_semaforo2.Location = new System.Drawing.Point(393, 408);
            this.pct_semaforo2.Name = "pct_semaforo2";
            this.pct_semaforo2.Size = new System.Drawing.Size(80, 80);
            this.pct_semaforo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pct_semaforo2.TabIndex = 1;
            this.pct_semaforo2.TabStop = false;
            // 
            // pct_semaforo3
            // 
            this.pct_semaforo3.BackColor = System.Drawing.Color.Transparent;
            this.pct_semaforo3.Image = global::Semaforo.Properties.Resources.apagado;
            this.pct_semaforo3.Location = new System.Drawing.Point(680, 335);
            this.pct_semaforo3.Name = "pct_semaforo3";
            this.pct_semaforo3.Size = new System.Drawing.Size(80, 80);
            this.pct_semaforo3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pct_semaforo3.TabIndex = 2;
            this.pct_semaforo3.TabStop = false;
            // 
            // pct_semaforo4
            // 
            this.pct_semaforo4.BackColor = System.Drawing.Color.Transparent;
            this.pct_semaforo4.Image = global::Semaforo.Properties.Resources.apagado;
            this.pct_semaforo4.Location = new System.Drawing.Point(315, 106);
            this.pct_semaforo4.Name = "pct_semaforo4";
            this.pct_semaforo4.Size = new System.Drawing.Size(80, 80);
            this.pct_semaforo4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pct_semaforo4.TabIndex = 3;
            this.pct_semaforo4.TabStop = false;
            // 
            // grp_Operaciones
            // 
            this.grp_Operaciones.BackColor = System.Drawing.Color.Transparent;
            this.grp_Operaciones.Controls.Add(this.btn_Preventivas);
            this.grp_Operaciones.Controls.Add(this.btn_apagar);
            this.grp_Operaciones.Controls.Add(this.btn_parar);
            this.grp_Operaciones.Controls.Add(this.btn_iniciar);
            this.grp_Operaciones.ForeColor = System.Drawing.Color.Black;
            this.grp_Operaciones.Location = new System.Drawing.Point(761, 421);
            this.grp_Operaciones.Name = "grp_Operaciones";
            this.grp_Operaciones.Size = new System.Drawing.Size(251, 152);
            this.grp_Operaciones.TabIndex = 4;
            this.grp_Operaciones.TabStop = false;
            this.grp_Operaciones.Text = "Operaciones";
            // 
            // btn_Preventivas
            // 
            this.btn_Preventivas.BackColor = System.Drawing.Color.Silver;
            this.btn_Preventivas.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Preventivas.ForeColor = System.Drawing.Color.Black;
            this.btn_Preventivas.Location = new System.Drawing.Point(116, 88);
            this.btn_Preventivas.Name = "btn_Preventivas";
            this.btn_Preventivas.Size = new System.Drawing.Size(109, 44);
            this.btn_Preventivas.TabIndex = 3;
            this.btn_Preventivas.Text = "PREVENTIVAS";
            this.btn_Preventivas.UseVisualStyleBackColor = false;
            this.btn_Preventivas.Click += new System.EventHandler(this.btn_Preventivas_Click);
            // 
            // btn_apagar
            // 
            this.btn_apagar.BackColor = System.Drawing.Color.Silver;
            this.btn_apagar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_apagar.ForeColor = System.Drawing.Color.Black;
            this.btn_apagar.Location = new System.Drawing.Point(24, 88);
            this.btn_apagar.Name = "btn_apagar";
            this.btn_apagar.Size = new System.Drawing.Size(76, 44);
            this.btn_apagar.TabIndex = 2;
            this.btn_apagar.Text = "APAGAR";
            this.btn_apagar.UseVisualStyleBackColor = false;
            this.btn_apagar.Click += new System.EventHandler(this.btn_apagar_Click);
            // 
            // btn_parar
            // 
            this.btn_parar.BackColor = System.Drawing.Color.Silver;
            this.btn_parar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_parar.ForeColor = System.Drawing.Color.Black;
            this.btn_parar.Location = new System.Drawing.Point(126, 38);
            this.btn_parar.Name = "btn_parar";
            this.btn_parar.Size = new System.Drawing.Size(90, 44);
            this.btn_parar.TabIndex = 1;
            this.btn_parar.Text = "PARAR";
            this.btn_parar.UseVisualStyleBackColor = false;
            this.btn_parar.Click += new System.EventHandler(this.btn_parar_Click);
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.BackColor = System.Drawing.Color.Silver;
            this.btn_iniciar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iniciar.ForeColor = System.Drawing.Color.Black;
            this.btn_iniciar.Location = new System.Drawing.Point(24, 38);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(77, 44);
            this.btn_iniciar.TabIndex = 0;
            this.btn_iniciar.Text = "INICIAR";
            this.btn_iniciar.UseVisualStyleBackColor = false;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // timer_verde
            // 
            this.timer_verde.Interval = 500;
            this.timer_verde.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_contador
            // 
            this.lbl_contador.AutoSize = true;
            this.lbl_contador.BackColor = System.Drawing.Color.Transparent;
            this.lbl_contador.Font = new System.Drawing.Font("DS-Digital", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_contador.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbl_contador.Location = new System.Drawing.Point(476, 214);
            this.lbl_contador.MinimumSize = new System.Drawing.Size(130, 90);
            this.lbl_contador.Name = "lbl_contador";
            this.lbl_contador.Size = new System.Drawing.Size(130, 95);
            this.lbl_contador.TabIndex = 5;
            this.lbl_contador.Text = "0";
            this.lbl_contador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_preventivas
            // 
            this.timer_preventivas.Interval = 500;
            this.timer_preventivas.Tick += new System.EventHandler(this.timer_preventivas_Tick);
            // 
            // timer_verde_parpadeante
            // 
            this.timer_verde_parpadeante.Interval = 500;
            this.timer_verde_parpadeante.Tick += new System.EventHandler(this.timer_verde_parpadeante_Tick);
            // 
            // timer_amarillo
            // 
            this.timer_amarillo.Interval = 500;
            this.timer_amarillo.Tick += new System.EventHandler(this.timer_amarillo_Tick);
            // 
            // timer_rojo
            // 
            this.timer_rojo.Interval = 500;
            this.timer_rojo.Tick += new System.EventHandler(this.timer_rojo_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pct_vehiculo1
            // 
            this.pct_vehiculo1.BackColor = System.Drawing.Color.Transparent;
            this.pct_vehiculo1.Image = ((System.Drawing.Image)(resources.GetObject("pct_vehiculo1.Image")));
            this.pct_vehiculo1.Location = new System.Drawing.Point(594, 575);
            this.pct_vehiculo1.Name = "pct_vehiculo1";
            this.pct_vehiculo1.Size = new System.Drawing.Size(36, 90);
            this.pct_vehiculo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pct_vehiculo1.TabIndex = 7;
            this.pct_vehiculo1.TabStop = false;
            // 
            // pct_vehiculo2
            // 
            this.pct_vehiculo2.BackColor = System.Drawing.Color.Transparent;
            this.pct_vehiculo2.Image = ((System.Drawing.Image)(resources.GetObject("pct_vehiculo2.Image")));
            this.pct_vehiculo2.Location = new System.Drawing.Point(328, 177);
            this.pct_vehiculo2.Name = "pct_vehiculo2";
            this.pct_vehiculo2.Size = new System.Drawing.Size(36, 90);
            this.pct_vehiculo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pct_vehiculo2.TabIndex = 8;
            this.pct_vehiculo2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1072, 578);
            this.Controls.Add(this.pct_vehiculo2);
            this.Controls.Add(this.pct_semaforo1);
            this.Controls.Add(this.pct_vehiculo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grp_Operaciones);
            this.Controls.Add(this.pct_semaforo4);
            this.Controls.Add(this.pct_semaforo3);
            this.Controls.Add(this.pct_semaforo2);
            this.Controls.Add(this.lbl_contador);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Semaforo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_semaforo4)).EndInit();
            this.grp_Operaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_vehiculo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_vehiculo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pct_semaforo1;
        private System.Windows.Forms.PictureBox pct_semaforo2;
        private System.Windows.Forms.PictureBox pct_semaforo3;
        private System.Windows.Forms.PictureBox pct_semaforo4;
        private System.Windows.Forms.GroupBox grp_Operaciones;
        private System.Windows.Forms.Button btn_apagar;
        private System.Windows.Forms.Button btn_parar;
        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.Timer timer_verde;
        private System.Windows.Forms.Label lbl_contador;
        private System.Windows.Forms.Button btn_Preventivas;
        private System.Windows.Forms.Timer timer_preventivas;
        private System.Windows.Forms.Timer timer_verde_parpadeante;
        private System.Windows.Forms.Timer timer_amarillo;
        private System.Windows.Forms.Timer timer_rojo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pct_vehiculo1;
        private System.Windows.Forms.PictureBox pct_vehiculo2;
    }
}

