using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 库存管理系统
{
    class Time
    {
        public static void setTimeout(double interval, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
           {
               timer.Enabled = false;
               action();
           };
            timer.Enabled = true;
        }
    }
}
