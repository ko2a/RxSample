using System;
using System.Windows;

namespace RxSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window, IObserver<string>
    {
        ObservableA observableA = new ObservableA();
        ObservableB observableB = new ObservableB();

        #region 説明に関係ないところ

        // コンストラクタ
        public MainWindow()
        {
            InitializeComponent();

            this.Closing += MainWindow_Closing;

            // ボタンイベント登録
            this.SubscribeA.Click += SubscribeA_Click;
            this.SubscribeB.Click += SubscribeB_Click;

            // Observable表示
            this.observableA.Show();
            this.observableB.Show();
        }

        // MainWindow終了時に他Windowを閉じる
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.observableA.Close();
            this.observableB.Close();
        }

        #endregion

        #region ObservableをSubscribeしている箇所

        // Observable AをSubscribe
        void SubscribeA_Click(object sender, RoutedEventArgs e)
        {
            this.observableA.Subscribe(this);
        }

        // Observable BをSubscribe
        void SubscribeB_Click(object sender, RoutedEventArgs e)
        {
            this.observableB.Subscribe(this);
        }

        #endregion

        #region Observableからの通知処理

        /// オブザーバーの処理が完了したとき
        public void OnCompleted()
        {
            OutputTextBox(" [OnComplete] オブザーバーの処理が完了しました。");
        }

        /// オブザーバーがエラーを出したとき
        public void OnError(Exception ex)
        {
            OutputTextBox(" [OnError]    エラーが発生。" + ex);
        }

        /// オブザーバーから通知が来たとき
        public void OnNext(string value)
        {
            OutputTextBox(" [OnNext]     オブザーバー" + value + "が操作された。");
        }

        #endregion

        #region 説明に関係ないところ

        // テキストボックス追加処理
        private void OutputTextBox(string value)
        {
            ObserverbleLog.Text = DateTime.Now.ToString("HH:mm:ss") + value +"\n" + ObserverbleLog.Text;
            ObserverbleLog.Select(0, 0);
        }

        #endregion
    }
}
