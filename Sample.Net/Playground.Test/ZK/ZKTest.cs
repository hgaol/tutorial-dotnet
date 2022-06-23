using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using org.apache.zookeeper;
using Xunit;

namespace Playground.Test.ZK
{
    public class ZKTest
    {

        public ZooKeeper? createClient(Watcher watcher, string chroot = null)
        {
            var zk = new ZooKeeper("localhost:2181", 30000, watcher);

            Thread.Sleep(1000);//停一秒，等待连接完成
            while (zk.getState() == ZooKeeper.States.CONNECTING)
            {
                Console.WriteLine("等待连接完成...");
                Thread.Sleep(1000);
            }

            var state = zk.getState();
            if (state != ZooKeeper.States.CONNECTED && state != ZooKeeper.States.CONNECTEDREADONLY)
            {
                Console.WriteLine("连接失败：" + state);
                return null;
            }
            
            return zk;
        }
        
        // [Fact]
        public async Task Create()
        {
            var mywatcher = new MyWatcher("my watcher.");
            var zk = createClient(mywatcher);

            // var ret = await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT_SEQUENTIAL);
            // Console.WriteLine($"path: {ret}");
            // Console.WriteLine(await zk.createAsync("/dotnet-test/ppp", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT));
            Console.WriteLine(await zk.existsAsync("/dotnet-test/eee", mywatcher));
            Console.WriteLine(await zk.createAsync("/dotnet-test/eee", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL));
            Console.WriteLine(await zk.setDataAsync("/dotnet-test/eee", Encoding.UTF8.GetBytes("hello")));
            Console.WriteLine(await zk.getDataAsync("/dotnet-test/eee", mywatcher));
            // Console.WriteLine(await zk.setDataAsync("/dotnet-test/eee", Encoding.UTF8.GetBytes("hello")));
            // Console.WriteLine(await zk.setDataAsync("/dotnet-test/eee", Encoding.UTF8.GetBytes("hello")));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL_SEQUENTIAL));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL_SEQUENTIAL));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL_SEQUENTIAL));
            while (true)
            {
                Console.WriteLine(zk.getState());
                Thread.Sleep(5000);
            }
        }
    }
    
    class MyWatcher : Watcher
    {
        public string Name { get; private set; }

        public MyWatcher(string name)
        {
            this.Name = name;
        }

        public override Task process(WatchedEvent @event)
        {
            var path = @event.getPath();
            var state = @event.getState();

            Console.WriteLine($"{Name} recieve: Path-{path}     State-{@event.getState()}    Type-{@event.get_Type()}");
            return Task.CompletedTask;
        }
    }
}