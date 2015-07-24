using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Bank_Manager
{
    public partial class MainForm : Form
    {
        DAL dal = new DAL();   // класс для общения с БД
        List<DataGridViewRow> searchedRows; // список для поиска записей 


        public MainForm()
        {
            InitializeComponent();

            // При создании главного окна
            dataGridView_Debitors.DataSource = dal.GetAllDebitors(); // получаем из бд все записи из таблицы Debitors
            SettingDataGridView_Debitors();
        }

        public void SettingDataGridView_Debitors()
        {
            // Настройки для DataGridView_Debitors
            try
            {
                dataGridView_Debitors.Columns["Id"].Visible = false;
                dataGridView_Debitors.TopLeftHeaderCell.Value = "#";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        // подписывание на событий при загрузке окна
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView_Debitors.CellEnter += dataGridView_Debitors_CellEnter;
            dataGridView_Credits.CellEnter += dataGridView_Credits_CellEnter;
        }

        // отображение всех кредитов при выборе дебитора
        private void dataGridView_Debitors_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            #region Display current selected Debitor's details
            // при выборе записи в таблице Debitors, выводит всю информацию о записи в grpbx Debitors Details
            textBox_ID.Text = dataGridView_Debitors.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView_Debitors.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox_PersonalCode.Text = dataGridView_Debitors.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox_DateOfBirth.Text = dataGridView_Debitors.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox_Adress.Text = dataGridView_Debitors.Rows[e.RowIndex].Cells[4].Value.ToString();
            #region Add separator - in Number
            var refactorNumber = dataGridView_Debitors.Rows[e.RowIndex].Cells[5].Value.ToString().TrimEnd();

            int strLeng = refactorNumber.Length;
            int counter = 0;

            for (int i = 0; i < strLeng; i++)
                if (i % 3 == 0 && i != 0)
                {
                    refactorNumber = refactorNumber.Insert(i + counter, "-");
                    counter++;
                }
            #endregion
            textBox_PhoneNumber.Text = refactorNumber;
            #endregion

            string selectedDebitorID = dataGridView_Debitors.CurrentRow.Cells["Id"].Value.ToString();
            dataGridView_Credits.DataSource = dal.GetAllCreditsForDebitor(selectedDebitorID);

            if (dataGridView_Credits.RowCount == 0)
            {
                dataGridView_Payments.DataSource = null;
            }
        }

        // отображение всех оплат при выборе кредита
        private void dataGridView_Credits_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string selectedCreditID = dataGridView_Credits.CurrentRow.Cells["Id"].Value.ToString();
            dataGridView_Payments.DataSource = dal.GetAllPaymentsForCredit(selectedCreditID);
        }

        // спрашиваем пользователя действительно ли он хочет закрыть приложение
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Bank Manager", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else e.Cancel = true;
        }

        #region MenuStrip and Toolbox Click Events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewDebitor();
        }

        private void debitorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewDebitor();
        }

        private void toolStripButton_AddDebitor_Click(object sender, EventArgs e)
        {
            AddNewDebitor();
        }

        private void creditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewCredit();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddNewCredit();
        }

        private void toolStripButton_AddCredit_Click(object sender, EventArgs e)
        {
            AddNewCredit();
        }
        private void toolStripButton_AddPayment_Click(object sender, EventArgs e)
        {
            AddNewPayment();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddNewPayment();
        }

        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewPayment();
        }

        // сохранение данных бд в файл
        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void toolStripButton_SaveData_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        #endregion

        /// Form Methods
        private void AddNewDebitor()
        {
            AddDebitor addDeb = new AddDebitor();
            if (addDeb.ShowDialog() == DialogResult.OK)
            {
                if (dal.SaveNewDebitor(addDeb._name, addDeb._perCode, addDeb._dayOfBirth, addDeb._adress, addDeb._phoneNumber))
                {
                    MessageBox.Show("New Debitor was added.");
                    dataGridView_Debitors.DataSource = dal.GetAllDebitors(); // обновление интерфейса после добавления
                }
            }
        }

        private void AddNewCredit()
        {
            NewCredit addCred = new NewCredit();
            if (addCred.ShowDialog() == DialogResult.OK)
            {
                if (dal.CheckDebitorId(addCred._DebitorId))
                {
                    if (dal.SaveNewCredit(addCred._DebitorId, addCred._amount, addCred._openDate, addCred._deadlineDate))
                    {
                        MessageBox.Show("New Credit was created.");
                        string selectedDebitorID = dataGridView_Debitors.CurrentRow.Cells["Id"].Value.ToString(); // обновление UI
                        dataGridView_Credits.DataSource = dal.GetAllCreditsForDebitor(selectedDebitorID);
                    }
                }
                else
                {
                    MessageBox.Show("There is no such Debitor ID in Data Base!", "Bank Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddNewPayment()
        {
            NewPayment addPayment = new NewPayment();
            if (addPayment.ShowDialog() == DialogResult.OK)
            {
                if (dal.CheckCreditId(addPayment._CreditorId))
                {
                    if (dal.SaveNewPayment(addPayment._CreditorId, addPayment._amount, addPayment._date))
                    {
                        MessageBox.Show("New Payment was created.");

                        string selectedDebitorID = dataGridView_Debitors.CurrentRow.Cells["Id"].Value.ToString(); // обновление UI
                        dataGridView_Credits.DataSource = dal.GetAllCreditsForDebitor(selectedDebitorID);

                        string selectedCreditID = dataGridView_Credits.CurrentRow.Cells["Id"].Value.ToString(); // обновление UI
                        dataGridView_Payments.DataSource = dal.GetAllPaymentsForCredit(selectedCreditID);
                    }
                }
                else
                {
                    MessageBox.Show("There is no such Credit ID in Data Base!", "Bank Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveData()
        {
            if (dal.SaveDataToFiles())
            {
                MessageBox.Show("Data successfully saved!", "Bank Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data save failed!", "Bank Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // добавляем нумерацию записей в DataGridView
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            object headValue = ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value;
            if (headValue == null || !headValue.Equals((e.RowIndex + 1).ToString()))
            {
                ((DataGridView)sender).Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            searchedRows = new List<DataGridViewRow>();
            string DebName = textBox_SearchName.Text.Trim();
            string PerCode = textBox_SearchPersCode.Text.Trim();
            string PhoneNum = textBox_SearchPhoneNumber.Text.Trim();

            foreach(DataGridViewRow row in dataGridView_Debitors.Rows)
            {
                if (row.Cells["Name"].FormattedValue.ToString().Contains(DebName) &&
                    row.Cells["Personal Code"].FormattedValue.ToString().Contains(PerCode) &&
                    row.Cells["Phone Number"].FormattedValue.ToString().Contains(PhoneNum))
                {
                    searchedRows.Add(row); // добавляем все совпадающие с уловием поиска записи
                }
            }

            if (searchedRows.Count == 0)
            {
                MessageBox.Show("Nothing has found!");
                button_Next.Enabled = false;
                return;
            }
            else
            {
                string str = String.Format("{0} records has found.", searchedRows.Count);
                MessageBox.Show(str);
                button_Next.Enabled = true;
                currentRow = -1;
                button_Next_Click(null, null);
            }
        }  // поиск

        private int currentRow;
        private void button_Next_Click(object sender, EventArgs e) // показывает след. найденную запись
        {
            if (currentRow == (searchedRows.Count - 1))
                currentRow = 0;
            else
                currentRow++;

            dataGridView_Debitors.CurrentCell = searchedRows[currentRow].Cells[1];
        }

        private void groupBox_LayerDebitors_Debitors_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("");
            dataGridView_LayerDebitors.DataSource = dal.GetAllDebitors();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    dataGridView_LayerDebitors.DataSource = dal.GetAllDebitors();
                    break;
                case 2:
                    dataGridView_LayerCredits.DataSource = dal.GetAllCredits();
                    break;
                case 3:
                    dataGridView_LayerPayments.DataSource = dal.GetAllPayments();
                    break;
                default:
                    break;
            }
        }

    }
}
