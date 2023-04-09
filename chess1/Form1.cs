using System;
using System.Collections.Generic;
using System.ComponentModel;//////------------        
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace chess1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //groupBox1.BackColor = Color.Green;
        }
        static public int[,] table = new int[8, 8];//مصفوفة تمثل رقعة الشطرنج
        static public int x, y,  /*  الاحداثيات الجديدة  */
            x2, y2,      /*  الاحداثيات القديمة  */
            n,      /*  القطعة التي نريد تحريكها */
            turn = 1,  /*  الدور */
            cc     /* للتأكد من ان الطريق خال */
            ,j,i,
            k, kk,       /* للتأكد ان الملك موجود */
            click = 0,         /* لمعرفة النقرة الاولى اوالثانية  */
            check = 0;        /* للتأكد ان التحرك صحيح */

        public void start()   //  تابع لتوزيع الاحجار عندبدأاللعب
        {
          
            //     نستدعيه مرة واحدة فقط عند بداية اللعبة
            table = new int[8, 8] 
            {                   
            {1,2,3,4,5,3,2,1},//      القطع البيض :  قلعة=1  حصان=2  فيل=3  وزير=4  ملك=5  جندي=6  
            {6,6,6,6,6,6,6,6},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {12,12,12,12,12,12,12,12},
            {7,8,9,10,11,9,8,7}, //    القطع السود :  قلعة=7  حصان=8  فيل=9  وزير=10  ملك=11  جندي=12
            };

            timer1.Enabled = true;
            click = 0; turn = 1; n = 0;
        }  

   
        //===========================================================================================
        public void drawing()
        {
        
             
            //------------------ Hx1-------------------------------
           
            if (table[0, 0] == 0) { pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0,0]==1)	  {pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif");}
            else if (table[0,0]==2)	  {pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif");}
            else if (table[0, 0] == 3){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif");}
            else if (table[0, 0] == 4){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif");}
            else if (table[0, 0] == 5){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif");}
            else if (table[0, 0] == 6){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif");}
            else if (table[0, 0] == 7){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif");}
            else if (table[0, 0] == 8){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif");}
            else if (table[0, 0] == 9){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif");}
            else if (table[0, 0] ==10){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif");}
            else if (table[0, 0] ==11){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif");}
            else if (table[0, 0] ==12){pictureBoxH1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif");}
            //-------------------Hx2-------------------------------
            if      (table[0, 1] == 0) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 1] == 1) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 1] == 2) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 1] == 3) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 1] == 4) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 1] == 5) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 1] == 6) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 1] == 7) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 1] == 8) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 1] == 9) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 1] == 10) { pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 1] == 11){ pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 1] == 12){ pictureBoxH2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Hx3-------------------------------
            if (table[0, 2] == 0)      { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 2] == 1) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 2] == 2) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 2] == 3) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 2] == 4) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 2] == 5) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 2] == 6) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 2] == 7) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 2] == 8) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 2] == 9) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 2] == 10) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 2] == 11) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 2] == 12) { pictureBoxH3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Hx4-------------------------------
            if (table[0, 3] == 0) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 3] == 1) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 3] == 2) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 3] == 3) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 3] == 4) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 3] == 5) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 3] == 6) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 3] == 7) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 3] == 8) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 3] == 9) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 3] == 10) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 3] == 11) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 3] == 12) { pictureBoxH4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Hx5-------------------------------
            if (table[0, 4] == 0) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 4] == 1) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 4] == 2) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 4] == 3) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 4] == 4) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 4] == 5) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 4] == 6) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 4] == 7) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 4] == 8) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 4] == 9) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 4] == 10) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 4] == 11) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 4] == 12) { pictureBoxH5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Hx6-------------------------------
            if (table[0, 5] == 0) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 5] == 1) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 5] == 2) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 5] == 3) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 5] == 4) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 5] == 5) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 5] == 6) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 5] == 7) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 5] == 8) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 5] == 9) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 5] == 10) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 5] == 11) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 5] == 12) { pictureBoxH6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Hx7-------------------------------
            if (table[0, 6] == 0) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 6] == 1) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 6] == 2) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 6] == 3) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 6] == 4) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 6] == 5) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 6] == 6) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 6] == 7) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 6] == 8) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 6] == 9) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 6] == 10) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 6] == 11) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 6] == 12) { pictureBoxH7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Hx8-------------------------------
            if (table[0, 7] == 0) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[0, 7] == 1) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[0, 7] == 2) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[0, 7] == 3) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[0, 7] == 4) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[0, 7] == 5) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[0, 7] == 6) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[0, 7] == 7) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[0, 7] == 8) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[0, 7] == 9) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 7] == 10) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[0, 7] == 11) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[0, 7] == 12) { pictureBoxH8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
           // =============================================================================================
            //------------------ Gx1       
            if (table[1, 0] == 0) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 0] == 1) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 0] == 2) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 0] == 3) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 0] == 4) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 0] == 5) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 0] == 6) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 0] == 7) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 0] == 8) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 0] == 9) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 0] == 10) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 0] == 11) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 0] == 12) { pictureBoxG1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx2-------------------------------
            if (table[1, 1] == 0) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 1] == 1) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 1] == 2) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 1] == 3) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 1] == 4) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 1] == 5) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 1] == 6) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 1] == 7) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 1] == 8) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 1] == 9) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 1] == 10) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 1] == 11) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 1] == 12) { pictureBoxG2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx3-------------------------------
            if (table[1, 2] == 0) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 2] == 1) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 2] == 2) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 2] == 3) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 2] == 4) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 2] == 5) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 2] == 6) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 2] == 7) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 2] == 8) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 2] == 9) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 2] == 10) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 2] == 11) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 2] == 12) { pictureBoxG3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx4-------------------------------
            if (table[1, 3] == 0) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 3] == 1) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 3] == 2) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 3] == 3) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 3] == 4) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 3] == 5) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 3] == 6) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 3] == 7) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1    , 3] == 8) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 3] == 9) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 3] == 10) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 3] == 11) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 3] == 12) { pictureBoxG4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx5------------------------------
            if (table[1, 4] == 0) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 4] == 1) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 4] == 2) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 4] == 3) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 4] == 4) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 4] == 5) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 4] == 6) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 4] == 7) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 4] == 8) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 4] == 9) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 4] == 10) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 4] == 11) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 4] == 12) { pictureBoxG5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx6-------------------------------/
            if (table[1, 5] == 0) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 5] == 1) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 5] == 2) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 5] == 3) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 5] == 4) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 5] == 5) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 5] == 6) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 5] == 7) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 5] == 8) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 5] == 9) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 5] == 10) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 5] == 11) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 5] == 12) { pictureBoxG6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx7-------------------------------
            if (table[1, 6] == 0) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 6] == 1) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 6] == 2) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 6] == 3) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 6] == 4) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 6] == 5) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 6] == 6) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 6] == 7) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 6] == 8) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 6] == 9) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 6] == 10) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 6] == 11) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 6] == 12) { pictureBoxG7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Gx8-------------------------------
            if (table[1, 7] == 0) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[1, 7] == 1) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[1, 7] == 2) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[1, 7] == 3) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[1, 7] == 4) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[1, 7] == 5) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[1, 7] == 6) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[1, 7] == 7) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[1, 7] == 8) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[1, 7] == 9) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[1, 7] == 10) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[1, 7] == 11) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[1, 7] == 12) { pictureBoxG8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // =============================================================================================
            //------------------ Fx1       
            if (table[2, 0] == 0) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 0] == 1) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 0] == 2) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 0] == 3) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 0] == 4) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 0] == 5) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 0] == 6) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 0] == 7) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 0] == 8) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 0] == 9) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 0] == 10) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 0] == 11) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 0] == 12) { pictureBoxF1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Fx2-------------------------------
            if (table[2, 1] == 0) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 1] == 1) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 1] == 2) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 1] == 3) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 1] == 4) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 1] == 5) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 1] == 6) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 1] == 7) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 1] == 8) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 1] == 9) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 1] == 10) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 1] == 11) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 1] == 12) { pictureBoxF2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Fx3------------------------------
            if (table[2, 2] == 0) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 2] == 1) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 2] == 2) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 2] == 3) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 2] == 4) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 2] == 5) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 2] == 6) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 2] == 7) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 2] == 8) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 2] == 9) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 2] == 10) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 2] == 11) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 2] == 12) { pictureBoxF3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Fx4-----------------------------
            if (table[2, 3] == 0) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 3] == 1) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 3] == 2) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 3] == 3) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 3] == 4) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 3] == 5) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 3] == 6) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 3] == 7) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 3] == 8) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 3] == 9) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 3] == 10) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 3] == 11) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 3] == 12) { pictureBoxF4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Fx5------------------------------
            if (table[2, 4] == 0) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 4] == 1) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 4] == 2) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 4] == 3) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 4] == 4) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 4] == 5) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 4] == 6) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 4] == 7) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 4] == 8) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 4] == 9) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 4] == 10) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 4] == 11) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 4] == 12) { pictureBoxF5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Fx6-------------------------------
            if (table[2, 5] == 0) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 5] == 1) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 5] == 2) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 5] == 3) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 5] == 4) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 5] == 5) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 5] == 6) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 5] == 7) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 5] == 8) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 5] == 9) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 5] == 10) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 5] == 11) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 5] == 12) { pictureBoxF6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Fx7------------------------------
            if (table[2, 6] == 0) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 6] == 1) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 6] == 2) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 6] == 3) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 6] == 4) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 6] == 5) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 6] == 6) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 6] == 7) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 6] == 8) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 6] == 9) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 6] == 10) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 6] == 11) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 6] == 12) { pictureBoxF7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Fx8------------------------------
            if (table[2, 7] == 0) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[2, 7] == 1) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[2, 7] == 2) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[2, 7] == 3) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[2, 7] == 4) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[2, 7] == 5) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[2, 7] == 6) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[2, 7] == 7) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[2, 7] == 8) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[2, 7] == 9) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[2, 7] == 10) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[2, 7] == 11) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[2, 7] == 12) { pictureBoxF8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // =============================================================================================
            //-------------------Ex1-------------------------------
            if (table[3, 0] == 0) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 0] == 1) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 0] == 2) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 0] == 3) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 0] == 4) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 0] == 5) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 0] == 6) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 0] == 7) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 0] == 8) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 0] == 9) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 0] == 10) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 0] == 11) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 0] == 12) { pictureBoxE1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ex2-------------------------------
            if (table[3, 1] == 0) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 1] == 1) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 1] == 2) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 1] == 3) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 1] == 4) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 1] == 5) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 1] == 6) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 1] == 7) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 1] == 8) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 1] == 9) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 1] == 10) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 1] == 11) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 1] == 12) { pictureBoxE2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------EX3-------------------------------
            if (table[3, 2] == 0) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 2] == 1) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 2] == 2) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 2] == 3) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 2] == 4) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 2] == 5) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 2] == 6) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 2] == 7) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 2] == 8) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 2] == 9) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 2] == 10) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 2] == 11) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 2] == 12) { pictureBoxE3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ex4-------------------------------
            if (table[3, 3] == 0) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 3] == 1) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 3] == 2) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 3] == 3) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 3] == 4) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 3] == 5) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 3] == 6) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 3] == 7) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 3] == 8) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 3] == 9) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 3] == 10) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 3] == 11) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 3] == 12) { pictureBoxE4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ex5-------------------------------
            if (table[3, 4] == 0) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 4] == 1) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 4] == 2) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 4] == 3) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 4] == 4) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 4] == 5) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 4] == 6) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 4] == 7) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 4] == 8) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 4] == 9) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 4] == 10) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 4] == 11) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 4] == 12) { pictureBoxE5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Ex6-------------------------------
            if (table[3, 5] == 0) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 5] == 1) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 5] == 2) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 5] == 3) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 5] == 4) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 5] == 5) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 5] == 6) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 5] == 7) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 5] == 8) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 5] == 9) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 5] == 10) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 5] == 11) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 5] == 12) { pictureBoxE6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ex7------------------------------
            if (table[3, 6] == 0) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 6] == 1) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 6] == 2) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 6] == 3) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 6] == 4) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 6] == 5) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 6] == 6) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 6] == 7) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 6] == 8) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 6] == 9) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 6] == 10) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 6] == 11) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 6] == 12) { pictureBoxE7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Ex8-------------------------------
            if (table[3, 7] == 0) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[3, 7] == 1) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[3, 7] == 2) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[3, 7] == 3) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[3, 7] == 4) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[3, 7] == 5) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[3, 7] == 6) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[3, 7] == 7) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[3, 7] == 8) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[3, 7] == 9) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[3, 7] == 10) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[3, 7] == 11) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[3, 7] == 12) { pictureBoxE8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // ============================================================================================
            //------------------ Dx1 ----------------------------      
            if (table[4, 0] == 0) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 0] == 1) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 0] == 2) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 0] == 3) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 0] == 4) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 0] == 5) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 0] == 6) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 0] == 7) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 0] == 8) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 0] == 9) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 0] == 10) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 0] == 11) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 0] == 12) { pictureBoxD1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Dx2-------------------------------
            if (table[4, 1] == 0) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 1] == 1) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 1] == 2) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 1] == 3) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 1] == 4) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 1] == 5) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 1] == 6) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 1] == 7) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 1] == 8) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 1] == 9) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 1] == 10) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 1] == 11) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 1] == 12) { pictureBoxD2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Dx3-------------------------------
            if (table[4, 2] == 0) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 2] == 1) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 2] == 2) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 2] == 3) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 2] == 4) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 2] == 5) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 2] == 6) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 2] == 7) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 2] == 8) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 2] == 9) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 2] == 10) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 2] == 11) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 2] == 12) { pictureBoxD3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Dx4-------------------------------
            if (table[4, 3] == 0) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 3] == 1) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 3] == 2) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 3] == 3) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 3] == 4) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 3] == 5) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 3] == 6) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 3] == 7) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 3] == 8) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 3] == 9) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 3] == 10) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 3] == 11) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 3] == 12) { pictureBoxD4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Dx5-------------------------------
            if (table[4, 4] == 0) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 4] == 1) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 4] == 2) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 4] == 3) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 4] == 4) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 4] == 5) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 4] == 6) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 4] == 7) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 4] == 8) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 4] == 9) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 4] == 10) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 4] == 11) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 4] == 12) { pictureBoxD5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Dx6-------------------------------
            if (table[4, 5] == 0) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 5] == 1) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 5] == 2) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 5] == 3) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 5] == 4) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 5] == 5) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 5] == 6) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 5] == 7) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 5] == 8) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 5] == 9) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 5] == 10) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 5] == 11) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 5] == 12) { pictureBoxD6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Dx7------------------------------
            if (table[4, 6] == 0) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 6] == 1) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 6] == 2) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[4, 6] == 3) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 6] == 4) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 6] == 5) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 6] == 6) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 6] == 7) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 6] == 8) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 6] == 9) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[4, 6] == 10) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 6] == 11) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 6] == 12) { pictureBoxD7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Dx8-------------------------------
            if (table[4, 7] == 0) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[4, 7] == 1) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[4, 6] == 2) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile(".BKnightgif"); }
            else if (table[4, 7] == 3) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[4, 7] == 4) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[4, 7] == 5) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[4, 7] == 6) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[4, 7] == 7) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[4, 7] == 8) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[4, 7] == 9) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[0, 7] == 10) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[4, 7] == 11) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[4, 7] == 12) { pictureBoxD8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // =============================================================================================
            //------------------ Cx1-------------------------------
            if (table[5, 0] == 0) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 0] == 1) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 0] == 2) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 0] == 3) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 0] == 4) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 0] == 5) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 0] == 6) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 0] == 7) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 0] == 8) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 0] == 9) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 0] == 10) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 0] == 11) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 0] == 12) { pictureBoxC1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Cx2-------------------------------
            if (table[5, 1] == 0) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 1] == 1) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 1] == 2) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 1] == 3) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 1] == 4) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 1] == 5) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 1] == 6) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 1] == 7) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 1] == 8) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 1] == 9) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 1] == 10) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 1] == 11) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 1] == 12) { pictureBoxC2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Cx3-------------------------------
            if (table[5, 2] == 0) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 2] == 1) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 2] == 2) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 2] == 3) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 2] == 4) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 2] == 5) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 2] == 6) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 2] == 7) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 2] == 8) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 2] == 9) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 2] == 10) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 2] == 11) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 2] == 12) { pictureBoxC3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Cx4-------------------------------
            if (table[5, 3] == 0) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 3] == 1) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 3] == 2) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 3] == 3) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 3] == 4) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 3] == 5) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 3] == 6) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 3] == 7) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 3] == 8) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 3] == 9) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 3] == 10) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 3] == 11) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 3] == 12) { pictureBoxC4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Cx5-------------------------------
            if (table[5, 4] == 0) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 4] == 1) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 4] == 2) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 4] == 3) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 4] == 4) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 4] == 5) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 4] == 6) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 4] == 7) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 4] == 8) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 4] == 9) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 4] == 10) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 4] == 11) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 4] == 12) { pictureBoxC5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Cx6-------------------------------
            if (table[5, 5] == 0) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 5] == 1) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 5] == 2) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 5] == 3) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 5] == 4) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 5] == 5) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 5] == 6) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 5] == 7) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 5] == 8) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 5] == 9) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 5] == 10) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 5] == 11) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 5] == 12) { pictureBoxC6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Cx7-------------------------------
            if (table[5, 6] == 0) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 6] == 1) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 6] == 2) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 6] == 3) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 6] == 4) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 6] == 5) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 6] == 6) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 6] == 7) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 6] == 8) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 6] == 9) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 6] == 10) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 6] == 11) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 6] == 12) { pictureBoxC7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Cx8-------------------------------
            if (table[5, 7] == 0) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[5, 7] == 1) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[5, 7] == 2) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[5, 7] == 3) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[5, 7] == 4) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[5, 7] == 5) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[5, 7] == 6) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[5, 7] == 7) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[5, 7] == 8) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[5, 7] == 9) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[5, 7] == 10) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[5, 7] == 11) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[5, 7] == 12) { pictureBoxC8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // =============================================================================================
            //------------------ Bx1-------------------------------
            if (table[6, 0] == 0) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 0] == 1) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 0] == 2) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 0] == 3) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 0] == 4) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 0] == 5) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 0] == 6) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 0] == 7) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 0] == 8) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 0] == 9) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 0] == 10) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 0] == 11) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 0] == 12) { pictureBoxB1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Bx2-------------------------------
            if (table[6, 1] == 0) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 1] == 1) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 1] == 2) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 1] == 3) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 1] == 4) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 1] == 5) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 1] == 6) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 1] == 7) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 1] == 8) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 1] == 9) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 1] == 10) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 1] == 11) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 1] == 12) { pictureBoxB2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Bx3-------------------------------
            if (table[6, 2] == 0) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 2] == 1) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 2] == 2) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 2] == 3) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 2] == 4) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 2] == 5) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 2] == 6) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 2] == 7) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 2] == 8) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 2] == 9) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 2] == 10) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 2] == 11) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 2] == 12) { pictureBoxB3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Bx4-------------------------------
            if (table[6, 3] == 0) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 3] == 1) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 3] == 2) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 3] == 3) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 3] == 4) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 3] == 5) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 3] == 6) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 3] == 7) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 3] == 8) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 3] == 9) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 3] == 10) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 3] == 11) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 3] == 12) { pictureBoxB4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Bx5-------------------------------
            if (table[6, 4] == 0) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 4] == 1) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 4] == 2) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 4] == 3) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 4] == 4) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 4] == 5) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 4] == 6) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 4] == 7) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 4] == 8) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 4] == 9) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 4] == 10) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 4] == 11) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 4] == 12) { pictureBoxB5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Bx6-------------------------------
            if (table[6, 5] == 0) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 5] == 1) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 5] == 2) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 5] == 3) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 5] == 4) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 5] == 5) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 5] == 6) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 5] == 7) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 5] == 8) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 5] == 9) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 5] == 10) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 5] == 11) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 5] == 12) { pictureBoxB6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Bx7-------------------------------
            if (table[6, 6] == 0) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 6] == 1) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 6] == 2) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 6] == 3) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 6] == 4) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 6] == 5) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 6] == 6) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 6] == 7) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 6] == 8) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 6] == 9) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 6] == 11) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 6] == 12) { pictureBoxB7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Bx8------------------------------
            if (table[6, 7] == 0) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[6, 7] == 1) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[6, 7] == 2) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[6, 7] == 3) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[6, 7] == 4) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[6, 7] == 5) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[6, 7] == 6) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[6, 7] == 7) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[6, 7] == 8) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[6, 7] == 9) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[6, 7] == 10) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[6, 7] == 11) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[6, 7] == 12) { pictureBoxB8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // =============================================================================================
            //------------------ Ax1-------------------------------
            if (table[7, 0] == 0) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 0] == 1) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 0] == 2) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 0] == 3) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 0] == 4) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 0] == 5) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 0] == 6) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 0] == 7) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 0] == 8) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 0] == 9) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 0] == 10) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 0] == 11) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 0] == 12) { pictureBox1.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ax2-------------------------------
            if (table[7, 1] == 0) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 1] == 1) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 1] == 2) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 1] == 3) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 1] == 4) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 1] == 5) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 1] == 6) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 1] == 7) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 1] == 8) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 1] == 9) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 1] == 10) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 1] == 11) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 1] == 12) { pictureBox2.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ax3-------------------------------
            if (table[7, 2] == 0) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 2] == 1) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 2] == 2) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 2] == 3) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 2] == 4) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 2] == 5) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 2] == 6) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 2] == 7) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 2] == 8) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 2] == 9) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 2] == 10) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 2] == 11) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 2] == 12) { pictureBox3.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ax4-------------------------------
            if (table[7, 3] == 0) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 3] == 1) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 3] == 2) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 3] == 3) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 3] == 4) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 3] == 5) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 3] == 6) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 3] == 7) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 3] == 8) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 3] == 9) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 3] == 10) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 3] == 11) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 3] == 12) { pictureBox4.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Ax5-------------------------------
            if (table[7, 4] == 0) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 4] == 1) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 4] == 2) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 4] == 3) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 4] == 4) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 4] == 5) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 4] == 6) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 4] == 7) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 4] == 8) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 4] == 9) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 4] == 10) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 4] == 11) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 4] == 12) { pictureBox5.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Ax6-------------------------------
            if (table[7, 5] == 0) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 5] == 1) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 5] == 2) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 5] == 3) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 5] == 4) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 5] == 5) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 5] == 6) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 5] == 7) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 5] == 8) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 5] == 9) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 5] == 10) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 5] == 11) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 5] == 12) { pictureBox6.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //------------------Ax7-------------------------------
            if (table[7, 6] == 0) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 6] == 1) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 6] == 2) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 6] == 3) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 6] == 4) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 6] == 5) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 6] == 6) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 6] == 7) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 6] == 8) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 6] == 9) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 6] == 10) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 6] == 11) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 6] == 12) { pictureBox7.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            //-------------------Ax8-------------------------------
            if (table[7, 7] == 0) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (table[7, 7] == 1) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (table[7, 7] == 2) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (table[7, 7] == 3) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (table[7, 7] == 4) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (table[7, 7] == 5) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (table[7, 7] == 6) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (table[7, 7] == 7) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (table[7, 7] == 8) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (table[7, 7] == 9) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (table[7, 7] == 10) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (table[7, 7] == 11) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (table[7, 7] == 12) { pictureBox8.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }
            // =========================================صورة القطعة التي نحملها==============================================
            if (n == 0) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("nothing.gif"); }
            else if (n == 1) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("BRook.gif"); }
            else if (n == 2) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("BKnight.gif"); }
            else if (n == 3) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("BBishop.gif"); }
            else if (n == 4) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("BQueen.gif"); }
            else if (n == 5) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("BKing.gif"); }
            else if (n == 6) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("BPawn.gif"); }
            else if (n == 7) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("WRook.gif"); }
            else if (n == 8) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("WKnight.gif"); }
            else if (n == 9) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("WBishop.gif"); }
            else if (n == 10) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("WQueen.gif"); }
            else if (n == 11) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("WKing.gif"); }
            else if (n== 12) { pictureBox99.BackgroundImage = System.Drawing.Image.FromFile("WPawn.gif"); }

        }    // تابع لرسم الرقعة  بحسب تموضع الاحجار في المصفوفة
        //===========================================================================================

        public void move()//            ------   تابع التحريك    ------------
        {
            if (turn == 1 )//  white
            {

                if (click == 0)//            عند اول ضغطة على القطعة لتحريكها
                {
                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                    {
                        n = table[x, y];//   تخزين القطعة المراد تحريكها
                        x2 = x; y2 = y;//     تخزين الاحداثيات القديمة
                        table[x, y] = 0;//     ازالة القطعة من مكانها القديم
                        click++;
                    }
                }
                else if (click == 1)//     عند وضع القطعة في المكان المطلوب
                {
                    check = 0;
                    turnwhite();//   هذا التابع مهمته تحديد التابع المناسب لحركة القطعة           
                    n = 0;
                    click--;
                    if (check==1)// 
                    {
                       turn++;
                    } 
                }

                drawing();
               
            }
            else if ( turn == 2)
            {
                if (click == 0)//            عند اول ضغطة على القطعة لتحريكها
                {
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    {

                        n = table[x, y];//   تخزين القطعة المراد تحريكها
                        x2 = x; y2 = y;//     تخزين الاحداثيات القديمة
                        table[x, y] = 0;//     ازالة القطعة من مكانها القديم
                        click++;
                    }
                }
                else if (click == 1)//     عند وضع القطعة في المكان المطلوب
                {
                    check = 0;
                    turnblack();
                    n = 0;
                    click--;
                    if (check==1)
                    {
                         turn--;
                    }
                   
                }

                drawing();
               
            }

           
        }

        public void turnwhite()// تحريك القطع البيضاء
        {
            if (n == 7)//   قلعة
            { moveroookwhite(); }
            if (n == 8)//
            { moveKnightwhite(); }//تحريك الحصان الابيض
            if (n == 9)//
            { moveBishopwhite(); }
            if (n == 10)
            { moveQueenwhite(); }
            if (n == 11)
            { moveKingwhite(); }
            if (n == 12)
            { movePawnwhite(); }// جندي ابيض

        }
        public void turnblack()// تحريك القطع السوداء
        {
            if (n == 1)//     اذا كانت القطعة قلعة بيضاء
            { moveroookblack(); }
            if (n == 2)
            { moveKnightblack(); }//تحريك الحصان الاسود
            if (n == 3)//
            { moveBishopblack(); }
            if (n == 4)
            { moveQueenblack(); }
            if (n == 5)
            { moveKingblack(); }
            if (n == 6)
            { movePawnblack(); }// جندي اسود
        }

        //    خوارزمية تحريك كل قطعة
        public void moveroookwhite()
        {
            cc = 0;
            if (x2 == x) //   تحرك سطري
            {
                if (y2 < y)//     من اليسار الى اليمين
                {
                    for (int i = y2; i < y; i++)// حلقة للتأكد ان المسار خالي من اي قطع
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }
                    //              للتأكد ان القطعة التي ليست صديق    
                  if (table[x,y]==7||table[x,y]==8||table[x,y]==9||table[x,y]==10||table[x,y]==11||table[x,y]==12)
                    {cc=1;}

                  if (cc == 0)
                  { table[x, y] = n;   check = 1;   }
                  else
                  {error();}
                }

                else if (y2 > y)// من اليمين الى اليسار
                {
                    for (int i = y2; i > y; i--)
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }
                   if (table[x,y]==7||table[x,y]==8||table[x,y]==9||table[x,y]==10||table[x,y]==11||table[x,y]==12)
                    {cc=1;}
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
            }
            //---------------------------------------------
            else if (y2 == y) ///   تحرك عامودي
            {
                if (x2 > x)                //من اسفل الى أعلى 
                {
                    for (int i = x2; i > x; i--)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (x2 < x)    //    من أعلى الى أسفل
                {
                    for (int i = x2; i < x; i++)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    } if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else
                {
                    { error(); }
                    table[x2, y2] = n;
                }
            }
            else
            { error(); }
        }//  تم الانتهاء 
        public void moveroookblack()
        {
            cc = 0;
            if (x2 == x) //   تحرك سطري
            {
                if (y2 < y)//     من اليسار الى اليمين
                {
                    for (int i = y2; i < y; i++)////////////////////////////////////////////////////
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (y2 > y)// من اليمين الى اليسار
                {
                    for (int i = y2; i > y; i--)
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }

                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
            }
            //---------------------------------------------
            else if (y2 == y) ///   تحرك عامودي
            {
                if (x2 > x)                //من اسفل الى أعلى 
                {
                    for (int i = x2; i > x; i--)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (x2 < x)    //    من أعلى الى أسفل
                {
                    for (int i = x2; i < x; i++)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else
                {
                    { error(); }
                    table[x2, y2] = n;
                }
            }
            else
            { error(); }
        }//  تم الانتهاء 
        public void moveKnightwhite()
        {
           
            if (x2==x-1 && (y2==y+2||y2==y-2) )
            {
                eatblack();
            }
            else if (x2==x+1 && (y2==y+2||y2==y-2) )
            {
                eatblack();
            }
            else if (x2 == x - 2 && (y2 == y + 1 || y2 == y - 1))
            {
                eatblack();
            }
            else if (x2 == x + 2 && (y2 == y + 1 || y2 == y - 1))
            {
                eatblack();
            }
            else

            { error(); }
           
        }//  تم الانتهاء 
        public void moveKnightblack()
        {
           
            if (x2 == x - 1 && (y2 == y + 2 || y2 == y - 2))
            {
                
                eatwhite();
            }
            else if (x2 == x + 1 && (y2 == y + 2 || y2 == y - 2))
            {
               
                eatwhite();
            }
            else if (x2 == x - 2 && (y2 == y + 1 || y2 == y - 1))
            {
              
                eatwhite();
            }
            else if (x2 == x + 2 && (y2 == y + 1 || y2 == y - 1))
            {              
                eatwhite();
            }
            else
            { error(); }
        }//  تم الانتهاء 
        public void moveBishopwhite()
        {
            cc = 0;               //  O               الحركة على القطر الرئيسي
            if (x2 - x == y2 - y)//     O
            {                   //        O


                if (x2 > x) //         باتجاه اعلى يسار
                {
                    j = y2;
                    for (int i = x2; i > x; i--)//حلقة للتأكد ان المسار خال من اي قطع
                    {

                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc++; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { MessageBox.Show("هيك خطأ يا خيو"); table[x2, y2] = n; }
                    }
                    else { error(); }
                }//---------------------------------
                else if (x2 < x)//     باتجاه يمين اسفل
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }
                }
                else { error(); }
            }//==============================================================
                                                 //     O              القطر الثانوي
            else if (x2 - x == (-1) * (y2 - y)) //   O
            {                                  // O

                if (x2 > x)//      باتجاه اعلى يمين
                {
                    j = y2;
                    for (int i = x2; i > x; i--)////حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }
                }//---------------------------------------------
                else if (x2 < x)//                ياتجاه اسفل يسار
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }

                }
                else { error(); }
            }//==================================================================
            else
            { error(); }
        }   //  تم الانتهاء 
        public void moveBishopblack()
        {  cc=0;                  //  O               الحركة على القطر الرئيسي
            if (x2 - x == y2 - y)//     O
            {                   //        O
                if (x2>x) //         باتجاه اعلى يسار
                {  
                    j = y2;
                    for (int i = x2; i > x; i--)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc++; }
                        j--;
                    }
                   if (cc == 0)
                   {     if (table[x, y] == 0||table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                   { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                   else { error(); }
                   }
                   else { error(); }
                }//---------------------------------
                else if (x2<x)//     باتجاه يمين اسفل
                {
                   j = y2;
                   for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                   {
                       if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                       { cc = 1; }
                       j++;
                   }
                   if (cc == 0)
                   {
                       if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                       { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                       else { error(); }
                   }
                   else { error(); }
                }
                else { error(); }
            }//==============================================================
                                                 //     O              القطر الثانوي
            else if (x2 - x == (-1) * (y2 - y)) //   O
            {                                  // O

                if (x2>x)//      باتجاه اعلى يمين
                {
                    j = y2;
                    for (int i = x2; i > x; i--)////حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                     if (cc == 0)
                     {
                         if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8|| table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                         { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                         else { error(); }
                     }
                     else { error(); }
                }//---------------------------------------------
                else if (x2<x)//                ياتجاه اسفل يسار
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }
                    
                }
                else { error(); }
            }//==================================================================
            else
            { error(); }
        }    //  تم الانتهاء 
        public void moveQueenwhite()
        {
            cc = 0;
            if (x2 == x) //   تحرك سطري
            {
                if (y2 < y)//     من اليسار الى اليمين
                {
                    for (int i = y2; i < y; i++)////////////////////////////////////////////////////
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9|| table[x, y] == 10|| table[x, y] == 11|| table[x, y] == 12)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (y2 > y)// من اليمين الى اليسار
                {
                    for (int i = y2; i > y; i--)
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }

                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12) 
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
            }
            //---------------------------------------------
            else if (y2 == y) ///   تحرك عامودي
            {
                if (x2 > x)                //من اسفل الى أعلى 
                {
                    for (int i = x2; i > x; i--)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12) 
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (x2 < x)    //    من أعلى الى أسفل
                {
                    for (int i = x2; i < x; i++)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12) 
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else
                { error(); }

            }//=====================================================================================================
            //  O               الحركة على القطر الرئيسي
            else if (x2 - x == y2 - y)//     O
            {                       //        O


                if (x2 > x) //         باتجاه اعلى يسار
                {
                    j = y2;
                    for (int i = x2; i > x; i--)//حلقة للتأكد ان المسار خال من اي قطع
                    {

                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc++; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }
                }//---------------------------------
                else if (x2 < x)//     باتجاه يمين اسفل
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }
                }
                else { error(); }
            }//==============================================================
            //     O              القطر الثانوي
            else if (x2 - x == (-1) * (y2 - y)) //   O
            {                                  // O

                if (x2 > x)//      باتجاه اعلى يمين
                {
                    j = y2;
                    for (int i = x2; i > x; i--)////حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }
                }//---------------------------------------------
                else if (x2 < x)//                ياتجاه اسفل يسار
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }

                }
                else { error(); }
            }//==================================================================
            else
            { error(); }

        }//تم الانتهاء
        public void moveQueenblack()
        {
           cc = 0;
            if (x2 == x) //   تحرك سطري
            {
                if (y2 < y)//     من اليسار الى اليمين
                {
                    for (int i = y2; i < y; i++)////////////////////////////////////////////////////
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (y2 > y)// من اليمين الى اليسار
                {
                    for (int i = y2; i > y; i--)
                    {
                        if (table[x, i] != 0)
                            cc = 1;
                    }

                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
            }
            //---------------------------------------------
            else if (y2 == y) ///   تحرك عامودي
            {
                if (x2 > x)                //من اسفل الى أعلى 
                {
                    for (int i = x2; i > x; i--)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else if (x2 < x)    //    من أعلى الى أسفل
                {
                    for (int i = x2; i < x; i++)
                    {
                        if (table[i, y] != 0)
                            cc = 1;
                    }
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    { cc = 1; }
                    if (cc == 0)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }
                }
                else
                { error(); }

            }//=====================================================================================================
                                      //  O               الحركة على القطر الرئيسي
           else if (x2 - x == y2 - y)//     O
            {                       //        O


                if (x2 > x) //         باتجاه اعلى يسار
                {
                    j = y2;
                    for (int i = x2; i > x; i--)//حلقة للتأكد ان المسار خال من اي قطع
                    {

                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc++; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }
                    }
                    else { error(); }//-
                }//---------------------------------
                else if (x2 < x)//     باتجاه يمين اسفل
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }//-
                    }
                    else { error(); }//-
                }
                else { error(); }//-

            }//==============================================================
                                                 //     O              القطر الثانوي
            else if (x2 - x == (-1) * (y2 - y)) //   O
            {                                  // O

                if (x2 > x)//      باتجاه اعلى يمين
                {
                    j = y2;
                    for (int i = x2; i > x; i--)////حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j++;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }//-
                    }
                    else { error(); }//-
                }//---------------------------------------------
                else if (x2 < x)//                ياتجاه اسفل يسار
                {
                    j = y2;
                    for (int i = x2; i < x; i++)//حلقة للتأكد ان المسار خال من اي قطع
                    {
                        if (table[i, j] != 0)//التأكد من المسار خطوة خطوة
                        { cc = 1; }
                        j--;
                    }
                    if (cc == 0)
                    {
                        if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                        { table[x, y] = n; check = 1; }// التأكد ان مكان التحرك فارغ او يحوي عدو لأكله
                        else { error(); }//-
                    }
                    else { error(); }//-

                }
                else { error(); }//-
            }//==================================================================
            else
            { error(); }//-

        
        }//تم الانتهاء
        public void moveKingblack()
        {
            if ((y2 == y && x2 == (x - 1))||(y2 == y && x2 == (x + 1)))
            {
                eatwhite();
            }
            else if ((x2==x && y2==y-1)||(x2==x && y2==y+1))
            {
                eatwhite();
            }
            else if ((x-x2==1 && y-y2==1)||(x2-x==1 && y2-y==1))
            {
                eatwhite();
            }
          
            else if ((x2-x==1&&y-y2==1)||(x-x2==1&&y2-y==1))
            {
                eatwhite();
            }
            
            else
            { error(); }//-

        }//تم الانتهاء
        public void moveKingwhite()
        {
            if ((y2 == y && x2 == (x - 1)) || (y2 == y && x2 == (x + 1)))
            {
                eatblack();
            }
            else if ((x2 == x && y2 == y - 1) || (x2 == x && y2 == y + 1))
            {
                eatblack();
            }
            else if ((x - x2 == 1 && y - y2 == 1) || (x2 - x == 1 && y2 - y == 1))
            {
                eatblack();
            }
            
            else if ((x2 - x == 1 && y - y2 == 1) || (x - x2 == 1 && y2 - y == 1))
            {
                eatblack();
            }

            else
            { error(); }//-

        }//تم الانتهاء
        public void movePawnblack()//تم الانتهاء
        {

          if (x2 == 1)         //اذا كان الجندي على الصف الاول
          {// اول حركة للجندي يمكن خطوتين
                if (y2 == y && x2 == (x - 2) && table[x - 1, y] == 0&&table[x,y]==0)//يجب ان تكون الحركة على نفس العمود وبعد سطرين والمكان خالي        
                { table[x, y] = n; check = 1; }

                else if (y2 == y && x2 == (x - 1))    //  الجركة الطبيعية خطوة للامام                   
                {
                    if (table[x, y] == 0)  // اذا كان امام الجندي فارغ                   
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }//-
                }

                else if (table[x, y] != 0)//   يأكل الجندي بالمائل
                {
                    if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                    {
                        if ((y2 == y + 1 || y2 == y - 1) && x2 == x - 1)
                        { table[x, y] = n; check = 1; }
                        else
                        { error(); }//-
                    }
                    else
                    { error(); }//-
                }

                     else
                { error(); }//-
                }///////---------------------------------------------------------         
           else   if (y2 == y && x2 == (x - 1))    //  الجركة الطبيعية خطوة للامام                   
                {  
                    if (table[x, y] == 0)  // اذا كان امام الجندي فارغ                   
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }//-
                }
   
           else if (table[x , y] != 0)//   يأكل الجندي بالمائل
            {
                if (table[x, y] == 7 || table[x, y] == 8 || table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                {
                    if ((y2 == y + 1 || y2 == y - 1) && x2 == x - 1)
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }//-
                }
                else
                { error(); }//-
           }
           else
          { error(); }//-
        }
        public void movePawnwhite()//  
        {
  
            if (x2==6)          //اذا كان الجندي على الصف الاول
            {// اول حركة للجندي يمكن خطوتين
                if (y2 == y && x2 == (x + 2)&&table[x+1,y]==0&& table[x, y] == 0)//  يجب ان تكون الحركة على نفس العمود وبعد سطرين والمكان خالي                    
                { table[x, y] = n; check = 1; }

               else if (y2 == y && x2 == (x + 1))//تحرك خطوة للامام
                {
                     if (table[x, y] == 0)// المكان خالي
                     { table[x, y] = n; check = 1; }
                    else
                     { error(); }//-
                }

                else if (table[x, y] != 0) //   يأكل الجندي بالمائل
                {//                                       يجب ان يكون من الفريق العدو
                    if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                    {
                        if ((y2 == y + 1 || y2 == y - 1) && x2 == x + 1)//  يجب ان يكون السطر الذي يليه والعمود يساره او يمينه
                        { table[x, y] = n; check = 1; }
                        else
                        { error(); }//-
                    }
                    else
                    { error(); }//-
                }
                else
                { error(); }//-
            }/////--------------------------------------------------------
                // حركة الجندي خطوة للامام
            else if (y2 == y && x2 == (x + 1))//تحرك خطوة للامام
            {
                if (table[x, y] == 0)// المكان خالي
                { table[x, y] = n; check = 1; }
                else
                { error(); }//-
            }
            else if (table[x, y] != 0) //   يأكل الجندي بالمائل
            {//                                       يجب ان يكون من الفريق العدو
                if (table[x, y] == 1 || table[x, y] == 2 || table[x, y] == 3 || table[x, y] == 4 || table[x, y] == 5 || table[x, y] == 6)
                {
                    if ((y2 == y + 1 || y2 == y - 1) && x2 == x + 1)//  يجب ان يكون السطر الذي يليه والعمود يساره او يمينه
                    { table[x, y] = n; check = 1; }
                    else
                    { error(); }//-
                }
                else
                { error(); }//-
            }
            else
            { error(); }//-
        }
        //------------------------------------------------------
        public void eatblack() 
        {
            if (table[x,y]==0||table[x,y]==1||table[x,y]==2||table[x,y]==3||table[x,y]==4||table[x,y]==5||table[x,y]==6)            
                { table[x, y] = n; check = 1; }
            
            else
            { error(); }//-
        }

        public void eatwhite()
        {
            if (table[x, y] == 0 || table[x, y] == 7 || table[x, y] == 8|| table[x, y] == 9 || table[x, y] == 10 || table[x, y] == 11 || table[x, y] == 12)
                {table[x, y] = n; check = 1;}

            else
            { error(); }//-
        }

        public void error()   //                  Error
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("هيك خطأ يا خيو");
            table[x2, y2] = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start();
            drawing();
           
        }//------  زر بدأ اللعبة    ا==((طجت لعبت))==ا

        // توابع الضغط على الصور في رقعة الشطرنج
        //  عند الضغط على كل صورة يتم تخزين الاحداثيات الموافقة للصورة
        // move ثم استدعاء تابع التحريك 
        //----------------------A------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {            x = 7;         y = 0;           move();}
        private void pictureBox2_Click(object sender, EventArgs e)   
        {            x = 7;         y = 1;           move();}
        private void pictureBox3_Click(object sender, EventArgs e)
        {            x = 7; y = 2; move();        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {            x = 7; y = 3; move();        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {            x = 7; y = 4; move();        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {            x = 7; y = 5; move();        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {            x = 7; y = 6; move();        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {            x = 7; y = 7; move();        }
        //----------------------B------------------------
        private void pictureBoxB1_Click(object sender, EventArgs e)
        { x = 6; y = 0; move(); }
        private void pictureBoxB2_Click(object sender, EventArgs e)
        { x = 6; y = 1; move(); }
        private void pictureBoxB3_Click(object sender, EventArgs e)
        { x = 6; y = 2; move(); }
        private void pictureBoxB4_Click(object sender, EventArgs e)
        { x = 6; y = 3; move(); }
        private void pictureBoxB5_Click(object sender, EventArgs e)
        { x = 6; y = 4; move(); }
        private void pictureBoxB6_Click(object sender, EventArgs e)
        { x = 6; y = 5; move(); }
        private void pictureBoxB7_Click(object sender, EventArgs e)
        { x = 6; y = 6; move(); }
        private void pictureBoxB8_Click(object sender, EventArgs e)
        { x = 6; y = 7; move(); }
        //----------------------C------------------------
        private void pictureBoxC1_Click(object sender, EventArgs e)
        { x = 5; y =0 ; move(); }
        private void pictureBoxC2_Click(object sender, EventArgs e)
        {  x = 5; y = 1; move();  }
        private void pictureBoxC3_Click(object sender, EventArgs e)
        {  x = 5; y =2 ; move();      }
        private void pictureBoxC4_Click(object sender, EventArgs e)
        {  x = 5; y =3 ; move();      }
        private void pictureBoxC5_Click(object sender, EventArgs e)
        {  x = 5; y = 4; move();      }
        private void pictureBoxC6_Click(object sender, EventArgs e)
        {  x = 5; y = 5; move();      }
        private void pictureBoxC7_Click(object sender, EventArgs e)
        {  x = 5; y = 6; move();      }
        private void pictureBoxC8_Click(object sender, EventArgs e)
        {  x = 5; y = 7; move();      }
        //----------------------D------------------------
        private void pictureBoxD1_Click(object sender, EventArgs e)
        { x = 4; y = 0; move(); }
        private void pictureBoxD2_Click(object sender, EventArgs e)
        { x = 4; y = 1; move(); }
        private void pictureBoxD3_Click(object sender, EventArgs e)
        {      x = 4; y = 2; move();  }
        private void pictureBoxD4_Click(object sender, EventArgs e)
        {       x = 4; y = 3; move(); }
        private void pictureBoxD5_Click(object sender, EventArgs e)
        {      x = 4; y =4 ; move();  }
        private void pictureBoxD6_Click(object sender, EventArgs e)
        {     x = 4; y = 5; move(); }
        private void pictureBoxD7_Click(object sender, EventArgs e)
        {       x = 4; y = 6; move(); }
        private void pictureBoxD8_Click(object sender, EventArgs e)
        {      x = 4; y = 7; move();  }
        //----------------------E------------------------
        private void pictureBoxE1_Click(object sender, EventArgs e)
        { x = 3; y = 0; move(); }
        private void pictureBoxE2_Click(object sender, EventArgs e)
        { x = 3; y = 1; move(); }
        private void pictureBoxE3_Click(object sender, EventArgs e)
        { x = 3; y = 2; move(); }
        private void pictureBoxE4_Click(object sender, EventArgs e)
        { x = 3; y = 3; move(); }
        private void pictureBoxE5_Click(object sender, EventArgs e)
        { x = 3; y = 4; move(); }
        private void pictureBoxE6_Click(object sender, EventArgs e)
        { x = 3; y = 5; move(); }
        private void pictureBoxE7_Click(object sender, EventArgs e)
        { x = 3; y = 6; move(); }
        private void pictureBoxE8_Click(object sender, EventArgs e)
        { x =3; y = 7; move(); }
        //----------------------F------------------------
        private void pictureBoxF1_Click(object sender, EventArgs e)
        { x = 2; y = 0; move(); }
        private void pictureBoxF2_Click(object sender, EventArgs e)
        { x = 2; y = 1; move(); }
        private void pictureBoxF3_Click(object sender, EventArgs e)
        { x = 2; y = 2; move(); }
        private void pictureBoxF4_Click(object sender, EventArgs e)
        { x = 2; y = 3; move(); }
        private void pictureBoxF5_Click(object sender, EventArgs e)
        { x = 2; y = 4; move(); }
        private void pictureBoxF6_Click(object sender, EventArgs e)
        { x = 2; y = 5; move(); }
        private void pictureBoxF7_Click(object sender, EventArgs e)
        { x = 2; y = 6; move(); }
        private void pictureBoxF8_Click(object sender, EventArgs e)
        { x = 2; y = 7; move(); }
        //----------------------G------------------------
        private void pictureBoxG1_Click(object sender, EventArgs e)
        { x = 1; y = 0; move(); }
        private void pictureBoxG2_Click(object sender, EventArgs e)
        { x = 1; y = 1; move(); }
        private void pictureBoxG3_Click(object sender, EventArgs e)
        { x = 1; y = 2; move(); }
        private void pictureBoxG4_Click(object sender, EventArgs e)
        { x = 1; y = 3; move(); }
        private void pictureBoxG5_Click(object sender, EventArgs e)
        { x = 1; y = 4; move(); }
        private void pictureBoxG6_Click(object sender, EventArgs e)
        { x = 1; y = 5; move(); }
        private void pictureBoxG7_Click(object sender, EventArgs e)
        { x = 1; y = 6; move(); }
        private void pictureBoxG8_Click(object sender, EventArgs e)
        { x = 1; y = 7; move(); }
        //----------------------H------------------------
        private void pictureBoxH1_Click(object sender, EventArgs e)
        { x = 0; y = 0; move(); }
        private void pictureBoxH2_Click(object sender, EventArgs e)
        { x = 0; y = 1; move(); }
        private void pictureBoxH3_Click(object sender, EventArgs e)
        { x = 0; y = 2; move(); }
        private void pictureBoxH4_Click(object sender, EventArgs e)
        { x = 0; y = 3; move(); }
        private void pictureBoxH5_Click(object sender, EventArgs e)
        { x = 0; y = 4; move(); }
        private void pictureBoxH6_Click(object sender, EventArgs e)
        { x = 0; y = 5; move(); }
        private void pictureBoxH7_Click(object sender, EventArgs e)
        { x = 0; y = 6; move(); }
        private void pictureBoxH8_Click(object sender, EventArgs e)
        { x = 0; y = 7; move(); }

        
        private void button3_Click(object sender, EventArgs e)
        {
            table[4,4] = Convert.ToInt16(textBox1.Text);
            drawing();
        } //  هاد الزر زيادة

        private void timer1_Tick(object sender, EventArgs e)
        {
            k = 0; kk = 0;
            richTextBox1.Text = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    richTextBox1.Text += table[i, j] + " ";
                }
                richTextBox1.Text += "\n";
            }
            richTextBox1.Text += "click=" + click + " n=" + n + " x=" + x + " y=" + y + "\n";
            richTextBox1.Text += "x2=" + x2 + " y2=" + y2 + "\n";
            richTextBox1.Text += "cc=" + cc + "\n" + "turn=" + turn + "  check=" + check;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (table[i, j] == 11) { kk = table[i, j]; } if (n == 11) { kk = 11; }
                    if (table[i, j] == 5) { k = table[i, j]; } if (n == 5) { k = 5; }
                    
                }
            }
            if (k!=5||kk!=11)
            {
                timer1.Enabled = false;
                MessageBox.Show("خلصت اللعبة");
                start();
                drawing();
            }
            richTextBox1.Text +="\n"+ "k=" + k + " kk=" + kk;

            if (turn == 1)
            { label30.Text = "دور الابيض";
            label30.BackColor = Color.White;
            label30.ForeColor = Color.Black;
            }
            if (turn == 2)
            { label30.Text = "دور الاسود";
            label30.BackColor = Color.Black;
            label30.ForeColor = Color.White;
            }

        }//  موقت لكتابة مصفوفة الرقعة على الشاشة كل ثانية

        private void button2_Click(object sender, EventArgs e)//  زر الاغلاق
        {
            this.Close();
        }
        //------ save files
        public void savefile(string path_name)
        {
            StreamWriter sw = new StreamWriter(path_name);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sw.Write(table[i, j] + ";");
                }
                sw.WriteLine();
            }
            // sw.WriteLine(table);
            sw.WriteLine(click);
            sw.WriteLine(n);
            sw.WriteLine(turn);
            sw.Close();

        }
        //------ load files
        public void loadfils(string path_name)
        {
            StreamReader sr = new StreamReader(path_name);
            string line = "";
            for (int i = 0; i < 8; i++)
            {
                line = sr.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    table[i, j] = Convert.ToInt16(line.Split(';')[j]);
                }
              
            }
            click = Convert.ToInt16(sr.ReadLine());
            n = Convert.ToInt16(sr.ReadLine());
            turn = Convert.ToInt16(sr.ReadLine());
            drawing();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("gameSave.txt");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sw.Write(table[i, j]+";");
                }
                sw.WriteLine();
            }
           // sw.WriteLine(table);
            sw.WriteLine(click);
            sw.WriteLine(n);
            sw.WriteLine(turn);
            sw.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("gameSave.txt");
            string line = "";
            for (int i = 0; i < 8; i++)
            {
                line = sr.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    table[i, j] =Convert.ToInt16( line.Split(';')[j]);
                }
             //   sr.ReadLine();
            }
            click = Convert.ToInt16(sr.ReadLine());
            n = Convert.ToInt16(sr.ReadLine());
            turn = Convert.ToInt16(sr.ReadLine());
            drawing();
          //  table = sr.Read();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ssq = new SaveFileDialog();
            sfd.Title = "اختر المكان واكتب الاسم الذي تريد الحفظ به";
         //   sfd.InitialDirectory = "c:\\";
            sfd.ShowDialog();
            string xxx = sfd.FileName;
            savefile(xxx);
        }

        private void loadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Title = "اختر اللعبة التي تريد استرجاعها";
         //   sfd.InitialDirectory = "c:\\";
            ofd.ShowDialog();
            string yyy = ofd.FileName;
            loadfils(yyy);
        }
// ------------   اظهار-اخفاء التفاصيل
        public bool isCool=true;
        public int formWidthLarg = 798;
        public int formWidthmine = 566;
        private void button4_Click(object sender, EventArgs e)
        {
          //  742; 598
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCool)
            {
                this.Width -= 7;
                if (this.Width<=formWidthmine)
                {
                    timer2.Stop();
                    isCool = false;
                }
            }
            else
            {
                this.Width += 7;
                if (this.Width >= formWidthLarg)
                {
                    timer2.Stop();
                    isCool = true;
                }
            }
        }

      
    
    }  
}
//                                                                                                   تم بعون الله  
//                           مع تحيات انصاف المهندسين:أحمد الحاج حسين + مهند حمود + محمد ضبيط
//              2018/6/7-سوريا-ادلب
//