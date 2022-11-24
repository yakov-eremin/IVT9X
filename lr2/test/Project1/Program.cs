using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1 {
	public class Program {
		public static int Main(string[] args){
			return 0;
		}

		public static int[] shuffle(int[] arr){
			Random rand = new Random();
			int tmp, j;
			for(int i = arr.Length - 1; i >= 1; i--){
				j = rand.Next(i + 1);
				tmp = arr[j];
				arr[j] = arr[i];
				arr[i] = tmp;
			}

			return arr;
		}

		public static int[] get_sorted_array(int len){
            if(len < 1){
                return new int[]{ };
            }

            int[] arr = new int[len];
			for(int i = 0; i < len; i++){
				arr[i] = i+1;
			}

			return arr;
		}


		public static int[] bubble_sort(int[] arr){
			if(arr.Length <= 1){
				return arr;
			}

			bool change = false;
			int size = arr.Length;
			int tmp;
			do{
				change = false;
				for(int i = 0; i < size-1; i++){
					if(arr[i] > arr[i+1]){
						tmp = arr[i];
						arr[i] = arr[i+1];
						arr[i+1] = tmp;
						change = true;
					}
				}
				size--;

			}while(change);

			return arr;
		}

		public static int[] shaker_sort(int[] arr){
			if(arr.Length <= 1){
				return arr;
			}

			bool change = false;
			int start = 0;
			int end = arr.Length-1;
			int tmp;
			do{
				change = false;
				for(int i = start; i < end; i++){
					if(arr[i] > arr[i+1]){
						tmp = arr[i];
						arr[i] = arr[i+1];
						arr[i+1] = tmp;
						change = true;
					}
				}
				end--;
				if(!change){
					break;
				}

				for(int i = end; i > start; i--){
					if(arr[i] < arr[i-1]){
						tmp = arr[i];
						arr[i] = arr[i-1];
						arr[i-1] = tmp;
						change = true;
					}
				}
				start++;

			}while(change);

			return arr;

		}

		public static int[] comb_sort(int[] arr){
			if(arr.Length <= 1){
				return arr;
			}

			double k = 1.2473309;
			int step = arr.Length - 1;
			
			int tmp;
			while(step > 1) {
				for(int i = 0; i + step < arr.Length; i++){
					if(arr[i] > arr[i+step]){
						tmp = arr[i];
						arr[i] = arr[i+step];
						arr[i+step] = tmp;
					}
				}
				step = (int)(step / k);
			}

			return bubble_sort(arr);
		}

		public static int[] insert_sort(int[] arr){
			if(arr.Length <= 1){
				return arr;
			}

			int tmp;
			for(int i = 1; i < arr.Length; i++){
				int j = i;
				while(j > 0 && arr[j-1] > arr[j]){
					tmp = arr[j];
					arr[j] = arr[j-1];
					arr[j-1] = tmp;
					j--;
				}
			}

			return arr;
		}

		public static int[] shell_hib_sort(int[] arr){
			if(arr.Length <= 1){
				return arr;
			}

			int step = 1;
			while(step < arr.Length){
                step <<= 1;
            }
			step >>= 1;
			step--;
            int tmp;
			while(step >= 1){
				for(int i = step; i < arr.Length; i++) {
					int j = i;
					int diff = j - step;
					while(diff >= 0 && arr[diff] > arr[j]) {
						tmp = arr[j];
					    arr[j] = arr[diff];
					    arr[diff] = tmp;
						
                        j = diff;
						diff = j - step;
					}
				}
				step /= 2;
			}

			return arr;
		}
	}
}
