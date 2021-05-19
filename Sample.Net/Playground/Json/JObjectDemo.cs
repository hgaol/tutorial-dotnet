using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// https://www.newtonsoft.com/json/help/html/Introduction.htm
/// </summary>
namespace Playground.Json
{
    public class JObjectDemo
    {
        public static void Run()
        {
            // demo1();
            demo2();
            Console.ReadKey();
        }

        // https://www.newtonsoft.com/json/help/html/ParsingLINQtoJSON.htm
        private static void demo1()
        {
            JObject o = JObject.Parse(@"{
  'CPU': 'Intel',
  'Drives': [
    'DVD read/writer',
    '500 gigabyte hard drive'
  ]
}");

            string cpu = (string)o["CPU"];
            // Intel

            string firstDrive = (string)o["Drives"][0];
            // DVD read/writer

            List<string> allDrives = o["Drives"].Select(t => (string)t).ToList();
            // DVD read/writer
            // 500 gigabyte hard drive

            string json = @"[
  ""Small"",
  ""Medium"",
  ""Large""
]";
            JArray a = JArray.Parse(json);

            Console.WriteLine();
        }


        private static void demo2()
        {
            JArray a = JArray.Parse(@"
[
        {
            ""Id"": ""69d105cb-8892-4c11-98ac-08891dfd93c4"",
            ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
            ""Name"": ""Business Development"",
            ""NodeType"": ""Division"",
            ""Path"": null,
            ""Tags"": """",
            ""Status"": ""Active"",
            ""Created"": ""2017-02-09T22:49:30.5437409Z"",
            ""CreatedBy"": ""mmaitre@microsoft.com"",
            ""Modified"": ""2017-02-09T22:49:30.5437409Z"",
            ""ModifiedBy"": ""mmaitre@microsoft.com"",
            ""ChildrenCount"": 4,
            ""Children"": [
                {
                    ""Id"": ""f254311b-be8c-4c5d-823b-4064ed03b78e"",
                    ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                    ""Name"": ""BD_Lost_Subscriptions"",
                    ""NodeType"": ""Organization"",
                    ""Path"": null,
                    ""Tags"": """",
                    ""Status"": ""Active"",
                    ""Created"": ""2020-06-26T19:38:49.2957033Z"",
                    ""CreatedBy"": ""CN=validationengine.servicetree.msftcloudes.com"",
                    ""Modified"": ""2020-06-26T19:38:49.2957033Z"",
                    ""ModifiedBy"": ""CN=validationengine.servicetree.msftcloudes.com"",
                    ""ChildrenCount"": 1,
                    ""Children"": [
                        {
                            ""Id"": ""f4c9e35e-c881-46b7-9d83-9abfc86b8817"",
                            ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                            ""Name"": ""Lost_Subscriptions"",
                            ""NodeType"": ""ServiceGroup"",
                            ""Path"": null,
                            ""Tags"": """",
                            ""Status"": ""Active"",
                            ""Created"": ""2020-06-26T19:44:56.1400933Z"",
                            ""CreatedBy"": ""CN=validationengine.servicetree.msftcloudes.com"",
                            ""Modified"": ""2020-06-26T19:44:56.1400933Z"",
                            ""ModifiedBy"": ""CN=validationengine.servicetree.msftcloudes.com"",
                            ""ChildrenCount"": 0,
                            ""Children"": []
                        }
                    ]
                },
                {
                    ""Id"": ""f58fc140-9310-4041-a890-135e93f8c402"",
                    ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                    ""Name"": ""Business Development Corporate"",
                    ""NodeType"": ""Organization"",
                    ""Path"": null,
                    ""Tags"": ""for dynamics crm instance "",
                    ""Status"": ""Active"",
                    ""Created"": ""2018-01-10T22:53:57.4244278Z"",
                    ""CreatedBy"": ""andrewj@microsoft.com"",
                    ""Modified"": ""2020-07-27T21:56:42.0959145Z"",
                    ""ModifiedBy"": ""stephlew@microsoft.com"",
                    ""ChildrenCount"": 1,
                    ""Children"": [
                        {
                            ""Id"": ""5e4ef350-5660-4692-9981-887522a84cc6"",
                            ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                            ""Name"": ""CorporateBDCRM"",
                            ""NodeType"": ""ServiceGroup"",
                            ""Path"": null,
                            ""Tags"": """",
                            ""Status"": ""Active"",
                            ""Created"": ""2018-01-10T22:54:59.3604326Z"",
                            ""CreatedBy"": ""andrewj@microsoft.com"",
                            ""Modified"": ""2018-01-10T22:54:59.3604326Z"",
                            ""ModifiedBy"": ""andrewj@microsoft.com"",
                            ""ChildrenCount"": 0,
                            ""Children"": []
                        }
                    ]
                },
                {
                    ""Id"": ""b186a75c-f750-493c-9117-1c5a74bd57ef"",
                    ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                    ""Name"": ""Cloud, Experiences, and Devices -US"",
                    ""NodeType"": ""Organization"",
                    ""Path"": null,
                    ""Tags"": """",
                    ""Status"": ""Active"",
                    ""Created"": ""2017-07-26T19:28:27.4102153Z"",
                    ""CreatedBy"": ""mmaitre@microsoft.com"",
                    ""Modified"": ""2020-08-04T17:50:45.6979952Z"",
                    ""ModifiedBy"": ""stephlew@microsoft.com"",
                    ""ChildrenCount"": 2,
                    ""Children"": [
                        {
                            ""Id"": ""17a18880-67dd-43db-b2d0-8a89420c2734"",
                            ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                            ""Name"": ""AI & Ecosystem"",
                            ""NodeType"": ""ServiceGroup"",
                            ""Path"": null,
                            ""Tags"": """",
                            ""Status"": ""Active"",
                            ""Created"": ""2017-06-27T05:14:49.2702801Z"",
                            ""CreatedBy"": ""mmaitre@microsoft.com"",
                            ""Modified"": ""2020-08-04T17:55:06.8539139Z"",
                            ""ModifiedBy"": ""stephlew@microsoft.com"",
                            ""ChildrenCount"": 0,
                            ""Children"": []
                        },
                        {
                            ""Id"": ""bb989437-0727-422c-92e1-6908ad9fbaa6"",
                            ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                            ""Name"": ""Emerging Markets SG"",
                            ""NodeType"": ""ServiceGroup"",
                            ""Path"": null,
                            ""Tags"": """",
                            ""Status"": ""Active"",
                            ""Created"": ""2017-07-27T19:07:22.6117012Z"",
                            ""CreatedBy"": ""mmaitre@microsoft.com"",
                            ""Modified"": ""2017-07-27T19:07:22.6117012Z"",
                            ""ModifiedBy"": ""mmaitre@microsoft.com"",
                            ""ChildrenCount"": 0,
                            ""Children"": []
                        }
                    ]
                },
                {
                    ""Id"": ""1edfbc5c-944d-451e-ba19-3cfaa0a8b9a6"",
                    ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                    ""Name"": ""Microsoft's Venture Fund - M12"",
                    ""NodeType"": ""Organization"",
                    ""Path"": null,
                    ""Tags"": """",
                    ""Status"": ""Active"",
                    ""Created"": ""2019-12-03T19:37:02.2173475Z"",
                    ""CreatedBy"": ""askim@microsoft.com"",
                    ""Modified"": ""2019-12-03T19:37:02.2173475Z"",
                    ""ModifiedBy"": ""askim@microsoft.com"",
                    ""ChildrenCount"": 1,
                    ""Children"": [
                        {
                            ""Id"": ""9ca959ea-4a2d-4307-a1e5-65b06f3eb3fd"",
                            ""ParentId"": ""00000000-0000-0000-0000-000000000000"",
                            ""Name"": ""M12 Service Group"",
                            ""NodeType"": ""ServiceGroup"",
                            ""Path"": null,
                            ""Tags"": """",
                            ""Status"": ""Active"",
                            ""Created"": ""2019-12-03T19:59:49.4601348Z"",
                            ""CreatedBy"": ""askim@microsoft.com"",
                            ""Modified"": ""2019-12-03T19:59:49.4601348Z"",
                            ""ModifiedBy"": ""askim@microsoft.com"",
                            ""ChildrenCount"": 0,
                            ""Children"": []
                        }
                    ]
                }
            ]
        }]
");
            var json = recur(a);

            Console.WriteLine(JsonConvert.SerializeObject(json));
        }

        private static List<ServiceTree> recur(JArray a)
        {
            return a.Select(st =>
            {
                ServiceTree ret = new ServiceTree
                {
                    id = (string)st["Id"],
                    name = (string) st["Name"],
                    type = (string) st["NodeType"],
                    status = (string) st["Status"],
                    children = recur((JArray)st["Children"]),
                };

                return ret;
            }).ToList();

        }

        class ServiceTree
        {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public List<ServiceTree> children { get; set; }
        }
    }
}