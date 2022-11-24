using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1;

namespace test {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void shuffle_test_1(){
            int[] expected = new int[]{};
			int[] actual = Program.shuffle(new int[]{});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shuffle_test_2(){
            int[] expected = new int[]{5};
			int[] actual = Program.shuffle(new int[]{5});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shuffle_test_3(){
            int[] unexpected = Program.get_sorted_array(10000);
			int[] actual = Program.shuffle(Program.get_sorted_array(10000));
			Assert.AreEqual(unexpected.Length, actual.Length);
            int unchange = 0;
			for(int i=0; i<unexpected.Length; i++){
                if(unexpected[i] == actual[i]){
                    unchange++;
                }
			}
            Assert.IsTrue(unchange < unexpected.Length/2);
		}


		[TestMethod]
		public void bubble_sort_test_1(){
            int[] expected = new int[]{};
			int[] actual = Program.bubble_sort(new int[]{});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void bubble_sort_test_2(){
            int[] expected = new int[]{5};
			int[] actual = Program.bubble_sort(new int[]{5});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void bubble_sort_test_3(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = Program.shuffle(Program.get_sorted_array(10000));
			int[] actual = Program.bubble_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void bubble_sort_test_4(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = (Program.get_sorted_array(10000));
            System.Array.Reverse(to_func);
			int[] actual = Program.bubble_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
        
		[TestMethod]
		public void shaker_sort_test_1(){
            int[] expected = new int[]{};
			int[] actual = Program.shaker_sort(new int[]{});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shaker_sort_test_2(){
            int[] expected = new int[]{5};
			int[] actual = Program.shaker_sort(new int[]{5});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shaker_sort_test_3(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = Program.shuffle(Program.get_sorted_array(10000));
			int[] actual = Program.shaker_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shaker_sort_test_4(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = (Program.get_sorted_array(10000));
            System.Array.Reverse(to_func);
			int[] actual = Program.shaker_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
        
		[TestMethod]
		public void comb_sort_test_1(){
            int[] expected = new int[]{};
			int[] actual = Program.comb_sort(new int[]{});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void comb_sort_test_2(){
            int[] expected = new int[]{5};
			int[] actual = Program.comb_sort(new int[]{5});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void comb_sort_test_3(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = Program.shuffle(Program.get_sorted_array(10000));
			int[] actual = Program.comb_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void comb_sort_test_4(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = (Program.get_sorted_array(10000));
            System.Array.Reverse(to_func);
			int[] actual = Program.comb_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
        
		[TestMethod]
		public void insert_sort_test_1(){
            int[] expected = new int[]{};
			int[] actual = Program.insert_sort(new int[]{});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void insert_sort_test_2(){
            int[] expected = new int[]{5};
			int[] actual = Program.insert_sort(new int[]{5});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void insert_sort_test_3(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = Program.shuffle(Program.get_sorted_array(10000));
			int[] actual = Program.insert_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void insert_sort_test_4(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = (Program.get_sorted_array(10000));
            System.Array.Reverse(to_func);
			int[] actual = Program.insert_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
        
		[TestMethod]
		public void shell_hib_sort_test_1(){
            int[] expected = new int[]{};
			int[] actual = Program.shell_hib_sort(new int[]{});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shell_hib_sort_test_2(){
            int[] expected = new int[]{5};
			int[] actual = Program.shell_hib_sort(new int[]{5});
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shell_hib_sort_test_3(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = Program.shuffle(Program.get_sorted_array(10000));
			int[] actual = Program.shell_hib_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
		[TestMethod]
		public void shell_hib_sort_test_4(){
            int[] expected = Program.get_sorted_array(10000);
            int[] to_func = (Program.get_sorted_array(10000));
            System.Array.Reverse(to_func);
			int[] actual = Program.shell_hib_sort(to_func);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int i=0; i<expected.Length; i++){
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
	}
}
