using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ATM_Program
{
    public partial class Form1 : Form
    {
        private double amountAvailable;
        private int PIN;
        private int attempts;
        private int i;
        public Form1()
        {
            InitializeComponent();
            amountAvailable = 5000;
            PIN = 3099;
            attempts = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textBox1.Text, out i) || textBox1.Text.Length == 0)
            {
                amountErrorProvider.SetError(textBox1, "Please enter valid information");
                return;
            }

            else if (int.TryParse(textBox1.Text, out int requestedAmount))
            {
                if (requestedAmount <= amountAvailable) 
                {
                    amountErrorProvider.SetError(textBox1, string.Empty);
                }
                else
                {
                    amountErrorProvider.SetError(textBox1, "You don't have this amount in your bank account!");
                }
            }

            else
            {
                amountErrorProvider.SetError(textBox1, string.Empty);
            }

            if (textBox2.Text == "")
            {
                pinErrorProvider.SetError(textBox2, "You need to enter your PIN!");
            }

            else if (!(textBox2.TextLength == 4))
            {
                pinErrorProvider.SetError(textBox2, "Your PIN should be 4 numbers!");
            }

            else if (!int.TryParse(textBox2.Text, out i))
            {
                pinErrorProvider.SetError(textBox2, "This is a number only field");
                return;
            }

            
            else if ((int.TryParse(textBox2.Text, out i)) && !(i == PIN)) 
            {

                if (!(i == PIN))
                {
                    attempts++;
                    pinErrorProvider.SetError(textBox2, "Wrong PIN!");
                    if (attempts >= 3)
                    {
                        MessageBox.Show("Maximum attempts reached. Your card is blocked!");
                        button1.Enabled = false;
                    }

                }
            }

            else
            {
                pinErrorProvider.SetError(textBox2, string.Empty);
            }

            if (amountErrorProvider.GetError(textBox1).Equals(string.Empty) &&
                 pinErrorProvider.GetError(textBox2).Equals(string.Empty))
            {
                pictureBox1.Show();
                MessageBox.Show($"You successfully withdrew {textBox1.Text} BGN!");
            }

            //else
            //{
            //    MessageBox.Show("Error!");
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
