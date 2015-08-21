using System;
using System.Windows;
using System.Windows.Input;

namespace RxSample
{
    /// <summary>
    /// ObservableB.xaml の相互作用ロジック
    /// </summary>
    public partial class ObservableB : Window, IObservable<string>
    {
        // オブザーバー
        public MainWindow myObserver;

        // コンストラクタ
        public ObservableB()
        {
            InitializeComponent();

            this.MouseDown += ObservableB_MouseDown;
            this.Closing += ObservableB_Closing;
        }

        // Subscribe
        public IDisposable Subscribe(IObserver<string> observer)
        {
            myObserver = (MainWindow)observer;
            return null;
        }

        // MouseDownイベント
        void ObservableB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (myObserver != null)
            {
                // ObserverへOnNextを通知
                myObserver.OnNext("B");
            }
        }

        // Closingイベント
        void ObservableB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (myObserver != null)
            {
                // ObserverへOnCompleteを通知
                myObserver.OnCompleted();
            }
        }
    }
}
