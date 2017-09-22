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
            
            
            List<Tuple<int,int>> collect = new List<Tuple<int,int>>();
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
                String[] info1 = content.Split(' ');
                int left;
                Int32.TryParse(info1[0], out left);
                int right;
                Int32.TryParse(info1[1], out right);
                Tuple<int, int> A = new Tuple<int, int>(left,right);
                collect.Add(A);
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
                Tuple<int,int> compare = collect.ElementAt(index);
                long xl=compare.Item1;
                long yl=compare.Item2;
               
                List<Tuple<int,int>> solution = new List<Tuple<int,int>>();

                for (int i = 0; i < collect.Count; i++)
                {
                    if (i != index)
                    {
                        Tuple<int,int> compare2 = collect.ElementAt(i);
                        long xr=compare2.Item1;
                        long yr=compare2.Item2;
                     
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
        public static int MSort(List<Tuple<int,int>> array, int left, int right,int d)
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
                        Tuple<int,int> lefts = array.ElementAt(left);
                        long x1=lefts.Item1;
                        long y1=lefts.Item2;
                        
                        Tuple<int,int> rights = array.ElementAt(right);
                        long x2=rights.Item1;
                        long y2=rights.Item2;
                      
                        if (Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) < Math.Pow(d, 2))
                        {
                            return leftresult;
                        }
                        else
                        {
                            List<Tuple<int,int>> temp = new List<Tuple<int,int>>();
                            Tuple<int,int> compare = array.ElementAt(leftresult);
                            long xl=compare.Item1;
                            long yl=compare.Item2;
                           
                            for (int i = left; i <= center; i++)
                            {
                                if (i != leftresult)
                                {
                                    Tuple<int,int> compare2 = array.ElementAt(i);
                                    long xr=compare2.Item1;
                                    long yr=compare2.Item2;
                                    
                                    if (Math.Pow(xl - xr, 2) + Math.Pow(yl - yr, 2) < Math.Pow(d, 2))
                                    {
                                        temp.Add(array.ElementAt(i));
                                    }
                                }
                            }
                           
                            List<Tuple<int,int>> Rtemp = new List<Tuple<int,int>>();
                            Tuple<int,int> Rcompare = array.ElementAt(rightresult);
                            long Rxl=Rcompare.Item1;
                            long Ryl=Rcompare.Item2;
                            
                            for (int i = center+2; i <= right; i++)
                            {
                                Tuple<int,int> Rcompare2 = array.ElementAt(i);
                                long Rxr=Rcompare2.Item1;
                                long Ryr=Rcompare2.Item2;
                                
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
