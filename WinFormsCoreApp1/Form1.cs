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
                // ��ʾ�ȴ���ʾ
                label1.Text = "Processing...";

                // �����첽����
                await LongRunningTask();

                // �������
                label1.Text = "Done!";
            }
            catch (Exception ex)
            {
                label1.Text = "Error: " + ex.Message;
            }
        }

        private async Task LongRunningTask()
        {
            // ģ�ⳤʱ�����е�����
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000); // ��ͣ 1 ��
                Console.WriteLine($"Processing step {i + 1}...");

                // ���� UI
                UpdateLabel($"Processing step {i + 1}...");
            }
        }

        private void UpdateLabel(string text)
        {
            // ȷ���� UI �߳��и��±�ǩ
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
