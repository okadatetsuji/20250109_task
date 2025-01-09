using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20250109
{
    internal class _20250109_Prac1_岡田
    {
        static void Main(string[] args)
        {
            // ゲーム開始メッセージ
            Console.WriteLine("ゲーム開始");

            // 新しいスレッドを作成して開始
            Thread backgroundThread = new Thread(BackgroundTask);
            backgroundThread.Start();

            // メインスレッドの処理
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine("ゲーム中...");
                Thread.Sleep(1000);
            }

            // メインスレッドの終了メッセージ
            Console.WriteLine("ゲーム終了");
        }

        static void BackgroundTask()
        {
            for(int i = 1; i <= 3; i++)
            {
                Console.WriteLine("敵キャラクターが出現！");
                Thread.Sleep(5000);
            }
        }
    }
}
