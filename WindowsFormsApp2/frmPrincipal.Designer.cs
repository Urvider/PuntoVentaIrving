namespace WindowsFormsApp2
{
    partial class frmPrincipal
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
            this.btEmpleados = new System.Windows.Forms.Button();
            this.btClientes = new System.Windows.Forms.Button();
            this.btProducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btEmpleados
            // 
            this.btEmpleados.Location = new System.Drawing.Point(97, 167);
            this.btEmpleados.Name = "btEmpleados";
            this.btEmpleados.Size = new System.Drawing.Size(75, 23);
            this.btEmpleados.TabIndex = 0;
            this.btEmpleados.Text = "Empleados";
            this.btEmpleados.UseVisualStyleBackColor = true;
            this.btEmpleados.Click += new System.EventHandler(this.btEmpleados_Click);
            // 
            // btClientes
            // 
            this.btClientes.Location = new System.Drawing.Point(209, 167);
            this.btClientes.Name = "btClientes";
            this.btClientes.Size = new System.Drawing.Size(75, 23);
            this.btClientes.TabIndex = 1;
            this.btClientes.Text = "Clientes";
            this.btClientes.UseVisualStyleBackColor = true;
            this.btClientes.Click += new System.EventHandler(this.btClientes_Click);
            // 
            // btProducto
            // 
            this.btProducto.Location = new System.Drawing.Point(348, 167);
            this.btProducto.Name = "btProducto";
            this.btProducto.Size = new System.Drawing.Size(75, 23);
            this.btProducto.TabIndex = 2;
            this.btProducto.Text = "Producto";
            this.btProducto.UseVisualStyleBackColor = true;
            this.btProducto.Click += new System.EventHandler(this.btProducto_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(532, 450);
            this.Controls.Add(this.btProducto);
            this.Controls.Add(this.btClientes);
            this.Controls.Add(this.btEmpleados);
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEmpleados;
        private System.Windows.Forms.Button btClientes;
        private System.Windows.Forms.Button btProducto;
    }
}