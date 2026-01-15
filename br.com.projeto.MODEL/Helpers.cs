using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porjeto_Controle_Vendas.br.com.projeto.MODEL
{
    public class Helpers
    {
        public void LimparTela(Form tela)
        {
            foreach (Control controlPai in tela.Controls)
            {
                foreach (Control control1 in controlPai.Controls)
                {
                    if(control1 is TabPage)
                    {
                        foreach(Control control2 in control1.Controls)
                        {
                            if (control2 is TextBox)
                            {
                                (control2 as TextBox).Text = string.Empty;
                            }
                            if (control2 is MaskedTextBox)
                            {
                                (control2 as MaskedTextBox).Text = string.Empty;
                            }
                        }
                    }
                }
            }
        }
    }
}
