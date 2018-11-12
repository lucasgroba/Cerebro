namespace EmuladorSensor
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Tipo_Sen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Latitude = new System.Windows.Forms.TextBox();
            this.Longitud = new System.Windows.Forms.TextBox();
            this.Aceleracion = new System.Windows.Forms.TextBox();
            this.Velocidad = new System.Windows.Forms.TextBox();
            this.Presion = new System.Windows.Forms.TextBox();
            this.Temperatura = new System.Windows.Forms.TextBox();
            this.AlarmaActiva = new System.Windows.Forms.ComboBox();
            this.NivelCombustible = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.IdSensor = new System.Windows.Forms.TextBox();
            this.lLatitud = new System.Windows.Forms.Label();
            this.lLongitud = new System.Windows.Forms.Label();
            this.lAceleracion = new System.Windows.Forms.Label();
            this.lVelocidad = new System.Windows.Forms.Label();
            this.lPresion = new System.Windows.Forms.Label();
            this.lTemperatura = new System.Windows.Forms.Label();
            this.lAlarmaActiva = new System.Windows.Forms.Label();
            this.lNivelCombustible = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "EMULADOR DE SENSORES";
            // 
            // Tipo_Sen
            // 
            this.Tipo_Sen.FormattingEnabled = true;
            this.Tipo_Sen.Location = new System.Drawing.Point(151, 53);
            this.Tipo_Sen.Name = "Tipo_Sen";
            this.Tipo_Sen.Size = new System.Drawing.Size(145, 21);
            this.Tipo_Sen.TabIndex = 1;
            this.Tipo_Sen.SelectedIndexChanged += new System.EventHandler(this.Tipo_Sen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "TIPO SENSOR:";
            // 
            // Latitude
            // 
            this.Latitude.Location = new System.Drawing.Point(182, 98);
            this.Latitude.Name = "Latitude";
            this.Latitude.Size = new System.Drawing.Size(145, 20);
            this.Latitude.TabIndex = 3;
            this.Latitude.Text = "-1";
            // 
            // Longitud
            // 
            this.Longitud.Location = new System.Drawing.Point(182, 124);
            this.Longitud.Name = "Longitud";
            this.Longitud.Size = new System.Drawing.Size(145, 20);
            this.Longitud.TabIndex = 4;
            this.Longitud.Text = "-1";
            // 
            // Aceleracion
            // 
            this.Aceleracion.Location = new System.Drawing.Point(182, 151);
            this.Aceleracion.Name = "Aceleracion";
            this.Aceleracion.Size = new System.Drawing.Size(145, 20);
            this.Aceleracion.TabIndex = 5;
            this.Aceleracion.Text = "-1";
            // 
            // Velocidad
            // 
            this.Velocidad.Location = new System.Drawing.Point(182, 178);
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.Size = new System.Drawing.Size(145, 20);
            this.Velocidad.TabIndex = 6;
            this.Velocidad.Text = "-1";
            // 
            // Presion
            // 
            this.Presion.Location = new System.Drawing.Point(182, 205);
            this.Presion.Name = "Presion";
            this.Presion.Size = new System.Drawing.Size(145, 20);
            this.Presion.TabIndex = 7;
            this.Presion.Text = "-1";
            // 
            // Temperatura
            // 
            this.Temperatura.Location = new System.Drawing.Point(182, 232);
            this.Temperatura.Name = "Temperatura";
            this.Temperatura.Size = new System.Drawing.Size(145, 20);
            this.Temperatura.TabIndex = 8;
            this.Temperatura.Text = "-1";
            // 
            // AlarmaActiva
            // 
            this.AlarmaActiva.FormattingEnabled = true;
            this.AlarmaActiva.Location = new System.Drawing.Point(182, 259);
            this.AlarmaActiva.Name = "AlarmaActiva";
            this.AlarmaActiva.Size = new System.Drawing.Size(145, 21);
            this.AlarmaActiva.TabIndex = 9;
            // 
            // NivelCombustible
            // 
            this.NivelCombustible.Location = new System.Drawing.Point(182, 287);
            this.NivelCombustible.Name = "NivelCombustible";
            this.NivelCombustible.Size = new System.Drawing.Size(145, 20);
            this.NivelCombustible.TabIndex = 10;
            this.NivelCombustible.Text = "-1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Emitir Lecturas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(302, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "ID_SENSOR:";
            // 
            // IdSensor
            // 
            this.IdSensor.Location = new System.Drawing.Point(426, 53);
            this.IdSensor.Name = "IdSensor";
            this.IdSensor.Size = new System.Drawing.Size(53, 20);
            this.IdSensor.TabIndex = 13;
            // 
            // lLatitud
            // 
            this.lLatitud.AutoSize = true;
            this.lLatitud.Location = new System.Drawing.Point(69, 105);
            this.lLatitud.Name = "lLatitud";
            this.lLatitud.Size = new System.Drawing.Size(42, 13);
            this.lLatitud.TabIndex = 14;
            this.lLatitud.Text = "Latitud:";
            // 
            // lLongitud
            // 
            this.lLongitud.AutoSize = true;
            this.lLongitud.Location = new System.Drawing.Point(69, 131);
            this.lLongitud.Name = "lLongitud";
            this.lLongitud.Size = new System.Drawing.Size(51, 13);
            this.lLongitud.TabIndex = 15;
            this.lLongitud.Text = "Longitud:";
            // 
            // lAceleracion
            // 
            this.lAceleracion.AutoSize = true;
            this.lAceleracion.Location = new System.Drawing.Point(69, 158);
            this.lAceleracion.Name = "lAceleracion";
            this.lAceleracion.Size = new System.Drawing.Size(66, 13);
            this.lAceleracion.TabIndex = 16;
            this.lAceleracion.Text = "Aceleracion:";
            // 
            // lVelocidad
            // 
            this.lVelocidad.AutoSize = true;
            this.lVelocidad.Location = new System.Drawing.Point(69, 185);
            this.lVelocidad.Name = "lVelocidad";
            this.lVelocidad.Size = new System.Drawing.Size(57, 13);
            this.lVelocidad.TabIndex = 17;
            this.lVelocidad.Text = "Velocidad:";
            // 
            // lPresion
            // 
            this.lPresion.AutoSize = true;
            this.lPresion.Location = new System.Drawing.Point(69, 212);
            this.lPresion.Name = "lPresion";
            this.lPresion.Size = new System.Drawing.Size(45, 13);
            this.lPresion.TabIndex = 18;
            this.lPresion.Text = "Presion:";
            // 
            // lTemperatura
            // 
            this.lTemperatura.AutoSize = true;
            this.lTemperatura.Location = new System.Drawing.Point(69, 239);
            this.lTemperatura.Name = "lTemperatura";
            this.lTemperatura.Size = new System.Drawing.Size(70, 13);
            this.lTemperatura.TabIndex = 19;
            this.lTemperatura.Text = "Temperatura:";
            // 
            // lAlarmaActiva
            // 
            this.lAlarmaActiva.AutoSize = true;
            this.lAlarmaActiva.Location = new System.Drawing.Point(69, 267);
            this.lAlarmaActiva.Name = "lAlarmaActiva";
            this.lAlarmaActiva.Size = new System.Drawing.Size(75, 13);
            this.lAlarmaActiva.TabIndex = 20;
            this.lAlarmaActiva.Text = "Alarma Activa:";
            // 
            // lNivelCombustible
            // 
            this.lNivelCombustible.AutoSize = true;
            this.lNivelCombustible.Location = new System.Drawing.Point(69, 294);
            this.lNivelCombustible.Name = "lNivelCombustible";
            this.lNivelCombustible.Size = new System.Drawing.Size(109, 13);
            this.lNivelCombustible.TabIndex = 21;
            this.lNivelCombustible.Text = "Nivel de Combustible:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 400);
            this.Controls.Add(this.lNivelCombustible);
            this.Controls.Add(this.lAlarmaActiva);
            this.Controls.Add(this.lTemperatura);
            this.Controls.Add(this.lPresion);
            this.Controls.Add(this.lVelocidad);
            this.Controls.Add(this.lAceleracion);
            this.Controls.Add(this.lLongitud);
            this.Controls.Add(this.lLatitud);
            this.Controls.Add(this.IdSensor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NivelCombustible);
            this.Controls.Add(this.AlarmaActiva);
            this.Controls.Add(this.Temperatura);
            this.Controls.Add(this.Presion);
            this.Controls.Add(this.Velocidad);
            this.Controls.Add(this.Aceleracion);
            this.Controls.Add(this.Longitud);
            this.Controls.Add(this.Latitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tipo_Sen);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Tipo_Sen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Latitude;
        private System.Windows.Forms.TextBox Longitud;
        private System.Windows.Forms.TextBox Aceleracion;
        private System.Windows.Forms.TextBox Velocidad;
        private System.Windows.Forms.TextBox Presion;
        private System.Windows.Forms.TextBox Temperatura;
        private System.Windows.Forms.ComboBox AlarmaActiva;
        private System.Windows.Forms.TextBox NivelCombustible;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IdSensor;
        private System.Windows.Forms.Label lLatitud;
        private System.Windows.Forms.Label lLongitud;
        private System.Windows.Forms.Label lAceleracion;
        private System.Windows.Forms.Label lVelocidad;
        private System.Windows.Forms.Label lPresion;
        private System.Windows.Forms.Label lTemperatura;
        private System.Windows.Forms.Label lAlarmaActiva;
        private System.Windows.Forms.Label lNivelCombustible;
    }
}

