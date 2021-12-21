using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AOSHomework
{
    public partial class MainForm : Form
    {
        // 要測試的 Frame 個數
        private static readonly int[] FRAME_TEST = new int[]
        {
            30, 60, 90, 120, 150
        };

        // 題目規格
        public static readonly int MIN_REFERENCE = 1, MAX_REFERENCE = 1200, REFERENCE_COUNT = 300000;

        // 記憶體參照字串輸出檔案名稱
        public static readonly string RANDOM_FILE = "Random.txt", LOCALITY_FILE = "Locality.txt", CUSTOM_FILE = "Custom.txt";

        // 要測試演算法
        private static readonly Type[] ALGORITHM = new Type[]
        {
            typeof(FIFOAlgorithm), typeof(OptimalAlgorithm), typeof(ARBAlgorithm), typeof(CustomAlgorithm)
        };

        // 主控台
        private static readonly ConsoleHelper console = ConsoleHelper.getInstance("高等作業系統 作業 1");

        // 統計資料 (Page Fault 次數, 中斷次數, 磁碟寫入 Page 數)
        private int[][] pageFault, interrupt, diskWrite;

        // 讀取檔案路徑
        public string file
        {
            get;
            private set;
        }

        // 瀏覽檔案
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "請選擇記憶體參照字串檔案"
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            file = ofd.FileName;
            txtPath.Text = file;
        }

        // UI 開關與狀態設定
        private void enableControl(bool enable)
        {
            btnBrowse.Enabled = btnStart.Enabled = btnConsole.Enabled
                = btnGenerate.Enabled = btnGraphData.Enabled = enable;

            pbExecute.Visible = labelExecute.Visible = !enable;
        }

        // 執行演算法
        // algorithm 要執行的演算法
        // referenceString 要測試的記憶體參照字串列表
        private void doAlgorithm(ReplacementAlgorithm algorithm, IList<int> referenceString)
        {
            Console.WriteLine($"正在執行 {algorithm.name} 演算法 Frame 數量 {algorithm.frame}");
            // 自訂演算法快取是否開啟判斷
            if (algorithm is CustomAlgorithm)
            {
                CustomAlgorithm custom = algorithm as CustomAlgorithm;
                string fileName = Path.GetFileName(file).ToLower();
                custom.preFetch = fileName == RANDOM_FILE.ToLower() || fileName == CUSTOM_FILE.ToLower();
            }
            // 載入記憶體參照字串
            foreach (int reference in referenceString)
            {
                algorithm.loadFrame(reference);
            }
            // 最佳化演算法在資料讀取完畢後才執行
            if (algorithm is OptimalAlgorithm)
            {
                OptimalAlgorithm optimal = algorithm as OptimalAlgorithm;
                optimal.end();
            }
        }

        // 輸出 2 維陣列格式
        public static string output2DArray<T>(T[][] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T[] data in array)
            {
                foreach (T value in data)
                {
                    sb.Append(value).Append(", ");
                }
                sb.Length -= 2;
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // 顯示統計原始資料 (開新視窗)
        private void btnGraphData_Click(object sender, EventArgs e)
        {
            using (DataForm form = new DataForm())
            {
                form.txtPageFault.Text = output2DArray(pageFault);
                form.txtInterrupt.Text = output2DArray(interrupt);
                form.txtDiskWrite.Text = output2DArray(diskWrite);
                form.ShowDialog();
            }
        }

        // 主控台開關
        private void btnConsole_Click(object sender, EventArgs e)
        {
            console.toggleConsole();
        }

        // 清除目前統計資料圖表 (通常用於下一個檔案測試)
        private void clearChart()
        {
            int algorithmCount = ALGORITHM.Length;
            for (int i = 0; i < algorithmCount; ++i)
            {
                chartPageFault.Series[i].Points.Clear();
                chartInterrupt.Series[i].Points.Clear();
                chartDiskWrite.Series[i].Points.Clear();
            }
        }

        // 初始化統計資料陣列
        // [測試 Frame 個數] [測試演算法個數]
        private void initArray()
        {
            int frameCount = FRAME_TEST.Length;
            pageFault = new int[frameCount][];
            interrupt = new int[frameCount][];
            diskWrite = new int[frameCount][];

            int algorithmCount = ALGORITHM.Length;
            for (int i = 0; i < frameCount; ++i)
            {
                pageFault[i] = new int[algorithmCount];
                interrupt[i] = new int[algorithmCount];
                diskWrite[i] = new int[algorithmCount];
            }
        }

        // 開始執行
        private async void btnStart_Click(object sender, EventArgs e)
        {
            // 判斷檔案是否正常
            if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
            {
                MessageBox.Show("請輸入有效檔案", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exception = false;
            int frameCount = FRAME_TEST.Length;
            int algorithmCount = ALGORITHM.Length;
            clearChart();

            enableControl(false);
            // 非同步工作，防止 UI 卡住
            await Task.Run(() =>
            {
                try
                {
                    // 讀取記憶體參照字串檔案
                    IList<int> referenceString = ReferenceStringGenerator.loadFromFile(file, REFERENCE_COUNT);
                    // 對每個 Frame 大小進行測試
                    for (int i = 0; i < frameCount; ++i)
                    {
                        int frame = FRAME_TEST[i];
                        // 對每個演算法進行測試
                        for (int j = 0; j < algorithmCount; ++j)
                        {
                            Type type = ALGORITHM[j];
                            // 反射存取 : 建立新物件
                            ReplacementAlgorithm algorithm = (ReplacementAlgorithm)Activator.CreateInstance(type, new object[] {
                                frame
                            });
                            doAlgorithm(algorithm, referenceString);
                            // 儲存統計資料
                            pageFault[i][j] = algorithm.fault;
                            interrupt[i][j] = algorithm.interrupt;
                            diskWrite[i][j] = algorithm.diskWrite;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"執行演算法時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    exception = true;
                }
            });
            enableControl(true);
            if (exception)
            {
                return;
            }

            // 繪製統計圖表
            for (int i = 0; i < frameCount; ++i)
            {
                for (int j = 0; j < algorithmCount; ++j)
                {
                    chartPageFault.Series[j].Points.AddXY(FRAME_TEST[i], pageFault[i][j]);
                    chartInterrupt.Series[j].Points.AddXY(FRAME_TEST[i], interrupt[i][j]);
                    chartDiskWrite.Series[j].Points.AddXY(FRAME_TEST[i], diskWrite[i][j]);
                }
            }
            MessageBox.Show("執行完畢", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public MainForm()
        {
            InitializeComponent();
            initArray();
            // 開啟主控台
            console.toggleConsole();
        }

        // 產生記憶體參照字串檔案
        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            // 題目規格
            const int RANDOM_LOWER_COUNT = 1, RANDOM_HIGHER_COUNT = 20;
            enableControl(false);
            // 非同步工作，防止 UI 卡住
            await Task.Run(() =>
            {
                try
                {
                    // 生成並寫入至硬碟
                    RandomGenerator randomGenerator = new RandomGenerator(MIN_REFERENCE, MAX_REFERENCE, REFERENCE_COUNT, RANDOM_LOWER_COUNT, RANDOM_HIGHER_COUNT);
                    randomGenerator.generate();
                    randomGenerator.saveToFile(RANDOM_FILE);

                    LocalityGenerator localityGenerator = new LocalityGenerator(MIN_REFERENCE, MAX_REFERENCE, REFERENCE_COUNT, RANDOM_LOWER_COUNT, RANDOM_HIGHER_COUNT);
                    localityGenerator.generate();
                    localityGenerator.saveToFile(LOCALITY_FILE);

                    CustomGenerator customGenerator = new CustomGenerator(MIN_REFERENCE, MAX_REFERENCE, REFERENCE_COUNT, FRAME_TEST[0]);
                    customGenerator.generate();
                    customGenerator.saveToFile(CUSTOM_FILE);
                    MessageBox.Show("記憶體參照字串檔案產生完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"產生記憶體參照字串時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            enableControl(true);
        }
    }
}