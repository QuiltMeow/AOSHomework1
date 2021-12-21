using System;
using System.Collections.Generic;
using System.Linq;

namespace AOSHomework
{
    // ARB 演算法
    public sealed class ARBAlgorithm : ReplacementAlgorithm
    {
        // 目前在記憶體中的 Page ARB 表 (8 Bit)
        private readonly IDictionary<int, byte> ARB;

        // 硬體設定的 Reference Bit
        private readonly ISet<int> referenceBit;

        public const int SPLIT = 3;

        // 模擬程式採用固定記憶體存取次數後醒來一次，用來假設每次存取時間皆相同
        public int wakeUpInstruction
        {
            get;
            private set;
        }

        public ARBAlgorithm(int frame) : base("ARB", frame)
        {
            // 每執行一定指令後 OS 需要起來一次，這裡依照 frame 動態調整
            wakeUpInstruction = frame / SPLIT;
            ARB = new Dictionary<int, byte>();
            referenceBit = new HashSet<int>();
        }

        public override ReferenceType loadFrame(int reference)
        {
            // OS 該醒來維護 ARB 表時
            if (++count % wakeUpInstruction == 0)
            {
                ++interrupt;
                doARB();
            }

            // 設定 Reference Bit
            referenceBit.Add(reference);
            // 已存在記憶體中
            if (memory.Contains(reference))
            {
                // 放到佇列最後面
                memory.Remove(reference);
                memory.Add(reference);
                return ReferenceType.EXIST;
            }

            // 發生 Page Fault
            ++fault;
            if (memory.Count < frame)
            {
                memory.Add(reference);
                Console.WriteLine($"第 {count} 次存取發生 Page Fault : 載入 {reference} 到記憶體");
                return ReferenceType.PAGE_FAULT_LOAD;
            }

            // 進行 Page Replacement
            ++interrupt;
            ++diskWrite;

            // 將 ARB 表中最小的 (也就是經過很久沒有存取) 替換掉
            int replace = processMinARB();
            int index = memory.IndexOf(replace);
            memory.RemoveAt(index);
            memory.Add(reference);
            Console.WriteLine($"第 {count} 次存取發生 Page Fault : 進行 Page Replacement {replace} (位置 {index}) -> {reference}");
            return ReferenceType.PAGE_FAULT_REPLACEMENT;
        }

        // 抓出目前 ARB 表中最小值的記憶體參照字串並移除不存在與取出項目
        // 傳回值 : ARB 中最小值的記憶體參照字串
        private int processMinARB()
        {
            IDictionary<int, byte> copy = ARB.ToDictionary(entry => entry.Key, entry => entry.Value);
            // 移除 OS 未醒來這段期間內被替換出去的記憶體參照字串紀錄
            foreach (KeyValuePair<int, byte> pair in copy)
            {
                int reference = pair.Key;
                if (!memory.Contains(reference))
                {
                    ARB.Remove(reference);
                }
            }

            // 如果 ARB 表目前沒有紀錄則傳回記憶體第一筆資料
            if (ARB.Count <= 0)
            {
                return memory[0];
            }

            // 取得最小值與最小值的記憶體參照字串
            int minKey = int.MaxValue, minValue = int.MaxValue;
            foreach (KeyValuePair<int, byte> pair in ARB)
            {
                int value = pair.Value;
                if (value < minValue)
                {
                    minKey = pair.Key;
                    minValue = value;
                }
            }
            // 移除被取出來的紀錄 (將被替換掉)
            ARB.Remove(minKey);
            return minKey;
        }

        // 維護 ARB 表
        private void doARB()
        {
            IDictionary<int, byte> copy = ARB.ToDictionary(entry => entry.Key, entry => entry.Value);
            // 將目前 ARB 表中每一個項目數值向右位移 1 Bit
            foreach (KeyValuePair<int, byte> pair in copy)
            {
                byte value = pair.Value;
                value >>= 1;
                ARB[pair.Key] = value;
            }

            // 對目前 Reference Bit 列表進行處理
            foreach (int reference in referenceBit)
            {
                // 如果仍存在記憶體中
                if (memory.Contains(reference))
                {
                    // 將 ARB 表中該 Page 數值最高位設定為 1
                    if (ARB.ContainsKey(reference))
                    {
                        ARB[reference] |= 128;
                    }
                    else
                    {
                        ARB[reference] = 128;
                    }
                }
            }
            // 清空 Reference Bit 列表
            referenceBit.Clear();
        }
    }
}