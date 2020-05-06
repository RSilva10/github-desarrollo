using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFlrClient
{
    public partial class frm_Utilerias : Form
    {
        public frm_Utilerias()
        {
            InitializeComponent();
        }

        private void mnu_Cif_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
            this.pnl_Cifrar.Enabled = true;
            this.pnl_Descifrar.Enabled = false;
            this.txt_Texto.Focus();
        }

        private void frm_Utilerias_Load(object sender, EventArgs e)
        {
            this.pnl_Cifrar.Enabled = false;
            this.pnl_Descifrar.Enabled = false;
        }

        private void mnu_Des_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
            this.pnl_Cifrar.Enabled = false;
            this.pnl_Descifrar.Enabled = true;
            this.txt_Texto2.Focus();
        }

        private void btn_Cifrar_Click(object sender, EventArgs e)
        {
            if (this.txt_Texto.Text.Trim() == "") 
            {
                MessageBox.Show("Proporcione el texto a cifrar", "Cifrado", MessageBoxButtons.OK);
                this.txt_Texto.Focus();
                return;
            }

            this.txt_Cifrado.Text = encripta_Password(this.txt_Texto.Text.Trim()); 
        }

        private void btn_Descifrar_Click(object sender, EventArgs e)
        {
            if (this.txt_Texto2.Text.Trim() == "")
            {
                MessageBox.Show("Proporcione el texto a descifrar", "Descifrado", MessageBoxButtons.OK);
                this.txt_Texto2.Focus();
                return;
            }

            this.txt_Descifrar.Text = desencripta_Password(this.txt_Texto2.Text.Trim());
        }

        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        private void Limpiar_Campos() 
        {
            this.txt_Texto.Text = "";
            this.txt_Cifrado.Text = "";
            this.txt_Texto2.Text = "";
            this.txt_Descifrar.Text = "";
        }

        /// <summary>
        /// Encripta la contraseña del usuario 
        /// </summary>
        /// <returns></returns>
        private String encripta_Password(string _pasword)
        {
            string _Resultado = string.Empty;

            byte[] _Encriptado = Encoding.Unicode.GetBytes(_pasword);
            _Resultado = Convert.ToBase64String(_Encriptado);

            return _Resultado;
        }

        /// <summary>
        /// Desencripta la contraseña del usuario 
        /// </summary>
        /// <returns></returns>
        private String desencripta_Password(string _pasword)
        {
            string _Resultado = string.Empty;

            byte[] _Desencriptado = Convert.FromBase64String(_pasword);
            _Resultado = Encoding.Unicode.GetString(_Desencriptado);

            return _Resultado;
        }
    }
}
