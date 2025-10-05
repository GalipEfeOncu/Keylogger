using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicKeyLogger
{
    public partial class Form1 : Form
    {
        private StringBuilder buffer = new StringBuilder();
        private readonly object bufLock = new object();
        private volatile bool isSending = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void txtInput_TextChanged(object sender, EventArgs e)
        {
            lock (bufLock)
            {
                buffer.Clear();
                buffer.Append(txtInput.Text);
            }

            lblStatus.Text = $"Chars: {txtInput.Text.Length}";

            if (!checkBoxConsent.Checked) return;
            int threshold = (int)numericUpDownThreshold.Value;
            if (txtInput.Text.Length < threshold) return;

            if (isSending) return;
            await TrySendAsync();
        }

        private async Task TrySendAsync(bool force = false)
        {
            if (!checkBoxConsent.Checked && !force)
            {
                lblStatus.Text = "Gönderim izni yok.";
                return;
            }

            string content;
            lock (bufLock) { content = buffer.ToString(); }

            if (string.IsNullOrWhiteSpace(content))
            {
                lblStatus.Text = "Gönderilecek içerik yok.";
                return;
            }

            isSending = true;
            lblStatus.Text = "Gönderiliyor...";
            try
            {
                await SendEmailAsync("alici@gmail.com", "Toplanan veri", content);
                lblStatus.Text = "E-posta gönderildi.";
                lock (bufLock) buffer.Clear();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Gönderim hatası: " + ex.Message;
            }
            finally
            {
                isSending = false;
            }
        }

        private async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress("alici@gmail.com", "App Logger");
                msg.To.Add(new MailAddress(to));
                msg.Subject = subject;
                msg.Body = body;

                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("smtp-user", "smtp-password");
                    await client.SendMailAsync(msg);
                }
            }
        }
    }
}
