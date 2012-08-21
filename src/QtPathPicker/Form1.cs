using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ShowCurrentQtPath();

            pathComboBox_.Items.Add("<<<Pick root directory below>>>");
        }

        private void ShowCurrentQtPath()
        {
            GetPathAndDoSomething((s, p) => currentPathLabel_.Text = p);
        }

        private void GetPathAndDoSomething(Action<string, string> something)
        {
            object value = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment", "PATH", null);
            if (value != null)
            {
                string fullPath = value as string;
                if (fullPath != null)
                {
                    var paths = fullPath.Split(';');
                    var qtPath = paths.Where(p => p.Contains("Qt")).SingleOrDefault();
                    if (qtPath != null)
                    {
                        something(fullPath, qtPath);
                    }
                }
            }
        }

        private void chooseRootButton__Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                chooseRootButton_.Text = folderBrowserDialog1.SelectedPath;
                updateChoices(chooseRootButton_.Text);
            }
        }

        private void updateChoices(string root)
        {
            var dirs = Directory.GetDirectories(root);
            pathComboBox_.Items.Clear();
            pathComboBox_.Items.AddRange(dirs);
        }

        private void pathComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPath = pathComboBox_.SelectedItem as string;
            selectedPath += "\\bin";

            if (Directory.Exists(selectedPath))
            {
                GetPathAndDoSomething((f, p) => SetNewQtPath(f, p, selectedPath));
            }
        }

        private void SetNewQtPath(string fullPath, string oldQtPath, string newQtPath)
        {
            fullPath = fullPath.Replace(oldQtPath, newQtPath);

            var pathKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment", true);

            pathKey.SetValue("PATH", fullPath);
            currentPathLabel_.Text = newQtPath;
        }
    }
}
