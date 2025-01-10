using MySql.Data.MySqlClient;
namespace wypozyczalniaSamochodowa

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string mysqlcon = "server=127.0.0.1; user=root; database=wypo¿yczalnia; password=";
            MySqlConnection conn = new MySqlConnection(mysqlcon);
            try
            {
                conn.Open();
                MessageBox.Show("Po³¹czono");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Zaloguj siê lub zarejestruj aby kontynuowaæ";
            Button newButton = new Button
            {
                Text = "Zaloguj siê",
                Size = new Size(114, 56),
                Location = new Point(355, 428)
            };
            newButton.Click += NewButton_Click_LogReje;
            this.Controls.Add(newButton);

            Button newButton2 = new Button
            {
                Text = "Zarejestruj siê",
                Size = new Size(114, 56),
                Location = new Point(479, 428)
            };
            newButton2.Click += NewButton2_Click;
            this.Controls.Add(newButton2);           
        }

        private void NewButton_Click_LogReje(object sender, EventArgs e)
        {
            Form loginForm = new Form
            {
                Text = "Logowanie",
                Size = new Size(300, 200),
                BackColor = Color.White
            };
            

            TextBox logwanie_uz_log = new TextBox
            {   
                PlaceholderText = "Podaj login",
                Location = new Point(100, 50),
                AutoSize = true
            };

            TextBox logwanie_uz_has = new TextBox
            {
                PlaceholderText = "Podaj has³o",
                Location = new Point(100, 100),
                AutoSize = true
            };
            loginForm.Controls.Add(logwanie_uz_log);
            loginForm.Controls.Add(logwanie_uz_has);
            loginForm.Show();
        }

        private void NewButton2_Click(object sender, EventArgs e)
        {
            Form registerForm = new Form
            {
                Text = "Rejestracja",
                Size = new Size(300, 200),
                BackColor = Color.White
            };

            TextBox regi_uz_log = new TextBox
            {
                PlaceholderText = "Podaj nowy login",
                Location = new Point(100, 50),
                AutoSize = true
            };
            TextBox regi_uz_has = new TextBox
            {
                PlaceholderText = "Podaj nowe has³o",
                Location = new Point(100, 100),
                AutoSize = true
            };
            registerForm.Controls.Add(regi_uz_log);
            registerForm.Controls.Add(regi_uz_has);
            registerForm.Show();
        }







    }
}
