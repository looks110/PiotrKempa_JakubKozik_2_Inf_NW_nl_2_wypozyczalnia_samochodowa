using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;
namespace wypozyczalniaSamochodowa

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
            //Panel logowania
            Form loginForm = new Form
            {
                Text = "Logowanie",
                Size = new Size(310, 300),
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

            Button wyslijDoBazyLog = new Button
            {
                Text = "Zaloguj siê",
                Size = new Size(100, 56),
                Location = new Point(100, 150)
            };

            wyslijDoBazyLog.Click += (s, args) =>
            {
                string mysqlcon = "server=127.0.0.1; user=root; database=wyp; password=";
                MySqlConnection conn = new MySqlConnection(mysqlcon);
                string query = "SELECT * FROM uzytkownicy WHERE login = @login AND haslo = @haslo";
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", logwanie_uz_log.Text);
                        cmd.Parameters.AddWithValue("@haslo", logwanie_uz_has.Text);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Zalogowano pomyœlnie!");
                            loginForm.Close();

                            Form newForm = new Form();
                            {
                                Text = "Nowe Okno";
                                Size = new Size(1000, 600);
                                BackColor = Color.White;
                            };

                            Label congratulationLabel = new Label
                            {
                                Location = new Point(20, 20),
                                AutoSize = false,
                                Width = 300,
                                Height = 100,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                BackColor = Color.LightGray,
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            congratulationLabel.AutoSize = true;
                            congratulationLabel.MaximumSize = new Size(280, 0);
                            congratulationLabel.Text = "Gratulacja wypo¿yczy³eœ auto! Odbierz auto jutro od 8:00 na naszym parkingu ul.Zimna12A Warszawa tel:123432213."; // Mo¿na u¿yæ d³ugiego tekstu.



                            newForm.Controls.Add(congratulationLabel);


                            newForm.ClientSize = new Size(congratulationLabel.Width + 40, congratulationLabel.Height + 40);


                            newForm.Show();
                        }
                        else 
                        {
                            MessageBox.Show("Nieprawid³owy login lub has³o.");
                        }
                    }
      
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            };

            loginForm.Controls.Add(logwanie_uz_log);
            loginForm.Controls.Add(logwanie_uz_has);
            loginForm.Controls.Add(wyslijDoBazyLog);
            loginForm.Show();
        }

        private void NewButton2_Click(object sender, EventArgs e)
        {
            //Panel rejestracji
            Form registerForm = new Form
            {
                Text = "Rejestracja",
                Size = new Size(310, 300),
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

            Button wyslijDoBazyRej = new Button
            {
                Text = "Zarejestruj siê",
                Size = new Size(100, 56),
                Location = new Point(100, 150)
            };

            wyslijDoBazyRej.Click += (s, args) =>
            {
                string mysqlcon = "server=127.0.0.1; user=root; database=wyp; password=";
                MySqlConnection conn = new MySqlConnection(mysqlcon);
                string query = "INSERT INTO uzytkownicy (login, haslo) VALUES (@login, @haslo)";
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Dodawanie parametrów do zapytania
                        cmd.Parameters.AddWithValue("@login", regi_uz_log.Text);
                        cmd.Parameters.AddWithValue("@haslo", regi_uz_has.Text);

                        // Wykonanie zapytania
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Zarejestrowano");
                            registerForm.Close();
                            registerForm.Dispose();

                            Form newForm = new Form();
                            {
                                Text = "Nowe Okno";
                                Size = new Size(1000, 600);
                                BackColor = Color.White;
                            };

                            Label congratulationLabel = new Label
                            {    
                                Location = new Point(20, 20),
                                AutoSize = false,
                                Width = 300,
                                Height = 100,
                                TextAlign = ContentAlignment.MiddleCenter,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                BackColor = Color.LightGray,
                                BorderStyle = BorderStyle.FixedSingle
                            };
                            
                            congratulationLabel.AutoSize = true;
                            congratulationLabel.MaximumSize = new Size(280, 0);
                            congratulationLabel.Text = "Gratulacja wypo¿yczy³eœ auto! Odbierz auto jutro od 8:00 na naszym parkingu ul.Zimna12A Warszawa tel:123432213."; // Mo¿na u¿yæ d³ugiego tekstu.


                           
                            newForm.Controls.Add(congratulationLabel);

                          
                            newForm.ClientSize = new Size(congratulationLabel.Width + 40, congratulationLabel.Height + 40);

                            
                            newForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Rejestracja nie powiod³a siê");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }


            };

            registerForm.Controls.Add(regi_uz_log);
            registerForm.Controls.Add(regi_uz_has);
            registerForm.Controls.Add(wyslijDoBazyRej);
            registerForm.Show();
        }
    }
}
