using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20250109
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // メインスレッドの開始メッセージ
            Console.WriteLine("メインスレッド開始（ID：{0}）",Thread.CurrentThread.ManagedThreadId);

            // 新しいスレッドを作成して開始
            Thread backgroundThread = new Thread(BackgroundTask);
            backgroundThread.Start();

            // メインスレッドの処理（数字カウント）
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"メインスレッド処理：{i}");
                Thread.Sleep(1000); // 1秒休止
            }

            // メインスレッドの終了メッセージ
            Console.WriteLine("メインスレッド終了");
        }

        // 別スレッドでの処理
        static void BackgroundTask()
        {
            Console.WriteLine("バックグラウンドスレッド開始（ID：{0}）",Thread.CurrentThread.ManagedThreadId);
            for(char c = 'A'; c <= 'E'; c++)
            {
                Console.WriteLine($"バックグラウンド処理：{c}");
                Thread.Sleep(1500); // 1.5秒休止
            }
            Console.WriteLine("バックグラウンドスレッド終了");
        }
    }
}
