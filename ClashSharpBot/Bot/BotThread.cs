using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClashSharpBot.Bot
{
    class BotThread
    {
        private static Thread Thread = null;
        private static ManualResetEvent WaitEvent = new ManualResetEvent(false);
        private static bool _work;

        // Packages as Tasks
        private static Task[] PackagesTasks = new Task[]
        {
            CreateTask(new Action(Packages.Startup.ZoomOut.Execute)),
            CreateTask(new Action(Packages.Startup.CollectResource.Execute)),
        };

        private static Task CreateTask(Action action) // Im Lazy to Write "new Task(bla bla)"
        {
            return new Task(action);
        }

        public static bool Work
        {
            get
            {
                return _work;
            }
            set
            {
                if(value)
                {
                    if(Thread == null)
                    {
                        Thread = new Thread(new ThreadStart(botThread));
                        Thread.IsBackground = true;
                        Thread.Start();
                    }
                    WaitEvent.Set();
                    _work = true;
                    return;
                }

                _work = false;
            }
        }

        private static void botThread()
        {
            while(true)
            {
                if(!_work)
                {
                    WaitEvent.WaitOne();
                    WaitEvent.Reset();
                }

                foreach(Task task in PackagesTasks)
                {
                    if (!_work)
                        break;

                    // Execute Package
                    task.Start();

                    // Wait for Package to Complete
                    task.Wait();
                }
            }
        }
    }
}
