using System;

namespace AOSHomework
{
    // 先進先出 (FIFO) 演算法
    public sealed class FIFOAlgorithm : ReplacementAlgorithm
    {
        public FIFOAlgorithm(int frame) : base("FIFO", frame)
        {
        }

        public override ReferenceType loadFrame(int reference)
        {
            ++count;
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

            // 將最早進來的 Page 替換掉
            int replace = memory[0];
            memory.RemoveAt(0);
            memory.Add(reference);
            Console.WriteLine($"第 {count} 次存取發生 Page Fault : 進行 Page Replacement {replace} -> {reference}");
            return ReferenceType.PAGE_FAULT_REPLACEMENT;
        }
    }
}