using System;
using System.Windows;
using System.Windows.Input;

namespace RxSample
{
    /// <summary>
    /// ObservableA.xaml の相互作用ロジック
    /// </summary>
    public partial class ObservableA : Window, IObservable<string>
    {
        // オブザーバー
        public MainWindow myObserver; 

        // コンストラクタ
        public ObservableA()
        {
            InitializeComponent();

            this.MouseDown += ObservableA_MouseDown;
            this.Closing += ObservableA_Closing;
        }

        // Subscribe
        public IDisposable Subscribe(IObserver<string> observer)
        {
            this.myObserver = (MainWindow)observer;
            return null;
        }

        // MouseDownイベント
        void ObservableA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (myObserver != null)
            {
                // ObserverへOnNextを通知
                myObserver.OnNext("A");
            }
        }

        // Closingイベント
        void ObservableA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (myObserver != null)
            {
                // ObserverへOnCompleteを通知
                myObserver.OnCompleted();
            }
        }

    }
}
