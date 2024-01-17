
#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;
int main()
{
    ios::sync_with_stdio(0);
    cin.tie(NULL);
    
    int woodCount{}, needWoods{};
    int cutHeight{};
    vector<int> woods{};
    
    cin >> woodCount >> needWoods;
    
    woods.reserve(woodCount);
    for(int i=0;i<woodCount;++i)
    {
        int height;
        cin >> height;
        woods.emplace_back(height);
    }
    
    sort(woods.begin(),woods.end(),greater<int>());
    cutHeight = woods[0];
    for(int i=1;i<woods.size();++i)
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
    int restHeight = ceil(restHeightf);
    cout << cutHeight - restHeight;
}
