#include <bits/stdc++.h>
using namespace std;

int main(){
    long long distance = 0;
    int n = 1000;
    vector<int> l1(n), l2(n);
    int el1, el2;
    for(int i = 0; i < n; i++)
        cin >> l1[i] >> l2[i];

    sort(l1.begin(), l1.end());
    sort(l2.begin(), l2.end());

    for(int i = 0; i < l1.size(); i++)
        distance += (max(l1[i], l2[i]) - min(l1[i], l2[i]));

    cout << distance;
}
