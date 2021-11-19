using HackerWe.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackerWe.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer timer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Tick += (object o, EventArgs argss) =>
            {
                lblMessages.Text = "";
                timer.Stop();
            };

            Library.ReadBooksFromJSON();
            Library.ReadClientsFromJSON();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            AddBookControl addBookControl = new AddBookControl();
            addBookControl.Parent = panel1;

            addBookControl.SaveNewBook += (NewBook) =>
            {
                lblMessages.Text = "The Book " + NewBook.Name + " has save successfully, Thanks!";
                panel1.Controls.Clear();
                BorrowingUserControl borrowingUserControl = new BorrowingUserControl();
                borrowingUserControl.Parent = panel1;
                timer.Start();

            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BorrowingUserControl borrowingUserControl = new BorrowingUserControl();
            borrowingUserControl.BorrowingSaved += (borrowing) =>
            {
                lblMessages.Text = "Borowing saved successfully "+ borrowing.Id;
                timer.Start();
            };
            borrowingUserControl.Parent = panel1;

            borrowingUserControl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ClientUserControl1 clientUserControl1 = new ClientUserControl1();
            clientUserControl1.Parent = panel1;

            clientUserControl1.newClient += (NewClient) =>
            {
                lblMessages.Text = "The Client " + NewClient.FullName + " has signed successfully, Welcome!";
                panel1.Controls.Clear();
                BorrowingUserControl borrowingUserControl = new BorrowingUserControl();
                borrowingUserControl.Parent = panel1;
                timer.Start();

            };
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
