#include <bits/stdc++.h>
using namespace std;

int frec[100000];

int main(){
    long long similarity = 0;
    int n = 1000;
    vector<int> l1(n), l2(n);
    int el1, el2;
    for(int i = 0; i < n; i++) {
        cin >> l1[i] >> l2[i];
        frec[l2[i]]++;
    }

    for(int i = 0; i < l1.size(); i++){
        similarity += (l1[i] * frec[l1[i]]);
    }
    
    cout << similarity;
}
