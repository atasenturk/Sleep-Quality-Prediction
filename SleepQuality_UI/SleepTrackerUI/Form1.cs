using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace SleepTrackerUI
{
    public partial class mainForm : Form
    {
        private Button currentButton;
        private Button btnAdvices;
        private Button btnSleepDetails;
        private float sleepQuality;
        Panel pnlSleep = new Panel();
        public mainForm()
        {
            InitializeComponent();
            btnSleepQuality.PerformClick();
        }

        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {

                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(183, 150, 224);
                    Panel color = new Panel();
                    color.Size = new Size(190, 5);
                    color.BackColor = Color.FromArgb(173, 130, 196);

                    currentButton.Controls.Add(color);
                    color.Dock = DockStyle.Bottom;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnlTop.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Controls.Clear();
                    previousBtn.BackColor = Color.FromArgb(173, 130, 196);
                }
            }
        }

        private void btnSleepQuality_Click_1(object sender, EventArgs e)
        {
            if (pnlMain.Controls.Count == 0)
            {
                ActiveButton(sender);
                Panel pnlSleep = new Panel();
                pnlSleep.BackColor = Color.FromArgb(203, 164, 224);
                pnlSleep.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(pnlSleep);
                Label text = new Label();
                text.Text = "Dün gecenin uyku kalitesi";
                text.BackColor = Color.Transparent;
                text.Location = new Point(161, 119);
                text.AutoSize = true;
                text.Font = new Font("Montserrat SemiBold", 18, FontStyle.Regular);

                Panel pnlGadgets = new Panel();
                pnlGadgets.Dock = DockStyle.Bottom;
                pnlGadgets.Size = new Size(128, 50);
                pnlGadgets.BackColor = Color.FromArgb(173, 130, 196);
                pnlSleep.Controls.Add(pnlGadgets);

                createButtons();
                pnlGadgets.Controls.Add(btnAdvices);
                pnlGadgets.Controls.Add(btnSleepDetails);

                Label sleepQualityLabel = new Label();
                sleepQualityLabel.Text = "% "+ sleepQuality;
                sleepQualityLabel.Location = new Point(161, 170);
                sleepQualityLabel.BackColor = Color.Transparent;
                sleepQualityLabel.AutoSize = true;
                sleepQualityLabel.Font = new Font("Montserrat SemiBold", 22, FontStyle.Regular);

                pnlSleep.Controls.Add(text);
                pnlSleep.Controls.Add(sleepQualityLabel);

                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "sleep.png");
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(path);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                sleepQualityLabel.Parent = pb;
                text.Parent = pb;
                pnlSleep.Controls.Add(pb);
                pb.Dock = DockStyle.Fill;


            }
        }

        private void Click_Dashboard_Butt(object sender, EventArgs e)
        {
            if((sender as Button).Text == "Öneriler")
            {
                Click_Advices_Button();
            }

            if ((sender as Button).Text == "Uyku detayları")
            {
                Click_Details_Button();
            }
        }

        private void Click_Details_Button()
        {
            pnlMain.Controls.Clear();

            string _connectionString = "Data Source=SQL5109.site4now.net;Initial Catalog=db_a7efcb_atasenturk; User Id=db_a7efcb_atasenturk_admin;Password=ata45ata";

            DetailedSleepDesign dsp = new DetailedSleepDesign();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP(1) * FROM sleepdata$ ORDER BY Start DESC", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dsp.setLabelStart(reader["Start"].ToString());
                        dsp.setLabelEnd(reader["End"].ToString());
                        dsp.setLabelHeart(reader["Heart rate"].ToString());
                        dsp.setLabelSteps(reader["Activity (Steps)"].ToString());
                        sleepQuality = float.Parse(reader["Sleep quality"].ToString());
                        dsp.setLabelQuality(sleepQuality.ToString());

                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dsp.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(dsp);
        }

        private void Click_Advices_Button()
        {
            pnlMain.Controls.Clear();
            GetAdvice advice = new GetAdvice();
            string adviceStr = advice.getAdvice(sleepQuality);
            Label text = new Label();
            text.Text = adviceStr;
            text.BackColor = Color.Transparent;
            text.Location = new Point(161, 119);
            text.AutoSize = true;
            text.Font = new Font("Montserrat SemiBold", 18, FontStyle.Regular);
            pnlMain.Controls.Add(text);


        }


        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            ActiveButton(sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
        }

        void createButtons()
        {
            btnAdvices = new Button();
            btnAdvices.Text = "Öneriler";
            btnAdvices.Dock = DockStyle.Left;
            btnAdvices.FlatAppearance.BorderSize = 1;
            btnAdvices.FlatAppearance.BorderColor = Color.Black;
            btnAdvices.Font = new Font("Coolvetica", 12, FontStyle.Regular);
            btnAdvices.Size = new Size(128, 50);
            btnAdvices.FlatStyle = FlatStyle.Flat;
            btnAdvices.BackColor = Color.FromArgb(173, 130, 196);
            btnAdvices.Click += Click_Dashboard_Butt;

            btnSleepDetails = new Button();
            btnSleepDetails.Text = "Uyku detayları";
            btnSleepDetails.Dock = DockStyle.Left;
            btnSleepDetails.FlatAppearance.BorderSize = 1;
            btnSleepDetails.FlatAppearance.BorderColor = Color.Black;
            btnSleepDetails.Font = new Font("Coolvetica", 12, FontStyle.Regular);
            btnSleepDetails.Size = new Size(128, 50);
            btnSleepDetails.FlatStyle = FlatStyle.Flat;
            btnSleepDetails.BackColor = Color.FromArgb(173, 130, 196);
            btnSleepDetails.Click += Click_Dashboard_Butt;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            string _connectionString = "Data Source=SQL5109.site4now.net;Initial Catalog=db_a7efcb_atasenturk; User Id=db_a7efcb_atasenturk_admin;Password=ata45ata";

            DetailedSleepDesign dsp = new DetailedSleepDesign();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP(1) * FROM sleepdata$ ORDER BY Start DESC", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        sleepQuality = float.Parse(reader["Sleep quality"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            btnSleepQuality.PerformClick();



        }
    }
}
