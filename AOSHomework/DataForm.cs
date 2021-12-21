using System.Text;
using System.Windows.Forms;

namespace AOSHomework
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, System.EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("資料排列方式");
            sb.AppendLine("30 Frame : FIFO, Optimal, ARB, Custom");
            sb.AppendLine("60 Frame : FIFO, Optimal, ARB, Custom");
            sb.AppendLine("90 Frame : FIFO, Optimal, ARB, Custom");
            sb.AppendLine("120 Frame : FIFO, Optimal, ARB, Custom");
            sb.Append("150 Frame : FIFO, Optimal, ARB, Custom");
            MessageBox.Show(sb.ToString(), "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}