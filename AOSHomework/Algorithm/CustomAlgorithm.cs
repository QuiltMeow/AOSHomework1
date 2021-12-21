using System;

namespace AOSHomework
{
    // 自訂演算法
    // 在特定條件下開啟快取預先載入連續記憶體參照字串
    // 否則則將記憶體最中間位置進行 Page Replacement
    public sealed class CustomAlgorithm : ReplacementAlgorithm
    {
        // 是否啟用快取
        public bool preFetch
        {
            get;
            set;
        }

        public CustomAlgorithm(int frame) : base("Custom", frame)
        {
        }

        public override ReferenceType loadFrame(int reference)
        {
            ++count;
            // 使用快取
            if (preFetch)
            {
                // 已存在記憶體中
                if (memory.Contains(reference))
                {
                    return ReferenceType.EXIST;
                }

                ReferenceType ret = memory.Count > 0 ? ReferenceType.PAGE_FAULT_REPLACEMENT : ReferenceType.PAGE_FAULT_LOAD;
                ++fault;
                ++interrupt;
                // 發生 Page Fault 時，將目前記憶體內所有資料寫回硬碟並清空
                int toDisk = memory.Count;
                diskWrite += toDisk;
                memory.Clear();

                // 載入連續記憶體參照字串直到 Frame 放滿
                for (int i = 0; i < frame; ++i)
                {
                    memory.Add(reference + i);
                }
                Console.WriteLine($"第 {count} 次存取發生 Page Fault : 載入 {reference} ~ {memory[memory.Count - 1]} 到記憶體 (替換 {toDisk} 個)");
                return ret;
            }
            // 不使用快取
            else
            {
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

                // 將位於記憶體中間位置的 Page 替換掉
                int index = frame / 2;
                int replace = memory[index];
                memory.RemoveAt(index);
                memory.Add(reference);
                Console.WriteLine($"第 {count} 次存取發生 Page Fault : 進行 Page Replacement {replace} (位置 {index}) -> {reference}");
                return ReferenceType.PAGE_FAULT_REPLACEMENT;
            }
        }
    }
}