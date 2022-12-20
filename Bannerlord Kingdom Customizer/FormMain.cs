using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Bannerlord_Kingdom_Customizer
{
    public partial class FormMain : MaterialForm
    {
        private MaterialSkinManager themeManager = MaterialSkinManager.Instance;

        public FormMain()
        {
            InitializeComponent();

            themeManager.Theme = MaterialSkinManager.Themes.DARK;
            themeManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green900, Primary.Green500, Accent.Green400, TextShade.WHITE);
        }
    }
}