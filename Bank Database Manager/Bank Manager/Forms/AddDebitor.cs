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

namespace Bank_Manager
{
    public partial class AddDebitor : Form
    {
        public string _name {get; private set;}
        public string _perCode {get; private set;}
        public string _dayOfBirth {get; private set;}
        public string _adress {get; private set;}
        public string _phoneNumber {get; private set;}

        public AddDebitor()
        {
            InitializeComponent();
        }

        private void buttonSaveNewDebitor_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool isInputValid()
        {
            _name = textBox_Name.Text.Trim();
            _perCode = textBox_PersonalCode.Text.Trim();
            _dayOfBirth = textBox_DateOfBirth.Text.Trim();
            _adress = textBox_Adress.Text.Trim();
            _phoneNumber = textBox_PhoneNumber.Text.Trim();

            // проверка всех введенных данных на валидность
            if (_name.Length > 50 || _name.Length < 6)
            {
                MessageBox.Show("Name should contain 6-50 symbols!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_perCode.Length > 50 || _perCode.Length < 1)
            {
                MessageBox.Show("Personal Code can't be empty and should contain less than 50 symbols!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_adress.Length > 50 || _adress.Length < 1)
            {
                MessageBox.Show("Adress can't be empty and should contain less than 50 symbols!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_phoneNumber.Length > 50)
            {
                MessageBox.Show("Phone Number should contain less than 50 symbols!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                DateTime.Parse(_dayOfBirth); // проверка формата даты
            }
            catch
            {
                MessageBox.Show("Birth of Day is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(!Regex.IsMatch(_phoneNumber, @"^\d+$"))
            {
                MessageBox.Show("Phone Number must contain digits only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // если проверки пройдены то возвращает TRUE
            return true;
        }
    }
}
