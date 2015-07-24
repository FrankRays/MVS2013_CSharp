using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Manager
{
    public partial class NewPayment : Form
    {
        public Guid _CreditorId { get; private set; }
        public decimal _amount { get; private set; }
        public DateTime _date { get; private set; }

        private const int minPaymentAmount = 10;

        public NewPayment()
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
            _date = dateTime_Date.Value;

            // делаем все необходимы проверки введеных данных

            // проверка уникального ключа ID на валидность
            try
            {
                _CreditorId = new Guid(textBox_CreditID.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Creditor ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_Amount.Text.Trim() != String.Empty)
            {
                _amount = Decimal.Parse(textBox_Amount.Text.Trim());
                if (_amount < minPaymentAmount)
                {
                    string str = String.Format("Amount can't be less than {0}!", minPaymentAmount);
                    MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Amount field can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // если все проверки пройдены возврат TRUE
        }


        private void textBox_Amount_KeyPress(object sender, KeyPressEventArgs e)  //!!!!
        {
            if (e.KeyChar == ',')  // ограничение на только одну запятую в дробном числе
            {
                if (textBox_Amount.Text.Trim().Contains(',') ||
                    textBox_Amount.Text.Trim() == String.Empty)
                {
                    e.Handled = true; // не позволяем вводить 2 запятые или запятую в начале строки
                    return;
                }
                else
                {
                    e.Handled = false;
                    return;
                }
            }

            if (e.KeyChar != 8)  // не запрещяет клавишу BASKSPACE
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57))  // если не число то запрещаем
                {
                    e.Handled = true;  // разрешает ввод только цифры от 0-9
                }
                else // если ввели число
                {

                    string tmp = textBox_Amount.Text.Trim();
                    if (tmp.Contains(','))
                    {
                        int x = tmp.IndexOf(',');
                        if (tmp.Substring(x).Length > 2)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
        }
    }
}
