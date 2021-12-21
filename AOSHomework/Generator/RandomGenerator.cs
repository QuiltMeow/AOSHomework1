using System;

namespace AOSHomework
{
    // 隨機記憶體參照字串產生器
    public sealed class RandomGenerator : ReferenceStringGenerator
    {
        private readonly Random random;

        // 每個區間最小產生連續數字個數
        public int randomLowerBound
        {
            get;
            private set;
        }

        // 每個區間最大產生連續數字個數
        public int randomHigherBound
        {
            get;
            private set;
        }

        public RandomGenerator(int referenceMin, int referenceMax, int count, int randomLowerBound, int randomHigherBound) : base(referenceMin, referenceMax, count)
        {
            if (randomHigherBound >= 2100000000)
            {
                throw new Exception("無效的邊界值");
            }

            this.randomLowerBound = randomLowerBound;
            this.randomHigherBound = randomHigherBound;
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
                // 第二次隨機 : 產生連續值
                int continueTime = random.Next(randomLowerBound, randomHigherBound + 1);

                int now = start;
                // 連續循環
                for (int i = 1; i <= continueTime; ++i)
                {
                    referenceString.Add(now);
                    // 如果產生數值超出最大值，則回到最小值
                    if (++now > referenceMax)
                    {
                        now = referenceMin;
                    }
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