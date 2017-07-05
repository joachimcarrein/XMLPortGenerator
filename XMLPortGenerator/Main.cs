using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLPortGenerator
{
    public partial class Main : Form
    {

        #region Form Code & Events
        public Main()
        {
            InitializeComponent();
        }
        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            GenerateXMLPort();
        }
        private void txtFields_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessHotkeys(sender, e);
        }
        private void txtXMLPort_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessHotkeys(sender, e);
        }
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }
        #endregion

        #region Functions
        private void SaveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.CheckPathExists = true;
            sfd.DefaultExt = ".txt";
            sfd.Filter = "Text Files (*.txt)|*.TXT|All Files (*.*)|*.*";


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(sfd.FileName);
                tw.WriteLine(txtXMLPort.Text);
                tw.Close();
                MessageBox.Show("Saved to " + sfd.FileName, "Saved XMLPort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GenerateXMLPort()
        {
            if (txtSeparator.Text.Equals(";"))
                txtSeparator.Text = "[;]";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("OBJECT XMLport " + nudXMLPortNo.Value + " IMPORT " + txtSourceTableName.Text);
            sb.AppendLine("{");
            sb.AppendLine("  OBJECT-PROPERTIES");
            sb.AppendLine("  {");
            sb.AppendLine("    Date=;");
            sb.AppendLine("    Time=;");
            sb.AppendLine("    Modified=Yes;");
            sb.AppendLine("    Version List=;");
            sb.AppendLine("  }");
            sb.AppendLine("  PROPERTIES");
            sb.AppendLine("  {");
            sb.AppendLine("    Direction=Import;");
            sb.AppendLine("    Format=Variable Text;");
            if (txtDelimiter.Text != "")
                sb.AppendLine("    FieldDelimiter=" + txtDelimiter.Text + ";");
            if (txtSeparator.Text != "")
                sb.AppendLine("    FieldSeparator=" + txtSeparator.Text + ";");
            sb.AppendLine("  }");
            sb.AppendLine("  ELEMENTS");
            sb.AppendLine("  {");

            sb.AppendLine("    { [" + GenerateGuid() + "];0 ;root                ;Element ;Text     }");
            sb.AppendLine("");
            sb.AppendLine("    { [" + GenerateGuid() + "];1 ;source              ;Element ;Table   ;");
            sb.AppendLine("                                                  SourceTable=Table" + nudSourceTableNo.Value + " }");

            bool FieldsStarted = false;
            // loop fields
            foreach (string line in txtFields.Lines)
            {
                if ((FieldsStarted) && (line.StartsWith("    {")))
                {
                    if (!(line.ToUpper().Contains("FLOW") || line.ToUpper().Contains("BLOB")))
                    {
                        string[] Values = line.Split(';');

                        sb.AppendLine("    { [" + GenerateGuid() + "];2 ;" + Values[2].PrepareForXMLField() + ";Element ;Field   ;");
                        sb.AppendLine("                                                  DataType=" + new string(Values[3].Where(c => c > 'A' && c < 'z').ToArray()) + ";");
                        sb.AppendLine("                                                  SourceField=" + txtSourceTableName.Text + "::" + Values[2].TrimEnd() + " }");
                    }
                }
                if (line.Equals("  FIELDS"))
                {
                    FieldsStarted = true;
                }
                if (line.Equals("  }"))
                {
                    FieldsStarted = false;
                }
            }

            sb.AppendLine("  }");
            sb.AppendLine("  EVENTS");
            sb.AppendLine("  {");
            sb.AppendLine("  }");
            sb.AppendLine("  REQUESTPAGE");
            sb.AppendLine("  {");
            sb.AppendLine("    PROPERTIES");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine("    CONTROLS");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine("  }");
            sb.AppendLine("  CODE");
            sb.AppendLine("  {");
            sb.AppendLine("");
            sb.AppendLine("    BEGIN");
            sb.AppendLine("    END.");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            txtXMLPort.Text = sb.ToString();
        }
        private void ProcessHotkeys(object sender, KeyEventArgs e)
        {
            if (sender.GetType().Equals(typeof(TextBox)))
            {
                if (e.Control && (e.KeyCode == Keys.A))
                {
                    ((TextBox)sender).SelectAll();
                }
            }
        }
        private string GenerateGuid()
        {
            return "{" + Guid.NewGuid().ToString().ToUpper() + "}";
        }
        #endregion

    }
}
