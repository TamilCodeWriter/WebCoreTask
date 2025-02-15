namespace WebCoreTask.Class
{
    public class MyTask
    {


       
        public void ReverseString()
        {
            string input = "Tamil";
            char[] charArray = new char[input.Length];
            int forwardIndex = 0;
            int reverseIndex = input.Length - 1;

            while (reverseIndex >= 0)
            {
                charArray[forwardIndex] = input[reverseIndex];
                forwardIndex++;
                reverseIndex--;
            }
            Console.WriteLine(new string(charArray));
            // return new string(charArray);
        }
        public void ReverseStringDF()
        {
          
            string input = "Vashi";      
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray); 

           Console.WriteLine(new string(charArray));
            
            int a = 7;int b = 3;
            int result = AddWithoutPlush(a,b);
            int result1 = substractWithouMinus(a,b);
            Console.WriteLine($"A and B Sum{result}");
            Console.WriteLine($"A - B Sum{result1}");
           
            swapWithoutArithmetic(a,b);
            
            findFibo(1);
            long resultfact = FindFact(5);
            Console.WriteLine($"factorial is : {resultfact}");
            isPrime(13);
        }

        static int AddWithoutPlush(int a,int b)
        {
            if (b == 0)
                return a;
            return AddWithoutPlush(a ^ b, (a & b) << 1);
        }

        static int substractWithouMinus(int a,int b) { 
        
            while (b != 0)
            {
                int br = (~a & b)<<1;
                a = a ^ b;
                b = br;
            }
            return a;
        }
        static void swapWithoutArithmetic(int a,int b)
        {
            a=a^b;
            b=a^b;
            a=a^b;
            Console.WriteLine($"After swapping: a = {a}, b = {b}");
        }

        static void findFibo(int n)
        {
            if (n <= 1) 
            { Console.WriteLine(n);
            }
            else
            {
               int previous = 0; int current = 1;
                for (int i = 2; i <= n; i++)
                {
                    int next = previous + current;
                    previous = current;
                    current = next;
                    Console.WriteLine(current);
                }
            }
           
          
            //return current;
        }

        static long FindFact(int n)
        {
            if (n < 0) throw new ArgumentException("Negative number not accept");
            long result =1;
            for(int i = 1; i <= n; i++)
            {
                result *=i;
            }
            return result;
        }

        static void isPrime(int number)
        {
            bool isPrimeNumber = true;
            if (number <= 1) { Console.WriteLine("Not a prime Number");
            }
            else if (number == 2)
                {
                    Console.WriteLine($"prime Number:{number}");
                }
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    for(int j = 2; j <= number; j++)
                    {
                        if (i!=j && i%j == 0)
                        {
                            isPrimeNumber = false;

                            break;
                        }
                    }
                    
                    if (isPrimeNumber)
                    {
                        Console.WriteLine(i);
                    }
                    isPrimeNumber = true;
                }
            }

            reverseLoop();
        }

        static void reverseLoop()
        {
            String original = "Hellooo";

            String Reverse = "";
            for(int i =original.Length-1; i>=0; i--)
            {
                Reverse += original[i];
            }
            Console.WriteLine(Reverse);
        }
    }
}
