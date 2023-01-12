using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fajlovi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Stack<string> stack1;
        Stack<string> stack2;
        string folder1_path = @"E:\test_folder1";
        string folder2_path = @"E:\test_folder2";
        private void Form1_Load(object sender, EventArgs e)
        {
            stack1 = new Stack<string>();
            stack2 = new Stack<string>();
            if(Directory.Exists(folder1_path))
                Directory.Delete(folder1_path, true);
            if (Directory.Exists(folder2_path))
                Directory.Delete(folder2_path, true);
        }

        private void toolStripUkloni_Click(object sender, EventArgs e)
        {
            if(stack1.Count == 0)
            {
                if (Directory.Exists(folder2_path))
                {
                    Directory.Delete(folder2_path, true);
                    MessageBox.Show("test_folder2 je obrisan!!!","Vazno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stack2.Clear();
                }
                else
                    stack2.Clear();
            }
            else
            {
                string stack1_pop = stack1.Pop();
                string ime_fajla = Path.GetFileName(stack1_pop);
                string odredisni_path = folder2_path;
                string odredisno_puno_ime_fajla = Path.Combine(odredisni_path, ime_fajla);
                if (!Directory.Exists(odredisni_path))
                    Directory.CreateDirectory(odredisni_path);
                if (stack1_pop != odredisno_puno_ime_fajla && !(stack2.Contains(odredisno_puno_ime_fajla)))
                {
                    File.Copy(stack1_pop, odredisno_puno_ime_fajla, true);
                    stack2.Push(odredisno_puno_ime_fajla);
                }
                File.Delete(stack1_pop);
            }
            UpdateListBox1();
            UpdateListBox2();

        }

        private void toolStripDodaj_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (stack1.Count >= 10)
                {
                    foreach (string filename in stack1)
                    {
                        File.Delete(filename);
                    }
                    stack1.Clear();
                    foreach (string filename in ofd.FileNames)
                    {
                        string ime_fajla = Path.GetFileName(filename);
                        string odredisni_path = folder1_path;
                        string odredisno_puno_ime_fajla = Path.Combine(odredisni_path, ime_fajla);
                        if (!Directory.Exists(odredisni_path))
                            Directory.CreateDirectory(odredisni_path);
                        if (filename != odredisno_puno_ime_fajla && !(stack1.Contains(odredisno_puno_ime_fajla)))
                        {
                            File.Copy(filename, odredisno_puno_ime_fajla, true);
                            stack1.Push(odredisno_puno_ime_fajla);
                        }
                        else MessageBox.Show($"Fajl '{odredisno_puno_ime_fajla}' vec postoji u steku pa nece biti dodat!!!", "Vazno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (ofd.FileNames.Length + stack1.Count > 10)
                {
                    MessageBox.Show($"Maksimalan broj fajlova je 10\n(sa ovom selekcijom imali biste {ofd.FileNames.Length + stack1.Count} fajlova)","Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    foreach (string filename in ofd.FileNames)
                    {
                        string ime_fajla = Path.GetFileName(filename);
                        string odredisni_path = folder1_path;
                        string odredisno_puno_ime_fajla = Path.Combine(odredisni_path, ime_fajla);
                        if (!Directory.Exists(odredisni_path))
                            Directory.CreateDirectory(odredisni_path);
                        if (filename != odredisno_puno_ime_fajla && !(stack1.Contains(odredisno_puno_ime_fajla)))
                        {
                            File.Copy(filename, odredisno_puno_ime_fajla, true);
                            stack1.Push(odredisno_puno_ime_fajla);
                        }
                        else MessageBox.Show($"Fajl '{odredisno_puno_ime_fajla}' vec postoji u steku pa nece biti dodat!!!","Vazno",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            UpdateListBox1();
        }
        private void UpdateListBox1()
        {
            listBox1.Items.Clear();
            foreach (string s in stack1)
                listBox1.Items.Add(s);
        }
        private void UpdateListBox2()
        {
            listBox2.Items.Clear();
            foreach (string s in stack2)
                listBox2.Items.Add(s);
        }
    }
}
