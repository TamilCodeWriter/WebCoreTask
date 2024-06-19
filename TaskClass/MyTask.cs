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
            
            int a = 4;int b = 3;
            int result = AddWithoutPlush(a,b);
            int result1 = substractWithouMinus(a,b);
            Console.WriteLine($"A and B Sum{result}");
            Console.WriteLine($"A - B Sum{result1}");
            swapWithoutArithmetic(a,b);
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
    }
}
