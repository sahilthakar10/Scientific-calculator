using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        int count = 0;


        static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
     
        private Boolean check = false;
        private Boolean io = false;
        String[] a = new String[30];
        int top = 0;
        Boolean b = true;
        Boolean c = false;
        string ans = "";
        double M=0;
        Boolean p_m = true;
        Boolean s_c_t = false;
        internal static int Prec1(string ch)
        {
            switch (ch)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }
            return -1;
        }
        // The main method that converts given infix expression  
        // to postfix expression.   
        public static string infixToPostfix(string exp)
        {
            // initializing empty String for result  
            string latest_exp = "";
           
            Console.WriteLine("Expression " + exp);
           
            var s = exp.Trim().Split(' ');
            
            for(int i=0; i <s.Length; i++)
            {
                Console.WriteLine("Hello " + s[i]);

                if (s[i].Contains("Sin("))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;

                    s[i] = Math.Sin(DegreeToRadian(Convert.ToDouble( s[i].Substring(4, c)))).ToString();
                    //     label2.Text = ch;
                    latest_exp += " " +s[i];
                }
                else if (s[i].Contains("Cos("))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;
                    Console.WriteLine("sfsdfsf " + Convert.ToDouble(s[i].Substring(4, c)) + "  cos value " + Math.Cos(2));
                    s[i] = Math.Cos(DegreeToRadian(Convert.ToDouble(s[i].Substring(4, c)))).ToString();
                    //     label2.Text = ch;
                    latest_exp += " " + s[i];
                }
                else if (s[i].Contains("Tan("))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;

                    s[i] = Math.Tan(DegreeToRadian( Convert.ToDouble(s[i].Substring(4, c)))).ToString();
                    //     label2.Text = ch;
                    latest_exp += " " +s[i];
                    Console.WriteLine("ten expression " + Math.Tan(Convert.ToDouble(s[i].Substring(4, c))).ToString());
                }
                else if (s[i].Contains("Sin-1"))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;

                    if (Convert.ToDouble(s[i].Substring(6, c)) <1 && Convert.ToDouble(s[i].Substring(6, c)) >-1)
                    {
                        s[i] = Math.Asin(Convert.ToDouble(s[i].Substring(6, c))).ToString();
                        latest_exp += " " + s[i];
                    }
                    else
                    {
                        latest_exp = "invalid";
                       
                    }
              
                   //     label2.Text = ch;
                }
                else if (s[i].Contains("Cos-1"))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;

                    if (Convert.ToDouble(s[i].Substring(6, c)) < 1 && Convert.ToDouble(s[i].Substring(6, c)) > -1)
                    {
                        s[i] = Math.Acos(Convert.ToDouble(s[i].Substring(6, c))).ToString();
                        latest_exp += " " + s[i];
                    }
                    else
                    {
                        latest_exp = "invalid";

                    }

                }
                else if (s[i].Contains("Tan-1"))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;

                    s[i] = Math.Atan(Convert.ToDouble(s[i].Substring(6, c))).ToString();
                    //     label2.Text = ch;
                    latest_exp += " " +s[i];
                }
                else if(s[i].Contains("f"))
                {
                    int len = s[i].IndexOf('(') + 1;
                    int endlen = s[i].IndexOf(')');
                    int c = endlen - len;
                    int number, fact;

                    number = Convert.ToInt32(s[i].Substring(2, c));
                    fact = number;

                    for (i = number - 1; i >= 1; i--)
                    {
                        fact = fact * i;
                    }
                    s[i] = fact.ToString();
                    latest_exp += " " +s[i];
                }
                else
                {
                    latest_exp += " " +s[i];
                }
            }

            Console.WriteLine("latest_Exp " + latest_exp);

            for(int i=0; i<s.Length; i++)
            {
                Console.Write("AAAA" + s[i]);
            }
            // initializing empty stack  
            Stack<string> stack1 = new Stack<string>();

            var ptf = latest_exp.Split(' ');
            string res = "";
            for (int i = 0; i < ptf.Length; ++i)
            {
                string ex = ptf[i];
                Console.WriteLine("Ex " + ex);

                if (!ex.Equals("+") && !ex.Equals("-") && !ex.Equals("*") && !ex.Equals("/") && !ex.Equals("(") && !ex.Equals(")"))
                {
                    res += ex;
                }
                else if (ex.Equals("("))
                {
                    stack1.Push(ex);
                }
                else if (ex.Equals(")"))
                {
                    while (stack1.Count > 0 && !stack1.Peek().Equals("("))
                    {
                        res += ' ';
                        res += stack1.Pop();
                        Console.WriteLine("LL");
                    }


                    if (stack1.Count > 0 && !stack1.Peek().Equals("("))
                    {
                        return "Invalid Expression"; // invalid expression 
                    }
                    else
                    {
                        stack1.Pop();
                        Console.WriteLine("LL1");
                    }
                    Console.WriteLine("LL2");

                }
                else // an operator is encountered 
                {
                    while (stack1.Count > 0 && Prec1(ex) <= Prec1(stack1.Peek()))
                    {
                        res += " ";
                        res += stack1.Pop();
                        Console.WriteLine(res);
                    }
                    stack1.Push(ex);
                    res += " ";
                    Console.WriteLine("ssad" + ex);
                }
            }
            // pop all the operators from the stack  
            while (stack1.Count > 0)
            {
                res += ' ';
                res += stack1.Pop();

            }
            return res;

        }


        public Form1()
        {
            InitializeComponent();
            button32.Enabled = false;
            button29.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //1
            String text = label1.Text;
            if(!check)
            {
                if (c)
                {
                    label1.Text = text + 1;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "1";
                }
                else
                {
                    label1.Text = text + 1;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 1;
                check = false;
            }           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //2
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 2;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "2";
                }
                else
                {
                    label1.Text = text + 2;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 2;
                check = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //3
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 3;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "3";
                }
                else
                {
                    label1.Text = text + 3;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 3;
                check = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //4
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 4;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "4";
                }
                else
                {
                    label1.Text = text + 4;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 4;
                check = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //5
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 5;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "5";
                }
                else
                {
                    label1.Text = text + 5;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 5;
                check = false;
            }

            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //6
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 6;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "6";
                }
                else
                {
                    label1.Text = text + 6;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 6;
                check = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //7
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 7;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "7";
                }
                else
                {
                    label1.Text = text + 7;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 7;
                check = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //8
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 8;
                }
                else if (text.Substring(0, 1) == "0")
                {

                    label1.Text = "8";
                }
                else
                {
                    label1.Text = text + 8;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 8;
                check = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //9
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 9;
                }
                else if(text.Substring(0, 1) == "0")
                {

                    label1.Text = "9";
                }
                else
                {
                    label1.Text = text + 9;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 9;
                check = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //0
            String text = label1.Text;

            if (!check)
            {
                if (c)
                {
                    label1.Text = text + 0;
                }
                else if (text.Substring(0, 1) == "0")
                {
                    label1.Text = "0";
                }
                else
                {
                    label1.Text = text + 0;
                }
            }
            else
            {
                text = "";
                label1.Text = text + 0;
                check = false;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + " Sin-1(" + label1.Text + ")";
            b = false;
            check = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //"("
            String text = label2.Text + " (";

            label2.Text = text;
            label1.Text = "0";

            ++count;
            check = false;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            //")"
            
            if(count>=1)
            {
               
             //   String text = label2.Text + " )";
                if (label2.Text.EndsWith("+") || label2.Text.EndsWith("-") || label2.Text.EndsWith("*") || label2.Text.EndsWith("/"))
                {
                    label2.Text = label2.Text + " " + label1.Text + " )";
                    b = false;
                    check = true;
                }
                else
                {
                    if(b)
                    {
                        label2.Text = label2.Text + " " + label1.Text + " )";
                        b = false;
                        check = true;
                        Console.WriteLine("hello1");
                    }
                    else
                    {
                        check = true;
                        label2.Text = label2.Text + " )";
                        Console.WriteLine("hello1");

                    }

                }
                count--;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            //+
            String text = label1.Text;
            String text1 = label2.Text;
            io = true;

            if(label2.Text.Length!=0 &&!label2.Text.EndsWith("+") && !label2.Text.EndsWith("-") && !label2.Text.EndsWith("*") && !label2.Text.EndsWith("/"))
            {
                label2.Text = label2.Text + " +" ;
            }
            if(!check)
            {
                label2.Text = text1 + " " + text + " +";
                check = true;
            }
            else
            {
                if (text1.EndsWith("*") || text1.EndsWith("/") || text1.EndsWith("-") || text1.EndsWith("+"))
                {
                    label2.Text = text1.Substring(0, text1.Length - 1) + "+";
                    check = true;
                }
            }
            c = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //-
            String text = label1.Text;
            String text1 = label2.Text;
            io = true;

            if (!label2.Text.EndsWith("+") && !label2.Text.EndsWith("-") && !label2.Text.EndsWith("*") && !label2.Text.EndsWith("/"))
            {
                label2.Text = label2.Text + " -" ;
            }
            if (!check)
            {
                label2.Text = text1 + " " + text + " -";
                check = true;
            }
            else
            {
                if (text1.EndsWith("*") || text1.EndsWith("/") || text1.EndsWith("-") || text1.EndsWith("+"))
                {
                    label2.Text = text1.Substring(0, text1.Length - 1) + "-";
                    check = true;
                }
            }
            c = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
           
            // /
            String text = label1.Text;
            String text1 = label2.Text;
            io = true;


           
            if (!check)
            {
                label2.Text = text1 + " " + text + " /";
                check = true;
            }
            else if (!label2.Text.EndsWith("+") && !label2.Text.EndsWith("-") && !label2.Text.EndsWith("*") && !label2.Text.EndsWith("/"))
            {
                label2.Text = label2.Text + " /";
            }
            else
            {
                if (text1.EndsWith("*") || text1.EndsWith("/") || text1.EndsWith("-") || text1.EndsWith("+"))
                {
                    label2.Text = text1.Substring(0, text1.Length - 1) + "/";
                    check = true;
                }
            }
            c = false;

        }

        private void button22_Click(object sender, EventArgs e)
        {

            // *
            String text = label1.Text;
            String text1 = label2.Text;
            io = true;

            if (!label2.Text.EndsWith("+") && !label2.Text.EndsWith("-") && !label2.Text.EndsWith("*") && !label2.Text.EndsWith("/"))
            {
                label2.Text = label2.Text + " *";
            }
            if (!check)
            {
                label2.Text = text1 + " " + text + " *";
                check = true;
            }
            else
            {
                if (text1.EndsWith("*") || text1.EndsWith("/") || text1.EndsWith("-") || text1.EndsWith("+"))
                {
                    label2.Text = text1.Substring(0, text1.Length - 1) + "*";
                    check = true;
                }
            }
            c = false;
        }
        private void button24_Click(object sender, EventArgs e)
        {

            //  1/x
            label1.Text = Convert.ToDouble( 1 / Convert.ToDouble(label1.Text)).ToString();

        }

        private void button18_Click(object sender, EventArgs e)
        {

            // x^2
            label1.Text = Convert.ToDouble(Convert.ToDouble(label1.Text) * Convert.ToDouble(label1.Text)).ToString();
        }

    
        private void button20_Click(object sender, EventArgs e)
        {
            // =
           
            String s = "";
            if(io)
            {
              

                if (!label2.Text.EndsWith("+") && !label2.Text.EndsWith("-") && !label2.Text.EndsWith("*") && !label2.Text.EndsWith("/"))
                {
                    s = label2.Text;
                    Console.WriteLine("LLL1" + s);

                }
                else
                {
                    s = label2.Text + " " + label1.Text;
                    Console.WriteLine("LLL2" + s);

                }
                if (count != 0)
                {
                  //  label2.Text = label2.Text + " " + label1.Text;
                    for (int i = 0; i < count; i++)
                    {
                        s += " )";
                        Console.WriteLine("LLL" + s);
                    }
                    //     Console.WriteLine("LLL" + s);
                }
               

                string post = infixToPostfix(s);
                Console.Write("Post " + post);

                if(post.Contains("invalid"))
                {
                    label1.Text = "Invalid input";
                }
                else
                {
                    string[] a = post.Split(' ');
                    double[] b = new double[15];
                    int max = a.Length;

                    for (int i = 0; i < max; i++)
                    {
                        //Console.WriteLine(a[i]);
                        if (a[i].Equals("+") || a[i].Equals("-") || a[i].Equals("*") || a[i].Equals("/"))
                        {
                            switch (a[i])
                            {
                                case "+":
                                    b[i] = Convert.ToDouble(a[i - 2]) + Convert.ToDouble(a[i - 1]);
                                    a[i - 2] = Convert.ToString(b[i]);

                                    //for loop for change place of values in arrray
                                    for (int j = i + 1; j < max; j++)
                                    {
                                        a[j - 2] = a[j];

                                    }

                                    a[max - 1] = "";
                                    a[max - 2] = "";
                                    max = max - 2;
                                    i = i - 2;
                                    //   Console.WriteLine("array after " + count + " evaluation ");
                                    for (int c = 0; c < max; c++)
                                    {
                                        //       Console.WriteLine(" + " + a[c]);
                                        ans = a[c];
                                    }
                                    break;

                                case "*":
                                    b[i] = Convert.ToDouble(a[i - 2]) * Convert.ToDouble(a[i - 1]);
                                    a[i - 2] = Convert.ToString(b[i]);

                                    //for loop for change place of values in arrray
                                    for (int j = i + 1; j < max; j++)
                                    {
                                        a[j - 2] = a[j];
                                    }

                                    a[max - 1] = "";
                                    a[max - 2] = "";

                                    max = max - 2;
                                    i = i - 2;
                                    count++;
                                    //   Console.WriteLine("array after " + count + " evaluation ");
                                    for (int c = 0; c < max; c++)
                                    {
                                        //       Console.WriteLine(a[c]);
                                        ans = a[c];
                                    }
                                    break;

                                case "-":
                                    b[i] = Convert.ToDouble(a[i - 2]) - Convert.ToDouble(a[i - 1]);
                                    a[i - 2] = Convert.ToString(b[i]);

                                    //for loop for change place of values in arrray
                                    for (int j = i + 1; j < max; j++)
                                    {
                                        a[j - 2] = a[j];
                                    }
                                    a[max - 1] = "";
                                    a[max - 2] = "";

                                    max = max - 2;
                                    i = i - 2;
                                    count++;
                                    //  Console.WriteLine("array after " + count + " evaluation ");
                                    for (int c = 0; c < max; c++)
                                    {
                                        //     Console.WriteLine("- " + a[c]);
                                        ans = a[c];

                                    }
                                    break;


                                case "/":
                                    b[i] = Convert.ToDouble(a[i - 2]) / Convert.ToDouble(a[i - 1]);
                                    a[i - 2] = Convert.ToString(b[i]);

                                    //for loop for change place of values in arrray
                                    for (int j = i + 1; j < max; j++)
                                    {
                                        a[j - 2] = a[j];
                                    }

                                    //fill last to place of array with NULL
                                    a[max - 1] = "";
                                    a[max - 2] = "";

                                    max = max - 2;
                                    i = i - 2;
                                    count++;
                                    //  Console.WriteLine("array after " + count + " evaluation ");
                                    for (int c = 0; c < max; c++)
                                    {
                                        //       Console.WriteLine(a[c]);
                                        ans = a[c];

                                    }
                                    break;
                            }

                        }

                    }
                    label1.Text = ans;
                    label2.Text = "";
                    check = false;
                    count = 0;
                }
               
                }
            else
            {
                int len = label2.Text.IndexOf('(') + 1;
                int endlen = label2.Text.IndexOf(')');
                int c = endlen - len;
                if(label2.Text.Contains("Sin("))
                {
                    label1.Text = Math.Sin(DegreeToRadian(Convert.ToDouble(label2.Text.Substring(len, c)))).ToString();
                }
                else if(label2.Text.Contains("Cos("))
                {
                    label1.Text = Math.Cos(DegreeToRadian(Convert.ToDouble(label2.Text.Substring(len, c)))).ToString();
                }
                else if(label2.Text.Contains("Tan("))
                {
                    label1.Text = Math.Tan(DegreeToRadian(Convert.ToDouble(label2.Text.Substring(len, c)))).ToString();
                }
                else if(label2.Text.Contains("Sin-1("))
                {
                    label1.Text = Math.Asin(Convert.ToDouble(label2.Text.Substring(len, c))).ToString();
                }
                else if(label2.Text.Contains("Cos-1("))
                {
                    label1.Text = Math.Acos(Convert.ToDouble(label2.Text.Substring(len, c))).ToString();
                }
                else if(label2.Text.Contains("Tan-1("))
                {
                    label1.Text = Math.Atan(Convert.ToDouble(label2.Text.Substring(len, c))).ToString();
                }
                label2.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 355;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            c = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "";
            c = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //sine
            
            label2.Text = label2.Text + " Sin(" + label1.Text + ")";
            check = true;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + " Cos(" + label1.Text + ")";
            check = true;

        }

        private void button27_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + " Tan(" + label1.Text + ")";
            check = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(label1.Text.Length ==1)
            {
                label1.Text = "0";
            }
            else if(label1.Text.EndsWith("."))
            {
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
                c = false;
            }
            else
            {
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + " Cos-1(" + label1.Text + ")";
            b = false;

            check = true;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            label2.Text = label2.Text + " Tan-1(" + label1.Text + ")";
            b = false;

            check = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // .
            if(!c)
            {
                label1.Text = label1.Text + ".";
                c = true;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int fact, number;
            number =Convert.ToInt32( label1.Text) ;
            fact = number;
            for (int i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }
            label1.Text = fact.ToString();
            check = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            // pie
            label1.Text = "3.14";
            check = true;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            /// sqrt
            label1.Text = Math.Sqrt(Convert.ToDouble(label1.Text)).ToString();
            check = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // log10
            label1.Text = Math.Log10(Convert.ToDouble(label1.Text)).ToString();
            check = true;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //10^x
            int ans=10;
            for(int i=0; i<Convert.ToInt32(label1.Text)-1; i++)
            {
                ans = ans * 10;
            }
            label1.Text = ans.ToString();
            check = true ;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //M+ 

            M = M + Convert.ToDouble(label1.Text);
            button32.Enabled = true;
            button29.Enabled = true;

        }

        private void button30_Click(object sender, EventArgs e)
        {
            //M-

            M = M - Convert.ToDouble(label1.Text);
            button32.Enabled = true;
            button29.Enabled = true;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //MC
            M = 0;
            button32.Enabled = false;
            button29.Enabled = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //MR
            label1.Text = M.ToString();
            check = true;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            // + /-
            if(p_m)
            {
                label1.Text = (0 - Convert.ToDouble(label1.Text)).ToString();
                p_m = false;
            }
            else
            {
                label1.Text = (0 - Convert.ToDouble(label1.Text)).ToString();
                p_m = true;
            }
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 355;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 584;
        }
    }
}
