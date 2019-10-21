using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumSharp;

namespace PdfiumSharpGUITest {
  public partial class Form1 : Form {

    public PDF P;
    public Image Test;
    public Form1() {
      InitializeComponent();
      P = new PDF();
    }

    private void button1_Click(object sender, EventArgs e) {
      OpenFileDialog openFileDialog1 = new OpenFileDialog {
        InitialDirectory = @"C:\Users\edgar\Downloads",
        Title = "Browse PDF Files",

        CheckFileExists = true,
        CheckPathExists = true,

        DefaultExt = "pdf",
        Filter = "pdf files (*.pdf)|*.pdf",
        FilterIndex = 2,
        RestoreDirectory = true,

        ReadOnlyChecked = true,
        ShowReadOnly = true
      };

      if (openFileDialog1.ShowDialog() == DialogResult.OK) {
        textBox1.Text = openFileDialog1.FileName;
      }

      P.Load(textBox1.Text);

    }

    private void button2_Click(object sender, EventArgs e) {
      var inf = P.GetInformation();

      textBox2.Text = "Number of Pages: " + P.PageCount().ToString();
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("Creator: " + inf.Creator);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("Title: " + inf.Title);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("Author: " + inf.Author);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("Subject: " + inf.Subject);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("Keywords: " + inf.Keywords);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("Producer: " + inf.Producer);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("CreationDate: " + inf.CreationDate);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText(Environment.NewLine);
      textBox2.AppendText("ModDate: " + inf.ModificationDate);
    }

    private void textBox3_TextChanged(object sender, EventArgs e) {

    }

    private void button3_Click(object sender, EventArgs e) {
      int pagenumber = Int32.Parse(textBox3.Text);
      Test = P.Render(pagenumber, 460, 520, 460, 520);
            
      pictureBox1.Image = Test;
    }

    private void pictureBox1_Click(object sender, EventArgs e) {

    }

    private void Form1_Load(object sender, EventArgs e) {

    }
  }
}
