using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class PromptDialogEditor
    {
        public bool ShowDialog(string labelText, string Header,string confirmButtonText,string cancelButtonText)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = Header,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = labelText, AutoSize=true };
            Button confirmation = new Button() { Text = confirmButtonText, Left = 100, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = cancelButtonText, Left = 300, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(cancel);
            prompt.CancelButton = cancel;
            prompt.AcceptButton = confirmation;
            if (prompt.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }
    }
}
