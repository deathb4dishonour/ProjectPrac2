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
using ThinkLib;

namespace B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string s = "test";
        string t = "TEST";
        public MainWindow()
        {

            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Tester.TestEq(length(s), 4);
            Tester.TestEq(contains(s, "st"), true);
            Tester.TestEq(indexOf(s, "st"), 2);
            Tester.TestEq(insertSubString(s, "ab", 1), "tabest");
            Tester.TestEq(replaceSubString(s, "cd", "te"), "cdst");
            Tester.TestEq(deleteSubString(s, "es"),"tt");
            Tester.TestEq(split(s,'e'),new List<string>{ "t","st"});
            Tester.TestEq(stringCompare(s, "tesz"), 1);
            Tester.TestEq(toLower(t), "test");
            Tester.TestEq(toUpper(t), "TEST");
        }
        int length(string s)
        {
            int c = 0;
            foreach (var x in s)
            {
                c++;
            }
            return c;
        }
        int length(char[] s)
        {
            int c = 0;
            foreach (var x in s)
            {
                c++;
            }
            return c;
        }
        bool contains(string s, string subs)
        {
            int subsCount = 0;
            int sCount = 0;
            int matchCount = 0;
            for (int i1 = subsCount; i1 < length(subs); i1++)
            {
                 for (int i2 =sCount; i2 < length(s); i2++)
                    {
                    if (subs[i1] == s[i2])
                    {
                        matchCount++;
                        if (matchCount == length(subs))
                        {
                            return true;
                        }
                        break;
                    }
                    else if (subs[i1] != s[i2])
                    {
                        subsCount = 0;
                        sCount++;
                    }



                        }
                

                    }
            return false;
                }

          
        
        int indexOf(string s, string subs)
        
        {
            for (int i = 0; i < length(s); i++)
            {
                if (subs[0]==s[i])
                {
                    return i;
                }
            }
            return -1;
        }
          
        
    
        string insertSubString(string s, string x, int pos)
        {
            string fin1 = "";
            string fin2 = "";

            for (int i = 0; i < pos; i++)
            {
                fin1 += s[i];
            }
            fin1 += x;
            for (int i = pos; i < length(s); i++)
            {
                fin2 += s[i];
            }
            return fin1+fin2;
        }
        string replaceSubString(string s, string n, string o){
            int find = indexOf(s,o);
            string output = "";      
            List<string> sList = new List<string> { s };
            for (int i = 0; i <find; i++)
            {
                output += s[i];
            }
            output += n;
            for (int i = length(n); i < length(s); i++)
            {
                output += s[i];
            }
            return output;
}
        string deleteSubString(string s, string subs)
        {
            
            string fin1 = "";
            string fin2 = "";
            int idx = indexOf(s,subs);
            for (int i = 0; i < idx; i++)
            {
                fin1 += s[i];
            }
            for (int i2 = idx+length(subs); i2 <length(s); i2++)
            {
                fin2 += s[i2];
            }
            return fin1+fin2;
        }

        List<string> split(string s, char c)
        {
            int pos = 0;
            string fin1 = "";
            string fin2 = "";

            List<string> l = new List<string> { "", "" };

            for (int i1 = 0; i1 < length(s); i1++)
            {
                if (s[i1] == c)
                {
                    pos = i1;
                    break;

                }
            }
                for (int i2 = 0; i2 < pos; i2++)
                {
                    fin1 += s[i2];
                }
                for (int i3 = pos + 1; i3 <length(s); i3++)
                {
                    fin2 += s[i3];
                }

                l[0] = fin1;
                l[1] = fin2;
                return l;
            
        }
        
        int stringCompare(string s1, string s2)
        {
            //assume equal length
            
            for (int i = 0; i < length(s1); i++)
            {

                 if ((Convert.ToInt32(s1[i]) > Convert.ToInt32(s2[i])))
                {
                    return -1;
                }
                if ((Convert.ToInt32(s1[i]) < Convert.ToInt32(s2[i])))
                {
                    return 1;
                }
                if (i==length(s1) &&length(s1)>length(s2))
                {
                    return -1;
                }
                if (i == length(s1) && length(s1) < length(s2))
                {
                    return 1;
                }
            }
            return 0;
            }
        string toLower(string t)
        {
            char[] u = t.ToCharArray();
            char[] large = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] small = { 'a', 'b', 'c', 'd', 'e','f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's','t', 'u', 'v', 'w', 'x', 'y','z' };
            for (int i1 = 0; i1 < u.Length; i1++)
            {
                for (int i2 = 0; i2 < length(large); i2++)
                {
                    if (u[i1]==large[i2])
                    {
                        u[i1] = small[i2];
                    }
                }
            }
            string output = "";
            for(int i = 0; i < length(u); i++)
            {
                output += u[i];
            }
            return output ;
        }
        string toUpper(string s)
        {
            char[] u = s.ToCharArray();
            char[] large = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] small = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int i1 = 0; i1 < u.Length; i1++)
            {
                for (int i2 = 0; i2 <length(large); i2++)
                {
                    if (u[i1] == small[i2])
                    {
                        u[i1] = large[i2];
                    }
                }
            }
            string output = "";
            for (int i = 0; i < length(u); i++)
            {
                output += u[i];
            }
            return output;
        }





    }
}
