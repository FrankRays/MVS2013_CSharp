using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bank_Manager
{
    public partial class NewCredit : Form
    {
        public Guid _DebitorId { get; private set; }
        public int _amount { get; private set; }
        public DateTime _openDate { get; private set; }
        public DateTime _deadlineDate { get; private set; }

        private const int minAmount = 500;
        private const int maxAmount = 1000000;

        public NewCredit()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool isInputValid()
        {
            _openDate = dateTime_OpenDate.Value;
            _deadlineDate = dateTime_DeadlineDate.Value;

            // делаем все необходимы проверки введеных данных

            // проверка уникального ключа ID на валидность
            try
            {
                _DebitorId = new Guid(textBox_DebitorID.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Debitor ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // проверка поля Amount
            if (textBox_Amount.Text.Trim() != String.Empty)
            {
                if (!Regex.IsMatch(textBox_Amount.Text.Trim(), @"^\d+$"))
                {
                    MessageBox.Show("Amount field must contain digits only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    _amount = Int32.Parse(textBox_Amount.Text.Trim());
                    if (_amount < minAmount)
                    {
                    string str = String.Format("Amount can't be less than {0}!", minAmount);
                    MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Amount field can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // проверка дат, дата открытия кредита не может быть старше даты срока его возврата
            if (_openDate > _deadlineDate)
            {
                MessageBox.Show("Open Date should be < Deadline Date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void textBox_Amount_TextChanged(object sender, EventArgs e)
        {
            // нельзя вводить пробелы в поле ввода денежных едениц
            textBox_Amount.Text = textBox_Amount.Text.Trim().Replace(" ", "");
        }
    }
}
