#include <iostream>
#include <math.h>
using namespace std;
int main()
{
    int a{};
    int b{};
    int v{};
    int result{};

    cin >> a >> b >> v;

    result = ceil(((double)v - a) / ((double)a - b)) + 1;
    cout << result;
}