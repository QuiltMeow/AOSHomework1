using System;

namespace AOSHomework
{
    // 自訂記憶體參照字串產生器
    // 隨機 + Locality 方案
    // 在 Locality 區間內隨機產生限定範圍記憶體參照字串
    public sealed class CustomGenerator : ReferenceStringGenerator
    {
        private readonly Random random;

        // 將產生值限定在隨機起始值 ~ 起始值 + frame - 1 範圍內
        public int frame
        {
            get;
            private set;
        }

        public CustomGenerator(int referenceMin, int referenceMax, int count, int frame) : base(referenceMin, referenceMax, count)
        {
            this.frame = frame;
            random = new Random();
        }

        public override void generate()
        {
            // 清除原本資料
            referenceString.Clear();
            // 產生直到達到所需個數為止
            while (referenceString.Count < count)
            {
                // 第一次隨機 : 產生起始值
                int start = random.Next(referenceMin, referenceMax + 1);
                // 確定最大值
                int end = start + frame - 1;
                if (end < start || end + 1 < 0)
                {
                    throw new Exception("frame 數值錯誤");
                }

                // 如果最大值超過最大記憶體參照值，則將最大值設定為最大記憶體參照值
                if (end > referenceMax)
                {
                    end = referenceMax;
                }

                // 第二次隨機 : 決定區間大小 (1 / 300 ~ 1 / 120)
                int gap = random.Next(count / 300, count / 120 + 1);
                // 每個區間起始值
                referenceString.Add(start);
                // 將隨機限定範圍數值填入區間
                for (int i = 2; i <= gap; ++i)
                {
                    referenceString.Add(random.Next(start, end + 1));
                }
            }
            // 清除多餘資料
            int size = referenceString.Count;
            if (size > count)
            {
                referenceString.RemoveRange(count, size - count);
            }
        }
    }
}