using System;
using System.Collections.Generic;

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
    }
}