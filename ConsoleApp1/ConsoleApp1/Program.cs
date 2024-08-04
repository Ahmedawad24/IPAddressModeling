namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IP ip = new IP(119,223,154,123);
            Console.WriteLine($"FULL IP ADDRESS: {ip.Address}");


            var firstseg = ip[0];
            var secondseg = ip[1];
            var thirdseg = ip[2];
            var fourthseg = ip[3];
            Console.WriteLine($"First Segment:{firstseg}\nSecond Segment:{secondseg}\nThird Segment:{thirdseg}\nFourth Segment:{fourthseg}");


            var ip2 = new IP("119.223.154.123");
            Console.WriteLine($"IP Using String Input → {ip2.Address}");
            Console.ReadLine();
        }



        public class IP
        {
            private int[] _segments = new int[4];

            //indexer 
            public int this[int index]
            {
                get
                {
                    return _segments[index];
                }
                set
                {
                    _segments[index] = value;
                }
            }


            // segment 1-255
            public IP(int seg1, int seg2, int seg3, int seg4)
            {
                int[] ipsegs = new int[4] { seg1, seg2, seg3, seg4 }; 
                if(isValidate(ipsegs))
                {
                    _segments = ipsegs;
                }

            }
            public IP(string IPAddress)
            {
                var seg = IPAddress.Split(".");
                int[] ipsegs = new int[4];

                for (int i = 0; i < seg.Length; i++)
                {
                    ipsegs[i] = Convert.ToInt32(seg[i]);
                }

                if (isValidate(ipsegs))
                {
                    _segments = ipsegs;
                }
            }

            public static bool isValidate(int[] x)
            { 
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] < 0 || x[i] > 255)
                    {
                        Console.WriteLine("Out of Range segment has been entered");
                        return false;
                    }
                }
                return true;
            }
            public string Address => string.Join(".", _segments);

        }
    }
}