using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowflak
{
    class IdWorker
    {
        //机器标识位数
        private const int WORKER_ID_BITS = 4;
        //机器标识位的最大值
        private const long MAX_WORKER_ID = -1L ^ -1L << WORKER_ID_BITS;
        //毫秒内自增位
        private const int SEQUENCE_BITS = 10;
        //自增位最大值
        private const long SEQUENCE_Mask = -1L ^ -1L << SEQUENCE_BITS;
        private const long twepoch = 1398049504651L;
        //时间毫秒值向左偏移位
        private const int timestampLeftShift = SEQUENCE_BITS + WORKER_ID_BITS;
        //机器标识位向左偏移位
        private const int WORKER_ID_SHIFT = SEQUENCE_BITS;
        private static readonly DateTime START_TIME = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        private static readonly object LOCK = new object();
        private long sequence = 0L;
        private long lastTimestamp = -1L;
        private long workerId;
        public IdWorker(long workerId)
        {
            if (workerId > MAX_WORKER_ID || workerId < 0)
            {
                throw new ArgumentException(string.Format("worker id can't be greater than {0} or less than 0", MAX_WORKER_ID));
            }
            this.workerId = workerId;
        }
        /// <summary>
        /// 获取下一个id值
        /// </summary>
        /// <returns></returns>
        public long NextId()
        {
            lock (LOCK)
            {
                long timestamp = TimeGen();
                //当前时间小于上一次时间，错误
                if (timestamp < this.lastTimestamp)
                {
                    throw new Exception(string.Format("Clock moved backwards.  Refusing to generate id for %d milliseconds", lastTimestamp - timestamp));
                }
                //当前毫秒内
                if (this.lastTimestamp == timestamp)
                {
                    //+1 求余
                    this.sequence = (this.sequence + 1) & SEQUENCE_Mask;
                    //当前毫秒内计数满了，等待下一秒
                    if (this.sequence == 0)
                    {
                        timestamp = tilNextMillis(lastTimestamp);
                    }
                }
                else      //不是当前毫秒内
                {
                    this.sequence = 0;   //重置当前毫秒计数
                }
                this.lastTimestamp = timestamp;
                //当前毫秒值 | 机器标识值 | 当前毫秒内自增值
                long nextId = ((timestamp - twepoch << timestampLeftShift))
                | (this.workerId << WORKER_ID_SHIFT) | (this.sequence);
                return nextId;
            }
        }
        /// <summary>
        /// 等待下一个毫秒
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private long tilNextMillis(long lastTimestamp)
        {
            long timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }
            return timestamp;
        }
        /// <summary>
        /// 获取当前时间的Unix时间戳
        /// </summary>
        /// <returns></returns>
        private long TimeGen()
        {
            return (DateTime.UtcNow.Ticks - START_TIME.Ticks) / 10000;
        }
    }
}
