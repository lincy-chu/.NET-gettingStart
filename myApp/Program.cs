using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace myApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("The current time is " + DateTime.Now);
            WorkingWithIntegers();
            TestLimits();
            WorkWithDoubles();
            DecimalTest();
            OtherTest();
            CycleTest();
            ArrayTest();
            More();
            TestMore();
            StringMore();
            InterfaceTest();
            AboutCSharp();
            TypeAndVar();
        }

        private static void WorkingWithIntegers() // 封装成方法
        {
            // 1.处理C#中的整数和浮点数
            const int a = 18;
            const int b = 6;
            var c = a + b; // 加法
            Console.WriteLine(c);
            c = a - b; // 减法
            Console.WriteLine(c);
            c = a * b; // 乘法
            Console.WriteLine(c);
            c = a / b; // 除法
            Console.WriteLine(c);
            c = a + b - 12 * 17; // 混合使用变量和常量
            Console.WriteLine(c);
            var d = (a + b) * c; // 可以在要优先执行的一个或多个运算前后加括号，从而强制改变运算顺序
            Console.WriteLine(d);
            // 整数有一个有趣的行为，整数除法始终生成整数结果，即使预期结果有小数或分数部分也是如此
            const int f = 11 / 3;
            Console.WriteLine(f);
        }

        private static void TestLimits()
        {
            // 取余
            const int g = 11 % 3;
            Console.WriteLine(g);
            
            // 整数的最大值和最小值
            const int max = int.MaxValue;
            const int min = int.MinValue;
            Console.WriteLine($"The range of integers is {min} to {max}");
        }

        private static void WorkWithDoubles()
        {
            const double h = 19;
            const double i = 23;
            const double j = (h + i) / 8;
            Console.WriteLine($"j = {j}");
            const double max = double.MaxValue;
            const double min = double.MinValue;
            Console.WriteLine($"The range of double is {min} to {max}"); // E左侧为有效数字，右侧是10的n次幂
            const double third = 1.0 / 3.0; // 双精度值可能会存在四舍五入误差
            Console.WriteLine(third);
        }

        private static void DecimalTest()
        {
            /**
             * 使用固定点类型
             * decimal类型，decimal类型的范围较小，但精度高于double。"固定点"一词意味着，十进制小数点（或二进制小数点）不会移动
             */
            const decimal min = decimal.MinValue;
            const decimal max = decimal.MaxValue;
            Console.WriteLine($"min = {min}, and max = {max}");

            const decimal a = 1.0M;
            const decimal b = 3.0M; // 数字中的M后缀指明了常数应如何使用decimal类型
            Console.WriteLine(a / b);

            const double pi = Math.PI;
            const double radius = 2.5;
            Console.WriteLine(radius * radius * pi);
        }

        private static void OtherTest()
        {
            // 布尔值
            const bool a = true;
            const bool b = false;
            Console.WriteLine($"布尔值：{a}, {b}");
            // 字符串
            const string c = "Hello";
            var d = "H";
            d += "ello"; // 连接字符串
            Console.WriteLine(c == d); // True，以内字符串的内容是相等的
            Console.WriteLine(object.ReferenceEquals(c, d)); // 但c和d并不指代同一个字符串实例
            // char
            const string str = "test";
            var x = str[2];
            Console.WriteLine(x);
        }

        private static void CycleTest()
        {
            Fun(1, 2);
            Fun(3, 10);
            Console.WriteLine(FunOne(3, 6));
            Console.WriteLine(FunOne(5, 5));
            // 使用循环重复执行运算
            WhileOne();
            WhileTwo();
            // 使用for循环
            ForOne();
            // 计算总数
            Console.WriteLine(Sum());
        }

        private static void Fun(int a, int b) // 方法，并设置参数
        {
            if (a + b > 10)
            {
                Console.WriteLine("The answer is greater than 10.");
            }
            else
            {
                Console.WriteLine("The answer is smaller than 10.");
            }
        }

        private static bool FunOne(int a = 3, int b = 5)
        {
            const int c = 5;
            return (a + b + c > 10) && (a == b);
        }

        private static void WhileOne()
        {
            var counter = 0;
            while (counter < 10)
            {
                Console.WriteLine($"The counter is {counter}");
                counter++;
            }
        }

        private static void WhileTwo(int counter = 0)
        {
            do
            {
                Console.WriteLine($"The Counter IS {counter}");
                counter++;
            } while (counter < 10);
        }

        private static void ForOne(int max = 10)
        {
            for (var i = 0; i < max; i++)
            {
                Console.WriteLine($"The index is {i}");
            }
        }

        private static int Sum(int num = 100)
        {
            var sum = 0;
            for (var i = 1; i <= num; i++)
            {
                sum += i;
            }
            return sum;
        }

        private static void ArrayTest()
        {
            // 数组
            var names = new List<string> { "Jack", "Rose", "Robin" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name}!"); // 显示名称的代码使用字符串内插功能，如果String前面有$符号，可以在字符串声明中嵌入C#代码。实际上字符串使用自己生成的值替换该C#代码
            }
            
            // 修改列表内容
            names.Add("Anna");
            names.Add("Jeff");
            names.Add("Lucy"); // 向数组中添加元素
            names.Remove("Jeff"); // 移除指定元素
            foreach (var item in names)
            {
                Console.WriteLine($"{names.IndexOf(item)} - {item}");
            }
            
            // 数组排序 -- sort()按正常顺序（按字母顺序，如果是字符串的话）
            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"排序后：{names.IndexOf(name)} - {name}");
            }
            
            // 其他类型的列表
            var fibonacci = new List<int>{1, 1}; // 创建一个整数列表，并将头两个整数设置为值1。这些是裴波那契数列的头两个值。斐波那契数列中的每个数字都是前两个数字之后。
            var previous = fibonacci[^1];
            var previous2 = fibonacci[^2];
            fibonacci.Add(previous + previous2);
            foreach (var item in fibonacci)
            {
                Console.WriteLine(item);
            }
            // 利用循环计算裴波那契数列
            var fibonacci1 = new List<int>{1, 1};
            while (fibonacci1.Count < 20)
            {
                var pre = fibonacci1[^1];
                var pre1 = fibonacci1[^2];
                fibonacci1.Add(pre + pre1);
            }

            foreach (var item in fibonacci1)
            {
                Console.WriteLine(item);
            }
        }

        private static void More()
        {
            var person = new Person("Zhu", "Da", "Peng");
            Console.WriteLine($"The name, in all caps: {person.AllCaps()}");
            Console.WriteLine($"The name: {person}");

            const string phrase = "the quick brown fox jumps over the lazy dog";
            var wordLength = from word in phrase.Split(' ') select word.Length;
            var enumerable = wordLength as int[] ?? wordLength.ToArray();
            WriteLine($"The average word length is: {enumerable.Average():F2}");
            WriteLine($"The average word length is: {enumerable.Average()}");
        }

        private static void TestMore()
        {
            // 异常筛选器
            // 使用异常筛选器可以捕获基于某些条件的异常。典型用法是创建筛选器方法，该方法记录异常，但从不处理异常
            try
            {
                const string s = null;
                // WriteLine(s.Length);
                WriteLine(s);
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
            
            // 使用nameof
            // nameof运算符返回任何变量、类型或类型成员的名称
            WriteLine(nameof(System.String));
            const int j = 5;
            WriteLine(nameof(j));
            List<string> names = new List<string>();
            WriteLine(nameof(names));
            
            // 新的对象初始化语法
            // 对象初始化设定项语法现在支持初始化索引器以及属性和字段。此添加使初始化字典和其他类型更容器。
            // 此语法在索引器中设置值，可用于在索引器上具有访问的set访问器的任何类型
            var messages = new Dictionary<int, string>
            {
                [404] = "Page not Found",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };
            WriteLine(messages[302]);
        }

        private static void StringMore()
        {
            // 内插字符串
            const string name = "robin";
            WriteLine($"Hello, {name}. It's a pleasure to meet you!");
            
            // 包含不同的数据类型
            var (s, price, perPackage) = (name: "eggplant", price: 1.99m, perPackage: 3);
            var date = DateTime.Now;
            // 通过字符串内插，可以指定用于控制特定类型格式的格式字符串。可通过在内插表达式后面接冒号(:)和格式字符串来指定格式字符串。'd'是标准日期和时间格式字符串，表示短日期格式。'C2'是标注数值格式字符串，用数字表示货币值（精确到小数点后两位）
            // date 默认显示年月时间
            // date:d 只显示年月
            // date:t 只显示时间
            // date:y 只显示年月
            // date:yyyy 只显示4位年份
            WriteLine($"On {date}, the price of {s} was {price:C2} per {perPackage} items.");
            WriteLine($"On {date:d}, the price of {s} was {price:C2} per {perPackage} items.");
            WriteLine($"On {date:t}, the price of {s} was {price:C2} per {perPackage} items.");
            WriteLine($"On {date:y}, the price of {s} was {price:C2} per {perPackage} items.");
            WriteLine($"On {date:yyyy}, the price of {s} was {price:C2} per {perPackage} items.");
            // :C3保留三位小数
            WriteLine($"On {date}, the price of {s} was {price:C3} per {perPackage} items.");
            
            // 字符串内插的高级方案
            // 字符串插值功能构建在复合格式设置功能的基础之上，提供更具有可读性、更方便的语法，用于将设置了格式的表达式结果包括到结果字符串。可嵌入任何会在内插字符串中返回值的有效C#表达式
            const double a = 3;
            const double b = 4;
            double CalculateHypotenuse(double leg1, double leg2) => Math.Sqrt(leg1 * leg1 + leg2 * leg2);
            WriteLine($"Area of the right triangle with legs of {a} and {b} is {0.5 * a * b}");
            WriteLine($"Length of hypotenuse of the right triangle with legs of {a} and {b} is {CalculateHypotenuse(a, b)}");
            var theDate = new DateTime(2008, 8, 8, 20, 0, 0, 0);
            WriteLine($"On {theDate:yyyy/MM/dd dddd}, China was holding the Olympic opening ceremony!");

            var xs = new int[] { 1, 2, 7, 9 };
            var yx = new int[] { 7, 9, 12 };
            WriteLine($"Find the intersection of the {{{string.Join(", ", xs)}}} and {{{string.Join(", ", yx)}}} sets.");
            
            // 在内插表达式中使用三元条件运算符?:
            var random = new Random();
            for (var i = 0; i < 7; i++)
            {
                WriteLine($"Coin flip: {(random.NextDouble() < 0.5 ? "heads": "tails")}");
            }
        }

        private static void InterfaceTest()
        {
            // 使用默认接口方法更新接口
            // 从.NET Core3.0上的C#8.0开始，可以在声明接口成员时定义实现，常用的方案是安全地将成员添加到已经由无数客户端发布并使用的接口。添加了默认接口实现用于升级接口。默认接口实现使开发人员能够升级接口，同时仍允许任何实现器替代该实现。库的用户可以接受默认实现作为非中断性变更。如果业务规则不同，则可以进行替代
            var overHeadLight = new OverheadLight(false);
            WriteLine(overHeadLight.ToString());
            overHeadLight.SwitchOn();
            WriteLine(overHeadLight.ToString());
            overHeadLight.SwitchOff();
            WriteLine(overHeadLight.IsOn());
            WriteLine(overHeadLight.ToString());
        }

        private static void AboutCSharp()
        {
            /**
             * C#中的关键组织结构概念包括程序、命名空间、类型、成员和程序集。C#程序由一个或多个源文件组成。程序声明类型，而类型则包含成员，并被整理到命名空间中。类型实例包括类和接口。成员示例包括字段、方法、属性和事件。编译完的C#程序实际上会打包到程序集中。程序集的文件扩展名通常是.exe或.dll，具体取决于实现的是应用程序还是库。
             */
            var s = new Stack();
            s.Push(1);
            s.Push(10);
            s.Push(100);
            WriteLine(s.Pop());
            WriteLine(s.Pop());
            WriteLine(s.Pop());
        }

        private static void TypeAndVar()
        {
            // 类型和变量
            
            // 枚举
            const int x = (int) Day.Sun;
            const int y = (int) Day.Fri;
            WriteLine("Sun = {0}", x);
            WriteLine("Fri = {0}", y);
        }

        private class Person
        {
            private string FirstName { get; set; }
            private string LastName { get; set; }

            private string MiddleName { get; } = ""; // 初始化自动属性的支持字段

            public Person(string first, string middle, string last)
            {
                this.FirstName = first;
                this.MiddleName = middle;
                this.LastName = last;
            }

            public override string ToString() => FirstName + " " + LastName; // expression-bodied成员为轻量级方法提供轻量级语法

            public string AllCaps() => ToString().ToUpper();
        }
    }
}