using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequenceWithQueue
{
    static void Main(string[] args)
    {
        var queue = new Queue<long>();
        int counter = 1;
        var number = long.Parse(Console.ReadLine());
        long sValue = 1;
        int sIndex = 0;
        for (int i = 0; i < 49; i++)
        {
            if(i==0)
            {
                queue.Enqueue(number);
            }
            switch (counter) {
                case 1:                   
                    var array = queue.ToArray();
                    sValue = array[sIndex];
                    sIndex++;
                    queue.Enqueue(sValue + 1);
                    counter = 2;
                    break;
                case 2:
                    queue.Enqueue(2*sValue + 1);
                    counter = 3;
                    break;
                case 3:
                    queue.Enqueue(sValue + 2);
                    counter = 1;                    
                    break;
            }
        }
        while(queue.Count!=0)
        {
            Console.Write(queue.Dequeue()+" ");
        }
    }
}

