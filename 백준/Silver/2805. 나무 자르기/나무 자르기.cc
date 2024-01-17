
#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(NULL);
    
    long long woodCount{}, needWoods{};
    long long cutHeight{};
    vector<long long> woods{};
    
    cin >> woodCount >> needWoods;
    
    woods.reserve(woodCount);
    for(long long i=0;i<woodCount;++i)
    {
        long long height;
        cin >> height;
        woods.emplace_back(height);
    }
    
    sort(woods.begin(),woods.end(),greater<long long>());
    cutHeight = woods[0];
    for(long long i=1;i<woods.size();++i)
    {
        needWoods -= (woods[i-1]-woods[i])*i;
        cutHeight = woods[i];
        if(needWoods == 0)
        {
            cout << cutHeight;
            return 0;            
        }else if (needWoods < 0)
        {
            cout << cutHeight - needWoods/i;
            return 0;
        }
    }

    float restHeightf = (float)needWoods / woods.size();
    long long restHeight = ceil(restHeightf);
    cout << cutHeight - restHeight;
}