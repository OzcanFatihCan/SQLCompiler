using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDerleyici
{
    public partial class SQLDerleyiciForm : Form
    {
        public SQLDerleyiciForm()
        {
            InitializeComponent();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private SqlConnection currentConnection;
        private string currentDatabase;
        private void BtnCalistir_Click(object sender, EventArgs e)
        {
            string query = richTextBox1.Text; 

            string[] lines = query.Split(new char[] { '\n' });

            foreach (string line in lines)
            {
                if (line.TrimStart().StartsWith("use", StringComparison.OrdinalIgnoreCase))
                {                  
                    currentDatabase = line.Trim().Substring(4).Trim();
                    MessageBox.Show(currentDatabase + " Veri tabanına bağlantı sağlandı", "Hata");//use varsa güncelle
                    continue;
                }

                if (!string.IsNullOrEmpty(currentDatabase))
                {
                    if (currentConnection == null || currentConnection.Database != currentDatabase)
                    {
                        
                        currentConnection = LogicBaglanti.LLBaglan(currentDatabase);  //yeni veritabanı                     
                    }

                    if (currentConnection != null)
                    {
                        try
                        {
                            // Sorguyu çalıştır
                            SqlDataAdapter adapter = new SqlDataAdapter(query, currentConnection);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sorgu çalıştırılırken bir hata oluştu: " + ex.Message, "Hata");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı bağlantısı kurulamadı. Lütfen geçerli bir veritabanı adı girin.", "Hata");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir veritabanı seçin", "Hata");
                }
            }
        }
    }
}
