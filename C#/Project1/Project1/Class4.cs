using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Class4
    {
        public Class4()
        {
            bool check = true;
            int arrCnt = 0;
            do
            {
                try
                {
                    Console.Write("만들고 싶은 배열방의 크기를 정해주세요 : ");
                    arrCnt = checked(Convert.ToInt32(Console.ReadLine()));
                    // checked 는 런타임 오버플로 검사하는 과정에서 사용된다.
                    // 여기에서는 Convert.ToInt32를 하는 과정에서 int형으로 변환될 수 있는 string이 아닌
                    // 다른 string을 입력한다면 런타임 오버플로가 발생하여
                    // catch문이 바로 실행된다. 하지만 정상적으로 입력을 받은 경우
                    // check = false;의 실행으로 do-while을 빠져나갈 수 있는 조건이 완성된다.
                    check = false;
                    // 올바른 정수값을 입력받았다면 빠져나옴.
                    // 정수값이 아니라면 에러메시지표시후 재입력하게 한다.
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (check);
            //입력받은 정수값크기의 배열을 만든다.
            int[,] array = new int[arrCnt, arrCnt];
            int x = 0;  //배열의 열위치
            int y = -1;  //배열의 행위치
            int s = 1;  //배열의 숫자입력 방향을 바꿀때 사용
            int num = 0; //입력되는 숫자값
            int size = arrCnt;
            for (int i = 0; i < arrCnt; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    y = y + s;   // [0,1,2,3,4] [3,2,1,0] [1,2,3] [2,1] [2]
                    num++;
                    array[x, y] = num;
                }
                size--;
                if (size != 0)
                {
                    for (int j = 0; j < size; j++)
                    {
                        x = x + s;    // [1,2,3,4] [3,2,1] [2,3] [2]
                        num++;
                        array[x, y] = num;
                    }
                }
                s = s * (-1); // -1, 1, -1, 1
            }
            //배열값을 출력한다.
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write("{0,3}", array[i, j]);
                Console.WriteLine();
            }
        }
    }
}
