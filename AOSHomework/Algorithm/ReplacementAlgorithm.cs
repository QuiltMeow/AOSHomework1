using System;
using System.Collections.Generic;

namespace AOSHomework
{
    // 記憶體讀取狀況
    public enum ReferenceType
    {
        EXIST,
        PAGE_FAULT_LOAD,
        PAGE_FAULT_REPLACEMENT,
        LOAD_ONLY
    }

    // Page Replacement 演算法抽象類別
    public abstract class ReplacementAlgorithm
    {
        // 已載入到記憶體列表
        protected readonly IList<int> memory;

        // 記憶體 Frame 數量
        public int frame
        {
            get;
            set;
        }

        // 發生 Page Fault 次數
        public int fault
        {
            get;
            protected set;
        }

        // 發生中斷次數
        public int interrupt
        {
            get;
            protected set;
        }

        // 發生磁碟寫入次數
        public int diskWrite
        {
            get;
            protected set;
        }

        // 記憶體存取次數
        public int count
        {
            get;
            protected set;
        }

        // 演算法名稱
        public string name
        {
            get;
            protected set;
        }

        public ReplacementAlgorithm(string name, int frame)
        {
            if (frame <= 0 || frame >= 2100000000)
            {
                throw new Exception("無效的 Frame 數量");
            }

            this.name = name;
            this.frame = frame;
            memory = new List<int>(frame);
        }

        // 將參照字串載入到記憶體抽象方法
        // reference : 參照字串
        // 回傳 : 載入結果
        public abstract ReferenceType loadFrame(int reference);
    }
}