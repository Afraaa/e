using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //.匹配除了换行符以外的任意字符。
            //*指定*前边的内容可以连续重复使用任意次以使整个表达式得到匹配
            //.*连在一起就意味着任意数量的不包含换行的字符。
            //这里的\d 匹配一位数字
            //-匹配它本身—
            //0\d{2}-\d{8}前面\d 必须连续重复匹配2次(8次)
            //\s 匹配任意的空白符，包括空格，制表符(Tab)，换行符，中文全角空格
            //\w 匹配字母或数字或下划线或汉字
            //\d+匹配1个或更多连续的数字。*匹配重复任意次(可能是0次)，而+则匹配重复1次或更多次。
            //{5,12}是重复的次数不能少于5次，不能多于12次，否则都不匹配
            //用\来取消这些字符的特殊意义。\.和\*和用\\

            //关键字：int,char,if,else,while,do,for

            //string pattern = @"\bhi\b";//精确匹配hi
            //string pattern1 = @"\bha";//ha开头
            //string pattern3 = @"[aeiou]";
            //string pattern2 = @"\bhi\b.*\bLucy\b";
/*
#include<>
int main(){
    char a;
    int a=1213234;
    string str="abcsafdsad112dsfhk";
    if(){}else{}
    while(){}
    do{}while();
    for(int i=1;){}
}
*/


            string str = richTextBox1.Text;
            string patternKeyWord = @"\bint\b|\bchar\b|\bif\b|\belse\b|\bwhile\b|\bdo\b|\bfor\b";//匹配关键字
            string patternC = @"/\*(\n|.)*\*/";//匹配注释
            string patternStr = @""".*""";//匹配字符串常量
            string patternNum = @"\b\d+\b";//匹配数字常量
            string patternY = @"#.*";//匹配预编译指令

            

            Regex r = new Regex(patternKeyWord, RegexOptions.IgnoreCase);//匹配关键字
            Match m = r.Match(str);
            int ct = 0;
            while (m.Success)
            {
                ct++;
                //richTextBox1.Text += "值(m" + ct + "):" + m + "\n";
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    //  richTextBox1.Text += "(c" + ct + ")" + c + "\n";
                    //richTextBox1.Text += "原索引值："+c.Index+",子串长度"+c.Length + "\n";
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.Blue;
                }
                //richTextBox1.Text += "(m.Groups.Count):" + m.Groups.Count+"\n";
                for (int i = 0; i < m.Groups.Count; i++)
                {
                    Group group = m.Groups[i];
                    //  richTextBox1.Text += "(group:)" + group + "," + "(i):" + i + "\n";
                    //richTextBox1.Text += "(group.Captures.Count:)" + group.Captures.Count+"\n";
                    for (int j = 0; j < group.Captures.Count; j++)
                    {
                        Capture capture = group.Captures[j];
                        //  richTextBox1.Text += "(capture" + j + "):" + capture +"\n";
                    }
                }
                m = m.NextMatch();
            }

            r = new Regex(patternC, RegexOptions.IgnoreCase);//匹配注释
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.DarkGreen;
                }
                m = m.NextMatch();
            }

            r = new Regex(patternStr, RegexOptions.IgnoreCase);//匹配字符串常量
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.DeepPink;
                }
                m = m.NextMatch();
            }

            r = new Regex(patternNum, RegexOptions.IgnoreCase);//匹配数字常量
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.Purple;
                }
                m = m.NextMatch();
            }

            r = new Regex(patternY, RegexOptions.IgnoreCase);//匹配预编译指令
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.Red;
                }
                m = m.NextMatch();
            }
        }
    }
}
