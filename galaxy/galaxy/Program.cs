using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> collect = new List<string>();
            String content = Console.ReadLine() ;
            String[] info = content.Split(' ');
            int d;
            Int32.TryParse(info[0], out d);
            int k;
            Int32.TryParse(info[1], out k);
            int count = 0;
            while (content!=""||content!=null)
            {
                if (count > k)
                {
                    break;
                }
                collect.Add(content);
                content = Console.ReadLine();
                count++;
             }
            collect.Remove(collect.ElementAt(0));
            int index = MSort(collect, 0, collect.Count-1, d);
            if (index == -1)
            {
                Console.WriteLine("NO");
                Console.Read();
            }
            else
            {
                String[] compare = collect.ElementAt(index).Split(' ');
                long xl;
                long yl;
                long.TryParse(compare[0], out xl);
                long.TryParse(compare[1], out yl);
                List<string> solution = new List<string>();

                for (int i = 0; i < collect.Count; i++)
                {
                    if (i != index)
                    {
                        string[] compare2 = collect.ElementAt(i).Split(' ');
                        long xr;
                        long yr;
                        long.TryParse(compare2[0], out xr);
                        long.TryParse(compare2[1], out yr);
                        if (Math.Pow(xl - xr, 2) + Math.Pow(yl - yr, 2) < Math.Pow(d, 2))
                        {
                            solution.Add(collect.ElementAt(i));
                        }
                    }

                }
                solution.Add(collect.ElementAt(index));
                if (solution.Count > k / 2)
                {
                    Console.WriteLine(solution.Count);
                    Console.Read();
                }else
                {
                    Console.WriteLine("NO");
                    Console.Read();
                }

            }

        }
        public static int MSort(List<string> array, int left, int right,int d)
        {

            int center;
            if (left < right)
            {
                center = (left + right) / 2;
                int leftresult = MSort(array, left, center,d);
                int rightresult = MSort(array, center + 1, right,d);
                if (leftresult==-1&&rightresult==-1)
                {
                    return -1;
                }else
                {
                    if (leftresult!=-1&&rightresult==-1)
                    {
                       
                        return leftresult;
                    }
                    else if(leftresult==-1&&rightresult!=-1)
                    {
                        
                        return rightresult;
                    }
                    else
                    {
                        String[] lefts = array.ElementAt(left).Split(' ');
                        long x1;
                        long y1;
                        long.TryParse(lefts[0], out x1);
                        long.TryParse(lefts[1], out y1);
                        String[] rights = array.ElementAt(right).Split(' ');
                        long x2;
                        long y2;
                        long.TryParse(rights[0], out x2);
                        long.TryParse(rights[1], out y2);
                        if (Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) < Math.Pow(d, 2))
                        {
                            return leftresult;
                        }
                        else
                        {
                            List<string> temp = new List<string>();
                            string[] compare = array.ElementAt(leftresult).Split(' ');
                            long xl;
                            long yl;
                            long.TryParse(compare[0], out xl);
                            long.TryParse(compare[1], out yl);
                            for (int i = left; i <= center; i++)
                            {
                                if (i != leftresult)
                                {
                                    string[] compare2 = array.ElementAt(i).Split(' ');
                                    long xr;
                                    long yr;
                                    long.TryParse(compare2[0], out xr);
                                    long.TryParse(compare2[1], out yr);
                                    if (Math.Pow(xl - xr, 2) + Math.Pow(yl - yr, 2) < Math.Pow(d, 2))
                                    {
                                        temp.Add(array.ElementAt(i));
                                    }
                                }
                            }
                           
                            List<string> Rtemp = new List<string>();
                            string[] Rcompare = array.ElementAt(rightresult).Split(' ');
                            long Rxl;
                            long Ryl;
                            long.TryParse(Rcompare[0], out Rxl);
                            long.TryParse(Rcompare[1], out Ryl);
                            for (int i = center+2; i <= right; i++)
                            {
                                string[] Rcompare2 = array.ElementAt(i).Split(' ');
                                long Rxr;
                                long Ryr;
                                long.TryParse(Rcompare2[0], out Rxr);
                                long.TryParse(Rcompare2[1], out Ryr);
                                if (Math.Pow(Rxl - Rxr, 2) + Math.Pow(Ryl - Ryr, 2) < Math.Pow(d, 2))
                                {
                                    Rtemp.Add(array.ElementAt(i));
                                }
                            }
                            if (temp.Count == 0&&Rtemp.Count==0||temp.Count==Rtemp.Count)
                            {
                                return -1;
                            }
                            
                            temp.Add(array.ElementAt(left));
                            Rtemp.Add(array.ElementAt(center+1));
                            if (temp.Count > Rtemp.Count)
                            {
                                return leftresult;
                            }else
                            {
                                return rightresult;
                            }
                        }
                    }
                }
                

            }
            else
            {
                return left;
            }

        }
    }
}
