namespace wypozyczalniaSamochodowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Zaloguj siê lub zarejestruj aby kontynuowaæ";
            Button newButton = new Button();
            newButton.Text = "Zaloguj siê";
            newButton.Size = new Size(114, 56);
            newButton.Location = new Point(355, 428);
            this.Controls.Add(newButton);

            Button newButton2 = new Button();
            newButton2.Text = "Zarejestruj siê";
            newButton2.Size = new Size(114, 56);
            newButton2.Location = new Point(479, 428);
            this.Controls.Add(newButton2);


        }
    }
}
