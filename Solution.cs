public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int a1 = m - 1;

        int a2 = n - 1;

        int a = m + n - 1;

        while (nums1[a1] > 0 && nums2[a2] > 0)
        {
            if (nums1[a1] > nums2[a2])
            {
                nums1[a] = nums1[a1];
                a1 -= 1;
            }
            else
            {
                nums1[a] = nums2[a2];
                a2 -= 1;
            }
            a -= 1;


        }
        while (a2 >= 0)
        {
            nums1[a] = nums2[a2];
            a2--;
            a--;
        }




    }
    public int RemoveElement(int[] nums, int val)
    {

        int k = 0;

        for (int i = 0; i < nums.Length; i++)
        {

            if (nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }


        }

        return k;

    }
    public int MajorityElement(int[] nums)
    {
        int n = nums.Length;
        int k = 1;
        int candidate = nums[0];
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == candidate)
            {
                k++;
            }
            if (nums[i]!= candidate)
            {
                k--;
            }
            if (k == 0)
            {
                candidate = nums[i];
                k=1;
            }
        }
        return candidate;
    }
    public bool IsPalindrome(string s)
    {
        
        int left = 0;
        int right = s.Length-1;
        

        if(string.IsNullOrEmpty(s))
        {
            return true;
        }
        while (left < right)
        {   
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }
            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }
            left++;
            right--;
        }   
        return true;


       
    }

}