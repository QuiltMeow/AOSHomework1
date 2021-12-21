using System;
using System.Collections.Generic;

namespace AOSHomework
{
    // Page Fault 狀態結構
    // count 第幾筆資料
    // reference 參照字串
    // type Page Fault 狀態
    public struct PageFault
    {
        public int count, reference;
        public ReferenceType type;
    }

    // 最佳化演算法
    public sealed class OptimalAlgorithm : ReplacementAlgorithm
    {
        // 記憶體參照字串 (先載入後再進行分析)
        private readonly IList<int> referenceString;

        public OptimalAlgorithm(int frame) : base("Optimal", frame)
        {
            referenceString = new List<int>();
        }

        // 載入記憶體參照字串 (僅載入)
        public override ReferenceType loadFrame(int reference)
        {
            referenceString.Add(reference);
            return ReferenceType.LOAD_ONLY;
        }

        // 分析記憶體參照字串
        // 回傳 Page Fault 列表
        public IList<PageFault> end()
        {
            IList<PageFault> ret = new List<PageFault>();
            int total = referenceString.Count;
            for (int i = 0; i < total; ++i)
            {
                ++count;
                int reference = referenceString[i];

                // 已存在記憶體中
                if (memory.Contains(reference))
                {
                    continue;
                }

                // 發生 Page Fault
                ++fault;
                if (memory.Count < frame)
                {
                    memory.Add(reference);
                    Console.WriteLine($"第 {count} 次存取發生 Page Fault : 載入 {reference} 到記憶體");
                    ret.Add(new PageFault()
                    {
                        count = count,
                        reference = reference,
                        type = ReferenceType.PAGE_FAULT_LOAD
                    });
                    continue;
                }

                // 進行 Page Replacement
                ++interrupt;
                ++diskWrite;
                int maxPeriod = int.MinValue, maxReferenceIndex = int.MinValue;
                // 對每個目前在記憶體中的 Page 依次掃描
                // 找到最久沒有使用到的 Page 進行替換
                for (int j = 0; j < frame; ++j)
                {
                    int now = memory[j];
                    int period = 0;
                    // 掃描下次存取的時長
                    for (int k = i + 1; k < total; ++k)
                    {
                        ++period;
                        if (now == referenceString[k])
                        {
                            break;
                        }
                    }
                    if (period > maxPeriod)
                    {
                        maxPeriod = period;
                        maxReferenceIndex = j;
                    }
                }
                // 將之後最久沒使用到的替換掉
                int replace = memory[maxReferenceIndex];
                memory.RemoveAt(maxReferenceIndex);
                memory.Add(reference);
                Console.WriteLine($"第 {count} 次存取發生 Page Fault : 進行 Page Replacement {replace} (位置 {maxReferenceIndex}) -> {reference}");
                ret.Add(new PageFault()
                {
                    count = count,
                    reference = reference,
                    type = ReferenceType.PAGE_FAULT_REPLACEMENT
                });
            }
            return ret;
        }
    }
}