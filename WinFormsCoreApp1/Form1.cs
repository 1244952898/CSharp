namespace WinFormsCoreApp1
{
    public partial class Form1 : Form
    {
        private SynchronizationContext _uiContext;
        private static readonly HttpClient s_httpClient = new HttpClient();


        public Form1()
        {
            InitializeComponent();
            _uiContext = SynchronizationContext.Current;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WindowsFormsSynchronizationContext c = null;
                // 显示等待提示
                label1.Text = "Processing...";

                // 调用异步方法
                await LongRunningTask();

                // 处理完成
                label1.Text = "Done!";
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex.Message;
            }
        }

        private async Task LongRunningTask()
        {
            // 模拟长时间运行的任务
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000); // 暂停 1 秒
                Console.WriteLine($"Processing step {i + 1}...");

                // 更新 UI
                UpdateLabel($"Processing step {i + 1}...");
            }
        }

        private void UpdateLabel(string text)
        {
            // 确保在 UI 线程中更新标签
            label1.Text = text;
            //_uiContext.Post(state =>
            //{
            //    ((Label)state).Text = text;
            //    Thread.Sleep(1500);
            //}, label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SynchronizationContext sc = SynchronizationContext.Current;
            s_httpClient.GetStringAsync("https://www.cnblogs.com/xiaoxiaotank/p/13529413.html").ContinueWith(downloadTask =>
            {
                button2.Text = downloadTask.Result;
            },TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
