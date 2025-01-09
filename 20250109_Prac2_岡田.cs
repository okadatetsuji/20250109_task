using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20250109
{
    public class _20250109_Prac2_岡田
    {
        //現在のプレイヤーのHP
        static int playerHP = 50;
        //HP操作を排他制御するためのオブジェクト
        static object lockObject = new object();
        //HP最大値
        const int MaxHP = 100;
        //HPの最小値
        const int MinHP = 0;

        static void Main()
        {
            //回復スレッドとダメージスレッドを作成
            Thread healThread = new Thread(HealRoutine);
            Thread damageThread = new Thread(DamageRoutine);
            //スレッドを開始
            healThread.Start();
            damageThread.Start();
            //スレッドの終了を待機
            healThread.Join();
            damageThread.Join();

            //最終的なHPの表示
            Console.WriteLine($"最終的なHP: {playerHP}");
        }

        //プレイヤーのHP回復する処理を行うスレッド
        static void HealRoutine()
        {
            // 回復量や待機時間をランダムにするための乱数生成器
            Random rand = new Random();

            // 回復処理を5回行う
            for (int i = 0; i < 5; i++)
            {
                // 回復量を1～10の間でランダムに決定
                int healAmount = rand.Next(1, 11);

                // 複数スレッドからの同時アクセスを防ぐために lock で囲む
                lock (lockObject)
                {
                    // HPを回復量ぶん加算
                    playerHP += healAmount;

                    // HPが上限を超えないように調整
                    if (playerHP > MaxHP)
                    {
                        playerHP = MaxHP;
                    }

                    // 回復後のHPを出力
                    Console.WriteLine($"回復アイテム使用: +{healAmount} (現在のHP: {playerHP})");
                }

                // 次の回復処理まで 0.5秒～1秒 待機
                Thread.Sleep(rand.Next(500, 1000));
            }
        }

        //プレイヤーがダメージを受ける処理を行うスレッド
        static void DamageRoutine()
        {
            // ダメージ量や待機時間をランダムにするための乱数生成器
            Random rand = new Random();

            // ダメージ処理を5回行う
            for (int i = 0; i < 5; i++)
            {
                // ダメージ量を1～10の間でランダムに決定
                int damage = rand.Next(1, 11);

                // 複数スレッドからの同時アクセスを防ぐために lock で囲む
                lock (lockObject)
                {
                    // HPをダメージ量ぶん減算
                    playerHP -= damage;

                    // HPが0未満にならないように調整
                    if (playerHP < MinHP)
                    {
                        playerHP = MinHP;
                    }

                    // ダメージ後のHPを出力
                    Console.WriteLine($"敵の攻撃: -{damage} (現在のHP: {playerHP})");
                }

                // 次のダメージ処理まで 0.5秒～1秒 待機
                Thread.Sleep(rand.Next(500, 1000));
            }
        }

    }
}
