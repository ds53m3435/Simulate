using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace simulation_project2
{
   
    class Man
    {
        Image man;
        Queue<Want> wantQueue = new Queue<Want>();
        int angle;
        public Man(int act,Image m)
        {
            angle = 0;
            man = m;
            if(act>99)
            {
                wantQueue.Enqueue(new Want(act / 100));
                wantQueue.Enqueue(new Want((act / 10) % 10));
                wantQueue.Enqueue(new Want(act % 10));
            }
            else if(act>9)
            {
                wantQueue.Enqueue(new Want(act / 10));
                wantQueue.Enqueue(new Want(act % 10));
            }
            else
            {
                wantQueue.Enqueue(new Want(act));
            }
        }
        public void moveUp()
        {
            if (angle != 0)
            {
                angle = 0;
                RotateTransform rt = new RotateTransform(angle);
                man.RenderTransform = rt;
            }
            else
            {
                Canvas.SetTop(man, Canvas.GetTop(man) - 100);
            }
        }
        public void moveDown()
        {
            if (angle != 180)
            {
                angle = 180;
                RotateTransform rt = new RotateTransform(angle);
                man.RenderTransform = rt;
            }
            else
            {
                Canvas.SetTop(man, Canvas.GetTop(man) + 100);
            }
        }
        public void moveLeft()
        {
            if (angle != 270)
            {
                angle = 270;
                RotateTransform rt = new RotateTransform(angle);
                man.RenderTransform = rt;
            }
            else
            {
                if (Canvas.GetLeft(man) <= 400)
                    Canvas.SetLeft(man, Canvas.GetLeft(man) - 200);
                else
                    Canvas.SetLeft(man, Canvas.GetLeft(man) - 150);
            }
        }
        public void moveRight()
        {
            if (angle != 90)
            {
                angle = 90;
                RotateTransform rt = new RotateTransform(angle);
                man.RenderTransform = rt;
            }
            else
            {
                if (Canvas.GetLeft(man) < 400)
                    Canvas.SetLeft(man, Canvas.GetLeft(man) + 200);
                else
                    Canvas.SetLeft(man, Canvas.GetLeft(man) + 150);


            }
        }

        #region usesink
        DispatcherTimer sinkTime = new DispatcherTimer();
        DispatcherTimer presinkTime = new DispatcherTimer();
        public void useSink()
        {
            angle = 0;
            RotateTransform rt = new RotateTransform(angle);
            man.RenderTransform = rt;
            Canvas.SetTop(man, Canvas.GetTop(man) - 100);
            presinkTime.Tick += presink_Tick;
            presinkTime.Interval = new TimeSpan(0, 0, 1);
            presinkTime.Start();


        }
        private void presink_Tick(object sender, EventArgs e)
        {

            presinkTime.Stop();
            presinkTime = new DispatcherTimer();
            Canvas.SetTop(man, Canvas.GetTop(man) - 70);
            sinkTime.Tick += sink_Tick;
            sinkTime.Interval = new TimeSpan(0, 0, 10);
            sinkTime.Start();
        }
        private void sink_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Complete:Sink");
            angle = 180;
            RotateTransform rt = new RotateTransform(angle);
            man.RenderTransform = rt;
            Canvas.SetTop(man, Canvas.GetTop(man) + 70);
            sinkTime.Stop();
            sinkTime = new DispatcherTimer();
        }
        #endregion

        #region usetoilet
        DispatcherTimer toiletTime = new DispatcherTimer();
        DispatcherTimer pretoiletTime = new DispatcherTimer();
        public void useToilet()
        {
            angle = 0;
            RotateTransform rt = new RotateTransform(angle);
            man.RenderTransform = rt;
            moveUp();
            pretoiletTime.Tick += pretoilet_Tick;
            pretoiletTime.Interval = new TimeSpan(0, 0, 1);
            pretoiletTime.Start();

        }
        private void pretoilet_Tick(object sender, EventArgs e)
        {
            pretoiletTime.Stop();
            pretoiletTime = new DispatcherTimer();
            Canvas.SetTop(man, Canvas.GetTop(man) - 130);
            moveDown();
            toiletTime.Tick += toilet_Tick;
            toiletTime.Interval = new TimeSpan(0, 1, 0);
            toiletTime.Start();
        }
        private void toilet_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Complete:Toilet");
            Canvas.SetTop(man, Canvas.GetTop(man) + 130);
            toiletTime.Stop();
            toiletTime = new DispatcherTimer();
        }
        #endregion

        #region usetosuam
        DispatcherTimer tosuamTime = new DispatcherTimer();
        DispatcherTimer pretosuamTime = new DispatcherTimer();
        public void useTosuam()
        {
            angle = 180;
            RotateTransform rt = new RotateTransform(angle);
            man.RenderTransform = rt;
            Canvas.SetTop(man, Canvas.GetTop(man) + 100);
            pretosuamTime.Tick += pretosuam_Tick;
            pretosuamTime.Interval = new TimeSpan(0, 0, 1);
            pretosuamTime.Start();

        }
        private void pretosuam_Tick(object sender, EventArgs e)
        {
            pretosuamTime.Stop();
            pretosuamTime = new DispatcherTimer();
            moveDown();
            tosuamTime.Tick += tosuam_Tick;
            tosuamTime.Interval = new TimeSpan(0, 0, 1);
            tosuamTime.Start();

        }
        private void tosuam_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Complete:Tosuam");
            moveUp();
            moveUp();
            tosuamTime.Stop();
            tosuamTime = new DispatcherTimer();
        }
        #endregion
        


        DispatcherTimer delay = new DispatcherTimer();
        DispatcherTimer delay2 = new DispatcherTimer();

        int count = 0;

        public void doorToSink()
        {
            delay.Tick += Sink_Tick1;
            delay.Interval = new TimeSpan(0, 0, 1);
            delay.Start();
        }
        private void Sink_Tick1(object sender, EventArgs e)
        {
            moveUp();
            count++;
            if (count == 4)
            {
                delay.Stop();
                delay = new DispatcherTimer();
                delay2.Tick += Sink_Tick2;
                delay2.Interval = new TimeSpan(0, 0, 1);
                delay2.Start();
            }
        }
        private void Sink_Tick2(object sender, EventArgs e)
        {
            angle = 90;
            man.RenderTransform = new RotateTransform(angle);
            moveRight();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            delay2.Tick += Sink_Tick3;
            delay2.Interval = new TimeSpan(0, 0, 1);
            delay2.Start();
            count = 0;
        }
        private void Sink_Tick3(object sender, EventArgs e)
        {
            useSink();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            delay2.Tick += Sink_Tick4;
            delay2.Interval = new TimeSpan(0, 0, 11);
            delay2.Start();
            count = 0;
        }
        private void Sink_Tick4(object sender, EventArgs e)
        {
            delay2.Stop();
            delay2 = new DispatcherTimer();
            count = 0;
            SinkToToilet();
        }

        public void doorToTosuam()
        {
            delay.Tick += Tosuam_Tick1;
            delay.Interval = new TimeSpan(0, 0, 1);
            delay.Start();
        }
        private void Tosuam_Tick1(object sender, EventArgs e)
        {
            moveUp();
            count++;
            if (count == 2)
            {
                count = 0;
                delay.Stop();
                delay = new DispatcherTimer();
                delay2.Tick += Tosuam_Tick2;
                delay2.Interval = new TimeSpan(0, 0, 1);
                delay2.Start();
            }
        }
        private void Tosuam_Tick2(object sender, EventArgs e)
        {
            moveRight();
            moveRight();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            delay2.Tick += Tosuam_Tick3;
            delay2.Interval = new TimeSpan(0, 0, 1);
            delay2.Start();
        }
        private void Tosuam_Tick3(object sender, EventArgs e)
        {
            useTosuam();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            count = 0;
        }


        public void doorToToilet()
        {
            count = 0;
            delay.Tick += Toilet_Tick1;
            delay.Interval = new TimeSpan(0, 0, 1);
            delay.Start();
        }
        private void Toilet_Tick1(object sender, EventArgs e)
        {
            moveUp();
            count++;
            if (count == 4)
            {
                count = 0;
                delay.Stop();
                delay = new DispatcherTimer();
                delay2.Tick += Toilet_Tick2;
                delay2.Interval = new TimeSpan(0, 0, 1);
                delay2.Start();
            }
        }
        private void Toilet_Tick2(object sender, EventArgs e)
        {
            if (angle != 90)
            {
                angle = 90;
                man.RenderTransform = new RotateTransform(angle);
            }
            moveRight();
            count++;
            if (count == 2)
            {
                count = 0;
                delay2.Stop();
                delay2 = new DispatcherTimer();
                delay2.Tick += Toilet_Tick3;
                delay2.Interval = new TimeSpan(0, 0, 1);
                delay2.Start();
            }
        }
        private void Toilet_Tick3(object sender, EventArgs e)
        {
            useToilet();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            count = 0;
        }

        public void SinkToToilet()
        {
            delay = new DispatcherTimer();
            delay2 = new DispatcherTimer();
            count = 0;
            delay.Tick += sinkToilet_Tick1;
            delay.Interval = new TimeSpan(0, 0, 1);
            delay.Start();
        }
        private void sinkToilet_Tick1(object sender, EventArgs e)
        {
            angle = 180;
            man.RenderTransform = new RotateTransform(angle);
            moveDown();
            count = 0;
            delay.Stop();
            delay = new DispatcherTimer();
            delay2.Tick += sinkToilet_Tick2;
            delay2.Interval = new TimeSpan(0, 0, 1);
            delay2.Start();
        }
        private void sinkToilet_Tick2(object sender, EventArgs e)
        {
            angle = 90;
            man.RenderTransform = new RotateTransform(angle);
            moveRight();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            delay2.Tick += sinkToilet_Tick3;
            delay2.Interval = new TimeSpan(0, 0, 1);
            delay2.Start();
            count = 0;
        }
        private void sinkToilet_Tick3(object sender, EventArgs e)
        {
            useToilet();
            delay2.Stop();
            delay2 = new DispatcherTimer();
            count = 0;
        }
    }
}
