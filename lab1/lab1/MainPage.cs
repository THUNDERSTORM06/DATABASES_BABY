using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab1
{
    public partial class MainPage : Form
    {
        SqlConnection conexiune = new SqlConnection(@"Data Source=DESKTOP-4EUM035;Initial Catalog=DATABASE;Integrated Security=True;TrustServerCertificate=true;");

        SqlDataAdapter daCherestea = new SqlDataAdapter();
        SqlDataAdapter daSpecii = new SqlDataAdapter();
        DataSet dsCherestea = new DataSet();
        DataSet dsSpecii = new DataSet();
        BindingSource bsCherestea = new BindingSource();
        BindingSource bsSpecii = new BindingSource();

        public MainPage()
        {
            InitializeComponent();
            showDataGridCherestea();
            initializeButtons();
        }

        private void initializeButtons()
        {
            buttonAdd.Enabled = true;
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private void showDataGridCherestea()
        {
            daCherestea.SelectCommand = new SqlCommand("SELECT * FROM Cherestea", conexiune);
            dsCherestea.Clear();
            daCherestea.Fill(dsCherestea);
            dataGridViewCherestea.DataSource = dsCherestea.Tables[0];
            bsCherestea.DataSource = dsCherestea.Tables[0];
        }

        private void dataGridViewCherestea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sqlSpecii = "SELECT * FROM Specii WHERE cod_5 = @cod_5";
                SqlCommand sqlCommand = new SqlCommand(sqlSpecii, conexiune);
                sqlCommand.Parameters.AddWithValue("@cod_5", dataGridViewCherestea.Rows[e.RowIndex].Cells["cod_5"].Value);

                daSpecii.SelectCommand = sqlCommand;
                dsSpecii.Clear();
                daSpecii.Fill(dsSpecii);

                dataGridViewSpecii.DataSource = dsSpecii.Tables[0];

                bsSpecii.DataSource = dsSpecii.Tables[0];
            }
        }
        private void dataGridViewCherestea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string sqlSpecii = "SELECT * FROM Specii WHERE cod_5 = @cod_5";
                SqlCommand sqlCommand = new SqlCommand(sqlSpecii, conexiune);
                sqlCommand.Parameters.AddWithValue("@cod_5", dataGridViewCherestea.Rows[dataGridViewCherestea.CurrentRow.Index].Cells["cod_1"].Value);

                daSpecii.SelectCommand = sqlCommand;
                dsSpecii.Clear();
                daSpecii.Fill(dsSpecii);

                dataGridViewSpecii.DataSource = dsSpecii.Tables[0];

                bsSpecii.DataSource = dsSpecii.Tables[0];

                e.Handled = true;
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBoxGen.Text, out int gen))
                {
                    MessageBox.Show("Gen invalid.");
                    return;
                }
                else if (textBoxSpeciiName.Text == "")
                {
                    MessageBox.Show("Denumire invalida.");
                    return;
                }

                daSpecii.InsertCommand = new SqlCommand("INSERT INTO Specii (denumire, gen, cod_5) VALUES (@denumire, @gen, @cod_5)", conexiune);
                daSpecii.InsertCommand.Parameters.Add("@denumire", SqlDbType.NVarChar).Value = textBoxSpeciiName.Text;
                daSpecii.InsertCommand.Parameters.Add("@gen", SqlDbType.Int).Value = textBoxGen.Text;
                daSpecii.InsertCommand.Parameters.Add("@cod_5", SqlDbType.Int).Value = dataGridViewCherestea.Rows[dataGridViewCherestea.SelectedCells[0].RowIndex].Cells["id_casino"].Value;

                conexiune.Open();
                var x = daSpecii.InsertCommand.ExecuteNonQuery();
                conexiune.Close();

                dsSpecii.Clear();
                daSpecii.Fill(dsSpecii);
                textBoxSpeciiName.Clear();
                textBoxGen.Clear();
                buttonAdd.Enabled = false;
                if (x > 0)
                {
                    MessageBox.Show("Specia a fost adăugata cu succes!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Sunteți sigur că doriți să ștergeți acesta specie?", "Ștergere", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int selectedrowindex = dataGridViewSpecii.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridViewSpecii.Rows[selectedrowindex];
                    string id = selectedRow.Cells["cod_5"].Value.ToString();

                    int cod_5;
                    if (int.TryParse(id, out cod_5))
                    {
                        daSpecii.DeleteCommand = new SqlCommand("DELETE FROM Specii WHERE cod_5 = @cod_5", conexiune);
                        daSpecii.DeleteCommand.Parameters.Add("@cod_5", SqlDbType.Int).Value = id;

                        conexiune.Open();
                        daSpecii.DeleteCommand.ExecuteNonQuery();
                        conexiune.Close();

                        dsSpecii.Clear();
                        daSpecii.Fill(dsSpecii);
                        buttonDelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Nu a funcționat. Am eșuat.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int x;
                if (!int.TryParse(textBoxGen.Text, out int gen))
                {
                    MessageBox.Show("Gen invalid.");
                    return;
                }
                else if (textBoxSpeciiName.Text == "")
                {
                    MessageBox.Show("Denumire invalid.");
                    return;
                }

                string name = textBoxSpeciiName.Text;
                daSpecii.UpdateCommand = new SqlCommand("UPDATE Specii SET denumire = @denumire, gen = @gen WHERE cod_5 = @cod_5", conexiune);
                daSpecii.UpdateCommand.Parameters.AddWithValue("@denumire", name);
                daSpecii.UpdateCommand.Parameters.AddWithValue("@gen", gen);
                daSpecii.UpdateCommand.Parameters.Add("@cod_5", SqlDbType.Int).Value = dataGridViewSpecii.CurrentRow.Cells[0].Value;

                conexiune.Open();
                x = daSpecii.UpdateCommand.ExecuteNonQuery();
                conexiune.Close();
                if (x >= 1)
                {
                    MessageBox.Show("Specia a fost modificata!");
                }
                dsSpecii.Clear();
                daSpecii.Fill(dsSpecii);
                textBoxSpeciiName.Clear();
                textBoxGen.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSpeciiName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSpeciiName.Text.Length > 0 && dataGridViewSpecii.Rows.Count > 0)
            {
                buttonAdd.Enabled = true;
                buttonUpdate.Enabled = true;
            }
            else
            {
                buttonAdd.Enabled = false;
                buttonUpdate.Enabled = false;
            }
        }

        private void textBoxGen_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGen.Text.Length > 0 && dataGridViewSpecii.Rows.Count > 0)
            {
                buttonAdd.Enabled = true;
                buttonUpdate.Enabled = true;
            }
            else
            {
               buttonAdd.Enabled = false;
               buttonUpdate.Enabled = false;
            }
        }

        private void dataGridViewSpecii_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDelete.Enabled = true;
        }

        private void dataGridViewCherestea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sqlSpecii = "SELECT * FROM Cherestea WHERE cod_5 = @cod_5";
                SqlCommand sqlCommand = new SqlCommand(sqlSpecii, conexiune);
                sqlCommand.Parameters.AddWithValue("@cod_5", dataGridViewCherestea.Rows[e.RowIndex].Cells["cod_5"].Value);

                daSpecii.SelectCommand = sqlCommand;
                dsSpecii.Clear();

                dataGridViewSpecii.DataSource = dsSpecii.Tables[0];

                bsSpecii.DataSource = dsSpecii.Tables[0];
            }
                daSpecii.Fill(dsSpecii);
        }

        private void labelCherestea_Click(object sender, EventArgs e)
        {

        }
    }
}