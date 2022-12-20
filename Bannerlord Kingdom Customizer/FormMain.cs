using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Bannerlord_Kingdom_Customizer
{
    public partial class FormMain : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await Setup();
        }

        private async Task Setup()
        {
            await Task.Run(() =>
            {
                Application.EnableVisualStyles();

                MainMenu.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());

                List<string[]> items = new List<string[]> { new string[] { "New", "Open" }, new string[] { "New", "Open" } };
                ToolStripMenuItem fileToolStripMenuItem = new ToolStripMenuItem() { Text = "File" };
                MainMenuStrip.Items.Add(fileToolStripMenuItem);

                foreach (var item in items)
                    foreach (var subitem in item)
                        fileToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(subitem));

                //fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripMenuItem[] { new ToolStripMenuItem("New") });
            });
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public class CustomToolStripSeparator : ToolStripSeparator
    {
        public CustomToolStripSeparator() => Paint += CustomToolStripSeparator_Paint;

        private void CustomToolStripSeparator_Paint(object sender, PaintEventArgs e)
        {
            // Get the separator's width and height.
            ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;
            int width = toolStripSeparator.Width;
            int height = toolStripSeparator.Height;
            //Color foreColor = Color.Blue;
            Color backColor = Color.FromArgb(255, 200, 200, 200);
            Color foreColor = Color.FromArgb(255, 220, 220, 220);

            // Fill the background.
            e.Graphics.FillRectangle(new SolidBrush(backColor), 0, 0, width, height);
            // Draw the line.
            e.Graphics.DrawLine(new Pen(foreColor), 4, height / 2, width - 4, height / 2);
        }
    }

    class MenuColorTable : ProfessionalColorTable
    {
        public MenuColorTable()
        {
            base.UseSystemColors = false;
        }
        public override Color MenuBorder
        {
            get { return Color.Fuchsia; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.DarkViolet; }
        }
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(255, 200, 200, 200); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(255, 190, 190, 190); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(255, 180, 180, 180); }
        }
        public override Color MenuStripGradientBegin
        {
            get { return Color.FromArgb(255, 190, 190, 190); }
        }
        public override Color MenuStripGradientEnd
        {
            get { return Color.FromArgb(255, 180, 180, 180); }
        }
    }
}