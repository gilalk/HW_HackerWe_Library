using HackerWe.Entities;
using HackerWe.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackerWe.UI
{
    public partial class ClientUserControl1 : UserControl
    {
        Client client = new Client();

        public event Action <Client> newClient;


        public ClientUserControl1()
        {
            InitializeComponent();
        }

        private void SaveClientbtn_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            client.Id = int.Parse(textBox1.Text);
            client.FirstName = textBox2.Text;
            client.LastName = textBox3.Text;

            if (regex.IsMatch(textBox4.Text))
            {
                client.Email = textBox4.Text;
            }
            else
            {
                MessageBox.Show("Email is not valid!");
            }
            client.PhoneNumber = textBox5.Text;

            Library.Clients.Insert(0, client);
            Library.SaveClientsAsJSON();

            newClient(client);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^\d+";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Invalid ID");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(textBox5.Text))
            {
                errorProvider2.SetError(textBox5, "Invalid Phone Number");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
    }
}
