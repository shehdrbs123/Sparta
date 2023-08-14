// See https://aka.ms/new-console-template for more information



public class Program
{
    static void Main(string[] args)
    {
        // 기본 조건 문
        if(true) { }
        // if else
        if (true) { }
        else { }
        
        // if else if
        if (true) { } else if(false){ }
        // 중첩
        if (true) { if(true){ }}
        
        // switch
        // 설정한 자료형을 설정 해줘야한다.
        int a = 0;
        switch(a)
        {
            case 0 :
                break;
            default :
                break;
        }
        // 3항 연산자, 복잡하다면 안쓰는게 좋지
        int b = true ? 1 : 0;

        int number = int.Parse(Console.ReadLine());
        
        isOddorEven(number);
        ForTest();
        // 디버깅 브레이크 포인트 설정 방법,
        // F9를 이용해도 된다. 해당라인을 브레이크 포인트로 설정해준다.
    }

    public static void isOddorEven(int a)
    {
        Console.WriteLine("홀수/짝수 구하기");
        if ((a %= 2) == 0)
        {  
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");
        }
    }

    public static string PrintGrade(int rank)
    {
        string grade = "Bronze";
        switch (rank/10)
        {
            case 10 :
            case 9 :
                
                break;
            case 8:
                break;
            case 5 :
                break;
            case 4 :
                break;
            case 3 :
                break;
            default :
                
                break;
        }

        return grade;
    }
    // 반복문 기본
    private static void ForTest()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
    }
    // 조건식, 증감규칙을 한번에 볼수 있어서 좋다.
    // 인덱싱이나, 정해진 수를 돌아야할 떄 유리함.
    
    // WHILE문
    private static void WhileTest()
    {
        int i = 0;
        while (i > 10)
        {
            Console.WriteLine(i);
            ++i;
        }
    }
    // 정해진 수가 아닌 부분을 구현할 때 편함.
    // 링크드 리스트같이 레퍼런싱을 지속적으로 넘어갈때 편하다.
    
    //foreach문
    private static void ForEachTest()
    {
        int[] a = new int[10];
        foreach (var value in a)
        {
            Console.WriteLine($"{value}");
        }
    }
    // 배열을 읽을 떄 쓰면 좋음
    // 인덱싱 오류가 발생하지 않아서 안전함
    // 다만 내부적으로 iterator를 사용하므로, 중간에 배열이 수정되면 오류 발생가능
    
    
    // 중첩반복문
    // 그냥 반복문 두번 쓰면 된다.
    private static void DuplyForTest()
    {
        int[] a = new int[10];
        foreach (var value in a)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{value}");
            }
        }
    }
    // 구구단 뽑기
    // 한줄에 1~9단 까지 뽑아보기
    

    // break와 continue;
    // 반복문에서 사용함.
    // break :  반복문에서 나감(현재를 기준으로 감싸고 있는 반복문)
    // continue : 밑에 실행하지 않고 다음 회차로 넘어감
    
    // 반복문 심화
    // 직접 만들어 보기
    // 가위바위보 게임

    public static void RockPaperCissors()
    {
        
    }
    
    // 숫자 맞추기 
    public static void numberCheckGame()
    {
        
    }
    
    
}