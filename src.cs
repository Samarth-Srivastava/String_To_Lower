using System.Text;

namespace String_To_Lower{
	public class Solution{
		public string solve(List<char> A){
			//var ans = ToLower(A);
			//var ans = ToUpper(A);
			//var ans = new List<char> { IsAlphaNumeric(A).ToString()[0] };
			var ans = IsPalindrome(new String(A.ToArray()));
			return ans;
		}

		public List<char> ToLower(List<char> A){
			int N = A.Count();

			for(int i = 0; i < N; i++){
				int ascii_char = A[i];
				if(ascii_char >= 97 && ascii_char <= 122){
					continue;
				}
				if(ascii_char >= 65 && ascii_char <= 90){
					A[i] = Convert.ToChar(A[i] ^ 32);
				}
			}
			return A;
		}

		public List<char> ToUpper(List<char> A){
			int N = A.Count();

			for(int i = 0; i < N; i++){
				int ascii_char = A[i];
				if(ascii_char >= 97 && ascii_char <= 122){
					A[i] = Convert.ToChar(A[i] ^ 32);
				}
				if(ascii_char >= 65 && ascii_char <= 90){
					continue;
				}
			}
			return A;
		}
		
		public int IsAlphaNumeric(List<char> A){
			int N = A.Count();
			int flag = 1;
			for(int i = 0; i < N; i++){
				int ascii_char = A[i];
				if((ascii_char < 48) || (ascii_char > 57 && ascii_char < 65) || (ascii_char > 90 && ascii_char < 97)){
					flag = 0;
					break;
				}
			}
			return flag;
		}
		
		public string IsPalindrome(string A){
			int N = A.Length;
			int maxLen = -1;
			int startPoint = N;
			string ans = string.Empty;
			
			for(int i = 1; i < N; i++){
				List<int> temp = ExpandFromCentreCheckPalindrome(A, i, i);
				if(temp.Count() > 0){
					int len = temp[1]-temp[0]-1;
					if(maxLen < len){
						maxLen = temp[1]-temp[0]-1;
						ans = subStr(A, temp[0], temp[1]);
					}
				}
			}
			for(int i = 0; i < N-1; i++){
				List<int> temp = ExpandFromCentreCheckPalindrome(A, i, i+1);
				if(temp.Count() > 0){
					int len = temp[1]-temp[0];
					if(maxLen < len){
						maxLen = temp[1]-temp[0];
						ans = subStr(A, temp[0], temp[1]);
					}
				}
			}

			return ans;
		}

		public int CheckStringPalindrome(string A, int start, int end){
			int N = A.Length;
			int flag = 1;
			while(start < end){
				if(A[start] != A[end]){
					flag = 0;
					break;
				}
				start++;
				end--;
			}
			return flag;
		}

		public List<int> ExpandFromCentreCheckPalindrome(string A, int start, int end){
			int N = A.Length;
			int flag = 0;

			while(start >= 0 && end < N){
				if(A[start] == A[end]){
					flag = 1;
					break;
				}
				start--;
				end++;
			}
			List<int> ans = new List<int>();
			if(flag == 1){
				ans.Add(start);
				ans.Add(end);
			}
			return ans;
		}

		public int max(int a , int b){
			if(a > b){
				return a;
			}
			return b;
		}
	
		public string subStr(string A, int start, int end=-1){
            int N = A.Length;
            if(end < start){
                return string.Empty;
            }
            if(end == -1){
                end = N-1;
            }
			if(start == -1){
				start = 0;
			}
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < end; i++)
            {
                sb.Append(A[i]);
            }
            return sb.ToString();
        }

	}
}
