using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Bank_Manager
{
    // Класс для общения с базой данных
    class DAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Bank_Manager.Properties.Settings.BankConnectionString"].ConnectionString;

        public ArrayList GetAllDebitors()
        {
            ArrayList allDebitors = new ArrayList(); // переменная для возврата
            
            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand("SELECT * FROM Debitors Order By Name", conec);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allDebitors.Add(result);
                        }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with connecting to database: " + e.Message);
                }
            }
            return allDebitors;
        }

        public ArrayList GetAllCredits()
        {
            ArrayList allCredits = new ArrayList(); // переменная для возврата

            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand("SELECT * FROM Credits Order By [Open Date]", conec);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allCredits.Add(result);
                        }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with connecting to database: " + e.Message);
                }
            }
            return allCredits;
        }

        public ArrayList GetAllPayments()
        {
            ArrayList allPayments = new ArrayList(); // переменная для возврата

            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand("SELECT * FROM Payments Order By [Payment Date]", conec);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allPayments.Add(result);
                        }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with connecting to database: " + e.Message);
                }
            }
            return allPayments;
        }

        internal object GetAllCreditsForDebitor(string debitorID)
        {
            ArrayList allCreditsForDebitor = new ArrayList();
            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                //string querry = String.Format("SELECT * FROM Credits WHERE DebitorID='{0}' Order By 'Open Date'", debitorID);

                SqlCommand command = new SqlCommand("GetAllCreditsByCurrentDebitor", conec);
                command.CommandType = System.Data.CommandType.StoredProcedure; // используем хранимую процедуру из бд

                SqlParameter param = new SqlParameter();  // создаем параметр для процедуры
                param.ParameterName = @"debitorID";  // имя указанное в процедуре
                param.Value = new Guid(debitorID);
                param.SqlDbType = System.Data.SqlDbType.UniqueIdentifier;
                param.Direction = System.Data.ParameterDirection.Input; // параметр входа
                command.Parameters.Add(param);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allCreditsForDebitor.Add(result);
                        }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with connecting to database: " + e.Message);
                }
            }

            return allCreditsForDebitor;
        }

        internal object GetAllPaymentsForCredit(string selectedCreditorID)
        {
            ArrayList allPaymentsForCredit = new ArrayList();
            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                string querry = String.Format("SELECT * FROM Payments WHERE CreditID='{0}' Order By 'Payment Date'", selectedCreditorID);
                SqlCommand command = new SqlCommand(querry, conec);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allPaymentsForCredit.Add(result);
                        }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with connecting to database: " + e.Message);
                }
            }

            return allPaymentsForCredit;
        }

        public bool CheckCreditId(Guid creditID)
        {
            bool success = false;

            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                string querry = String.Format("SELECT * FROM Credits WHERE Id='{0}'", creditID.ToString());
                SqlCommand command = new SqlCommand(querry, conec);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with checking Credit Id: " + e.Message);
                }
            }

            return success;
        }

        public bool CheckDebitorId(Guid creditID)
        {
            bool success = false;

            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                string querry = String.Format("SELECT * FROM Debitors WHERE Id='{0}'", creditID.ToString());
                SqlCommand command = new SqlCommand(querry, conec);

                try
                {
                    conec.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with checking Debitor Id: " + e.Message);
                }
            }

            return success;
        }

        public bool SaveNewDebitor(string Name, string PersonalCode, string DateOfBirth, string Adress, string PhoneNumber)
        {
            bool success = false;

            string querry = String.Format("INSERT into Debitors ([Name], [Personal Code], [Day of Birth], [Adress], [Phone Number]) " +
                "VALUES ('{0}','{1}','{2}','{3}','{4}')", Name, PersonalCode, DateOfBirth, Adress, PhoneNumber);

            // присоедениение к базе данных
            using (SqlConnection conec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand(querry, conec);

                try
                {
                    conec.Open();
                    if (command.ExecuteNonQuery() == 1) // возвращает кол-во добавленных записей, если 1 то вставка успех
                        success = true;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with adding to database: " + e.Message);
                }
            }

            return success;
        }

        public bool SaveNewCredit(Guid debitorID, int amount, DateTime openDate, DateTime deadlineDate)
        {
            bool success = false;

            string query = String.Format("INSERT into Credits ([DebitorID], [Amount], [Current Balance], [Open Date], [Deadline Date]) " +
                "VALUES ('{0}','{1}','{2}','{3}','{4}')", debitorID, amount, amount, openDate, deadlineDate);

            // присоедениение к базе данных
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand(query, connec);

                try
                {
                    connec.Open();
                    if (command.ExecuteNonQuery() == 1) // возвращает кол-во добавленных записей, если 1 то вставка успех
                        success = true;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with creating new credit: " + e.Message);
                }
            }

            return success;
        }

        internal bool SaveNewPayment(Guid creditID, decimal amount, DateTime date)
        {
            bool success = false;

            // присоедениение к базе данных
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                try
                {
                    connec.Open();
                    SqlTransaction sqlTransact = connec.BeginTransaction();  // начинаем работу в режиме транзакции
                    SqlCommand command = connec.CreateCommand();  // создаем команду
                    command.Transaction = sqlTransact;            // назначаем комманде транзакцию

                    try
                    {
                        string payAmount = amount.ToString().Replace(',', '.');
                        string query = String.Format("INSERT into Payments ([CreditID], [Amount], [Payment Date]) " +
                            "VALUES ('{0}','{1}','{2}')", creditID, payAmount, date);
                        command.CommandText = query;
                        command.ExecuteNonQuery();  // выполняем команду

                        // уменьшаем баланса кредита на введнную сумму платежа
                        query = String.Format("UPDATE Credits SET [Current Balance] = ([Current Balance] - {0}) " +
                        "WHERE [Id] = '{1}'", payAmount, creditID);
                        command.CommandText = query;
                        command.ExecuteNonQuery();  // выполняем команду

                        // фиксирование транзакции
                        sqlTransact.Commit();  // даем понять БД что все команды в транзакции были произведены

                        success = true;
                    }
                    catch(Exception e)
                    {
                        sqlTransact.Rollback(); // в случае ошибки откат всех изменний в бд
                        MessageBox.Show("Error in transaction: " + e.Message);
                        return false;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with creating new payment: " + e.Message);
                }
            }

            return success;
        }

        internal bool SaveDataToFiles()
        {
            if (SaveDebitorsToFile() == true && SaveCreditsToFile() == true && SavePaymentsToFile() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool SaveDebitorsToFile()
        {
            bool success = false;

            StreamWriter file = new StreamWriter(new FileStream("Debitors.csv", FileMode.Create), Encoding.GetEncoding(1251));

            string querry = String.Format("SELECT * FROM Debitors");

            // присоедениение к базе данных
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand(querry, connec);

                try
                {
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    file.WriteLine("Table 'Debitors'");
                    file.WriteLine(@"""ID"";""Name"";""Personal Code"";""Day of Birth"";""Adress"";""Phone Number""");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            file.WriteLine(@"""" + reader[0].ToString() + @""";""" +
                                reader[1].ToString() + @""";""" + reader[2].ToString() + @""";""" +
                                reader[3].ToString() + @""";""" + reader[4].ToString() + @""";""" +
                                reader[5].ToString() + @"""", Encoding.ASCII);
                        }

                        file.WriteLine("End of File.");
                        success = true;
                    }
                    else
                    {
                        file.WriteLine("The table is empty.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with saving Debitors: " + e.Message);
                    return false;
                }
                finally
                {
                    file.Close();
                }
            }

            return success;
        }

        internal bool SaveCreditsToFile()
        {
            bool success = false;

            StreamWriter file = new StreamWriter(new FileStream("Credits.csv", FileMode.Create), Encoding.GetEncoding(1251));

            string querry = String.Format("SELECT * FROM Credits");

            // присоедениение к базе данных
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand(querry, connec);

                try
                {
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    file.WriteLine("Table 'Credits'");
                    file.WriteLine(@"""ID"";""Debitor ID"";""Amount"";""Current Balance"";""Open Date"";""Deadline Date""");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            file.WriteLine(@"""" + reader[0].ToString() + @""";""" +
                                reader[1].ToString() + @""";""" + reader[2].ToString() + @""";""" +
                                reader[3].ToString() + @""";""" + reader[4].ToString() + @""";""" +
                                reader[5].ToString() + @"""", Encoding.ASCII);
                        }

                        file.WriteLine("End of File.");
                        success = true;
                    }
                    else
                    {
                        file.WriteLine("The table is empty.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with saving Credits: " + e.Message);
                    return false;
                }
                finally
                {
                    file.Close();
                }
            }

            return success;
        }

        internal bool SavePaymentsToFile()
        {
            bool success = false;

            StreamWriter file = new StreamWriter(new FileStream("Payments.csv", FileMode.Create), Encoding.GetEncoding(1251));

            string querry = String.Format("SELECT * FROM Payments");

            // присоедениение к базе данных
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                // запрос к базе данных
                SqlCommand command = new SqlCommand(querry, connec);

                try
                {
                    connec.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    file.WriteLine("Table 'Payments'");
                    file.WriteLine(@"""ID"";""Credit ID"";""Amount"";""Payment Date""");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            file.WriteLine(@"""" + reader[0].ToString() + @""";""" +
                                reader[1].ToString() + @""";""" + reader[2].ToString() + @""";""" 
                                + reader[3].ToString() + @"""", Encoding.ASCII);
                        }

                        file.WriteLine("End of File.");
                        success = true;
                    }
                    else
                    {
                        file.WriteLine("The table is empty.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error with saving Payments: " + e.Message);
                    return false;
                }
                finally
                {
                    file.Close();
                }
            }

            return success;
        }
    }
}
