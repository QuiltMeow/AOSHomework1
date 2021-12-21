using System;
using System.Collections.Generic;
using System.IO;

namespace AOSHomework
{
    // 記憶體參照字串檔案產生器抽象類別
    public abstract class ReferenceStringGenerator
    {
        // 產生的記憶體參照字串列表
        protected readonly List<int> referenceString;

        // 參照字串最小值
        public int referenceMin
        {
            get;
            protected set;
        }

        // 參照字串最大值
        public int referenceMax
        {
            get;
            protected set;
        }

        // 參照字串總數
        public int count
        {
            get;
            protected set;
        }

        public ReferenceStringGenerator(int referenceMin, int referenceMax, int count)
        {
            if (referenceMax > 2100000000 || count > 2100000000 || count < 10)
            {
                throw new Exception("無效的邊界值");
            }

            this.referenceMin = referenceMin;
            this.referenceMax = referenceMax;
            this.count = count;
            referenceString = new List<int>();
        }

        // 產生參照字串抽象方法
        public abstract void generate();

        // 將參照字串儲存到檔案
        // path : 儲存路徑
        public void saveToFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < count; ++i)
                    {
                        int reference = referenceString[i];
                        sw.Write($"{reference}");
                        if (i < count - 1)
                        {
                            sw.Write(", ");
                        }
                    }
                }
            }
        }

        // 載入記憶體參照字串檔案
        // path : 檔案路徑
        // 回傳值 : 記憶體參照字串列表
        public static IList<int> loadFromFile(string path)
        {
            IList<int> ret = new List<int>();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string read = sr.ReadToEnd();
                    // 字串切割
                    string[] data = read.Split(new string[] {
                        ", "
                    }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string value in data)
                    {
                        ret.Add(int.Parse(value));
                    }
                }
            }
            return ret;
        }

        // 載入記憶體參照字串檔案並檢查個數
        public static IList<int> loadFromFile(string path, int count)
        {
            IList<int> ret = loadFromFile(path);
            if (ret.Count != count)
            {
                throw new Exception("載入檔案個數錯誤");
            }
            return ret;
        }
    }
}