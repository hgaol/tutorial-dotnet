/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using org.apache.zookeeper;

namespace Playground.zk
{
    public class ZKHelper
    {
        public static ZooKeeper? createClient(Watcher watcher, string chroot = null)
        {
            // var zk = new ZooKeeper("localhost:2181", 3000, watcher);
            var zk = new ZooKeeper("20.239.121.107:2181", 3000, watcher);

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
        
         public static async Task Create()
        {
            var mywatcher = new MyWatcher("my watcher.");
            var zk = createClient(mywatcher);

            // var ret = await zk.createAsync("/dotnet-test/eee", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT);
            // Console.WriteLine($"path: {ret}");
            // Console.WriteLine(await zk.createAsync("/dotnet-test/ppp", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.PERSISTENT));
            // Console.WriteLine(await zk.existsAsync("/", null));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/eee", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL));
            // Console.WriteLine(await zk.setDataAsync("/dotnet-test/eee", Encoding.UTF8.GetBytes("hello")));
            // var ret = await zk.getDataAsync("/shenyu/register/metadata/http/dotnet/dotnet--dotnet-template", null);
            var ret = await zk.getDataAsync("/hello1", null);
            Console.WriteLine(string.Join(" ", ret.Data));
            var ret2 = await zk.getDataAsync("/hello2", null);
            Console.WriteLine(string.Join(" ", ret2.Data));
            var ret3 = await zk.getDataAsync("/hello3", null);
            Console.WriteLine(string.Join(" ", ret3.Data));
            // Console.WriteLine(string.Join(" ", Encoding.UTF8.GetString(zk.getDataAsync("/shenyu/register/metadata/http/dotnet/dotnet--dotnet-template-hello", null).Result.Data)));
            // Console.WriteLine(Encoding.UTF8.GetString(zk.getDataAsync("/shenyu/register/metadata/http/http/http--http-hello", null).Result.Data));
            // Console.WriteLine(string.Join(" ", zk.getDataAsync("/shenyu/register/metadata/http/http/http--http-hello", null).Result.Data));
            // Console.WriteLine(string.Join(" ", zk.getDataAsync("/shenyu/register/metadata/http/http/http--http-hello", null).Result.Data));
            // Console.WriteLine(@"{"appName":"http","contextPath":"/http","path":"/http/hello","pathDesc":"spring annotation register","rpcType":"http","ruleName":"/http/hello","enabled":true,"pluginNames":[],"registerMetaData":false,"timeMillis":1651136636085}");
            // Console.WriteLine(await zk.setDataAsync("/dotnet-test/eee", Encoding.UTF8.GetBytes("hello")));
            // Console.WriteLine(await zk.setDataAsync("/dotnet-test/eee", Encoding.UTF8.GetBytes("hello")));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL_SEQUENTIAL));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL_SEQUENTIAL));
            // Console.WriteLine(await zk.createAsync("/dotnet-test/hahaha", null, ZooDefs.Ids.OPEN_ACL_UNSAFE, CreateMode.EPHEMERAL_SEQUENTIAL));
            // while (true)
            // {
                // Console.WriteLine(zk.getState());
                // Thread.Sleep(5000);
            // }
            // {"appName":"http","contextPath":"/http","path":"/http/hello","pathDesc":"spring annotation register","rpcType":"http","ruleName":"/http/hello","enabled":true,"pluginNames":[],"registerMetaData":false,"timeMillis":1651136636085}

            await zk.closeAsync();
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