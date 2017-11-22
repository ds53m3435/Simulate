using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace simulation_project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image[] manGroup = new Image[30];
        bool[] Sink = new bool[3];
        bool[] Toilet = new bool[4];
        bool[] Tosuam = new bool[5];
        Image pic;
        int floorno = 1;
        int[] prob1 = {21,21,21,2,1,1,2,2,21,31,21,21,21,21,2,2,1,2,31,21,2,2,2,1,1,1,3,31,2,21,1,1,2};
        int[] prob2 = { };
        int[] prob3 = { };
        int[] prob4 = { };
        int[] prob5 = { };
        //int angle = 0;
        int manIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            begin();
        }

        public void begin()
        {
            manIndex = 0;
            while(manIndex<30)
            {
                callMan(manIndex);
                manGroup[manIndex] = new Image();
                manGroup[manIndex] = pic;
                Canvas.SetTop(manGroup[manIndex], 850);
                Canvas.SetLeft(manGroup[manIndex], 200);
                manGroup[manIndex].RenderTransform = new RotateTransform(0);

                manIndex++;
            }
            for(int i=0;i<3;i++)
            {
                Sink[i] = true;
            }
            for (int i = 0; i < 4; i++)
            {
                Toilet[i] = true;
            }
            for (int i = 0; i < 5; i++)
            {
                Tosuam[i] = true;
            }
        }
        public void callMan(int index)
        {
            switch(index)
            {
                case 0:
                    pic = man;
                    break;
                case 1:
                    pic = man2;
                    break;
                case 2:
                    pic = man3;
                    break;
                case 3:
                    pic = man4;
                    break;
                case 4:
                    pic = man5;
                    break;
                case 5:
                    pic = man6;
                    break;
                case 6:
                    pic = man7;
                    break;
                case 7:
                    pic = man8;
                    break;
                case 8:
                    pic = man9;
                    break;
                case 9:
                    pic = man10;
                    break;
                case 10:
                    pic = man11;
                    break;
                case 11:
                    pic = man12;
                    break;
                case 12:
                    pic = man13;
                    break;
                case 13:
                    pic = man14;
                    break;
                case 14:
                    pic = man15;
                    break;
                case 15:
                    pic = man16;
                    break;
                case 16:
                    pic = man17;
                    break;
                case 17:
                    pic = man18;
                    break;
                case 18:
                    pic = man19;
                    break;
                case 19:
                    pic = man20;
                    break;
                case 20:
                    pic = man21;
                    break;
                case 21:
                    pic = man22;
                    break;
                case 22:
                    pic = man23;
                    break;
                case 23:
                    pic = man24;
                    break;
                case 24:
                    pic = man25;
                    break;
                case 25:
                    pic = man26;
                    break;
                case 26:
                    pic = man27;
                    break;
                case 27:
                    pic = man28;
                    break;
                case 28:
                    pic = man29;
                    break;
                case 29:
                    pic = man30;
                    break;
            }
        }

        
/*
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && Canvas.GetTop(man) >= 100)
            {
                moveUp();
            }
            else if (e.Key == Key.Down && Canvas.GetTop(man) < 690)
            {
                moveDown();
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(man) < 1000)
            {
                moveRight();
            }
            else if (e.Key == Key.Left && Canvas.GetLeft(man) > 50)
            {
                moveLeft();
            }
            else if(e.Key == Key.A)
            {
                useSink();
            }
            else if(e.Key == Key.S)
            {
                useToilet();
            }
            else if(e.Key== Key.D)
            {
                useTosuam();
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
            sinkTime.Interval = new TimeSpan(0, 0, 1);
            sinkTime.Start();
        }
        private void sink_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Complete:Sink");
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
            toiletTime.Interval = new TimeSpan(0, 0, 1);
            toiletTime.Start();
        }
        private void toilet_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Complete:Toilet");
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
        */
        DispatcherTimer serverTime = new DispatcherTimer();
        private void start_sim(object sender, RoutedEventArgs e)
        {
            manIndex = 0;
            //MessageBox.Show("start");
            start_btn.IsEnabled = false;
            Canvas.SetTop(man, 650);
            Canvas.SetLeft(man, 200);
            Random rnd = new Random();
            Man person = new Man(prob1[rnd.Next(0, 32)],manGroup[manIndex]);
            person.doorToSink();
            //serverTime.Tick += serverTime_Tick;
            //serverTime.Interval = new TimeSpan(0, 1, 0);
        }
        private void serverTime_Tick(object sender, EventArgs e)
        {
           
            manIndex++;
            if(manIndex>29)
            {
                manIndex = 0;
            }
            Canvas.SetTop(manGroup[manIndex], 650);
            Random rnd = new Random();
            Man person = new Man(prob1[rnd.Next(0, 32)],manGroup[manIndex]);

        }
        private void stop_sim(object sender, RoutedEventArgs e)
        {
            start_btn.IsEnabled = true;
            manIndex = 0;
            //angle = 0;
            begin();
        }
        /*

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
            count = 0;
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
            { angle = 90;
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
        */


    }
}
