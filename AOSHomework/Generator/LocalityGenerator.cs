using System;
using System.Collections.Generic;
using System.Linq;

namespace AOSHomework
{
    public sealed class LocalityGenerator : ReferenceStringGenerator
    {
        private readonly Random random;

        // 每個區間最小 Locality 個數
        public int randomLowerBound
        {
            get;
            private set;
        }

        // 每個區間最大 Locality 個數
        public int randomHigherBound
        {
            get;
            private set;
        }

        public LocalityGenerator(int referenceMin, int referenceMax, int count, int randomLowerBound, int randomHigherBound) : base(referenceMin, referenceMax, count)
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
                // 第一次隨機 : 決定區間大小 (1 / 300 ~ 1 / 120)
                int gap = random.Next(count / 300, count / 120 + 1);
                // 第二次隨機 : 產生 Locality 個數
                int localityCount = random.Next(randomLowerBound, randomHigherBound + 1);

                ISet<int> localitySet = new HashSet<int>();
                // 填滿 Locality 個數
                while (localitySet.Count < localityCount)
                {
                    // 第三次隨機 : 產生 Locality 記憶體參照字串 (不限範圍)
                    localitySet.Add(random.Next(referenceMin, referenceMax + 1));
                }

                IList<int> localityList = localitySet.ToList();
                // 將 Locality 記憶體參照字串隨機填入區間內
                for (int i = 1; i <= gap; ++i)
                {
                    referenceString.Add(localityList[random.Next(localityCount)]);
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