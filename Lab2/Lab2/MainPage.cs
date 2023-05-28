using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab2
{
    public partial class MainPage : Form
    {
        SqlConnection cs = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        SqlDataAdapter daParent = new SqlDataAdapter();
        SqlDataAdapter daChild = new SqlDataAdapter();
        DataSet dsParent = new DataSet();
        DataSet dsChild = new DataSet();
        BindingSource bsParent = new BindingSource();
        BindingSource bsChild = new BindingSource();

        string childTableName = ConfigurationManager.AppSettings["child"];
        string parentTableName = ConfigurationManager.AppSettings["parent"];

        List<string> childColumnNamesList = new List<string>(ConfigurationManager.AppSettings["childColumnNames"].Split(','));

        string childColumnNames = ConfigurationManager.AppSettings["childColumnNames"];
        string childColumnInsertParameters = ConfigurationManager.AppSettings["childColumnInsertParameters"];

        public MainPage()
        {
            InitializeComponent();
            InitializeButtons();
            InitializePanel();
            ShowDataGridParent();
        }

        private void InitializePanel()
        {
            parentLabel.Text = parentTableName;
            childLabel.Text = childTableName;
            int y = 0; 
            int labelWidth = 150; 
            int textBoxWidth = 150;
            int spacing = 4;
            
            foreach (string columnName in childColumnNamesList)
            {
                TextBox textBox = new TextBox();
                Label label = new Label();

                textBox.Name = columnName;
                label.Text = columnName;

                panelChild.Controls.Add(textBox);
                panelChild.Controls.Add(label);

                label.Location = new Point(spacing, y);
                label.Size = new Size(labelWidth, 35);
                label.Font = new Font(label.Font.FontFamily, 10, FontStyle.Regular);
                textBox.Location = new Point(label.Location.X + label.Width + spacing, y);
                textBox.Size = new Size(labelWidth, 35);
                textBox.Font = new Font(textBox.Font.FontFamily, 10, FontStyle.Regular);

                y += 35;
            }
            foreach(Control control in panelChild.Controls)
            {
                if(control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.TextChanged += TextBox_TextChanged;
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            foreach(Control control in panelChild.Controls)
            {
                if(control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if(textBox.Text.Length == 0)
                    {
                        buttonAdd.Enabled = false;
                        buttonUpdate.Enabled = false;
                    }
                }
            }

            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private void InitializeButtons()
        {
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void ShowDataGridParent()
        {
            try
            {
                daParent.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["selectParents"], cs);
                dsParent.Clear();
                daParent.Fill(dsParent);
                dataGridViewParent.DataSource = dsParent.Tables[0];
                bsParent.DataSource = dsParent.Tables[0];
            } catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridViewParinte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SqlCommand sqlCommand = new SqlCommand(ConfigurationManager.AppSettings["selectChildsFromParent"], cs);
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue(ConfigurationManager.AppSettings["parentId"], dataGridViewParent.Rows[e.RowIndex].Cells[0].Value);
                
                    daChild.SelectCommand = sqlCommand;
                    dsChild.Clear();
                    daChild.Fill(dsChild);

                    dataGridViewChild.DataSource = dsChild.Tables[0];

                    bsChild.DataSource = dsChild.Tables[0];
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDelete.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " + childTableName + "(" + childColumnNames + ") VALUES (" + childColumnInsertParameters + ")", cs);
                daParent.InsertCommand = cmd;
                foreach (string column in childColumnNamesList)
                {
                    TextBox textBox = (TextBox)panelChild.Controls[column];
                    cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                }

                cs.Open();
                daParent.InsertCommand.ExecuteNonQuery();

                dsParent.Clear();
                daParent.Fill(dsParent);

                dsChild.Clear();
                daChild.Fill(dsChild);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cs.Close();
                foreach (Control control in panelChild.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (textBox.Text.Length > 0)
                        {
                            textBox.Clear();
                        }
                    }
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = ConfigurationManager.AppSettings["updateQuery"];
                SqlCommand cmd = new SqlCommand(updateQuery, cs);
                daChild.UpdateCommand = cmd;

                foreach(string column in childColumnNamesList)
                {
                    TextBox textBox = (TextBox)panelChild.Controls[column];
                    cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                }
                cmd.Parameters.AddWithValue("@id_personnel", dataGridViewChild.CurrentRow.Cells[0].Value);

                cs.Open();
                if(daChild.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Query succesfully updated!");
                }
                dsChild.Clear();
                daChild.Fill(dsChild);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cs.Close();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure you want to delete this query?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    object CellID = dataGridViewChild.Rows[dataGridViewChild.SelectedCells[0].RowIndex].Cells[0].Value;

                    string deleteChild = ConfigurationManager.AppSettings["deleteChild"];
                    string childId = ConfigurationManager.AppSettings["childId"];
                    daChild.DeleteCommand = new SqlCommand(deleteChild, cs);
                    daChild.DeleteCommand.Parameters.Add(childId, SqlDbType.Int).Value = CellID.ToString();

                    cs.Open();
                    daChild.DeleteCommand.ExecuteNonQuery();
                    cs.Close();
                    dsChild.Clear();
                    daChild.Fill(dsChild);

                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
