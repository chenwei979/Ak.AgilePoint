using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Memcached.ClientLibrary;

namespace TestMemcachedApp
{
    class Program
    {
        [STAThread]
        public static void Main(String[] args)
        {
            string[] serverlist = { "192.168.0.210:11211" };//服务器可以是多个

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);//设置连接池可用的cache服务器列表，server的构成形式是IP:PORT（如：127.0.0.1:11211）
            pool.InitConnections = 3;//初始连接数
            pool.MinConnections = 3;//最小连接数
            pool.MaxConnections = 5;//最大连接数
            pool.SocketConnectTimeout = 1000;//设置连接的套接字超时
            pool.SocketTimeout = 3000;//设置套接字超时读取
            pool.MaintenanceSleep = 30;//设置维护线程运行的睡眠时间。如果设置为0，那么维护线程将不会启动,30就是每隔30秒醒来一次

            //获取或设置池的故障标志。
            //如果这个标志被设置为true则socket连接失败，将试图从另一台服务器返回一个套接字如果存在的话。
            //如果设置为false，则得到一个套接字如果存在的话。否则返回NULL，如果它无法连接到请求的服务器。
            pool.Failover = true;

            pool.Nagle = false;//如果为false，对所有创建的套接字关闭Nagle的算法
            pool.Initialize();

            // 获得客户端实例
            MemcachedClient mc = new MemcachedClient();
            mc.EnableCompression = false;

            Console.WriteLine("------------测  试-----------");
            mc.Set("test", "my value");  //存储数据到缓存服务器，这里将字符串"my value"缓存，key 是"test"

            if (mc.KeyExists("test"))   //测试缓存存在key为test的项目
            {
                Console.WriteLine("test is Exists");
                Console.WriteLine(mc.Get("test").ToString());  //在缓存中获取key为test的项目
            }
            else
            {
                Console.WriteLine("test not Exists");
            }


            mc.Delete("test");  //移除缓存中key为test的项目

            if (mc.KeyExists("test"))
            {
                Console.WriteLine("test is Exists");
                Console.WriteLine(mc.Get("test").ToString());
            }
            else
            {
                Console.WriteLine("test not Exists");
            }
            Console.ReadLine();

            SockIOPool.GetInstance().Shutdown();  //关闭池， 关闭sockets
        }
    }
}